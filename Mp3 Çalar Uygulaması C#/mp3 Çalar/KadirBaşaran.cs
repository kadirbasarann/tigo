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
    class KadirBaşaran
    {
        public KadirBaşaran()
        {
            MessageBox.Show("Hoşgeldin");                   //varsayılan yapıcı metot
        }
        ~KadirBaşaran()
        {
            MessageBox.Show("Görüşmek üzere");              //varsayılan yıkıcı metot 
        }
        public string ad="Liste1";
        public string Ad                                    //property
        {
            get
            { 
                return ad.ToUpper(); 
            }
            set
            {
                if (value == "LİSTE1") ;
                ad=value;
            }
        }
        public string ad2 = "Liste2";
        public string Ad2                                    //property
        {
            get { return ad2.ToUpper(); }
            set
            {
                if (value == "LİSTE2") ;
                ad2 = value;
            }
        }

    }
}
