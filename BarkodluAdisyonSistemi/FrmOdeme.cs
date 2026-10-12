using DevExpress.XtraBars;
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
    public partial class FrmOdeme : Form
    {
        sqlBaglantisi bgl = new sqlBaglantisi();
        public FrmOdeme()
        {
            InitializeComponent();
        }
        public int SiparisID { get; set; }
        public int MasaID { get; set; }
        public decimal ToplamTutar { get; set; }

        private OdemeKayitServices odemeKayitServies = new OdemeKayitServices();

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            lblToplamTutarDeger.Text = ToplamTutar.ToString("N2") + "₺";

            OdemeTurleriniGetir();
            lblParaUstuDegeri.Text = "0,00 ₺";

        }

        private void OdemeTurleriniGetir()
        {
            string sorgu = @"
                Select OdemeTuruID, OdemeTuru
                From TBL_ODEMETURU
                ORDER By OdemeTuruID";

            using (SqlConnection baglanti = bgl.baglanti())
                using (SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbOdemeTuru.DataSource = dt;
                cmbOdemeTuru.DisplayMember = "Odemeturu";
                cmbOdemeTuru.ValueMember = "OdemeTuruID";
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            string odemeTuru = cmbOdemeTuru.SelectedItem.ToString();

            if (odemeTuru == "Nakit")
            {
                decimal odenenTutar;
                //girilen tutar sayı mı kontol et
                if(!decimal.TryParse(txtOdenenTutar.Text, out odenenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz.");
                    return;
                }

                //Müşterinin verdiği para yetrli mi
                if  (odenenTutar < ToplamTutar)
                {
                    MessageBox.Show("Girilen tutar yetersiz.");
                    return;
                }

                decimal paraUstu = odenenTutar - ToplamTutar;

                bool kaydedildi = odemeKayitServies.OdemeKaydet(
                    SiparisID,
                    1,
                    null,
                    ToplamTutar,
                    odenenTutar,
                    paraUstu,
                    "Başarılı",
                    "NAKIT-" + Guid.NewGuid().ToString("N").Substring(0, 10),
                    "Nakit ödemesi"
                    );

                if (kaydedildi)
                {
                    MessageBox.Show(
                        "Nakit ödeme başarılı.\n" +
                        "Toplam Tutar: " + ToplamTutar.ToString("N2") + "₺\n" +
                        "Ödenen Tutar: " + odenenTutar.ToString("N2") + "₺\n" +
                        "Para Üstü: " + paraUstu.ToString("N2") + " ₺",
                        "Ödeme Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
                else
                {

                    MessageBox.Show(
                        "Ödeme veritabanına kaydedilmedi.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }

            }

            else if ( odemeTuru == "Kart")
            {
                PosServicecs pos = new PosServicecs();

                PosOdemeSonucu sonuc = pos.OdemeAl(ToplamTutar);

                if (sonuc.Basarili)
                {
                    bool kaydedildi = odemeKayitServies.OdemeKaydet(
                        SiparisID, 2, null, ToplamTutar, ToplamTutar, 0,
                        "Başarılı", sonuc.ReferansNo, "Kart ödemesi"
                        );
                    if (kaydedildi)
                    {
                        MessageBox.Show(
                        "Kart ödemesi başarılı.\n" +
                        "Tutar:" + sonuc.Tutar.ToString("N2") + "₺\n" +
                        "Referans No: " + sonuc.ReferansNo,
                        "Ödeme Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    }
                    
                }
                else
                {
                    MessageBox.Show(
                        "Kart ödemesi başarısız.\n" +
                        sonuc.Mesaj,
                        "Ödeme Başarısız",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        private void ParaUstuHesapla()
        {
            decimal odenenTutar;
            if ( decimal.TryParse(txtOdenenTutar.Text, out odenenTutar))
            {
                decimal paraUstu = odenenTutar - ToplamTutar;

                if (paraUstu >= 0)
                {
                    lblParaUstuDegeri.Text = paraUstu.ToString("N2") + "₺";
                }
                else
                {
                    lblParaUstuDegeri.Text = "Yetersiz ödeme";
                }
            }
            else
            {
                lblParaUstuDegeri.Text = "0,00 ₺";
            }
        }

        private void txtOdenenTutar_TextChanged(object sender, EventArgs e)
        {
            ParaUstuHesapla();
        }
    }
}
