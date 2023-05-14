using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Store_Managements
{
    public partial class frm_ThongKeDoanhThu : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_HoaDon;
        DataSet ds_HoaDon;
        public frm_ThongKeDoanhThu()
        {
            InitializeComponent();

            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM HoaDon";
            da_HoaDon = new SqlDataAdapter(strSelect, cn);
            ds_HoaDon = new DataSet();
            da_HoaDon.Fill(ds_HoaDon, "HoaDon");
        }
        private void thietKeTieuDeDGV()
        {
            if (dgv_ThongKeDoanhThu != null && dgv_ThongKeDoanhThu.ColumnCount > 0)
            {
                dgv_ThongKeDoanhThu.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_ThongKeDoanhThu.Columns[1].HeaderText = "Tên sản phẩm";
                dgv_ThongKeDoanhThu.Columns[2].HeaderText = "Số lượng";
                dgv_ThongKeDoanhThu.Columns[3].HeaderText = "Đơn giá(đ)";
                dgv_ThongKeDoanhThu.Columns[4].HeaderText = "Tổng tiền";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_ThongKeDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_ThongKeDoanhThu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_ThongKeDoanhThu.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_ThongKeDoanhThu.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }

                dgv_ThongKeDoanhThu.Columns["MaSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_ThongKeDoanhThu.Sort(dgv_ThongKeDoanhThu.Columns["MaSanPham"], ListSortDirection.Ascending);
            }
        }
        DataTable resultTable;
        private void load_Form()
        {
            // Khởi tạo kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");
            conn.Open();

            // Tạo câu truy vấn SQL để chỉ lấy 5 cột cần thiết và chỉ load dữ liệu của mã hóa đơn ta truyền vào
            string sql = "SELECT MaSanPham, TenSanPham, SoLuong, DonGia, TongTien FROM ChiTietHoaDon";
            // Tạo đối tượng SqlCommand để thực hiện truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Tạo đối tượng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
            SqlDataReader reader = cmd.ExecuteReader();

            // Tạo datatable để lưu trữ dữ liệu đọc được từ cơ sở dữ liệu
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            resultTable = dataTable.Clone();
        }
        // Hàm frm_ThongKeDoanhThu_Load
        private void frm_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            load_Form();
            dgv_ThongKeDoanhThu.DataSource = resultTable;
            thietKeTieuDeDGV();
        }
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            string dateString = dtp_Ngay.Value.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT ct.MaSanPham, ct.TenSanPham, ct.SoLuong, ct.DonGia, ct.TongTien " +
                             "FROM ChiTietHoaDon ct " +
                             "INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon " +
                             "WHERE CONVERT(date, hd.NgayBan) = @NgayBan ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NgayBan", dateString);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        epd_Ngay.Clear();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        dgv_ThongKeDoanhThu.DataSource = dt;
                        thietKeTieuDeDGV();

                        float tongTien = TinhTongDoanhThu(connection, dateString);
                        lab_DoanhThu.Text = tongTien.ToString();
                        lab_DoanhThuThang.Text = tinhTongDoanhThuTheoThang(connection, dateString).ToString();
                    }
                    else
                    {
                        lab_DoanhThu.Text = "0";
                        lab_DoanhThuThang.Text = "0";
                        dgv_ThongKeDoanhThu.DataSource = resultTable;
                        thietKeTieuDeDGV();
                        epd_Ngay.SetError(dtp_Ngay, "Ngày này không có đơn hàng!!");
                    }
                }
            }
        }
        private float TinhTongDoanhThu(SqlConnection connection, string dateString)
        {
            string sql = "SELECT SUM(ct.TongTien) AS TongTien " +
                         "FROM ChiTietHoaDon ct " +
                         "INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon " +
                         "WHERE CONVERT(date, hd.NgayBan) = @NgayBan ";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@NgayBan", dateString);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return float.Parse(result.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }
        private float tinhTongDoanhThuTheoThang(SqlConnection connection, string dateString)
        {
            string sql = "SELECT SUM(ct.TongTien) AS TongTien " +
                         "FROM ChiTietHoaDon ct " +
                         "INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon " +
                         "WHERE MONTH(hd.NgayBan) = MONTH(@NgayBan) AND YEAR(hd.NgayBan) = YEAR(@NgayBan)";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@NgayBan", dateString);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return float.Parse(result.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Home _Frm_Home = new frm_Home();
            _Frm_Home.ShowDialog();
        }
        private void btn_MonTop_Click(object sender, EventArgs e)
        {
            string dateString = dtp_Ngay.Value.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT TOP 1 ct.MaSanPham, ct.TenSanPham, ct.SoLuong, ct.DonGia, ct.TongTien FROM ChiTietHoaDon ct INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon WHERE CONVERT(date, hd.NgayBan) = @NgayBan ORDER BY ct.SoLuong DESC";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NgayBan", dateString);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        epd_Ngay.Clear();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        dgv_ThongKeDoanhThu.DataSource = dt;
                        thietKeTieuDeDGV();

                        float tongTien = TinhTongDoanhThu(connection, dateString);
                        lab_DoanhThu.Text = tongTien.ToString();
                        lab_DoanhThuThang.Text = tinhTongDoanhThuTheoThang(connection, dateString).ToString();
                    }
                    else
                    {
                        lab_DoanhThu.Text = "0";
                        lab_DoanhThuThang.Text = "0";
                        dgv_ThongKeDoanhThu.DataSource = resultTable;
                        thietKeTieuDeDGV();
                        epd_Ngay.SetError(dtp_Ngay, "Ngày này không có đơn hàng!!");
                    }
                }
            }
        }
    }
}
