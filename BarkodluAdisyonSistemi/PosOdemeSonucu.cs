using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodluAdisyonSistemi
{
    public class PosOdemeSonucu
    {
        public bool Basarili { get; set; }
        public decimal Tutar { get; set; }
        public string ReferansNo { get; set; }
        public string Mesaj { get; set; }
    }
}
