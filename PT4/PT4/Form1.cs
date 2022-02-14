using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PT4.Model.dal;

namespace PT4
{
    public partial class Form1 : Form
    {

        
        public Form1(IAnimalRepository animalRepo, ServiceCollection services)
        {
            InitializeComponent();
        }
    }
}
