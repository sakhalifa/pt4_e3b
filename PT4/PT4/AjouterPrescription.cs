using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;

namespace PT4
{
    public partial class AjouterPrescription : PT4.TemplateSoin
    {
        public AjouterPrescription(MaladiesController diseaseController, ProduitController productController, SoinController careController, ServiceCollection service) : base(diseaseController, productController, careController, service)
        {
            InitializeComponent();
        }
    }
}
