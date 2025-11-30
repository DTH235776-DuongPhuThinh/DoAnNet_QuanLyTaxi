using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlytaxi
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daThongKe;

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;password=248569;database=qltaxi;";

            // ===== Load dữ liệu thống kê kèm tên tài xế =====
            string sQuery = @"
            SELECT tk.MaTaiXe,
                   tx.HoTen AS TenTaiXe,
                   tk.SoChuyen,
                   tk.DoanhThu
            FROM thongke tk
            LEFT JOIN taixe tx ON tk.MaTaiXe = tx.MaTaiXe;
            ";

            daThongKe = new MySqlDataAdapter(sQuery, conn);
            daThongKe.Fill(ds, "tblThongKe");

            dgvThongKe.DataSource = ds.Tables["tblThongKe"];

            // ===== Format DataGridView =====
            dgvThongKe.Columns["MaTaiXe"].HeaderText = "Mã tài xế";
            dgvThongKe.Columns["MaTaiXe"].Width = 80;

            dgvThongKe.Columns["TenTaiXe"].HeaderText = "Tên tài xế";
            dgvThongKe.Columns["TenTaiXe"].Width = 150;

            dgvThongKe.Columns["SoChuyen"].HeaderText = "Số chuyến";
            dgvThongKe.Columns["SoChuyen"].Width = 100;

            dgvThongKe.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
            dgvThongKe.Columns["DoanhThu"].Width = 130;
            dgvThongKe.Columns["DoanhThu"].DefaultCellStyle.Format = "#,###";

            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // INSERT
            string sInsert = @"INSERT INTO thongke(MaTaiXe, SoChuyen, DoanhThu) 
                       VALUES(@MaTaiXe, @SoChuyen, @DoanhThu)";
            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            cmdInsert.Parameters.Add("@SoChuyen", MySqlDbType.Int32, 0, "SoChuyen");
            cmdInsert.Parameters.Add("@DoanhThu", MySqlDbType.Decimal, 18, "DoanhThu");
            daThongKe.InsertCommand = cmdInsert;

            // UPDATE
            string sUpdate = @"UPDATE thongke 
                       SET SoChuyen=@SoChuyen, DoanhThu=@DoanhThu
                       WHERE MaTaiXe=@MaTaiXe";
            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@SoChuyen", MySqlDbType.Int32, 0, "SoChuyen");
            cmdUpdate.Parameters.Add("@DoanhThu", MySqlDbType.Decimal, 18, "DoanhThu");
            cmdUpdate.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            daThongKe.UpdateCommand = cmdUpdate;

            // DELETE
            string sDelete = @"DELETE FROM thongke WHERE MaTaiXe=@MaTaiXe";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            daThongKe.DeleteCommand = cmdDelete;
        }

        private void dgvThongKe_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvThongKe.SelectedRows[0];
                txtMaTaiXe.Text = dr.Cells["MaTaiXe"].Value.ToString();
                txtTenTaiXe.Text = dr.Cells["TenTaiXe"].Value.ToString();
                txtSoChuyen.Text = dr.Cells["SoChuyen"].Value.ToString();
                txtDoanhThu.Text = dr.Cells["DoanhThu"].Value.ToString();
            }
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTaiXe.Text) ||
                string.IsNullOrWhiteSpace(txtSoChuyen.Text) ||
                string.IsNullOrWhiteSpace(txtDoanhThu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoChuyen.Text.Trim(), out int soChuyen))
            {
                MessageBox.Show("Số chuyến phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtDoanhThu.Text.Trim(), out decimal doanhThu))
            {
                MessageBox.Show("Doanh thu phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow r in ds.Tables["tblThongKe"].Rows)
            {
                if (r.RowState != DataRowState.Deleted &&
                    r["MaTaiXe"].ToString() == txtMaTaiXe.Text.Trim())
                {
                    MessageBox.Show("Mã tài xế đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DataRow row = ds.Tables["tblThongKe"].NewRow();
            row["MaTaiXe"] = txtMaTaiXe.Text.Trim();
            row["TenTaiXe"] = txtTenTaiXe.Text.Trim(); // tự điền từ textbox
            row["SoChuyen"] = soChuyen;
            row["DoanhThu"] = doanhThu;

            ds.Tables["tblThongKe"].Rows.Add(row);
            dgvThongKe.Refresh();
            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo");
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa!", "Thông báo");
                return;
            }

            if (!int.TryParse(txtSoChuyen.Text.Trim(), out int soChuyen))
            {
                MessageBox.Show("Số chuyến phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtDoanhThu.Text.Trim(), out decimal doanhThu))
            {
                MessageBox.Show("Doanh thu phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView rowView = dgvThongKe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;
            row["TenTaiXe"] = txtTenTaiXe.Text.Trim();
            row["SoChuyen"] = soChuyen;
            row["DoanhThu"] = doanhThu;

            dgvThongKe.Refresh();
            MessageBox.Show("Sửa dữ liệu thành công! Nhấn Lưu để cập nhật vào cơ sở dữ liệu.", "Thông báo");
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DataRowView rowView = dgvThongKe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            rowView.Row.Delete();
            dgvThongKe.Refresh();
            MessageBox.Show("Xóa dữ liệu thành công! Nhấn Lưu để cập nhật vào database.", "Thông báo");
        }

        // ===== NÚT LƯU =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                dgvThongKe.EndEdit();
                daThongKe.Update(ds.Tables["tblThongKe"]);
                MessageBox.Show("Đã lưu thay đổi vào MySQL thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== NÚT HỦY =====
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaTaiXe.Text = "";
            txtTenTaiXe.Text = "";
            txtSoChuyen.Text = "";
            txtDoanhThu.Text = "";
        }

        // ===== NÚT THOÁT =====
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
