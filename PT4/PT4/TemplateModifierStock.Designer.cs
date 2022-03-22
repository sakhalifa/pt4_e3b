
namespace PT4
{
    partial class TemplateModifierStock
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
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.description = new System.Windows.Forms.TextBox();
            this.quantite = new System.Windows.Forms.NumericUpDown();
            this.prixAchat = new System.Windows.Forms.NumericUpDown();
            this.nom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vendable = new System.Windows.Forms.CheckBox();
            this.estMedic = new System.Windows.Forms.CheckBox();
            this.prixVente = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixAchat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prixVente)).BeginInit();
            this.SuspendLayout();
            // 
            // titre
            // 
            this.titre.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.titre.Dock = System.Windows.Forms.DockStyle.Top;
            this.titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.titre.Location = new System.Drawing.Point(0, 0);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(280, 20);
            this.titre.TabIndex = 4;
            this.titre.Text = "TITRE A MODIFIER";
            this.titre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.Location = new System.Drawing.Point(202, 408);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmer.TabIndex = 22;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = true;
            this.buttonConfirmer.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAnnuler.Location = new System.Drawing.Point(3, 408);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 20;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.White;
            this.description.ForeColor = System.Drawing.SystemColors.ControlText;
            this.description.Location = new System.Drawing.Point(48, 303);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(211, 91);
            this.description.TabIndex = 19;
            // 
            // quantite
            // 
            this.quantite.Location = new System.Drawing.Point(48, 243);
            this.quantite.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.quantite.Name = "quantite";
            this.quantite.Size = new System.Drawing.Size(120, 20);
            this.quantite.TabIndex = 18;
            // 
            // prixAchat
            // 
            this.prixAchat.Location = new System.Drawing.Point(48, 113);
            this.prixAchat.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.prixAchat.Name = "prixAchat";
            this.prixAchat.Size = new System.Drawing.Size(120, 20);
            this.prixAchat.TabIndex = 17;
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(48, 58);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(100, 20);
            this.nom.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(45, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(45, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Quantité:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(45, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Prix d\'achat:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(45, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nom:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PT4.Properties.Resources.zebra_g8a6d9221f_1920;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 479);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.vendable);
            this.panel1.Controls.Add(this.estMedic);
            this.panel1.Controls.Add(this.prixVente);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonConfirmer);
            this.panel1.Controls.Add(this.buttonAnnuler);
            this.panel1.Controls.Add(this.titre);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 456);
            this.panel1.TabIndex = 24;
            // 
            // vendable
            // 
            this.vendable.AutoSize = true;
            this.vendable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.vendable.Location = new System.Drawing.Point(167, 160);
            this.vendable.Name = "vendable";
            this.vendable.Size = new System.Drawing.Size(77, 17);
            this.vendable.TabIndex = 28;
            this.vendable.Text = "Vendable?";
            this.vendable.UseVisualStyleBackColor = true;
            this.vendable.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // estMedic
            // 
            this.estMedic.AutoSize = true;
            this.estMedic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.estMedic.Location = new System.Drawing.Point(167, 123);
            this.estMedic.Name = "estMedic";
            this.estMedic.Size = new System.Drawing.Size(90, 17);
            this.estMedic.TabIndex = 27;
            this.estMedic.Text = "Médicament?";
            this.estMedic.UseVisualStyleBackColor = true;
            // 
            // prixVente
            // 
            this.prixVente.BackColor = System.Drawing.Color.LightGray;
            this.prixVente.Enabled = false;
            this.prixVente.Location = new System.Drawing.Point(36, 168);
            this.prixVente.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.prixVente.Name = "prixVente";
            this.prixVente.Size = new System.Drawing.Size(120, 20);
            this.prixVente.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(33, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Prix de vente:";
            // 
            // TemplateModifierStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(304, 477);
            this.Controls.Add(this.description);
            this.Controls.Add(this.quantite);
            this.Controls.Add(this.prixAchat);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TemplateModifierStock";
            this.Text = "AjouterStock";
            ((System.ComponentModel.ISupportInitialize)(this.quantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prixAchat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prixVente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //Make the modifiable components in inherited forms as protected to make it accessible.
        //Stupid.
        protected System.Windows.Forms.Label titre;
        protected System.Windows.Forms.Button buttonConfirmer;
        protected System.Windows.Forms.CheckBox estMedic;
        protected System.Windows.Forms.TextBox description;
        protected System.Windows.Forms.NumericUpDown quantite;
        protected System.Windows.Forms.NumericUpDown prixAchat;
        protected System.Windows.Forms.NumericUpDown prixVente;
        protected System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.CheckBox vendable;
    }
}