using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4.Controllers
{
    public partial class RechercheClient : Form
    {
        private static readonly object[] ITEM_LIST = new object[] { "Nom", "Prenom", "Email", "Nombre d'animaux", "Nombre de RDV dans le mois" };
        public RechercheClient()
        {
            InitializeComponent();
            criteriaCombo.SelectedIndex = 0;
        }



        private void remove_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Parent is TableLayoutPanel table)
            {
                int row = table.GetRow(button);
                for (int i = 0; i <= table.ColumnCount; i++)
                {
                    Control c = table.GetControlFromPosition(i, row);
                    if (!(c is null))
                    {
                        table.Controls.Remove(c);
                        c.Dispose();
                    }
                }

                //Shift every control after the removed row to the row before it.
                for (int i = row + 1; i < table.RowCount; i++)
                {
                    for (int j = 0; j <= table.ColumnCount; j++)
                    {
                        Control c = table.GetControlFromPosition(j, i);
                        if (!(c is null))
                        {
                            table.SetCellPosition(c, new TableLayoutPanelCellPosition(j, i - 1));
                        }
                    }
                }
                Control firstColRow = table.GetControlFromPosition(0, 0);

                if (!(firstColRow is Button))
                {
                    if (!(firstColRow is null))
                    {
                        table.Controls.Remove(firstColRow);
                    }
                }

                if (table.RowCount > 8)
                {
                    table.RowStyles.RemoveAt(row);
                    table.RowCount -= 1;
                }
                if (table.RowCount == 8)
                {
                    table.AutoScroll = false;
                }

            }
        }

        private void critere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.Parent is TableLayoutPanel table)
            {
                int row = table.GetRow(comboBox);
                for (int i = 2; i <= 3; i++)
                {
                    table.Controls.Remove(table.GetControlFromPosition(i, row));
                }

                switch (comboBox.SelectedIndex)
                {
                    //case 0, 1 and 2 have the same logic so we group 'em up
                    case 0:
                    case 1:
                    case 2:
                        TextBox t = new TextBox()
                        {
                            Anchor = AnchorStyles.Left | AnchorStyles.Right
                        };

                        table.Controls.Add(t);
                        table.SetRow(t, row);
                        table.SetColumn(t, 3);
                        break;
                    //same logic as case 0, 1 and 2
                    case 3:
                    case 4:
                        NumericUpDown nd = new NumericUpDown()
                        {
                            Anchor = AnchorStyles.None
                        };

                        table.Controls.Add(nd);
                        table.SetRow(nd, row);
                        table.SetColumn(nd, 3);

                        ComboBox cb = new ComboBox()
                        {
                            Anchor = AnchorStyles.Left | AnchorStyles.Right,
                            DropDownStyle = ComboBoxStyle.DropDownList
                        };
                        cb.Items.AddRange(new string[] { "=", "!=", "<=", ">=", "<", ">" });
                        table.Controls.Add(cb);
                        table.SetRow(cb, row);
                        table.SetColumn(cb, 2);
                        break;
                }
            }
        }

        private void addRow_click(object sender, EventArgs e)
        {
            if (addRow.Parent is TableLayoutPanel table)
            {
                int row = table.GetRow(addRow);
                if (table.RowCount <= row + 1)
                {
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 51.875f));
                    table.RowCount += 1;
                    table.AutoScroll = true;
                }
                table.SetRow(addRow, row + 1);
                if (row > 0)
                {
                    ComboBox andOr = new ComboBox()
                    {
                        Anchor = AnchorStyles.None,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    andOr.Items.AddRange(new string[] { "ET", "OU" });
                    table.Controls.Add(andOr);
                    table.SetRow(andOr, row);
                    table.SetColumn(andOr, 0);
                }
                ComboBox criteria = new ComboBox()
                {
                    Anchor = AnchorStyles.None,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = criteriaCombo.Width
                };

                criteria.Items.AddRange(ITEM_LIST);
                criteria.SelectedIndexChanged += critere_SelectedIndexChanged;

                table.Controls.Add(criteria);
                table.SetRow(criteria, row);
                table.SetColumn(criteria, 1);

                Button rmvRow = new Button()
                {
                    Anchor = AnchorStyles.None,
                    Text = "-"
                };
                rmvRow.Click += remove_Click;
                table.Controls.Add(rmvRow);
                table.SetRow(rmvRow, row);
                table.SetColumn(rmvRow, 4);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.RowCount - 1; i++)
            {

                if (tableLayoutPanel1.GetControlFromPosition(0, i) is ComboBox combinType)
                {
                    if (combinType.SelectedItem is null)
                    {
                        Utils.ShowError("ERREUR! Veuillez choisir une combinaison valide!");
                        return;
                    }
                }
                if (tableLayoutPanel1.GetControlFromPosition(1, i) is ComboBox critere)
                {
                    if (critere.SelectedItem is null)
                    {
                        Utils.ShowError("ERREUR! Veuillez choisir un critère!");
                        return;
                    }
                }
                if (tableLayoutPanel1.GetControlFromPosition(2, i) is ComboBox checkType)
                {
                    if (checkType.SelectedItem is null)
                    {
                        Utils.ShowError("ERREUR! Veuillez choisir une comparaison valide!");
                        return;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
