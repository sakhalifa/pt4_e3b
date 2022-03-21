using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public class Utils
    {
        public static void ShowError(string text)
        {
            MessageBox.Show(text, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
