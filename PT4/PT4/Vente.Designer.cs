
namespace PT4
{
    partial class Vente
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
            this.textBoxPrix1 = new System.Windows.Forms.TextBox();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.comboBoxProduit1 = new System.Windows.Forms.ComboBox();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelReduction = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prix de base";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Produit";
            // 
            // textBoxPrix1
            // 
            this.textBoxPrix1.Location = new System.Drawing.Point(275, 182);
            this.textBoxPrix1.Name = "textBoxPrix1";
            this.textBoxPrix1.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrix1.TabIndex = 7;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(275, 231);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(121, 23);
            this.buttonAjouter.TabIndex = 8;
            this.buttonAjouter.Text = "+ Ajouter un produit";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxProduit1
            // 
            this.comboBoxProduit1.FormattingEnabled = true;
            this.comboBoxProduit1.Location = new System.Drawing.Point(507, 181);
            this.comboBoxProduit1.Name = "comboBoxProduit1";
            this.comboBoxProduit1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProduit1.TabIndex = 10;
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(275, 113);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClient.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(411, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Réduction  de:";
            // 
            // labelReduction
            // 
            this.labelReduction.AutoSize = true;
            this.labelReduction.Location = new System.Drawing.Point(485, 116);
            this.labelReduction.Name = "labelReduction";
            this.labelReduction.Size = new System.Drawing.Size(27, 13);
            this.labelReduction.TabIndex = 13;
            this.labelReduction.Text = "20%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "€";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Total après réduction:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.labelTotal.Location = new System.Drawing.Point(497, 312);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(13, 13);
            this.labelTotal.TabIndex = 16;
            this.labelTotal.Text = "8";
            this.labelTotal.Click += new System.EventHandler(this.label7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(516, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "€";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.Location = new System.Drawing.Point(414, 355);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmer.TabIndex = 18;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = true;
            // 
            // Vente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonConfirmer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelReduction);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.comboBoxProduit1);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.textBoxPrix1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Vente";
            this.Text = "Vente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPrix1;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.ComboBox comboBoxProduit1;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelReduction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonConfirmer;
    }
}