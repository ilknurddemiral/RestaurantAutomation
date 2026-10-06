using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmOdeme : Form
    {
        sqlBaglantisi bgl = new sqlBaglantisi();
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

            OdemeTurleriniGetir();
            lblParaUstuDegeri.Text = "0,00 ₺";

        }

        private void OdemeTurleriniGetir()
        {
            string sorgu = @"
                Select OdemeTuruID, OdemeTuru
                From TBL_ODEMETURU
                ORDER By OdemeTuruID";

            using (SqlConnection baglanti = bgl.baglanti())
                using (SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbOdemeTuru.DataSource = dt;
                cmbOdemeTuru.DisplayMember = "Odemeturu";
                cmbOdemeTuru.ValueMember = "OdemeTuruID";
            }
        }

    }
}
