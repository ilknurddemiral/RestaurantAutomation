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
using DevExpress.XtraEditors;

namespace BarkodluAdisyonSistemi
{
    public partial class FrmMasalar : Form
    {
        public FrmMasalar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMasalar_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Masa durumları çalıştı");
            MasaDurumlariniGetir();

            for (int i =1; i<=20; i++)
            {
                PanelControl panel =
                    this.Controls.Find("pnlMasa" + i, true)
                    .FirstOrDefault() as PanelControl;

                if (panel == null)
                    continue;

                panel.Click -= Masa_Click;
                panel.Click += Masa_Click;

                foreach (Control kontrol in panel.Controls)
                {
                    panel.Click -= Masa_Click;
                    panel.Click += Masa_Click;
                }
            }
        }
        public void MasaDurumlariniGetir()
        {
            SqlConnection baglanti = bgl.baglanti();
            SqlCommand komut = new SqlCommand(
                "Select MasaID, Durum From TBL_MASALAR",
                baglanti);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["MasaID"]);
                byte durum = Convert.ToByte(dr["Durum"]);

                PanelControl panel =
                    this.Controls.Find("pnlMasa" + id, true).FirstOrDefault() as PanelControl;

                LabelControl lblDurum =
                    this.Controls.Find("lblDurum" + id, true).FirstOrDefault() as LabelControl;

                if ( panel != null)
                {
                    switch (durum)
                    {
                        case 0:
                            panel.Appearance.BackColor = Color.LightGreen;

                            if (lblDurum != null)
                            {
                            lblDurum.Text = "DOLU";
                            lblDurum.Appearance.ForeColor = Color.DarkGreen;
                            }
                            break;

                        case 1:
                            panel.Appearance.BackColor = Color.IndianRed;

                            if (lblDurum != null)
                            {
                                lblDurum.Text = "BOŞ";
                                lblDurum.Appearance.ForeColor = Color.DarkRed;
                            }
                            break;

                        case 2:
                            panel.Appearance.BackColor = Color.Orange;

                            if (lblDurum != null)
                            {
                                lblDurum.Text = "REZERVE";
                                lblDurum.Appearance.ForeColor = Color.DarkOrange;
                            }
                            break;

                        default:
                            panel.Appearance.BackColor = Color.LightGray;

                            if(lblDurum != null)
                            {
                                lblDurum.Text = "BİLİNMİYOR";
                                lblDurum.Appearance.ForeColor = Color.DimGray;
                            }
                            break;

                    }


                    panel.Appearance.Options.UseBackColor = true;

                    if(lblDurum != null)
                    {
                        lblDurum.Appearance.Options.UseForeColor = true;
                    }

                }
            }
            dr.Close();
            baglanti.Close();

        }

        private void Masa_Click(object sender, EventArgs e)
        {
            Control kontrol = sender as Control;

            if (kontrol == null)
                return;

            PanelControl masaPaneli = null;

            while (kontrol != null)
            {
                PanelControl panel = kontrol as PanelControl;

                if (panel != null && 
                    panel.Name.StartsWith("pnlMasa"))
                {
                    masaPaneli = panel;
                    break;
                }

                kontrol = kontrol.Parent;      
            }


            if (masaPaneli == null)
                return;

            if (!int.TryParse(masaPaneli.Tag?.ToString(), out int masaID))
            {
                MessageBox.Show(
                    "Masa numarası bulunamadı. Panelin Tag değerini kontrol edin.",
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Form anaModul = this.MdiParent;

            if (anaModul == null)
            {
                MessageBox.Show("Ana form bulunamadı.");
                return;
            }

            FrmSiparis frm = new FrmSiparis();

            frm.SecilenMasaID = masaID;
            frm.MdiParent = anaModul; 
            frm.Show();

            this.Hide();

        }

        
    }
}
