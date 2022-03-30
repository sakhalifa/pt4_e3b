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
    public partial class ajouterConge : Form
    {
        private SalarieController _salarieController;
        private SALARIÉ _salarie;
        public ajouterConge(SalarieController salarieController, int salarieId)
        {
            InitializeComponent();
            _salarieController = salarieController;
            _salarie = salarieController.GetSalarieFromId(salarieId);
        }

    

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {

            if(dateTimePickerFin.Value.Date < dateTimePickerDebut.Value.Date || dateTimePickerDebut.Value.Date < DateTime.Now)
            {
                Utils.ShowError("Veuillez sélectionner des dates valides");
            }
            
            else
            {
                
                try
                {
                    _salarieController.PositionnerConge( _salarie, dateTimePickerDebut.Value.Date, dateTimePickerFin.Value.Date);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex.Message);
                    return;
                }
               
            }

        }
    }
}
