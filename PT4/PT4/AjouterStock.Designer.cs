
namespace PT4
{
    partial class AjouterStock
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.quantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixAchat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixVente)).BeginInit();
            this.SuspendLayout();
            // 
            // titre
            // 
            this.titre.Text = "Ajouter Stock";
            // 
            // AjouterStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(304, 477);
            this.Name = "AjouterStock";
            ((System.ComponentModel.ISupportInitialize)(this.quantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixAchat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixVente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
