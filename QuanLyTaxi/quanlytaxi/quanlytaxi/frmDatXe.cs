using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace quanlytaxi
{
    public partial class frmDatXe : Form
    {
        // Khai báo kết nối và DataAdapter
        DataSet ds = new DataSet("dsQLTaxi");
        MySqlDataAdapter daDatXe;
        MySqlConnection conn = new MySqlConnection();

        // Biến cờ để tránh vòng lặp vô hạn khi gán text tự động (quan trọng cho Lookup)
        private bool isUpdatingText = false;

        public frmDatXe()
        {
            InitializeComponent();
        }

        private void frmDatXe_Load(object sender, EventArgs e)
        {
            // Thiết lập Form
            this.AutoSize = false;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            conn.ConnectionString = "server=localhost;user=root;password=248569;database=qltaxi;";

            LoadDatXe();

            DataTable dtSoCho = new DataTable();
            dtSoCho.Columns.Add("Value");
            dtSoCho.Columns.Add("Text");
            dtSoCho.Rows.Add("4", "4 chỗ");
            dtSoCho.Rows.Add("7", "7 chỗ");
            dtSoCho.Rows.Add("16", "16 chỗ");
            cboSoCho.DataSource = dtSoCho;
            cboSoCho.DisplayMember = "Text";
            cboSoCho.ValueMember = "Value";
            if (cboSoCho.Items.Count > 0) cboSoCho.SelectedIndex = 0;

            // Format DataGridView (Đã thêm NgayDat)
            FormatDataGridView();

            // Thiết lập Command cho DataAdapter (Đã FIX NgayDat)
            SetupDataAdapterCommands();

            // Gắn sự kiện TextChanged cho các TextBox Mã để tự động lookup
            txtMaKhachHang.TextChanged += new EventHandler(txtMaKhachHang_TextChanged);
            txtMaTaiXe.TextChanged += new EventHandler(txtMaTaiXe_TextChanged);

            dtpNgayDatXe.Format = DateTimePickerFormat.Custom;
            dtpNgayDatXe.CustomFormat = "dd/MM/yyyy";
            dtpNgayDatXe.ShowUpDown = true;
        }

        private void FormatDataGridView()
        {
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

            dgvDatXe.Columns["MaTaiXe"].HeaderText = "Mã TX";
            dgvDatXe.Columns["MaTaiXe"].Width = 80;

            dgvDatXe.Columns["TenTaiXe"].HeaderText = "Tên tài xế";
            dgvDatXe.Columns["TenTaiXe"].Width = 150;

            dgvDatXe.Columns["SoCho"].HeaderText = "Số chỗ";
            dgvDatXe.Columns["SoCho"].Width = 70;

            dgvDatXe.Columns["NgayDat"].HeaderText = "Ngày Đặt";
            dgvDatXe.Columns["NgayDat"].Width = 150;
            dgvDatXe.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvDatXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // --- Setup DataAdapter Commands ---
        private void SetupDataAdapterCommands()
        {
            // ===== INSERT (Đã thêm NgayDat) =====
            string sInsert = @"INSERT INTO datxe(MaKH, MaXe, MaTaiXe, DiemDon, DiemDen, SoCho, NgayDat)
                               VALUES(@MaKH, @MaXe, @MaTaiXe, @DiemDon, @DiemDen, @SoCho, @NgayDat)";
            MySqlCommand cmdInsert = new MySqlCommand(sInsert, conn);
            cmdInsert.Parameters.Add("@MaKH", MySqlDbType.Int32, 0, "MaKH");
            cmdInsert.Parameters.Add("@MaXe", MySqlDbType.Int32, 0, "MaXe");
            cmdInsert.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            cmdInsert.Parameters.Add("@DiemDon", MySqlDbType.VarChar, 255, "DiemDon");
            cmdInsert.Parameters.Add("@DiemDen", MySqlDbType.VarChar, 255, "DiemDen");
            cmdInsert.Parameters.Add("@SoCho", MySqlDbType.Int32, 0, "SoCho");
            cmdInsert.Parameters.Add("@NgayDat", MySqlDbType.DateTime, 0, "NgayDat"); // Thêm Parameter NgayDat
            daDatXe.InsertCommand = cmdInsert;

            // ===== UPDATE (Đã thêm NgayDat) =====
            string sUpdate = @"UPDATE datxe SET MaKH=@MaKH, MaXe=@MaXe, MaTaiXe=@MaTaiXe, DiemDon=@DiemDon,
                               DiemDen=@DiemDen, SoCho=@SoCho, NgayDat=@NgayDat
                               WHERE MaDatXe=@MaDatXe";
            MySqlCommand cmdUpdate = new MySqlCommand(sUpdate, conn);
            cmdUpdate.Parameters.Add("@MaKH", MySqlDbType.Int32, 0, "MaKH");
            cmdUpdate.Parameters.Add("@MaXe", MySqlDbType.Int32, 0, "MaXe");
            cmdUpdate.Parameters.Add("@MaTaiXe", MySqlDbType.Int32, 0, "MaTaiXe");
            cmdUpdate.Parameters.Add("@DiemDon", MySqlDbType.VarChar, 255, "DiemDon");
            cmdUpdate.Parameters.Add("@DiemDen", MySqlDbType.VarChar, 255, "DiemDen");
            cmdUpdate.Parameters.Add("@SoCho", MySqlDbType.Int32, 0, "SoCho");
            cmdUpdate.Parameters.Add("@NgayDat", MySqlDbType.DateTime, 0, "NgayDat"); // Thêm Parameter NgayDat
            cmdUpdate.Parameters.Add("@MaDatXe", MySqlDbType.Int32, 0, "MaDatXe");
            daDatXe.UpdateCommand = cmdUpdate;

            // ===== DELETE (Giữ nguyên) =====
            string sDelete = @"DELETE FROM datxe WHERE MaDatXe=@MaDatXe";
            MySqlCommand cmdDelete = new MySqlCommand(sDelete, conn);
            cmdDelete.Parameters.Add("@MaDatXe", MySqlDbType.Int32, 0, "MaDatXe");
            daDatXe.DeleteCommand = cmdDelete;
        }

        // --- Hàm Tải Dữ Liệu Riêng ---
        private void LoadDatXe()
        {
            // Query JOIN để lấy tất cả thông tin cần thiết, bao gồm NgayDat
            string sQueryDatXe = @"
            SELECT dx.MaDatXe,
                   dx.MaKH,
                   kh.HoTen AS TenKhach,
                   kh.SDT AS SDTKhach,
                   dx.DiemDon,
                   dx.DiemDen,
                   dx.MaXe,
                   dx.MaTaiXe,        
                   tx.HoTen AS TenTaiXe,
                   dx.SoCho,
                   dx.NgayDat              
            FROM datxe dx
            LEFT JOIN khachhang kh ON dx.MaKH = kh.MaKH
            LEFT JOIN taixe tx ON dx.MaTaiXe = tx.MaTaiXe
            ORDER BY dx.NgayDat DESC;
            ";

            daDatXe = new MySqlDataAdapter(sQueryDatXe, conn);
            ds.Clear();
            daDatXe.Fill(ds, "tblDatXe");
            dgvDatXe.DataSource = ds.Tables["tblDatXe"];
        }

        // --- Hàm Lookup Khách Hàng (Tự động điền) ---
        private void LookupKhachHang(int maKH)
        {
            isUpdatingText = true;
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            if (maKH <= 0)
            {
                isUpdatingText = false;
                return;
            }

            string query = "SELECT HoTen, SDT FROM khachhang WHERE MaKH = @MaKH";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTenKH.Text = reader["HoTen"].ToString();
                        txtSDTKH.Text = reader["SDT"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi kết nối trong khi gõ nhanh
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                isUpdatingText = false;
            }
        }

        // --- Hàm Lookup Tài Xế (Tự động điền) ---
        private void LookupTaiXe(int maTaiXe)
        {
            isUpdatingText = true;
            txtTenTaiXe.Text = "";
            if (maTaiXe <= 0)
            {
                isUpdatingText = false;
                return;
            }

            string query = "SELECT HoTen FROM taixe WHERE MaTaiXe = @MaTaiXe";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTaiXe", maTaiXe);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTenTaiXe.Text = reader["HoTen"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi kết nối
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                isUpdatingText = false;
            }
        }

        // --- Sự kiện TextChanged Mã KH ---
        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingText) return;
            if (int.TryParse(txtMaKhachHang.Text, out int maKH))
            {
                LookupKhachHang(maKH);
            }
            else
            {
                txtTenKH.Text = "";
                txtSDTKH.Text = "";
            }
        }

        // --- Sự kiện TextChanged Mã Tài Xế ---
        private void txtMaTaiXe_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingText) return;
            if (int.TryParse(txtMaTaiXe.Text, out int maTaiXe))
            {
                LookupTaiXe(maTaiXe);
            }
            else
            {
                txtTenTaiXe.Text = "";
            }
        }

        // --- Sự kiện DataGridView Click (CẬP NHẬT NGÀY ĐẶT) ---
        private void dgvDatXe_Click(object sender, EventArgs e)
        {
            if (dgvDatXe.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvDatXe.SelectedRows[0];

                isUpdatingText = true;

                // Hiển thị thông tin
                txtMaKhachHang.Text = dr.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dr.Cells["TenKhach"].Value.ToString();
                txtSDTKH.Text = dr.Cells["SDTKhach"].Value.ToString();

                txtDiemDon.Text = dr.Cells["DiemDon"].Value.ToString();
                txtDiemDen.Text = dr.Cells["DiemDen"].Value.ToString();

                txtMaXe.Text = dr.Cells["MaXe"].Value.ToString();
                txtMaTaiXe.Text = dr.Cells["MaTaiXe"].Value.ToString();
                txtTenTaiXe.Text = dr.Cells["TenTaiXe"].Value.ToString();

                cboSoCho.SelectedValue = dr.Cells["SoCho"].Value.ToString();

                // HIỂN THỊ NGÀY ĐẶT TỪ DATABASE VÀO DateTimePicker
                try
                {
                    object ngayDatValue = dr.Cells["NgayDat"].Value;
                    if (ngayDatValue != DBNull.Value && ngayDatValue != null)
                    {
                        // Đảm bảo kiểu dữ liệu là DateTime trước khi gán
                        dtpNgayDatXe.Value = Convert.ToDateTime(ngayDatValue);
                    }
                    else
                    {
                        dtpNgayDatXe.Value = DateTime.Now;
                    }
                }
                catch (Exception)
                {
                    dtpNgayDatXe.Value = DateTime.Now;
                }

                isUpdatingText = false;
            }
        }

        // --- Sự kiện Thêm (CẬP NHẬT NGÀY ĐẶT) ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtMaXe.Text) ||
                string.IsNullOrWhiteSpace(txtMaTaiXe.Text) ||
                string.IsNullOrWhiteSpace(txtDiemDon.Text) ||
                string.IsNullOrWhiteSpace(txtDiemDen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đặt xe!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRow row = ds.Tables["tblDatXe"].NewRow();

                // Gán giá trị cho các cột thực sự trong bảng datxe
                row["MaKH"] = int.Parse(txtMaKhachHang.Text.Trim());
                row["MaXe"] = int.Parse(txtMaXe.Text.Trim());
                row["MaTaiXe"] = int.Parse(txtMaTaiXe.Text.Trim());
                row["DiemDon"] = txtDiemDon.Text.Trim();
                row["DiemDen"] = txtDiemDen.Text.Trim();
                row["SoCho"] = int.Parse(cboSoCho.SelectedValue.ToString());
                // LẤY GIÁ TRỊ NGÀY TỪ DATETIMEPICKER
                row["NgayDat"] = dtpNgayDatXe.Value;

                // Gán giá trị cho các cột hiển thị (cho DataGridView)
                row["TenKhach"] = txtTenKH.Text.Trim();
                row["SDTKhach"] = txtSDTKH.Text.Trim();
                row["TenTaiXe"] = txtTenTaiXe.Text.Trim();

                ds.Tables["tblDatXe"].Rows.Add(row);
                dgvDatXe.Refresh();
                MessageBox.Show("Thêm đặt xe mới thành công! Nhấn Lưu để cập nhật vào cơ sở dữ liệu.", "Thông báo");
            }
            catch (FormatException)
            {
                MessageBox.Show("Mã Khách Hàng, Mã Xe, Mã Tài Xế, Số Chỗ phải là số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Sự kiện Sửa (CẬP NHẬT NGÀY ĐẶT) ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDatXe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đặt xe cần sửa!", "Thông báo");
                return;
            }

            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text) ||
                string.IsNullOrWhiteSpace(txtMaXe.Text) ||
                string.IsNullOrWhiteSpace(txtMaTaiXe.Text) ||
                string.IsNullOrWhiteSpace(txtDiemDon.Text) ||
                string.IsNullOrWhiteSpace(txtDiemDen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đặt xe!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRowView rowView = dgvDatXe.CurrentRow.DataBoundItem as DataRowView;
                if (rowView == null) return;

                DataRow row = rowView.Row;

                // Gán giá trị cho các cột thực sự trong bảng datxe
                row["MaKH"] = int.Parse(txtMaKhachHang.Text.Trim());
                row["MaXe"] = int.Parse(txtMaXe.Text.Trim());
                row["MaTaiXe"] = int.Parse(txtMaTaiXe.Text.Trim());
                row["DiemDon"] = txtDiemDon.Text.Trim();
                row["DiemDen"] = txtDiemDen.Text.Trim();
                row["SoCho"] = int.Parse(cboSoCho.SelectedValue.ToString());
                // LẤY GIÁ TRỊ NGÀY TỪ DATETIMEPICKER
                row["NgayDat"] = dtpNgayDatXe.Value;

                // Cập nhật các cột hiển thị để lưới thấy thay đổi ngay
                row["TenKhach"] = txtTenKH.Text.Trim();
                row["SDTKhach"] = txtSDTKH.Text.Trim();
                row["TenTaiXe"] = txtTenTaiXe.Text.Trim();

                dgvDatXe.Refresh();
                MessageBox.Show("Sửa đặt xe thành công! Nhấn Lưu để cập nhật vào cơ sở dữ liệu.", "Thông báo");
            }
            catch (FormatException)
            {
                MessageBox.Show("Mã Khách Hàng, Mã Xe, Mã Tài Xế, Số Chỗ phải là số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Sự kiện Xóa (Giữ nguyên) ---
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

        // --- Sự kiện Lưu (Giữ nguyên) ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDatXe.EndEdit();

                // Ngăn chặn lỗi AutoIncrement
                if (ds.Tables["tblDatXe"].Columns.Contains("MaDatXe"))
                {
                    ds.Tables["tblDatXe"].Columns["MaDatXe"].AutoIncrement = false;
                }

                daDatXe.Update(ds.Tables["tblDatXe"]);
                MessageBox.Show("Đã lưu thay đổi vào MySQL thành công!", "Thông báo");

                // Tải lại dữ liệu sau khi lưu để có MaDatXe mới (nếu có)
                LoadDatXe();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ràng buộc khóa ngoại
                if (ex.Message.Contains("FOREIGN KEY"))
                {
                    MessageBox.Show("Lỗi ràng buộc khóa ngoại: Mã Khách Hàng, Mã Xe, hoặc Mã Tài Xế không tồn tại trong hệ thống!", "Lỗi Lưu Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Sự kiện Hủy (Cập nhật NgayDat) ---
        private void btnHuy_Click(object sender, EventArgs e)
        {
            isUpdatingText = true;

            txtMaKhachHang.Text = "";
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtDiemDon.Text = "";
            txtDiemDen.Text = "";
            txtMaXe.Text = "";
            txtTenTaiXe.Text = "";
            txtMaTaiXe.Text = "";
            // Đặt lại ngày về ngày hiện tại khi Hủy
            dtpNgayDatXe.Value = DateTime.Now;

            isUpdatingText = false;

            if (cboSoCho.Items.Count > 0) cboSoCho.SelectedIndex = 0;

            // Hủy các thay đổi chưa lưu
            ds.Tables["tblDatXe"].RejectChanges();
            dgvDatXe.Refresh();

            // Hủy bộ lọc để hiện lại toàn bộ dữ liệu gốc
            ApplyFilter("");
        }

        private void btntimKiem_Click(object sender, EventArgs e)
        {
             string searchValue = txttimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                // Nếu ô tìm kiếm trống, hiển thị lại toàn bộ dữ liệu
                ApplyFilter("");
                return;
            }

            // Xây dựng chuỗi lọc (Filter Expression) để tìm kiếm trên nhiều cột
            // Sử dụng 'LIKE' và '%{value}%' để tìm kiếm chuỗi con không phân biệt chữ hoa/thường
            // Các cột tìm kiếm: MaDatXe, TenKhach, SDTKhach, DiemDon, DiemDen, TenTaiXe
            string filterExpression = string.Format(
                "Convert(MaDatXe, 'System.String') LIKE '%{0}%' OR " +
                "TenKhach LIKE '%{0}%' OR " +
                "SDTKhach LIKE '%{0}%' OR " +
                "DiemDon LIKE '%{0}%' OR " +
                "DiemDen LIKE '%{0}%' OR " +
                "TenTaiXe LIKE '%{0}%'",
                searchValue.Replace("'", "''") // Tránh lỗi SQL Injection cho RowFilter
            );

            ApplyFilter(filterExpression);

        }

        private void ApplyFilter(string filter)
        {
            try
            {
                DataTable dt = ds.Tables["tblDatXe"];

                // Lấy DataView từ DataTable
                DataView dv = dt.DefaultView;

                // Áp dụng bộ lọc
                dv.RowFilter = filter;

                // Gắn DataView đã lọc lại vào DataGridView
                dgvDatXe.DataSource = dv;

                if (string.IsNullOrEmpty(filter))
                {
                    MessageBox.Show("Đã hủy bỏ tìm kiếm. Hiển thị toàn bộ dữ liệu.", "Thông báo");
                }
                else if (dv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào trùng khớp.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng bộ lọc: " + ex.Message, "Lỗi Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}