
namespace PT4
{
    partial class AjouterStock
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
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.description = new System.Windows.Forms.TextBox();
            this.quantite = new System.Windows.Forms.NumericUpDown();
            this.prixVente = new System.Windows.Forms.NumericUpDown();
            this.nom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prixVenteLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.estMedic = new System.Windows.Forms.CheckBox();
            this.prixAchat = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.modifier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixVente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixAchat)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ajouter";
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(217, 417);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(75, 23);
            this.buttonAjouter.TabIndex = 22;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(16, 417);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 20;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(48, 233);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(211, 156);
            this.description.TabIndex = 19;
            // 
            // quantite
            // 
            this.quantite.Location = new System.Drawing.Point(48, 167);
            this.quantite.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.quantite.Name = "quantite";
            this.quantite.Size = new System.Drawing.Size(120, 20);
            this.quantite.TabIndex = 18;
            // 
            // prixVente
            // 
            this.prixVente.Location = new System.Drawing.Point(48, 128);
            this.prixVente.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.prixVente.Name = "prixVente";
            this.prixVente.Size = new System.Drawing.Size(120, 20);
            this.prixVente.TabIndex = 17;
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(48, 53);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(100, 20);
            this.nom.TabIndex = 16;
            this.nom.TextChanged += new System.EventHandler(this.nom_TextChanged);
            this.nom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nom_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Quantité:";
            // 
            // prixVenteLabel
            // 
            this.prixVenteLabel.AutoSize = true;
            this.prixVenteLabel.Location = new System.Drawing.Point(45, 112);
            this.prixVenteLabel.Name = "prixVenteLabel";
            this.prixVenteLabel.Size = new System.Drawing.Size(69, 13);
            this.prixVenteLabel.TabIndex = 13;
            this.prixVenteLabel.Text = "Prix de vente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nom:";
            // 
            // estMedic
            // 
            this.estMedic.AutoSize = true;
            this.estMedic.Location = new System.Drawing.Point(212, 107);
            this.estMedic.Name = "estMedic";
            this.estMedic.Size = new System.Drawing.Size(90, 17);
            this.estMedic.TabIndex = 23;
            this.estMedic.Text = "Médicament?";
            this.estMedic.UseVisualStyleBackColor = true;
            // 
            // prixAchat
            // 
            this.prixAchat.Location = new System.Drawing.Point(48, 89);
            this.prixAchat.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.prixAchat.Name = "prixAchat";
            this.prixAchat.Size = new System.Drawing.Size(120, 20);
            this.prixAchat.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Prix d\'achat";
            // 
            // modifier
            // 
            this.modifier.Location = new System.Drawing.Point(115, 417);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(75, 23);
            this.modifier.TabIndex = 26;
            this.modifier.Text = "Modifier";
            this.modifier.UseVisualStyleBackColor = true;
            this.modifier.Click += new System.EventHandler(this.modifier_Click);
            // 
            // AjouterStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 477);
            this.Controls.Add(this.modifier);
            this.Controls.Add(this.prixAchat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.estMedic);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.description);
            this.Controls.Add(this.quantite);
            this.Controls.Add(this.prixVente);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prixVenteLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "AjouterStock";
            this.Text = "AjouterStock";
            ((System.ComponentModel.ISupportInitialize)(this.quantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixVente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixAchat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.NumericUpDown quantite;
        private System.Windows.Forms.NumericUpDown prixVente;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label prixVenteLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox estMedic;
        private System.Windows.Forms.NumericUpDown prixAchat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button modifier;
    }
}