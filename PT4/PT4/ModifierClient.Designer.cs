
namespace PT4
{
    partial class ModifierClient
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
            this.topLayout = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxesLayout = new System.Windows.Forms.TableLayoutPanel();
            this.masterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.confirmButton = new System.Windows.Forms.Button();
            this.gridViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.addAnimal = new System.Windows.Forms.Button();
            this.animalGridView = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Espece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Race = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Taille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NbreMaladies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numeroTextBox = new System.Windows.Forms.MaskedTextBox();
            this.topLayout.SuspendLayout();
            this.textBoxesLayout.SuspendLayout();
            this.masterLayout.SuspendLayout();
            this.gridViewLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLayout
            // 
            this.topLayout.ColumnCount = 2;
            this.topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.topLayout.Controls.Add(this.textBoxesLayout, 0, 0);
            this.topLayout.Controls.Add(this.gridViewLayout, 1, 0);
            this.topLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLayout.Location = new System.Drawing.Point(3, 3);
            this.topLayout.Name = "topLayout";
            this.topLayout.RowCount = 1;
            this.topLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLayout.Size = new System.Drawing.Size(794, 401);
            this.topLayout.TabIndex = 0;
            // 
            // textBoxesLayout
            // 
            this.textBoxesLayout.ColumnCount = 1;
            this.textBoxesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.textBoxesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.textBoxesLayout.Controls.Add(this.panel4, 0, 3);
            this.textBoxesLayout.Controls.Add(this.panel3, 0, 2);
            this.textBoxesLayout.Controls.Add(this.panel2, 0, 1);
            this.textBoxesLayout.Controls.Add(this.panel1, 0, 0);
            this.textBoxesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxesLayout.Location = new System.Drawing.Point(3, 3);
            this.textBoxesLayout.Name = "textBoxesLayout";
            this.textBoxesLayout.RowCount = 4;
            this.textBoxesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.textBoxesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.textBoxesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.textBoxesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.textBoxesLayout.Size = new System.Drawing.Size(232, 395);
            this.textBoxesLayout.TabIndex = 0;
            // 
            // masterLayout
            // 
            this.masterLayout.ColumnCount = 1;
            this.masterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.Controls.Add(this.confirmButton, 0, 1);
            this.masterLayout.Controls.Add(this.topLayout, 0, 0);
            this.masterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterLayout.Location = new System.Drawing.Point(0, 0);
            this.masterLayout.Name = "masterLayout";
            this.masterLayout.RowCount = 2;
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.masterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.masterLayout.Size = new System.Drawing.Size(800, 450);
            this.masterLayout.TabIndex = 1;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmButton.Location = new System.Drawing.Point(362, 417);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(10);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirmer";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // gridViewLayout
            // 
            this.gridViewLayout.ColumnCount = 1;
            this.gridViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gridViewLayout.Controls.Add(this.addAnimal, 0, 1);
            this.gridViewLayout.Controls.Add(this.animalGridView, 0, 0);
            this.gridViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewLayout.Location = new System.Drawing.Point(241, 3);
            this.gridViewLayout.Name = "gridViewLayout";
            this.gridViewLayout.RowCount = 2;
            this.gridViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gridViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridViewLayout.Size = new System.Drawing.Size(550, 395);
            this.gridViewLayout.TabIndex = 1;
            // 
            // addAnimal
            // 
            this.addAnimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addAnimal.Location = new System.Drawing.Point(0, 372);
            this.addAnimal.Margin = new System.Windows.Forms.Padding(0);
            this.addAnimal.Name = "addAnimal";
            this.addAnimal.Size = new System.Drawing.Size(550, 23);
            this.addAnimal.TabIndex = 1;
            this.addAnimal.Text = "+";
            this.addAnimal.UseVisualStyleBackColor = true;
            // 
            // animalGridView
            // 
            this.animalGridView.AllowUserToAddRows = false;
            this.animalGridView.AllowUserToDeleteRows = false;
            this.animalGridView.AllowUserToOrderColumns = true;
            this.animalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.animalGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Espece,
            this.Race,
            this.Taille,
            this.Poids,
            this.NbreMaladies});
            this.animalGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animalGridView.Location = new System.Drawing.Point(0, 0);
            this.animalGridView.Margin = new System.Windows.Forms.Padding(0);
            this.animalGridView.Name = "animalGridView";
            this.animalGridView.ReadOnly = true;
            this.animalGridView.Size = new System.Drawing.Size(550, 372);
            this.animalGridView.TabIndex = 2;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            // 
            // Espece
            // 
            this.Espece.HeaderText = "Espece";
            this.Espece.Name = "Espece";
            this.Espece.ReadOnly = true;
            // 
            // Race
            // 
            this.Race.HeaderText = "Race";
            this.Race.Name = "Race";
            this.Race.ReadOnly = true;
            // 
            // Taille
            // 
            this.Taille.HeaderText = "Taille";
            this.Taille.Name = "Taille";
            this.Taille.ReadOnly = true;
            // 
            // Poids
            // 
            this.Poids.HeaderText = "Poids";
            this.Poids.Name = "Poids";
            this.Poids.ReadOnly = true;
            // 
            // NbreMaladies
            // 
            this.NbreMaladies.HeaderText = "Nombre de maladies contractées dans le mois";
            this.NbreMaladies.Name = "NbreMaladies";
            this.NbreMaladies.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nomTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 92);
            this.panel1.TabIndex = 0;
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(61, 45);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.prenomTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 92);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prenom";
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Location = new System.Drawing.Point(61, 45);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(100, 20);
            this.prenomTextBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.emailTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 92);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(61, 45);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.numeroTextBox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 297);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 95);
            this.panel4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Numéro";
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.Location = new System.Drawing.Point(61, 43);
            this.numeroTextBox.Mask = "00 00 00 00 00";
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(100, 20);
            this.numeroTextBox.TabIndex = 2;
            // 
            // ModifierClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.masterLayout);
            this.Name = "ModifierClient";
            this.Text = "ModifierClient";
            this.topLayout.ResumeLayout(false);
            this.textBoxesLayout.ResumeLayout(false);
            this.textBoxesLayout.PerformLayout();
            this.masterLayout.ResumeLayout(false);
            this.gridViewLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.animalGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topLayout;
        private System.Windows.Forms.TableLayoutPanel textBoxesLayout;
        private System.Windows.Forms.TableLayoutPanel masterLayout;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TableLayoutPanel gridViewLayout;
        private System.Windows.Forms.Button addAnimal;
        private System.Windows.Forms.DataGridView animalGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Espece;
        private System.Windows.Forms.DataGridViewTextBoxColumn Race;
        private System.Windows.Forms.DataGridViewTextBoxColumn Taille;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poids;
        private System.Windows.Forms.DataGridViewTextBoxColumn NbreMaladies;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.MaskedTextBox numeroTextBox;
    }
}