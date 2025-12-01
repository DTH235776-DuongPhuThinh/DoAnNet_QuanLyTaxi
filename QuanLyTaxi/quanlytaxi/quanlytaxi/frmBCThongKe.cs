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
    public partial class frmBCThongKe : Form
    {
        // Chuỗi kết nối dùng chung
        string connString = "server=localhost;user=root;password=248569;database=qltaxi;";

        // Các biến cho Tab 1 (Quản lý tài xế)
        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daThongKe;

        public frmBCThongKe()
        {
            InitializeComponent();
        }

        private void frmBCThongKe_Load(object sender, EventArgs e)
        {
            // Cấu hình Form
            this.AutoSize = false;
            this.Dock = DockStyle.Fill;

            // 1. TẢI DỮ LIỆU CHO TAB 1 (Logic cũ của bạn)
            LoadDuLieuTaiXe();

            // 2. TẢI DỮ LIỆU CHO TAB 2 (Báo cáo tháng)
            LoadNamVaoComboBox();
        }

        // =================================================================================
        // PHẦN 1: LOGIC CŨ (QUẢN LÝ DOANH THU TỪNG TÀI XẾ) - ĐÃ SỬA GỌN LẠI
        // =================================================================================
        private void LoadDuLieuTaiXe()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                string sQuery = @"SELECT tk.MaTaiXe, tx.HoTen AS TenTaiXe, tk.SoChuyen, tk.DoanhThu 
                                  FROM thongke tk LEFT JOIN taixe tx ON tk.MaTaiXe = tx.MaTaiXe";

                daThongKe = new MySqlDataAdapter(sQuery, conn);

                // Cấu hình Insert/Update/Delete Command (Giữ nguyên logic của bạn)
                CauHinhCommand(conn);

                // Fill dữ liệu
                ds.Clear();
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

                FormatLuoiTaiXe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu tài xế: " + ex.Message);
            }
        }

        private void CauHinhCommand(MySqlConnection conn)
        {
            // INSERT
            string sInsert = "INSERT INTO thongke(MaTaiXe, SoChuyen, DoanhThu) VALUES(@MaTaiXe, @SoChuyen, @DoanhThu)";
            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            cmdInsert.Parameters.Add("@SoChuyen", MySqlDbType.Int32, 0, "SoChuyen");
            cmdInsert.Parameters.Add("@DoanhThu", MySqlDbType.Decimal, 18, "DoanhThu");
            daThongKe.InsertCommand = cmdInsert;

            // UPDATE
            string sUpdate = "UPDATE thongke SET SoChuyen=@SoChuyen, DoanhThu=@DoanhThu WHERE MaTaiXe=@MaTaiXe";
            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@SoChuyen", MySqlDbType.Int32, 0, "SoChuyen");
            cmdUpdate.Parameters.Add("@DoanhThu", MySqlDbType.Decimal, 18, "DoanhThu");
            cmdUpdate.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            daThongKe.UpdateCommand = cmdUpdate;

            // DELETE
            string sDelete = "DELETE FROM thongke WHERE MaTaiXe=@MaTaiXe";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            daThongKe.DeleteCommand = cmdDelete;
        }

        private void FormatLuoiTaiXe()
        {
            if (dgvThongKe.Columns["DoanhThu"] != null)
                dgvThongKe.Columns["DoanhThu"].DefaultCellStyle.Format = "#,###";
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvThongKe_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.CurrentRow != null && dgvThongKe.CurrentRow.Index >= 0)
            {
                DataGridViewRow dr = dgvThongKe.CurrentRow;
                txtMaTaiXe.Text = dr.Cells["MaTaiXe"].Value.ToString();
                txtTenTaiXe.Text = dr.Cells["TenTaiXe"].Value.ToString();
                txtSoChuyen.Text = dr.Cells["SoChuyen"].Value.ToString();
                txtDoanhThu.Text = dr.Cells["DoanhThu"].Value.ToString();
            }
        }

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

            /*try
            {
                DataRow row = ds.Tables["tblThongKe"].NewRow();
                row["MaTaiXe"] = txtMaTaiXe.Text.Trim();
                row["TenTaiXe"] = txtTenTaiXe.Text.Trim();
                row["SoChuyen"] = int.Parse(txtSoChuyen.Text);
                row["DoanhThu"] = decimal.Parse(txtDoanhThu.Text);
                ds.Tables["tblThongKe"].Rows.Add(row);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }*/
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.CurrentRow == null) return;
            DataRowView rowView = dgvThongKe.CurrentRow.DataBoundItem as DataRowView;
            rowView.Row["SoChuyen"] = int.Parse(txtSoChuyen.Text);
            rowView.Row["DoanhThu"] = decimal.Parse(txtDoanhThu.Text);
        }

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                dgvThongKe.EndEdit();
                daThongKe.Update(ds.Tables["tblThongKe"]);
                MessageBox.Show("Đã lưu thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
        }

        // ===== NÚT HỦY =====
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaTaiXe.Text = "";
            txtTenTaiXe.Text = "";
            txtSoChuyen.Text = "";
            txtDoanhThu.Text = "";
        }

        // =================================================================================
        // PHẦN 2: LOGIC MỚI (BÁO CÁO THÁNG - TAB 2)
        // =================================================================================

        private void LoadNamVaoComboBox()
        {
            // Thêm các năm vào ComboBox để chọn
            cboNam.Items.Add("2023");
            cboNam.Items.Add("2024");
            cboNam.Items.Add("2025");
            cboNam.SelectedIndex = 0; // Mặc định chọn năm đầu
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (cboNam.SelectedItem == null) return;
            string namDuocChon = cboNam.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // CÂU SQL QUAN TRỌNG: GOM NHÓM DỮ LIỆU TỪ BẢNG DATXE
                    // COUNT(DISTINCT ...) để đếm số lượng duy nhất (ví dụ 1 tài xế chạy 10 chuyến chỉ đếm là 1 tài xế hoạt động)
                    string sql = @"
                        SELECT 
                            MONTH(NgayDat) AS 'Tháng',
                            COUNT(MaDatXe) AS 'Tổng Số Chuyến',
                            SUM(ThanhTien) AS 'Tổng Doanh Thu',
                            COUNT(DISTINCT MaTaiXe) AS 'Số Tài Xế Hoạt Động',
                            COUNT(DISTINCT MaXe) AS 'Số Xe Hoạt Động',
                            COUNT(DISTINCT MaKH) AS 'Số Khách Phục Vụ'
                        FROM datxe
                        WHERE YEAR(NgayDat) = @Nam
                        GROUP BY MONTH(NgayDat)
                        ORDER BY MONTH(NgayDat)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nam", namDuocChon);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dtBaoCao = new DataTable();
                    da.Fill(dtBaoCao);

                    // Hiển thị lên DataGridView mới ở Tab 2
                    dgvBaoCaoThang.DataSource = dtBaoCao;

                    FormatLuoiBaoCao();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
                }
            }
        }

        private void FormatLuoiBaoCao()
        {
            // Định dạng hiển thị cho đẹp
            if (dgvBaoCaoThang.Columns["Tổng Doanh Thu"] != null)
            {
                dgvBaoCaoThang.Columns["Tổng Doanh Thu"].DefaultCellStyle.Format = "#,### VNĐ";
                dgvBaoCaoThang.Columns["Tổng Doanh Thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvBaoCaoThang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
