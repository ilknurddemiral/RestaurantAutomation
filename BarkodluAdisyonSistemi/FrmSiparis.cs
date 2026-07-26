using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmSiparis : Form
    {
        public int SecilenMasaID { get; set; }
        public FrmSiparis()
        {
            InitializeComponent();
        }
        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            lblMasaAdi.Text = "Masa " + SecilenMasaID;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
