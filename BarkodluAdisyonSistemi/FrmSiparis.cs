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
using DevExpress.Office;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmSiparis : Form
    {
        public int SecilenMasaID { get; set; }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private int masaID;
        public FrmSiparis(int gelenMasaID)
        {
            InitializeComponent();
            masaID = gelenMasaID;
        }
        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            lblMasaAdi.Text = "Masa " + SecilenMasaID;
            UrunleriListele();
            SiparisleriListele();
        }
        void UrunleriListele()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"Select UrunID, UrunAdi, SatisAdi,Stok
                      From TBL_URUNLER
                      Where AktifMi =1",
                    bgl.baglanti());

                DataTable dt = new DataTable();
                da.Fill(dt);

                gridControlUrunler.DataSource = dt;
            }
            catch (Exception hata)
            {
                MessageBox.Show(
                    "Ürünler listelenirken hata oluştu:\n" + hata.Message);
            }
        }

        void SiparisleriListele()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"Select 
                       SD.SiparisDetayID,
                       SD.UrnID,
                       U.UrunAdi,
                       SD.Miktar,
                       SD.BirimFiyat,
                       SD.ToplamFiyat
                      From TBL_SIPARISDETAY SD
                      Inner Join TBL_SIPARISLER S
                       On SD.SiparisID = S.SiparisID
                      Inner Join TBL_URUNLER U
                       On SD.UrunID = U.UrunID
                      Where S.MasaID =@masaID
                       And S.Durum ='Açık'",
                      bgl.baglanti());

                da.SelectCommand.Parameters.AddWithValue("@masaID", SecilenMasaID);
                DataTable dt = new DataTable();

                gridControlSiparis.DataSource = dt;

                ToplamTutarHesapla();
            }
            catch(Exception hata)
            {
                MessageBox.Show(
                    "Siparişler listelenirken hata oluştu:\n" + hata.Message);
            }
        }
        void ToplamTutarHesapla()
        {
            decimal toplamTutar = 0;

            for (int i=0; i< gridViewSiparis.RowCount; i++)
            {
                object deger = gridViewSiparis.GetRowCellValue(i, "ToplamTutar");

                if ( deger != null && decimal.TryParse(deger.ToString(), out decimal tutar))
                {
                    toplamTutar += tutar;
                }
            }

            txtToplamTutar.Text = "Toplam: " + toplamTutar.ToString("C2", new System.Globalization.CultureInfo("tr-TR"));
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
