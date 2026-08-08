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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtSubeID.Text = dr["SubeID"].ToString();
                txtSubeAd.Text = dr["Ad"].ToString(); 
                txtYetkiliAd.Text = dr["YetkiliAdSoyad"].ToString();
                txtStatu.Text = dr["YetkiliStatu"].ToString();
                txtTC.Text = dr["YetkiliTC"].ToString();
                txtTelefon1.Text = dr["Telefon1"].ToString();
                txtTelefon2.Text = dr["Telefon2"].ToString();
                txtTelefon3.Text = dr["Telefon3"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                txtFax.Text = dr["Fax"].ToString();
                lueIL.Text = dr["IL"].ToString();
                lueIlce.Text = dr["ILCE"].ToString();
                txtVergiDairesi.Text = dr["VergiDaire"].ToString();
                rtbAdres.Text = dr["Adres"].ToString();
                txtKod1.Text = dr["OzelKod1"].ToString();
                txtKod2.Text = dr["OzelKod2"].ToString();
                txtKod3.Text = dr["OzelKod3"].ToString();
            }
        }
    }
}
