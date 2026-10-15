using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Siparişi kapatma ve masa durumunu güncelleme işlemlerini yönetecek.
namespace BarkodluAdisyonSistemi
{
    public class SiparisService
    {
        private sqlBaglantisi bgl = new sqlBaglantisi();

        public bool SiparisKapatveMasayiBosalt(int siparisID, int masaID)
        {
            using(SqlConnection baglanti = bgl.baglanti())
            using (SqlTransaction transaction = baglanti.BeginTransaction())
            {
                try
                {
                    //Siparişi kapat
                    SqlCommand siparisKapatKomutu = new SqlCommand(
                        @"UPDATE TBL_SIPARISLER 
                          SET SiparisDurumu =N'Kapalı'
                          WHERE SiparisID = @SiparisID
                          AND MasaID = @MasaID
                          AND SiparisDurumu = N'Açık'",
                        baglanti,
                        transaction);

                    siparisKapatKomutu.Parameters.AddWithValue("@SiparisID", siparisID);
                    siparisKapatKomutu.Parameters.AddWithValue("@MasaID", masaID);
                    int siparisSatirSayisi = siparisKapatKomutu.ExecuteNonQuery();

                    if (siparisSatirSayisi == 0)
                    {
                        throw new Exception("Açık sipariş bulunamadı veya sipariş kapatılmadı.");
                    }

                    //Masayı boşalt
                    SqlCommand masaBosaltKomutu = new SqlCommand(
                        @"UPDATE TBL_MASALAR
                          SET Durum = 0
                          WHERE MasaID = @MasaID
                          AND Durum = 1",
                        baglanti,
                        transaction);

                    masaBosaltKomutu.Parameters.AddWithValue("@MasaID", masaID);
                    int masaSatirSayisi = masaBosaltKomutu.ExecuteNonQuery();

                    if (masaSatirSayisi == 0)
                    {
                        throw new Exception(
                            "Masa boşaltılmadı.Masa durumu kontrol edilmedi.");
                    }
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
