using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodluAdisyonSistemi
{
    public class PosServicecs
    {
        public PosOdemeSonucu OdemeAl(decimal tutar)
        {
            PosOdemeSonucu sonuc = new PosOdemeSonucu();

            sonuc.Basarili = true;
            sonuc.Tutar = tutar;
            sonuc.ReferansNo = "SIM-" + Guid.NewGuid().ToString("N").Substring(0, 10);
            sonuc.Mesaj = "POS ödeme işlemi başarılı.";

            return sonuc;
        }

    }
}