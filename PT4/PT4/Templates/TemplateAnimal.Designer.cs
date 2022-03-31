namespace PT4.Templates
{
    partial class TemplateAnimal
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
            this.label7 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.clients = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.poids = new System.Windows.Forms.NumericUpDown();
            this.taille = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateNaissance = new System.Windows.Forms.DateTimePicker();
            this.race = new System.Windows.Forms.TextBox();
            this.espece = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.poids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Client";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(291, 203);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 29;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // clients
            // 
            this.clients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clients.FormattingEnabled = true;
            this.clients.Location = new System.Drawing.Point(266, 167);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(121, 21);
            this.clients.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Poids (kg)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Taille (cm)";
            // 
            // poids
            // 
            this.poids.DecimalPlaces = 3;
            this.poids.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.poids.Location = new System.Drawing.Point(412, 124);
            this.poids.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            196608});
            this.poids.Name = "poids";
            this.poids.Size = new System.Drawing.Size(120, 20);
            this.poids.TabIndex = 25;
            // 
            // taille
            // 
            this.taille.Location = new System.Drawing.Point(126, 124);
            this.taille.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.taille.Name = "taille";
            this.taille.Size = new System.Drawing.Size(120, 20);
            this.taille.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Date de naissance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Race";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Espece";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nom";
            // 
            // dateNaissance
            // 
            this.dateNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateNaissance.Location = new System.Drawing.Point(454, 65);
            this.dateNaissance.Name = "dateNaissance";
            this.dateNaissance.Size = new System.Drawing.Size(200, 20);
            this.dateNaissance.TabIndex = 19;
            // 
            // race
            // 
            this.race.Location = new System.Drawing.Point(303, 66);
            this.race.Name = "race";
            this.race.Size = new System.Drawing.Size(100, 20);
            this.race.TabIndex = 18;
            // 
            // espece
            // 
            this.espece.Location = new System.Drawing.Point(169, 66);
            this.espece.Name = "espece";
            this.espece.Size = new System.Drawing.Size(100, 20);
            this.espece.TabIndex = 17;
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(31, 66);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(100, 20);
            this.nom.TabIndex = 16;
            // 
            // TemplateAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 257);
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
            this.Name = "TemplateAnimal";
            this.Text = "TemplateAnimal";
            ((System.ComponentModel.ISupportInitialize)(this.poids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taille)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button buttonConfirm;
        protected System.Windows.Forms.ComboBox clients;
        protected System.Windows.Forms.NumericUpDown poids;
        protected System.Windows.Forms.NumericUpDown taille;
        protected System.Windows.Forms.DateTimePicker dateNaissance;
        protected System.Windows.Forms.TextBox race;
        protected System.Windows.Forms.TextBox espece;
        protected System.Windows.Forms.TextBox nom;
    }
}