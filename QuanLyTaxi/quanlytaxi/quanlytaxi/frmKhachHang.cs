using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace quanlytaxi
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daKH;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;password=cyclone221;database=qltaxi;";

            // ===== Load dữ liệu Khách hàng =====
            string sQuery = @"SELECT * FROM khachhang";
            daKH = new MySqlDataAdapter(sQuery, conn);
            daKH.Fill(ds, "tblKhachHang");

            dgvKhachHang.DataSource = ds.Tables["tblKhachHang"];

            // ===== Format DataGridView =====
            dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
            dgvKhachHang.Columns["MaKH"].Width = 80;

            dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
            dgvKhachHang.Columns["HoTen"].Width = 150;

            dgvKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns["SDT"].Width = 120;

            dgvKhachHang.Columns["Email"].HeaderText = "Email";
            dgvKhachHang.Columns["Email"].Width = 160;

            dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvKhachHang.Columns["GioiTinh"].Width = 80;

            dgvKhachHang.Columns["CCCD"].HeaderText = "CCCD/CMND";
            dgvKhachHang.Columns["CCCD"].Width = 120;

            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== INSERT command =====
            string sInsert = @"INSERT INTO khachhang(HoTen, SDT, Email, GioiTinh, CCCD)
                           VALUES(@HoTen, @SDT, @Email, @GioiTinh, @CCCD)";

            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@HoTen", MySqlDbType.VarChar, 100, "HoTen");
            cmdInsert.Parameters.Add("@SDT", MySqlDbType.VarChar, 15, "SDT");
            cmdInsert.Parameters.Add("@Email", MySqlDbType.VarChar, 100, "Email");
            cmdInsert.Parameters.Add("@GioiTinh", MySqlDbType.VarChar, 10, "GioiTinh");
            cmdInsert.Parameters.Add("@CCCD", MySqlDbType.VarChar, 20, "CCCD");
            daKH.InsertCommand = cmdInsert;

            // ===== UPDATE command =====
            string sUpdate = @"UPDATE khachhang 
                           SET HoTen=@HoTen, SDT=@SDT, Email=@Email,
                               GioiTinh=@GioiTinh, CCCD=@CCCD
                           WHERE MaKH=@MaKH";

            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@HoTen", MySqlDbType.VarChar, 100, "HoTen");
            cmdUpdate.Parameters.Add("@SDT", MySqlDbType.VarChar, 15, "SDT");
            cmdUpdate.Parameters.Add("@Email", MySqlDbType.VarChar, 100, "Email");
            cmdUpdate.Parameters.Add("@GioiTinh", MySqlDbType.VarChar, 10, "GioiTinh");
            cmdUpdate.Parameters.Add("@CCCD", MySqlDbType.VarChar, 20, "CCCD");
            cmdUpdate.Parameters.Add("@MaKH", MySqlDbType.Int32, 0, "MaKH");
            daKH.UpdateCommand = cmdUpdate;

            // ===== DELETE command =====
            string sDelete = @"DELETE FROM khachhang WHERE MaKH=@MaKH";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaKH", MySqlDbType.Int32, 0, "MaKH");
            daKH.DeleteCommand = cmdDelete;
        }
        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvKhachHang.SelectedRows[0];

                txtMaKhachHang.Text = dr.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dr.Cells["HoTen"].Value.ToString();
                txtSDTKH.Text = dr.Cells["SDT"].Value.ToString();
                txtEmail.Text = dr.Cells["Email"].Value.ToString();
                txtCMND.Text = dr.Cells["CCCD"].Value.ToString();

                if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                    radNam.Checked = true;
                else
                    radNu.Checked = true;
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSDTKH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã khách hàng
            foreach (DataRow r in ds.Tables["tblKhachHang"].Rows)
            {
                if (r.RowState != DataRowState.Deleted &&
                    r["MaKH"].ToString().Equals(txtMaKhachHang.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DataRow row = ds.Tables["tblKhachHang"].NewRow();
            row["MaKH"] = txtMaKhachHang.Text.Trim();
            row["HoTen"] = txtTenKH.Text.Trim();
            row["SDT"] = txtSDTKH.Text.Trim();
            row["Email"] = txtEmail.Text.Trim();
            row["CCCD"] = txtCMND.Text.Trim();
            row["GioiTinh"] = radNam.Checked ? "Nam" : "Nữ";

            ds.Tables["tblKhachHang"].Rows.Add(row);
            dgvKhachHang.Refresh();

            MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo");
        }
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo");
                return;
            }

            DataRowView rowView = dgvKhachHang.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            row["HoTen"] = txtTenKH.Text.Trim();
            row["SDT"] = txtSDTKH.Text.Trim();
            row["Email"] = txtEmail.Text.Trim();
            row["CCCD"] = txtCMND.Text.Trim();
            row["GioiTinh"] = radNam.Checked ? "Nam" : "Nữ";

            dgvKhachHang.Refresh();
            MessageBox.Show("Đã sửa thông tin khách hàng! Nhấn Lưu để cập nhật DB.", "Thông báo");
        }
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DataRowView rowView = dgvKhachHang.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            rowView.Row.Delete();
            dgvKhachHang.Refresh();

            MessageBox.Show("Xóa thành công! Nhấn Lưu để cập nhật DB.", "Thông báo");
        }
        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            try
            {
                dgvKhachHang.EndEdit();
                daKH.Update(ds.Tables["tblKhachHang"]);
                MessageBox.Show("Đã lưu dữ liệu khách hàng thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = "";
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtEmail.Text = "";
            txtCMND.Text = "";
            radNam.Checked = true;
        }
    }
}
