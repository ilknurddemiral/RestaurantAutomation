using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BarkodluAdisyonSistemi
{
    internal class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-JKG37G1\SQLEXPRESS;Initial Catalog=Dbo Otomasyon;Integrated Security=True;Encrypt=False;");
            baglan.Open();
            return baglan;

        }
    }
}
