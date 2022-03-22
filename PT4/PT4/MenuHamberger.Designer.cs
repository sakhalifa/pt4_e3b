
namespace PT4
{
    partial class MenuHamberger
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuHamberger));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.buttonLog = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonNewCompte = new System.Windows.Forms.Button();
            this.buttonNewPrescription = new System.Windows.Forms.Button();
            this.buttonNewCustomer = new System.Windows.Forms.Button();
            this.buttonNewSale = new System.Windows.Forms.Button();
            this.panelAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonWeekSale = new System.Windows.Forms.Button();
            this.buttonPlanning = new System.Windows.Forms.Button();
            this.buttonStock = new System.Windows.Forms.Button();
            this.buttonManagement = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonHamburger = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.Black;
            this.panelSideMenu.Controls.Add(this.buttonLog);
            this.panelSideMenu.Controls.Add(this.panel2);
            this.panelSideMenu.Controls.Add(this.panelAdd);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Controls.Add(this.buttonManagement);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 474);
            this.panelSideMenu.TabIndex = 0;
            // 
            // buttonLog
            // 
            this.buttonLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLog.FlatAppearance.BorderSize = 0;
            this.buttonLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLog.Location = new System.Drawing.Point(0, 528);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonLog.Size = new System.Drawing.Size(233, 45);
            this.buttonLog.TabIndex = 5;
            this.buttonLog.Text = "Logs";
            this.buttonLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.buttonNewCompte);
            this.panel2.Controls.Add(this.buttonNewPrescription);
            this.panel2.Controls.Add(this.buttonNewCustomer);
            this.panel2.Controls.Add(this.buttonNewSale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 168);
            this.panel2.TabIndex = 4;
            // 
            // buttonNewCompte
            // 
            this.buttonNewCompte.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewCompte.FlatAppearance.BorderSize = 0;
            this.buttonNewCompte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCompte.ForeColor = System.Drawing.Color.LightGray;
            this.buttonNewCompte.Location = new System.Drawing.Point(0, 120);
            this.buttonNewCompte.Name = "buttonNewCompte";
            this.buttonNewCompte.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonNewCompte.Size = new System.Drawing.Size(233, 40);
            this.buttonNewCompte.TabIndex = 8;
            this.buttonNewCompte.Text = "Nouveau compte";
            this.buttonNewCompte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewCompte.UseVisualStyleBackColor = true;
            this.buttonNewCompte.Click += new System.EventHandler(this.buttonNewAccount_Click);
            // 
            // buttonNewPrescription
            // 
            this.buttonNewPrescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewPrescription.FlatAppearance.BorderSize = 0;
            this.buttonNewPrescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewPrescription.ForeColor = System.Drawing.Color.LightGray;
            this.buttonNewPrescription.Location = new System.Drawing.Point(0, 80);
            this.buttonNewPrescription.Name = "buttonNewPrescription";
            this.buttonNewPrescription.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonNewPrescription.Size = new System.Drawing.Size(233, 40);
            this.buttonNewPrescription.TabIndex = 7;
            this.buttonNewPrescription.Text = "Nouvelle presription";
            this.buttonNewPrescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewPrescription.UseVisualStyleBackColor = true;
            this.buttonNewPrescription.Click += new System.EventHandler(this.buttonNewPrescription_Click);
            // 
            // buttonNewCustomer
            // 
            this.buttonNewCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewCustomer.FlatAppearance.BorderSize = 0;
            this.buttonNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCustomer.ForeColor = System.Drawing.Color.LightGray;
            this.buttonNewCustomer.Location = new System.Drawing.Point(0, 40);
            this.buttonNewCustomer.Name = "buttonNewCustomer";
            this.buttonNewCustomer.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonNewCustomer.Size = new System.Drawing.Size(233, 40);
            this.buttonNewCustomer.TabIndex = 6;
            this.buttonNewCustomer.Text = "Nouveau client";
            this.buttonNewCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewCustomer.UseVisualStyleBackColor = true;
            this.buttonNewCustomer.Click += new System.EventHandler(this.buttonNewCustomer_Click);
            // 
            // buttonNewSale
            // 
            this.buttonNewSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewSale.FlatAppearance.BorderSize = 0;
            this.buttonNewSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewSale.ForeColor = System.Drawing.Color.LightGray;
            this.buttonNewSale.Location = new System.Drawing.Point(0, 0);
            this.buttonNewSale.Name = "buttonNewSale";
            this.buttonNewSale.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonNewSale.Size = new System.Drawing.Size(233, 40);
            this.buttonNewSale.TabIndex = 5;
            this.buttonNewSale.Text = "Nouvelle vente";
            this.buttonNewSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewSale.UseVisualStyleBackColor = true;
            this.buttonNewSale.Click += new System.EventHandler(this.buttonNewSale_Click);
            // 
            // panelAdd
            // 
            this.panelAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdd.FlatAppearance.BorderSize = 0;
            this.panelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.panelAdd.Location = new System.Drawing.Point(0, 315);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelAdd.Size = new System.Drawing.Size(233, 45);
            this.panelAdd.TabIndex = 3;
            this.panelAdd.Text = "Ajouter";
            this.panelAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelAdd.UseVisualStyleBackColor = true;
            this.panelAdd.Click += new System.EventHandler(this.panelAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.buttonWeekSale);
            this.panel1.Controls.Add(this.buttonPlanning);
            this.panel1.Controls.Add(this.buttonStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 120);
            this.panel1.TabIndex = 2;
            // 
            // buttonWeekSale
            // 
            this.buttonWeekSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonWeekSale.FlatAppearance.BorderSize = 0;
            this.buttonWeekSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWeekSale.ForeColor = System.Drawing.Color.LightGray;
            this.buttonWeekSale.Location = new System.Drawing.Point(0, 80);
            this.buttonWeekSale.Name = "buttonWeekSale";
            this.buttonWeekSale.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonWeekSale.Size = new System.Drawing.Size(233, 40);
            this.buttonWeekSale.TabIndex = 2;
            this.buttonWeekSale.Text = "Ventes de la semaine";
            this.buttonWeekSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWeekSale.UseVisualStyleBackColor = true;
            this.buttonWeekSale.Click += new System.EventHandler(this.buttonWeekSale_Click);
            // 
            // buttonPlanning
            // 
            this.buttonPlanning.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlanning.FlatAppearance.BorderSize = 0;
            this.buttonPlanning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlanning.ForeColor = System.Drawing.Color.LightGray;
            this.buttonPlanning.Location = new System.Drawing.Point(0, 40);
            this.buttonPlanning.Name = "buttonPlanning";
            this.buttonPlanning.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonPlanning.Size = new System.Drawing.Size(233, 40);
            this.buttonPlanning.TabIndex = 1;
            this.buttonPlanning.Text = "Planning";
            this.buttonPlanning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlanning.UseVisualStyleBackColor = true;
            this.buttonPlanning.Click += new System.EventHandler(this.buttonPlanning_Click);
            // 
            // buttonStock
            // 
            this.buttonStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStock.FlatAppearance.BorderSize = 0;
            this.buttonStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStock.ForeColor = System.Drawing.Color.LightGray;
            this.buttonStock.Location = new System.Drawing.Point(0, 0);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonStock.Size = new System.Drawing.Size(233, 40);
            this.buttonStock.TabIndex = 0;
            this.buttonStock.Text = "Stocks";
            this.buttonStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStock.UseVisualStyleBackColor = true;
            this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
            // 
            // buttonManagement
            // 
            this.buttonManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManagement.FlatAppearance.BorderSize = 0;
            this.buttonManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonManagement.Location = new System.Drawing.Point(0, 150);
            this.buttonManagement.Name = "buttonManagement";
            this.buttonManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonManagement.Size = new System.Drawing.Size(233, 45);
            this.buttonManagement.TabIndex = 1;
            this.buttonManagement.Text = "Gestion";
            this.buttonManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonManagement.UseVisualStyleBackColor = true;
            this.buttonManagement.Click += new System.EventHandler(this.buttonManagement_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.buttonX);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(30);
            this.panelLogo.Size = new System.Drawing.Size(233, 150);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // buttonX
            // 
            this.buttonX.Location = new System.Drawing.Point(192, 12);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(25, 25);
            this.buttonX.TabIndex = 0;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // buttonHamburger
            // 
            this.buttonHamburger.Location = new System.Drawing.Point(763, 12);
            this.buttonHamburger.Name = "buttonHamburger";
            this.buttonHamburger.Size = new System.Drawing.Size(25, 25);
            this.buttonHamburger.TabIndex = 1;
            this.buttonHamburger.Text = "O";
            this.buttonHamburger.UseVisualStyleBackColor = true;
            this.buttonHamburger.Click += new System.EventHandler(this.buttonHamburger_Click);
            // 
            // MenuHamberger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.buttonHamburger);
            this.Controls.Add(this.panelSideMenu);
            this.Name = "MenuHamberger";
            this.Text = "MenuHamberger";
            this.panelSideMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button panelAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonWeekSale;
        private System.Windows.Forms.Button buttonPlanning;
        private System.Windows.Forms.Button buttonStock;
        private System.Windows.Forms.Button buttonManagement;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonNewCompte;
        private System.Windows.Forms.Button buttonNewPrescription;
        private System.Windows.Forms.Button buttonNewCustomer;
        private System.Windows.Forms.Button buttonNewSale;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonHamburger;
        private System.Windows.Forms.Label label1;
    }
}

