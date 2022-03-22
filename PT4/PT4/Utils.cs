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
        public static DialogResult ShowError(string text)
        {
            return MessageBox.Show(text, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static List<T> GetRangeAndCut<T>(List<T> list, int offset, int count)
        {
            int realCount = count;
            if(count * (offset+1) > list.Count())
            {
                realCount = list.Count() / (offset + 1);
            }

            return list.GetRange(offset, realCount);
        }
    }
}
