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
    public partial class frmDatXe : Form
    {
        public frmDatXe()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daDatXe;

        private void frmDatXe_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;password=cyclone221;database=qltaxi;";

            // ===== Load bảng Đặt Xe =====
            string sQueryDatXe = @"
            SELECT dx.MaDatXe,
                   kh.MaKH,
                   kh.HoTen AS TenKhach,
                   kh.SDT AS SDTKhach,
                   dx.DiemDon,
                   dx.DiemDen,
                   dx.MaXe,
                   tx.HoTen AS TenTaiXe,
                   lx.SoCho
            FROM datxe dx
            LEFT JOIN khachhang kh ON dx.MaKH = kh.MaKH
            LEFT JOIN taixe tx ON dx.MaTaiXe = tx.MaTaiXe
            LEFT JOIN loaixe lx ON dx.MaXe = lx.MaXe;
            ";

            daDatXe = new MySqlDataAdapter(sQueryDatXe, conn);
            ds.Clear();
            daDatXe.Fill(ds, "tblDatXe");
            dgvDatXe.DataSource = ds.Tables["tblDatXe"];



            // ===== Load ComboBox Số chỗ =====
            DataTable dtSoCho = new DataTable();
            dtSoCho.Columns.Add("Value");
            dtSoCho.Columns.Add("Text");

            dtSoCho.Rows.Add("4", "4 chỗ");
            dtSoCho.Rows.Add("7", "7 chỗ");
            dtSoCho.Rows.Add("16", "16 chỗ");

            cboSoCho.DataSource = dtSoCho;
            cboSoCho.DisplayMember = "Text";
            cboSoCho.ValueMember = "Value";


            // ===== Format DataGridView =====
            dgvDatXe.Columns["MaDatXe"].HeaderText = "Mã đặt xe";
            dgvDatXe.Columns["MaDatXe"].Width = 80;

            dgvDatXe.Columns["MaKH"].HeaderText = "Mã KH";
            dgvDatXe.Columns["MaKH"].Width = 80;

            dgvDatXe.Columns["TenKhach"].HeaderText = "Tên khách";
            dgvDatXe.Columns["TenKhach"].Width = 150;

            dgvDatXe.Columns["SDTKhach"].HeaderText = "SĐT";
            dgvDatXe.Columns["SDTKhach"].Width = 110;

            dgvDatXe.Columns["DiemDon"].HeaderText = "Điểm đón";
            dgvDatXe.Columns["DiemDon"].Width = 200;

            dgvDatXe.Columns["DiemDen"].HeaderText = "Điểm đến";
            dgvDatXe.Columns["DiemDen"].Width = 200;

            dgvDatXe.Columns["MaXe"].HeaderText = "Mã xe";
            dgvDatXe.Columns["MaXe"].Width = 80;

            dgvDatXe.Columns["TenTaiXe"].HeaderText = "Tên tài xế";
            dgvDatXe.Columns["TenTaiXe"].Width = 150;

            dgvDatXe.Columns["SoCho"].HeaderText = "Số chỗ";
            dgvDatXe.Columns["SoCho"].Width = 70;


            dgvDatXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===== INSERT =====
            string sInsert = @"INSERT INTO datxe(MaKH,HoTen,SDT,DiemDon,DiemDen,MaXe,TenTaiXe,SoCho)
                       VALUES(@MaKH,@HoTen,@SDT,@DiemDon,@DiemDen,@MaXe,@TenTaiXe,@SoCho)";
            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaKH", MySqlDbType.Int32, 0, "MaKH");
            cmdInsert.Parameters.Add("@HoTen", MySqlDbType.VarChar, 100, "HoTen");
            cmdInsert.Parameters.Add("@SDT", MySqlDbType.VarChar, 15, "SDT");
            cmdInsert.Parameters.Add("@DiemDon", MySqlDbType.VarChar, 200, "DiemDon");
            cmdInsert.Parameters.Add("@DiemDen", MySqlDbType.VarChar, 200, "DiemDen");
            cmdInsert.Parameters.Add("@MaXe", MySqlDbType.Int32, 0, "MaXe");
            cmdInsert.Parameters.Add("@TenTaiXe", MySqlDbType.VarChar, 100, "TenTaiXe");
            cmdInsert.Parameters.Add("@SoCho", MySqlDbType.Int32, 0, "SoCho");
            daDatXe.InsertCommand = cmdInsert;

            // ===== UPDATE =====
            string sUpdate = @"UPDATE datxe SET MaKH=@MaKH,HoTen=@HoTen,SDT=@SDT,DiemDon=@DiemDon,
                       DiemDen=@DiemDen,MaXe=@MaXe,TenTaiXe=@TenTaiXe,SoCho=@SoCho
                       WHERE MaDatXe=@MaDatXe";
            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@MaKH", MySqlDbType.Int32, 0, "MaKH");
            cmdUpdate.Parameters.Add("@HoTen", MySqlDbType.VarChar, 100, "HoTen");
            cmdUpdate.Parameters.Add("@SDT", MySqlDbType.VarChar, 15, "SDT");
            cmdUpdate.Parameters.Add("@DiemDon", MySqlDbType.VarChar, 200, "DiemDon");
            cmdUpdate.Parameters.Add("@DiemDen", MySqlDbType.VarChar, 200, "DiemDen");
            cmdUpdate.Parameters.Add("@MaXe", MySqlDbType.Int32, 0, "MaXe");
            cmdUpdate.Parameters.Add("@TenTaiXe", MySqlDbType.VarChar, 100, "TenTaiXe");
            cmdUpdate.Parameters.Add("@SoCho", MySqlDbType.Int32, 0, "SoCho");
            cmdUpdate.Parameters.Add("@MaDatXe", MySqlDbType.Int32, 0, "MaDatXe");
            daDatXe.UpdateCommand = cmdUpdate;

            // ===== DELETE =====
            string sDelete = @"DELETE FROM datxe WHERE MaDatXe=@MaDatXe";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaDatXe", MySqlDbType.Int32, 0, "MaDatXe");
            daDatXe.DeleteCommand = cmdDelete;

        }

        private void dgvDatXe_Click(object sender, EventArgs e)
        {
            if (dgvDatXe.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvDatXe.SelectedRows[0];

                // Hiển thị thông tin khách
                txtMaKhachHang.Text = dr.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dr.Cells["TenKhach"].Value.ToString();
                txtSDTKH.Text = dr.Cells["SDTKhach"].Value.ToString();

                // Hiển thị thông tin điểm đón / điểm đến
                txtDiemDon.Text = dr.Cells["DiemDon"].Value.ToString();
                txtDiemDen.Text = dr.Cells["DiemDen"].Value.ToString();

                // Hiển thị thông tin xe và tài xế
                txtMaXe.Text = dr.Cells["MaXe"].Value.ToString();
                txtTenTaiXe.Text = dr.Cells["TenTaiXe"].Value.ToString();

                // Hiển thị số chỗ
                cboSoCho.SelectedValue = dr.Cells["SoCho"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhập
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtMaXe.Text) ||
                string.IsNullOrWhiteSpace(txtDiemDon.Text) ||
                string.IsNullOrWhiteSpace(txtDiemDen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đặt xe!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DataRow row = ds.Tables["tblDatXe"].NewRow();
            row["MaKH"] = txtMaKhachHang.Text.Trim();
            row["TenKhach"] = txtTenKH.Text.Trim();
            row["SDTKhach"] = txtSDTKH.Text.Trim();
            row["DiemDon"] = txtDiemDon.Text.Trim();
            row["DiemDen"] = txtDiemDen.Text.Trim();
            row["MaXe"] = txtMaXe.Text.Trim();
            row["TenTaiXe"] = txtTenTaiXe.Text.Trim();
            row["SoCho"] = cboSoCho.SelectedValue;

            ds.Tables["tblDatXe"].Rows.Add(row);
            dgvDatXe.Refresh();
            MessageBox.Show("Thêm đặt xe mới thành công!", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDatXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đặt xe cần sửa!", "Thông báo");
                return;
            }

            DataRowView rowView = dgvDatXe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            DataRow row = rowView.Row;

            row["MaKH"] = txtMaKhachHang.Text.Trim();
            row["TenKhach"] = txtTenKH.Text.Trim();
            row["SDTKhach"] = txtSDTKH.Text.Trim();
            row["DiemDon"] = txtDiemDon.Text.Trim();
            row["DiemDen"] = txtDiemDen.Text.Trim();
            row["MaXe"] = txtMaXe.Text.Trim();
            row["TenTaiXe"] = txtTenTaiXe.Text.Trim();
            row["SoCho"] = cboSoCho.SelectedValue;

            dgvDatXe.Refresh();
            MessageBox.Show("Sửa đặt xe thành công! Nhấn Lưu để cập nhật vào cơ sở dữ liệu.", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDatXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đặt xe để xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa đặt xe này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DataRowView rowView = dgvDatXe.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            rowView.Row.Delete();
            dgvDatXe.Refresh();

            MessageBox.Show("Xóa đặt xe thành công! Nhấn Lưu để cập nhật vào database.", "Thông báo");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDatXe.EndEdit();
                daDatXe.Update(ds.Tables["tblDatXe"]);
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
            txtMaKhachHang.Text = "";
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtDiemDon.Text = "";
            txtDiemDen.Text = "";
            txtMaXe.Text = "";
            txtTenTaiXe.Text = "";
            if (cboSoCho.Items.Count > 0) cboSoCho.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
