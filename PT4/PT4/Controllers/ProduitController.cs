using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PT4.Model;
using System.Linq.Expressions;
using System.Reflection;

namespace PT4.Controllers
{
    public class ProduitController
    {
        private IGenericRepository<PRODUIT> _produitRepository;

        public ProduitController(IGenericRepository<PRODUIT> produitRepository)
        {
            _produitRepository = produitRepository;
        }

        public IEnumerable<PRODUIT> RecupererTousProduits()
        {
            return _produitRepository.FindAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prix"></param>
        /// <param name="quantite"></param>
        /// <param name="description"></param>
        /// <param name="estMedicament"></param>
        /// <param name="add">true iif we want to add the quantities. Else false</param>
        public void CreerOuMaJProduit(string nom, decimal prixVente, decimal prixAchat, int quantite, string description, bool estMedicament, bool add)
        {
            PRODUIT prod = _produitRepository.FindWhere(p => p.NOMPRODUIT == nom).FirstOrDefault();
            List<PRODUIT> productsChanged = new List<PRODUIT>();
            if (prod == null)
            {
                prod = new PRODUIT()
                {
                    NOMPRODUIT = nom,
                    PRIXACHAT = prixAchat,
                    DESCRIPTION = description,
                    MEDICAMENT = estMedicament,
                    PRIXDEVENTE = prixVente,
                    QUANTITEENSTOCK = (short)quantite
                };
                productsChanged.Add(prod);
                _produitRepository.Insert(prod);
            }
            else
            {
                if (add)
                {
                    quantite += prod.QUANTITEENSTOCK;
                }
                //Si on a rien changé alors on fait pas le reste
                if (prod.PRIXACHAT == prixAchat
                    && prod.DESCRIPTION == description
                    && prod.MEDICAMENT == estMedicament
                    && prod.PRIXDEVENTE == prixVente
                    && prod.QUANTITEENSTOCK == (short)(quantite))
                    return;
                prod.PRIXACHAT = prixAchat;
                prod.DESCRIPTION = description;
                prod.MEDICAMENT = estMedicament;
                prod.PRIXDEVENTE = prixVente;
                prod.QUANTITEENSTOCK = (short)(quantite);
                productsChanged.Add(prod);
                _produitRepository.Update(prod);
            }
            _produitRepository.Save();
        }

        public IQueryable<PRODUIT> GetAlmostExpiredProducts()
        {
            return _produitRepository.FindWhere((p) => p.QUANTITEENSTOCK <= 10);
        }

        public void RemoveByName(string name)
        {
            PRODUIT prod = FindByName(name);
            if (prod != null)
            {
                _produitRepository.Delete(prod);
                _produitRepository.Save();
            }
        }

        public PRODUIT FindByName(string name)
        {
            return _produitRepository.FindWhere(p => p.NOMPRODUIT == name).FirstOrDefault();
        }

        public IQueryable<PRODUIT> FindByPredicate(Expression<Func<PRODUIT, bool>> expr)
        {
            return _produitRepository.FindWhere(expr);
        }

        public void SubscribeProducts(OnChanged<PRODUIT> onChanged)
        {
            _produitRepository.Subscribe(onChanged);
        }

        public void SubscribeDeleteProducts(OnDelete<PRODUIT> onDelete)
        {
            _produitRepository.SubscribeDelete(onDelete);
        }

        public Expression<Func<PRODUIT, bool>> CreateCriteriasFromForm(RechercheStock rS)
        {
            Expression<Func<PRODUIT, bool>> finalExpr = (p) => true;
            TableLayoutPanel table = rS.tableLayoutPanel1;
            for (int i = 0; i < table.RowCount; i++)
            {
                //If we are not at the line where we can insert a new criteria
                if (!(table.GetControlFromPosition(0, i) is Button))
                {
                    string criteria = null;
                    if (table.GetControlFromPosition(1, i) is ComboBox criteriaCb)
                    {
                        criteria = (string)criteriaCb.SelectedItem;
                    }
                    CriteriaCombinationType? combinationType = null;
                    if (table.GetControlFromPosition(0, i) is ComboBox combinationCb)
                    {
                        combinationType = CriteriaCombinationTypeHelper.FromString((string)(combinationCb.SelectedItem));
                    }
                    CriteriaCheckType? checkType = null;
                    if (table.GetControlFromPosition(2, i) is ComboBox checkCb)
                    {
                        checkType = CriteriaCheckTypeHelper.FromString((string)(checkCb.SelectedItem));
                    }

                    object checkObj = null;
                    if (table.GetControlFromPosition(3, i) is TextBox tb)
                    {
                        checkObj = tb.Text;
                    }
                    else if (table.GetControlFromPosition(3, i) is NumericUpDown nud)
                    {
                        checkObj = nud.Value;
                    }
                    else if (table.GetControlFromPosition(3, i) is CheckBox checkBox)
                    {
                        checkObj = checkBox.Checked;
                    }
                    switch (criteria)
                    {
                        case "Nom":
                            CreateNameCriteriaFunc(ref finalExpr, (string)checkObj, combinationType);
                            break;
                        case "Prix d'achat":
                            CreateBuyCriteriaFunc(ref finalExpr, (decimal)checkObj, combinationType, checkType.Value);
                            break;
                        case "Prix de vente":
                            CreateSellCriteriaFunc(ref finalExpr, (decimal)checkObj, combinationType, checkType.Value);
                            break;
                        case "Quantité":
                            CreateQuantityCriteriaFunc(ref finalExpr, (decimal)checkObj, combinationType, checkType.Value);
                            break;
                        case "Description":
                            CreateDescCriteriaFunc(ref finalExpr, (string)checkObj, combinationType);
                            break;
                        case "Medicament":
                            CreateIsDrugCriteriaFunc(ref finalExpr, (bool)checkObj, combinationType);
                            break;
                    }

                }
            }
            return finalExpr;
        }

        private void CreateIsDrugCriteriaFunc(ref Expression<Func<PRODUIT, bool>> expr, bool checkBool, CriteriaCombinationType? combinationType)
        {
            BoolCriteria criteria = new BoolCriteria(checkBool);
            var pParameter = expr.Parameters[0];
            Expression accessProperty = Expression.Property(pParameter, typeof(PRODUIT).GetProperty("MEDICAMENT"));
            LambdaExpression exprProd = Expression.Lambda(accessProperty, pParameter);

            //We get the expression that checks if a bool = checkedBool
            var func = criteria.CreateFunctionFromCriteria();
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);
            if (combinationType is null)
            {
                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    var andExpr = Expression.OrElse(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
            }
        }

        private void CreateDescCriteriaFunc(ref Expression<Func<PRODUIT, bool>> expr, string checkStr, CriteriaCombinationType? combinationType)
        {
            StringCriteria criteria = new StringCriteria(checkStr);

            var pParameter = expr.Parameters[0];
            Expression accessProperty = Expression.Property(pParameter, typeof(PRODUIT).GetProperty("DESCRIPTION"));
            LambdaExpression exprProd = Expression.Lambda(accessProperty, pParameter);

            //We get the expression that checks if a bool = checkedBool
            var func = criteria.CreateFunctionFromCriteria();
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);
            if (combinationType is null)
            {

                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    var andExpr = Expression.OrElse(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }

            }
        }

        private void CreateQuantityCriteriaFunc(ref Expression<Func<PRODUIT, bool>> expr, decimal checkDec, CriteriaCombinationType? combinationType, CriteriaCheckType checkType)
        {
            DecimalCriteria criteria = new DecimalCriteria(checkDec, checkType);

            var pParameter = expr.Parameters[0];
            Expression accessProperty = Expression.Property(pParameter, typeof(PRODUIT).GetProperty("QUANTITEENSTOCK"));
            LambdaExpression exprProd = Expression.Lambda(accessProperty, pParameter);

            //We get the expression that checks if a bool = checkedBool
            var func = criteria.CreateFunctionFromCriteria();
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);
            if (combinationType is null)
            {

                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    var andExpr = Expression.OrElse(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }

            }
        }

        private void CreateSellCriteriaFunc(ref Expression<Func<PRODUIT, bool>> expr, decimal checkDec, CriteriaCombinationType? combinationType, CriteriaCheckType checkType)
        {
            //TODO : Take into account unsellable products fuck this
            DecimalCriteria criteria = new DecimalCriteria(checkDec, checkType);

            var pParameter = expr.Parameters[0];
            Expression accessProperty = Expression.Property(pParameter, typeof(PRODUIT).GetProperty("PRIXDEVENTE"));
            Expression Value = Expression.Property(accessProperty, typeof(decimal?).GetProperty("Value"));
            LambdaExpression exprProd = Expression.Lambda(Value, pParameter);

            //We get the expression that checks if a bool = checkedBool
            var func = criteria.CreateFunctionFromCriteria();
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);
            if (combinationType is null)
            {

                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    var andExpr = Expression.OrElse(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }

            }
        }

        private void CreateBuyCriteriaFunc(ref Expression<Func<PRODUIT, bool>> expr, decimal checkDec, CriteriaCombinationType? combinationType, CriteriaCheckType checkType)
        {
            DecimalCriteria criteria = new DecimalCriteria(checkDec, checkType);

            var pParameter = expr.Parameters[0];
            Expression accessProperty = Expression.Property(pParameter, typeof(PRODUIT).GetProperty("PRIXACHAT"));
            LambdaExpression exprProd = Expression.Lambda(accessProperty, pParameter);

            //We get the expression that checks if a bool = checkedBool
            var func = criteria.CreateFunctionFromCriteria();
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);
            if (combinationType is null)
            {

                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    var andExpr = Expression.OrElse(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }

            }
        }

        private void CreateNameCriteriaFunc(ref Expression<Func<PRODUIT, bool>> expr, string checkStr, CriteriaCombinationType? combinationType)
        {
            StringCriteria criteria = new StringCriteria(checkStr);

            var pParameter = expr.Parameters[0];
            Expression accessProperty = Expression.Property(pParameter, typeof(PRODUIT).GetProperty("NOMPRODUIT"));
            LambdaExpression exprProd = Expression.Lambda(accessProperty, pParameter);
            
            //We get the expression that checks if a bool = checkedBool
            var func = criteria.CreateFunctionFromCriteria();
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);
            if (combinationType is null)
            {
                
                expr = lambdaNew;
            }
            else
            {
                if(combinationType == CriteriaCombinationType.AND) { 
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    var andExpr = Expression.OrElse(expr.Body, lambdaNew.Body);
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }

            }
        }
    }
}
