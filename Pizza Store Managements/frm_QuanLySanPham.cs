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
using System.Text.RegularExpressions;

namespace Pizza_Store_Managements
{
    public partial class frm_QuanLySanPham : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_SanPham;
        DataSet ds_SanPham;
        DataColumn[] key = new DataColumn[1];
        public frm_QuanLySanPham()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng loại sản phẩm
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM SanPham";
            da_SanPham = new SqlDataAdapter(strSelect, cn);
            ds_SanPham = new DataSet();
            da_SanPham.Fill(ds_SanPham, "SanPham");

            // Thêm khóa chính 
            key[0] = ds_SanPham.Tables["SanPham"].Columns[0];
            ds_SanPham.Tables["SanPham"].PrimaryKey = key;
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Home newFrmHomes = new frm_Home();
            newFrmHomes.ShowDialog();
        }
        private void btn_QuanLySanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLyLoaiSanPham _Frm_QuanLyLoaiSanPham = new frm_QuanLyLoaiSanPham();
            _Frm_QuanLyLoaiSanPham.ShowDialog();
        }
        private void load_Combobox()
        {
            SqlConnection cn;
            SqlDataAdapter da_LoaiSanPham;
            DataSet ds_LoaiSanPham;
            DataColumn[] key = new DataColumn[1];

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng loại sản phẩm
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM LoaiSanPham";
            da_LoaiSanPham = new SqlDataAdapter(strSelect, cn);
            ds_LoaiSanPham = new DataSet();
            da_LoaiSanPham.Fill(ds_LoaiSanPham, "LoaiSanPham");


            cmb_LoaiSanPham.DataSource = ds_LoaiSanPham.Tables["LoaiSanPham"];
            cmb_LoaiSanPham.DisplayMember = "TenLoaiSanPham";
            cmb_LoaiSanPham.ValueMember = "TenLoaiSanPham";

            cmb_LoaiSanPham.SelectedIndex = -1;
        }
        private void load_grid()
        {
            dgv_QuanLySanPham.DataSource = ds_SanPham.Tables["SanPham"];
            thietKeTieuDeDGV();
        }
        private void thietKeTieuDeDGV()
        {
            if (dgv_QuanLySanPham != null && dgv_QuanLySanPham.ColumnCount > 0)
            {
                dgv_QuanLySanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgv_QuanLySanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dgv_QuanLySanPham.Columns[2].HeaderText = "Giá nhập (đ)";
                dgv_QuanLySanPham.Columns[3].HeaderText = "Giá bán (đ)";
                dgv_QuanLySanPham.Columns[4].HeaderText = "Loại sản phẩm";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_QuanLySanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_QuanLySanPham.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_QuanLySanPham.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_QuanLySanPham.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }

                dgv_QuanLySanPham.Columns["MaSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLySanPham.Sort(dgv_QuanLySanPham.Columns["MaSanPham"], ListSortDirection.Ascending);
            }
        }
        private void capNhatSoSanPham()
        {
            int soLuongSanPham = 0;
            DataRow[] rows = ds_SanPham.Tables["SanPham"].Select("MaSanPham IS NOT NULL");
            if (rows != null && rows.Length > 0)
            {
                soLuongSanPham = rows.Length;
            }
            txt_TongSoSanPham.Text = soLuongSanPham.ToString();
        }
        private void frm_QuanLySanPham_Load(object sender, EventArgs e)
        {
            load_grid();
            load_Combobox();
            capNhatSoSanPham();
        }
        private void dataBinding()
        {
            // Thực hiện binding cho tên loại sản phẩm
            string idSanPham = dgv_QuanLySanPham.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
            txt_IDSanPham.Text = idSanPham;
            // Thực hiện binding cho tên sản phẩm
            string tenSanPham = dgv_QuanLySanPham.SelectedRows[0].Cells["TenSanPham"].Value.ToString();
            txt_TenSanPham.Text = tenSanPham;
            // Thực hiện binding cho giá nhập sản phầm
            string giaNhapSanPham = dgv_QuanLySanPham.SelectedRows[0].Cells["GiaNhap"].Value.ToString();
            txt_GiaNhap.Text = giaNhapSanPham;
            // Thực hiện binding cho giá bán sản phầm
            string giaBanSanPham = dgv_QuanLySanPham.SelectedRows[0].Cells["GiaBan"].Value.ToString();
            txt_GiaBan.Text = giaBanSanPham;
            // Thực hiện binding cho loại sản phẩm
            string loaiSanPham = dgv_QuanLySanPham.SelectedRows[0].Cells["LoaiSanPham"].Value.ToString();
            cmb_LoaiSanPham.Text = loaiSanPham;
        }
        private void dgv_QuanLySanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBinding();
        }
        private void xoaThongTin()
        {
            txt_IDSanPham.Clear();
            txt_TenSanPham.Clear();
            txt_GiaNhap.Clear();
            txt_GiaBan.Clear();
            cmb_LoaiSanPham.SelectedIndex = -1;
        }
        private void btn_XoaThongTin_Click(object sender, EventArgs e)
        {
            txt_IDSanPham.Clear();
            txt_TenSanPham.Clear();
            txt_GiaNhap.Clear();
            txt_GiaBan.Clear();
            cmb_LoaiSanPham.SelectedIndex = -1;
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
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            string selectQuery = "Select MaSanPham from SanPham where MaSanPham ='" + id + "'";
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
        private string get_MaSanPham()
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            // Tìm số lượng sản phẩm có trong cơ sở
            string countQuery = "SELECT COUNT(*) FROM SanPham";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("SP", 5, 1, count);

            // Kiểm tra xem tài mã sản phẩm đã tồn tại chưa.
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
                    id = getID("SP", 5, 1, count);
                }
            }

            cn.Close();
            return id;
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }
        private int kiemTraTenSanPham()
        {
            // Kiểm tra tên sản phẩm
            if (coTrongKhong(txt_TenSanPham.Text) == false)
            {
                epd_TenSanPham.Clear();
                return 1;
            }
            else
            {
                epd_TenSanPham.SetError(txt_TenSanPham, "Bạn chưa nhập TÊN SẢN PHẨM!!!.");
                return 0;
            }
        }
        private int kiemTraGiaSanPham()
        {
            // Kiểm tra giá sản phẩm
            if (coTrongKhong(txt_GiaNhap.Text) == false)
            {
                epd_GiaSanPham.Clear();
                return 1;
            }
            else
            {
                epd_GiaSanPham.SetError(txt_GiaNhap, "Bạn chưa nhập GIÁ SẢN PHẨM!!!.");
                return 0;
            }
        }
        private int kiemTraDaNhapDayDuThongTin()
        {
            int tenSanPhan = kiemTraTenSanPham();
            int giaSanPham = kiemTraGiaSanPham();
            int daDu = tenSanPhan + giaSanPham;
            if (daDu == 2)
            {
                return 1;
            }
            return 0;
        }
        private Boolean kiemTraThongTinSanPhamDaCo()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();
            // Kiểm tra thông tin nhân viên đã có trong hệ thống hay chưa.
            String strQuery = "Select * from SanPham where TenSanPham=N'" + txt_TenSanPham.Text.Trim() + "'";
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
            if (kiemTraThongTinSanPhamDaCo() == false)
            {
                int flag = 0;
                try
                {
                    if (txt_GiaNhap.Text.Trim().Length != 0)
                    {
                        float giaNhapSanPham = float.Parse(txt_GiaNhap.Text);
                    }
                    if (txt_GiaBan.Text.Trim().Length != 0)
                    {
                        float giaBanSanPham = float.Parse(txt_GiaBan.Text);
                    }
                }
                catch (FormatException ex) // Bắt lỗi FormatException khi nhập sai định dạng
                {
                    // Xử lý lỗi ở đây, ví dụ như thông báo cho người dùng biết nhập sai định dạng
                    MessageBox.Show("Vui lòng nhập đúng định dạng số!");
                    flag = 1;
                }
                if (flag != 1)
                {
                    // Tạo một dòng dữ liệu mới.
                    DataRow newRow = ds_SanPham.Tables["SanPham"].NewRow();
                    // Thêm mã sản phẩm
                    newRow["MaSanPham"] = get_MaSanPham();
                    // Thêm tên sản phẩm
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    string titleCaseString = textInfo.ToTitleCase(txt_TenSanPham.Text.ToLower());
                    newRow["TenSanPham"] = xoaKhoangTrang(titleCaseString);
                    // Thêm giá nhập sản phẩm
                    if (txt_GiaNhap.Text.Trim().Length != 0) newRow["GiaNhap"] = txt_GiaNhap.Text;
                    // Thêm giá bán sản phẩm
                    if (txt_GiaBan.Text.Trim().Length != 0) newRow["GiaBan"] = txt_GiaBan.Text;
                    // Thêm loại sản phẩm
                    if (cmb_LoaiSanPham.Text.Trim().Length != 0) newRow["LoaiSanPham"] = cmb_LoaiSanPham.Text;

                    ds_SanPham.Tables[0].Rows.Add(newRow);
                    // Cập nhật trong cơ sở dữ liệu.
                    SqlCommandBuilder cB = new SqlCommandBuilder(da_SanPham);
                    // Cập nhật trong DataSet.
                    da_SanPham.Update(ds_SanPham, "SanPham");

                    capNhatSoLuong(cmb_LoaiSanPham.Text, demSoLuongLoaiDaCo(cmb_LoaiSanPham.Text));
                    capNhatSoSanPham();
                    MessageBox.Show("Thêm sản phẩm thành công!!");

                    // Xóa binding
                    txt_IDSanPham.Clear();
                    txt_TenSanPham.Clear();
                    txt_GiaNhap.Clear();
                    txt_GiaBan.Clear();
                    cmb_LoaiSanPham.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm này đã có!!!", "THÊM SẢN PHẨM KHÔNG THÀNH CÔNG", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private int demSoLuongLoaiDaCo(string loaiSanPham)
        {
            int soLuongSanPham = 0;
            DataRow[] rows = ds_SanPham.Tables["SanPham"].Select("LoaiSanPham = '" + loaiSanPham + "'");
            if (rows != null && rows.Length > 0)
            {
                soLuongSanPham = rows.Length;
            }
            return soLuongSanPham;
        }
        public void capNhatSoLuong(string tenLoaiSanPham, int soLuongMoi)
        {
            string connectionString = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE LoaiSanPham SET SoLuong = @SoLuongMoi WHERE TenLoaiSanPham = @TenLoaiSanPham";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoLuongMoi", soLuongMoi);
                command.Parameters.AddWithValue("@TenLoaiSanPham", tenLoaiSanPham);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void txt_ThemSanPham_Click(object sender, EventArgs e)
        {
            if (kiemTraTenSanPham() == 1)
            {
                if (kiemTraThongTinSanPhamDaCo() == true)
                {
                    MessageBox.Show("Không thể thêm sản phẩm này!!", "SẢN PHẨM NÀY ĐÃ CÓ",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    themSanPham();
                }
            }
        }
        private void btn_CapNhatSanPham_Click(object sender, EventArgs e)
        {
            if (txt_IDSanPham.Text.Length != 0)
            {
                if (kiemTraThongTinSanPhamDaCo() == true)
                {
                    int flag = 0;
                    TextInfo textInf = CultureInfo.CurrentCulture.TextInfo;
                    string titleCaseStrings = textInf.ToTitleCase(txt_TenSanPham.Text.ToLower());
                    string getTenSanPham = dgv_QuanLySanPham.SelectedRows[0].Cells["TenSanPham"].Value.ToString();
                    try
                    {
                        if (txt_GiaNhap.Text.Trim().Length != 0)
                        {
                            float giaNhapSanPham = float.Parse(txt_GiaNhap.Text);
                        }
                        if (txt_GiaBan.Text.Trim().Length != 0)
                        {
                            float giaBanSanPham = float.Parse(txt_GiaBan.Text);
                        }
                    }
                    catch (FormatException ex) // Bắt lỗi FormatException khi nhập sai định dạng
                    {
                        // Xử lý lỗi ở đây, ví dụ như thông báo cho người dùng biết nhập sai định dạng
                        MessageBox.Show("Vui lòng nhập đúng định dạng số!");
                        flag = 1;
                    }
                    if (titleCaseStrings == getTenSanPham)
                    {
                        if (flag != 1)
                        {
                            DialogResult r;

                            r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin sản phẩm này?", "CẬP NHẬT THÔNG TIN SẢN PHẨM", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                            // Nếu đồng ý thì sẽ thực hiện việc cập nhật sản phẩm.
                            if (r == DialogResult.Yes)
                            {
                                DataRow dr = ds_SanPham.Tables["SanPham"].Rows.Find(txt_IDSanPham.Text);

                                if (dr != null)
                                {
                                    dr["MaSanPham"] = txt_IDSanPham.Text;
                                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                                    string titleCaseString = textInfo.ToTitleCase(txt_TenSanPham.Text.ToLower());
                                    dr["TenSanPham"] = xoaKhoangTrang(titleCaseString);
                                    if (txt_GiaNhap.Text.Trim().Length != 0)
                                    {
                                        float giaNhapSanPham = float.Parse(txt_GiaNhap.Text);
                                        dr["GiaNhap"] = giaNhapSanPham;
                                    }
                                    if (txt_GiaBan.Text.Trim().Length != 0)
                                    {
                                        float giaBanSanPham = float.Parse(txt_GiaBan.Text);
                                        dr["GiaBan"] = giaBanSanPham;
                                    }
                                    dr["LoaiSanPham"] = cmb_LoaiSanPham.Text;
                                }

                                SqlCommandBuilder cB = new SqlCommandBuilder(da_SanPham);
                                da_SanPham.Update(ds_SanPham, "SanPham");

                                capNhatSoLuong(cmb_LoaiSanPham.Text, demSoLuongLoaiDaCo(cmb_LoaiSanPham.Text));
                                capNhatSoSanPham();
                                MessageBox.Show("Cập nhật thành công!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã có sản phẩm có tên: " + titleCaseStrings + "!!!", "CẬP NHẬT KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    DialogResult r;

                    r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin sản phẩm này?", "CẬP NHẬT THÔNG TIN SẢN PHẨM", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    // Nếu đồng ý thì sẽ thực hiện việc cập nhật sản phẩm.
                    if (r == DialogResult.Yes)
                    {
                        DataRow dr = ds_SanPham.Tables["SanPham"].Rows.Find(txt_IDSanPham.Text);

                        if (dr != null)
                        {
                            dr["MaSanPham"] = txt_IDSanPham.Text;
                            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                            string titleCaseString = textInfo.ToTitleCase(txt_TenSanPham.Text.ToLower());
                            dr["TenSanPham"] = xoaKhoangTrang(titleCaseString);
                            if (txt_GiaNhap.Text.Trim().Length != 0)
                            {
                                float giaNhapSanPham = float.Parse(txt_GiaNhap.Text);
                                dr["GiaNhap"] = giaNhapSanPham;
                            }
                            if (txt_GiaBan.Text.Trim().Length != 0)
                            {
                                float giaBanSanPham = float.Parse(txt_GiaNhap.Text);
                                dr["GiaBan"] = giaBanSanPham;
                            }
                            dr["LoaiSanPham"] = cmb_LoaiSanPham.Text;
                        }

                        SqlCommandBuilder cB = new SqlCommandBuilder(da_SanPham);
                        da_SanPham.Update(ds_SanPham, "SanPham");

                        capNhatSoLuong(cmb_LoaiSanPham.Text, demSoLuongLoaiDaCo(cmb_LoaiSanPham.Text));
                        capNhatSoSanPham();
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn sản phẩm cần cập nhật!!");
            }
        }
        private void btn_XoaSanPham_Click(object sender, EventArgs e)
        {
            if (txt_IDSanPham.Text.Length != 0)
            {
                DialogResult r;

                r = MessageBox.Show("Bạn có CHẮC CHẮN là muốn xóa sản phẩm này?", "XÓA SẢN PHẨM", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Nếu đồng ý thì sẽ thực hiện việc xóa sản phẩm.
                if (r == DialogResult.Yes)
                {
                    // Tìm dòng dữ liệu có tên loại sản phẩm trùng với tên loại sản phẩm trong textbox.
                    DataRow dr = ds_SanPham.Tables["SanPham"].Rows.Find(txt_IDSanPham.Text);

                    // Xóa dòng dữ liệu vừa tìm được.
                    if (dr != null)
                    {
                        dr.Delete();
                        // Cập nhật trong CSDL.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_SanPham);
                        // Cập nhật trong DataSet.
                        da_SanPham.Update(ds_SanPham, "SanPham");
                        // Cập nhật và thông báo đã xóa thành công
                        capNhatSoLuong(cmb_LoaiSanPham.Text, demSoLuongLoaiDaCo(cmb_LoaiSanPham.Text));
                        capNhatSoSanPham();
                        MessageBox.Show("Đã xóa sản phẩn thành công!", "XÓA SẢN PHẨM THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xoaThongTin();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm này!", "XÓA SẢN PHẨM KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn sản phẩm cần xóa!!");
            }
        }

        // Thực hiện chức năng tìm kiếm 
        private static string timKiemTheo = "";
        private static int checkClick = 0;
        private void rb_MaSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_MaSanPham.Checked)
            {
                timKiemTheo = "MaSanPham";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void rb_TenSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_TenSanPham.Checked)
            {
                timKiemTheo = "TenSanPham";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void rb_LoaiSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_LoaiSanPham.Checked)
            {
                timKiemTheo = "LoaiSanPham";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void timTheoMaSanPham()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TimKiem.Text.ToLower());
            string maSanPham = xoaKhoangTrang(titleCaseString);
            if (maSanPham.Length != 0)
            {
                bool timThayMaSanPham = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                foreach (DataGridViewRow row in dgv_QuanLySanPham.Rows)
                {
                    if (row.Cells["MaSanPham"] != null && row.Cells["MaSanPham"].Value != null)
                    {
                        string maSanPhamRow = row.Cells["MaSanPham"].Value.ToString();
                        if (maSanPhamRow == maSanPham)
                        {
                            row.Selected = true;
                            dgv_QuanLySanPham.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_QuanLySanPham.Focus();
                            timThayMaSanPham = true;
                            break;
                        }
                    }
                }
                if (!timThayMaSanPham)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã " + maSanPham + "!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần tìm!!");
            }
        }
        private void timTheoTenSanPham()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TimKiem.Text.ToLower());
            string maSanPham = xoaKhoangTrang(titleCaseString);
            if (maSanPham.Length != 0)
            {
                bool timThayMaSanPham = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                foreach (DataGridViewRow row in dgv_QuanLySanPham.Rows)
                {
                    if (row.Cells["TenSanPham"] != null && row.Cells["TenSanPham"].Value != null)
                    {
                        string maSanPhamRow = row.Cells["TenSanPham"].Value.ToString();
                        if (maSanPhamRow == maSanPham)
                        {
                            row.Selected = true;
                            dgv_QuanLySanPham.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_QuanLySanPham.Focus();
                            timThayMaSanPham = true;
                            break;
                        }
                    }
                }
                if (!timThayMaSanPham)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có tên" + maSanPham + "!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!!");
            }
        }
        private void timTheoLoaiSanPham()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TimKiem.Text.ToLower());
            string loaiSanPham = xoaKhoangTrang(titleCaseString);
            if (loaiSanPham.Trim().Length != 0)
            {
                bool timThayLoaiSanPham = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                dgv_QuanLySanPham.Columns["LoaiSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLySanPham.Sort(dgv_QuanLySanPham.Columns["LoaiSanPham"], ListSortDirection.Ascending);
                foreach (DataGridViewRow row in dgv_QuanLySanPham.Rows)
                {
                    if (row.Cells["LoaiSanPham"] != null && row.Cells["LoaiSanPham"].Value != null)
                    {
                        string loaiSanPhamRow = row.Cells["LoaiSanPham"].Value.ToString();
                        if (loaiSanPham == loaiSanPhamRow)
                        {
                            row.Selected = true;
                            dgv_QuanLySanPham.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_QuanLySanPham.Focus();
                            timThayLoaiSanPham = true;
                            break;
                        }
                    }
                }
                if (!timThayLoaiSanPham)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có loại " + loaiSanPham);
                    dgv_QuanLySanPham.Columns["LoaiSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
                    dgv_QuanLySanPham.Sort(dgv_QuanLySanPham.Columns["LoaiSanPham"], ListSortDirection.Ascending);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập loại sản phẩm cần tìm kiếm");
            }
        }
        private void btn_Tim_Click_1(object sender, EventArgs e)
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
                    if (timKiemTheo == "MaSanPham")
                    {
                        timTheoMaSanPham();
                    }
                    if (timKiemTheo == "TenSanPham")
                    {
                        timTheoTenSanPham();
                    }
                    if (timKiemTheo == "LoaiSanPham")
                    {
                        timTheoLoaiSanPham();
                    }
                }
            }
        }
        private void btn_TaiLai_Click(object sender, EventArgs e)
        {
            load_grid();
            dgv_QuanLySanPham.Columns["MaSanPham"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgv_QuanLySanPham.Sort(dgv_QuanLySanPham.Columns["MaSanPham"], ListSortDirection.Ascending);

        }

        // Thực hiện chức năng thống kê
        private int thongKe(string loaiSanPham)
        {
            DataTable resultTable = ds_SanPham.Tables["SanPham"].Clone();
            DataRow[] rows = ds_SanPham.Tables["SanPham"].Select("LoaiSanPham LIKE '%" + loaiSanPham + "%'");

            foreach (DataRow row in rows)
            {
                resultTable.ImportRow(row); // sao chép các dòng này vào resultTable
            }
            if (resultTable.Rows.Count > 0)
            {
                dgv_QuanLySanPham.DataSource = resultTable;
                dataBinding();
                return 1;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
                return 0;
            }
        }
        private void rb_Pizza_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Pizza.Checked)
            {
                string thongKeTheo = "Pizza";
                thongKe(thongKeTheo);
            }
        }
        private void rb_ThucAnKem_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ThucAnKem.Checked)
            {
                int check = 0;

                // Kiểm tra thức ăn kèm
                DataTable resultTable = ds_SanPham.Tables["SanPham"].Clone();
                DataRow[] rows = ds_SanPham.Tables["SanPham"].Select("LoaiSanPham LIKE '%" + "Thức ăn kèm" + "%'");

                foreach (DataRow row in rows)
                {
                    resultTable.ImportRow(row); // sao chép các dòng này vào resultTable
                }
                if (resultTable.Rows.Count > 0)
                {
                    dgv_QuanLySanPham.DataSource = resultTable;
                    dataBinding();
                    check = 1;
                }

                // Kiểm tra tráng miệng
                DataRow[] rowss = ds_SanPham.Tables["SanPham"].Select("LoaiSanPham LIKE '%" + "Tráng miệng" + "%'");

                foreach (DataRow row in rowss)
                {
                    resultTable.ImportRow(row); // sao chép các dòng này vào resultTable
                }
                if (resultTable.Rows.Count > 0)
                {
                    dgv_QuanLySanPham.DataSource = resultTable;
                    dataBinding();
                    check = 1;
                }
                if (check == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu.");
                }
            }
        }

        private void rb_NuocUong_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_NuocUong.Checked)
            {
                string thongKeTheo = "Nước uống";
                thongKe(thongKeTheo);
            }
        }
        private void btn_GiamGia_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_GiamGia _Frm_GiamGia = new frm_GiamGia();
            _Frm_GiamGia.ShowDialog();
        }
    }
}
