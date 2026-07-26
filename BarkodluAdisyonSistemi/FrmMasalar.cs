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
            SqlCommand komut = new SqlCommand(
                "Select MasaID, Durum From TBL_MASALAR",
                bgl.baglanti());

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["MasaID"]);
                bool durum = Convert.ToBoolean(dr["Durum"]);

                PanelControl panel =
                    this.Controls.Find("pnlMasa" + id, true).FirstOrDefault() as PanelControl;

                LabelControl lblDurum =
                    this.Controls.Find("lblDurum" + id, true).FirstOrDefault() as LabelControl;

                if ( panel != null)
                {
                    if (durum)
                    {
                        panel.Appearance.BackColor = Color.IndianRed;

                        if (lblDurum != null)
                        {
                            lblDurum.Text = "DOLU";
                            lblDurum.Appearance.ForeColor = Color.DarkRed;
                        }
                    }

                    else
                    {
                        panel.Appearance.BackColor = Color.LightGreen;

                        if (lblDurum != null)
                        {
                            lblDurum.Text = "BOŞ";
                            lblDurum.Appearance.ForeColor = Color.DarkGreen;
                        }
                    }
                       

                    panel.Appearance.Options.UseBackColor = true;

                    if(lblDurum != null)
                    {
                        lblDurum.Appearance.Options.UseForeColor = true;
                    }

                }
            }
            dr.Close();
            bgl.baglanti().Close();

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

            Form anaForm = this.MdiParent;

            if (anaForm == null)
            {
                MessageBox.Show("Ana form bulunamadı.");
                return;
            }

            FrmSiparis frm = new FrmSiparis();

            frm.SecilenMasaID = masaID;
            frm.MdiParent = anaForm; 
            frm.Show();

            this.Hide();

        }

        
    }
}
