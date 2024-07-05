using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp3_Çalar
{
    class favoriekleme
    {
        public void favoriyekleme(ListBox listBox1, ListBox listBox3)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                  
                listBox3.Items.Add(listBox1.SelectedItems[i]);
            }
        }
            
    }
}
