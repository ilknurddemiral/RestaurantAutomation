using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmStoklar1_Load(object sender, EventArgs e)
        {
            chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
            chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);

            SqlDataAdapter da = new SqlDataAdapter(
                                                    @"Select
                                                       U.UrunAd, 
                                                       Sum(S.StokAdet) As ToplamStok
                                                      From TBL_URUNLER U
                                                      Inner Join TBL_STOKLAR S
                                                        On U.UrunID = S.UrunID
                                                      Group By U.UrunAd",
                                                     bgl.baglanti());

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = null;

            gridView1.Columns.Clear();

            gridControl1.DataSource = dt;
            gridView1.PopulateColumns();
            gridView1.Columns["UrunAd"].Caption = "Ürün Adı";
            gridView1.Columns["ToplamStok"].Caption = "Toplam Stok";

            gridView1.BestFitColumns();
        }
    }
}
