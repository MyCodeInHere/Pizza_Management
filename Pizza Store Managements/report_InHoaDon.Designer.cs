namespace Pizza_Store_Managements
{
    partial class report_InHoaDon
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
            this.components = new System.ComponentModel.Container();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_InHoaDon = new System.Windows.Forms.Button();
            this.cmb_InHoaDon = new System.Windows.Forms.ComboBox();
            this.epd_InHoaDon = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_TroVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epd_InHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1924, 1050);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // btn_InHoaDon
            // 
            this.btn_InHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_InHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_InHoaDon.Font = new System.Drawing.Font("SFU Stafford", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_InHoaDon.Location = new System.Drawing.Point(218, 187);
            this.btn_InHoaDon.Name = "btn_InHoaDon";
            this.btn_InHoaDon.Size = new System.Drawing.Size(202, 62);
            this.btn_InHoaDon.TabIndex = 1;
            this.btn_InHoaDon.Text = "In Hóa Đơn";
            this.btn_InHoaDon.UseVisualStyleBackColor = false;
            this.btn_InHoaDon.Click += new System.EventHandler(this.btn_InHoaDon_Click);
            // 
            // cmb_InHoaDon
            // 
            this.cmb_InHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_InHoaDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_InHoaDon.FormattingEnabled = true;
            this.cmb_InHoaDon.Location = new System.Drawing.Point(218, 118);
            this.cmb_InHoaDon.Name = "cmb_InHoaDon";
            this.cmb_InHoaDon.Size = new System.Drawing.Size(202, 28);
            this.cmb_InHoaDon.TabIndex = 2;
            this.cmb_InHoaDon.SelectedIndexChanged += new System.EventHandler(this.cmb_InHoaDon_SelectedIndexChanged);
            this.cmb_InHoaDon.SelectedValueChanged += new System.EventHandler(this.cmb_InHoaDon_SelectedValueChanged);
            // 
            // epd_InHoaDon
            // 
            this.epd_InHoaDon.ContainerControl = this;
            // 
            // btn_TroVe
            // 
            this.btn_TroVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_TroVe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TroVe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_TroVe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_TroVe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_TroVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TroVe.Font = new System.Drawing.Font("SFU Stafford", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TroVe.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_TroVe.Location = new System.Drawing.Point(23, 61);
            this.btn_TroVe.Name = "btn_TroVe";
            this.btn_TroVe.Size = new System.Drawing.Size(135, 52);
            this.btn_TroVe.TabIndex = 3;
            this.btn_TroVe.Text = "Trở về";
            this.btn_TroVe.UseVisualStyleBackColor = false;
            this.btn_TroVe.Click += new System.EventHandler(this.btn_TroVe_Click);
            // 
            // report_InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btn_TroVe);
            this.Controls.Add(this.cmb_InHoaDon);
            this.Controls.Add(this.btn_InHoaDon);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "report_InHoaDon";
            this.Text = "IN HÓA ĐƠN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.report_InHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epd_InHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btn_InHoaDon;
        private System.Windows.Forms.ComboBox cmb_InHoaDon;
        private System.Windows.Forms.ErrorProvider epd_InHoaDon;
        private System.Windows.Forms.Button btn_TroVe;
    }
}