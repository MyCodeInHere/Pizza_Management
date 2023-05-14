using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pizza_Store_Managements
{
    public partial class frm_TaiKhoanNhanVien : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_TaiKhoan;
        DataSet ds_TaiKhoan;
        DataColumn[] key = new DataColumn[1];
        public frm_TaiKhoanNhanVien()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng DangNhap
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");
       
            string strSelect = "SELECT * FROM DangNhap";
            da_TaiKhoan = new SqlDataAdapter(strSelect, cn);
            ds_TaiKhoan = new DataSet();
            da_TaiKhoan.Fill(ds_TaiKhoan, "DangNhap");

            // Thêm khóa chính 
            key[0] = ds_TaiKhoan.Tables["DangNhap"].Columns[0];
            ds_TaiKhoan.Tables["DangNhap"].PrimaryKey = key;
        }

        // Đổ dữ liệu vào combobox.
        private void load_ComBoBox()
        {
            // Load mã tài khoản
            cmb_MaTaiKhoan.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_MaTaiKhoan.DisplayMember = "MaTaiKhoan";
            cmb_MaTaiKhoan.ValueMember = "MaTaiKhoan";

            // Load mã Gioi Tinh
            cmb_GioiTinh.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_GioiTinh.DisplayMember = "GioiTinh";
            cmb_GioiTinh.ValueMember = "GioiTinh";

            // Load Tai Khoan
            cmb_TaiKhoan.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_TaiKhoan.DisplayMember = "TaiKhoan";
            cmb_TaiKhoan.ValueMember = "TaiKhoan";


            // Load mật khẩu
            cmb_MatKhau.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_MatKhau.DisplayMember = "MatKhau";
            cmb_MatKhau.ValueMember = "MatKhau";

            // Load họ và tên
            cmb_HoVaTen.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_HoVaTen.DisplayMember = "HoVaTen";
            cmb_HoVaTen.ValueMember = "HoVaTen";

            // Load ngày sinh
            cmb_NgaySinh.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_NgaySinh.DisplayMember = "NgaySinh";
            cmb_NgaySinh.ValueMember = "NgaySinh";

            // Load số điện thoại
            cmb_SoDienThoai.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_SoDienThoai.DisplayMember = "SoDienThoai";
            cmb_SoDienThoai.ValueMember = "SoDienThoai";

            // Load địa chỉ
            cmb_DiaChi.DataSource = dgv_TaiKhoanNhanVien.DataSource;
            cmb_DiaChi.DisplayMember = "DiaChi";
            cmb_DiaChi.ValueMember = "DiaChi";
        }
     
        // Tải dữ liệu lên DataGridView.
        private void load_Grid()
        {
            dgv_TaiKhoanNhanVien.DataSource = ds_TaiKhoan.Tables[0];
        }
        // Hàm này thực hiện chức năng thống kê
        private void thongKe(string loaiTK)
        {
            DataTable resultTable = ds_TaiKhoan.Tables["DangNhap"].Clone(); // tạo DataTable mới với cùng cấu trúc nhưng không có dữ liệu
            DataRow[] rows = ds_TaiKhoan.Tables["DangNhap"].Select("TaiKhoan = '" + loaiTK + "'"); // lọc các dòng có giá trị trường TaiKhoan bằng loaiTK
           
            foreach (DataRow row in rows)
            {
                resultTable.ImportRow(row); // sao chép các dòng này vào resultTable
            }
            if (resultTable.Rows.Count > 0)
            {
                dgv_TaiKhoanNhanVien.DataSource = resultTable;
                load_ComBoBox();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
            }
        }

        // Thiết kế giao diện cho DataGridView.
        private void thietKeTieuDeDGV()
        {
            if (dgv_TaiKhoanNhanVien != null && dgv_TaiKhoanNhanVien.ColumnCount > 0)
            {
                dgv_TaiKhoanNhanVien.Columns[0].HeaderText = "Mã tài khoản";
                dgv_TaiKhoanNhanVien.Columns[1].HeaderText = "Tài khoản";
                dgv_TaiKhoanNhanVien.Columns[2].HeaderText = "Mật khẩu";
                dgv_TaiKhoanNhanVien.Columns[3].HeaderText = "Họ và tên";
                dgv_TaiKhoanNhanVien.Columns[4].HeaderText = "Giới tính";
                dgv_TaiKhoanNhanVien.Columns[5].HeaderText = "Ngày sinh";
                dgv_TaiKhoanNhanVien.Columns[6].HeaderText = "Số điện thoại";
                dgv_TaiKhoanNhanVien.Columns[7].HeaderText = "Địa chỉ";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_TaiKhoanNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_TaiKhoanNhanVien.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_TaiKhoanNhanVien.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_TaiKhoanNhanVien.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
            }
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLyNhanVien _Frm_QuanLyNhanVien = new frm_QuanLyNhanVien();
            _Frm_QuanLyNhanVien.ShowDialog();
        }

        // Hàm này thực hiện chức năng xóa tài khoản
        private void btn_XoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult r;

            r = MessageBox.Show("Bạn có CHẮC là muốn xóa tài khoản này?", "XÓA TÀI KHOẢN", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Nếu đồng ý thì sẽ thực hiện việc xóa tài khoản.
            if (r == DialogResult.Yes)
            {
                // Tìm dòng dữ liệu có mã tài khoản trùng với mã tài khoản trong combobox.
                DataRow dr = ds_TaiKhoan.Tables["DangNhap"].Rows.Find(cmb_MaTaiKhoan.Text);

                // Xóa dòng dữ liệu vừa tìm được.
                if (dr != null)
                {
                    dr.Delete();
                    // Cập nhật trong CSDL.
                    SqlCommandBuilder cB = new SqlCommandBuilder(da_TaiKhoan);
                    // Cập nhật trong DataSet.
                    da_TaiKhoan.Update(ds_TaiKhoan, "DangNhap");
                    // Thông báo đã xóa thành công
                    MessageBox.Show("Đã xóa tài khoản thành công!", "XÓA TÀI KHOẢN THÀNH CÔNG",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản!", "XÓA TÀI KHOẢN KHÔNG THÀNH CÔNG", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void frm_TaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            load_Grid();
            load_ComBoBox();
            thietKeTieuDeDGV();
        }

        private void rb_QuanLy_Click(object sender, EventArgs e)
        {
            string loaiTK = "Quản Lý";
            thongKe(loaiTK);
        }

        private void rb_NhanVien_Click(object sender, EventArgs e)
        {
            string loaiTK = "Nhân Viên";
            thongKe(loaiTK);
        }

        private void rb_QuanLyNhanVien_Click(object sender, EventArgs e)
        {
            load_Grid();
            load_ComBoBox();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DangKy _Frm_DangKy = new frm_DangKy();
            _Frm_DangKy.ShowDialog();
        }
    }
}
