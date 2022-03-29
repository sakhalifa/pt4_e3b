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

        public void SubscribeProducts(OnChanged<PRODUIT> onChanged)
        {
            _produitRepository.Subscribe(onChanged);
        }

        public void SubscribeDeleteProducts(OnDelete<PRODUIT> onDelete)
        {
            _produitRepository.SubscribeDelete(onDelete);
        }

        public void UnSubscribeProducts(OnChanged<PRODUIT> onChanged)
        {
            _produitRepository.UnSubscribe(onChanged);
        }

        public void UnSubscribeDeleteProducts(OnDelete<PRODUIT> onDelete)
        {
            _produitRepository.UnSubscribeDelete(onDelete);
        }

        public IQueryable<PRODUIT> GetAllSellableProducts()
        {
            return _produitRepository.FindWhere((p) => p.PRIXDEVENTE.HasValue);
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
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (p) => p.NOMPRODUIT);
                            break;
                        case "Prix d'achat":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new DecimalCriteria((decimal)checkObj, checkType.Value), (p) => p.PRIXACHAT);
                            break;
                        case "Prix de vente":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new NullableDecimalCriteria((decimal)checkObj, checkType.Value, false), (p) => p.PRIXDEVENTE);
                            break;
                        case "Quantité":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new ShortCriteria(Convert.ToInt16(checkObj), checkType.Value), (p) => p.QUANTITEENSTOCK);
                            break;
                        case "Description":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (p) => p.DESCRIPTION);
                            break;
                        case "Medicament":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new BoolCriteria((bool)checkObj), (p) => p.MEDICAMENT);
                            break;
                        case "Vendable":
                            if ((bool)checkObj)
                            {
                                Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new IsNullCriteria(CriteriaCheckType.NE), (p) => p.PRIXDEVENTE);
                            }
                            else
                            {
                                Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new IsNullCriteria(CriteriaCheckType.EQ), (p) => p.PRIXDEVENTE);
                            }
                            break;
                    }
                }
            }
            return finalExpr;
        }

        

    }
}