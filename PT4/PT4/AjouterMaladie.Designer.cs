namespace PT4
{
    partial class AjouterMaladie
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
            this.textBoxMaladie = new System.Windows.Forms.TextBox();
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMaladie
            // 
            this.textBoxMaladie.Location = new System.Drawing.Point(57, 57);
            this.textBoxMaladie.Name = "textBoxMaladie";
            this.textBoxMaladie.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaladie.TabIndex = 0;
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.Location = new System.Drawing.Point(136, 103);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmer.TabIndex = 1;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = true;
            this.buttonConfirmer.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nom maladie :";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AjouterMaladie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConfirmer);
            this.Controls.Add(this.textBoxMaladie);
            this.Name = "AjouterMaladie";
            this.Text = "AjouterMaladie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMaladie;
        private System.Windows.Forms.Button buttonConfirmer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}