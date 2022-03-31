namespace PT4
{
    partial class AjouterFacture
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
            this.components = new System.ComponentModel.Container();
            this.leftRightLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gridAndAddLayout = new System.Windows.Forms.TableLayoutPanel();
            this.produits = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelClient = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.clients = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.montantFacture = new System.Windows.Forms.Label();
            this.RefProduitVendu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrixUnitaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrixTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftRightLayout.SuspendLayout();
            this.gridAndAddLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produits)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftRightLayout
            // 
            this.leftRightLayout.ColumnCount = 2;
            this.leftRightLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftRightLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftRightLayout.Controls.Add(this.gridAndAddLayout, 1, 0);
            this.leftRightLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.leftRightLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftRightLayout.Location = new System.Drawing.Point(3, 3);
            this.leftRightLayout.Name = "leftRightLayout";
            this.leftRightLayout.RowCount = 1;
            this.leftRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftRightLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 415F));
            this.leftRightLayout.Size = new System.Drawing.Size(819, 415);
            this.leftRightLayout.TabIndex = 1;
            // 
            // gridAndAddLayout
            // 
            this.gridAndAddLayout.ColumnCount = 1;
            this.gridAndAddLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gridAndAddLayout.Controls.Add(this.produits, 0, 0);
            this.gridAndAddLayout.Controls.Add(this.buttonAdd, 0, 1);
            this.gridAndAddLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAndAddLayout.Location = new System.Drawing.Point(412, 3);
            this.gridAndAddLayout.Name = "gridAndAddLayout";
            this.gridAndAddLayout.RowCount = 2;
            this.gridAndAddLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gridAndAddLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridAndAddLayout.Size = new System.Drawing.Size(404, 409);
            this.gridAndAddLayout.TabIndex = 3;
            // 
            // produits
            // 
            this.produits.AllowUserToAddRows = false;
            this.produits.AllowUserToDeleteRows = false;
            this.produits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefProduitVendu,
            this.Produit,
            this.Quantite,
            this.PrixUnitaire,
            this.PrixTotal});
            this.produits.ContextMenuStrip = this.contextMenuStrip1;
            this.produits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.produits.Location = new System.Drawing.Point(0, 0);
            this.produits.Margin = new System.Windows.Forms.Padding(0);
            this.produits.Name = "produits";
            this.produits.ReadOnly = true;
            this.produits.RowHeadersVisible = false;
            this.produits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.produits.Size = new System.Drawing.Size(404, 386);
            this.produits.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 48);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.supprimerToolStripMenuItem.Text = "Retirer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Location = new System.Drawing.Point(0, 386);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(404, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelClient, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 409);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panelClient
            // 
            this.panelClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelClient.Controls.Add(this.label1);
            this.panelClient.Controls.Add(this.clients);
            this.panelClient.Location = new System.Drawing.Point(136, 74);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(131, 56);
            this.panelClient.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // clients
            // 
            this.clients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clients.FormattingEnabled = true;
            this.clients.Location = new System.Drawing.Point(3, 22);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(121, 21);
            this.clients.TabIndex = 0;
            this.clients.SelectedIndexChanged += new System.EventHandler(this.clients_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonConfirm, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.leftRightLayout, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(825, 450);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConfirm.Location = new System.Drawing.Point(375, 424);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 0;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.montantFacture, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(101, 256);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Montant total de la facture";
            // 
            // montantFacture
            // 
            this.montantFacture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.montantFacture.AutoSize = true;
            this.montantFacture.Location = new System.Drawing.Point(90, 50);
            this.montantFacture.Name = "montantFacture";
            this.montantFacture.Size = new System.Drawing.Size(19, 13);
            this.montantFacture.TabIndex = 1;
            this.montantFacture.Text = "0€";
            // 
            // RefProduitVendu
            // 
            this.RefProduitVendu.HeaderText = "RefProduitVendu";
            this.RefProduitVendu.Name = "RefProduitVendu";
            this.RefProduitVendu.ReadOnly = true;
            this.RefProduitVendu.Visible = false;
            // 
            // Produit
            // 
            this.Produit.HeaderText = "Produit";
            this.Produit.Name = "Produit";
            this.Produit.ReadOnly = true;
            // 
            // Quantite
            // 
            this.Quantite.HeaderText = "Quantite";
            this.Quantite.Name = "Quantite";
            this.Quantite.ReadOnly = true;
            // 
            // PrixUnitaire
            // 
            this.PrixUnitaire.HeaderText = "Prix Unitaire";
            this.PrixUnitaire.Name = "PrixUnitaire";
            this.PrixUnitaire.ReadOnly = true;
            // 
            // PrixTotal
            // 
            this.PrixTotal.HeaderText = "Prix Total";
            this.PrixTotal.Name = "PrixTotal";
            this.PrixTotal.ReadOnly = true;
            // 
            // AjouterFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 450);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AjouterFacture";
            this.Text = "AjouterFacture";
            this.leftRightLayout.ResumeLayout(false);
            this.gridAndAddLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.produits)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel leftRightLayout;
        private System.Windows.Forms.TableLayoutPanel gridAndAddLayout;
        private System.Windows.Forms.DataGridView produits;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox clients;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label montantFacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefProduitVendu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrixUnitaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrixTotal;
    }
}