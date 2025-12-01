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
using MySql.Data.MySqlClient;
namespace quanlytaxi
{
    public partial class frmDMQuanLyTaiXe : System.Windows.Forms.Form
    {
        public frmDMQuanLyTaiXe()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daTaiXe;
        DataView dvTaiXe;

        private void frmDMQuanLyTaiXe_Load(object sender, EventArgs e)
        {

            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;   // QUAN TRỌNG

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;password=248569;database=qltaxi;";

            // Lấy dữ liệu tài xế
            string sQueryTaiXe = @"SELECT * FROM taixe";
            daTaiXe = new MySqlDataAdapter(sQueryTaiXe, conn);         
            daTaiXe.Fill(ds, "tblTaiXe");
            ds.Tables["tblTaiXe"].Columns["Dob"].DataType = typeof(DateTime);

            dgvTaiXe.DataSource = ds.Tables["tblTaiXe"];
            // cboTrangThai
            DataTable dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Value");
            dtTrangThai.Columns.Add("Text");

            dtTrangThai.Rows.Add("Dang lai", "Đang lái xe");
            dtTrangThai.Rows.Add("Khong lai", "Không lái xe");

            cboTrangThai.DataSource = dtTrangThai;
            cboTrangThai.DisplayMember = "Text";
            cboTrangThai.ValueMember = "Value";

            // Format tiêu đề + độ rộng cột
            dgvTaiXe.Columns["MaTaiXe"].HeaderText = "Mã tài xế";
            dgvTaiXe.Columns["MaTaiXe"].Width = 80;

            dgvTaiXe.Columns["HoTen"].HeaderText = "Họ tên";
            dgvTaiXe.Columns["HoTen"].Width = 180;

            dgvTaiXe.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvTaiXe.Columns["Dob"].Width = 120;
            dgvTaiXe.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvTaiXe.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvTaiXe.Columns["SDT"].Width = 120;

            dgvTaiXe.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvTaiXe.Columns["GioiTinh"].Width = 80;

            dgvTaiXe.Columns["Luong"].HeaderText = "Lương (VNĐ)";
            dgvTaiXe.Columns["Luong"].Width = 130;
            dgvTaiXe.Columns["Luong"].DefaultCellStyle.Format = "#,###";

            dgvTaiXe.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvTaiXe.Columns["TrangThai"].Width = 150;
            dgvTaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dvTaiXe = new DataView(ds.Tables["tblTaiXe"]);
            dgvTaiXe.DataSource = dvTaiXe;


            // Thêm command Thêm tài xế (INSERT)
            string sInsert = @"INSERT INTO taixe(HoTen, Dob, SDT, GioiTinh, Luong, TrangThai) 
                       VALUES(@HoTen,@Dob,@SDT,@GioiTinh,@Luong,@TrangThai)";
            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@HoTen", MySqlDbType.VarChar, 100, "HoTen");
            cmdInsert.Parameters.Add("@Dob", MySqlDbType.Date, 0, "Dob");
            cmdInsert.Parameters.Add("@SDT", MySqlDbType.VarChar, 15, "SDT");
            cmdInsert.Parameters.Add("@GioiTinh", MySqlDbType.VarChar, 5, "GioiTinh");
            cmdInsert.Parameters.Add("@Luong", MySqlDbType.Decimal, 18, "Luong");
            cmdInsert.Parameters.Add("@TrangThai", MySqlDbType.VarChar, 20, "TrangThai");
            daTaiXe.InsertCommand = cmdInsert;

            // UPDATE command
            string sUpdate = @"UPDATE taixe 
                       SET HoTen=@HoTen, Dob=@Dob, SDT=@SDT, GioiTinh=@GioiTinh,
                           Luong=@Luong, TrangThai=@TrangThai
                       WHERE MaTaiXe=@MaTaiXe";
            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@HoTen", MySqlDbType.VarChar, 100, "HoTen");
            cmdUpdate.Parameters.Add("@Dob", MySqlDbType.Date, 0, "Dob");
            cmdUpdate.Parameters.Add("@SDT", MySqlDbType.VarChar, 15, "SDT");
            cmdUpdate.Parameters.Add("@GioiTinh", MySqlDbType.VarChar, 5, "GioiTinh");
            cmdUpdate.Parameters.Add("@Luong", MySqlDbType.Decimal, 18, "Luong");
            cmdUpdate.Parameters.Add("@TrangThai", MySqlDbType.VarChar, 20, "TrangThai");
            cmdUpdate.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            daTaiXe.UpdateCommand = cmdUpdate;

            // DELETE command
            string sDelete = @"DELETE FROM taixe WHERE MaTaiXe=@MaTaiXe";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            daTaiXe.DeleteCommand = cmdDelete;
        }

        private void dgvTaiXe_Click(object sender, EventArgs e)
        {
            if (dgvTaiXe.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvTaiXe.SelectedRows[0];

                txtMaTaiXe.Text = dr.Cells["MaTaiXe"].Value.ToString();
                txtTenTaiXe.Text = dr.Cells["HoTen"].Value.ToString();
                txtSDT.Text = dr.Cells["SDT"].Value.ToString();
                txtLuong.Text = dr.Cells["Luong"].Value.ToString();
                dpNgaySinh.Text = dr.Cells["Dob"].Value.ToString();

                // Giới tính
                if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }

                // Trạng thái (cboTrangThai dùng SelectedValue)
                string trangThai = dr.Cells["TrangThai"].Value.ToString();
                cboTrangThai.SelectedValue = trangThai;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // ===== 1. Kiểm tra dữ liệu hợp lệ =====
            if (string.IsNullOrWhiteSpace(txtTenTaiXe.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin tài xế!");
                return;
            }

            // Kiểm tra mã tài xế không trùng
            foreach (DataRow r in ds.Tables["tblTaiXe"].Rows)
            {
                if (r["MaTaiXe"].ToString().Equals(txtMaTaiXe.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã tài xế đã tồn tại!");
                    return;
                }
            }

            // ===== 2. Thêm 1 dòng vào DataSet =====
            DataRow row = ds.Tables["tblTaiXe"].NewRow();
            row["MaTaiXe"] = txtMaTaiXe.Text.Trim();
            row["HoTen"] = txtTenTaiXe.Text.Trim();
            row["SDT"] = txtSDT.Text.Trim();
            row["Luong"] = decimal.Parse(txtLuong.Text.Trim());
            row["Dob"] = dpNgaySinh.Value.Date;
            row["GioiTinh"] = radNu.Checked ? "Nu" : "Nam";
            row["TrangThai"] = cboTrangThai.SelectedValue;

            ds.Tables["tblTaiXe"].Rows.Add(row);

            // Refresh DataGridView
            dgvTaiXe.Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài xế để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài xế này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DataRowView rowView = dgvTaiXe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            rowView.Row.Delete();
            dgvTaiXe.Refresh();
            MessageBox.Show("Đã xóa tài xế. Nhấn Lưu để cập nhật vào cơ sở dữ liệu.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài xế để sửa!");
                return;
            }

            DataRowView rowView = dgvTaiXe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            row["HoTen"] = txtTenTaiXe.Text.Trim();
            row["SDT"] = txtSDT.Text.Trim();
            row["Luong"] = decimal.Parse(txtLuong.Text.Trim());
            row["Dob"] = dpNgaySinh.Value.Date;
            row["GioiTinh"] = radNu.Checked ? "Nu" : "Nam";
            row["TrangThai"] = cboTrangThai.SelectedValue;

            dgvTaiXe.Refresh();
            MessageBox.Show("Sửa dữ liệu tài xế thành công! Nhấn Lưu để cập nhật vào database.");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTaiXe.EndEdit();
                daTaiXe.Update(ds.Tables["tblTaiXe"]);
                MessageBox.Show("Đã lưu tất cả thay đổi vào MySQL!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaTaiXe.Text = "";
            txtTenTaiXe.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
            dpNgaySinh.Value = DateTime.Today;
            radNam.Checked = true;
            radNu.Checked = false;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            txtTim.Text = "";
            dvTaiXe.RowFilter = "";  
            dgvTaiXe.Refresh();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dvTaiXe.RowFilter = "";
            }
            else
            {
                dvTaiXe.RowFilter =
                    $"HoTen LIKE '%{keyword}%' " +
                    $"OR CONVERT(MaTaiXe, 'System.String') LIKE '%{keyword}%'";
            }
        }


    }
}
