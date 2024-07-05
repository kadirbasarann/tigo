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
    public partial class Form1 : Form
    {
        KadirBaşaran kdr = new KadirBaşaran();
        
        public Form1()
        {
            InitializeComponent();
            kdr.ad = "Liste 1";
            label1.Text = kdr.ad;
            kdr.ad2 = "Liste 2";
            label2.Text = kdr.ad2;

        }

     
        müzikekle msn = new müzikekle();
        Listeleyi_Temzileme akr = new Listeleyi_Temzileme();
        çıkış mkr = new çıkış();
        favoriekleme sad = new favoriekleme();

        
        private void button1_Click(object sender, EventArgs e)
        {
            msn.müzikekleme(openFileDialog1,listBox1,listBox2);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            akr.lt1(listBox1, listBox2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            mkr.çıkıs();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            axWindowsMediaPlayer1.URL = listBox2.SelectedItem.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();

        }
        private void button8_Click()                                                    //overload      
        {
            axWindowsMediaPlayer1.settings.volume += 10;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8_Click();                                                            //overload

        }

        private void button9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume -= 10;

        }

        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastForward();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            sad.favoriyekleme(listBox1, listBox3);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
