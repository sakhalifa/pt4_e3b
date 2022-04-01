using PT4.Controllers;
using System;
using System.Windows.Forms;

namespace PT4
{
    public partial class AfficherJournee : Form
    {
        public AfficherJournee(RendezVousController rendezVousController, DateTime datePicked)
        {
            InitializeComponent();
            for (int i = 0; i < 24; i++)
            {
                dataGridView1.Rows.Add($"{i}-{(i + 1) % 24}h", null);
            }

            foreach (RENDEZVOUS r in rendezVousController.FindForDay(datePicked))
            {
                dataGridView1.Rows[r.DATEHEURERDV.Hour].Cells[1].Value = r;
            }
        }
    }
}
