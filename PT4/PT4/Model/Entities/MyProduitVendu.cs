namespace PT4
{
    public partial class PRODUIT_VENDU
    {
        public decimal Montant { get => this.PRODUIT.PRIXDEVENTE.Value * this.QUANTITÉ; }
    }
}
