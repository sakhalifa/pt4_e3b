
namespace PT4
{
    partial class TemplateSoin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.maladiesListBox = new System.Windows.Forms.ListBox();
            this.produitListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddSickness = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(309, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Création de soin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(313, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Produits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(33, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Maladie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(604, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(607, 96);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(144, 227);
            this.textBoxDescription.TabIndex = 13;
            // 
            // maladiesListBox
            // 
            this.maladiesListBox.FormattingEnabled = true;
            this.maladiesListBox.Location = new System.Drawing.Point(33, 96);
            this.maladiesListBox.Name = "maladiesListBox";
            this.maladiesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.maladiesListBox.Size = new System.Drawing.Size(245, 303);
            this.maladiesListBox.TabIndex = 16;
            // 
            // produitListBox
            // 
            this.produitListBox.FormattingEnabled = true;
            this.produitListBox.Location = new System.Drawing.Point(313, 96);
            this.produitListBox.Name = "produitListBox";
            this.produitListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.produitListBox.Size = new System.Drawing.Size(245, 303);
            this.produitListBox.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Maladies";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Produits";
            // 
            // buttonAddSickness
            // 
            this.buttonAddSickness.Location = new System.Drawing.Point(33, 398);
            this.buttonAddSickness.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddSickness.Name = "buttonAddSickness";
            this.buttonAddSickness.Size = new System.Drawing.Size(245, 23);
            this.buttonAddSickness.TabIndex = 23;
            this.buttonAddSickness.Text = "+";
            this.buttonAddSickness.UseVisualStyleBackColor = true;
            this.buttonAddSickness.Click += new System.EventHandler(this.buttonAddSickness_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(313, 398);
            this.buttonAddProduct.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(245, 23);
            this.buttonAddProduct.TabIndex = 24;
            this.buttonAddProduct.Text = "+";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // TemplateSoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.buttonAddSickness);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.produitListBox);
            this.Controls.Add(this.maladiesListBox);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "TemplateSoin";
            this.Text = "CreerPrescription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ListBox maladiesListBox;
        private System.Windows.Forms.ListBox produitListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddSickness;
        private System.Windows.Forms.Button buttonAddProduct;
    }
}