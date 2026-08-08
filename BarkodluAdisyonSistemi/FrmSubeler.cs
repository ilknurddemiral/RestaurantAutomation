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

        void temizle()
        {
            txtSubeID.Text = "";
            txtSubeAd.Text = "";
            txtYetkiliAd.Text = "";
            txtStatu.Text = "";
            txtTC.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtTelefon3.Text = "";
            txtMail.Text = "";
            txtFax.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtVergiDairesi.Text = "";
            rtbAdres.Text = "";
        }
        private void FrmSubeler_Load(object sender, EventArgs e)
        {
            subeListesi();
            IlleriGetir();
            IlceleriGetir();
            temizle();
        }
           
        void IlleriGetir()
        {
            SqlCommand komut = new SqlCommand(
                "Select IL From TBL_ILLER Order By IL",
                bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cmbil.Items.Add(dr["IL"].ToString());
            }
            dr.Close();
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Items.Clear();

        }
        void IlceleriGetir()
        {
            SqlCommand komut = new SqlCommand(
                "Select ILCE From TBL_ILCELER Where IL = @P1",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", cmbil.SelectedIndex + 1);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cmbilce.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtSubeID.Text = dr["SubeID"].ToString();
                txtSubeAd.Text = dr["SubeAd"].ToString(); 
                txtYetkiliAd.Text = dr["YetkiliAdSoyad"].ToString();
                txtStatu.Text = dr["YetkiliStatu"].ToString();
                txtTC.Text = dr["YetkiliTC"].ToString();
                txtTelefon1.Text = dr["Telefon1"].ToString();
                txtTelefon2.Text = dr["Telefon2"].ToString();
                txtTelefon3.Text = dr["Telefon3"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                txtFax.Text = dr["Fax"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtVergiDairesi.Text = dr["VergiDaire"].ToString();
                rtbAdres.Text = dr["Adres"].ToString();
                
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = bgl.baglanti())
            {


                SqlCommand kontrol = new SqlCommand(
                   @"Select Count(*) 
                  From TBL_SUBELER
                  Where SubeAd = @P1
                  And YetkiliAdSoyad = @P2
                  And YetkiliStatu = @P3
                  And YetkiliTC = @P4
                  And Adres = @P5",
                    baglanti);

                kontrol.Parameters.AddWithValue("@P1", txtSubeAd.Text);
                kontrol.Parameters.AddWithValue("@P2", txtYetkiliAd.Text);
                kontrol.Parameters.AddWithValue("@P3", txtStatu.Text);
                kontrol.Parameters.AddWithValue("@P4", txtTC.Text);
                kontrol.Parameters.AddWithValue("@P5", rtbAdres.Text);

                int kayitSayisi = Convert.ToInt32(kontrol.ExecuteScalar());
                if ( kayitSayisi > 0)
                {
                    MessageBox.Show(
                        "Aynı bilgilere sahip bir şube zaten var",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    temizle();
                    return;

                }
;
                SqlCommand komut = new SqlCommand(
                "Insert into TBL_SUBELER" +
                "(SubeAd,YetkiliAdSoyad,YetkiliStatu,YetkiliTC,Telefon1,Telefon2," +
                "Telefon3,Mail,Fax,IL,ILCE,VergiDaire,Adres)" +
                "Values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13)",
                bgl.baglanti());

                komut.Parameters.AddWithValue("@P1", txtSubeAd.Text);
                komut.Parameters.AddWithValue("@P2", txtYetkiliAd.Text);
                komut.Parameters.AddWithValue("@P3", txtStatu.Text);
                komut.Parameters.AddWithValue("@P4", txtTC.Text);
                komut.Parameters.AddWithValue("@P5", txtTelefon1.Text);
                komut.Parameters.AddWithValue("@P6", txtTelefon2.Text);
                komut.Parameters.AddWithValue("@P7", txtTelefon3.Text);
                komut.Parameters.AddWithValue("@P8", txtMail.Text);
                komut.Parameters.AddWithValue("@P9", txtFax.Text);
                komut.Parameters.AddWithValue("@P10", cmbil.Text);
                komut.Parameters.AddWithValue("@P11", cmbilce.Text);
                komut.Parameters.AddWithValue("@P12", txtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@P13", rtbAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Şube sisteme kaydedildi.",
                   "Bilgi",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                subeListesi();
                temizle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                "Delete From TBL_SUBELER Where SubeID = @P1",
                bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", txtSubeID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            subeListesi();

            MessageBox.Show("Şube Listeden Silindi",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                @"Update TBL_SUBELER
                  Set SubeAd = @P1,
                  YetkiliAdSoyad = @P2,
                  YetkiliStatu = @P3,
                  YetkiliTC = @P4,
                  Telefon1 = @P5,
                  Telefon2 = @P6,
                  Telefon3 = @P7,
                  Mail = @P8,
                  Fax = @P9,
                  IL = @P10,
                  ILCE = @P11,
                  VergiDaire = @P12,
                  Adres = @P13
                  Where SubeID = @P14",
                bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", txtSubeAd.Text);
            komut.Parameters.AddWithValue("@P2", txtYetkiliAd.Text);
            komut.Parameters.AddWithValue("@P3", txtStatu.Text);
            komut.Parameters.AddWithValue("@P4", txtTC.Text);
            komut.Parameters.AddWithValue("@P5", txtTelefon1.Text);
            komut.Parameters.AddWithValue("@P6", txtTelefon2.Text);
            komut.Parameters.AddWithValue("@P7", txtTelefon3.Text);
            komut.Parameters.AddWithValue("@P8", txtMail.Text);
            komut.Parameters.AddWithValue("@P9", txtFax.Text);
            komut.Parameters.AddWithValue("@P10", cmbil.Text);
            komut.Parameters.AddWithValue("@P11", cmbilce.Text);
            komut.Parameters.AddWithValue("@P12", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@P13", rtbAdres.Text);
            komut.Parameters.AddWithValue("@P14", txtSubeID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şube bilgileri güncellendi.",
               "Bilgi",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            subeListesi();
            temizle();
        }
    }
}
