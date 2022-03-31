﻿using Microsoft.Extensions.DependencyInjection;
using PT4.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public partial class MenuHamberger : Form
    {
        protected ServiceCollection _services;
        private int salarieId;
        protected bool estAdmin;

        private MenuHamberger()
        {
            InitializeComponent();
        }

        public MenuHamberger(ServiceCollection services, int salarieId, bool estAdmin)
        {
            InitializeComponent();
            _services = services;
            this.estAdmin = estAdmin;
            this.salarieId = salarieId;
            if (!this.estAdmin)
            {
                buttonNewCompte.Visible = false;
                buttonNewPrescription.Visible = false;
            }
            buttonHamburger.BringToFront();
        }

        /**
         * Permits to hide panels which contains submenu 
         */
        private void hideSubMenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
            if (panel2.Visible == true)
                panel2.Visible = false;
        }

        /**
         * Permits to show one submenu
         */
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        /**
         * Manage the click of the button Gestion
         */
        private void buttonManagement_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }

        /**
         * Manage the click of the button Stock
         */
        private void buttonStock_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped((p) =>
            {
                return new AfficherStock(p.GetRequiredService<ProduitController>(), _services, salarieId, estAdmin);
            });
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                AfficherStock form = provider.GetRequiredService<AfficherStock>();
                ShowDialogLinked(form);
            }
        }

        private void clientsGestion_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped((p) =>
            {
                return new AfficherClient(p.GetRequiredService<ClientController>(), _services, salarieId, estAdmin);
            });
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                AfficherClient form = provider.GetService<AfficherClient>();
                ShowDialogLinked(form);
            }
        }

        /**
         * Manage the click of the button Planning
         */
        private void buttonPlanning_Click(object sender, EventArgs e)
        {
            //Code
            hideSubMenu();
        }

        /**
         * Manage the click of the button Week sale
         */
        private void buttonWeekSale_Click(object sender, EventArgs e)
        {
            //Code
            hideSubMenu();
        }

        /**
         * Manage the click of the button New sale
         */
        private void buttonNewSale_Click(object sender, EventArgs e)
        {
            //Code
            hideSubMenu();
            _services.AddScoped<AjouterVente>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterVente>();
                dlg.ShowDialog();
            }
        }

        /**
         * Manage the click of the button new prescription
         */
        private void buttonNewPrescription_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped<AjouterPrescription>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterPrescription>();
                dlg.ShowDialog();
            }
        }

        /**
         * Manage the click of the button new account
         */
        private void buttonNewAccount_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped<AjouterCompte>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterCompte>();
                dlg.ShowDialog();
            }
        }

        /**
         * Manage the click of the panel add
         */
        private void panelAdd_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        /**
         * Manage the click of the button Log
         */
        private void buttonLog_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        /**
         * Manage the click of the close button
         */
        private void buttonX_Click(object sender, EventArgs e)
        {
            panelSideMenu.Visible = false;
            buttonHamburger.Visible = true;
        }

        /**
         * Manage the click of the hamburger button 
         */
        private void buttonHamburger_Click(object sender, EventArgs e)
        {
            panelSideMenu.Visible = true;
            buttonHamburger.Visible = false;
            panelSideMenu.BringToFront();
        }

        private void mdpChange_Click(object sender, EventArgs e)
        {
            _services.AddScoped((p) =>
            {
                var contr = p.GetRequiredService<SalarieController>();
                return new ModifierMdp(contr, salarieId);
            });
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                provider.GetService<ModifierMdp>().ShowDialog();
            }

        }

        private void deconnexion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void ShowDialogLinked(MenuHamberger toShow)
        {
            toShow.Closed += (send, __) =>
            {
                if (send is MenuHamberger a)
                {
                    if(a.DialogResult == DialogResult.Retry) {
                        this.DialogResult = DialogResult.Retry;
                        this.Close();
                    }
                }
            };
            toShow.ShowDialog();
        }

        private void buttonRdv_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped<AjouterRDV>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterRDV>();
                dlg.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped((p) => new AjouterConge(salarieId, p.GetRequiredService<SalarieController>()));
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterConge>();
                dlg.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            _services.AddScoped<AjouterMaladie>();
            using (ServiceProvider provider = _services.BuildServiceProvider())
            {
                var dlg = provider.GetService<AjouterMaladie>();
                dlg.ShowDialog();
            }
        }
    }
}
