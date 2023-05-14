namespace Pizza_Store_Managements
{
    partial class frm_QuanLyLoaiSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_QuanLyLoaiSanPham));
            this.lab_QuanLyLoaiSanPham = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgv_QuanLyLoaiSanPham = new System.Windows.Forms.DataGridView();
            this.gb_TimKiem = new System.Windows.Forms.GroupBox();
            this.rb_TenLoaiSanPham = new System.Windows.Forms.RadioButton();
            this.rb_DonViTinh = new System.Windows.Forms.RadioButton();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.lab_TimKiem = new System.Windows.Forms.Label();
            this.btn_CapNhatLoaiSanPham = new System.Windows.Forms.Button();
            this.btn_XoaLoaiSanPham = new System.Windows.Forms.Button();
            this.txt_ThemLoaiSanPham = new System.Windows.Forms.Button();
            this.lab_TenLoaiSanPham = new System.Windows.Forms.Label();
            this.lab_DonViTinh = new System.Windows.Forms.Label();
            this.txt_TenLoaiSanPham = new System.Windows.Forms.TextBox();
            this.cmb_DonViTinh = new System.Windows.Forms.ComboBox();
            this.lab_SoLuong = new System.Windows.Forms.Label();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.epd_TenLoaiSanPham = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_XoaThongTin = new System.Windows.Forms.Button();
            this.epd_DonViTinh = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_TroVe = new System.Windows.Forms.Button();
            this.btn_TaiLai = new System.Windows.Forms.Button();
            this.lab_MaLoaiSanPham = new System.Windows.Forms.Label();
            this.txt_MaLoaiSanPham = new System.Windows.Forms.TextBox();
            this.lab_TongSoLoai = new System.Windows.Forms.Label();
            this.txt_TongSoLoai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuanLyLoaiSanPham)).BeginInit();
            this.gb_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epd_TenLoaiSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_DonViTinh)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_QuanLyLoaiSanPham
            // 
            this.lab_QuanLyLoaiSanPham.AutoSize = true;
            this.lab_QuanLyLoaiSanPham.Font = new System.Drawing.Font("SFU Stafford", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QuanLyLoaiSanPham.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_QuanLyLoaiSanPham.Location = new System.Drawing.Point(674, 124);
            this.lab_QuanLyLoaiSanPham.Name = "lab_QuanLyLoaiSanPham";
            this.lab_QuanLyLoaiSanPham.Size = new System.Drawing.Size(687, 75);
            this.lab_QuanLyLoaiSanPham.TabIndex = 4;
            this.lab_QuanLyLoaiSanPham.Text = "Quản Lý Loại Sản Phẩm";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(419, 68);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(249, 191);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // dgv_QuanLyLoaiSanPham
            // 
            this.dgv_QuanLyLoaiSanPham.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgv_QuanLyLoaiSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QuanLyLoaiSanPham.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.dgv_QuanLyLoaiSanPham.GridColor = System.Drawing.Color.Yellow;
            this.dgv_QuanLyLoaiSanPham.Location = new System.Drawing.Point(315, 437);
            this.dgv_QuanLyLoaiSanPham.Name = "dgv_QuanLyLoaiSanPham";
            this.dgv_QuanLyLoaiSanPham.RowHeadersWidth = 62;
            this.dgv_QuanLyLoaiSanPham.RowTemplate.Height = 28;
            this.dgv_QuanLyLoaiSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_QuanLyLoaiSanPham.Size = new System.Drawing.Size(1286, 491);
            this.dgv_QuanLyLoaiSanPham.TabIndex = 5;
            this.dgv_QuanLyLoaiSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QuanLyLoaiSanPham_CellClick);
            // 
            // gb_TimKiem
            // 
            this.gb_TimKiem.Controls.Add(this.rb_TenLoaiSanPham);
            this.gb_TimKiem.Controls.Add(this.rb_DonViTinh);
            this.gb_TimKiem.Location = new System.Drawing.Point(315, 362);
            this.gb_TimKiem.Name = "gb_TimKiem";
            this.gb_TimKiem.Size = new System.Drawing.Size(353, 51);
            this.gb_TimKiem.TabIndex = 140;
            this.gb_TimKiem.TabStop = false;
            // 
            // rb_TenLoaiSanPham
            // 
            this.rb_TenLoaiSanPham.AutoSize = true;
            this.rb_TenLoaiSanPham.Font = new System.Drawing.Font("SFU AmericanType", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_TenLoaiSanPham.ForeColor = System.Drawing.Color.SeaGreen;
            this.rb_TenLoaiSanPham.Location = new System.Drawing.Point(12, 16);
            this.rb_TenLoaiSanPham.Name = "rb_TenLoaiSanPham";
            this.rb_TenLoaiSanPham.Size = new System.Drawing.Size(193, 26);
            this.rb_TenLoaiSanPham.TabIndex = 20;
            this.rb_TenLoaiSanPham.TabStop = true;
            this.rb_TenLoaiSanPham.Text = "Tên Loại Sản Phẩm";
            this.rb_TenLoaiSanPham.UseVisualStyleBackColor = true;
            this.rb_TenLoaiSanPham.CheckedChanged += new System.EventHandler(this.rb_MaSanPham_CheckedChanged);
            // 
            // rb_DonViTinh
            // 
            this.rb_DonViTinh.AutoSize = true;
            this.rb_DonViTinh.Font = new System.Drawing.Font("SFU AmericanType", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_DonViTinh.ForeColor = System.Drawing.Color.SeaGreen;
            this.rb_DonViTinh.Location = new System.Drawing.Point(214, 17);
            this.rb_DonViTinh.Name = "rb_DonViTinh";
            this.rb_DonViTinh.Size = new System.Drawing.Size(133, 26);
            this.rb_DonViTinh.TabIndex = 135;
            this.rb_DonViTinh.TabStop = true;
            this.rb_DonViTinh.Text = "Đơn Vị Tính";
            this.rb_DonViTinh.UseVisualStyleBackColor = true;
            this.rb_DonViTinh.CheckedChanged += new System.EventHandler(this.rb_DonViTinh_CheckedChanged);
            // 
            // btn_Tim
            // 
            this.btn_Tim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Tim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Tim.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Tim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Tim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tim.Font = new System.Drawing.Font("SFU Stafford", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_Tim.Location = new System.Drawing.Point(674, 318);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(72, 50);
            this.btn_Tim.TabIndex = 139;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = false;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(472, 332);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(196, 26);
            this.txt_TimKiem.TabIndex = 138;
            // 
            // lab_TimKiem
            // 
            this.lab_TimKiem.AutoSize = true;
            this.lab_TimKiem.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TimKiem.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_TimKiem.Location = new System.Drawing.Point(320, 324);
            this.lab_TimKiem.Name = "lab_TimKiem";
            this.lab_TimKiem.Size = new System.Drawing.Size(146, 35);
            this.lab_TimKiem.TabIndex = 137;
            this.lab_TimKiem.Text = "Tìm Kiếm:";
            // 
            // btn_CapNhatLoaiSanPham
            // 
            this.btn_CapNhatLoaiSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_CapNhatLoaiSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CapNhatLoaiSanPham.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_CapNhatLoaiSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_CapNhatLoaiSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_CapNhatLoaiSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CapNhatLoaiSanPham.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhatLoaiSanPham.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_CapNhatLoaiSanPham.Location = new System.Drawing.Point(783, 959);
            this.btn_CapNhatLoaiSanPham.Name = "btn_CapNhatLoaiSanPham";
            this.btn_CapNhatLoaiSanPham.Size = new System.Drawing.Size(373, 56);
            this.btn_CapNhatLoaiSanPham.TabIndex = 143;
            this.btn_CapNhatLoaiSanPham.Text = "Cập Nhật Loại Sản Phẩm";
            this.btn_CapNhatLoaiSanPham.UseVisualStyleBackColor = false;
            this.btn_CapNhatLoaiSanPham.Click += new System.EventHandler(this.btn_CapNhatLoaiSanPham_Click);
            // 
            // btn_XoaLoaiSanPham
            // 
            this.btn_XoaLoaiSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaLoaiSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XoaLoaiSanPham.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaLoaiSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_XoaLoaiSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaLoaiSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaLoaiSanPham.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaLoaiSanPham.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_XoaLoaiSanPham.Location = new System.Drawing.Point(1224, 959);
            this.btn_XoaLoaiSanPham.Name = "btn_XoaLoaiSanPham";
            this.btn_XoaLoaiSanPham.Size = new System.Drawing.Size(308, 56);
            this.btn_XoaLoaiSanPham.TabIndex = 142;
            this.btn_XoaLoaiSanPham.Text = "Xóa Loại Sản Phẩm";
            this.btn_XoaLoaiSanPham.UseVisualStyleBackColor = false;
            this.btn_XoaLoaiSanPham.Click += new System.EventHandler(this.btn_XoaLoaiSanPham_Click);
            // 
            // txt_ThemLoaiSanPham
            // 
            this.txt_ThemLoaiSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_ThemLoaiSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txt_ThemLoaiSanPham.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.txt_ThemLoaiSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_ThemLoaiSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_ThemLoaiSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_ThemLoaiSanPham.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ThemLoaiSanPham.ForeColor = System.Drawing.Color.Firebrick;
            this.txt_ThemLoaiSanPham.Location = new System.Drawing.Point(397, 959);
            this.txt_ThemLoaiSanPham.Name = "txt_ThemLoaiSanPham";
            this.txt_ThemLoaiSanPham.Size = new System.Drawing.Size(318, 56);
            this.txt_ThemLoaiSanPham.TabIndex = 141;
            this.txt_ThemLoaiSanPham.Text = "Thêm Loại Sản Phẩm";
            this.txt_ThemLoaiSanPham.UseVisualStyleBackColor = false;
            this.txt_ThemLoaiSanPham.Click += new System.EventHandler(this.txt_ThemLoaiSanPham_Click);
            // 
            // lab_TenLoaiSanPham
            // 
            this.lab_TenLoaiSanPham.AutoSize = true;
            this.lab_TenLoaiSanPham.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TenLoaiSanPham.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_TenLoaiSanPham.Location = new System.Drawing.Point(793, 329);
            this.lab_TenLoaiSanPham.Name = "lab_TenLoaiSanPham";
            this.lab_TenLoaiSanPham.Size = new System.Drawing.Size(269, 35);
            this.lab_TenLoaiSanPham.TabIndex = 144;
            this.lab_TenLoaiSanPham.Text = "Tên Loại Sản Phẩm:";
            // 
            // lab_DonViTinh
            // 
            this.lab_DonViTinh.AutoSize = true;
            this.lab_DonViTinh.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_DonViTinh.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_DonViTinh.Location = new System.Drawing.Point(793, 376);
            this.lab_DonViTinh.Name = "lab_DonViTinh";
            this.lab_DonViTinh.Size = new System.Drawing.Size(172, 35);
            this.lab_DonViTinh.TabIndex = 145;
            this.lab_DonViTinh.Text = "Đơn Vị Tính:";
            // 
            // txt_TenLoaiSanPham
            // 
            this.txt_TenLoaiSanPham.Location = new System.Drawing.Point(1068, 338);
            this.txt_TenLoaiSanPham.Name = "txt_TenLoaiSanPham";
            this.txt_TenLoaiSanPham.Size = new System.Drawing.Size(268, 26);
            this.txt_TenLoaiSanPham.TabIndex = 146;
            // 
            // cmb_DonViTinh
            // 
            this.cmb_DonViTinh.FormattingEnabled = true;
            this.cmb_DonViTinh.Items.AddRange(new object[] {
            "Cái",
            "Lon"});
            this.cmb_DonViTinh.Location = new System.Drawing.Point(1068, 383);
            this.cmb_DonViTinh.Name = "cmb_DonViTinh";
            this.cmb_DonViTinh.Size = new System.Drawing.Size(268, 28);
            this.cmb_DonViTinh.TabIndex = 147;
            // 
            // lab_SoLuong
            // 
            this.lab_SoLuong.AutoSize = true;
            this.lab_SoLuong.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_SoLuong.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_SoLuong.Location = new System.Drawing.Point(1356, 305);
            this.lab_SoLuong.Name = "lab_SoLuong";
            this.lab_SoLuong.Size = new System.Drawing.Size(140, 35);
            this.lab_SoLuong.TabIndex = 148;
            this.lab_SoLuong.Text = "Số Lượng:";
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Enabled = false;
            this.txt_SoLuong.Location = new System.Drawing.Point(1497, 313);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(80, 26);
            this.txt_SoLuong.TabIndex = 149;
            // 
            // epd_TenLoaiSanPham
            // 
            this.epd_TenLoaiSanPham.ContainerControl = this;
            // 
            // btn_XoaThongTin
            // 
            this.btn_XoaThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_XoaThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XoaThongTin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaThongTin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_XoaThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_XoaThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaThongTin.Font = new System.Drawing.Font("SFU Stafford", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaThongTin.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_XoaThongTin.Location = new System.Drawing.Point(1360, 359);
            this.btn_XoaThongTin.Name = "btn_XoaThongTin";
            this.btn_XoaThongTin.Size = new System.Drawing.Size(217, 50);
            this.btn_XoaThongTin.TabIndex = 150;
            this.btn_XoaThongTin.Text = "Xóa Thông Tin";
            this.btn_XoaThongTin.UseVisualStyleBackColor = false;
            this.btn_XoaThongTin.Click += new System.EventHandler(this.btn_XoaThongTin_Click);
            // 
            // epd_DonViTinh
            // 
            this.epd_DonViTinh.ContainerControl = this;
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
            this.btn_TroVe.Location = new System.Drawing.Point(36, 33);
            this.btn_TroVe.Name = "btn_TroVe";
            this.btn_TroVe.Size = new System.Drawing.Size(135, 53);
            this.btn_TroVe.TabIndex = 151;
            this.btn_TroVe.Text = "Trở về";
            this.btn_TroVe.UseVisualStyleBackColor = false;
            this.btn_TroVe.Click += new System.EventHandler(this.btn_TroVe_Click);
            // 
            // btn_TaiLai
            // 
            this.btn_TaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_TaiLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TaiLai.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_TaiLai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_TaiLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_TaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TaiLai.Font = new System.Drawing.Font("SFU Stafford", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaiLai.ForeColor = System.Drawing.Color.Firebrick;
            this.btn_TaiLai.Location = new System.Drawing.Point(1489, 437);
            this.btn_TaiLai.Name = "btn_TaiLai";
            this.btn_TaiLai.Size = new System.Drawing.Size(112, 50);
            this.btn_TaiLai.TabIndex = 152;
            this.btn_TaiLai.Text = "Tải Lại";
            this.btn_TaiLai.UseVisualStyleBackColor = false;
            this.btn_TaiLai.Click += new System.EventHandler(this.btn_TaiLai_Click);
            // 
            // lab_MaLoaiSanPham
            // 
            this.lab_MaLoaiSanPham.AutoSize = true;
            this.lab_MaLoaiSanPham.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MaLoaiSanPham.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_MaLoaiSanPham.Location = new System.Drawing.Point(793, 281);
            this.lab_MaLoaiSanPham.Name = "lab_MaLoaiSanPham";
            this.lab_MaLoaiSanPham.Size = new System.Drawing.Size(261, 35);
            this.lab_MaLoaiSanPham.TabIndex = 153;
            this.lab_MaLoaiSanPham.Text = "Mã Loại Sản Phẩm:";
            // 
            // txt_MaLoaiSanPham
            // 
            this.txt_MaLoaiSanPham.Enabled = false;
            this.txt_MaLoaiSanPham.Location = new System.Drawing.Point(1068, 290);
            this.txt_MaLoaiSanPham.Name = "txt_MaLoaiSanPham";
            this.txt_MaLoaiSanPham.Size = new System.Drawing.Size(268, 26);
            this.txt_MaLoaiSanPham.TabIndex = 154;
            // 
            // lab_TongSoLoai
            // 
            this.lab_TongSoLoai.AutoSize = true;
            this.lab_TongSoLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lab_TongSoLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_TongSoLoai.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TongSoLoai.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_TongSoLoai.Location = new System.Drawing.Point(316, 890);
            this.lab_TongSoLoai.Name = "lab_TongSoLoai";
            this.lab_TongSoLoai.Size = new System.Drawing.Size(187, 37);
            this.lab_TongSoLoai.TabIndex = 155;
            this.lab_TongSoLoai.Text = "Tổng số soại:";
            // 
            // txt_TongSoLoai
            // 
            this.txt_TongSoLoai.Enabled = false;
            this.txt_TongSoLoai.Location = new System.Drawing.Point(507, 896);
            this.txt_TongSoLoai.Name = "txt_TongSoLoai";
            this.txt_TongSoLoai.Size = new System.Drawing.Size(117, 26);
            this.txt_TongSoLoai.TabIndex = 156;
            // 
            // frm_QuanLyLoaiSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.txt_TongSoLoai);
            this.Controls.Add(this.lab_TongSoLoai);
            this.Controls.Add(this.txt_MaLoaiSanPham);
            this.Controls.Add(this.lab_MaLoaiSanPham);
            this.Controls.Add(this.btn_TaiLai);
            this.Controls.Add(this.btn_TroVe);
            this.Controls.Add(this.btn_XoaThongTin);
            this.Controls.Add(this.txt_SoLuong);
            this.Controls.Add(this.lab_SoLuong);
            this.Controls.Add(this.cmb_DonViTinh);
            this.Controls.Add(this.txt_TenLoaiSanPham);
            this.Controls.Add(this.lab_DonViTinh);
            this.Controls.Add(this.lab_TenLoaiSanPham);
            this.Controls.Add(this.btn_CapNhatLoaiSanPham);
            this.Controls.Add(this.btn_XoaLoaiSanPham);
            this.Controls.Add(this.txt_ThemLoaiSanPham);
            this.Controls.Add(this.gb_TimKiem);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.lab_TimKiem);
            this.Controls.Add(this.dgv_QuanLyLoaiSanPham);
            this.Controls.Add(this.lab_QuanLyLoaiSanPham);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_QuanLyLoaiSanPham";
            this.Text = "Quản Lý Loại Sản Phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_QuanLyLoaiSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuanLyLoaiSanPham)).EndInit();
            this.gb_TimKiem.ResumeLayout(false);
            this.gb_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epd_TenLoaiSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_DonViTinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_QuanLyLoaiSanPham;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgv_QuanLyLoaiSanPham;
        private System.Windows.Forms.GroupBox gb_TimKiem;
        private System.Windows.Forms.RadioButton rb_TenLoaiSanPham;
        private System.Windows.Forms.RadioButton rb_DonViTinh;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Label lab_TimKiem;
        private System.Windows.Forms.Button btn_CapNhatLoaiSanPham;
        private System.Windows.Forms.Button btn_XoaLoaiSanPham;
        private System.Windows.Forms.Button txt_ThemLoaiSanPham;
        private System.Windows.Forms.Label lab_TenLoaiSanPham;
        private System.Windows.Forms.Label lab_DonViTinh;
        private System.Windows.Forms.TextBox txt_TenLoaiSanPham;
        private System.Windows.Forms.ComboBox cmb_DonViTinh;
        private System.Windows.Forms.Label lab_SoLuong;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.ErrorProvider epd_TenLoaiSanPham;
        private System.Windows.Forms.Button btn_XoaThongTin;
        private System.Windows.Forms.ErrorProvider epd_DonViTinh;
        private System.Windows.Forms.Button btn_TroVe;
        private System.Windows.Forms.Button btn_TaiLai;
        private System.Windows.Forms.TextBox txt_MaLoaiSanPham;
        private System.Windows.Forms.Label lab_MaLoaiSanPham;
        private System.Windows.Forms.TextBox txt_TongSoLoai;
        private System.Windows.Forms.Label lab_TongSoLoai;
    }
}