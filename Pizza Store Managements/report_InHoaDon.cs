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
    public partial class report_InHoaDon : Form
    {
        SqlConnection cn;
        SqlDataAdapter da_HoaDon;
        DataSet ds_HoaDon;
        DataColumn[] key = new DataColumn[1];

        SqlDataAdapter da_ChiTietHoaDon;
        DataSet ds_ChiTietHoaDon;
        public report_InHoaDon()
        {
            InitializeComponent();

            cn = new SqlConnection("Data Source=Programming\\SQLEXPRESS01;Initial Catalog=\"Pizza Store Management\";Integrated Security=True");

            // Lấy dữ liệu từ bảng hóa đơn
            string strSelect = "SELECT * FROM HoaDon";
            da_HoaDon = new SqlDataAdapter(strSelect, cn);
            ds_HoaDon = new DataSet();
            da_HoaDon.Fill(ds_HoaDon, "HoaDon");
            key[0] = ds_HoaDon.Tables["HoaDon"].Columns[0];
            ds_HoaDon.Tables["HoaDon"].PrimaryKey = key;

            // Lấy dữ liệu từ bảng hóa đơn
            string strSelect1 = "SELECT * FROM ChiTietHoaDon";
            da_ChiTietHoaDon = new SqlDataAdapter(strSelect1, cn);
            ds_ChiTietHoaDon = new DataSet();
            da_ChiTietHoaDon.Fill(ds_ChiTietHoaDon, "ChiTietHoaDon");
        }
        private void load_Combobox()
        {
            cmb_InHoaDon.DataSource = ds_HoaDon.Tables["HoaDon"];
            cmb_InHoaDon.DisplayMember = "MaHoaDon";
            cmb_InHoaDon.ValueMember = "MaHoaDon";
        }
        private void report_InHoaDon_Load(object sender, EventArgs e)
        {
            load_Combobox();
            cmb_InHoaDon.SelectedIndex = -1;
            btn_InHoaDon.Enabled = false;
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            // Lấy giá trị mã hóa đơn được chọn trong combobox
            string maHoaDon = cmb_InHoaDon.SelectedValue.ToString();

            // Tìm kiếm các bản ghi tương ứng trong bảng ChiTietHoaDon
            DataRow[] rows = ds_ChiTietHoaDon.Tables["ChiTietHoaDon"].Select($"MaHoaDon = '{maHoaDon}'");

            // Tạo DataTable mới chứa các bản ghi tìm thấy
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHoaDon");
            dt.Columns.Add("TenSanPham");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("DonGia");
            dt.Columns.Add("TongTien");

            foreach (DataRow row in rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["MaHoaDon"] = row["MaHoaDon"];
                newRow["TenSanPham"] = row["TenSanPham"];
                newRow["SoLuong"] = row["SoLuong"];
                newRow["DonGia"] = row["DonGia"];
                newRow["TongTien"] = row["TongTien"];
                dt.Rows.Add(newRow);
            }

            // Tạo báo cáo Crystal Report và truyền DataTable mới vào để in
            HoaDon rpt = new HoaDon();
            rpt.SetDatabaseLogon("sa", "12345", "Programming\\SQLEXPRESS01", "Pizza Store Management");
            rpt.Database.Tables["ChiTietHoaDon"].SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
        private int check = 0;
        private void cmb_InHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_InHoaDon.Enabled = true;
        }

        private void cmb_InHoaDon_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_InHoaDon.Enabled = true;
        }

        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_TaoDonHang _Frm_QuanLySanPham = new frm_TaoDonHang();
            _Frm_QuanLySanPham.ShowDialog();
        }
    }
}
