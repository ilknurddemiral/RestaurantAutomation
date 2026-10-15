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

//Ödeme ekranı, kullanıcı girişleri, para üstü ve başarı/hata mesajları
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

        private OdemeService odemeService = new OdemeService();
        private FrmSiparis masalaraDon = new FrmSiparis();

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
            if (cmbOdemeTuru.SelectedItem == null)
            {
                MessageBox.Show("lütfen ödeme türünü seçiniz.");
                return;
            }
            string odemeTuru = cmbOdemeTuru.Text;
            
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

                bool basarili = odemeService.OdemeIsleminiTamamla(
                    SiparisID,
                    MasaID,
                    1,
                    ToplamTutar,
                    odenenTutar,
                    paraUstu,
                    null,
                    "Nakit ödemesi"
                    );
                

                if (basarili)
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

                    masalaraDon.MasalaraDon();
                }
                else
                {
                    MessageBox.Show("Ödeme tamamlanamadı.");
                }

            }

            else if ( odemeTuru == "Kart")
            {
                PosServicecs pos = new PosServicecs();

                PosOdemeSonucu sonuc = pos.OdemeAl(ToplamTutar);

                if (!sonuc.Basarili)
                {
                    MessageBox.Show(
                        "Kart ödemesi başarısız.\n" +
                        sonuc.Mesaj,
                        "Ödeme Başarısız",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return;
                }
                bool basarili = odemeService.OdemeIsleminiTamamla(
                    SiparisID,
                    MasaID,
                    2,
                    ToplamTutar,
                    ToplamTutar,
                    0,
                    sonuc.ReferansNo,
                    "Kart ödemesi"
                    );
                if (basarili)
                {
                    MessageBox.Show(
                        "Kart ödeme başarılı.\n" +
                        "Tutar: " + sonuc.Tutar.ToString("N2") + "₺\n" +
                        "Referans No: " + sonuc.ReferansNo,
                        "Ödeme Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    masalaraDon.MasalaraDon();
                }
                else
                {
                    MessageBox.Show(
                        "Kart ödemesi alındı ancak kayıt veya sipariş kapatma işlemi tamamlanamadı.",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
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
