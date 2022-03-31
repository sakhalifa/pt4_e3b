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
    public partial class AjouterConge : Form
    {

        private SalarieController _salarieController;
        public AjouterConge(SalarieController salarieController)
        {
            InitializeComponent();
            _salarieController = salarieController;
        }


        private void buttonConfirmer_Click(object sender, EventArgs e)
        {

            if(dateTimePickerFin.Value < dateTimePickerDebut.Value || dateTimePickerDebut.Value.Date < DateTime.Now)
            {
                Utils.ShowError("La date de fin doit être supérieure à celle de début");
                return;
            }

            try
            {
                _salarieController.PositionnerConge(Utils.connectedSalarieId.Value, dateTimePickerDebut.Value.Date, dateTimePickerFin.Value.Date, false, checkBoxRegulier.Checked);           
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // if not, it shows the error
            catch (ArgumentException ex)
            {
                Utils.ShowError(ex.Message);
                return;
            }

            catch (DataMisalignedException ex)
            {
                if((bool)ex.Data["canModify"])
                {
                    if (MessageBox.Show("La case 'Est Régulier' ne correspond pas au congé correspondant. Souhaitez-vous le modifier ? ", "Confirmation : ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        _salarieController.PositionnerConge(Utils.connectedSalarieId.Value, dateTimePickerDebut.Value.Date, dateTimePickerFin.Value.Date, true, checkBoxRegulier.Checked);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("La case 'Est Régulier' ne correspond pas au congé correspondant. Vous n'avez pas les droits pour le modifier");
                }
                 
            }
        }
    }
}
