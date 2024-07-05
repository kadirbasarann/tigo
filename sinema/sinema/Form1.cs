using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Double total = 0;       
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (radioButton1.Checked == false && radioButton2.Checked == false || textBox1.Text == string.Empty)
            {
                MessageBox.Show("BOŞ BIRAKMAYINIZ");
            }
            else
            {
                if (b.Text == "REZERVASYON İPTAL")
                {                 
                    string metin = listBox1.SelectedItem.ToString();
                    string button = metin.Substring(0, 2);
                    string tota = listBox1.SelectedItem.ToString().Substring(15, 10);
                    if (tota=="ÖGR = 10TL")
                    {
                        total -= 10;
                        label11.Text = total.ToString();

                    }
                    else if (tota=="TAM = 15TL")
                    {
                        total-=15;
                        label11.Text = total.ToString();
                    }
                    foreach (Control a in this.Controls)
                    {
                        if ((a is Button) && (a as Button).Enabled==false)
                        {
                            if (a.Text==button)
                            {
                                a.BackColor = Color.LimeGreen;
                                a.Enabled = true;
                            }
                        }
                    }                  
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    progressBar2.Value -= 1;
                    progressBar1.Value += 1;
                    label7.Text = progressBar1.Value.ToString();
                    label9.Text = progressBar2.Value.ToString();
                }
                else
                {
                    if (radioButton1.Checked)
                    {
                        total += 10;
                        label11.Text = total.ToString();
                        listBox1.Items.Add((b.Text.ToString())+"             " +(radioButton1.Text) +"          "+(textBox1.Text));
                        progressBar2.Value += 1;
                        progressBar1.Value -= 1;
                        b.Enabled = false;
                        b.BackColor = Color.Red;
                        label7.Text = progressBar1.Value.ToString();
                        label9.Text = progressBar2.Value.ToString();
                    }
                    if (radioButton2.Checked)
                    {
                        total += 15;
                        label11.Text = total.ToString();
                        listBox1.Items.Add(item: b.Text.ToString() + "             " + radioButton2.Text +"          " +textBox1.Text);
                        progressBar2.Value += 1;
                        progressBar1.Value -= 1;
                        b.Enabled = false;
                        b.BackColor = Color.Red;
                        label7.Text = progressBar1.Value.ToString();
                        label9.Text = progressBar2.Value.ToString();
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 18;
            progressBar2.Value = 0;
        }      
    }   
}