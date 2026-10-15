using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Ödeme bilgilerinin veritabanına kaydedilmesi
namespace BarkodluAdisyonSistemi
{
    public class OdemeKayitServices
    {
        private sqlBaglantisi bgl = new sqlBaglantisi();

        public bool OdemeKaydet(
            int siparisID,
            int odemeTuruID,
            int? bankaID,
            decimal tutar,
            decimal odenenTutar,
            decimal paraUstu,
            string odemeDurumu,
            string referansNo,
            string aciklama)
        {
            try
            {
                using (SqlConnection baglanti = bgl.baglanti())
                {
                    string sorgu = @"
                        INSERT INTO TBL_ODEME
                        (
                          SiparisID, OdemeTuruID, BankaID,Tutar, OdenenTutar,
                          ParaUstu, OdemeTarihi, OdemeDurumu, ReferansNo, Aciklama
                        )
                        VALUES
                        (
                          @SiparisID, @OdemeTuruID, @BankaID, @Tutar, @OdenenTutar,
                          @ParaUstu, @OdemeTarihi, @OdemeDurumu, @ReferansNo, @Aciklama
                        )";

                    using(SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@SiparisID", siparisID);
                        komut.Parameters.AddWithValue("@OdemeTuruID", odemeTuruID);

                        if (bankaID.HasValue)
                        {
                            komut.Parameters.AddWithValue("@BankaID", bankaID.Value);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("@BankaID", DBNull.Value);
                        }

                        komut.Parameters.AddWithValue("@Tutar", tutar);
                        komut.Parameters.AddWithValue("@OdenenTutar", odenenTutar);
                        komut.Parameters.AddWithValue("@ParaUstu", paraUstu);
                        komut.Parameters.AddWithValue("@OdemeTarihi", DateTime.Now);
                        komut.Parameters.AddWithValue("@OdemeDurumu", odemeDurumu);

                        if (string.IsNullOrEmpty(referansNo))
                        {
                            komut.Parameters.AddWithValue("@ReferansNo", DBNull.Value);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("@ReferansNo", referansNo);
                        }

                        if (string.IsNullOrEmpty(aciklama))
                            komut.Parameters.AddWithValue("@Aciklama", DBNull.Value);
                        else
                            komut.Parameters.AddWithValue("@Aciklama", aciklama);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch(System.Exception hata)
            {
                MessageBox.Show(
                "Ödeme kayıt hatası:\n" + hata.Message,
                "Veritabanı Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}
