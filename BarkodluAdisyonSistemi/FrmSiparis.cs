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
    
        public FrmSiparis()
        {
            InitializeComponent();
            
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
                    @"Select
                      UrunID, 
                      UrunAd,
                      KategoriID,
                      AlisFiyat,
                      SatisFiyat
                      From TBL_URUNLER",
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
                using (SqlConnection baglanti = bgl.baglanti())
                {
                    int siparisID = AcikSiparisIDGetir(baglanti);

                    if (siparisID == 0)
                    {
                        gridControlSiparis.DataSource = null;
                        txtToplamTutar.Text = "0,00 ₺";
                        return;

                    }
                
                SqlDataAdapter da = new SqlDataAdapter(
                    @"Select 
                       SD.SiparisDetayID,
                       SD.UrunID,
                       U.UrunAdi,
                       SD.Miktar,
                       SD.BirimFiyat,
                       SD.SatisToplam
                      From TBL_SIPARISDETAY SD
                      Inner Join TBL_SIPARISLER S
                       On SD.SiparisID = S.SiparisID
                      Inner Join TBL_URUNLER U
                       On SD.UrunID = U.UrunID
                      Where S.MasaID =@masaID
                       And S.SiparisDurum ='Açık'",
                      bgl.baglanti());

                da.SelectCommand.Parameters.AddWithValue("@masaID", SecilenMasaID);
                DataTable dt = new DataTable();
                da.Fill(dt);                                                                                                                

                gridControlSiparis.DataSource = dt;

                ToplamTutarHesapla();
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(
                    "Siparişler listelenirken hata oluştu:\n" + hata.Message);
            }
        }

        void ToplamTutarHesapla()
        {
            decimal SatisToplam = 0;

            for (int i=0; i< gridViewSiparis.RowCount; i++)
            {
                object deger = gridViewSiparis.GetRowCellValue(i, "ToplamTutar");

                if ( deger != null && decimal.TryParse(deger.ToString(), out decimal tutar))
                {
                    SatisToplam += tutar;
                }
            }

            txtToplamTutar.Text = "Toplam: " + SatisToplam.ToString("C2", new System.Globalization.CultureInfo("tr-TR"));
        }

        private void SiparisToplaminiGuncelle(SqlConnection baglanti, int siparisID)
        {
            SqlCommand komut = new SqlCommand(
                @"Update TBL_SIPARISLER
                  Set ToplamTutar = 
                  (  
                     Select IsNull(Sum(SatisToplam), 0)
                     From TBL_SIPARISDETAY
                     Where SiparisID = @SiparisID
                  )
                  Where SiparisID = @SiparisID",
                 baglanti);
            komut.Parameters.AddWithValue("@SiparisId", siparisID);
            komut.ExecuteNonQuery();
        }
        private int AcikSiparisIDGetir(SqlConnection baglanti)
        {
            SqlCommand komut = new SqlCommand(
                @"Select Top 1 SiparisID
                  From TBL_SIPARISLER
                  Where MasaID = @MasaID
                  And SiparisDurumu = N'Açık'
                  Order By SiparisID DESC",
                  baglanti);

            komut.Parameters.AddWithValue(
                "@MasaID",
                SecilenMasaID);

            object sonuc = komut.ExecuteScalar();

            if (sonuc == null || sonuc == DBNull.Value)
                return 0;

            return Convert.ToInt32(sonuc);
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {

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
