using Microsoft.Extensions.DependencyInjection;
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
    public partial class AfficherRdv : Form
    {
        private ClientController _clientController;
        private ServiceCollection _services;

        public AfficherRdv(ClientController clientController, ServiceCollection services)
        {
            InitializeComponent();
            _clientController = clientController;
            _services = services;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
