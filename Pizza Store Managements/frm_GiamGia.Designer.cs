namespace Pizza_Store_Managements
{
    partial class frm_GiamGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GiamGia));
            this.lab_GiamGiaHoaDon = new System.Windows.Forms.Label();
            this.dgv_GiamGia = new System.Windows.Forms.DataGridView();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.btn_XoaMucGiamGia = new System.Windows.Forms.Button();
            this.txt_ThemGiamGia = new System.Windows.Forms.Button();
            this.lab_MaGiamGia = new System.Windows.Forms.Label();
            this.txt_MaGiamGia = new System.Windows.Forms.TextBox();
            this.lab_NgayGiamGia = new System.Windows.Forms.Label();
            this.cmb_NgayGiamGia = new System.Windows.Forms.ComboBox();
            this.lab_MucGiamGia = new System.Windows.Forms.Label();
            this.txt_MucGiamGia = new System.Windows.Forms.TextBox();
            this.btn_TroVe = new System.Windows.Forms.Button();
            this.btn_XoaThongTin = new System.Windows.Forms.Button();
            this.epd_NgayGiamGia = new System.Windows.Forms.ErrorProvider(this.components);
            this.epd_MucGiamGia = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_NgayGiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_MucGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_GiamGiaHoaDon
            // 
            this.lab_GiamGiaHoaDon.AutoSize = true;
            this.lab_GiamGiaHoaDon.Font = new System.Drawing.Font("SFU Stafford", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_GiamGiaHoaDon.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_GiamGiaHoaDon.Location = new System.Drawing.Point(682, 123);
            this.lab_GiamGiaHoaDon.Name = "lab_GiamGiaHoaDon";
            this.lab_GiamGiaHoaDon.Size = new System.Drawing.Size(554, 75);
            this.lab_GiamGiaHoaDon.TabIndex = 3;
            this.lab_GiamGiaHoaDon.Text = "Giảm Giá Hóa Đơn ";
            // 
            // dgv_GiamGia
            // 
            this.dgv_GiamGia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgv_GiamGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GiamGia.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.dgv_GiamGia.GridColor = System.Drawing.Color.Yellow;
            this.dgv_GiamGia.Location = new System.Drawing.Point(319, 280);
            this.dgv_GiamGia.Name = "dgv_GiamGia";
            this.dgv_GiamGia.RowHeadersWidth = 62;
            this.dgv_GiamGia.RowTemplate.Height = 28;
            this.dgv_GiamGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GiamGia.Size = new System.Drawing.Size(1286, 491);
            this.dgv_GiamGia.TabIndex = 4;
            this.dgv_GiamGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_GiamGia_CellClick);
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_CapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CapNhat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_CapNhat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_CapNhat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_CapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CapNhat.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhat.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_CapNhat.Location = new System.Drawing.Point(687, 921);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(168, 56);
            this.btn_CapNhat.TabIndex = 15;
            this.btn_CapNhat.Text = "Cập Nhật";
            this.btn_CapNhat.UseVisualStyleBackColor = false;
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // btn_XoaMucGiamGia
            // 
            this.btn_XoaMucGiamGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaMucGiamGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XoaMucGiamGia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaMucGiamGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_XoaMucGiamGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaMucGiamGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaMucGiamGia.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaMucGiamGia.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_XoaMucGiamGia.Location = new System.Drawing.Point(935, 921);
            this.btn_XoaMucGiamGia.Name = "btn_XoaMucGiamGia";
            this.btn_XoaMucGiamGia.Size = new System.Drawing.Size(288, 56);
            this.btn_XoaMucGiamGia.TabIndex = 14;
            this.btn_XoaMucGiamGia.Text = "Xóa Mức Giảm Giá";
            this.btn_XoaMucGiamGia.UseVisualStyleBackColor = false;
            this.btn_XoaMucGiamGia.Click += new System.EventHandler(this.btn_XoaMucGiamGia_Click);
            // 
            // txt_ThemGiamGia
            // 
            this.txt_ThemGiamGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_ThemGiamGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txt_ThemGiamGia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.txt_ThemGiamGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_ThemGiamGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_ThemGiamGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_ThemGiamGia.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ThemGiamGia.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_ThemGiamGia.Location = new System.Drawing.Point(342, 921);
            this.txt_ThemGiamGia.Name = "txt_ThemGiamGia";
            this.txt_ThemGiamGia.Size = new System.Drawing.Size(265, 56);
            this.txt_ThemGiamGia.TabIndex = 13;
            this.txt_ThemGiamGia.Text = "Thêm Giảm Giá";
            this.txt_ThemGiamGia.UseVisualStyleBackColor = false;
            this.txt_ThemGiamGia.Click += new System.EventHandler(this.txt_ThemGiamGia_Click);
            // 
            // lab_MaGiamGia
            // 
            this.lab_MaGiamGia.AutoSize = true;
            this.lab_MaGiamGia.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MaGiamGia.ForeColor = System.Drawing.Color.ForestGreen;
            this.lab_MaGiamGia.Location = new System.Drawing.Point(280, 825);
            this.lab_MaGiamGia.Name = "lab_MaGiamGia";
            this.lab_MaGiamGia.Size = new System.Drawing.Size(189, 29);
            this.lab_MaGiamGia.TabIndex = 16;
            this.lab_MaGiamGia.Text = "Mã Giảm Giá:";
            // 
            // txt_MaGiamGia
            // 
            this.txt_MaGiamGia.Enabled = false;
            this.txt_MaGiamGia.Location = new System.Drawing.Point(475, 828);
            this.txt_MaGiamGia.Name = "txt_MaGiamGia";
            this.txt_MaGiamGia.Size = new System.Drawing.Size(162, 26);
            this.txt_MaGiamGia.TabIndex = 17;
            // 
            // lab_NgayGiamGia
            // 
            this.lab_NgayGiamGia.AutoSize = true;
            this.lab_NgayGiamGia.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_NgayGiamGia.ForeColor = System.Drawing.Color.SeaGreen;
            this.lab_NgayGiamGia.Location = new System.Drawing.Point(707, 825);
            this.lab_NgayGiamGia.Name = "lab_NgayGiamGia";
            this.lab_NgayGiamGia.Size = new System.Drawing.Size(219, 29);
            this.lab_NgayGiamGia.TabIndex = 18;
            this.lab_NgayGiamGia.Text = "Ngày Giảm Giá:";
            // 
            // cmb_NgayGiamGia
            // 
            this.cmb_NgayGiamGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NgayGiamGia.FormattingEnabled = true;
            this.cmb_NgayGiamGia.Items.AddRange(new object[] {
            "Thứ Hai",
            "Thứ Ba",
            "Thứ Tư",
            "Thứ Năm",
            "Thứ Sáu",
            "Thứ Bảy",
            "Chủ Nhật"});
            this.cmb_NgayGiamGia.Location = new System.Drawing.Point(932, 826);
            this.cmb_NgayGiamGia.Name = "cmb_NgayGiamGia";
            this.cmb_NgayGiamGia.Size = new System.Drawing.Size(234, 28);
            this.cmb_NgayGiamGia.TabIndex = 19;
            // 
            // lab_MucGiamGia
            // 
            this.lab_MucGiamGia.AutoSize = true;
            this.lab_MucGiamGia.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MucGiamGia.ForeColor = System.Drawing.Color.ForestGreen;
            this.lab_MucGiamGia.Location = new System.Drawing.Point(1245, 825);
            this.lab_MucGiamGia.Name = "lab_MucGiamGia";
            this.lab_MucGiamGia.Size = new System.Drawing.Size(205, 29);
            this.lab_MucGiamGia.TabIndex = 20;
            this.lab_MucGiamGia.Text = "Mức Giảm Giá:";
            // 
            // txt_MucGiamGia
            // 
            this.txt_MucGiamGia.Location = new System.Drawing.Point(1456, 828);
            this.txt_MucGiamGia.Name = "txt_MucGiamGia";
            this.txt_MucGiamGia.Size = new System.Drawing.Size(180, 26);
            this.txt_MucGiamGia.TabIndex = 21;
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
            this.btn_TroVe.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_TroVe.Location = new System.Drawing.Point(43, 33);
            this.btn_TroVe.Name = "btn_TroVe";
            this.btn_TroVe.Size = new System.Drawing.Size(135, 53);
            this.btn_TroVe.TabIndex = 22;
            this.btn_TroVe.Text = "Trở về";
            this.btn_TroVe.UseVisualStyleBackColor = false;
            this.btn_TroVe.Click += new System.EventHandler(this.btn_TroVe_Click);
            // 
            // btn_XoaThongTin
            // 
            this.btn_XoaThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XoaThongTin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaThongTin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_XoaThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaThongTin.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaThongTin.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_XoaThongTin.Location = new System.Drawing.Point(1303, 921);
            this.btn_XoaThongTin.Name = "btn_XoaThongTin";
            this.btn_XoaThongTin.Size = new System.Drawing.Size(268, 56);
            this.btn_XoaThongTin.TabIndex = 23;
            this.btn_XoaThongTin.Text = "Xóa Thông Tin";
            this.btn_XoaThongTin.UseVisualStyleBackColor = false;
            this.btn_XoaThongTin.Click += new System.EventHandler(this.btn_XoaThongTin_Click);
            // 
            // epd_NgayGiamGia
            // 
            this.epd_NgayGiamGia.ContainerControl = this;
            // 
            // epd_MucGiamGia
            // 
            this.epd_MucGiamGia.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1600, 829);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "%";
            // 
            // frm_GiamGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_XoaThongTin);
            this.Controls.Add(this.btn_TroVe);
            this.Controls.Add(this.txt_MucGiamGia);
            this.Controls.Add(this.lab_MucGiamGia);
            this.Controls.Add(this.cmb_NgayGiamGia);
            this.Controls.Add(this.lab_NgayGiamGia);
            this.Controls.Add(this.txt_MaGiamGia);
            this.Controls.Add(this.lab_MaGiamGia);
            this.Controls.Add(this.btn_CapNhat);
            this.Controls.Add(this.btn_XoaMucGiamGia);
            this.Controls.Add(this.txt_ThemGiamGia);
            this.Controls.Add(this.dgv_GiamGia);
            this.Controls.Add(this.lab_GiamGiaHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_GiamGia";
            this.Text = "Giảm Giá Hóa Đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_GiamGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_NgayGiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_MucGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_GiamGiaHoaDon;
        private System.Windows.Forms.DataGridView dgv_GiamGia;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_XoaMucGiamGia;
        private System.Windows.Forms.Button txt_ThemGiamGia;
        private System.Windows.Forms.Label lab_MaGiamGia;
        private System.Windows.Forms.TextBox txt_MaGiamGia;
        private System.Windows.Forms.Label lab_NgayGiamGia;
        private System.Windows.Forms.ComboBox cmb_NgayGiamGia;
        private System.Windows.Forms.Label lab_MucGiamGia;
        private System.Windows.Forms.TextBox txt_MucGiamGia;
        private System.Windows.Forms.Button btn_TroVe;
        private System.Windows.Forms.Button btn_XoaThongTin;
        private System.Windows.Forms.ErrorProvider epd_NgayGiamGia;
        private System.Windows.Forms.ErrorProvider epd_MucGiamGia;
        private System.Windows.Forms.Label label1;
    }
}