namespace PT4
{
    partial class DonneesPersonnelles
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
            this.panelDonneesPersonnelles = new System.Windows.Forms.Panel();
            this.numericUpDownAge = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSexe = new System.Windows.Forms.ComboBox();
            this.sexe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.motDePasse = new System.Windows.Forms.Label();
            this.titre = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.Label();
            this.textBoxMailDonnees = new System.Windows.Forms.TextBox();
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.panelDonneesPersonnelles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDonneesPersonnelles
            // 
            this.panelDonneesPersonnelles.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelDonneesPersonnelles.Controls.Add(this.numericUpDownAge);
            this.panelDonneesPersonnelles.Controls.Add(this.comboBoxSexe);
            this.panelDonneesPersonnelles.Controls.Add(this.sexe);
            this.panelDonneesPersonnelles.Controls.Add(this.label1);
            this.panelDonneesPersonnelles.Controls.Add(this.label4);
            this.panelDonneesPersonnelles.Controls.Add(this.textBoxNumero);
            this.panelDonneesPersonnelles.Controls.Add(this.motDePasse);
            this.panelDonneesPersonnelles.Controls.Add(this.titre);
            this.panelDonneesPersonnelles.Controls.Add(this.textBoxMail);
            this.panelDonneesPersonnelles.Controls.Add(this.textBoxMailDonnees);
            this.panelDonneesPersonnelles.Controls.Add(this.buttonConfirmer);
            this.panelDonneesPersonnelles.ForeColor = System.Drawing.Color.Transparent;
            this.panelDonneesPersonnelles.Location = new System.Drawing.Point(181, 26);
            this.panelDonneesPersonnelles.Name = "panelDonneesPersonnelles";
            this.panelDonneesPersonnelles.Size = new System.Drawing.Size(321, 385);
            this.panelDonneesPersonnelles.TabIndex = 7;
            // 
            // numericUpDownAge
            // 
            this.numericUpDownAge.Location = new System.Drawing.Point(95, 191);
            this.numericUpDownAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownAge.Name = "numericUpDownAge";
            this.numericUpDownAge.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAge.TabIndex = 15;
            // 
            // comboBoxSexe
            // 
            this.comboBoxSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSexe.FormattingEnabled = true;
            this.comboBoxSexe.Items.AddRange(new object[] {
            "Homme",
            "Femme",
            "Autre"});
            this.comboBoxSexe.Location = new System.Drawing.Point(94, 248);
            this.comboBoxSexe.Name = "comboBoxSexe";
            this.comboBoxSexe.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSexe.TabIndex = 14;
            // 
            // sexe
            // 
            this.sexe.AutoSize = true;
            this.sexe.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.sexe.Location = new System.Drawing.Point(141, 232);
            this.sexe.Name = "sexe";
            this.sexe.Size = new System.Drawing.Size(31, 13);
            this.sexe.TabIndex = 11;
            this.sexe.Text = "Sexe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(141, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(30, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 8;
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Location = new System.Drawing.Point(106, 139);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumero.TabIndex = 7;
            // 
            // motDePasse
            // 
            this.motDePasse.AutoSize = true;
            this.motDePasse.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.motDePasse.Location = new System.Drawing.Point(132, 123);
            this.motDePasse.Name = "motDePasse";
            this.motDePasse.Size = new System.Drawing.Size(44, 13);
            this.motDePasse.TabIndex = 6;
            this.motDePasse.Text = "Numéro";
            // 
            // titre
            // 
            this.titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titre.AutoSize = true;
            this.titre.BackColor = System.Drawing.Color.Transparent;
            this.titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titre.Location = new System.Drawing.Point(73, 28);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(169, 20);
            this.titre.TabIndex = 0;
            this.titre.Text = "Données Personnelles";
            this.titre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMail
            // 
            this.textBoxMail.AutoSize = true;
            this.textBoxMail.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxMail.Location = new System.Drawing.Point(123, 66);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(66, 13);
            this.textBoxMail.TabIndex = 1;
            this.textBoxMail.Text = "Adresse mail";
            // 
            // textBoxMailDonnees
            // 
            this.textBoxMailDonnees.Location = new System.Drawing.Point(106, 82);
            this.textBoxMailDonnees.Name = "textBoxMailDonnees";
            this.textBoxMailDonnees.Size = new System.Drawing.Size(100, 20);
            this.textBoxMailDonnees.TabIndex = 2;
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConfirmer.ForeColor = System.Drawing.Color.Black;
            this.buttonConfirmer.Location = new System.Drawing.Point(116, 299);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(73, 23);
            this.buttonConfirmer.TabIndex = 3;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = false;
            this.buttonConfirmer.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // DonneesPersonnelles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDonneesPersonnelles);
            this.Name = "DonneesPersonnelles";
            this.Text = "Données Personnelles";
            this.panelDonneesPersonnelles.ResumeLayout(false);
            this.panelDonneesPersonnelles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDonneesPersonnelles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.Label motDePasse;
        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label textBoxMail;
        private System.Windows.Forms.TextBox textBoxMailDonnees;
        private System.Windows.Forms.Button buttonConfirmer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sexe;
        private System.Windows.Forms.ComboBox comboBoxSexe;
        private System.Windows.Forms.NumericUpDown numericUpDownAge;
    }
}