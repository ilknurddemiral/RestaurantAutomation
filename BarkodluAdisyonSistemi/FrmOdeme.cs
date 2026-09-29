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
    public partial class FrmOdeme : Form
    {
        public FrmOdeme()
        {
            InitializeComponent();
        }
        public int SiparisID { get; set; }
        public int MasaID { get; set; }
        public decimal ToplamTutar { get; set; }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            lblToplamTutarDeger.Text = ToplamTutar.ToString("N2") + "₺";

            cmbOdemeTuru.Items.Clear();
            cmbOdemeTuru.Items.Add("Nakit");
            cmbOdemeTuru.Items.Add("Kart");

            cmbOdemeTuru.SelectedIndex = 0;

            lblParaUstuDegeri.Text = "0,00 ₺";
        }
    }
}
