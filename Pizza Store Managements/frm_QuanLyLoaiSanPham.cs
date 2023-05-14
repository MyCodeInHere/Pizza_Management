using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Store_Managements
{
    public partial class frm_QuanLyLoaiSanPham : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_LoaiSanPham;
        DataSet ds_LoaiSanPham;
        DataColumn[] key = new DataColumn[1];
        public frm_QuanLyLoaiSanPham()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng loại sản phẩm
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM LoaiSanPham";
            da_LoaiSanPham = new SqlDataAdapter(strSelect, cn);
            ds_LoaiSanPham = new DataSet();
            da_LoaiSanPham.Fill(ds_LoaiSanPham, "LoaiSanPham");

            // Thêm khóa chính 
            key[0] = ds_LoaiSanPham.Tables["LoaiSanPham"].Columns[0];
            ds_LoaiSanPham.Tables["LoaiSanPham"].PrimaryKey = key;
        }

        // Thiết kế giao diện cho DataGridView.
        private void thietKeTieuDeDGV()
        {
            if (dgv_QuanLyLoaiSanPham != null && dgv_QuanLyLoaiSanPham.ColumnCount > 0)
            {
                dgv_QuanLyLoaiSanPham.Columns[0].HeaderText = "Mã loại sản phẩm";
                dgv_QuanLyLoaiSanPham.Columns[1].HeaderText = "Tên loại sản phẩm";
                dgv_QuanLyLoaiSanPham.Columns[2].HeaderText = "Đơn vị tính";
                dgv_QuanLyLoaiSanPham.Columns[3].HeaderText = "Số lượng";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_QuanLyLoaiSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_QuanLyLoaiSanPham.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_QuanLyLoaiSanPham.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_QuanLyLoaiSanPham.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                dgv_QuanLyLoaiSanPham.Columns["MaLoaiSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLyLoaiSanPham.Sort(dgv_QuanLyLoaiSanPham.Columns["MaLoaiSanPham"], ListSortDirection.Ascending);
            }
        }
        private void load_TongSoLoai()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
                cn.ConnectionString = strConn;
                cn.Open();

                // Tìm số lượng sản phẩm có trong cơ sở
                string countQuery = "SELECT COUNT(*) FROM LoaiSanPham";
                using (SqlCommand countCommand = new SqlCommand(countQuery, cn))
                {
                    int count = (int)countCommand.ExecuteScalar();
                    txt_TongSoLoai.Text = count.ToString();
                }
            }
        }
        private void load_grid()
        {
            dgv_QuanLyLoaiSanPham.DataSource = ds_LoaiSanPham.Tables["LoaiSanPham"];
            thietKeTieuDeDGV();
            load_TongSoLoai();
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }

        private int kiemTraTenLoaiSanPham()
        {
            // Kiểm tra tên loại sản phẩm
            if (coTrongKhong(txt_TenLoaiSanPham.Text) == false)
            {
                epd_TenLoaiSanPham.Clear();
                return 1;
            }
            else
            {
                epd_TenLoaiSanPham.SetError(txt_TenLoaiSanPham, "Bạn chưa nhập TÊN LOẠI SẢN PHẨM!!!.");
                return 0;
            }
        }
        private int kiemTraDonViTinh()
        {
            // Kiểm tra tên loại sản phẩm
            if (coTrongKhong(cmb_DonViTinh.Text) == false)
            {
                epd_DonViTinh.Clear();
                return 1;
            }
            else
            {
                epd_DonViTinh.SetError(cmb_DonViTinh, "Bạn chưa nhập ĐƠN VỊ TÍNH!!!.");
                return 0;
            }
        }
        private Boolean kiemTraThongTinLoaiSanPhamDaCo()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();
            // Kiểm tra thông tin nhân viên đã có trong hệ thống hay chưa.
            String strQuery = "Select * from LoaiSanPham where TenLoaiSanPham=N'" + txt_TenLoaiSanPham.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                cn.Close();
                cn.Dispose();
                return true;
            }
            cn.Close();
            cn.Dispose();
            return false;
        }
        private string xoaKhoangTrang(string myString)
        {
            string pattern = "\\s+"; // Dấu \\s+ sẽ đại diện cho bất kỳ khoảng trắng nào (bao gồm cả dấu cách, tab và các ký tự xuống dòng)
            string replacement = " ";

            string result = Regex.Replace(myString, pattern, replacement).Trim();
            return result;
        }
        private void themSanPham()
        {
            // Tạo một dòng dữ liệu mới.
            DataRow newRow = ds_LoaiSanPham.Tables["LoaiSanPham"].NewRow();
            // Thêm mã loại sản phẩm
            newRow["MaLoaiSanPham"] = get_MaSanPham();
            // Thêm tên loại sản phẩm
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TenLoaiSanPham.Text.ToLower());
            newRow["TenLoaiSanPham"] = xoaKhoangTrang(titleCaseString);
            // Thêm đơn vị tính
            TextInfo inf = CultureInfo.CurrentCulture.TextInfo;
            string donViTinh = inf.ToTitleCase(cmb_DonViTinh.Text.ToLower());
            newRow["DonViTinh"] = xoaKhoangTrang(donViTinh);
            // Them số lượng
            newRow["SoLuong"] = getNumProduce(txt_TenLoaiSanPham.Text);

            ds_LoaiSanPham.Tables[0].Rows.Add(newRow);
            // Cập nhật trong cơ sở dữ liệu.
            SqlCommandBuilder cB = new SqlCommandBuilder(da_LoaiSanPham);
            // Cập nhật trong DataSet.
            da_LoaiSanPham.Update(ds_LoaiSanPham, "LoaiSanPham");

            load_TongSoLoai();
            MessageBox.Show("Thêm loại sản phẩm thành công!!");

            // Xóa Combobox
            txt_TenLoaiSanPham.Clear();
            txt_SoLuong.Clear();
            cmb_DonViTinh.SelectedIndex = -1;
        }
        private void txt_ThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (kiemTraTenLoaiSanPham() == 1)
            {
                if (kiemTraThongTinLoaiSanPhamDaCo() == true)
                {
                    MessageBox.Show("Loại sản phẩm này đã tồn tại!!", "THÊM LOẠI SẢN PHẨM KHÔNG THÀNH CÔNG", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
                else
                {
                    themSanPham();
                }
            }
        }
        private void frm_QuanLyLoaiSanPham_Load(object sender, EventArgs e)
        {
            load_grid();
        }

        // Phát sinh Id tự động. 
        private string getID(string prefix, int length, int startingNumber, int currentValue)
        {
            int number = currentValue + 1;
            string idNumber = number.ToString().PadLeft(length - prefix.Length, '0');
            string id = prefix + idNumber;
            return id;
        }

        // Kiểm tra mã sản phẩm đã tồn tại chưa.
        private Boolean check_MaSanPham(string id)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
            {
                cn.Open();

                string selectQuery = "Select MaLoaiSanPham from LoaiSanPham where MaLoaiSanPham ='" + id + "'";
                using (SqlCommand cmdSelect = new SqlCommand(selectQuery, cn))
                {
                    using (SqlDataReader newReader = cmdSelect.ExecuteReader())
                    {
                        if (newReader.HasRows)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Lấy mã sản phẩm.
        private string get_MaSanPham()
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            // Tìm số lượng sản phẩm có trong cơ sở
            string countQuery = "SELECT COUNT(*) FROM LoaiSanPham";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("LSP", 5, 1, count);

            // Kiểm tra xem tài mã tài khoản đã tồn tại chưa.
            Boolean check = true;
            while (check == true)
            {
                if (check_MaSanPham(id) == false)
                {
                    check = false;
                }
                else
                {
                    count++;
                    id = getID("LSP", 5, 1, count);
                }
            }

            cn.Close();
            return id;
        }
        private int getNumProduce(string loaiSanPham)
        {
            SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");
            string strSelected = "SELECT * FROM SanPham WHERE LoaiSanPham = @LoaiSanPham";
            SqlDataAdapter da_SanPham = new SqlDataAdapter(strSelected, cn);
            da_SanPham.SelectCommand.Parameters.AddWithValue("@LoaiSanPham", loaiSanPham);
            DataSet ds_SanPham = new DataSet();
            da_SanPham.Fill(ds_SanPham, "SanPham");

            int soSanPham = ds_SanPham.Tables["SanPham"].Rows.Count;

            return soSanPham;
        }
        public bool kiemTraLoaiSanPham(string loaiSanPham)
        {
            bool daCoLoaiSanPham = false;
            string connectionString = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM SanPham WHERE LoaiSanPham = @LoaiSanPham";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoaiSanPham", loaiSanPham);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    daCoLoaiSanPham = true;
                }
            }
            return daCoLoaiSanPham;
        }
        private void capNhatLoaiSanPhamBangSanPham(string tenLoaiSanPham, string tenLoaiSanPhamMoi)
        {
            if (kiemTraLoaiSanPham(tenLoaiSanPham) == true)
            {
                string connectionString = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string querySanPham = "UPDATE SanPham SET LoaiSanPham = @TenLoaiSanPhamMoi WHERE LoaiSanPham = @TenLoaiSanPham";
                    SqlCommand commandSanPham = new SqlCommand(querySanPham, connection);
                    commandSanPham.Parameters.AddWithValue("@TenLoaiSanPhamMoi", tenLoaiSanPhamMoi);
                    commandSanPham.Parameters.AddWithValue("@TenLoaiSanPham", tenLoaiSanPham);
                    commandSanPham.ExecuteNonQuery();
                }
            }
        }
        private void xoaThongTin()
        {
            // Xóa Combobox
            txt_TenLoaiSanPham.Clear();
            txt_SoLuong.Clear();
            cmb_DonViTinh.SelectedIndex = -1;
        }
        private void btn_XoaThongTin_Click(object sender, EventArgs e)
        {
            // Xóa Combobox
            txt_TenLoaiSanPham.Clear();
            txt_SoLuong.Clear();
            cmb_DonViTinh.SelectedIndex = -1;
            txt_TenLoaiSanPham.Focus();
        }
        private void btn_CapNhatLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (txt_MaLoaiSanPham.Text.Trim().Length != 0)
            {
                if (kiemTraThongTinLoaiSanPhamDaCo() == false)
                {
                    DialogResult r;

                    r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin loại sản phẩm này?", "CẬP NHẬT THÔNG TIN LOẠI SẢN PHẨM", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    // Nếu đồng ý thì sẽ thực hiện việc cập nhật nhân viên.
                    if (r == DialogResult.Yes)
                    {
                        string tenLoaiSanPham = dgv_QuanLyLoaiSanPham.SelectedRows[0].Cells["TenLoaiSanPham"].Value.ToString();
                        DataRow dr = ds_LoaiSanPham.Tables["LoaiSanPham"].Rows.Find(txt_MaLoaiSanPham.Text);

                        if (dr != null)
                        {
                            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                            string titleCaseString = textInfo.ToTitleCase(txt_TenLoaiSanPham.Text.ToLower());
                            dr["TenLoaiSanPham"] = xoaKhoangTrang(titleCaseString);
                            TextInfo inf = CultureInfo.CurrentCulture.TextInfo;
                            string donViTinh = inf.ToTitleCase(cmb_DonViTinh.Text.ToLower());
                            dr["DonViTinh"] = xoaKhoangTrang(donViTinh);
                        }

                        SqlCommandBuilder cB = new SqlCommandBuilder(da_LoaiSanPham);
                        da_LoaiSanPham.Update(ds_LoaiSanPham, "LoaiSanPham");

                        TextInfo textInf = CultureInfo.CurrentCulture.TextInfo;
                        string titleCaseStrings = textInf.ToTitleCase(txt_TenLoaiSanPham.Text.ToLower());
                        titleCaseStrings = xoaKhoangTrang(titleCaseStrings);
                        capNhatLoaiSanPhamBangSanPham(tenLoaiSanPham, titleCaseStrings);
                        load_TongSoLoai();
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Đã có loại sản phẩm này", "CẬP NHẬT KHÔNG THÀNH CÔNG", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn loại sản phẩm cần cập nhật!!");
            }
        }
        private void btn_XoaLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (kiemTraTenLoaiSanPham() == 1)
            {
                if (kiemTraLoaiSanPham(txt_TenLoaiSanPham.Text) == false) { 
                    DialogResult r;

                    r = MessageBox.Show("Bạn có CHẮC là muốn xóa loại sản phẩm này?", "XÓA SẢN PHẨM", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    // Nếu đồng ý thì sẽ thực hiện việc xóa sản phẩm.
                    if (r == DialogResult.Yes)
                    {
                        // Tìm dòng dữ liệu có tên loại sản phẩm trùng với tên loại sản phẩm trong textbox.
                        DataRow dr = ds_LoaiSanPham.Tables["LoaiSanPham"].Rows.Find(txt_MaLoaiSanPham.Text);

                        // Xóa dòng dữ liệu vừa tìm được.
                        if (dr != null)
                        {
                            dr.Delete();
                            // Cập nhật trong CSDL.
                            SqlCommandBuilder cB = new SqlCommandBuilder(da_LoaiSanPham);
                            // Cập nhật trong DataSet.
                            da_LoaiSanPham.Update(ds_LoaiSanPham, "LoaiSanPham");
                            // Thông báo đã xóa thành công
                            MessageBox.Show("Đã xóa loại sản phẩn thành công!", "XÓA LOẠI SẢN PHẨM THÀNH CÔNG",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            xoaThongTin();
                            load_TongSoLoai();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy loại sản phẩm này!", "XÓA LOẠI SẢN PHẨM KHÔNG THÀNH CÔNG",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Loại sản phẩm "+txt_TenLoaiSanPham.Text+" đã có trong bảng sản phẩm!!!", "KHÔNG THỂ XÓA SẢN PHẨM NÀY",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dataBinDing()
        {
            // Thực hiện binding cho mã loại sản phẩm
            string maLoaiSanPham = dgv_QuanLyLoaiSanPham.SelectedRows[0].Cells["MaLoaiSanPham"].Value.ToString();
            txt_MaLoaiSanPham.Text = maLoaiSanPham;
            // Thực hiện binding cho tên loại sản phẩm
            string tenLoaiSanPham = dgv_QuanLyLoaiSanPham.SelectedRows[0].Cells["TenLoaiSanPham"].Value.ToString();
            txt_TenLoaiSanPham.Text = tenLoaiSanPham;
            // Thực hiện biding cho đơn vị tính
            string donViTinh = dgv_QuanLyLoaiSanPham.SelectedRows[0].Cells["DonViTinh"].Value.ToString();
            cmb_DonViTinh.Text = donViTinh;
            // Thực hiện biding cho số lượng
            string soLuong = dgv_QuanLyLoaiSanPham.SelectedRows[0].Cells["SoLuong"].Value.ToString();
            txt_SoLuong.Text = soLuong;
        }
        private void dgv_QuanLyLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBinDing();
        }

        // Thực hiện chức năng tìm kiếm 
        private static string timKiemTheo = "";
        private static int checkClick = 0;
        private void rb_MaSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_TenLoaiSanPham.Checked)
            {
                timKiemTheo = "TenLoaiSanPham";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void rb_DonViTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_DonViTinh.Checked)
            {
                timKiemTheo = "DonViTinh";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            if (checkClick == 0)
            {
                MessageBox.Show("Bạn chưa chọn loại tìm kiếm!!", "CHƯA CHỌN KIỂU TÌM",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txt_TimKiem.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm!!", "CHƯA NHẬP THÔNG TIN",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (timKiemTheo == "TenLoaiSanPham")
                    {
                        timTheoTenLoaiSanPham();
                    }
                    if (timKiemTheo == "DonViTinh")
                    {
                        timTheoDonViTinh();
                    }
                }
            }
        }
        private void timTheoTenLoaiSanPham()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TimKiem.Text.Trim().ToLower());
            string tenLoaiSanPham = xoaKhoangTrang(titleCaseString);
            if (tenLoaiSanPham.Length != 0)
            {
                bool timThayTenLoaiSanPham = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                foreach (DataGridViewRow row in dgv_QuanLyLoaiSanPham.Rows)
                {
                    if (row.Cells["TenLoaiSanPham"] != null && row.Cells["TenLoaiSanPham"].Value != null)
                    {
                        string tenLoaiSanPhamRow = row.Cells["TenLoaiSanPham"].Value.ToString();
                        if (tenLoaiSanPhamRow == tenLoaiSanPham)
                        {
                            row.Selected = true;
                            dgv_QuanLyLoaiSanPham.CurrentCell = row.Cells[0];
                            dataBinDing();
                            dgv_QuanLyLoaiSanPham.Focus();
                            timThayTenLoaiSanPham = true;
                            break;
                        }
                    }
                }
                if (!timThayTenLoaiSanPham)
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm có tên " + tenLoaiSanPham + "!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm cần tìm!!");
            }
        }
        private void timTheoDonViTinh()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string donViTinhL = textInfo.ToTitleCase(txt_TimKiem.Text.Trim().ToLower());
            string donViTinh = xoaKhoangTrang(donViTinhL);
            if (donViTinh.Length != 0)
            {
                bool timThayDonViTinh = false;
                dgv_QuanLyLoaiSanPham.Columns["DonViTinh"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLyLoaiSanPham.Sort(dgv_QuanLyLoaiSanPham.Columns["DonViTinh"], ListSortDirection.Ascending);
                // Lặp qua các dòng của DataGridView để tìm kiếm
                foreach (DataGridViewRow row in dgv_QuanLyLoaiSanPham.Rows)
                {
                    if (row.Cells["DonViTinh"] != null && row.Cells["DonViTinh"].Value != null)
                    {
                        string donViTinhRow = row.Cells["DonViTinh"].Value.ToString();
                        if (donViTinhRow == donViTinh)
                        {
                            row.Selected = true;
                            dgv_QuanLyLoaiSanPham.CurrentCell = row.Cells[0];
                            dataBinDing();
                            dgv_QuanLyLoaiSanPham.Focus();
                            timThayDonViTinh = true;
                            break;
                        }
                    }
                }
                if (!timThayDonViTinh)
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm có đơn vị tính là " + donViTinh);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính cần tìm");
            }
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLySanPham _Frm_QuanLySanPham = new frm_QuanLySanPham();
            _Frm_QuanLySanPham.ShowDialog();
        }

        private void btn_TaiLai_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Clear();
            dgv_QuanLyLoaiSanPham.Columns["MaLoaiSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgv_QuanLyLoaiSanPham.Sort(dgv_QuanLyLoaiSanPham.Columns["MaLoaiSanPham"], ListSortDirection.Ascending);
        }
        /*private void dgv_QuanLyLoaiSanPham_SelectionChanged(object sender, EventArgs e)
{
if (dgv_QuanLyLoaiSanPham.SelectedRows != null && dgv_QuanLyLoaiSanPham.SelectedRows.Count > 0)
{
dataBinDing();
}
}*/
    }
}
