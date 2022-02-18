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
    public partial class InterfaceJournalAction : Form
    {
        public InterfaceJournalAction()
        {
            InitializeComponent();
            tableLayoutPanel1.MaximumSize = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            //On va rajouter 10 lignes
            for (int i = 0; i < 10; i++)
            {
                //On va remplir toutes les colonnes
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    /* Si on va rajouter un élément en dehors des limites du tableLayout 
                     * En gros, on sait qu'on va rajouter un élément en dehors des limites ssi le nombre de controles enfants
                     * est supérieur ou égal à hauteur*largeur. Si c'est le cas, on crée une nouvelle ligne avec une taille de 60px
                     * (comme les autres)
                     */
                    if (tableLayoutPanel1.Controls.Count >= tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount)
                    {
                        ++tableLayoutPanel1.RowCount;
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60f));
                    }
                    /* On crée notre label qu'on va rajouter. En gros, ce label a pour texte "Stylax"
                     * Son texte est aligné au centre du label (horizontal et vertical)
                     * Et le label prendra la totalité de l'espace de son controle parent.
                     * Le Dock = Fill est EXTREMEMENT pratique
                     */
                    Label l = new Label()
                    {
                        Text = "Breloom",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    tableLayoutPanel1.Controls.Add(l);
                }
            }
        }


        // 
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 )
            {
                e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds);
            }
            e.Graphics.DrawRectangle(new Pen(Color.Black), e.CellBounds);
        }

        private void Utilisateur_Paint(object sender, PaintEventArgs e)
        {
            User.BackColor = Color.Transparent;
        }

        private void Date_Paint(object sender, PaintEventArgs e)
        {
            Date.BackColor = Color.Transparent;
        }

        private void Action_Paint(object sender, PaintEventArgs e)
        {
            Action.BackColor = Color.Transparent;
        }

        private void Rights_Paint(object sender, PaintEventArgs e)
        {
            Rights.BackColor = Color.Transparent;
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======


   
>>>>>>> 42815f9 (Interfaces Logs)
=======
>>>>>>> 9fec93e (Interface Logs)
    }
}
