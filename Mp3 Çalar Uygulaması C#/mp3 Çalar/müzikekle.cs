using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp3_Çalar
{
    class müzikekle
    {
        public void müzikekleme(OpenFileDialog openFileDialog1,ListBox listBox1, ListBox listBox2)
        {
            openFileDialog1.ShowDialog();
            for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
            {
                listBox1.Items.Add(openFileDialog1.SafeFileNames[i].ToString());

                listBox2.Items.Add(openFileDialog1.FileNames[i].ToString());
            }
        }
    }
}
