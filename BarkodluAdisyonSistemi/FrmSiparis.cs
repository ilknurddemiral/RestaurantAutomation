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
                       U.UrunAd,
                       SD.Miktar,
                       SD.BirimFiyat,
                       SD.SatisToplam
                      From TBL_SIPARISDETAY SD
                      Inner Join TBL_SIPARISLER S
                       On SD.SiparisID = S.SiparisID
                      Inner Join TBL_URUNLER U
                       On SD.UrunID = U.UrunID
                      Where S.MasaID =@masaID
                       And S.SiparisDurumu ='Açık'",
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

        private void SiparisToplaminiGuncelle(SqlConnection baglanti, SqlTransaction transaction, int siparisID)
        {
            SqlCommand komut = new SqlCommand(
                @"UPDATE TBL_SIPARISLER
                 SET ToplamTutar =
                (
                   SELECT ISNULL(SUM(SatisToplam), 0)
                   FROM TBL_SIPARISDETAY
                   WHERE SiparisID = @SiparisID
                )
                WHERE SiparisID = @SiparisID",
                baglanti,
                transaction);

            komut.Parameters.AddWithValue("@SiparisID", siparisID);

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
            if (gridViewUrunler.FocusedRowHandle < 0)
            {
                MessageBox.Show("Lütfen ürün listesinden bir ürün seçiniz",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            object urunIDDegeri = gridViewUrunler.GetFocusedRowCellValue("UrunID");
            object fiyatDegeri = gridViewUrunler.GetFocusedRowCellValue("SatisFiyat");

            if (urunIDDegeri == null || fiyatDegeri == null)
            {
                MessageBox.Show("Seçilen ürün bilgileri alınamadı");

                return;
            }

            int urunID = Convert.ToInt32(urunIDDegeri);
            decimal birimFiyat = Convert.ToDecimal(fiyatDegeri);

            try
            {
                using (SqlConnection baglanti = bgl.baglanti())
                {
                    SqlTransaction transaction = baglanti.BeginTransaction();
                    try
                    {
                        //bu masaya ait açık sipariş aranıyor
                        SqlCommand siparisBulKomutu = new SqlCommand(
                            @"Select top 1 siparisID
                              From TBL_SIPARISLER
                              Where MasaID = @MasaID
                              And SiparisDurumu = N'Açık'
                              Order By SiparisID DESC",
                            baglanti, transaction);

                        siparisBulKomutu.Parameters.AddWithValue("@MasaID", SecilenMasaID);

                        object siparisSonucu = siparisBulKomutu.ExecuteScalar();

                        int siparisID;

                        if (siparisSonucu == null || siparisSonucu == DBNull.Value)
                        {
                            //yeni sipariş oluştur
                            SqlCommand siparisEkleKomutu = new SqlCommand(
                                @"Insert Into TBL_SIPARISLER
                                  (
                                    MasaID,
                                    SiparisTarihi,
                                    ToplamTutar,
                                    SiparisDurumu
                                  )
                                  Output Inserted.SiparisID
                                  Values
                                  (
                                    @MasaID,
                                    GETDATE(),
                                    0,
                                    N'Açık'
                                   )",
                                baglanti,
                                transaction);

                            siparisEkleKomutu.Parameters.AddWithValue("@MasaID", SecilenMasaID);
                            siparisID = Convert.ToInt32(siparisEkleKomutu.ExecuteScalar());
                        }
                        else
                        {
                            siparisID = Convert.ToInt32(siparisSonucu);
                        }

                        // Aynı ürün daha önce eklenmiş mi?
                        SqlCommand detayBulKomutu = new SqlCommand(
                            @"Select SiparisDetayID
                              From TBL_SIPARISDETAY
                              Where SiparisID = @SiparisID
                              And UrunID = @UrunID",
                            baglanti,
                            transaction);

                        detayBulKomutu.Parameters.AddWithValue("@SiparisID", siparisID);
                        detayBulKomutu.Parameters.AddWithValue("@UrunID", urunID);

                        object detaySonucu = detayBulKomutu.ExecuteScalar();

                        if (detaySonucu == null || detaySonucu == DBNull.Value)
                        {
                            //ürün ilk kez ekleniyorsa yeni satır oluştur
                            SqlCommand detayEkleKomutu = new SqlCommand(
                                @"Insert Into TBl_SIPARISDETAY
                                  (
                                      SiparisID,
                                      UrunID,
                                      Miktar,
                                      BirimFiyat,
                                      SatisToplam
                                  )
                                  Values
                                  (
                                      @SiparisID,
                                      @UrunID,
                                      1,
                                      @BirimFiyat,
                                      @BirimFiyat
                                   )",
                                baglanti,
                                transaction);

                            detayEkleKomutu.Parameters.AddWithValue("@SiparisID", siparisID);
                            detayEkleKomutu.Parameters.AddWithValue("@UrunID", urunID);
                            detayEkleKomutu.Parameters.AddWithValue("@BirimFiyat", birimFiyat);

                            detayEkleKomutu.ExecuteNonQuery();
                            SiparisToplaminiGuncelle(baglanti, transaction, siparisID);
                        }
                        else
                        {
                            MessageBox.Show("Bu ürün zaten bulunuyor.\n" +
                                "Miktarı artırmak için Artır butonunu kullanın.",
                                "Bilgi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            transaction.Rollback();
                            return;
                        }
                        SqlCommand masaGuncelleKomutu = new SqlCommand(
                            @"Update TBL_MASALAR
                              Set Durum = 1
                              Where MasaID = @MasaID",
                            baglanti,
                            transaction);

                        masaGuncelleKomutu.Parameters.AddWithValue("@MasaID", SecilenMasaID);
                        masaGuncelleKomutu.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                SiparisleriListele();
            }
            catch(Exception hata)
            {
                MessageBox.Show("Ürün eklenirken hata oluştu:\n" + hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //siparis gridinde satır seçilmiş mi
            if (gridViewSiparis.FocusedRowHandle < 0)
            {
                MessageBox.Show("Lütfen sipariş listesinden silmek istediğiniz ürünü seçiniz.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            object detayIDDegeri = gridViewSiparis.GetFocusedRowCellValue("SiparisDetayID");

            if (detayIDDegeri == null || detayIDDegeri == DBNull.Value)
            {
                MessageBox.Show("Seçilen sipariş detay bilgisi alınamadı.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int siparisDetayID = Convert.ToInt32(detayIDDegeri);

            DialogResult cevap = MessageBox.Show("Seçilen ürünü siparişten silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cevap != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection baglanti = bgl.baglanti())
                {
                    
                    int siparisID = AcikSiparisIDGetir(baglanti);

                    if (siparisID == 0)
                    {
                        MessageBox.Show(
                            "Silinecek açık sipariş bulunamadı.",
                            "Uyarı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    SqlTransaction transaction = baglanti.BeginTransaction();

                    try
                    {
                        // Seçilen ürünü sipariş detay tablosundan sil
                        SqlCommand detaySilKomutu = new SqlCommand(
                            @"Delete From TBL_SIPARISDETAY
                              Where SiparisDetayID = @SiparisDetayID
                              AND SiparisID = @SiparisID",
                            baglanti,
                            transaction);

                        detaySilKomutu.Parameters.AddWithValue("@SiparisDetayID", siparisDetayID);
                        detaySilKomutu.Parameters.AddWithValue("@SiparisID", siparisID);
                        int etkilenenSatir = detaySilKomutu.ExecuteNonQuery();

                        if(etkilenenSatir == 0)
                        {
                            MessageBox.Show("Silinecek ürün bulunamadı",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            transaction.Rollback();
                            return;
                        }

                        SiparisToplaminiGuncelle(baglanti, transaction, siparisID);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                SiparisleriListele();

                MessageBox.Show("Seçilen ürün siparişten silindi.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ürün silinirken hata oluştu:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void btnArtir_Click(object sender, EventArgs e)
        {
            //siparis listesinden bir ürün seçilmiş mi
            if (!siparisSatiriSecildi || gridViewSiparis.FocusedRowHandle < 0)
            {
                MessageBox.Show("Lütfen miktarı artırmak istediğiniz ürünü siparişler tablosundan seçiniz.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            
            object detayIDDegeri = gridViewSiparis.GetFocusedRowCellValue("SiparisDetayID");

            if (detayIDDegeri == null || detayIDDegeri == DBNull.Value)
            {
                MessageBox.Show("Seçilen siparisdetaybilgisi alınamadı.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int siparisDetayID = Convert.ToInt32(detayIDDegeri);

            try
            {
                using(SqlConnection baglanti = bgl.baglanti())
                {
                    SqlTransaction transaction = baglanti.BeginTransaction();

                    try
                    {
                        SqlCommand miktarArtirKomutu = new SqlCommand(
                            @"Update TBL_SIPARISDETAY
                              Set Miktar = Miktar + 1,
                                  SatisToplam = ( Miktar + 1) * BirimFiyat
                              Where SiparisDetayID = @SiparisDetayID",
                            baglanti,
                            transaction);

                        miktarArtirKomutu.Parameters.AddWithValue("@SiparisDetayID", siparisDetayID);

                        int etkilenenSatir = miktarArtirKomutu.ExecuteNonQuery();

                        if (etkilenenSatir == 0)
                        {
                            transaction.Rollback();

                            MessageBox.Show("Artılacak ürün bulunamadı.",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                        // detayın bağlı olduğu SiparisID bulunuyor
                        SqlCommand siparisIDBulKomutu = new SqlCommand(
                            @"Select SiparisID
                              From TBL_SIPARISDETAY
                              Where SiparisDetayID = @SiparisDetayID",
                            baglanti,
                            transaction);

                        siparisIDBulKomutu.Parameters.AddWithValue("@SiparisDetayID", siparisDetayID);

                        object siparisIDSonucu = siparisIDBulKomutu.ExecuteScalar();

                        if ( siparisIDSonucu == null)
                        {
                            transaction.Rollback();

                            MessageBox.Show("Sipariş bilgisi bulunamadı.",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        int siparisID = Convert.ToInt32(siparisIDSonucu);

                        SiparisToplaminiGuncelle(baglanti, transaction, siparisID);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                SiparisleriListele();
                siparisSatiriSecildi = true;
            }
            catch(Exception hata)
            {
                MessageBox.Show("Ürün miktarı artırılırken hata oluştu.\n" + hata.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool siparisSatiriSecildi = false;
        private void gridViewUrunler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            siparisSatiriSecildi = false;

            gridViewSiparis.ClearSelection();
            gridViewSiparis.FocusedRowHandle = 
                DevExpress.XtraGrid.GridControl.InvalidRowHandle; ;
        }

        private void gridViewSiparis_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                siparisSatiriSecildi = true;
            }
        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            if (!siparisSatiriSecildi || gridViewSiparis.FocusedRowHandle < 0)
            {
                MessageBox.Show("Lütfen miktarını azaltmak istediğiniz ürünü Siparişler Tablosundan seçiniz.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            object detayIDDegeri = gridViewSiparis.GetFocusedRowCellValue("SiparisDetayID");

            object miktarDegeri = gridViewSiparis.GetFocusedRowCellValue("Miktar");

            if (detayIDDegeri == null || detayIDDegeri == DBNull.Value 
                || miktarDegeri == null|| miktarDegeri == DBNull.Value)
            {
                MessageBox.Show("Seçilen siparis detay bilgisi alınamadı.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int siparisDetayID = Convert.ToInt32(detayIDDegeri);
            int miktar = Convert.ToInt32(miktarDegeri);

            if (miktar <= 1)
            {
                MessageBox.Show("Ürünün miktarı 1,\n" +
                    "Ürünü tamamen kaldırmak için Sil butonunu kullanınız.",
                    "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (SqlConnection baglanti = bgl.baglanti())
                {
                    SqlTransaction transaction = baglanti.BeginTransaction();

                    try
                    {
                        // önce bu detayın bağlı olduğu SiparisID bulunuyor
                        SqlCommand siparisIDBulKomutu = new SqlCommand(
                            @"Select SiparisID
                              From TBL_SIPARISDETAY
                              Where SiparisDetayID = @SiparisDetayID",
                            baglanti,
                            transaction);

                        siparisIDBulKomutu.Parameters.AddWithValue("@SiparisDetayID", siparisDetayID);

                        object siparisIDSonucu = siparisIDBulKomutu.ExecuteScalar();

                        if (siparisIDSonucu == null || siparisIDSonucu == DBNull.Value)
                        {
                            transaction.Rollback();

                            MessageBox.Show("Siparis bilgisi bulunamadı.",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        int siparisID = Convert.ToInt32(siparisIDSonucu);

                        SqlCommand miktarAzaltKomutu = new SqlCommand(
                            @"Update TBL_SIPARISDETAY
                              Set Miktar = Miktar - 1,
                                  SatisToplam = (Miktar - 1) * BirimFiyat
                              Where SiparisDetayID = @SiparisDetayID
                              And Miktar > 1",
                            baglanti,
                            transaction);

                        miktarAzaltKomutu.Parameters.AddWithValue("@SiparisDetayID", siparisDetayID);

                        int etkilenenSatir = miktarAzaltKomutu.ExecuteNonQuery();

                        if(etkilenenSatir == 0)
                        {
                            transaction.Rollback();

                            MessageBox.Show("Ürün mikatrı azaltılamadı.",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        SiparisToplaminiGuncelle(baglanti, transaction, siparisID);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                SiparisleriListele();

                int satirHandle = gridViewSiparis.LocateByValue("SiparisDetayID", siparisDetayID);

                if (satirHandle >= 0)
                {
                    gridViewSiparis.FocusedRowHandle = satirHandle;
                    gridViewSiparis.SelectRow(satirHandle);
                    siparisSatiriSecildi = true;
                }
                else
                {
                    siparisSatiriSecildi = false;
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show("Ürün miktarı azaltılırken hata oluştu:\n" + hata.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
