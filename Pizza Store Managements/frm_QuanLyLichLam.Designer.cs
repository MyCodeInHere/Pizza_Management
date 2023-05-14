namespace Pizza_Store_Managements
{
    partial class frm_QuanLyLichLam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_QuanLyLichLam));
            this.ptb_QuanLyLichLamViec = new System.Windows.Forms.PictureBox();
            this.lab_QuanLyLichLamViec = new System.Windows.Forms.Label();
            this.dgv_QuanLyLichLam = new System.Windows.Forms.DataGridView();
            this.lab_MaLichLam = new System.Windows.Forms.Label();
            this.txt_MaLichLam = new System.Windows.Forms.TextBox();
            this.btn_TroVe = new System.Windows.Forms.Button();
            this.lab_MaNhanVien = new System.Windows.Forms.Label();
            this.cmb_HoTenNhanVien = new System.Windows.Forms.ComboBox();
            this.lab_HoVaTen = new System.Windows.Forms.Label();
            this.txt_MaNhanVien = new System.Windows.Forms.TextBox();
            this.lab_CaLam = new System.Windows.Forms.Label();
            this.cmb_CaTruc = new System.Windows.Forms.ComboBox();
            this.lab_ViTri = new System.Windows.Forms.Label();
            this.cmb_ViTriLamViec = new System.Windows.Forms.ComboBox();
            this.lab_NgayLam = new System.Windows.Forms.Label();
            this.dtp_NgayLam = new System.Windows.Forms.DateTimePicker();
            this.btn_ThemLichLam = new System.Windows.Forms.Button();
            this.btn_XoaLichLam = new System.Windows.Forms.Button();
            this.btn_CapNhatLichLam = new System.Windows.Forms.Button();
            this.btn_XoaThongTin = new System.Windows.Forms.Button();
            this.lab_TimKiem = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.gb_TimKiem = new System.Windows.Forms.GroupBox();
            this.rb_MaLichLam = new System.Windows.Forms.RadioButton();
            this.rb_MaNhanVien = new System.Windows.Forms.RadioButton();
            this.rb_TenNhanVien = new System.Windows.Forms.RadioButton();
            this.btn_TaiLai = new System.Windows.Forms.Button();
            this.epd_HoVaTen = new System.Windows.Forms.ErrorProvider(this.components);
            this.epd_CaLam = new System.Windows.Forms.ErrorProvider(this.components);
            this.epd_ViTriLamViec = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_QuanLyLichLamViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuanLyLichLam)).BeginInit();
            this.gb_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epd_HoVaTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_CaLam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_ViTriLamViec)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_QuanLyLichLamViec
            // 
            this.ptb_QuanLyLichLamViec.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ptb_QuanLyLichLamViec.Image = global::Pizza_Store_Managements.Properties.Resources.calender_01;
            this.ptb_QuanLyLichLamViec.Location = new System.Drawing.Point(543, 47);
            this.ptb_QuanLyLichLamViec.Margin = new System.Windows.Forms.Padding(2);
            this.ptb_QuanLyLichLamViec.Name = "ptb_QuanLyLichLamViec";
            this.ptb_QuanLyLichLamViec.Size = new System.Drawing.Size(190, 164);
            this.ptb_QuanLyLichLamViec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_QuanLyLichLamViec.TabIndex = 7;
            this.ptb_QuanLyLichLamViec.TabStop = false;
            // 
            // lab_QuanLyLichLamViec
            // 
            this.lab_QuanLyLichLamViec.AutoSize = true;
            this.lab_QuanLyLichLamViec.Font = new System.Drawing.Font("SFU Stafford", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QuanLyLichLamViec.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_QuanLyLichLamViec.Location = new System.Drawing.Point(749, 96);
            this.lab_QuanLyLichLamViec.Name = "lab_QuanLyLichLamViec";
            this.lab_QuanLyLichLamViec.Size = new System.Drawing.Size(530, 75);
            this.lab_QuanLyLichLamViec.TabIndex = 8;
            this.lab_QuanLyLichLamViec.Text = "Quản Lý Lịch Làm";
            // 
            // dgv_QuanLyLichLam
            // 
            this.dgv_QuanLyLichLam.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgv_QuanLyLichLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QuanLyLichLam.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.dgv_QuanLyLichLam.GridColor = System.Drawing.Color.Yellow;
            this.dgv_QuanLyLichLam.Location = new System.Drawing.Point(327, 520);
            this.dgv_QuanLyLichLam.Name = "dgv_QuanLyLichLam";
            this.dgv_QuanLyLichLam.RowHeadersWidth = 62;
            this.dgv_QuanLyLichLam.RowTemplate.Height = 28;
            this.dgv_QuanLyLichLam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_QuanLyLichLam.Size = new System.Drawing.Size(1286, 385);
            this.dgv_QuanLyLichLam.TabIndex = 9;
            this.dgv_QuanLyLichLam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QuanLyLichLam_CellClick);
            // 
            // lab_MaLichLam
            // 
            this.lab_MaLichLam.AutoSize = true;
            this.lab_MaLichLam.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MaLichLam.ForeColor = System.Drawing.Color.Olive;
            this.lab_MaLichLam.Location = new System.Drawing.Point(426, 248);
            this.lab_MaLichLam.Name = "lab_MaLichLam";
            this.lab_MaLichLam.Size = new System.Drawing.Size(187, 35);
            this.lab_MaLichLam.TabIndex = 99;
            this.lab_MaLichLam.Text = "Mã Lịch Làm:";
            // 
            // txt_MaLichLam
            // 
            this.txt_MaLichLam.Enabled = false;
            this.txt_MaLichLam.Location = new System.Drawing.Point(646, 255);
            this.txt_MaLichLam.Name = "txt_MaLichLam";
            this.txt_MaLichLam.Size = new System.Drawing.Size(275, 26);
            this.txt_MaLichLam.TabIndex = 100;
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
            this.btn_TroVe.Location = new System.Drawing.Point(37, 31);
            this.btn_TroVe.Name = "btn_TroVe";
            this.btn_TroVe.Size = new System.Drawing.Size(135, 53);
            this.btn_TroVe.TabIndex = 101;
            this.btn_TroVe.Text = "Trở về";
            this.btn_TroVe.UseVisualStyleBackColor = false;
            this.btn_TroVe.Click += new System.EventHandler(this.btn_TroVe_Click);
            // 
            // lab_MaNhanVien
            // 
            this.lab_MaNhanVien.AutoSize = true;
            this.lab_MaNhanVien.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MaNhanVien.ForeColor = System.Drawing.Color.Olive;
            this.lab_MaNhanVien.Location = new System.Drawing.Point(1002, 248);
            this.lab_MaNhanVien.Name = "lab_MaNhanVien";
            this.lab_MaNhanVien.Size = new System.Drawing.Size(203, 35);
            this.lab_MaNhanVien.TabIndex = 102;
            this.lab_MaNhanVien.Text = "Mã Nhân Viên:";
            // 
            // cmb_HoTenNhanVien
            // 
            this.cmb_HoTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HoTenNhanVien.FormattingEnabled = true;
            this.cmb_HoTenNhanVien.Location = new System.Drawing.Point(646, 315);
            this.cmb_HoTenNhanVien.Name = "cmb_HoTenNhanVien";
            this.cmb_HoTenNhanVien.Size = new System.Drawing.Size(275, 28);
            this.cmb_HoTenNhanVien.TabIndex = 103;
            this.cmb_HoTenNhanVien.SelectedIndexChanged += new System.EventHandler(this.cmb_HoTenNhanVien_SelectedIndexChanged);
            // 
            // lab_HoVaTen
            // 
            this.lab_HoVaTen.AutoSize = true;
            this.lab_HoVaTen.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_HoVaTen.ForeColor = System.Drawing.Color.Olive;
            this.lab_HoVaTen.Location = new System.Drawing.Point(426, 308);
            this.lab_HoVaTen.Name = "lab_HoVaTen";
            this.lab_HoVaTen.Size = new System.Drawing.Size(151, 35);
            this.lab_HoVaTen.TabIndex = 104;
            this.lab_HoVaTen.Text = "Họ Và Tên:";
            // 
            // txt_MaNhanVien
            // 
            this.txt_MaNhanVien.Enabled = false;
            this.txt_MaNhanVien.Location = new System.Drawing.Point(1211, 257);
            this.txt_MaNhanVien.Name = "txt_MaNhanVien";
            this.txt_MaNhanVien.Size = new System.Drawing.Size(275, 26);
            this.txt_MaNhanVien.TabIndex = 105;
            // 
            // lab_CaLam
            // 
            this.lab_CaLam.AutoSize = true;
            this.lab_CaLam.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_CaLam.ForeColor = System.Drawing.Color.Olive;
            this.lab_CaLam.Location = new System.Drawing.Point(1002, 308);
            this.lab_CaLam.Name = "lab_CaLam";
            this.lab_CaLam.Size = new System.Drawing.Size(118, 35);
            this.lab_CaLam.TabIndex = 106;
            this.lab_CaLam.Text = "Ca Làm:";
            // 
            // cmb_CaTruc
            // 
            this.cmb_CaTruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CaTruc.FormattingEnabled = true;
            this.cmb_CaTruc.Items.AddRange(new object[] {
            "Ca sáng",
            "Ca chiều"});
            this.cmb_CaTruc.Location = new System.Drawing.Point(1211, 317);
            this.cmb_CaTruc.Name = "cmb_CaTruc";
            this.cmb_CaTruc.Size = new System.Drawing.Size(275, 28);
            this.cmb_CaTruc.TabIndex = 107;
            // 
            // lab_ViTri
            // 
            this.lab_ViTri.AutoSize = true;
            this.lab_ViTri.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ViTri.ForeColor = System.Drawing.Color.Olive;
            this.lab_ViTri.Location = new System.Drawing.Point(426, 372);
            this.lab_ViTri.Name = "lab_ViTri";
            this.lab_ViTri.Size = new System.Drawing.Size(214, 35);
            this.lab_ViTri.TabIndex = 108;
            this.lab_ViTri.Text = "Vị Trí Làm Việc:";
            // 
            // cmb_ViTriLamViec
            // 
            this.cmb_ViTriLamViec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ViTriLamViec.FormattingEnabled = true;
            this.cmb_ViTriLamViec.Items.AddRange(new object[] {
            "Bếp",
            "Phục Vụ",
            "Thu Ngân"});
            this.cmb_ViTriLamViec.Location = new System.Drawing.Point(646, 379);
            this.cmb_ViTriLamViec.Name = "cmb_ViTriLamViec";
            this.cmb_ViTriLamViec.Size = new System.Drawing.Size(275, 28);
            this.cmb_ViTriLamViec.TabIndex = 109;
            // 
            // lab_NgayLam
            // 
            this.lab_NgayLam.AutoSize = true;
            this.lab_NgayLam.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_NgayLam.ForeColor = System.Drawing.Color.Olive;
            this.lab_NgayLam.Location = new System.Drawing.Point(1002, 372);
            this.lab_NgayLam.Name = "lab_NgayLam";
            this.lab_NgayLam.Size = new System.Drawing.Size(150, 35);
            this.lab_NgayLam.TabIndex = 110;
            this.lab_NgayLam.Text = "Ngày Làm:";
            // 
            // dtp_NgayLam
            // 
            this.dtp_NgayLam.Location = new System.Drawing.Point(1211, 381);
            this.dtp_NgayLam.Name = "dtp_NgayLam";
            this.dtp_NgayLam.Size = new System.Drawing.Size(275, 26);
            this.dtp_NgayLam.TabIndex = 111;
            // 
            // btn_ThemLichLam
            // 
            this.btn_ThemLichLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_ThemLichLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ThemLichLam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_ThemLichLam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_ThemLichLam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_ThemLichLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThemLichLam.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemLichLam.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_ThemLichLam.Location = new System.Drawing.Point(391, 444);
            this.btn_ThemLichLam.Name = "btn_ThemLichLam";
            this.btn_ThemLichLam.Size = new System.Drawing.Size(257, 56);
            this.btn_ThemLichLam.TabIndex = 112;
            this.btn_ThemLichLam.Text = "Thêm Lịch Làm";
            this.btn_ThemLichLam.UseVisualStyleBackColor = false;
            this.btn_ThemLichLam.Click += new System.EventHandler(this.btn_ThemLichLam_Click);
            // 
            // btn_XoaLichLam
            // 
            this.btn_XoaLichLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaLichLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XoaLichLam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaLichLam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_XoaLichLam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_XoaLichLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaLichLam.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaLichLam.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_XoaLichLam.Location = new System.Drawing.Point(698, 444);
            this.btn_XoaLichLam.Name = "btn_XoaLichLam";
            this.btn_XoaLichLam.Size = new System.Drawing.Size(216, 56);
            this.btn_XoaLichLam.TabIndex = 113;
            this.btn_XoaLichLam.Text = "Xóa Lịch Làm";
            this.btn_XoaLichLam.UseVisualStyleBackColor = false;
            this.btn_XoaLichLam.Click += new System.EventHandler(this.btn_XoaLichLam_Click);
            // 
            // btn_CapNhatLichLam
            // 
            this.btn_CapNhatLichLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_CapNhatLichLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CapNhatLichLam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_CapNhatLichLam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_CapNhatLichLam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_CapNhatLichLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CapNhatLichLam.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhatLichLam.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_CapNhatLichLam.Location = new System.Drawing.Point(964, 444);
            this.btn_CapNhatLichLam.Name = "btn_CapNhatLichLam";
            this.btn_CapNhatLichLam.Size = new System.Drawing.Size(273, 56);
            this.btn_CapNhatLichLam.TabIndex = 114;
            this.btn_CapNhatLichLam.Text = "Cập Nhật Lịch Làm";
            this.btn_CapNhatLichLam.UseVisualStyleBackColor = false;
            this.btn_CapNhatLichLam.Click += new System.EventHandler(this.btn_CapNhatLichLam_Click);
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
            this.btn_XoaThongTin.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_XoaThongTin.Location = new System.Drawing.Point(1287, 444);
            this.btn_XoaThongTin.Name = "btn_XoaThongTin";
            this.btn_XoaThongTin.Size = new System.Drawing.Size(257, 56);
            this.btn_XoaThongTin.TabIndex = 115;
            this.btn_XoaThongTin.Text = "Xóa Thông Tin";
            this.btn_XoaThongTin.UseVisualStyleBackColor = false;
            this.btn_XoaThongTin.Click += new System.EventHandler(this.btn_XoaThongTin_Click);
            // 
            // lab_TimKiem
            // 
            this.lab_TimKiem.AutoSize = true;
            this.lab_TimKiem.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TimKiem.ForeColor = System.Drawing.Color.Olive;
            this.lab_TimKiem.Location = new System.Drawing.Point(332, 932);
            this.lab_TimKiem.Name = "lab_TimKiem";
            this.lab_TimKiem.Size = new System.Drawing.Size(146, 35);
            this.lab_TimKiem.TabIndex = 116;
            this.lab_TimKiem.Text = "Tìm Kiếm:";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(494, 941);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(239, 26);
            this.txt_TimKiem.TabIndex = 117;
            // 
            // btn_Tim
            // 
            this.btn_Tim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Tim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Tim.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Tim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Tim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tim.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.ForeColor = System.Drawing.Color.Tomato;
            this.btn_Tim.Location = new System.Drawing.Point(739, 932);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(67, 45);
            this.btn_Tim.TabIndex = 118;
            this.btn_Tim.Text = "Tìm ";
            this.btn_Tim.UseVisualStyleBackColor = false;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // gb_TimKiem
            // 
            this.gb_TimKiem.Controls.Add(this.rb_TenNhanVien);
            this.gb_TimKiem.Controls.Add(this.rb_MaNhanVien);
            this.gb_TimKiem.Controls.Add(this.rb_MaLichLam);
            this.gb_TimKiem.Location = new System.Drawing.Point(336, 983);
            this.gb_TimKiem.Name = "gb_TimKiem";
            this.gb_TimKiem.Size = new System.Drawing.Size(545, 55);
            this.gb_TimKiem.TabIndex = 119;
            this.gb_TimKiem.TabStop = false;
            // 
            // rb_MaLichLam
            // 
            this.rb_MaLichLam.AutoSize = true;
            this.rb_MaLichLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_MaLichLam.ForeColor = System.Drawing.Color.ForestGreen;
            this.rb_MaLichLam.Location = new System.Drawing.Point(12, 18);
            this.rb_MaLichLam.Name = "rb_MaLichLam";
            this.rb_MaLichLam.Size = new System.Drawing.Size(147, 26);
            this.rb_MaLichLam.TabIndex = 0;
            this.rb_MaLichLam.TabStop = true;
            this.rb_MaLichLam.Text = "Mã Lịch Làm";
            this.rb_MaLichLam.UseVisualStyleBackColor = true;
            this.rb_MaLichLam.CheckedChanged += new System.EventHandler(this.rb_MaLichLam_CheckedChanged);
            // 
            // rb_MaNhanVien
            // 
            this.rb_MaNhanVien.AutoSize = true;
            this.rb_MaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_MaNhanVien.ForeColor = System.Drawing.Color.ForestGreen;
            this.rb_MaNhanVien.Location = new System.Drawing.Point(184, 18);
            this.rb_MaNhanVien.Name = "rb_MaNhanVien";
            this.rb_MaNhanVien.Size = new System.Drawing.Size(160, 26);
            this.rb_MaNhanVien.TabIndex = 1;
            this.rb_MaNhanVien.TabStop = true;
            this.rb_MaNhanVien.Text = "Mã Nhân Viên";
            this.rb_MaNhanVien.UseVisualStyleBackColor = true;
            this.rb_MaNhanVien.CheckedChanged += new System.EventHandler(this.rb_MaNhanVien_CheckedChanged);
            // 
            // rb_TenNhanVien
            // 
            this.rb_TenNhanVien.AutoSize = true;
            this.rb_TenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_TenNhanVien.ForeColor = System.Drawing.Color.ForestGreen;
            this.rb_TenNhanVien.Location = new System.Drawing.Point(362, 18);
            this.rb_TenNhanVien.Name = "rb_TenNhanVien";
            this.rb_TenNhanVien.Size = new System.Drawing.Size(169, 26);
            this.rb_TenNhanVien.TabIndex = 2;
            this.rb_TenNhanVien.TabStop = true;
            this.rb_TenNhanVien.Text = "Tên Nhân Viên";
            this.rb_TenNhanVien.UseVisualStyleBackColor = true;
            this.rb_TenNhanVien.CheckedChanged += new System.EventHandler(this.rb_TenNhanVien_CheckedChanged);
            // 
            // btn_TaiLai
            // 
            this.btn_TaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_TaiLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TaiLai.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_TaiLai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_TaiLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_TaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TaiLai.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaiLai.ForeColor = System.Drawing.Color.Tomato;
            this.btn_TaiLai.Location = new System.Drawing.Point(1514, 520);
            this.btn_TaiLai.Name = "btn_TaiLai";
            this.btn_TaiLai.Size = new System.Drawing.Size(99, 45);
            this.btn_TaiLai.TabIndex = 120;
            this.btn_TaiLai.Text = "Tải Lại";
            this.btn_TaiLai.UseVisualStyleBackColor = false;
            this.btn_TaiLai.Click += new System.EventHandler(this.btn_TaiLai_Click);
            // 
            // epd_HoVaTen
            // 
            this.epd_HoVaTen.ContainerControl = this;
            // 
            // epd_CaLam
            // 
            this.epd_CaLam.ContainerControl = this;
            // 
            // epd_ViTriLamViec
            // 
            this.epd_ViTriLamViec.ContainerControl = this;
            // 
            // frm_QuanLyLichLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btn_TaiLai);
            this.Controls.Add(this.gb_TimKiem);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.lab_TimKiem);
            this.Controls.Add(this.btn_XoaThongTin);
            this.Controls.Add(this.btn_CapNhatLichLam);
            this.Controls.Add(this.btn_XoaLichLam);
            this.Controls.Add(this.btn_ThemLichLam);
            this.Controls.Add(this.dtp_NgayLam);
            this.Controls.Add(this.lab_NgayLam);
            this.Controls.Add(this.cmb_ViTriLamViec);
            this.Controls.Add(this.lab_ViTri);
            this.Controls.Add(this.cmb_CaTruc);
            this.Controls.Add(this.lab_CaLam);
            this.Controls.Add(this.txt_MaNhanVien);
            this.Controls.Add(this.lab_HoVaTen);
            this.Controls.Add(this.cmb_HoTenNhanVien);
            this.Controls.Add(this.lab_MaNhanVien);
            this.Controls.Add(this.btn_TroVe);
            this.Controls.Add(this.txt_MaLichLam);
            this.Controls.Add(this.lab_MaLichLam);
            this.Controls.Add(this.dgv_QuanLyLichLam);
            this.Controls.Add(this.lab_QuanLyLichLamViec);
            this.Controls.Add(this.ptb_QuanLyLichLamViec);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_QuanLyLichLam";
            this.Text = "Quản Lý Lịch Làm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_QuanLyLichLam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_QuanLyLichLamViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QuanLyLichLam)).EndInit();
            this.gb_TimKiem.ResumeLayout(false);
            this.gb_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epd_HoVaTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_CaLam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epd_ViTriLamViec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_QuanLyLichLamViec;
        private System.Windows.Forms.Label lab_QuanLyLichLamViec;
        private System.Windows.Forms.DataGridView dgv_QuanLyLichLam;
        private System.Windows.Forms.Label lab_MaLichLam;
        private System.Windows.Forms.TextBox txt_MaLichLam;
        private System.Windows.Forms.Button btn_TroVe;
        private System.Windows.Forms.Label lab_MaNhanVien;
        private System.Windows.Forms.ComboBox cmb_HoTenNhanVien;
        private System.Windows.Forms.Label lab_HoVaTen;
        private System.Windows.Forms.TextBox txt_MaNhanVien;
        private System.Windows.Forms.Label lab_CaLam;
        private System.Windows.Forms.ComboBox cmb_CaTruc;
        private System.Windows.Forms.Label lab_ViTri;
        private System.Windows.Forms.ComboBox cmb_ViTriLamViec;
        private System.Windows.Forms.Label lab_NgayLam;
        private System.Windows.Forms.DateTimePicker dtp_NgayLam;
        private System.Windows.Forms.Button btn_ThemLichLam;
        private System.Windows.Forms.Button btn_XoaLichLam;
        private System.Windows.Forms.Button btn_CapNhatLichLam;
        private System.Windows.Forms.Button btn_XoaThongTin;
        private System.Windows.Forms.Label lab_TimKiem;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.GroupBox gb_TimKiem;
        private System.Windows.Forms.RadioButton rb_TenNhanVien;
        private System.Windows.Forms.RadioButton rb_MaNhanVien;
        private System.Windows.Forms.RadioButton rb_MaLichLam;
        private System.Windows.Forms.Button btn_TaiLai;
        private System.Windows.Forms.ErrorProvider epd_HoVaTen;
        private System.Windows.Forms.ErrorProvider epd_CaLam;
        private System.Windows.Forms.ErrorProvider epd_ViTriLamViec;
    }
}