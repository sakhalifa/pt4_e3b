
namespace PT4
{
    partial class AjouterAnimal
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
            this.nom = new System.Windows.Forms.TextBox();
            this.espece = new System.Windows.Forms.TextBox();
            this.race = new System.Windows.Forms.TextBox();
            this.dateNaissance = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.taille = new System.Windows.Forms.NumericUpDown();
            this.poids = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clients = new System.Windows.Forms.ComboBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poids)).BeginInit();
            this.SuspendLayout();
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(104, 78);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(100, 20);
            this.nom.TabIndex = 1;
            // 
            // espece
            // 
            this.espece.Location = new System.Drawing.Point(242, 78);
            this.espece.Name = "espece";
            this.espece.Size = new System.Drawing.Size(100, 20);
            this.espece.TabIndex = 2;
            // 
            // race
            // 
            this.race.Location = new System.Drawing.Point(376, 78);
            this.race.Name = "race";
            this.race.Size = new System.Drawing.Size(100, 20);
            this.race.TabIndex = 3;
            // 
            // dateNaissance
            // 
            this.dateNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateNaissance.Location = new System.Drawing.Point(527, 77);
            this.dateNaissance.Name = "dateNaissance";
            this.dateNaissance.Size = new System.Drawing.Size(200, 20);
            this.dateNaissance.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Espece";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date de naissance";
            // 
            // taille
            // 
            this.taille.Location = new System.Drawing.Point(199, 136);
            this.taille.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.taille.Name = "taille";
            this.taille.Size = new System.Drawing.Size(120, 20);
            this.taille.TabIndex = 9;
            // 
            // poids
            // 
            this.poids.DecimalPlaces = 3;
            this.poids.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.poids.Location = new System.Drawing.Point(485, 136);
            this.poids.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            196608});
            this.poids.Name = "poids";
            this.poids.Size = new System.Drawing.Size(120, 20);
            this.poids.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Taille (cm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(482, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Poids (kg)";
            // 
            // clients
            // 
            this.clients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clients.FormattingEnabled = true;
            this.clients.Location = new System.Drawing.Point(339, 179);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(121, 21);
            this.clients.TabIndex = 13;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(364, 215);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 14;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Client";
            // 
            // AjouterAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 250);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.clients);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.poids);
            this.Controls.Add(this.taille);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateNaissance);
            this.Controls.Add(this.race);
            this.Controls.Add(this.espece);
            this.Controls.Add(this.nom);
            this.Name = "AjouterAnimal";
            this.Text = "AjouterAnimal";
            ((System.ComponentModel.ISupportInitialize)(this.taille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.TextBox espece;
        private System.Windows.Forms.TextBox race;
        private System.Windows.Forms.DateTimePicker dateNaissance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown taille;
        private System.Windows.Forms.NumericUpDown poids;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox clients;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label7;
    }
}