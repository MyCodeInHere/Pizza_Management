using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Store_Managements
{
    public partial class frm_Home : Form
    {
        public frm_Home()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
        }
        private void setChildren()
        {
            frm_DangNhap _Frm_DangNhap = new frm_DangNhap();
            _Frm_DangNhap.MdiParent = this;
            frm_QuanLyLichLam _Frm_QuanLyLichLam = new frm_QuanLyLichLam();
            _Frm_QuanLyLichLam.MdiParent = this;
        }
        public string setStatusStrip()
        {
            // Lấy giá trị mới nhất từ ComboBox
            string taiKhoan = getTaiKhoan();

            // Tìm kiếm StatusStrip trong form cha và lấy đối tượng NguoiDung
            StatusStrip NguoiDung = (StatusStrip)this.Controls.Find("statusString1", true)[0];

            // Kiểm tra xem NguoiDung có tồn tại hay không
            if (NguoiDung != null)
            {
                // Tìm kiếm ToolStripStatusLabel có tên "sts_NguoiDung" trong NguoiDung.Items và thêm tên người dùng
                if (NguoiDung.Items.ContainsKey("sts_NguoiDung"))
                {
                    NguoiDung.Items["sts_NguoiDung"].Text += " " + taiKhoan;
                }
            }
            return taiKhoan;
        }
        private void choPhepTruyCap(string nguoiTruyCap)
        {
            if (nguoiTruyCap.Equals("Nhân Viên"))
            {
                ptb_DoiMatKhau.Enabled = true;
                ptb_TaoDonHang.Enabled = true;
                ptb_DangXuat.Enabled = true;
                ptb_QuanLySanPham.Enabled = false;
                ptb_QuanLyNhanVien.Enabled = false;
                ptb_ThongKeDoanhThu.Enabled = false;
                ptb_QuanLyLichLamViec.Enabled = true;
            }
            if (nguoiTruyCap.Equals("Quản Lý"))
            {
                ptb_DoiMatKhau.Enabled = true;
                ptb_TaoDonHang.Enabled = true;
                ptb_DangXuat.Enabled = true;
                ptb_QuanLySanPham.Enabled = true;
                ptb_QuanLyNhanVien.Enabled = true;
                ptb_ThongKeDoanhThu.Enabled = true;
                ptb_QuanLyLichLamViec.Enabled = true;
            }
        }
        private string getTaiKhoan()
        {
            string taiKhoan = frm_DangNhap.TaiKhoanDangNhap;
            return taiKhoan;
        }
        private void frm_Home_Load(object sender, EventArgs e)
        {
            setChildren();
            setStatusStrip();
            choPhepTruyCap(getTaiKhoan());
        }

        private void ptb_DoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DoiMatKhau newFrm_DoiMatKhau = new frm_DoiMatKhau();
            newFrm_DoiMatKhau.ShowDialog();
        }

        private void ptb_TaoDonHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_TaoDonHang newFrmTaoDonHang = new frm_TaoDonHang();
            newFrmTaoDonHang.ShowDialog();
        }

        private void ptb_QuanLySanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLySanPham newFrm_QuanLySanPham = new frm_QuanLySanPham();
            newFrm_QuanLySanPham.ShowDialog();
        }

        private void ptb_QuanLyNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLyNhanVien newFrm_QuanLyNhanVien = new frm_QuanLyNhanVien();
            newFrm_QuanLyNhanVien.ShowDialog();
        }

        private void ptb_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult r;

            r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng Xuất", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Hide();
                frm_DangNhap newFrmDangNhap = new frm_DangNhap();
                newFrmDangNhap.ShowDialog();
            }
        }
        private void ptb_QuanLyLichLamViec_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLyLichLam _Frm_QuanLyLichLam = new frm_QuanLyLichLam();
            _Frm_QuanLyLichLam.ShowDialog();
        }
        private void ptb_ThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ThongKeDoanhThu _Frm_ThongKeDoanhThu = new frm_ThongKeDoanhThu();
            _Frm_ThongKeDoanhThu.ShowDialog();
        }
    }
}
