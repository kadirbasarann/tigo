using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKUL_KAYDI_GEÇTİ_KALDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başarıyla Kaydedilmiştir");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int notu = 0;
            notu = Convert.ToInt32(textBox5.Text);
            if (notu>50 )
            {
                listBox1.Items.Add(textBox1.Text + "        " + textBox2.Text + "        " + textBox3.Text + "        " + textBox4.Text + "       " + notu);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int notu = 0;
            notu = Convert.ToInt32(textBox5.Text);
            if (notu < 50)
            {
                listBox1.Items.Add(textBox1.Text + "        " + textBox2.Text + "        " + textBox3.Text + "        " + textBox4.Text + "       " + notu);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int notu = 0;
            notu = Convert.ToInt32(textBox5.Text);
            listBox1.Items.Add(textBox1.Text + "        " + textBox2.Text + "        " + textBox3.Text + "        " + textBox4.Text + "       " + notu);
        }
    }
}
