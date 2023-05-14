namespace Pizza_Store_Managements
{
    partial class frm_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DangNhap));
            this.pnl_DangNhap = new System.Windows.Forms.Panel();
            this.cmb_TaiKhoan = new System.Windows.Forms.ComboBox();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.lab_MatKhau = new System.Windows.Forms.Label();
            this.lab_TaiKhoan = new System.Windows.Forms.Label();
            this.lab_PizzaClass = new System.Windows.Forms.Label();
            this.lab_DangNhap = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_DangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_DangNhap
            // 
            this.pnl_DangNhap.Controls.Add(this.cmb_TaiKhoan);
            this.pnl_DangNhap.Controls.Add(this.btn_Thoat);
            this.pnl_DangNhap.Controls.Add(this.btn_DangNhap);
            this.pnl_DangNhap.Controls.Add(this.txt_MatKhau);
            this.pnl_DangNhap.Controls.Add(this.lab_MatKhau);
            this.pnl_DangNhap.Controls.Add(this.lab_TaiKhoan);
            this.pnl_DangNhap.Controls.Add(this.lab_PizzaClass);
            this.pnl_DangNhap.Controls.Add(this.lab_DangNhap);
            this.pnl_DangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_DangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_DangNhap.Location = new System.Drawing.Point(0, 0);
            this.pnl_DangNhap.Name = "pnl_DangNhap";
            this.pnl_DangNhap.Size = new System.Drawing.Size(1924, 1050);
            this.pnl_DangNhap.TabIndex = 2;
            // 
            // cmb_TaiKhoan
            // 
            this.cmb_TaiKhoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TaiKhoan.FormattingEnabled = true;
            this.cmb_TaiKhoan.Items.AddRange(new object[] {
            "Quản Lý",
            "Nhân Viên"});
            this.cmb_TaiKhoan.Location = new System.Drawing.Point(782, 416);
            this.cmb_TaiKhoan.Name = "cmb_TaiKhoan";
            this.cmb_TaiKhoan.Size = new System.Drawing.Size(451, 28);
            this.cmb_TaiKhoan.TabIndex = 9;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_Thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Thoat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Thoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btn_Thoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Thoat.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Thoat.Location = new System.Drawing.Point(1083, 574);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(109, 49);
            this.btn_Thoat.TabIndex = 8;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_DangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DangNhap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_DangNhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_DangNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangNhap.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.Color.Maroon;
            this.btn_DangNhap.Location = new System.Drawing.Point(853, 574);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(183, 49);
            this.btn_DangNhap.TabIndex = 6;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau.Location = new System.Drawing.Point(782, 493);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(451, 26);
            this.txt_MatKhau.TabIndex = 5;
            this.txt_MatKhau.UseSystemPasswordChar = true;
            // 
            // lab_MatKhau
            // 
            this.lab_MatKhau.AutoSize = true;
            this.lab_MatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_MatKhau.Font = new System.Drawing.Font("SFU Stafford", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lab_MatKhau.Location = new System.Drawing.Point(620, 485);
            this.lab_MatKhau.Name = "lab_MatKhau";
            this.lab_MatKhau.Size = new System.Drawing.Size(145, 35);
            this.lab_MatKhau.TabIndex = 3;
            this.lab_MatKhau.Text = "Mật khẩu:";
            // 
            // lab_TaiKhoan
            // 
            this.lab_TaiKhoan.AutoSize = true;
            this.lab_TaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_TaiKhoan.Font = new System.Drawing.Font("SFU Stafford", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lab_TaiKhoan.Location = new System.Drawing.Point(590, 403);
            this.lab_TaiKhoan.Name = "lab_TaiKhoan";
            this.lab_TaiKhoan.Size = new System.Drawing.Size(178, 41);
            this.lab_TaiKhoan.TabIndex = 2;
            this.lab_TaiKhoan.Text = "Tài khoản:";
            // 
            // lab_PizzaClass
            // 
            this.lab_PizzaClass.AutoSize = true;
            this.lab_PizzaClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_PizzaClass.Font = new System.Drawing.Font("SFU Stafford", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_PizzaClass.ForeColor = System.Drawing.Color.DarkOrange;
            this.lab_PizzaClass.Location = new System.Drawing.Point(951, 286);
            this.lab_PizzaClass.Name = "lab_PizzaClass";
            this.lab_PizzaClass.Size = new System.Drawing.Size(322, 69);
            this.lab_PizzaClass.TabIndex = 1;
            this.lab_PizzaClass.Text = "Pizza Class";
            // 
            // lab_DangNhap
            // 
            this.lab_DangNhap.AutoSize = true;
            this.lab_DangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_DangNhap.Font = new System.Drawing.Font("SFU Stafford", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_DangNhap.ForeColor = System.Drawing.Color.Maroon;
            this.lab_DangNhap.Location = new System.Drawing.Point(650, 286);
            this.lab_DangNhap.Name = "lab_DangNhap";
            this.lab_DangNhap.Size = new System.Drawing.Size(315, 69);
            this.lab_DangNhap.TabIndex = 0;
            this.lab_DangNhap.Text = "Đăng Nhập";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.pnl_DangNhap);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_DangNhap";
            this.Text = "ĐĂNG NHẬP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_DangNhap.ResumeLayout(false);
            this.pnl_DangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_DangNhap;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label lab_MatKhau;
        private System.Windows.Forms.Label lab_TaiKhoan;
        private System.Windows.Forms.Label lab_PizzaClass;
        private System.Windows.Forms.Label lab_DangNhap;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmb_TaiKhoan;
    }
}