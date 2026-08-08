using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", 
                bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            KategoriListede();
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //verileri kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER(UrunAd,KategoriID,AlisFiyat,SatisFiyat) values" +
                "(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", lueKategori.EditValue);
            komut.Parameters.AddWithValue("@p3", ceAlisFiyat.EditValue);
            komut.Parameters.AddWithValue("@p4", ceSatisFiyat.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            AlanlariTemizle();


        }
        void KategoriListede()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT KategoriID, KategoriAdi FROM TBL_KATEGORILER",
                bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);

            lueKategori.Properties.DataSource = dt;
            lueKategori.Properties.DisplayMember = "KategoriAdi";
            lueKategori.Properties.ValueMember = "KategoriID";
            lueKategori.Properties.NullText = "Kategori Seçiniz";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_URUNLER where UrunID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtUrunID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtUrunID.Text = dr["UrunID"].ToString();
            txtUrunAd.Text = dr["UrunAd"].ToString();
            lueKategori.EditValue = dr["KategoriID"];
            ceAlisFiyat.EditValue = dr["AlisFiyat"];
            ceSatisFiyat.EditValue = dr["SatisFiyat"];
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set UrunAd=@p1,KategoriId=@p2,AlisFiyat=@p3, SatisFiyat=@p4 where UrunID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", lueKategori.EditValue);
            komut.Parameters.AddWithValue("@p3", ceAlisFiyat.EditValue);
            komut.Parameters.AddWithValue("@p4", ceSatisFiyat.EditValue);
            komut.Parameters.Add("@p5", txtUrunID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        void AlanlariTemizle()
        {
            txtUrunID.Text = "";
            txtUrunAd.Text = "";
            lueKategori.EditValue = null;
            ceAlisFiyat.EditValue = null;
            ceSatisFiyat.EditValue = null;

            txtUrunAd.Focus();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AlanlariTemizle();
        }
    }
}
