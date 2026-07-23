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
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(
            @"Select
              U.UrunAd, 
              Sum(S.StokAdet) As ToplamStok
             From TBL_URUNLER U
             Inner Join TBL_STOKLAR S
                On U.UrunID = S.UrunID
             Group By U.UrunAd",
             bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;

            SqlCommand komut = new SqlCommand (
             @"Select
              U.UrunAd, 
              Sum(S.StokAdet) As ToplamStok
             From TBL_URUNLER U
             Inner Join TBL_STOKLAR S
                On U.UrunID = S.UrunID
             Group By U.UrunAd",
             bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();
        }

       
    }
}
