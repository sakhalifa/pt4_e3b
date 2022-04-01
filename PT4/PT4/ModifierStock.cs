using PT4.Controllers;

namespace PT4
{
    public partial class ModifierStock : PT4.TemplateModifierStock
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="produitController">Instance of ProduitController</param>
        /// <param name="estAdmin">boolean admin</param>
        public ModifierStock(ProduitController produitController) : base(produitController)
        {
            InitializeComponent();
            this.IsAdd = false;
        }

        /// <summary>
        /// it put the product to modify 
        /// </summary>
        /// <param name="p">Instance of PRODUIT</param>
        public override void SetProduit(PRODUIT p)
        {
            base.SetProduit(p);
            quantite.Value = p.QUANTITEENSTOCK;
        }
    }
}
