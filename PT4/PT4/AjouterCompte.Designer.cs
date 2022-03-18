
namespace PT4
{
    partial class AjouterCompte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titre = new System.Windows.Forms.Label();
            this.nomDeCompte = new System.Windows.Forms.Label();
            this.textBoxCompte = new System.Windows.Forms.TextBox();
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.confirmerMotDePasse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMdp = new System.Windows.Forms.TextBox();
            this.motDePasse = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titre
            // 
            this.titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titre.AutoSize = true;
            this.titre.BackColor = System.Drawing.Color.Transparent;
            this.titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titre.Location = new System.Drawing.Point(29, 21);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(148, 20);
            this.titre.TabIndex = 0;
            this.titre.Text = "Création de compte";
            this.titre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nomDeCompte
            // 
            this.nomDeCompte.AutoSize = true;
            this.nomDeCompte.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.nomDeCompte.Location = new System.Drawing.Point(53, 50);
            this.nomDeCompte.Name = "nomDeCompte";
            this.nomDeCompte.Size = new System.Drawing.Size(82, 13);
            this.nomDeCompte.TabIndex = 1;
            this.nomDeCompte.Text = "Nom de compte";
            // 
            // textBoxCompte
            // 
            this.textBoxCompte.Location = new System.Drawing.Point(45, 66);
            this.textBoxCompte.Name = "textBoxCompte";
            this.textBoxCompte.Size = new System.Drawing.Size(100, 20);
            this.textBoxCompte.TabIndex = 2;
            this.textBoxCompte.TextChanged += new System.EventHandler(this.textBoxCompte_TextChanged);
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConnexion.ForeColor = System.Drawing.Color.Black;
            this.buttonConnexion.Location = new System.Drawing.Point(60, 217);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(75, 23);
            this.buttonConnexion.TabIndex = 3;
            this.buttonConnexion.Text = "Créer";
            this.buttonConnexion.UseVisualStyleBackColor = false;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.confirmerMotDePasse);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxMdp);
            this.panel2.Controls.Add(this.motDePasse);
            this.panel2.Controls.Add(this.titre);
            this.panel2.Controls.Add(this.nomDeCompte);
            this.panel2.Controls.Add(this.textBoxCompte);
            this.panel2.Controls.Add(this.buttonConnexion);
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(295, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 264);
            this.panel2.TabIndex = 6;
            // 
            // confirmerMotDePasse
            // 
            this.confirmerMotDePasse.Location = new System.Drawing.Point(45, 179);
            this.confirmerMotDePasse.Name = "confirmerMotDePasse";
            this.confirmerMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.confirmerMotDePasse.TabIndex = 9;
            this.confirmerMotDePasse.TextChanged += new System.EventHandler(this.confirmerMotDePasse_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(30, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirmer le Mot de passe";
            // 
            // textBoxMdp
            // 
            this.textBoxMdp.Location = new System.Drawing.Point(45, 121);
            this.textBoxMdp.Name = "textBoxMdp";
            this.textBoxMdp.Size = new System.Drawing.Size(100, 20);
            this.textBoxMdp.TabIndex = 7;
            this.textBoxMdp.TextChanged += new System.EventHandler(this.textBoxMdp_TextChanged);
            // 
            // motDePasse
            // 
            this.motDePasse.AutoSize = true;
            this.motDePasse.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.motDePasse.Location = new System.Drawing.Point(64, 105);
            this.motDePasse.Name = "motDePasse";
            this.motDePasse.Size = new System.Drawing.Size(71, 13);
            this.motDePasse.TabIndex = 6;
            this.motDePasse.Text = "Mot de passe";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PT4.Properties.Resources.zebra_g8a6d9221f_1920;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 447);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // AjouterCompte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AjouterCompte";
            this.Text = "newCompte";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label nomDeCompte;
        private System.Windows.Forms.TextBox textBoxCompte;
        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox confirmerMotDePasse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMdp;
        private System.Windows.Forms.Label motDePasse;
    }
}