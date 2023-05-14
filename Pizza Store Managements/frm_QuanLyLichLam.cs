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
    public partial class frm_QuanLyLichLam : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_LichLam;
        DataSet ds_LichLam;
        DataColumn[] key = new DataColumn[1];
        private frm_Home _frmHome;
        public frm_QuanLyLichLam()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng lịch làm
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM LichLam";
            da_LichLam = new SqlDataAdapter(strSelect, cn);
            ds_LichLam = new DataSet();
            da_LichLam.Fill(ds_LichLam, "LichLam");

            // Thêm khóa chính 
            key[0] = ds_LichLam.Tables["LichLam"].Columns[0];
            ds_LichLam.Tables["LichLam"].PrimaryKey = key;

            _frmHome = new frm_Home();
        }
        private void KiemTraButton(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl is Button)
                {
                    if (ctl.Name == "btn_ThemLichLam" || ctl.Name == "btn_CapNhatLichLam" || ctl.Name == "btn_XoaLichLam")
                    {
                        ctl.Enabled = false;
                    }
                }
            }
        }
        private void choPhepTruyCapLichLam()
        {
            if (_frmHome != null)
            {
                // Gọi phương thức setStatusStrip của form cha để lấy giá trị trong sts_NguoiDung của form cha
                string giaTri = _frmHome.setStatusStrip();
                if (giaTri == "Nhân Viên") {
                    KiemTraButton(this);
                }
            }
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Home _Frm_Home = new frm_Home();
            _Frm_Home.ShowDialog();
        }

        // Thiết kế giao diện cho DataGridView.
        private void thietKeTieuDeDGV()
        {
            if (dgv_QuanLyLichLam != null && dgv_QuanLyLichLam.ColumnCount > 0)
            {
                dgv_QuanLyLichLam.Columns[0].HeaderText = "Mã lịch làm";
                dgv_QuanLyLichLam.Columns[1].HeaderText = "Mã nhân viên";
                dgv_QuanLyLichLam.Columns[2].HeaderText = "Họ và tên";
                dgv_QuanLyLichLam.Columns[3].HeaderText = "Ca làm";
                dgv_QuanLyLichLam.Columns[4].HeaderText = "Vị trí làm";
                dgv_QuanLyLichLam.Columns[5].HeaderText = "Ngày làm";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_QuanLyLichLam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_QuanLyLichLam.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_QuanLyLichLam.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_QuanLyLichLam.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                dgv_QuanLyLichLam.Columns["MaLichLam"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLyLichLam.Sort(dgv_QuanLyLichLam.Columns["MaLichLam"], ListSortDirection.Ascending);
            }
        }
        private void load_Combobox()
        {
            SqlConnection cn;
            SqlDataAdapter da_NhanVien;
            DataSet ds_NhanVien;
            DataColumn[] key = new DataColumn[1];

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng NhanVien
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM NhanVien";
            da_NhanVien = new SqlDataAdapter(strSelect, cn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");

            cmb_HoTenNhanVien.DataSource = ds_NhanVien.Tables["NhanVien"];
            cmb_HoTenNhanVien.DisplayMember = "HoVaTen";
            cmb_HoTenNhanVien.ValueMember = "HoVaTen";

            txt_MaNhanVien.Clear();
            cmb_HoTenNhanVien.SelectedIndex = -1;
        }
        private void cmb_HoTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn;
            SqlDataAdapter da_NhanVien;
            DataSet ds_NhanVien;
            DataColumn[] key = new DataColumn[1];

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng NhanVien
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM NhanVien";
            da_NhanVien = new SqlDataAdapter(strSelect, cn);
            ds_NhanVien = new DataSet();
            da_NhanVien.Fill(ds_NhanVien, "NhanVien");

            // Tìm kiếm tên nhân viên trong DataTable
            string tenNhanVien = cmb_HoTenNhanVien.Text;
            DataRow row = ds_NhanVien.Tables["NhanVien"].AsEnumerable().FirstOrDefault(r => r.Field<string>("HoVaTen") == tenNhanVien);

            // Kiểm tra xem có tìm thấy hay không
            if (row != null)
            {
                // Lấy mã nhân viên tương ứng
                string maNhanVien = row["MaNhanVien"].ToString();
                txt_MaNhanVien.Text = maNhanVien;
            }
        }
        private void load_Grid()
        {
            dgv_QuanLyLichLam.DataSource = ds_LichLam.Tables["LichLam"];
            thietKeTieuDeDGV();
            load_Combobox();
            choPhepTruyCapLichLam();
        }
        private void frm_QuanLyLichLam_Load(object sender, EventArgs e)
        {
            load_Grid();
            load_Combobox();
        }

        // Kiểm tra ô văn bản có trống hay không. Nếu có trả về true, không trả về false.
        private Boolean coTrongKhong(String str)
        {
            if (str.Trim().Length != 0)
                return false;
            return true;
        }
        private int kiemTraHoTen()
        {
            if (coTrongKhong(cmb_HoTenNhanVien.Text) == false)
            {
                epd_HoVaTen.Clear();
                return 1;
            }
            else
            {
                epd_HoVaTen.SetError(cmb_HoTenNhanVien, "Bạn chưa nhập HỌ TÊN NHÂN VIÊN!!!.");
                return 0;
            }
        }
        private int kiemTraCaLam()
        {
            if (coTrongKhong(cmb_CaTruc.Text) == false)
            {
                epd_CaLam.Clear();
                return 1;
            }
            else
            {
                epd_CaLam.SetError(cmb_CaTruc, "Bạn chưa nhập CA LÀM!!!.");
                return 0;
            }
        }
        private int kiemTraViTriLam()
        {
            if (coTrongKhong(cmb_ViTriLamViec.Text) == false)
            {
                epd_ViTriLamViec.Clear();
                return 1;
            }
            else
            {
                epd_ViTriLamViec.SetError(cmb_ViTriLamViec, "Bạn chưa nhập VỊ TRÍ LÀM!!!.");
                return 0;
            }
        }
        private int kiemTraDaDuThongTin()
        {
            int hoTen = kiemTraHoTen();
            int caLam = kiemTraCaLam();
            int viTri = kiemTraViTriLam();
            int daDu = hoTen + caLam + viTri;
            if (daDu == 3)
            {
                return 1;
            }
            return 0;
        }
        private Boolean kiemTraThongTinDaCo()
        {
            SqlConnection cn = new SqlConnection();
            String strConn = "Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True";
            cn.ConnectionString = strConn;
            cn.Open();

            String strQuery = "Select * from LichLam where HoVaTen=N'" + cmb_HoTenNhanVien.Text.Trim() + "' and CaLam=N'" + cmb_CaTruc.Text.Trim() + "' and ViTriLam=N'" + cmb_ViTriLamViec.Text.Trim() + "' and NgayLam = '" + dtp_NgayLam.Value.ToString() + "'";
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

            string selectQuery = "Select MaLichLam from LichLam where MaLichLam ='" + id + "'";
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

            string countQuery = "SELECT COUNT(*) FROM LichLam";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("LL", 5, 1, count);

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
                    id = getID("LL", 5, 1, count);
                }
            }

            cn.Close();
            return id;
        }
        private void themLichLam()
        {
            // Tạo một dòng dữ liệu mới.
            DataRow newRow = ds_LichLam.Tables[0].NewRow();
            // Thêm mã nhân viên
            newRow["MaLichLam"] = get_MaTaiKhoan();
            newRow["MaNhanVien"] = txt_MaNhanVien.Text;
            newRow["HoVaTen"] = cmb_HoTenNhanVien.Text;
            newRow["CaLam"] = cmb_CaTruc.Text;
            newRow["ViTriLam"] = cmb_ViTriLamViec.Text;
            newRow["NgayLam"] = dtp_NgayLam.Value.ToString("yyyy/MM/dd");

            ds_LichLam.Tables[0].Rows.Add(newRow);
            // Cập nhật trong cơ sở dữ liệu.
            SqlCommandBuilder cB = new SqlCommandBuilder(da_LichLam);
            // Cập nhật trong DataSet.
            da_LichLam.Update(ds_LichLam, "LichLam");

            MessageBox.Show("Thêm lịch làm thành công!!");

            txt_MaLichLam.Clear();
            txt_MaNhanVien.Clear();
            cmb_ViTriLamViec.SelectedIndex = -1;
            cmb_HoTenNhanVien.SelectedIndex = -1;
            cmb_CaTruc.SelectedIndex = -1;
        }
        private void btn_ThemLichLam_Click(object sender, EventArgs e)
        {
            if (kiemTraDaDuThongTin() == 1)
            {
                if (kiemTraThongTinDaCo() == false)
                {
                    themLichLam();
                }
                else
                {
                    MessageBox.Show("Lịch làm việc này đã có, không thể thêm!!!", "LỊCH LÀM BỊ TRÙNG", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                }

            }
        }
        private void dataBinding()
        {
            string maLichLam = dgv_QuanLyLichLam.SelectedRows[0].Cells["MaLichLam"].Value.ToString();
            txt_MaLichLam.Text = maLichLam;

            string maNhanVien = dgv_QuanLyLichLam.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();
            txt_MaNhanVien.Text = maNhanVien;

            string hoTen = dgv_QuanLyLichLam.SelectedRows[0].Cells["HoVaTen"].Value.ToString();
            cmb_HoTenNhanVien.Text = hoTen;

            string viTri = dgv_QuanLyLichLam.SelectedRows[0].Cells["ViTriLam"].Value.ToString();
            cmb_ViTriLamViec.Text = viTri;

            string caLam = dgv_QuanLyLichLam.SelectedRows[0].Cells["CaLam"].Value.ToString();
            cmb_CaTruc.Text = caLam;

            string ngayLam = dgv_QuanLyLichLam.SelectedRows[0].Cells["NgayLam"].Value.ToString();
            if (ngayLam.Trim().Length != 0)
            {
                DateTime ngayLams = Convert.ToDateTime(dgv_QuanLyLichLam.SelectedRows[0].Cells["NgayLam"].Value);
                dtp_NgayLam.Value = ngayLams;
            }
        }

        private void dgv_QuanLyLichLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBinding();
        }
        private void btn_XoaLichLam_Click(object sender, EventArgs e)
        {
            if (txt_MaNhanVien.Text.Trim().Length != 0)
            {
                DialogResult r;

                r = MessageBox.Show("Bạn có CHẮC là muốn lịch làm này?", "XÓA LỊCH LÀM", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Nếu đồng ý thì sẽ thực hiện việc xóa nhân viên.
                if (r == DialogResult.Yes)
                {
                    // Tìm dòng dữ liệu có mã nhân viên trùng với mã nhân viên trong combobox.
                    DataRow dr = ds_LichLam.Tables["LichLam"].Rows.Find(txt_MaLichLam.Text);

                    // Xóa dòng dữ liệu vừa tìm được.
                    if (dr != null)
                    {
                        dr.Delete();
                        // Cập nhật trong CSDL.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_LichLam);
                        // Cập nhật trong DataSet.
                        da_LichLam.Update(ds_LichLam, "LichLam");
                        // Thông báo đã xóa thành công
                        MessageBox.Show("Đã xóa lịch làm thành công!", "XÓA LỊCH LÀM THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_MaLichLam.Clear();
                        txt_MaNhanVien.Clear();
                        cmb_CaTruc.SelectedIndex = -1;
                        cmb_HoTenNhanVien.SelectedIndex = -1;
                        cmb_ViTriLamViec.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy LỊCH LÀM này!", "XÓA LỊCH LÀM KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn LỊCH LÀM để XÓA!!!");
            }
        }
        private void btn_XoaThongTin_Click(object sender, EventArgs e)
        {
            txt_MaLichLam.Clear();
            txt_MaNhanVien.Clear();
            cmb_CaTruc.SelectedIndex = -1;
            cmb_HoTenNhanVien.SelectedIndex = -1;
            cmb_ViTriLamViec.SelectedIndex = -1;
        }
        private void btn_CapNhatLichLam_Click(object sender, EventArgs e)
        {
            if (txt_MaLichLam.Text.Trim().Length != 0)
            {
                if (kiemTraDaDuThongTin() == 1)
                {
                    if (kiemTraThongTinDaCo() == false)
                    {
                        DialogResult r;

                        r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin sản phẩm này?", "CẬP NHẬT THÔNG TIN LỊCH LÀM VIỆC", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                        // Nếu đồng ý thì sẽ thực hiện việc cập nhật nhân viên.
                        if (r == DialogResult.Yes)
                        {
                            DataRow dr = ds_LichLam.Tables["LichLam"].Rows.Find(txt_MaLichLam.Text);

                            if (dr != null)
                            {
                                dr["HoVaTen"] = cmb_HoTenNhanVien.Text;
                                dr["CaLam"] = cmb_CaTruc.Text;
                                dr["ViTriLam"] = cmb_ViTriLamViec.Text;
                                dr["NgayLam"] = dtp_NgayLam.Value.ToString("yyyy/MM/dd");
                            }
                            SqlCommandBuilder cB = new SqlCommandBuilder(da_LichLam);
                            da_LichLam.Update(ds_LichLam, "LichLam");

                            MessageBox.Show("Cập nhật thành công!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lịch làm đã tồn tại", "KHÔNG THỂ CẬP NHẬT LỊCH NÀY", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn LỊCH LÀM để CẬP NHẬT!!!");
            }
        }

        // Thực hiện chức năng tìm kiếm 
        private static string timKiemTheo = "";
        private static int checkClick = 0;
        private void rb_MaLichLam_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_MaLichLam.Checked)
            {
                timKiemTheo = "MaLichLam";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void rb_MaNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_MaNhanVien.Checked)
            {
                timKiemTheo = "MaNhanVien";
                checkClick = 1;
                txt_TimKiem.Clear();
            }
        }
        private void rb_TenNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_TenNhanVien.Checked)
            {
                timKiemTheo = "TenNhanVien";
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
                    if (timKiemTheo == "MaLichLam")
                    {
                        timTheoMaLichLam();
                    }
                    if (timKiemTheo == "MaNhanVien")
                    {
                        timKiemTheoMaNhanVien();
                    }
                    if (timKiemTheo == "TenNhanVien")
                    {
                       timKiemTheoTenNhanVien();
                    }
                }
            }
        }
        private void timKiemTheoTenNhanVien()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(txt_TimKiem.Text.ToLower());
            string hoTen = titleCaseString;
            if (hoTen.Trim().Length != 0)
            {
                bool timThayNhanVien = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                dgv_QuanLyLichLam.Columns["HoVaTen"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLyLichLam.Sort(dgv_QuanLyLichLam.Columns["HoVaTen"], ListSortDirection.Ascending);
                foreach (DataGridViewRow row in dgv_QuanLyLichLam.Rows)
                {
                    if (row.Cells["HoVaTen"] != null && row.Cells["HoVaTen"].Value != null)
                    {
                        string hoVaTenRow = row.Cells["HoVaTen"].Value.ToString();
                        if (hoVaTenRow.Contains(hoTen))
                        {
                            row.Selected = true;
                            dgv_QuanLyLichLam.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_QuanLyLichLam.Focus();
                            timThayNhanVien = true;
                            break;
                        }
                    }
                }
                if (!timThayNhanVien)
                {
                    MessageBox.Show("Không tìm thấy nhân viên có tên: " + hoTen+" trong lịch làm!!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên cần tìm kiếm!!");
            }
        }
        private void timKiemTheoMaNhanVien()
        {
            string hoTen = txt_TimKiem.Text.ToUpper();
            if (hoTen.Trim().Length != 0)
            {
                bool timThayNhanVien = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                dgv_QuanLyLichLam.Columns["MaNhanVien"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLyLichLam.Sort(dgv_QuanLyLichLam.Columns["MaNhanVien"], ListSortDirection.Ascending);
                foreach (DataGridViewRow row in dgv_QuanLyLichLam.Rows)
                {
                    if (row.Cells["MaNhanVien"] != null && row.Cells["MaNhanVien"].Value != null)
                    {
                        string hoVaTenRow = row.Cells["MaNhanVien"].Value.ToString();
                        if (hoVaTenRow.Contains(hoTen))
                        {
                            row.Selected = true;
                            dgv_QuanLyLichLam.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_QuanLyLichLam.Focus();
                            timThayNhanVien = true;
                            break;
                        }
                    }
                }
                if (!timThayNhanVien)
                {
                    MessageBox.Show("Không tìm thấy lịch làm có mã nhân viên: " + hoTen);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần tìm kiếm!!");
            }
        }
        private void timTheoMaLichLam()
        {
            string hoTen = txt_TimKiem.Text.ToUpper();
            if (hoTen.Trim().Length != 0)
            {
                bool timThayNhanVien = false;
                // Lặp qua các dòng của DataGridView để tìm kiếm
                dgv_QuanLyLichLam.Columns["MaLichLam"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_QuanLyLichLam.Sort(dgv_QuanLyLichLam.Columns["MaLichLam"], ListSortDirection.Ascending);
                foreach (DataGridViewRow row in dgv_QuanLyLichLam.Rows)
                {
                    if (row.Cells["MaLichLam"] != null && row.Cells["MaLichLam"].Value != null)
                    {
                        string hoVaTenRow = row.Cells["MaLichLam"].Value.ToString();
                        if (hoVaTenRow.Contains(hoTen))
                        {
                            row.Selected = true;
                            dgv_QuanLyLichLam.CurrentCell = row.Cells[0];
                            dataBinding();
                            dgv_QuanLyLichLam.Focus();
                            timThayNhanVien = true;
                            break;
                        }
                    }
                }
                if (!timThayNhanVien)
                {
                    MessageBox.Show("Không tìm thấy lịch làm có mã " + hoTen);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã lịch làm cần tìm kiếm");
            }
        }

        private void btn_TaiLai_Click(object sender, EventArgs e)
        {
            load_Grid();
        }
    }
}
