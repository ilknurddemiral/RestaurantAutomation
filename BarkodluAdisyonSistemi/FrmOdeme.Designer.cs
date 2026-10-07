namespace BarkodluAdisyonSistemi
{
    partial class FrmOdeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOdeme));
            this.lblBaslık = new DevExpress.XtraEditors.LabelControl();
            this.lblToplamTutar = new DevExpress.XtraEditors.LabelControl();
            this.lblToplamTutarDeger = new DevExpress.XtraEditors.LabelControl();
            this.lblOdemeTuru = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.btnOdeme = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.lblParaUstuDegeri = new DevExpress.XtraEditors.LabelControl();
            this.lblParaUstu = new DevExpress.XtraEditors.LabelControl();
            this.txtAlinanTutar = new System.Windows.Forms.TextBox();
            this.lblAlinanTutar = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslık
            // 
            this.lblBaslık.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslık.Appearance.Options.UseFont = true;
            this.lblBaslık.Location = new System.Drawing.Point(75, 40);
            this.lblBaslık.Name = "lblBaslık";
            this.lblBaslık.Size = new System.Drawing.Size(188, 33);
            this.lblBaslık.TabIndex = 0;
            this.lblBaslık.Text = "Hesap Ödeme";
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamTutar.Appearance.Options.UseFont = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(60, 124);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(113, 22);
            this.lblToplamTutar.TabIndex = 1;
            this.lblToplamTutar.Text = "Toplam Tutar:";
            // 
            // lblToplamTutarDeger
            // 
            this.lblToplamTutarDeger.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamTutarDeger.Appearance.Options.UseFont = true;
            this.lblToplamTutarDeger.Location = new System.Drawing.Point(203, 124);
            this.lblToplamTutarDeger.Name = "lblToplamTutarDeger";
            this.lblToplamTutarDeger.Size = new System.Drawing.Size(103, 22);
            this.lblToplamTutarDeger.TabIndex = 2;
            this.lblToplamTutarDeger.Text = "labelControl3";
            // 
            // lblOdemeTuru
            // 
            this.lblOdemeTuru.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdemeTuru.Appearance.Options.UseFont = true;
            this.lblOdemeTuru.Location = new System.Drawing.Point(60, 187);
            this.lblOdemeTuru.Name = "lblOdemeTuru";
            this.lblOdemeTuru.Size = new System.Drawing.Size(105, 22);
            this.lblOdemeTuru.TabIndex = 3;
            this.lblOdemeTuru.Text = "Ödeme Türü:";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cmbOdemeTuru);
            this.panelControl1.Controls.Add(this.btnOdeme);
            this.panelControl1.Controls.Add(this.btnIptal);
            this.panelControl1.Controls.Add(this.lblParaUstuDegeri);
            this.panelControl1.Controls.Add(this.lblParaUstu);
            this.panelControl1.Controls.Add(this.txtAlinanTutar);
            this.panelControl1.Controls.Add(this.lblAlinanTutar);
            this.panelControl1.Controls.Add(this.lblBaslık);
            this.panelControl1.Controls.Add(this.lblToplamTutar);
            this.panelControl1.Controls.Add(this.lblOdemeTuru);
            this.panelControl1.Controls.Add(this.lblToplamTutarDeger);
            this.panelControl1.Location = new System.Drawing.Point(405, 113);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(378, 436);
            this.panelControl1.TabIndex = 5;
            // 
            // cmbOdemeTuru
            // 
            this.cmbOdemeTuru.FormattingEnabled = true;
            this.cmbOdemeTuru.Location = new System.Drawing.Point(188, 189);
            this.cmbOdemeTuru.Name = "cmbOdemeTuru";
            this.cmbOdemeTuru.Size = new System.Drawing.Size(121, 24);
            this.cmbOdemeTuru.TabIndex = 6;
            // 
            // btnOdeme
            // 
            this.btnOdeme.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdeme.Appearance.Options.UseFont = true;
            this.btnOdeme.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOdeme.ImageOptions.Image")));
            this.btnOdeme.Location = new System.Drawing.Point(201, 343);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(128, 49);
            this.btnOdeme.TabIndex = 10;
            this.btnOdeme.Text = "Ödemeyi\r\nTamamla";
            this.btnOdeme.Click += new System.EventHandler(this.btnOdeme_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.ImageOptions.Image")));
            this.btnIptal.Location = new System.Drawing.Point(62, 343);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(111, 49);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İptal";
            // 
            // lblParaUstuDegeri
            // 
            this.lblParaUstuDegeri.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblParaUstuDegeri.Appearance.Options.UseFont = true;
            this.lblParaUstuDegeri.Location = new System.Drawing.Point(188, 282);
            this.lblParaUstuDegeri.Name = "lblParaUstuDegeri";
            this.lblParaUstuDegeri.Size = new System.Drawing.Size(128, 22);
            this.lblParaUstuDegeri.TabIndex = 8;
            this.lblParaUstuDegeri.Text = "para üstü değeri";
            // 
            // lblParaUstu
            // 
            this.lblParaUstu.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblParaUstu.Appearance.Options.UseFont = true;
            this.lblParaUstu.Location = new System.Drawing.Point(60, 282);
            this.lblParaUstu.Name = "lblParaUstu";
            this.lblParaUstu.Size = new System.Drawing.Size(82, 22);
            this.lblParaUstu.TabIndex = 7;
            this.lblParaUstu.Text = "Para Üstü:";
            // 
            // txtAlinanTutar
            // 
            this.txtAlinanTutar.Location = new System.Drawing.Point(188, 234);
            this.txtAlinanTutar.Name = "txtAlinanTutar";
            this.txtAlinanTutar.Size = new System.Drawing.Size(125, 23);
            this.txtAlinanTutar.TabIndex = 6;
            // 
            // lblAlinanTutar
            // 
            this.lblAlinanTutar.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAlinanTutar.Appearance.Options.UseFont = true;
            this.lblAlinanTutar.Location = new System.Drawing.Point(60, 235);
            this.lblAlinanTutar.Name = "lblAlinanTutar";
            this.lblAlinanTutar.Size = new System.Drawing.Size(102, 22);
            this.lblAlinanTutar.TabIndex = 5;
            this.lblAlinanTutar.Text = "Alınan Tutar:";
            // 
            // FrmOdeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmOdeme";
            this.Text = "FrmOdeme";
            this.Load += new System.EventHandler(this.FrmOdeme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBaslık;
        private DevExpress.XtraEditors.LabelControl lblToplamTutar;
        private DevExpress.XtraEditors.LabelControl lblToplamTutarDeger;
        private DevExpress.XtraEditors.LabelControl lblOdemeTuru;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txtAlinanTutar;
        private DevExpress.XtraEditors.LabelControl lblAlinanTutar;
        private DevExpress.XtraEditors.SimpleButton btnOdeme;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.LabelControl lblParaUstuDegeri;
        private DevExpress.XtraEditors.LabelControl lblParaUstu;
        private System.Windows.Forms.ComboBox cmbOdemeTuru;
    }
}