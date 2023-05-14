using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pizza_Store_Managements
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        private Boolean checkMatKhauCoTrongKhong()
        {
            if (txt_MatKhau.Text.Trim().Length != 0)
                return false;
            return true;
        }
        private Boolean kiemTraTaiKhoanMatKhau(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (cmb_TaiKhoan.Text.Trim().Length == 0 && checkMatKhauCoTrongKhong() == true)
            {
                errorProvider1.SetError(ctr, "Bạn chưa nhập TÀI KHOẢN và MẬT KHẨU!!!.");
                return false;
            }
            else if (cmb_TaiKhoan.Text == "Nhân Viên" || cmb_TaiKhoan.Text == "Quản Lý")
            {
                if (checkMatKhauCoTrongKhong() == false)
                {
                    errorProvider1.Clear();
                    return true;
                }
                else
                {
                    errorProvider1.SetError(ctr, "Bạn cần phải nhập mật khẩu!!!.");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(ctr, "Bạn cần phải chọn 'Nhân viên' hoặc ' Quản Lý'!!!.");
                return false;
            }

            return false;
        }

        public static string TaiKhoanDangNhap = "";
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            kiemTraTaiKhoanMatKhau(sender, e);

            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            String strQuery = "Select * from DangNhap where TaiKhoan=N'" + cmb_TaiKhoan.Text.Trim() + "' and MatKhau='" + txt_MatKhau.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, cn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                frm_Home newFrm_Home = new frm_Home();
                string re = "Quyền: " + cmb_TaiKhoan.Text;
                MessageBox.Show(re, "ĐĂNG NHẬP THÀNH CÔNG", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaiKhoanDangNhap = cmb_TaiKhoan.SelectedItem.ToString();
                newFrm_Home.Show();
                this.Hide();
            }
            reader.Close();
            cn.Close();
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult r;

            r = MessageBox.Show("Bạn có chắc là muốn thoát chương trình!", "THOÁT CHƯƠNG TRÌNH",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}
