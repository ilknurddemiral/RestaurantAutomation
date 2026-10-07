using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        INSET INTO TBL_ODEME
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
                            komut.Parameters.AddWithValue("@bankaID", bankaID.Value);
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
                        komut.Parameters.AddWithValue("@ReferansNo", referansNo);

                        if (string.IsNullOrEmpty(aciklama))
                            komut.Parameters.AddWithValue("@Aciklama", DBNull.Value);
                        else
                            komut.Parameters.AddWithValue("@Aciklama", aciklama);

                        return komut.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
