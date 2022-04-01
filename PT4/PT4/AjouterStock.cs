using PT4.Controllers;

namespace PT4
{
    public partial class AjouterStock : TemplateModifierStock
    {
        public AjouterStock(ProduitController produitController) : base(produitController)
        {
            InitializeComponent();
        }
    }
}
