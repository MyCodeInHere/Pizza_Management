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

namespace Pizza_Store_Managements
{
    public partial class frm_DoiMatKhau : Form
    {
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Home newFrm_Home = new frm_Home();
            newFrm_Home.ShowDialog();
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }

        private int kiemTraTaiKhoan()
        {
            // Kiểm tra tài khoản.
            if (coTrongKhong(cmb_NhapTenTaiKhoan.Text) == false)
            {
                epd_TaiKhoan.Clear();
                return 1;
            }
            else
            {
                epd_TaiKhoan.SetError(cmb_NhapTenTaiKhoan, "Bạn chưa chọn TÊN TÀI KHOẢN!!!.");
                return 0;
            }
        }

        private int kiemTraMatKhau()
        {
            // Kiểm tra mật khẩu.
            if (coTrongKhong(txt_NhapMatKhauHienTai.Text) == false)
            {
                epd_MatKhauHienTai.Clear();
                return 1;
            }
            else
            {
                epd_MatKhauHienTai.SetError(txt_NhapMatKhauHienTai, "Bạn chưa nhập MẬT KHẨU HIỆN TẠI!!!.");
                return 0;
            }
        }

        private int kiemTraMatKhauMoi()
        {
            // Kiểm tra mật khẩu mới.
            if (coTrongKhong(txt_NhapMatKhauMoi.Text) == false)
            {
                epd_MatKhauMoi.Clear();
                return 1;
            }
            else
            {
                epd_MatKhauMoi.SetError(txt_NhapMatKhauMoi, "Bạn chưa nhập MẬT KHẨU MỚI!!!.");
                return 0;
            }
        }

        private int kiemTraNhapLaiMatKhauMoi()
        {
            // Kiểm tra nhập lại mật khẩu mới.
            if (coTrongKhong(txt_NhapLaiMatKhauMoi.Text) == false)
            {
                epd_NhapLaiMatKhauMoi.Clear();
                return 1;
            }
            else
            {
                epd_NhapLaiMatKhauMoi.SetError(txt_NhapLaiMatKhauMoi, "Bạn chưa nhập lại MẬT KHẨU MỚI!!!.");
                return 0;
            }
        }
        private Boolean kiemTraDaNhapDayDuThongTin()
        {
            int taiKhoan = kiemTraTaiKhoan();
            int matKhauHienTai = kiemTraMatKhau();
            int matKhauMoi = kiemTraMatKhauMoi();
            int nhapLaiMatKhauMoi =  kiemTraNhapLaiMatKhauMoi();
            int kiemTraDu = taiKhoan + matKhauHienTai + matKhauMoi + nhapLaiMatKhauMoi;

            if (kiemTraDu == 4)
                return true;
            return false;
        }
        private Boolean kiemTraMatKhauMoiVaNhapLaiMatKhauMoiGiongNhauKhong()
        {
            if (txt_NhapMatKhauMoi.Text.Equals(txt_NhapLaiMatKhauMoi.Text))
                return true;
            return false;
        }
        private bool kiemTraTaiKhoanTonTai(string tenTaiKhoan, string matKhauMoi)
        {
            bool ketQua = false;
            try
            {
                SqlConnection cn = new SqlConnection();
                String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
                cn.ConnectionString = strConn;
                cn.Open();
                // Truy vấn cơ sở dữ liệu để kiểm tra xem tài khoản đã tồn tại hay chưa.
                String strQuery = "SELECT COUNT(*) FROM DangNhap WHERE TaiKhoan=@TenTaiKhoan AND MatKhau=@MatKhauMoi";
                SqlCommand cmd = new SqlCommand(strQuery, cn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    ketQua = true;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ketQua;
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            cmb_NhapTenTaiKhoan.SelectedIndex = -1;
            txt_NhapMatKhauHienTai.Clear();
            txt_NhapMatKhauMoi.Clear();
            txt_NhapLaiMatKhauMoi.Clear();
            cmb_NhapTenTaiKhoan.Focus();
        }
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (kiemTraDaNhapDayDuThongTin())
            {
                SqlConnection cn = new SqlConnection();
                String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
                cn.ConnectionString = strConn;
                cn.Open();

                if (kiemTraTaiKhoanTonTai(cmb_NhapTenTaiKhoan.Text, txt_NhapMatKhauHienTai.Text) == true)
                {
                    // Kiểm tra tài khoản và mật khẩu có trong cơ sở dữ liệu hay không.
                    String strQuery = "Select * from DangNhap where TaiKhoan=N'" + cmb_NhapTenTaiKhoan.Text.Trim() + "' and MatKhau='" + txt_NhapMatKhauHienTai.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(strQuery, cn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Close();
                        // Nếu có thì kiểm tra nhập mật khẩu mới và việc nhập lại mật khẩu mới có giống nhau hay không.
                        if (kiemTraMatKhauMoiVaNhapLaiMatKhauMoiGiongNhauKhong() == true)
                        {
                            // Kiểm tra nếu mật khẩu mới khác với mật khẩu cũ
                            if (txt_NhapMatKhauMoi.Text.Trim() != txt_NhapMatKhauHienTai.Text.Trim())
                            {
                                if (kiemTraTaiKhoanTonTai(cmb_NhapTenTaiKhoan.Text, txt_NhapMatKhauMoi.Text) == false)
                                {
                                    // Cập nhật mật khẩu trong cơ sở dữ liệu
                                    String strU = "UPDATE DangNhap SET MatKhau=@MatKhauMoi WHERE TaiKhoan=@TaiKhoan AND MatKhau=@MatKhauHienTai";
                                    SqlCommand cmdU = new SqlCommand(strU, cn);
                                    cmdU.Parameters.AddWithValue("@MatKhauMoi", txt_NhapMatKhauMoi.Text.Trim());
                                    cmdU.Parameters.AddWithValue("@TaiKhoan", cmb_NhapTenTaiKhoan.Text.Trim());
                                    cmdU.Parameters.AddWithValue("@MatKhauHienTai", txt_NhapMatKhauHienTai.Text.Trim());
                                    int result = cmdU.ExecuteNonQuery();

                                    if (result > 0)
                                    {
                                        MessageBox.Show("Cập nhật mật khẩu thành công!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật mật khẩu thất bại!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vui lòng nhập lại mật khẩu khác!!!", "TÀI KHOẢN NÀY ĐÃ TỒN TẠI",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!", "Mật khẩu mới trùng với mật khẩu hiện tại",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("MẬT KHẨU MỚI VÀ NHẬP LẠI MẬT KHẨU MỚI không giống nhau!", "NHẬP LẠI SAI MẬT KHẨU",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản này không tồn tại để cập nhật!", "NHẬP SAI TÀI KHOẢN HOẶC MẬT KHẨU",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cn.Close();
            }
        }
    }
}
