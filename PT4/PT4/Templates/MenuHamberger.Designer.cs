
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
            this.deconnexion = new System.Windows.Forms.Button();
            this.buttonLog = new System.Windows.Forms.Button();
            this.mdpChange = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddDisease = new System.Windows.Forms.Button();
            this.buttonAddConge = new System.Windows.Forms.Button();
            this.buttonAddAppointment = new System.Windows.Forms.Button();
            this.buttonNewCompte = new System.Windows.Forms.Button();
            this.buttonNewPrescription = new System.Windows.Forms.Button();
            this.buttonNewSale = new System.Windows.Forms.Button();
            this.panelAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clientsGestion = new System.Windows.Forms.Button();
            this.buttonWeekSale = new System.Windows.Forms.Button();
            this.buttonPlanning = new System.Windows.Forms.Button();
            this.buttonStock = new System.Windows.Forms.Button();
            this.buttonManagement = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
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
            this.panelSideMenu.Controls.Add(this.deconnexion);
            this.panelSideMenu.Controls.Add(this.buttonLog);
            this.panelSideMenu.Controls.Add(this.mdpChange);
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
            this.panelSideMenu.Visible = false;
            // 
            // deconnexion
            // 
            this.deconnexion.Dock = System.Windows.Forms.DockStyle.Top;
            this.deconnexion.FlatAppearance.BorderSize = 0;
            this.deconnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deconnexion.ForeColor = System.Drawing.Color.Gainsboro;
            this.deconnexion.Location = new System.Drawing.Point(0, 730);
            this.deconnexion.Name = "deconnexion";
            this.deconnexion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.deconnexion.Size = new System.Drawing.Size(233, 45);
            this.deconnexion.TabIndex = 7;
            this.deconnexion.Text = "Deconnexion";
            this.deconnexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deconnexion.UseVisualStyleBackColor = true;
            this.deconnexion.Click += new System.EventHandler(this.deconnexion_Click);
            // 
            // buttonLog
            // 
            this.buttonLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLog.FlatAppearance.BorderSize = 0;
            this.buttonLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLog.Location = new System.Drawing.Point(0, 685);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonLog.Size = new System.Drawing.Size(233, 45);
            this.buttonLog.TabIndex = 5;
            this.buttonLog.Text = "Logs";
            this.buttonLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // mdpChange
            // 
            this.mdpChange.Dock = System.Windows.Forms.DockStyle.Top;
            this.mdpChange.FlatAppearance.BorderSize = 0;
            this.mdpChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mdpChange.ForeColor = System.Drawing.Color.Gainsboro;
            this.mdpChange.Location = new System.Drawing.Point(0, 640);
            this.mdpChange.Name = "mdpChange";
            this.mdpChange.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mdpChange.Size = new System.Drawing.Size(233, 45);
            this.mdpChange.TabIndex = 6;
            this.mdpChange.Text = "Changer de mdp";
            this.mdpChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mdpChange.UseVisualStyleBackColor = true;
            this.mdpChange.Click += new System.EventHandler(this.mdpChange_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.buttonAddDisease);
            this.panel2.Controls.Add(this.buttonAddConge);
            this.panel2.Controls.Add(this.buttonAddAppointment);
            this.panel2.Controls.Add(this.buttonNewCompte);
            this.panel2.Controls.Add(this.buttonNewPrescription);
            this.panel2.Controls.Add(this.buttonNewSale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 240);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            // 
            // buttonAddDisease
            // 
            this.buttonAddDisease.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddDisease.FlatAppearance.BorderSize = 0;
            this.buttonAddDisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDisease.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAddDisease.Location = new System.Drawing.Point(0, 200);
            this.buttonAddDisease.Name = "buttonAddDisease";
            this.buttonAddDisease.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonAddDisease.Size = new System.Drawing.Size(233, 40);
            this.buttonAddDisease.TabIndex = 11;
            this.buttonAddDisease.Text = "Nouvelle Maladie";
            this.buttonAddDisease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddDisease.UseVisualStyleBackColor = true;
            this.buttonAddDisease.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAddConge
            // 
            this.buttonAddConge.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddConge.FlatAppearance.BorderSize = 0;
            this.buttonAddConge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddConge.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAddConge.Location = new System.Drawing.Point(0, 160);
            this.buttonAddConge.Name = "buttonAddConge";
            this.buttonAddConge.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonAddConge.Size = new System.Drawing.Size(233, 40);
            this.buttonAddConge.TabIndex = 10;
            this.buttonAddConge.Text = "Nouveau Congé";
            this.buttonAddConge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddConge.UseVisualStyleBackColor = true;
            this.buttonAddConge.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAddAppointment
            // 
            this.buttonAddAppointment.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddAppointment.FlatAppearance.BorderSize = 0;
            this.buttonAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAppointment.ForeColor = System.Drawing.Color.LightGray;
            this.buttonAddAppointment.Location = new System.Drawing.Point(0, 120);
            this.buttonAddAppointment.Name = "buttonAddAppointment";
            this.buttonAddAppointment.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonAddAppointment.Size = new System.Drawing.Size(233, 40);
            this.buttonAddAppointment.TabIndex = 9;
            this.buttonAddAppointment.Text = "Nouveau Rendez-vous";
            this.buttonAddAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddAppointment.UseVisualStyleBackColor = true;
            this.buttonAddAppointment.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonNewCompte
            // 
            this.buttonNewCompte.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewCompte.FlatAppearance.BorderSize = 0;
            this.buttonNewCompte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCompte.ForeColor = System.Drawing.Color.LightGray;
            this.buttonNewCompte.Location = new System.Drawing.Point(0, 80);
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
            this.buttonNewPrescription.Location = new System.Drawing.Point(0, 40);
            this.buttonNewPrescription.Name = "buttonNewPrescription";
            this.buttonNewPrescription.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.buttonNewPrescription.Size = new System.Drawing.Size(233, 40);
            this.buttonNewPrescription.TabIndex = 7;
            this.buttonNewPrescription.Text = "Nouvelle presription";
            this.buttonNewPrescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewPrescription.UseVisualStyleBackColor = true;
            this.buttonNewPrescription.Click += new System.EventHandler(this.buttonNewPrescription_Click);
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
            this.panelAdd.Location = new System.Drawing.Point(0, 355);
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
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.clientsGestion);
            this.panel1.Controls.Add(this.buttonWeekSale);
            this.panel1.Controls.Add(this.buttonPlanning);
            this.panel1.Controls.Add(this.buttonStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 160);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // clientsGestion
            // 
            this.clientsGestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientsGestion.FlatAppearance.BorderSize = 0;
            this.clientsGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientsGestion.ForeColor = System.Drawing.Color.LightGray;
            this.clientsGestion.Location = new System.Drawing.Point(0, 120);
            this.clientsGestion.Name = "clientsGestion";
            this.clientsGestion.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.clientsGestion.Size = new System.Drawing.Size(233, 40);
            this.clientsGestion.TabIndex = 3;
            this.clientsGestion.Text = "Gestion des clients";
            this.clientsGestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsGestion.UseVisualStyleBackColor = true;
            this.clientsGestion.Click += new System.EventHandler(this.clientsGestion_Click);
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
            this.panelLogo.Controls.Add(this.buttonX);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(30);
            this.panelLogo.Size = new System.Drawing.Size(233, 150);
            this.panelLogo.TabIndex = 0;
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
            this.DoubleBuffered = true;
            this.Name = "MenuHamberger";
            this.Text = "MenuHamberger";
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonNewSale;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button mdpChange;
        private System.Windows.Forms.Button deconnexion;
        private System.Windows.Forms.Button clientsGestion;
        protected System.Windows.Forms.Button buttonHamburger;
        private System.Windows.Forms.Button buttonAddDisease;
        private System.Windows.Forms.Button buttonAddConge;
        private System.Windows.Forms.Button buttonAddAppointment;
    }
}

