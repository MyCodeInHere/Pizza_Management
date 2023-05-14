using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Store_Managements
{
    public partial class frm_TaoDonHang : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_HoaDon;
        DataSet ds_HoaDon;
        DataColumn[] key = new DataColumn[1];

        SqlDataAdapter da_ChiTietHoaDon;
        DataSet ds_ChiTietHoaDon;

        SqlDataAdapter da_NhanVien;
        DataSet ds_NhanVien;
        public frm_TaoDonHang()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng HoaDon
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            // Lấy dữ liệu từ bảng hóa đơn
            string strSelect = "SELECT * FROM HoaDon";
            da_HoaDon = new SqlDataAdapter(strSelect, cn);
            ds_HoaDon = new DataSet();
            da_HoaDon.Fill(ds_HoaDon, "HoaDon");
            key[0] = ds_HoaDon.Tables["HoaDon"].Columns[0];
            ds_HoaDon.Tables["HoaDon"].PrimaryKey = key;

            // Lấy dữ liệu từ bảng chi tiết hóa đơn
            string strSelect1 = "SELECT * FROM ChiTietHoaDon";
            da_ChiTietHoaDon = new SqlDataAdapter(strSelect1, cn);
            ds_ChiTietHoaDon = new DataSet();
            da_ChiTietHoaDon.Fill(ds_ChiTietHoaDon, "ChiTietHoaDon");

            // Lấy dữ liệu từ bảng nhân viên
            string strSelect2 = "SELECT * FROM NhanVien";
            da_NhanVien = new SqlDataAdapter(strSelect2, cn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            DataSet ds;
            string strSelect = "SELECT DISTINCT MaHoaDon FROM ChiTietHoaDon WHERE MaHoaDon NOT IN (SELECT MaHoaDon FROM HoaDon)";
            da = new SqlDataAdapter(strSelect, cn);
            ds = new DataSet();
            da.Fill(ds, "MaHoaDonKhongCoTrongHoaDon");

            if (ds.Tables["MaHoaDonKhongCoTrongHoaDon"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables["MaHoaDonKhongCoTrongHoaDon"].Rows)
                {
                    string maHoaDon = row["MaHoaDon"].ToString();

                    using (SqlConnection connection = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                    {
                        connection.Open();

                        // Thực hiện các thao tác trên cơ sở dữ liệu
                        SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon", connection);
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            this.Hide();
            frm_Home newFrmHome = new frm_Home();
            newFrmHome.ShowDialog();
        }
        private void load_Grid(string maHoaDon)
        {
            // Khởi tạo kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");
            conn.Open();

            // Tạo câu truy vấn SQL để chỉ lấy 5 cột cần thiết và chỉ load dữ liệu của mã hóa đơn ta truyền vào
            //string sql = "SELECT MaSanPham, TenSanPham, SoLuong, DonGia, TongTien FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            string sql = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";

            // Tạo đối tượng SqlCommand để thực hiện truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Thêm tham số cho câu truy vấn, giá trị của tham số là mã hóa đơn ta truyền vào
            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

            // Tạo đối tượng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
            SqlDataReader reader = cmd.ExecuteReader();

            // Tạo datatable để lưu trữ dữ liệu đọc được từ cơ sở dữ liệu
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            // Hiển thị dữ liệu lên datagridview
            dgv_ThongTinDonHang.DataSource = dataTable;
            //dgv_ThongTinDonHang.Columns["MaHoaDon"].Visible = false;

            // Đóng kết nối và giải phóng tài nguyên
            reader.Close();
            conn.Close();
        }

        // Thiết kế giao diện cho DataGridView.
        private void thietKeTieuDeDGV()
        {
            if (dgv_ThongTinDonHang != null && dgv_ThongTinDonHang.ColumnCount > 0)
            {
                dgv_ThongTinDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dgv_ThongTinDonHang.Columns[1].HeaderText = "Mã sản phẩm";
                dgv_ThongTinDonHang.Columns[2].HeaderText = "Tên sản phẩm";
                dgv_ThongTinDonHang.Columns[3].HeaderText = "Giá sản phẩm";
                dgv_ThongTinDonHang.Columns[4].HeaderText = "Số lượng";
                dgv_ThongTinDonHang.Columns[5].HeaderText = "Tổng tiền";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_ThongTinDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_ThongTinDonHang.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_ThongTinDonHang.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_ThongTinDonHang.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                dgv_ThongTinDonHang.Columns["MaSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_ThongTinDonHang.Sort(dgv_ThongTinDonHang.Columns["MaSanPham"], ListSortDirection.Ascending);
            }
        }

        DataTable resultTable;
        private void load_Form()
        {
            // Khởi tạo kết nối đến cơ sở dữ liệu
            SqlConnection conn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");
            conn.Open();

            // Tạo câu truy vấn SQL để chỉ lấy 5 cột cần thiết và chỉ load dữ liệu của mã hóa đơn ta truyền vào
            string sql = "SELECT * FROM ChiTietHoaDon";
            // Tạo đối tượng SqlCommand để thực hiện truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Tạo đối tượng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
            SqlDataReader reader = cmd.ExecuteReader();

            // Tạo datatable để lưu trữ dữ liệu đọc được từ cơ sở dữ liệu
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            resultTable = dataTable.Clone();
        }
        private void load_Cmb_MaNhanVien()
        {
            // Load mã nhân viên lên cmb_MaNhanVien
            cmb_MaNhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
            cmb_MaNhanVien.DisplayMember = "MaNhanVien";
            cmb_MaNhanVien.ValueMember = "MaNhanVien";
            cmb_MaNhanVien.SelectedIndex = -1;

            cmb_LoaiThanhToan.Items.Add(new LoaiThanhToan { Ma = "CK", Ten = "Chuyển khoản" });
            cmb_LoaiThanhToan.Items.Add(new LoaiThanhToan { Ma = "TM", Ten = "Tiền mặt" });
        }
        private void frm_TaoDonHang_Load(object sender, EventArgs e)
        {
            load_Form();
            dgv_ThongTinDonHang.DataSource = resultTable;
            thietKeTieuDeDGV();
            load_Cmb_MaNhanVien();
            load_Cmb_LoaiPizza();
            cmb_LoaiPizza.Enabled = false;
            txt_GiamGiaHoaDon.Text = mucGiamGia().ToString();

            cmb_TiemKiemTheoMaHoaDon.DataSource = ds_HoaDon.Tables["HoaDon"];
            cmb_TiemKiemTheoMaHoaDon.DisplayMember = "MaHoaDon";
            cmb_TiemKiemTheoMaHoaDon.ValueMember = "MaHoaDon";
            cmb_TiemKiemTheoMaHoaDon.SelectedIndex = -1;
        }
        private string xoaKhoangTrang(string myString)
        {
            string pattern = "\\s+"; // Dấu \\s+ sẽ đại diện cho bất kỳ khoảng trắng nào (bao gồm cả dấu cách, tab và các ký tự xuống dòng)
            string replacement = " ";

            string result = Regex.Replace(myString, pattern, replacement).Trim();
            return result;
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }
        private int kiemTraLoaiThanhToan()
        {
            if (coTrongKhong(cmb_LoaiThanhToan.Text) == false)
            {
                epd_LoaiThanhToan.Clear();
                return 1;
            }
            else
            {
                epd_LoaiThanhToan.SetError(cmb_LoaiThanhToan, "Bạn chưa chọn LOẠI THANH TOÁN!!!.");
                return 0;
            }
        }
        private int kiemTraMaNhanVien()
        {
            if (coTrongKhong(cmb_MaNhanVien.Text) == false)
            {
                epd_MaNhanVien.Clear();
                return 1;
            }
            else
            {
                epd_MaNhanVien.SetError(cmb_MaNhanVien, "Bạn chưa nhập MÃ NHÂN VIÊN!!!.");
                return 0;
            }
        }
        private int kiemTraDaNhapDuThongTinHoaDon()
        {
            int maNhanVien = kiemTraMaNhanVien();
            int loaiThanhToan = kiemTraLoaiThanhToan();
            int duThongTin = maNhanVien + loaiThanhToan;
            if (duThongTin == 2)
            {
                if (kiemTraMaNhanVienCoTonTaiHayKhong() == 1)
                {
                    return 1;
                }
                else
                {
                    epd_MaNhanVien.Clear();
                    epd_MaNhanVien.SetError(cmb_MaNhanVien, "MÃ NHÂN VIÊN NÀY KHÔNG TỒN TẠI!!!");
                    return 0;
                }
            }
            return 0;
        }
        private int kiemTraMaNhanVienCoTonTaiHayKhong()
        {
            // Lấy bảng NhanVien từ dataset
            DataTable dataTable = ds_NhanVien.Tables["NhanVien"];

            // Lọc các hàng có giá trị cột MaNhanVien bằng với giá trị đã nhập vào từ combobox
            DataRow[] rows = dataTable.Select("MaNhanVien = '" + cmb_MaNhanVien.Text.ToUpper() + "'");

            // Kiểm tra số lượng hàng lọc được
            if (rows.Length > 0)
            {
                return 1;
            }
            return 0;
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
        private Boolean check_MaHoaDon(string id)
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            string selectQuery = "Select MaHoaDon from HoaDon where MaHoaDon ='" + id + "'";
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

        // Lấy mã sản phẩm.
        private string get_MaHoaDon()
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            // Tìm số lượng hóa đơn có trong cơ sở
            string countQuery = "SELECT COUNT(*) FROM HoaDon";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("HD", 5, 1, count);

            // Kiểm tra xem tài mã hóa đơn đã tồn tại chưa.
            Boolean check = true;
            while (check == true)
            {
                if (check_MaHoaDon(id) == false)
                {
                    check = false;
                }
                else
                {
                    count++;
                    id = getID("HD", 5, 1, count);
                }
            }

            cn.Close();
            return id;
        }

        // Chọn loại sản phẩm để load lên combobox danh sách sản phẩm.
        private string chonLoai = "";
        private int daChon = 0;
        private void rb_Pizza_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Pizza.Checked)
            {
                chonLoai = "pizza";
                cmb_LoaiPizza.Enabled = true;
                daChon = 1;
                load_Cmb_DanhMucSanPham();
            }
        }
        private void rb_ThucAnKem_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ThucAnKem.Checked)
            {
                chonLoai = "thức ăn kèm";
                cmb_LoaiPizza.Enabled = false;
                cmb_LoaiPizza.SelectedIndex = -1;
                daChon = 1;
                load_Cmb_DanhMucSanPham();
            }
        }
        private void rb_DoUong_Click(object sender, EventArgs e)
        {
            if (rb_DoUong.Checked)
            {
                chonLoai = "đồ uống";
                cmb_LoaiPizza.Enabled = false;
                cmb_LoaiPizza.SelectedIndex = -1;
                daChon = 1;
                load_Cmb_DanhMucSanPham();
            }
        }

        // checkEnough kiểm tra đã nhập đầy đủ thông tin HÓA ĐƠN, SẢN PHẨM CHƯA.
        private int checkEnough = 0;
        private void btn_TaoHoaDon_Click(object sender, EventArgs e)
        {
            if (kiemTraDaNhapDuThongTinHoaDon() == 1)
            {
                txt_MaHoaDon.Text = get_MaHoaDon();
                cmb_MaNhanVien.Text = cmb_MaNhanVien.Text.ToUpper();
                // Lấy ngày giờ hiện tại
                DateTimeOffset currentDateTime = DateTimeOffset.Now;
                txt_NgayBan.Text = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                load_Form();
                checkEnough += 1;
            }
        }
        private void load_Cmb_LoaiPizza()
        {
            SqlDataAdapter da;
            DataSet ds;

            string strSelect = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE '%Pizza%'";
            da = new SqlDataAdapter(strSelect, cn);
            ds = new DataSet();
            da.Fill(ds, "LoaiSanPham");

            // Thiết lập giá trị cho ComboBox
            cmb_LoaiPizza.DataSource = ds.Tables["LoaiSanPham"];
            cmb_LoaiPizza.DisplayMember = "TenLoaiSanPham";
            cmb_LoaiPizza.ValueMember = "TenLoaiSanPham";

            cmb_LoaiPizza.SelectedIndex = -1;
        }
        private void load_Cmb_DanhMucSanPham()
        {
            if (daChon != 0)
            {
                if (chonLoai == "pizza")
                {
                    SqlDataAdapter da_SP;
                    DataSet ds_SP;
                    string strSelect = "SELECT * FROM SanPham WHERE LoaiSanPham LIKE '%Pizza%'";
                    da_SP = new SqlDataAdapter(strSelect, cn);
                    ds_SP = new DataSet();
                    da_SP.Fill(ds_SP, "SanPham");

                    if (ds_SP.Tables["SanPham"].Rows.Count > 0)
                    {
                        epd_ChuaCoSanPham.Clear();
                        cmb_DanhMucSanPham.DataSource = ds_SP.Tables["SanPham"];
                        cmb_DanhMucSanPham.DisplayMember = "TenSanPham";
                        cmb_DanhMucSanPham.ValueMember = "TenSanPham";

                        SqlDataAdapter da_S;
                        DataSet ds_S;
                        string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE '%Pizza%'";
                        da_S = new SqlDataAdapter(strSelect1, cn);
                        ds_S = new DataSet();
                        da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                        if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                        {
                            string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                            lab_DonVi.Text = donVi;
                        }
                    }
                    else
                    {
                        cmb_DanhMucSanPham.DataSource = null;
                        cmb_DanhMucSanPham.Items.Clear();
                        epd_ChuaCoSanPham.SetError(cmb_DanhMucSanPham, "Chưa có sản phẩm loại này!!");
                        lab_DonVi.Text = "...";
                    }
                }
                if (chonLoai == "thức ăn kèm")
                {
                    SqlDataAdapter da_TAK;
                    DataSet ds_TAK;
                    string strSelect = "SELECT * FROM SanPham WHERE LoaiSanPham LIKE N'%Thức Ăn Kèm%' OR TenSanPham LIKE N'%Tráng Miệng%'";
                    da_TAK = new SqlDataAdapter(strSelect, cn);
                    ds_TAK = new DataSet();
                    da_TAK.Fill(ds_TAK, "SanPham");

                    if (ds_TAK.Tables["SanPham"].Rows.Count > 0)
                    {
                        epd_ChuaCoSanPham.Clear();
                        cmb_DanhMucSanPham.DataSource = ds_TAK.Tables["SanPham"];
                        cmb_DanhMucSanPham.DisplayMember = "TenSanPham";
                        cmb_DanhMucSanPham.ValueMember = "TenSanPham";

                        SqlDataAdapter da_S;
                        DataSet ds_S;
                        string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE N'%Thức Ăn Kèm%' OR TenLoaiSanPham LIKE N'%Tráng Miệng%'";
                        da_S = new SqlDataAdapter(strSelect1, cn);
                        ds_S = new DataSet();
                        da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                        if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                        {
                            string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                            lab_DonVi.Text = donVi;
                        }
                    }
                    else
                    {
                        cmb_DanhMucSanPham.DataSource = null;
                        cmb_DanhMucSanPham.Items.Clear();
                        epd_ChuaCoSanPham.SetError(cmb_DanhMucSanPham, "Chưa có sản phẩm loại này!!");
                        lab_DonVi.Text = "...";
                    }
                }
                if (chonLoai == "đồ uống")
                {
                    SqlDataAdapter da_DU;
                    DataSet ds_DU;
                    string strSelect = "SELECT * FROM SanPham WHERE LoaiSanPham LIKE N'%Đồ Uống%'";
                    da_DU = new SqlDataAdapter(strSelect, cn);
                    ds_DU = new DataSet();
                    da_DU.Fill(ds_DU, "SanPham");
                    if (ds_DU.Tables["SanPham"].Rows.Count > 0)
                    {
                        epd_ChuaCoSanPham.Clear();
                        cmb_DanhMucSanPham.DataSource = ds_DU.Tables["SanPham"];
                        cmb_DanhMucSanPham.DisplayMember = "TenSanPham";
                        cmb_DanhMucSanPham.ValueMember = "TenSanPham";

                        SqlDataAdapter da_S;
                        DataSet ds_S;
                        string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE N'%Đồ Uống%'";
                        da_S = new SqlDataAdapter(strSelect1, cn);
                        ds_S = new DataSet();
                        da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                        if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                        {
                            string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                            lab_DonVi.Text = donVi;
                        }
                    }
                    else
                    {
                        cmb_DanhMucSanPham.DataSource = null;
                        cmb_DanhMucSanPham.Items.Clear();
                        epd_ChuaCoSanPham.SetError(cmb_DanhMucSanPham, "Chưa có sản phẩm loại này!!");
                        lab_DonVi.Text = "...";
                    }
                }
            }
        }
        private int ch = 0;
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (daChon != 0 && ch != 0)
            {
                cmb_LoaiPizza.SelectedIndex = -1;

                SqlDataAdapter da_SP;
                DataSet ds_SP;
                string strSelect = "SELECT * FROM SanPham WHERE LoaiSanPham LIKE '%Pizza%'";
                da_SP = new SqlDataAdapter(strSelect, cn);
                ds_SP = new DataSet();
                da_SP.Fill(ds_SP, "SanPham");

                if (ds_SP.Tables["SanPham"].Rows.Count > 0)
                {
                    epd_ChuaCoSanPham.Clear();
                    cmb_DanhMucSanPham.DataSource = ds_SP.Tables["SanPham"];
                    cmb_DanhMucSanPham.DisplayMember = "TenSanPham";
                    cmb_DanhMucSanPham.ValueMember = "TenSanPham";

                    SqlDataAdapter da_S;
                    DataSet ds_S;
                    string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE '%Pizza%'";
                    da_S = new SqlDataAdapter(strSelect1, cn);
                    ds_S = new DataSet();
                    da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                    if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                    {
                        string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                        lab_DonVi.Text = donVi;
                    }
                }
                else
                {
                    cmb_DanhMucSanPham.DataSource = null;
                    cmb_DanhMucSanPham.Items.Clear();
                    //epd_ChuaCoSanPham.SetError(cmb_DanhMucSanPham, "Chưa có sản phẩm loại này!!");
                    lab_DonVi.Text = "...";
                }
            }
        }
        private void cmb_LoaiPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (daChon != 0)
            {
                SqlDataAdapter da_SP;
                DataSet ds_SP;
                string strSelect = "SELECT * FROM SanPham WHERE LoaiSanPham = N'" + cmb_LoaiPizza.Text + "'";
                da_SP = new SqlDataAdapter(strSelect, cn);
                ds_SP = new DataSet();
                da_SP.Fill(ds_SP, "SanPham");

                if (ds_SP.Tables["SanPham"].Rows.Count > 0)
                {
                    epd_ChuaCoSanPham.Clear();
                    cmb_DanhMucSanPham.DataSource = ds_SP.Tables["SanPham"];
                    cmb_DanhMucSanPham.DisplayMember = "TenSanPham";
                    cmb_DanhMucSanPham.ValueMember = "TenSanPham";
                    ch = 1;

                    SqlDataAdapter da_S;
                    DataSet ds_S;
                    string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE 'Pizza'";
                    da_S = new SqlDataAdapter(strSelect1, cn);
                    ds_S = new DataSet();
                    da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                    if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                    {
                        string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                        lab_DonVi.Text = donVi;
                    }
                }
                else
                {
                    cmb_DanhMucSanPham.DataSource = null;
                    cmb_DanhMucSanPham.Items.Clear();
                    epd_ChuaCoSanPham.SetError(cmb_DanhMucSanPham, "Chưa có sản phẩm loại này!!");
                    lab_DonVi.Text = "...";
                }
            }
        }
        private void load_GiaVaMaSanPham()
        {
            SqlDataAdapter da_SPs;
            DataSet ds_SPs;
            string strSelect = "SELECT * FROM SanPham WHERE TenSanPham = N'" + cmb_DanhMucSanPham.Text + "'";
            da_SPs = new SqlDataAdapter(strSelect, cn);
            ds_SPs = new DataSet();
            da_SPs.Fill(ds_SPs, "SanPham");

            if (ds_SPs.Tables["SanPham"].Rows.Count > 0)
            {
                string maSanPham = ds_SPs.Tables["SanPham"].Rows[0]["MaSanPham"].ToString();
                decimal giaBan = Convert.ToDecimal(ds_SPs.Tables["SanPham"].Rows[0]["GiaBan"]);
                txt_MaSanPham.Text = maSanPham;
                txt_GiaSanPham.Text = giaBan.ToString();
            }
        }
        private void cmb_DanhMucSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_DanhMucSanPham.Text.Length != 0)
            {
                load_GiaVaMaSanPham();
                txt_SoLuong.Clear();
            }
            else
            {
                txt_MaSanPham.Clear();
                txt_GiaSanPham.Clear();
                lab_DonVi.Text = "...";
            }
        }
        private int kiemTraDanhMucSanPham()
        {
            if (coTrongKhong(cmb_DanhMucSanPham.Text) == false)
            {
                epd_DanhMucSanPham.Clear();
                return 1;
            }
            else
            {
                epd_DanhMucSanPham.SetError(cmb_DanhMucSanPham, "Bạn chưa chọn SẢN PHẨM NÀO!!");
                return 0;
            }
        }
        private int kiemTraSoLuong()
        {
            if (coTrongKhong(txt_SoLuong.Text) == false)
            {
                epd_SoLuong.Clear();
                return 1;
            }
            else
            {
                epd_SoLuong.SetError(txt_SoLuong, "Bạn chưa chọn SỐ LƯỢNG!!!");
                return 0;
            }
        }
        private int kiemTraDaDuThongTinSanPham()
        {
            int kiemTraSoLuongs = kiemTraSoLuong();
            int kiemTraDanhMucSanPhams = kiemTraDanhMucSanPham();
            int daDuThongTin = kiemTraSoLuongs + kiemTraDanhMucSanPhams;

            if (daDuThongTin == 2)
            {
                return 1;
            }
            return 0;
        }
        private int kiemTraSanPhamDaTonTaiTrongHoaDon()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            String strQuery = "Select * from ChiTietHoaDon where MaHoaDon=N'" + txt_MaHoaDon.Text.Trim() + "' and MaSanPham ='" + txt_MaSanPham.Text.Trim() + "' and TenSanPham=N'" + cmb_DanhMucSanPham.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                cn.Close();
                cn.Dispose();
                return 1;
            }
            cn.Close();
            cn.Dispose();
            return 0;
        }
        private float mucGiamGia()
        {
            // Lấy ngày hiện tại
            var ngayHienTai = DateTime.Today;

            // Lấy thứ tương ứng của ngày hiện tại
            var today = ngayHienTai.DayOfWeek;

            // Chuyển thứ sang chuỗi
            var dayOfWeekString = today.ToString();

            if (dayOfWeekString == "Monday")
            {
                dayOfWeekString = "Thứ Hai";
            }
            if (dayOfWeekString == "Tuesday")
            {
                dayOfWeekString = "Thứ Ba";
            }
            if (dayOfWeekString == "Wednesday")
            {
                dayOfWeekString = "Thứ Tư";
            }
            if (dayOfWeekString == "Thursday")
            {
                dayOfWeekString = "Thứ Năm";
            }
            if (dayOfWeekString == "Friday")
            {
                dayOfWeekString = "Thứ Sáu";
            }
            if (dayOfWeekString == "Saturday")
            {
                dayOfWeekString = "Thứ Bảy";
            }
            if (dayOfWeekString == "Sunday")
            {
                dayOfWeekString = "Chủ Nhật";
            }
            // Biến lưu mức giảm giá
            float discountRate = 1;

            // Kiểm tra ngày hiện tại có trong bảng giảm giá hay không
            using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
            {
                cn.Open();
                string query = "SELECT MucGiamGia FROM GiamGia WHERE NgayGiamGia = @NgayGiamGia";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@NgayGiamGia", dayOfWeekString);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            discountRate = float.Parse(reader["MucGiamGia"].ToString());
                        }
                    }
                }
            }
            // Trả về mức giảm giá nếu có, ngược lại trả về 1
            return discountRate > 0 ? discountRate : 1;
        }
        private float tinhTongTien(string maHoaDon)
        {
            float tongTien = 0;

            using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=Pizza Store Management;Integrated Security=True"))
            {
                cn.Open();

                string query = "SELECT SUM(TongTien) AS TongTien FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                    object sumObject = cmd.ExecuteScalar();
                    if (sumObject != null && sumObject != DBNull.Value)
                    {
                        decimal decimalValue = Convert.ToDecimal(sumObject);
                        tongTien = Convert.ToSingle(decimalValue);
                    }
                }
            }

            float mucGiamGias = float.Parse((mucGiamGia() * 0.01).ToString());
            return tongTien - (tongTien * mucGiamGias);
        }
        private void themVaoHoaDon()
        {
            // Tạo một dòng dữ liệu mới.
            DataRow newRow = ds_ChiTietHoaDon.Tables[0].NewRow();

            newRow["MaHoaDon"] = txt_MaHoaDon.Text;
            newRow["MaSanPham"] = txt_MaSanPham.Text;
            newRow["TenSanPham"] = cmb_DanhMucSanPham.Text;
            newRow["SoLuong"] = txt_SoLuong.Text;
            newRow["DonGia"] = txt_GiaSanPham.Text;
            float soLuong = float.Parse(txt_SoLuong.Text);
            float donGia = float.Parse(txt_GiaSanPham.Text);
            newRow["TongTien"] = soLuong * donGia;

            ds_ChiTietHoaDon.Tables[0].Rows.Add(newRow);
            // Cập nhật trong cơ sở dữ liệu.
            SqlCommandBuilder cB = new SqlCommandBuilder(da_ChiTietHoaDon);
            // Cập nhật trong DataSet.
            da_ChiTietHoaDon.Update(ds_ChiTietHoaDon, "ChiTietHoaDon");

            MessageBox.Show("Thêm sản phẩm thành công!!");
        }
        private void btn_ThemVaoHoaDon_Click(object sender, EventArgs e)
        {
            if (txt_MaHoaDon.Text.Length != 0)
            {
                if (kiemTraDaDuThongTinSanPham() == 1)
                {
                    if (kiemTraSanPhamDaTonTaiTrongHoaDon() == 0)
                    {
                        themVaoHoaDon();
                        load_Grid(txt_MaHoaDon.Text);
                        txt_TongTienDonHang.Text = tinhTongTien(txt_MaHoaDon.Text).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm này đã có không thể thêm!!", "THÊM SẢN PHẨM KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa tạo hóa đơn!!!");
            }
        }
        private void frm_TaoDonHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlDataAdapter da;
            DataSet ds;
            string strSelect = "SELECT DISTINCT MaHoaDon FROM ChiTietHoaDon WHERE MaHoaDon NOT IN (SELECT MaHoaDon FROM HoaDon)";
            da = new SqlDataAdapter(strSelect, cn);
            ds = new DataSet();
            da.Fill(ds, "MaHoaDonKhongCoTrongHoaDon");

            if (ds.Tables["MaHoaDonKhongCoTrongHoaDon"].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables["MaHoaDonKhongCoTrongHoaDon"].Rows)
                {
                    string maHoaDon = row["MaHoaDon"].ToString();

                    using (SqlConnection connection = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                    {
                        connection.Open();

                        // Thực hiện các thao tác trên cơ sở dữ liệu
                        SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon", connection);
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
        }
        private string timKiemMaNhanVien(string maHoaDon)
        {
            // Lấy bảng đơn hàng từ dataset 
            DataTable ordersTable = ds_HoaDon.Tables["HoaDon"];

            // Tìm hàng có mã đơn hàng khớp 
            DataRow orderRow = ordersTable.Rows.Find(maHoaDon);
            // Nếu tìm thấy hàng    
            if (orderRow != null)
            {
                string employeeId = orderRow["MaNhanVien"].ToString();
                return employeeId;
            }
            return "";
        }
        private DateTime timKiemNgayBan(string maHoaDon)
        {
            DateTime ngayBan = DateTime.MinValue;

            // Lấy bảng HoaDon từ ds_HoaDon
            DataTable dtHoaDon = ds_HoaDon.Tables["HoaDon"];

            // Lọc các dòng có mã hóa đơn giống với mã hóa đơn truyền vào
            DataRow[] rows = dtHoaDon.Select("MaHoaDon = '" + maHoaDon + "'");

            if (rows.Length > 0)
            {
                // Lấy ngày bán từ bảng HoaDon
                ngayBan = Convert.ToDateTime(rows[0]["NgayBan"]);
            }

            return ngayBan;
        }
        private string timKiemLoaiThanhToan(string maHoaDon)
        {
            string maNhanVien = "";

            // Lấy bảng HoaDon từ ds_HoaDon
            DataTable dtHoaDon = ds_HoaDon.Tables["HoaDon"];

            // Lọc các dòng có mã hóa đơn giống với mã hóa đơn truyền vào
            DataRow[] rows = dtHoaDon.Select("MaHoaDon = '" + maHoaDon + "'");

            if (rows.Length > 0)
            {
                // Lấy mã nhân viên từ bảng HoaDon
                maNhanVien = rows[0]["MaNhanVien"].ToString();

                // Lấy bảng NhanVien từ ds_HoaDon
                DataTable dtNhanVien = ds_HoaDon.Tables["HoaDon"];

                // Lọc các dòng có mã nhân viên giống với mã nhân viên từ bảng HoaDon
                DataRow[] nhanVienRows = dtNhanVien.Select("MaNhanVien = '" + maNhanVien + "'");

                if (nhanVienRows.Length > 0)
                {
                    // Lấy mã nhân viên từ bảng NhanVien
                    maNhanVien = nhanVienRows[0]["LoaiThanhToan"].ToString();
                }
            }

            return maNhanVien;
        }
        private string timKiemLoaiSanPhamTheoTenSanPham(string tenSanPham)
        {
            string loaiSanPham = "";

            // Khởi tạo đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
            {
                // Tạo câu truy vấn SQL
                string query = "SELECT LoaiSanPham FROM SanPham WHERE TenSanPham = @TenSanPham";

                // Khởi tạo đối tượng SqlDataAdapter và DataSet
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                using (DataSet dataSet = new DataSet())
                {
                    // Thêm tham số @TenSanPham vào câu truy vấn
                    adapter.SelectCommand.Parameters.AddWithValue("@TenSanPham", tenSanPham);

                    // Đổ dữ liệu từ cơ sở dữ liệu vào DataSet
                    adapter.Fill(dataSet);

                    // Truy cập dữ liệu trong DataSet
                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        loaiSanPham = dataSet.Tables[0].Rows[0]["LoaiSanPham"].ToString();
                    }
                }
            }

            return loaiSanPham;

        }
        private void dgv_ThongTinDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maSanPham = dgv_ThongTinDonHang.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
            txt_MaSanPham.Text = maSanPham;

            string tenSanPhams = dgv_ThongTinDonHang.SelectedRows[0].Cells["TenSanPham"].Value.ToString();

            string loaiSanPham = timKiemLoaiSanPhamTheoTenSanPham(tenSanPhams);
            if (loaiSanPham.Contains("Pizza"))
            {
                rb_Pizza.Checked = true;

                SqlDataAdapter da_S;
                DataSet ds_S;
                string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE N'Pizza'";
                da_S = new SqlDataAdapter(strSelect1, cn);
                ds_S = new DataSet();
                da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                {
                    string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                    lab_DonVi.Text = donVi;
                }
            }
            else if (loaiSanPham.Contains("Thức Ăn Kèm"))
            {
                rb_ThucAnKem.Checked = true;

                SqlDataAdapter da_S;
                DataSet ds_S;
                string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE N'%Thức Ăn Kèm%'";
                da_S = new SqlDataAdapter(strSelect1, cn);
                ds_S = new DataSet();
                da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                {
                    string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                    lab_DonVi.Text = donVi;
                }
            }
            else if (loaiSanPham.Contains("Đồ Uống"))
            {
                rb_DoUong.Checked = true;

                SqlDataAdapter da_S;
                DataSet ds_S;
                string strSelect1 = "SELECT * FROM LoaiSanPham WHERE TenLoaiSanPham LIKE N'%Đồ Uống%'";
                da_S = new SqlDataAdapter(strSelect1, cn);
                ds_S = new DataSet();
                da_S.Fill(ds_S, "LoaiSanPham"); // Điền dữ liệu vào DataSet

                if (ds_S.Tables["LoaiSanPham"].Rows.Count > 0)
                {
                    string donVi = ds_S.Tables["LoaiSanPham"].Rows[0]["DonViTinh"].ToString();
                    lab_DonVi.Text = donVi;
                }
            }
            else
            {
                rb_Pizza.Checked = false;
                rb_ThucAnKem.Checked = false;
                rb_DoUong.Checked = false;
                lab_DonVi.Text = "...";
            }

            cmb_DanhMucSanPham.Text = tenSanPhams;

            if (tenSanPhams.Contains("Pizza"))
            {
                cmb_LoaiPizza.Text = timKiemLoaiSanPhamTheoTenSanPham(tenSanPhams);
            }
            else
            {
                cmb_LoaiPizza.SelectedIndex = -1;
            }

            string giaSanPham = dgv_ThongTinDonHang.SelectedRows[0].Cells["DonGia"].Value.ToString();
            txt_GiaSanPham.Text = giaSanPham;

            string soSanPham = dgv_ThongTinDonHang.SelectedRows[0].Cells["SoLuong"].Value.ToString();
            txt_SoLuong.Text = soSanPham;

            epd_ChuaCoSanPham.Clear();
        }
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (txt_MaSanPham.Text.Length != 0)
            {
                if (kiemTraDaDuThongTinSanPham() == 1)
                {
                    if (kiemTraSanPhamDaTonTaiTrongHoaDon() == 1)
                    {
                        string getMaSanPham = dgv_ThongTinDonHang.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
                        if (getMaSanPham == txt_MaSanPham.Text)
                        {
                            DialogResult r;

                            r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin sản phẩm này?", "CẬP NHẬT THÔNG TIN SẢN PHẨM", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                            // Nếu đồng ý thì sẽ thực hiện việc cập nhật nhân viên.
                            if (r == DialogResult.Yes)
                            {
                                using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=Pizza Store Management;Integrated Security=True"))
                                {
                                    cn.Open();

                                    string maHoaDon = txt_MaHoaDon.Text;
                                    string maSanPham = txt_MaSanPham.Text;
                                    string tenSanPham = cmb_DanhMucSanPham.Text;
                                    float donGia = float.Parse(txt_GiaSanPham.Text);
                                    int soLuong = int.Parse(txt_SoLuong.Text);
                                    float tongTien = donGia * soLuong;

                                    string query = "UPDATE ChiTietHoaDon SET MaSanPham = @MaSanPham, TenSanPham = @TenSanPham, " +
                                                   "DonGia = @DonGia, SoLuong = @SoLuong, TongTien = @TongTien WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

                                    using (SqlCommand cmd = new SqlCommand(query, cn))
                                    {
                                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                                        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                                        cmd.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                                        cmd.Parameters.AddWithValue("@DonGia", donGia);
                                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                        cmd.Parameters.AddWithValue("@TongTien", tongTien);

                                        cmd.ExecuteNonQuery();
                                    }

                                    load_Grid(txt_MaHoaDon.Text);
                                    MessageBox.Show("Cập nhật thành công!");

                                    txt_TongTienDonHang.Text = tinhTongTien(txt_MaHoaDon.Text).ToString();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đã có sản phẩm này!!!", "CẬP NHẬT KHÔNG THÀNH CÔNG",
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        DialogResult r;

                        r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin sản phẩm này?", "CẬP NHẬT THÔNG TIN SẢN PHẨM", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                        // Nếu đồng ý thì sẽ thực hiện việc cập nhật nhân viên.
                        if (r == DialogResult.Yes)
                        {
                            using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=Pizza Store Management;Integrated Security=True"))
                            {
                                cn.Open();

                                string maHoaDon = txt_MaHoaDon.Text;
                                string maSanPham = txt_MaSanPham.Text;
                                string tenSanPham = cmb_DanhMucSanPham.Text;
                                float donGia = float.Parse(txt_GiaSanPham.Text);
                                int soLuong = int.Parse(txt_SoLuong.Text);
                                float tongTien = donGia * soLuong;

                                string query = "UPDATE ChiTietHoaDon SET MaSanPham = @MaSanPham, TenSanPham = @TenSanPham, " +
                                               "DonGia = @DonGia, SoLuong = @SoLuong, TongTien = @TongTien WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

                                using (SqlCommand cmd = new SqlCommand(query, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                                    cmd.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                                    cmd.Parameters.AddWithValue("@DonGia", donGia);
                                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                                    cmd.ExecuteNonQuery();
                                }
                                load_Grid(txt_MaHoaDon.Text);
                                MessageBox.Show("Cập nhật thành công!");

                                txt_TongTienDonHang.Text = tinhTongTien(txt_MaHoaDon.Text).ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn một sản phẩm muốn cập nhật!!!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_MaSanPham.Text.Length != 0)
            {
                DialogResult r;

                r = MessageBox.Show("Bạn có CHẮC CHẮN là muốn xóa sản phẩm này?", "XÓA SẢN PHẨM", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Nếu đồng ý thì sẽ thực hiện việc xóa sản phẩm.
                if (r == DialogResult.Yes)
                {
                    using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=Pizza Store Management;Integrated Security=True"))
                    {
                        cn.Open();

                        string maSanPham = txt_MaSanPham.Text;

                        // Xóa dòng dữ liệu có tên loại sản phẩm trùng với tên loại sản phẩm trong textbox.
                        string query = "DELETE FROM ChiTietHoaDon WHERE MaSanPham = @MaSanPham";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đã xóa sản phẩm thành công!", "Xóa sản phẩm thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                load_Grid(txt_MaHoaDon.Text);
                                txt_TongTienDonHang.Text = tinhTongTien(txt_MaHoaDon.Text).ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy sản phẩm cần xóa!", "Không tìm thấy sản phẩm",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        txt_MaSanPham.Clear();
                        txt_SoLuong.Clear();
                        txt_GiaSanPham.Clear();
                        cmb_DanhMucSanPham.SelectedIndex = -1;
                        cmb_LoaiPizza.SelectedIndex = -1;
                        rb_DoUong.Checked = false;
                        rb_Pizza.Checked = false;
                        rb_ThucAnKem.Checked = false;
                        epd_ChuaCoSanPham.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm này!", "XÓA SẢN PHẨM KHÔNG THÀNH CÔNG",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn CẦN phải chọn sản phẩm để xóa!!!");
            }
        }
        private int kiemTraMaHoaDon(string maHoaDon)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
            {
                cn.Open();
                string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @ma";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@ma", maHoaDon);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) // Nếu đã có mã này
                {
                    return 1;
                }
                reader.Close();
            }
            return 0;
        }
        private void btn_LuuDonHang_Click(object sender, EventArgs e)
        {
            if (txt_MaHoaDon.Text.Length != 0)
            {
                if (kiemTraMaHoaDon(txt_MaHoaDon.Text) == 0)
                {
                    // Tạo một dòng dữ liệu mới.
                    DataRow newRow = ds_HoaDon.Tables["HoaDon"].NewRow();
                    // Thêm mã loại sản phẩm
                    newRow["MaHoaDon"] = txt_MaHoaDon.Text;
                    newRow["MaNhanVien"] = cmb_MaNhanVien.Text;
                    DateTime currentDate = DateTime.Now.Date;
                    txt_NgayBan.Text = currentDate.ToString();
                    newRow["NgayBan"] = txt_NgayBan.Text;
                    newRow["LoaiThanhToan"] = cmb_LoaiThanhToan.Text;
                    if(txt_TongTienDonHang.Text.Trim().Length !=0) newRow["TongTien"] = txt_TongTienDonHang.Text;

                    ds_HoaDon.Tables[0].Rows.Add(newRow);
                    // Cập nhật trong cơ sở dữ liệu.
                    SqlCommandBuilder cB = new SqlCommandBuilder(da_HoaDon);
                    // Cập nhật trong DataSet.
                    da_HoaDon.Update(ds_HoaDon, "HoaDon");

                    MessageBox.Show("Lưu hóa đơn thành công!!");
                }
                else
                {
                    DataRow dr = ds_HoaDon.Tables["HoaDon"].Rows.Find(txt_MaHoaDon.Text);

                    if (dr != null)
                    {
                        dr["MaHoaDon"] = txt_MaHoaDon.Text;
                        dr["MaNhanVien"] = cmb_MaNhanVien.Text;
                        dr["NgayBan"] = txt_NgayBan.Text;
                        dr["LoaiThanhToan"] = cmb_LoaiThanhToan.Text;
                        dr["TongTien"] = txt_TongTienDonHang.Text;
                    }

                    SqlCommandBuilder cB = new SqlCommandBuilder(da_HoaDon);
                    da_HoaDon.Update(ds_HoaDon, "HoaDon");

                    MessageBox.Show("Lưu hóa đơn thành công!!");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa tạo đơn hàng!!");
            }
        }
        private int kiemTraHoaDonDaTonTaiChua()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            String strQuery = "Select * from HoaDon where MaHoaDon=N'" + txt_MaHoaDon.Text.Trim() + "' and MaNhanVien ='" + cmb_MaNhanVien.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                cn.Close();
                cn.Dispose();
                return 1;
            }
            cn.Close();
            cn.Dispose();
            return 0;
        }
        private void btn_XoaDonHang_Click(object sender, EventArgs e)
        {
            if (txt_MaHoaDon.Text.Length != 0)
            {
                DialogResult r;

                r = MessageBox.Show("Bạn có CHẮC là muốn xóa hóa đơn này?", "XÓA HÓA ĐƠN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    DataRow dr = ds_HoaDon.Tables["HoaDon"].Rows.Find(txt_MaHoaDon.Text);

                    // Xóa dòng dữ liệu vừa tìm được.
                    if (dr != null)
                    {
                        dr.Delete();
                        // Cập nhật trong CSDL.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_HoaDon);
                        // Cập nhật trong DataSet.
                        da_HoaDon.Update(ds_HoaDon, "HoaDon");
                        // Thông báo đã xóa thành công
                        MessageBox.Show("Đã xóa hóa đơn thành công!", "XÓA HÓA ĐƠN THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlDataAdapter da;
                        DataSet ds;
                        string strSelect = "SELECT DISTINCT MaHoaDon FROM ChiTietHoaDon WHERE MaHoaDon NOT IN (SELECT MaHoaDon FROM HoaDon)";
                        da = new SqlDataAdapter(strSelect, cn);
                        ds = new DataSet();
                        da.Fill(ds, "MaHoaDonKhongCoTrongHoaDon");

                        if (ds.Tables["MaHoaDonKhongCoTrongHoaDon"].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables["MaHoaDonKhongCoTrongHoaDon"].Rows)
                            {
                                string maHoaDon = row["MaHoaDon"].ToString();

                                using (SqlConnection connection = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                                {
                                    connection.Open();

                                    // Thực hiện các thao tác trên cơ sở dữ liệu
                                    SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon", connection);
                                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                                    cmd.ExecuteNonQuery();

                                    connection.Close();
                                }
                            }
                        }
                        dgv_ThongTinDonHang.DataSource = resultTable;
                        txt_MaHoaDon.Clear();
                        cmb_MaNhanVien.SelectedIndex = -1;
                        txt_NgayBan.Clear();
                        cmb_LoaiThanhToan.SelectedIndex = -1;
                        txt_MaSanPham.Clear();
                        rb_DoUong.Checked = false;
                        rb_Pizza.Checked = false;
                        rb_ThucAnKem.Checked = false;
                        cmb_LoaiPizza.SelectedIndex = -1;
                        cmb_DanhMucSanPham.SelectedIndex = -1;
                        txt_GiaSanPham.Clear();
                        txt_SoLuong.Clear();
                        txt_TongTienDonHang.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đơn hàng!!");
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            if (cmb_TiemKiemTheoMaHoaDon.Text.Length != 0) {
                load_Grid(cmb_TiemKiemTheoMaHoaDon.Text);
                txt_MaHoaDon.Text = cmb_TiemKiemTheoMaHoaDon.Text;

                string maNhanVien = "";
                // Sử dụng DataAdapter để lấy dữ liệu
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT MaNhanVien FROM HoaDon WHERE MaHoaDon = @maHoaDon", "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                {
                    da.SelectCommand.Parameters.AddWithValue("@maHoaDon", txt_MaHoaDon.Text);

                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Lấy ra mã nhân viên đầu tiên từ bảng kết quả trả về
                            maNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
                        }
                    }
                }
                cmb_MaNhanVien.Text = maNhanVien;

                string ngayLap = "";

                // Sử dụng DataAdapter để lấy dữ liệu
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT NgayBan FROM HoaDon WHERE MaHoaDon = @maHoaDon", "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                {
                    da.SelectCommand.Parameters.AddWithValue("@maHoaDon", txt_MaHoaDon.Text);

                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Lấy ngày lập từ cột NgayBan
                            ngayLap = dt.Rows[0]["NgayBan"].ToString();
                        }
                    }
                }
                txt_NgayBan.Text = ngayLap;

                string loaiThanhToan = "";

                // Sử dụng DataAdapter để lấy dữ liệu
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT LoaiThanhToan FROM HoaDon WHERE MaHoaDon = @maHoaDon", "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                {
                    da.SelectCommand.Parameters.AddWithValue("@maHoaDon", txt_MaHoaDon.Text);

                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Lấy loại thanh toán từ cột LoaiThanhToan
                            loaiThanhToan = dt.Rows[0]["LoaiThanhToan"].ToString();
                        }
                    }
                }
                cmb_LoaiThanhToan.Text = loaiThanhToan;

                float tongTiens = 0;

                // Sử dụng DataAdapter để lấy dữ liệu
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT TongTien FROM HoaDon WHERE MaHoaDon = @maHoaDon", "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True"))
                {
                    da.SelectCommand.Parameters.AddWithValue("@maHoaDon", txt_MaHoaDon.Text);

                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // Lấy tổng tiền từ cột TongTien
                            float temp;
                            if (float.TryParse(dt.Rows[0]["TongTien"].ToString(), out temp))
                            {
                                tongTiens = temp;
                            }
                        }
                    }
                }

                // Hiển thị lên TextBox
                txt_TongTienDonHang.Text = tongTiens.ToString();

                load_Grid(cmb_TiemKiemTheoMaHoaDon.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã hóa đơn để tìm!!");
            }
        }

        private void btn_ThemDonHang_Click(object sender, EventArgs e)
        {
            if (txt_MaHoaDon.Text.Trim().Length != 0)
            {
                DataSet ds = new DataSet();
                da_HoaDon.Fill(ds, "HoaDon");
                // Tạo DataRow để tìm kiếm
                DataRow[] rows = ds.Tables["HoaDon"].Select("MaHoaDon = '" + txt_MaHoaDon.Text.Trim() + "'");

                // Kiểm tra
                if (rows.Length <= 0)
                {
                    DialogResult r;
                    // Hiển thị thông báo
                    r = MessageBox.Show("Hóa đơn chưa được lưu, bạn có muốn lưu trước khi xóa??", "CHƯA LƯU HÓA ĐƠN",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (r == DialogResult.OK)
                    {
                        if (kiemTraDaDuThongTinSanPham() == 1)
                        {
                            // Tạo một dòng dữ liệu mới.
                            DataRow newRow = ds_HoaDon.Tables["HoaDon"].NewRow();
                            // Thêm mã loại sản phẩm
                            newRow["MaHoaDon"] = txt_MaHoaDon.Text;
                            newRow["MaNhanVien"] = cmb_MaNhanVien.Text;
                            DateTimeOffset currentDateTime = DateTimeOffset.Now;
                            txt_NgayBan.Text = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                            newRow["NgayBan"] = txt_NgayBan.Text;
                            newRow["LoaiThanhToan"] = cmb_LoaiThanhToan.Text;
                            newRow["TongTien"] = txt_TongTienDonHang.Text;

                            ds_HoaDon.Tables[0].Rows.Add(newRow);
                            // Cập nhật trong cơ sở dữ liệu.
                            SqlCommandBuilder cB = new SqlCommandBuilder(da_HoaDon);
                            // Cập nhật trong DataSet.
                            da_HoaDon.Update(ds_HoaDon, "HoaDon");

                            MessageBox.Show("Lưu hóa đơn thành công!!");

                            dgv_ThongTinDonHang.DataSource = resultTable;
                            txt_MaHoaDon.Clear();
                            cmb_MaNhanVien.SelectedIndex = -1;
                            txt_NgayBan.Clear();
                            cmb_LoaiThanhToan.SelectedIndex = -1;
                            txt_MaSanPham.Clear();
                            rb_DoUong.Checked = false;
                            rb_Pizza.Checked = false;
                            rb_ThucAnKem.Checked = false;
                            cmb_LoaiPizza.SelectedIndex = -1;
                            cmb_DanhMucSanPham.SelectedIndex = -1;
                            txt_GiaSanPham.Clear();
                            txt_SoLuong.Clear();
                            txt_TongTienDonHang.Clear();
                        }
                    }
                    else
                    {
                        dgv_ThongTinDonHang.DataSource = resultTable;
                        txt_MaHoaDon.Clear();
                        cmb_MaNhanVien.SelectedIndex = -1;
                        txt_NgayBan.Clear();
                        cmb_LoaiThanhToan.SelectedIndex = -1;
                        txt_MaSanPham.Clear();
                        rb_DoUong.Checked = false;
                        rb_Pizza.Checked = false;
                        rb_ThucAnKem.Checked = false;
                        cmb_LoaiPizza.SelectedIndex = -1;
                        cmb_DanhMucSanPham.SelectedIndex = -1;
                        txt_GiaSanPham.Clear();
                        txt_SoLuong.Clear();
                        txt_TongTienDonHang.Clear();
                    }
                }
                else
                {
                    dgv_ThongTinDonHang.DataSource = resultTable;
                    txt_MaHoaDon.Clear();
                    cmb_MaNhanVien.SelectedIndex = -1;
                    txt_NgayBan.Clear();
                    cmb_LoaiThanhToan.SelectedIndex = -1;
                    txt_MaSanPham.Clear();
                    rb_DoUong.Checked = false;
                    rb_Pizza.Checked = false;
                    rb_ThucAnKem.Checked = false;
                    cmb_LoaiPizza.SelectedIndex = -1;
                    cmb_DanhMucSanPham.SelectedIndex = -1;
                    txt_GiaSanPham.Clear();
                    txt_SoLuong.Clear();
                    txt_TongTienDonHang.Clear();
                }
            }
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            report_InHoaDon rp = new report_InHoaDon();
            rp.ShowDialog();
        }
    }
}
