
namespace PT4
{
    partial class AfficherStock
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
            this.stocks = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxRechercher = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStats = new System.Windows.Forms.Button();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrixVente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrixAchat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stocks)).BeginInit();
            this.SuspendLayout();
            // 
            // stocks
            // 
            this.stocks.AllowUserToAddRows = false;
            this.stocks.AllowUserToDeleteRows = false;
            this.stocks.AllowUserToOrderColumns = true;
            this.stocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.PrixVente,
            this.PrixAchat,
            this.Quantite,
            this.Description});
            this.stocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stocks.Location = new System.Drawing.Point(0, 0);
            this.stocks.Name = "stocks";
            this.stocks.Size = new System.Drawing.Size(800, 450);
            this.stocks.TabIndex = 0;
            this.stocks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(26, 406);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxRechercher
            // 
            this.textBoxRechercher.Location = new System.Drawing.Point(123, 408);
            this.textBoxRechercher.Name = "textBoxRechercher";
            this.textBoxRechercher.Size = new System.Drawing.Size(100, 20);
            this.textBoxRechercher.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rechercher:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // buttonStats
            // 
            this.buttonStats.Location = new System.Drawing.Point(634, 404);
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Size = new System.Drawing.Size(136, 23);
            this.buttonStats.TabIndex = 5;
            this.buttonStats.Text = "Statistiques des stocks";
            this.buttonStats.UseVisualStyleBackColor = true;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            // 
            // PrixVente
            // 
            this.PrixVente.HeaderText = "Prix de vente";
            this.PrixVente.Name = "PrixVente";
            // 
            // PrixAchat
            // 
            this.PrixAchat.HeaderText = "Prix d\'achat";
            this.PrixAchat.Name = "PrixAchat";
            // 
            // Quantite
            // 
            this.Quantite.HeaderText = "Quantité en stock";
            this.Quantite.Name = "Quantite";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // AfficherStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRechercher);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.stocks);
            this.Name = "AfficherStock";
            this.Text = "AfficherStock";
            ((System.ComponentModel.ISupportInitialize)(this.stocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stocks;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxRechercher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrixVente;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrixAchat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}