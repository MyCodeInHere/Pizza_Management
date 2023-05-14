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
    public partial class frm_GiamGia : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_GiamGia;
        DataSet ds_GiamGia;
        DataColumn[] key = new DataColumn[1];
        public frm_GiamGia()
        {
            InitializeComponent();

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu từ bảng loại sản phẩm
            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            string strSelect = "SELECT * FROM GiamGia";
            da_GiamGia = new SqlDataAdapter(strSelect, cn);
            ds_GiamGia = new DataSet();
            da_GiamGia.Fill(ds_GiamGia, "GiamGia");

            // Thêm khóa chính 
            key[0] = ds_GiamGia.Tables["GiamGia"].Columns[0];
            ds_GiamGia.Tables["GiamGia"].PrimaryKey = key;
        }
        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLySanPham _Frm_QuanLySanPham = new frm_QuanLySanPham();
            _Frm_QuanLySanPham.ShowDialog();
        }
        private void btn_XoaThongTin_Click(object sender, EventArgs e)
        {
            txt_MaGiamGia.Clear();
            txt_MucGiamGia.Clear();
            cmb_NgayGiamGia.SelectedIndex = -1;
        }
        private void thietKeTieuDeDGV()
        {
            if (dgv_GiamGia != null && dgv_GiamGia.ColumnCount > 0)
            {
                dgv_GiamGia.Columns[0].HeaderText = "Mã giảm giá";
                dgv_GiamGia.Columns[1].HeaderText = "Ngày giảm giá";
                dgv_GiamGia.Columns[2].HeaderText = "Mức giảm giá (%)";

                // Đặt giá trị cho AutoSizeColumnsMode
                dgv_GiamGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Thiết lập lại chiều cao của từng dòng
                dgv_GiamGia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_GiamGia.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }
                // In đậm tiêu đề của các cột
                foreach (DataGridViewColumn column in dgv_GiamGia.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                }

                dgv_GiamGia.Columns["MaGiamGia"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgv_GiamGia.Sort(dgv_GiamGia.Columns["MaGiamGia"], ListSortDirection.Ascending);
            }
        }
        private void load_Grid()
        {
            dgv_GiamGia.DataSource = ds_GiamGia.Tables["GiamGia"];
            thietKeTieuDeDGV();
        }
        private void dataBinding()
        {
            // Thực hiện binding cho mã giảm giá
            string maGiamGia = dgv_GiamGia.SelectedRows[0].Cells["MaGiamGia"].Value.ToString();
            txt_MaGiamGia.Text = maGiamGia;
            // Thực hiện binding cho ngày giảm giá
            string ngayGiamGia = dgv_GiamGia.SelectedRows[0].Cells["NgayGiamGia"].Value.ToString();
            cmb_NgayGiamGia.Text = ngayGiamGia;
            // Thực hiện binding cho mức giảm giá
            string mucGiamGia = dgv_GiamGia.SelectedRows[0].Cells["MucGiamGia"].Value.ToString();
            txt_MucGiamGia.Text = mucGiamGia;
        }
        private void dgv_GiamGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataBinding();
        }

        private void frm_GiamGia_Load(object sender, EventArgs e)
        {
            load_Grid();
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

            string selectQuery = "Select MaGiamGia from GiamGia where MaGiamGia ='" + id + "'";
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
            string countQuery = "SELECT COUNT(*) FROM GiamGia";
            SqlCommand countCommand = new SqlCommand(countQuery, cn);
            int count = (int)countCommand.ExecuteScalar();
            string id = getID("MGG", 5, 1, count);

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
                    id = getID("MGG", 5, 1, count);
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
        private int kiemTraNgayGiamGia()
        {
            // Kiểm tra ngày giảm giá
            if (coTrongKhong(cmb_NgayGiamGia.Text) == false)
            {
                epd_NgayGiamGia.Clear();
                return 1;
            }
            else
            {
                epd_NgayGiamGia.SetError(cmb_NgayGiamGia, "Bạn chưa nhập NGÀY GIẢM GIÁ!!!.");
                return 0;
            }
        }
        private int kiemTraMucGiamGia()
        {
            // Kiểm tra mức giảm giá
            if (coTrongKhong(txt_MucGiamGia.Text) == false)
            {
                epd_MucGiamGia.Clear();
                return 1;
            }
            else
            {
                epd_MucGiamGia.SetError(txt_MucGiamGia, "Bạn chưa nhập MỨC GIẢM GIÁ!!!.");
                return 0;
            }
        }
        private int kiemTraDuThongTin()
        {
            int ngayGiamGia = kiemTraNgayGiamGia();
            int mucGiamGia = kiemTraMucGiamGia();
            int dayDuThongTin = ngayGiamGia + mucGiamGia;

            if (dayDuThongTin == 2)
            {
                return 1;
            }
            return 0;
        }
        private int kiemTraGiamGiaDaTonTai(string str)
        {
            int soLuong = 0;
            DataRow[] rows = ds_GiamGia.Tables["GiamGia"].Select("NgayGiamGia = '" + str + "'");
            if (rows != null && rows.Length > 0)
            {
                soLuong = rows.Length;
            }

            if (soLuong == 1) return 1;
            return 0;
        }
        private bool kiemTraCoPhaiSo(string input)
        {
            int flag = 0;
            try
            {
                float mucGiamGia = float.Parse(input);
            }
            catch (FormatException ex) // Bắt lỗi FormatException khi nhập sai định dạng
            {
                // Xử lý lỗi ở đây, ví dụ như thông báo cho người dùng biết nhập sai định dạng
                MessageBox.Show("Vui lòng nhập đúng định dạng số!");
                flag = 1;
            }
            if (flag == 1)
            {
                return false;
            }
            return true;
        }
        private void txt_ThemGiamGia_Click(object sender, EventArgs e)
        {
            if (kiemTraDuThongTin() == 1)
            {
                if (kiemTraGiamGiaDaTonTai(cmb_NgayGiamGia.Text.Trim()) == 0)
                {
                    if (kiemTraCoPhaiSo(txt_MucGiamGia.Text.Trim()) == true)
                    {
                        // Tạo một dòng dữ liệu mới.
                        DataRow newRow = ds_GiamGia.Tables["GiamGia"].NewRow();
                        // Thêm mã giảm giá
                        newRow["MaGiamGia"] = get_MaSanPham();
                        // Thêm ngày giảm giá
                        newRow["NgayGiamGia"] = cmb_NgayGiamGia.Text;
                        // Thêm mức giảm giá
                        float convertPercent = float.Parse(txt_MucGiamGia.Text);
                        newRow["MucGiamGia"] = convertPercent;

                        ds_GiamGia.Tables[0].Rows.Add(newRow);
                        // Cập nhật trong cơ sở dữ liệu.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_GiamGia);
                        // Cập nhật trong DataSet.
                        da_GiamGia.Update(ds_GiamGia, "GiamGia");

                        // Thông báo thêm thành công
                        MessageBox.Show("Thêm giảm giá thành công!!");

                        // Xóa thông tin trong control
                        txt_MaGiamGia.Clear();
                        txt_MucGiamGia.Clear();
                        cmb_NgayGiamGia.SelectedIndex = -1;
                    }
                }
                else
                {
                    MessageBox.Show("Đã có ngày giảm giá " + cmb_NgayGiamGia.Text.Trim() + "!!.\n Vui lòng chọn lại ngày khác!!!", "THÊM KHÔNG THÀNH CÔNG", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
        }
        private void capNhatGiamGia(string str)
        {
            DataRow dr = ds_GiamGia.Tables["GiamGia"].Rows.Find(str);

            if (dr != null)
            {
                dr["NgayGiamGia"] = cmb_NgayGiamGia.Text;

                dr["MucGiamGia"] = float.Parse(txt_MucGiamGia.Text);

                SqlCommandBuilder cB = new SqlCommandBuilder(da_GiamGia);
                da_GiamGia.Update(ds_GiamGia, "GiamGia");

                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!");
            }
        }
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string check = txt_MaGiamGia.Text.Trim();
            if (check.Length != 0)
            {
                if (kiemTraGiamGiaDaTonTai(cmb_NgayGiamGia.Text) == 1)
                {
                    string getNgayGiamGia = dgv_GiamGia.SelectedRows[0].Cells["NgayGiamGia"].Value.ToString();
                    if (cmb_NgayGiamGia.Text == getNgayGiamGia)
                    {
                        DialogResult r;

                        r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin giảm giá này?", "CẬP NHẬT THÔNG TIN GIẢM GIÁ", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                        // Nếu đồng ý thì sẽ thực hiện việc cập nhật giảm giá.
                        if (r == DialogResult.Yes)
                        {
                            capNhatGiamGia(check);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã có: " + cmb_NgayGiamGia.Text + "là ngày giảm giá!!!", "CẬP NHẬT KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    DialogResult r;

                    r = MessageBox.Show("Bạn có CHẮC là muốn thay đổi thông tin giảm giá này?", "CẬP NHẬT THÔNG TIN GIẢM GIÁ", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    // Nếu đồng ý thì sẽ thực hiện việc cập nhật giảm giá.
                    if (r == DialogResult.Yes)
                    {
                        capNhatGiamGia(check);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn ngày giảm giá cần sửa!!!");
            }
        }
        private void btn_XoaMucGiamGia_Click(object sender, EventArgs e)
        {
            if (txt_MaGiamGia.Text.Trim().Length != 0)
            {
                DialogResult r;

                r = MessageBox.Show("Bạn có CHẮC CHẮN là muốn xóa ngày giảm giá này?", "XÓA NGÀY GIẢM GIÁ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Nếu đồng ý thì sẽ thực hiện việc xóa.
                if (r == DialogResult.Yes)
                {
                    // Tìm dòng dữ liệu có tên loại sản phẩm trùng với tên loại sản phẩm trong textbox.
                    DataRow dr = ds_GiamGia.Tables["GiamGia"].Rows.Find(txt_MaGiamGia.Text);

                    // Xóa dòng dữ liệu vừa tìm được.
                    if (dr != null)
                    {
                        dr.Delete();
                        // Cập nhật trong CSDL.
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_GiamGia);
                        // Cập nhật trong DataSet.
                        da_GiamGia.Update(ds_GiamGia, "GiamGia");
                        // Cập nhật và thông báo đã xóa thành công
                        MessageBox.Show("Đã xóa sản phẩn thành công!", "XÓA NGÀY GIẢM GIÁ THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Xóa thông tin
                        txt_MaGiamGia.Clear();
                        cmb_NgayGiamGia.SelectedIndex = -1;
                        txt_MucGiamGia.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ngày giảm giá này!", "XÓA NGÀY GIẢM GIÁ KHÔNG THÀNH CÔNG",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn ngày giảm giá cần xóa!!!");
            }
        }
    }
}
