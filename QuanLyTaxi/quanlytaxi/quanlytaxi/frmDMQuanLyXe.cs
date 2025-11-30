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
    public partial class frmDMQuanLyXe : System.Windows.Forms.Form
    {
        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daXe;

        public frmDMQuanLyXe()
        {
            InitializeComponent();
        }

        private void frmDMQuanLyXe_Load(object sender, EventArgs e)
        {

            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;   // QUAN TRỌNG

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;password=A12345671a;database=qltaxi;";

            // ===== Load database loại xe =====
            string sQueryXe = @"SELECT * FROM loaixe";
            daXe = new MySqlDataAdapter(sQueryXe, conn);
            daXe.Fill(ds, "tblLoaiXe");

            dgvLoaiXe.DataSource = ds.Tables["tblLoaiXe"];

            // ===== Load dữ liệu ComboBox Số chỗ =====
            DataTable dtSoCho = new DataTable();
            dtSoCho.Columns.Add("Value");
            dtSoCho.Columns.Add("Text");

            dtSoCho.Rows.Add("4", "4 chỗ");
            dtSoCho.Rows.Add("7", "7 chỗ");
            dtSoCho.Rows.Add("16", "16 chỗ");

            cboSoCho.DataSource = dtSoCho;
            cboSoCho.DisplayMember = "Text";
            cboSoCho.ValueMember = "Value";

            // ===== Load ComboBox trạng thái =====
            DataTable dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Value");
            dtTrangThai.Columns.Add("Text");

            dtTrangThai.Rows.Add("Dang dung", "Đang sử dụng");
            dtTrangThai.Rows.Add("Ngung dung", "Ngừng sử dụng");

            cboTrangThai.DataSource = dtTrangThai;
            cboTrangThai.DisplayMember = "Text";
            cboTrangThai.ValueMember = "Value";

            // ===== Format DataGridView =====
            dgvLoaiXe.Columns["MaXe"].HeaderText = "Mã xe";
            dgvLoaiXe.Columns["MaXe"].Width = 80;

            dgvLoaiXe.Columns["SoXe"].HeaderText = "Số xe";
            dgvLoaiXe.Columns["SoXe"].Width = 120;

            dgvLoaiXe.Columns["SoCho"].HeaderText = "Số chỗ";
            dgvLoaiXe.Columns["SoCho"].Width = 80;

            dgvLoaiXe.Columns["GiaTrenKM"].HeaderText = "Giá/Km (VNĐ)";
            dgvLoaiXe.Columns["GiaTrenKM"].Width = 130;
            dgvLoaiXe.Columns["GiaTrenKM"].DefaultCellStyle.Format = "#,###";

            dgvLoaiXe.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvLoaiXe.Columns["TrangThai"].Width = 150;

            dgvLoaiXe.Columns["MoTa"].HeaderText = "Mô tả";
            dgvLoaiXe.Columns["MoTa"].Width = 300;

            dgvLoaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== Thiết lập command Insert =====
            string sInsert = @"INSERT INTO loaixe(SoXe, SoCho, GiaTrenKM, TrangThai, MoTa) 
                               VALUES(@SoXe,@SoCho,@GiaTrenKM,@TrangThai,@MoTa)";
            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@SoXe", MySqlDbType.VarChar, 30, "SoXe");
            cmdInsert.Parameters.Add("@SoCho", MySqlDbType.Int32, 0, "SoCho");
            cmdInsert.Parameters.Add("@GiaTrenKM", MySqlDbType.Decimal, 18, "GiaTrenKM");
            cmdInsert.Parameters.Add("@TrangThai", MySqlDbType.VarChar, 20, "TrangThai");
            cmdInsert.Parameters.Add("@MoTa", MySqlDbType.VarChar, 200, "MoTa");
            daXe.InsertCommand = cmdInsert;

            // ===== UPDATE command =====
            string sUpdate = @"UPDATE loaixe 
                               SET SoXe=@SoXe, SoCho=@SoCho, GiaTrenKM=@GiaTrenKM,
                                   TrangThai=@TrangThai, MoTa=@MoTa
                               WHERE MaXe=@MaXe";
            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@SoXe", MySqlDbType.VarChar, 30, "SoXe");
            cmdUpdate.Parameters.Add("@SoCho", MySqlDbType.Int32, 0, "SoCho");
            cmdUpdate.Parameters.Add("@GiaTrenKM", MySqlDbType.Decimal, 18, "GiaTrenKM");
            cmdUpdate.Parameters.Add("@TrangThai", MySqlDbType.VarChar, 20, "TrangThai");
            cmdUpdate.Parameters.Add("@MoTa", MySqlDbType.VarChar, 200, "MoTa");
            cmdUpdate.Parameters.Add("@MaXe", MySqlDbType.Int32, 0, "MaXe");
            daXe.UpdateCommand = cmdUpdate;

            // ===== DELETE command =====
            string sDelete = @"DELETE FROM loaixe WHERE MaXe=@MaXe";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaXe", MySqlDbType.Int32, 0, "MaXe");
            daXe.DeleteCommand = cmdDelete;
        }

        private void dgvLoaiXe_Click(object sender, EventArgs e)
        {
            if (dgvLoaiXe.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvLoaiXe.SelectedRows[0];
                txtMaXe.Text = dr.Cells["MaXe"].Value.ToString();
                txtTenXe.Text = dr.Cells["SoXe"].Value.ToString();
                txtGiaKM.Text = dr.Cells["GiaTrenKM"].Value.ToString();
                txtMoTa.Text = dr.Cells["MoTa"].Value.ToString();

                cboSoCho.SelectedValue = dr.Cells["SoCho"].Value.ToString();
                cboTrangThai.SelectedValue = dr.Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaXe.Text) ||
                string.IsNullOrWhiteSpace(txtTenXe.Text) ||
                string.IsNullOrWhiteSpace(txtGiaKM.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại xe!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaKM.Text.Trim(), out decimal giakm))
            {
                MessageBox.Show("Giá/Km phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mã xe không trùng
            foreach (DataRow r in ds.Tables["tblLoaiXe"].Rows)
            {
                if (r.RowState != DataRowState.Deleted &&
                    r["MaXe"].ToString().Equals(txtMaXe.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã xe đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DataRow row = ds.Tables["tblLoaiXe"].NewRow();
            row["MaXe"] = txtMaXe.Text.Trim();
            row["SoXe"] = txtTenXe.Text.Trim();
            row["SoCho"] = cboSoCho.SelectedValue;
            row["GiaTrenKM"] = giakm;
            row["TrangThai"] = cboTrangThai.SelectedValue;
            row["MoTa"] = txtMoTa.Text.Trim();

            ds.Tables["tblLoaiXe"].Rows.Add(row);
            dgvLoaiXe.Refresh();
            MessageBox.Show("Thêm loại xe mới thành công!", "Thông báo");
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại xe cần sửa!", "Thông báo");
                return;
            }

            if (!decimal.TryParse(txtGiaKM.Text.Trim(), out decimal giakm))
            {
                MessageBox.Show("Giá/Km phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView rowView = dgvLoaiXe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            row["SoXe"] = txtTenXe.Text.Trim();
            row["SoCho"] = cboSoCho.SelectedValue;
            row["GiaTrenKM"] = giakm;
            row["TrangThai"] = cboTrangThai.SelectedValue;
            row["MoTa"] = txtMoTa.Text.Trim();

            dgvLoaiXe.Refresh();
            MessageBox.Show("Sửa loại xe thành công! Nhấn Lưu để cập nhật vào cơ sở dữ liệu.", "Thông báo");
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại xe để xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại xe này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DataRowView rowView = dgvLoaiXe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            rowView.Row.Delete();
            dgvLoaiXe.Refresh();

            MessageBox.Show("Xóa xe thành công! Nhấn Lưu để cập nhật vào database.", "Thông báo");
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLoaiXe.EndEdit();
                daXe.Update(ds.Tables["tblLoaiXe"]);
                MessageBox.Show("Đã lưu thay đổi vào MySQL thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaXe.Text = "";
            txtTenXe.Text = "";
            txtMoTa.Text = "";
            txtGiaKM.Text = "";
            if (cboSoCho.Items.Count > 0) cboSoCho.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }
    }
}
