namespace BarkodluAdisyonSistemi
{
    partial class FrmSiparis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSiparis));
            this.gridControlUrunler = new DevExpress.XtraGrid.GridControl();
            this.gridViewUrunler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlSiparis = new DevExpress.XtraGrid.GridControl();
            this.gridViewSiparis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMasaAdi = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnArttır = new DevExpress.XtraEditors.SimpleButton();
            this.btnAzalt = new DevExpress.XtraEditors.SimpleButton();
            this.btnHesabiKapat = new DevExpress.XtraEditors.SimpleButton();
            this.txtToplamTutar = new DevExpress.XtraEditors.TextEdit();
            this.btnkaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSiparis)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplamTutar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlUrunler
            // 
            this.gridControlUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUrunler.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.gridControlUrunler.Location = new System.Drawing.Point(3, 47);
            this.gridControlUrunler.MainView = this.gridViewUrunler;
            this.gridControlUrunler.Name = "gridControlUrunler";
            this.gridControlUrunler.Size = new System.Drawing.Size(634, 414);
            this.gridControlUrunler.TabIndex = 1;
            this.gridControlUrunler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUrunler});
            this.gridControlUrunler.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridViewUrunler
            // 
            this.gridViewUrunler.GridControl = this.gridControlUrunler;
            this.gridViewUrunler.Name = "gridViewUrunler";
            this.gridViewUrunler.OptionsBehavior.Editable = false;
            this.gridViewUrunler.OptionsView.ShowGroupPanel = false;
            this.gridViewUrunler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewUrunler_RowClick);
            // 
            // gridControlSiparis
            // 
            this.gridControlSiparis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSiparis.Location = new System.Drawing.Point(643, 47);
            this.gridControlSiparis.MainView = this.gridViewSiparis;
            this.gridControlSiparis.Name = "gridControlSiparis";
            this.gridControlSiparis.Size = new System.Drawing.Size(636, 414);
            this.gridControlSiparis.TabIndex = 2;
            this.gridControlSiparis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSiparis});
            // 
            // gridViewSiparis
            // 
            this.gridViewSiparis.GridControl = this.gridControlSiparis;
            this.gridViewSiparis.Name = "gridViewSiparis";
            this.gridViewSiparis.OptionsBehavior.Editable = false;
            this.gridViewSiparis.OptionsView.ShowGroupPanel = false;
            this.gridViewSiparis.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewSiparis_RowClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.922F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.078F));
            this.tableLayoutPanel1.Controls.Add(this.lblMasaAdi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gridControlUrunler, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gridControlSiparis, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.567198F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.4328F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1282, 653);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // lblMasaAdi
            // 
            this.lblMasaAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMasaAdi.Appearance.Options.UseFont = true;
            this.lblMasaAdi.Appearance.Options.UseTextOptions = true;
            this.lblMasaAdi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblMasaAdi.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMasaAdi, 2);
            this.lblMasaAdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMasaAdi.Location = new System.Drawing.Point(3, 3);
            this.lblMasaAdi.Name = "lblMasaAdi";
            this.lblMasaAdi.Size = new System.Drawing.Size(1276, 38);
            this.lblMasaAdi.TabIndex = 11;
            this.lblMasaAdi.Text = "Masa 1";
            // 
            // panelControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelControl1, 2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.btnEkle);
            this.panelControl1.Controls.Add(this.btnArttır);
            this.panelControl1.Controls.Add(this.btnAzalt);
            this.panelControl1.Controls.Add(this.btnHesabiKapat);
            this.panelControl1.Controls.Add(this.txtToplamTutar);
            this.panelControl1.Controls.Add(this.btnkaydet);
            this.panelControl1.Controls.Add(this.btnSil);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 467);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1276, 183);
            this.panelControl1.TabIndex = 10;
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Appearance.Options.UseFont = true;
            this.btnEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.ImageOptions.Image")));
            this.btnEkle.Location = new System.Drawing.Point(430, 7);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 35);
            this.btnEkle.TabIndex = 15;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnArttır
            // 
            this.btnArttır.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnArttır.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArttır.Appearance.Options.UseFont = true;
            this.btnArttır.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnArttır.ImageOptions.Image")));
            this.btnArttır.Location = new System.Drawing.Point(642, 7);
            this.btnArttır.Name = "btnArttır";
            this.btnArttır.Size = new System.Drawing.Size(100, 35);
            this.btnArttır.TabIndex = 9;
            this.btnArttır.Text = "Arttır";
            this.btnArttır.Click += new System.EventHandler(this.btnArtir_Click);
            // 
            // btnAzalt
            // 
            this.btnAzalt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAzalt.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAzalt.Appearance.Options.UseFont = true;
            this.btnAzalt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAzalt.ImageOptions.Image")));
            this.btnAzalt.Location = new System.Drawing.Point(748, 7);
            this.btnAzalt.Name = "btnAzalt";
            this.btnAzalt.Size = new System.Drawing.Size(100, 35);
            this.btnAzalt.TabIndex = 10;
            this.btnAzalt.Text = "Azalt";
            this.btnAzalt.Click += new System.EventHandler(this.btnAzalt_Click);
            // 
            // btnHesabiKapat
            // 
            this.btnHesabiKapat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHesabiKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesabiKapat.Appearance.Options.UseFont = true;
            this.btnHesabiKapat.Location = new System.Drawing.Point(563, 145);
            this.btnHesabiKapat.Name = "btnHesabiKapat";
            this.btnHesabiKapat.Size = new System.Drawing.Size(152, 29);
            this.btnHesabiKapat.TabIndex = 13;
            this.btnHesabiKapat.Text = "Hesabı Kapat";
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtToplamTutar.Enabled = false;
            this.txtToplamTutar.Location = new System.Drawing.Point(470, 58);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtToplamTutar.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtToplamTutar.Properties.Appearance.Options.UseFont = true;
            this.txtToplamTutar.Properties.Appearance.Options.UseForeColor = true;
            this.txtToplamTutar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtToplamTutar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtToplamTutar.Properties.AutoHeight = false;
            this.txtToplamTutar.Properties.ReadOnly = true;
            this.txtToplamTutar.Size = new System.Drawing.Size(340, 25);
            this.txtToplamTutar.TabIndex = 14;
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnkaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.Appearance.Options.UseFont = true;
            this.btnkaydet.Location = new System.Drawing.Point(470, 98);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(152, 29);
            this.btnkaydet.TabIndex = 12;
            this.btnkaydet.Text = "Siparişi Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(536, 7);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 35);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(640, 98);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(152, 29);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "Masalara Dön";
            this.simpleButton1.Click += new System.EventHandler(this.btnMasalaraDon_Click);
            // 
            // FrmSiparis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSiparis";
            this.Text = "SİPARİŞ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSiparis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSiparis)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtToplamTutar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControlUrunler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUrunler;
        private DevExpress.XtraGrid.GridControl gridControlSiparis;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSiparis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblMasaAdi;
        private DevExpress.XtraEditors.SimpleButton btnArttır;
        private DevExpress.XtraEditors.SimpleButton btnAzalt;
        private DevExpress.XtraEditors.SimpleButton btnHesabiKapat;
        private DevExpress.XtraEditors.TextEdit txtToplamTutar;
        private DevExpress.XtraEditors.SimpleButton btnkaydet;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}