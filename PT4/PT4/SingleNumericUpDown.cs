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
    public partial class SingleNumericUpDown : Form
    {
        public decimal Value { get => this.numericUpDown1.Value; }

        public SingleNumericUpDown(string text, decimal min = 0, decimal max = 100, int decimalPlaces = 0, decimal increment = 1)
        {
            InitializeComponent();
            this.label1.Text = text;
            this.numericUpDown1.Minimum = min;
            this.numericUpDown1.Maximum = max;
            this.numericUpDown1.DecimalPlaces = decimalPlaces;
            this.numericUpDown1.Increment = increment;
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
