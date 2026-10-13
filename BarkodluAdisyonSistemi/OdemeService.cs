using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Nakit ve kart ödeme akışını yönetecek. Başarılı ödeme sonrası gerekli işlemleri başlatacak.
namespace BarkodluAdisyonSistemi
{
    public class OdemeService
    {
        private OdemeKayitServices odemeKayitServices = new OdemeKayitServices();
        private SiparisService siparisService = new SiparisService();

        public bool OdemeIsleminiTamamla(
            int siparisID,
            int masaID,
            int odemeTuruID,
            decimal tutar,
            decimal odenenTutar,
            decimal paraUstu,
            string referansNo,
            string aciklama)
        {
            //ödemeyi veritabanına kaydet
            bool kaydedildi = odemeKayitServices.OdemeKaydet(
                siparisID, odemeTuruID, null, tutar, odenenTutar,
                paraUstu, "Başarılı", referansNo, aciklama);

            if (!kaydedildi)
            {
                return false;
            }

            //siparişi kapat ve masayı boşalt
            bool siparisKapatildi = siparisService.SiparisKapatveMasayiBosalt(siparisID, masaID);
            return siparisKapatildi;
        }
    }
}
