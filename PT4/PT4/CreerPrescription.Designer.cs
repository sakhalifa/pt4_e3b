
namespace PT4
{
    partial class CreerPrescription
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.numericUpDownPrix = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxAnimal = new System.Windows.Forms.ComboBox();
            this.comboBoxProduit = new System.Windows.Forms.ComboBox();
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(309, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Création de prescription";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(199, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(471, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Animal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(199, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label5.Location = new System.Drawing.Point(199, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Prix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
            this.label6.Location = new System.Drawing.Point(471, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Produit";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(202, 125);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClient.TabIndex = 6;
            // 
            // numericUpDownPrix
            // 
            this.numericUpDownPrix.Location = new System.Drawing.Point(202, 334);
            this.numericUpDownPrix.Name = "numericUpDownPrix";
            this.numericUpDownPrix.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPrix.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "€";
            // 
            // comboBoxAnimal
            // 
            this.comboBoxAnimal.FormattingEnabled = true;
            this.comboBoxAnimal.Location = new System.Drawing.Point(474, 125);
            this.comboBoxAnimal.Name = "comboBoxAnimal";
            this.comboBoxAnimal.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAnimal.TabIndex = 10;
            // 
            // comboBoxProduit
            // 
            this.comboBoxProduit.FormattingEnabled = true;
            this.comboBoxProduit.Location = new System.Drawing.Point(474, 334);
            this.comboBoxProduit.Name = "comboBoxProduit";
            this.comboBoxProduit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProduit.TabIndex = 11;
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.Location = new System.Drawing.Point(357, 388);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirmer.TabIndex = 12;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = true;
            this.buttonConfirmer.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(202, 185);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(393, 130);
            this.textBoxDescription.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PT4.Properties.Resources.zebra_g8a6d9221f_1920;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 448);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(141, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 408);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // CreerPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.buttonConfirmer);
            this.Controls.Add(this.comboBoxProduit);
            this.Controls.Add(this.comboBoxAnimal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownPrix);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CreerPrescription";
            this.Text = "CreerPrescription";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.NumericUpDown numericUpDownPrix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxAnimal;
        private System.Windows.Forms.ComboBox comboBoxProduit;
        private System.Windows.Forms.Button buttonConfirmer;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}