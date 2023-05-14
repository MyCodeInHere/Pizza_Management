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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Pizza_Store_Managements
{
    public partial class frm_DangKy : Form
    {
        public frm_DangKy()
        {
            InitializeComponent();
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }
        private int kiemTraHoVaTen()
        {
            // Kiểm tra họ và tên.
            if (coTrongKhong(txt_HoVaTen.Text) == false)
            {
                epd_HoVaTen.Clear();
                return 1;
            }
            else
            {
                epd_HoVaTen.SetError(txt_HoVaTen, "Bạn chưa nhập HỌ VÀ TÊN!!!.");
                return 0;
            }
        }

        private int kiemTraGioiTinh()
        {
            // Kiểm tra giới tính.
            if (coTrongKhong(cmb_GioiTinh.Text) == false)
            {
                epd_GioiTinh.Clear();
                return 1;
            }
            else
            {
                epd_GioiTinh.SetError(cmb_GioiTinh, "Bạn chưa chọn GIỚI TÍNH!!!.");
                return 0;
            }
        }

        private int kiemTraSoDienThoai()
        {
            // Kiểm tra số điện thoại.
            if (coTrongKhong(txt_SoDienThoai.Text) == false)
            {
                epd_SoDienThoai.Clear();
                return 1;
            }
            else
            {
                epd_SoDienThoai.SetError(txt_SoDienThoai, "Bạn chưa nhập SỐ ĐIỆN THOẠI!!!.");
                return 0;
            }
        }

        private int kiemTraDiaChi()
        {
            // Kiểm tra địa chỉ.
            if (coTrongKhong(txt_DiaChi.Text) == false)
            {
                epd_DiaChi.Clear();
                return 1;
            }
            else
            {
                epd_DiaChi.SetError(txt_DiaChi, "Bạn chưa nhập ĐỊA CHỈ!!!.");
                return 0;
            }
        }

        private int kiemTraTaiKhoan()
        {
            // Kiểm tra tài khoản.
            if (coTrongKhong(cmb_TaiKhoan.Text) == false)
            {
                epd_TaiKhoan.Clear();
                return 1;
            }
            else
            {
                epd_TaiKhoan.SetError(cmb_TaiKhoan, "Bạn chưa nhập TÀI KHOẢN!!!.");
                return 0;
            }
        }

        private int kiemTraMatKhau()
        {
            // Kiểm tra mật khẩu.
            if (coTrongKhong(txt_MatKhau.Text) == false)
            {
                epd_MatKhau.Clear();
                return 1;
            }
            else
            {
                epd_MatKhau.SetError(txt_MatKhau, "Bạn chưa nhập MẬT KHẨU!!!.");
                return 0;
            }
        }

        // Phát sinh Id tự động. 
        private string getID(string prefix, int length, int startingNumber, int currentValue)
        {
            int number = currentValue + 1;
            string idNumber = number.ToString().PadLeft(length - prefix.Length, '0');
            string id = prefix + idNumber;
            return id;
        }

        // Kiểm tra mã tài khoản đã tồn tại chưa.
        private Boolean check_MaTaiKhoan(string id)
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            string selectQuery = "Select MaTaiKhoan from DangNhap where MaTaiKhoan ='" + id + "'";
            SqlCommand cmdSelect = new SqlCommand(selectQuery, cn);
            SqlDataReader newReader = cmdSelect.ExecuteReader();
            if (newReader.HasRows) 
            {
                cn.Close();
                return true;
            }

            cn.Close();
            return false;
        }
        // Lấy mã tài khoản.
        private string get_MaTaiKhoan()
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            // Tìm số lượng tài khoản có trong cơ sở
            string countQuery = "SELECT COUNT(*) FROM DangNhap";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("TK", 5, 1, count);

            // Kiểm tra xem tài mã tài khoản đã tồn tại chưa.
            Boolean check = true;
            while (check == true)
            {
                if (check_MaTaiKhoan(id) == false)
                {
                    check = false;
                }
                else
                {
                    count++;
                    id = getID("TK", 5, 1, count);
                }
            }

            cn.Close();
            return id;
        }
        private Boolean kiemTraTaiKhoanDaTonTai()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();
            // Kiểm tra tài khoản và mật khẩu đã có trong cơ sở dữ liệu hay chưa.
            String strQuery = "Select * from DangNhap where TaiKhoan=N'" + cmb_TaiKhoan.Text.Trim() + "' and MatKhau='" + txt_MatKhau.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, cn);
            SqlDataReader reader = cmd.ExecuteReader();

            Control ctr = new Control();

            // Có thì thông báo đã tồn tại tài khoản, vui lòng nhập lại thông tin.
            if (reader.HasRows)
            {
                MessageBox.Show("Bạn hãy nhập lại thông tin TÀI KHOẢN hoặc MẬT KHẨU", "TÀI KHOẢN NÀY ĐÃ TỒN TẠI"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                reader.Close();
                try
                {
                    string maTaiKhoan = get_MaTaiKhoan();

                    // Thêm dữ liệu vào CSDL.
                    string strInsert = "INSERT INTO DangNhap (MaTaiKhoan, HoVaTen, GioiTinh, NgaySinh, SoDienThoai, DiaChi, TaiKhoan, MatKhau) " +
                                    "VALUES (@MaTaiKhoan, @HoVaTen, @GioiTinh, @NgaySinh, @SoDienThoai, @DiaChi, @TaiKhoan, @MatKhau)";
                    SqlCommand cmdInsert = new SqlCommand(strInsert, cn);

                    cmdInsert.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cmdInsert.Parameters.AddWithValue("@HoVaTen", txt_HoVaTen.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@GioiTinh", cmb_GioiTinh.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Value);
                    cmdInsert.Parameters.AddWithValue("@SoDienThoai", txt_SoDienThoai.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@TaiKhoan", cmb_TaiKhoan.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@MatKhau", txt_MatKhau.Text.Trim());
                    cmdInsert.ExecuteNonQuery();

                    // Hiển thị đăng nhập thành công
                    MessageBox.Show("Bạn đã đăng ký tài khoản thành công.", "ĐĂNG KÝ THÀNH CÔNG",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đăng ký tài khoản: " + ex.Message, "LỖI ĐĂNG KÝ TÀI KHOẢN",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cn.Close();
                return false;
            }

            cn.Close();
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            Control ctr = new Control();

            int hoVaTen = kiemTraHoVaTen();
            int gioiTinh = kiemTraGioiTinh();
            int soDienThoai = kiemTraSoDienThoai();
            int diaChi = kiemTraDiaChi();
            int taiKhoan = kiemTraTaiKhoan();
            int matKhau = kiemTraMatKhau();
            // Kiểm tra đã nhập đầy đủ thông tin hay chưa.
            int kiemTra = hoVaTen + gioiTinh + soDienThoai + diaChi + taiKhoan + matKhau;
            if (kiemTra == 6)  kiemTraTaiKhoanDaTonTai();
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_TaiKhoanNhanVien _Frm_TaiKhoanNhanVien = new frm_TaiKhoanNhanVien();
            _Frm_TaiKhoanNhanVien.ShowDialog();
        }
        private void btn_XoaThongTin_Click(object sender, EventArgs e)
        {
            txt_HoVaTen.Clear();
            cmb_GioiTinh.SelectedIndex = -1;
            txt_DiaChi.Clear();
            txt_SoDienThoai.Clear();
            cmb_TaiKhoan.SelectedIndex = -1;
            txt_MatKhau.Clear();
            txt_HoVaTen.Focus();
        }
    }
}
