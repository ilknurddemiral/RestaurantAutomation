using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmSubeler : Form
    {
        public FrmSubeler()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        void subeListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_SUBELER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void FrmSubeler_Load(object sender, EventArgs e)
        {
            subeListesi();
        }
    }
}
