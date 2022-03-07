using Microsoft.Extensions.DependencyInjection;
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
        private ServiceCollection _services;

        public MenuHamberger(ServiceCollection services)
        {
            InitializeComponent();
            customizeDesign();
            _services = services;
        }

        /**
         * Permits to initialize the design of the hamburger menu
         */
        private void customizeDesign()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            buttonHamburger.Visible = false;
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
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            } else
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
            //Code
            hideSubMenu();
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
        }

        /**
         * Manage the click of the button new customer
         */
        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            //Code
            hideSubMenu();
        }

        /**
         * Manage the click of the button new prescription
         */
        private void buttonNewPrescription_Click(object sender, EventArgs e)
        {
            //Code
            hideSubMenu();
        }

        /**
         * Manage the click of the button new account
         */
        private void buttonNewAccount_Click(object sender, EventArgs e)
        {
            //Code
            hideSubMenu();
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
            //Code
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
        }
    }
}
