namespace PT4
{
    partial class ModifierMdp
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
            this.textBoxNewMdp = new System.Windows.Forms.TextBox();
            this.textBoxConfirmerMdp = new System.Windows.Forms.TextBox();
            this.titre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfirmation = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNewMdp
            // 
            this.textBoxNewMdp.Location = new System.Drawing.Point(90, 109);
            this.textBoxNewMdp.Name = "textBoxNewMdp";
            this.textBoxNewMdp.PasswordChar = '*';
            this.textBoxNewMdp.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewMdp.TabIndex = 8;
            // 
            // textBoxConfirmerMdp
            // 
            this.textBoxConfirmerMdp.Location = new System.Drawing.Point(90, 185);
            this.textBoxConfirmerMdp.Name = "textBoxConfirmerMdp";
            this.textBoxConfirmerMdp.PasswordChar = '*';
            this.textBoxConfirmerMdp.Size = new System.Drawing.Size(100, 20);
            this.textBoxConfirmerMdp.TabIndex = 9;
            // 
            // titre
            // 
            this.titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titre.AutoSize = true;
            this.titre.BackColor = System.Drawing.Color.Transparent;
            this.titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titre.Location = new System.Drawing.Point(54, 54);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(181, 20);
            this.titre.TabIndex = 10;
            this.titre.Text = "Modifier le mot de passe";
            this.titre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(87, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nouveau Mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Confirmer nouveau Mot de passe";
            // 
            // buttonConfirmation
            // 
            this.buttonConfirmation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConfirmation.ForeColor = System.Drawing.Color.Black;
            this.buttonConfirmation.Location = new System.Drawing.Point(105, 240);
            this.buttonConfirmation.Name = "buttonConfirmation";
            this.buttonConfirmation.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmation.TabIndex = 13;
            this.buttonConfirmation.Text = "Confirmer";
            this.buttonConfirmation.UseVisualStyleBackColor = false;
            this.buttonConfirmation.Click += new System.EventHandler(this.buttonConfirmation_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.buttonConfirmation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.titre);
            this.panel1.Controls.Add(this.textBoxConfirmerMdp);
            this.panel1.Controls.Add(this.textBoxNewMdp);
            this.panel1.Location = new System.Drawing.Point(255, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 339);
            this.panel1.TabIndex = 0;
            // 
            // ModifierMdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PT4.Properties.Resources.parrot_g3fd41130a_1920;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ModifierMdp";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNewMdp;
        private System.Windows.Forms.TextBox textBoxConfirmerMdp;
        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConfirmation;
        private System.Windows.Forms.Panel panel1;
    }
}