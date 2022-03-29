namespace PT4
{
	partial class ModifierAnimal
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
			if(disposing && (components != null))
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
            ((System.ComponentModel.ISupportInitialize)(this.poids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // ModifierAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(698, 257);
            this.Name = "ModifierAnimal";
            ((System.ComponentModel.ISupportInitialize)(this.poids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
	}
}
