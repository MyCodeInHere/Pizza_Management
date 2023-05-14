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
    public partial class frm_QuanLyNhanVien : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_NhanVien;
        DataSet ds_NhanVien;
        DataColumn[] key = new DataColumn[1];
        public frm_QuanLyNhanVien()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng NhanVien
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM NhanVien";
            da_NhanVien = new SqlDataAdapter(strSelect, cn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");

            // Thêm khóa chính 
            key[0] = ds_NhanVien.Tables["NhanVien"].Columns[0];
            ds_NhanVien.Tables["NhanVien"].PrimaryKey = key;
        }
        // Tải dữ liệu lên DataGridView.
        private void load_Grid()
        {
            dgv_ThongTinNhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
        }

        // Thiết kế giao diện cho DataGridView.
        private void thietKeTieuDeDGV()
        {
            if (dgv_ThongTinNhanVien != null && dgv_ThongTinNhanVien.ColumnCount > 0)
            {
                dgv_ThongTinNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                dgv_ThongTinNhanVien.Columns[1].HeaderText = "Chức vụ";
                dgv_ThongTinNhanVien.Columns[2].HeaderText = "Họ và tên";
                dgv_ThongTinNhanVien.Columns[3].HeaderText = "Giới tính";
                dgv_ThongTinNhanVien.Columns[4].HeaderText = "Ngày sinh";
                dgv_ThongTinNhanVien.Columns[5].HeaderText = "Địa chỉ";
                dgv_ThongTinNhanVien.Columns[6].HeaderText = "Số điện thoại";
                dgv_ThongTinNhanVien.Columns[7].HeaderText = "Email";
                dgv_ThongTinNhanVien.Columns[8].HeaderText = "CMND/CCCD";
                dgv_ThongTinNhanVien.Columns[9].HeaderText = "Ngày vào làm";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_ThongTinNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_ThongTinNhanVien.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_ThongTinNhanVien.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_ThongTinNhanVien.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // Định dạng ngày tháng năm ở dạng dd/MM/yyyy
                dgv_ThongTinNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_ThongTinNhanVien.Columns["NgayVaoLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        private string xoaKhoangTrang(string myString)
        {
            string pattern = "\\s+"; // Dấu \\s+ sẽ đại diện cho bất kỳ khoảng trắng nào (bao gồm cả dấu cách, tab và các ký tự xuống dòng)
            string replacement = " ";

            string result = Regex.Replace(myString, pattern, replacement).Trim();
            return result;
        }
        private void frm_QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            load_Grid();
            thietKeTieuDeDGV();
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }
        private int kiemTraChucVu()
        {
            // Kiểm tra chức vụ.
            if (coTrongKhong(cmb_ChucVu.Text) == false)
            {
                epd_ChucVu.Clear();
                return 1;
            }
            else
            {
                epd_ChucVu.SetError(cmb_ChucVu, "Bạn chưa nhập CHỨC VỤ!!!.");
                return 0;
            }
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
                epd_GioiTinh.SetError(cmb_GioiTinh, "Bạn chưa nhập GIỚI TÍNH!!!.");
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
        private Boolean kiemTraDaNhapDayDuThongTin()
        {
            int chucVu = kiemTraChucVu();
            int hoVaTen = kiemTraHoVaTen();
            int gioiTinh = kiemTraGioiTinh();
            int soDienThoai = kiemTraSoDienThoai();
            int daNhapDayDuThongTin = chucVu + hoVaTen + gioiTinh + soDienThoai;

            if (daNhapDayDuThongTin == 4)
                return true;
            return false;
        }
        private Boolean kiemTraThongTinNhanVienDaCo()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();
            // Kiểm tra thông tin nhân viên đã có trong hệ thống hay chưa.
            String strQuery = "Select * from NhanVien where HoVaTen=N'" + txt_HoVaTen.Text.Trim() + "' and GioiTinh=N'" + cmb_GioiTinh.Text.Trim() + "' and NgaySinh='"+ dtp_NgaySinh.Value.ToString()+"'";
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

        // Phát sinh Id tự động. 
        private string getID(string prefix, int length, int startingNumber, int currentValue)
        {
            int number = currentValue + 1;
            string idNumber = number.ToString().PadLeft(length - prefix.Length, '0');
            string id = prefix + idNumber;
            return id;
        }

        // Kiểm tra mã tài khoản đã tồn tại chưa.
        private Boolean check_MaNhanVien(string id)
        {
            // Kết nối CSDL.
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            string selectQuery = "Select MaNhanVien from NhanVien where MaNhanVien ='" + id + "'";
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
            string countQuery = "SELECT COUNT(*) FROM NhanVien";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("NV", 5, 1, count);

            // Kiểm tra xem tài mã tài khoản đã tồn tại chưa.
            Boolean check = true;
            while (check == true)
            {
                if (check_MaNhanVien(id) == false)
                {
                    check = false;
                }
                else
                {
                    count++;
                    id = getID("NV", 5, 1, count);
                }
            }

            cn.Close();
            return id;
        }
        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            if(kiemTraDaNhapDayDuThongTin() == true)
            {
                if(kiemTraThongTinNhanVienDaCo() == true)
                {
                    DialogResult r;
                    r = MessageBox.Show("Bạn có chắc muốn thêm nhân viên này!", "NHÂN VIÊN ĐÃ TỒN TẠI",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (r == DialogResult.OK)
                    {
                        // Tạo một dòng dữ liệu mới.
                        DataRow newRow = ds_NhanVien.Tables[0].NewRow();
                        // Thêm mã nhân viên
                        newRow["MaNhanVien"] = get_MaTaiKhoan();
                        // Thêm chức vụ
                        if (cmb_ChucVu.Text == "Nhân Viên")
                        {
                            newRow["ChucVu"] = "Nhân Viên";
                        }
                        else
                        {
                            newRow["ChucVu"] = "Quản Lý";
                        }
                        // Thêm họ tên nhân viên
                        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                        string titleCaseString = textInfo.ToTitleCase(txt_HoVaTen.Text.ToLower());
                        newRow["HoVaTen"] = xoaKhoangTrang(titleCaseString);
                        // Thêm giới tính nhân viên
                        if (cmb_GioiTinh.Text == "Nam")
                        {
                            newRow["GioiTinh"] = "Nam";
                        }
                        else
                        {
                            newRow["GioiTinh"] = "Nữ";
                        }
                        // Thêm ngày sinh nhân viên
                        newRow["NgaySinh"] = dtp_NgaySinh.Value.ToString("yyyy/MM/dd");
                        // Thêm địa chỉ nhân viên
                        TextInfo textInfom = CultureInfo.CurrentCulture.TextInfo;
                        string titleCaseStrings = textInfom.ToTitleCase(txt_DiaChi.Text.ToLower());
                        newRow["DiaChi"] = xoaKhoangTrang(titleCaseStrings);
                        // Thêm số điện thoại cho nhân viên
                        newRow["SoDienThoai"] = txt_SoDienThoai.Text;
                        // Thêm email cho nhân viên
                        newRow["Email"] = txt_Email.Text;
                        // Thêm cmnd/cccd cho nhân viên
                        newRow["CMND"] = txt_CMND.Text;
                        // Thêm ngày vào làm cho nhân viên
                        newRow["NgayVaoLam"] = dtp_NgayVaoLam.Value.ToString("yyyy/MM/dd");
                        // Thêm dòng dữ liệu vào DataSet.
                        ds_NhanVien.Tables[0].Rows.Add(newRow);
                        // Cập nhật trong cơ sở dữ liệu.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_NhanVien);
                        // Cập nhật trong DataSet.
                        da_NhanVien.Update(ds_NhanVien, "NhanVien");

                        MessageBox.Show("Thêm nhân viên thành công!!");
                        // Xóa Combobox
                        txt_MaNhanVien.Clear();
                        cmb_ChucVu.SelectedIndex = -1;
                        txt_HoVaTen.Clear();
                        cmb_GioiTinh.SelectedIndex = -1;
                        txt_DiaChi.Clear();
                        txt_SoDienThoai.Clear();
                        txt_Email.Clear();
                        txt_CMND.Clear();
                    }
                }
                else
                {
                    // Tạo một dòng dữ liệu mới.
                    DataRow newRow = ds_NhanVien.Tables[0].NewRow();
                    // Thêm mã nhân viên
                    newRow["MaNhanVien"] = get_MaTaiKhoan();
                    // Thêm chức vụ
                    if (cmb_ChucVu.Text == "Nhân Viên")
                    {
                        newRow["ChucVu"] = "Nhân Viên";
                    }
                    else
                    {
                        newRow["ChucVu"] = "Quản Lý";
                    }
                    // Thêm họ tên nhân viên
                    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                    string titleCaseString = textInfo.ToTitleCase(txt_HoVaTen.Text.ToLower());
                    newRow["HoVaTen"] = xoaKhoangTrang(titleCaseString);
                    // Thêm giới tính nhân viên
                    if (cmb_GioiTinh.Text == "Nam")
                    {
                        newRow["GioiTinh"] = "Nam";
                    }
                    else
                    {
                        newRow["GioiTinh"] = "Nữ";
                    }
                    // Thêm ngày sinh nhân viên
                    newRow["NgaySinh"] = dtp_NgaySinh.Value.ToString("yyyy/MM/dd");
                    // Thêm địa chỉ nhân viên
                    TextInfo textInfos = CultureInfo.CurrentCulture.TextInfo;
                    string titleCaseStrings = textInfos.ToTitleCase(txt_DiaChi.Text.ToLower());
                    newRow["DiaChi"] = xoaKhoangTrang(titleCaseStrings);
                    // Thêm số điện thoại cho nhân viên
                    newRow["SoDienThoai"] = txt_SoDienThoai.Text;
                    // Thêm email cho nhân viên
                    newRow["Email"] = txt_Email.Text;
                    // Thêm cmnd/cccd cho nhân viên
                    newRow["CMND"] = txt_CMND.Text;
                    // Thêm ngày vào làm cho nhân viên
                    newRow["NgayVaoLam"] = dtp_NgayVaoLam.Value.ToString("yyyy/MM/dd");
                    // Thêm dòng dữ liệu vào DataSet.
                    ds_NhanVien.Tables[0].Rows.Add(newRow);
                    // Cập nhật trong cơ sở dữ liệu.
                    SqlCommandBuilder cB = new SqlCommandBuilder(da_NhanVien);
                    // Cập nhật trong DataSet.
                    da_NhanVien.Update(ds_NhanVien, "NhanVien");

                    MessageBox.Show("Thêm nhân viên thành công!!");
                    // Xóa Combobox
                    txt_MaNhanVien.Clear();
                    cmb_ChucVu.SelectedIndex = -1;
                    txt_HoVaTen.Clear();
                    cmb_GioiTinh.SelectedIndex = -1;
                    txt_DiaChi.Clear();
                    txt_SoDienThoai.Clear();
                    txt_Email.Clear();
                    txt_CMND.Clear();
                }
            }
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Home newFrm_Home = new frm_Home();
            newFrm_Home.ShowDialog();
        }
        private void btn_TaiKhoanNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_TaiKhoanNhanVien _Frm_TaiKhoanNhanVien = new frm_TaiKhoanNhanVien();
            _Frm_TaiKhoanNhanVien.ShowDialog();
        }

        private void btn_SaThaiNhanVien_Click(object sender, EventArgs e)
        {
            if (txt_MaNhanVien.Text.Trim().Length != 0)
            {
                DialogResult r;

                r = MessageBox.Show("Bạn có CHẮC là muốn xóa nhân viên này?", "XÓA NHÂN VIÊN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Nếu đồng ý thì sẽ thực hiện việc xóa nhân viên.
                if (r == DialogResult.Yes)
                {
                    // Tìm dòng dữ liệu có mã nhân viên trùng với mã nhân viên trong combobox.
                    DataRow dr = ds_NhanVien.Tables["NhanVien"].Rows.Find(txt_MaNhanVien.Text);

                    // Xóa dòng dữ liệu vừa tìm được.
                    if (dr != null)
                    {
                        dr.Delete();
                        // Cập nhật trong CSDL.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_NhanVien);
                        // Cập nhật trong DataSet.
                        da_NhanVien.Update(ds_NhanVien, "NhanVien");
                        // Thông báo đã xóa thành công
                        MessageBox.Show("Đã xóa nhân viên thành công!", "XÓA NHÂN VIÊN THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xoaThongTin();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên này!", "XÓA NHÂN VIÊN KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn nhân viên để xóa!!!");
            }
        }

        private void btn_CapNhapThongTinNhanVien_Click(object sender, EventArgs e)
        {
            if (txt_MaNhanVien.Text.Trim().Length != 0)
            {
                if (kiemTraThongTinNhanVienDaCo() == true)
                {
                    string tenNhanVien = dgv_ThongTinNhanVien.SelectedRows[0].Cells["HoVaTen"].Value.ToString();
                    if (txt_HoVaTen.Text == tenNhanVien)
                    {
                        DialogResult r;

                        r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin nhân viên này?", "CẬP NHẬT THÔNG TIN NHÂN VIÊN", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                        // Nếu đồng ý thì sẽ thực hiện việc cập nhật nhân viên.
                        if (r == DialogResult.Yes)
                        {
                            DataRow dr = ds_NhanVien.Tables["NhanVien"].Rows.Find(txt_MaNhanVien.Text);

                            if (dr != null)
                            {
                                dr["ChucVu"] = cmb_ChucVu.Text;
                                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                                string titleCaseString = textInfo.ToTitleCase(txt_HoVaTen.Text.ToLower());
                                dr["HoVaTen"] = xoaKhoangTrang(titleCaseString);
                                dr["NgaySinh"] = dtp_NgaySinh.Value.ToString("yyyy/MM/dd");
                                dr["GioiTinh"] = cmb_GioiTinh.Text;
                                dr["SoDienThoai"] = txt_SoDienThoai.Text;
                                TextInfo textInfom = CultureInfo.CurrentCulture.TextInfo;
                                string titleCaseStrings = textInfom.ToTitleCase(txt_DiaChi.Text.ToLower());
                                dr["DiaChi"] = xoaKhoangTrang(titleCaseStrings);
                                dr["Email"] = txt_Email.Text;
                                dr["CMND"] = txt_CMND.Text;
                                dr["NgayVaoLam"] = dtp_NgayVaoLam.Value.ToString("yyyy/MM/dd");
                            }

                            SqlCommandBuilder cB = new SqlCommandBuilder(da_NhanVien);
                            da_NhanVien.Update(ds_NhanVien, "NhanVien");

                            MessageBox.Show("Cập nhật thành công!");
                        }
                    }
                }
                else
                {
                    DialogResult r;

                    r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin nhân viên này?", "CẬP NHẬT THÔNG TIN NHÂN VIÊN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    // Nếu đồng ý thì sẽ thực hiện việc cập nhật nhân viên.
                    if (r == DialogResult.Yes)
                    {
                        DataRow dr = ds_NhanVien.Tables["NhanVien"].Rows.Find(txt_MaNhanVien.Text);

                        if (dr != null)
                        {
                            dr["ChucVu"] = cmb_ChucVu.Text;
                            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                            string titleCaseString = textInfo.ToTitleCase(txt_HoVaTen.Text.ToLower());
                            dr["HoVaTen"] = xoaKhoangTrang(titleCaseString);
                            dr["NgaySinh"] = dtp_NgaySinh.Value.ToString("yyyy/MM/dd");
                            dr["GioiTinh"] = cmb_GioiTinh.Text;
                            dr["SoDienThoai"] = txt_SoDienThoai.Text;
                            TextInfo textInfom = CultureInfo.CurrentCulture.TextInfo;
                            string titleCaseStrings = textInfom.ToTitleCase(txt_DiaChi.Text.ToLower());
                            dr["DiaChi"] = xoaKhoangTrang(titleCaseStrings);
                            dr["Email"] = txt_Email.Text;
                            dr["CMND"] = txt_CMND.Text;
                            dr["NgayVaoLam"] = dtp_NgayVaoLam.Value.ToString("yyyy/MM/dd");
                        }

                        SqlCommandBuilder cB = new SqlCommandBuilder(da_NhanVien);
                        da_NhanVien.Update(ds_NhanVien, "NhanVien");

                        MessageBox.Show("Cập nhật thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần chọn nhân viên muốn sửa thông tin!!!");
            }
        }
        private void dataBinding()
        {
            // Thực hiện binding cho txt_MaNhanVien
            string maNhanVien = dgv_ThongTinNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();
            txt_MaNhanVien.Text = maNhanVien;
            // Thực hiện biding cho txt_HoVaTen
            string hoTen = dgv_ThongTinNhanVien.SelectedRows[0].Cells["HoVaTen"].Value.ToString();
            txt_HoVaTen.Text = hoTen;
            // Thực hiện biding cho txt_SoDienThoai
            string soDienThoai = dgv_ThongTinNhanVien.SelectedRows[0].Cells["SoDienThoai"].Value.ToString();
            txt_SoDienThoai.Text = soDienThoai;
            // Thực hiện biding cho txt_CMND
            string cmnd = dgv_ThongTinNhanVien.SelectedRows[0].Cells["CMND"].Value.ToString();
            txt_CMND.Text = cmnd;
            // Thực hiện biding cho txt_DiaChi
            string diaChi = dgv_ThongTinNhanVien.SelectedRows[0].Cells["DiaChi"].Value.ToString();
            txt_DiaChi.Text = diaChi;
            // Thực hiện biding cho txt_Email
            string email = dgv_ThongTinNhanVien.SelectedRows[0].Cells["Email"].Value.ToString();
            txt_Email.Text = email;
            // Thực hiện binding cho cmb_ChucVu
            string chucVu = dgv_ThongTinNhanVien.SelectedRows[0].Cells["ChucVu"].Value.ToString();
            if (chucVu == "Nhân Viên")
            {
                cmb_ChucVu.SelectedIndex = 1;
            }
            else if (chucVu.Trim() == "Quản Lý")
            {
                cmb_ChucVu.SelectedIndex = 0;
            }
            else
            {
                cmb_ChucVu.SelectedIndex = -1;
            }
            // Thực hiện binding cho cmb_GioiTinh
            string gioiTinh = dgv_ThongTinNhanVien.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
            if (gioiTinh == "Nam")
            {
                cmb_GioiTinh.SelectedIndex = 0;
            }
            else if (gioiTinh == "Nữ")
            {
                cmb_GioiTinh.SelectedIndex = 1;
            }
            else
            {
                cmb_GioiTinh.SelectedIndex = -1;
            }
            // Thực hiện binding cho dtp_NgaySinh
            string ngaySinh = dgv_ThongTinNhanVien.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
            if (ngaySinh.Trim().Length != 0)
            {
                DateTime ngaySinhDT = Convert.ToDateTime(dgv_ThongTinNhanVien.SelectedRows[0].Cells["NgaySinh"].Value);
                dtp_NgaySinh.Value = ngaySinhDT;
            }
            // Thực hiện binding cho dtp_NgayVaoLam
            string ngayVL = dgv_ThongTinNhanVien.SelectedRows[0].Cells["NgayVaoLam"].Value.ToString();
            if (ngayVL.Trim().Length != 0)
            {
                DateTime ngayVaoLam = Convert.ToDateTime(dgv_ThongTinNhanVien.SelectedRows[0].Cells["NgayVaoLam"].Value);
                dtp_NgayVaoLam.Value = ngayVaoLam;
            }
        }
        private void dgv_ThongTinNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBinding();
        }
        private void xoaThongTin()
        {
            txt_MaNhanVien.Clear();
            cmb_ChucVu.SelectedIndex = -1;
            txt_HoVaTen.Clear();
            cmb_GioiTinh.SelectedIndex = -1;
            txt_DiaChi.Clear();
            txt_SoDienThoai.Clear();
            txt_Email.Clear();
            txt_CMND.Clear();
        }
        private void btn_XoaThongTin_Click(object sender, EventArgs e)
        {
            xoaThongTin();
            txt_HoVaTen.Focus();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            dgv_ThongTinNhanVien.Columns["MaNhanVien"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgv_ThongTinNhanVien.Sort(dgv_ThongTinNhanVien.Columns["MaNhanVien"], ListSortDirection.Ascending);
            txt_TimKiem.Clear();
            dgv_ThongTinNhanVien.Focus();
        }

        // Thực hiện chức năng tìm kiếm 
        private static string timKiemTheo = "";
        private static int checkClick = 0;
        private void rb_MaNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_MaNhanVien.Checked)
            {
                timKiemTheo = "MaNhanVien";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }

        private void rb_HoVaTen_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_HoVaTen.Checked)
            {
                timKiemTheo = "HoVaTen";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private int kiemTraChuoi(string str)
        {
            if (str.Contains("nv"))
            {
                return 1;
            }
            else if (str.Contains("NV"))
            {
                return 1;
            }
            else if (str.Contains("Nv"))
            {
                return 1;
            }
            else if (str.Contains("nV"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
            return 0;
        }
        // Thực hiện tìm kiếm theo mã nhân viên
        private void timTheoMaNhanVien()
        {
            string maNhanVien = txt_TimKiem.Text;
            if (maNhanVien.Trim().Length !=0)
            {
                if (kiemTraChuoi(maNhanVien) == 1)
                {
                    maNhanVien = maNhanVien.ToUpper();
                    bool timThayNhanVien = false;
                    // Lặp qua các dòng của DataGridView để tìm kiếm
                    foreach (DataGridViewRow row in dgv_ThongTinNhanVien.Rows)
                    {
                        if (row.Cells["MaNhanVien"] != null && row.Cells["MaNhanVien"].Value != null)
                        {
                            string maNhanVienRow = row.Cells["MaNhanVien"].Value.ToString();
                            if (maNhanVienRow == maNhanVien)
                            {
                                row.Selected = true;
                                dgv_ThongTinNhanVien.CurrentCell = row.Cells[0];
                                dataBinding();
                                dgv_ThongTinNhanVien.Focus();
                                timThayNhanVien = true;
                                break;
                            }
                        }
                    }
                    if (!timThayNhanVien)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên có mã " + maNhanVien);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên có mã " + maNhanVien);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần tìm kiếm");
            }
        }
        // Thực hiện tìm kiếm theo mã nhân viên
        private void timKiemTheoHoTenNhanVien()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TimKiem.Text.ToLower());
            string hoTen = titleCaseString;
            if (hoTen.Trim().Length != 0)
            {
                bool timThayNhanVien = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                dgv_ThongTinNhanVien.Columns["HoVaTen"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_ThongTinNhanVien.Sort(dgv_ThongTinNhanVien.Columns["HoVaTen"], ListSortDirection.Ascending);
                foreach (DataGridViewRow row in dgv_ThongTinNhanVien.Rows)
                {
                    if (row.Cells["HoVaTen"] != null && row.Cells["HoVaTen"].Value != null)
                    {
                        string hoVaTenRow = row.Cells["HoVaTen"].Value.ToString();
                        if (hoVaTenRow.Contains(hoTen))
                        {
                            row.Selected = true;
                            dgv_ThongTinNhanVien.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_ThongTinNhanVien.Focus();
                            timThayNhanVien = true;
                            break;
                        }
                    }
                }
                if (!timThayNhanVien)
                {
                    MessageBox.Show("Không tìm thấy nhân viên có tên " + hoTen);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên cần tìm kiếm");
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
                    if (timKiemTheo == "MaNhanVien")
                    {
                        timTheoMaNhanVien();
                    }
                    if (timKiemTheo == "HoVaTen")
                    {
                        timKiemTheoHoTenNhanVien();
                    }
                }
            }
        }
        /*private void dgv_ThongTinNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ThongTinNhanVien.SelectedRows != null && dgv_ThongTinNhanVien.SelectedRows.Count > 0)
            {
                dataBinding();
            }
        }*/
    }
}
