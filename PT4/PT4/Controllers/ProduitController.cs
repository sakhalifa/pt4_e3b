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
        public void CreerOuMaJProduit(string nom, decimal? prixVente, decimal prixAchat, int quantite, string description, bool estMedicament, bool add)
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



            //To ensure the order of combinations, I have to first go through all the rows
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
                            CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (p) => p.NOMPRODUIT);
                            break;
                        case "Prix d'achat":
                            CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new DecimalCriteria((decimal)checkObj, checkType.Value), (p) => p.PRIXACHAT);
                            break;
                        case "Prix de vente":
                            CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new NullableDecimalCriteria((decimal)checkObj, checkType.Value, false), (p) => p.PRIXDEVENTE);
                            break;
                        case "Quantité":
                            CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new ShortCriteria(Convert.ToInt16(checkObj), checkType.Value), (p) => p.QUANTITEENSTOCK);
                            break;
                        case "Description":
                            CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (p) => p.DESCRIPTION);
                            break;
                        case "Medicament":
                            CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new BoolCriteria((bool)checkObj), (p) => p.MEDICAMENT);
                            break;
                        case "Vendable":
                            if ((bool)checkObj)
                            {
                                CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new IsNullCriteria(CriteriaCheckType.NE), (p) => p.PRIXDEVENTE);
                            }
                            else
                            {
                                CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new IsNullCriteria(CriteriaCheckType.EQ), (p) => p.PRIXDEVENTE);
                            }
                            break;
                    }
                }
            }
            return finalExpr;
        }

        private void CreateCriteriaCheckFunc<T>(ref Expression<Func<PRODUIT, bool>> expr, CriteriaCombinationType? combinationType, Func<Criteria<T>> provider, Expression<Func<PRODUIT, T>> productToTExpr)
        {
            Criteria<T> criteria = provider();
            var pParameter = expr.Parameters[0];

            //We replace the parameter of the lambda with pParameter
            Expression prodToT = ReplacingExpressionVisitor.Replace(productToTExpr.Parameters[0], pParameter, productToTExpr.Body);

            //We have to re-lambda the converted expression :(
            var exprProd = Expression.Lambda(prodToT, pParameter);

            //We get the expression that checks the criteria
            var func = criteria.CreateFunctionFromCriteria();

            /*We replace the value we check with the property of p.
                (Conversion from Func<T, bool> to Func<PRODUIT, bool> basically).
                i.e: we convert for example (b) => b == true to (p) => p.property == true
                b is a boolean, p is a Product and p.property is a boolean
            */
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            //Then we create the lambda that is basically the function (p) => func(p.property)
            var lambdaNew = Expression.Lambda<Func<PRODUIT, bool>>(newExpr, pParameter);

            //If we don't have to combine it then we just return it.
            if (combinationType is null)
            {
                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    //We create an AND operation between the already established expression in {expr} and our criteria check function.
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);

                    //Then we create the lambda which is basically (p) => expr(p.property) && func(p.property)
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(andExpr, pParameter);
                }
                else
                {
                    //We create an OR operation between the already established expression in {expr} and our criteria check function.
                    var orExpr = Expression.OrElse(expr.Body, lambdaNew.Body);

                    //Then we create the lambda which is basically (p) => expr(p.property) || func(p.property)
                    expr = Expression.Lambda<Func<PRODUIT, bool>>(orExpr, pParameter);
                }
            }
        }

    }
}