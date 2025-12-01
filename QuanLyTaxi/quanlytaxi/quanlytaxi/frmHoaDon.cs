using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing; // Để in ấn
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlytaxi
{
    public partial class frmHoaDon : Form
    {
        string connString = "server=localhost;user=root;password=cyclone221;database=qltaxi;";
        public frmHoaDon()
        {
            InitializeComponent();
            // Gắn sự kiện in ấn ngay khi khởi tạo
            printDocument1.PrintPage += new PrintPageEventHandler(InHoaDon_PrintPage);
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadChuyenXeChuaThanhToan();
        }

        // 1. TẢI DANH SÁCH CHUYẾN XE CHƯA THANH TOÁN
        // Logic: Lấy các chuyến trong bảng datxe MÀ CHƯA CÓ mặt trong bảng hoadon
        private void LoadChuyenXeChuaThanhToan()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            d.MaDatXe,
                            d.NgayDat,  -- <--- THÊM DÒNG NÀY (Lấy ngày giờ đặt xe)
                            k.HoTen AS TenKhach, 
                            d.DiemDon, 
                            d.DiemDen, 
                            d.ThanhTien 
                        FROM datxe d
                        JOIN khachhang k ON d.MaKH = k.MaKH
                        WHERE d.MaDatXe NOT IN (SELECT MaDatXe FROM hoadon)
                        ORDER BY d.MaDatXe ASC"; // <--- Thêm dòng này (ASC là tăng dần)

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvChoThanhToan.DataSource = dt;

                    // Format tiền cho đẹp
                    if (dgvChoThanhToan.Columns["ThanhTien"] != null)
                        dgvChoThanhToan.Columns["ThanhTien"].DefaultCellStyle.Format = "#,###";

                    dgvChoThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
            }
        }

        // 2. CHỌN CHUYẾN XE TỪ LƯỚI
        private void dgvChoThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChoThanhToan.Rows[e.RowIndex];
                txtMaDatXe.Text = row.Cells["MaDatXe"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenKhach"].Value.ToString();
                txtDiemDi.Text = row.Cells["DiemDon"].Value.ToString();
                txtDiemDen.Text = row.Cells["DiemDen"].Value.ToString();

                // Format số tiền bỏ dấu phẩy để đưa vào TextBox
                decimal tien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                txtThanhTien.Text = tien.ToString("0");

                if (row.Cells["NgayDat"].Value != DBNull.Value)
                {
                    // Chuyển đổi sang dạng ngày tháng năm (dd/MM/yyyy)
                    DateTime ngayDi = Convert.ToDateTime(row.Cells["NgayDat"].Value);
                    txtNgayDat.Text = ngayDi.ToString("dd/MM/yyyy HH:mm"); // Hiện cả giờ phút
                }
                else
                {
                    txtNgayDat.Text = "";
                }
            }
        }

        // 3. LƯU HÓA ĐƠN
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDatXe.Text)) return;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO hoadon (MaDatXe, TongTien, GhiChu, NgayLap) 
                                   VALUES (@Ma, @Tien, @GhiChu, NOW());
                                   SELECT LAST_INSERT_ID(); "; // <--- Thêm câu lệnh này để lấy ID vừa sinh ra

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMaDatXe.Text);
                    cmd.Parameters.AddWithValue("@Tien", decimal.Parse(txtThanhTien.Text));
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);

                    // Thực thi và lấy ID về
                    object result = cmd.ExecuteScalar();
                    int idHoaDonMoi = Convert.ToInt32(result);

                    // Hiển thị lên Form cho người dùng thấy
                    txtMaHoaDon.Text = idHoaDonMoi.ToString();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thanh toán thành công! Mã hóa đơn: " + idHoaDonMoi);

                    // Tải lại danh sách để chuyến vừa trả biến mất khỏi lưới
                    LoadChuyenXeChuaThanhToan();

                    // Cho phép in
                    btnIn.Enabled = true;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
            }
        }

        // 4. IN HÓA ĐƠN (Preview)
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDatXe.Text))
            {
                MessageBox.Show("Vui lòng chọn chuyến xe để in!");
                return;
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        // 5. THIẾT KẾ MẪU IN
        private void InHoaDon_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTieuDe = new Font("Arial", 16, FontStyle.Bold);
            Font fontThuong = new Font("Arial", 12);
            Font fontDam = new Font("Arial", 12, FontStyle.Bold);

            float y = 20;
            int margin = 40;

            // Vẽ Logo/Tên hãng
            g.DrawString("TAXI SYSTEM", fontTieuDe, Brushes.Blue, margin + 80, y);
            y += 40;
            g.DrawString("HÓA ĐƠN THANH TOÁN", fontDam, Brushes.Black, margin + 40, y);
            y += 40;
            // Vẽ Mã hóa đơn ngay dưới tiêu đề
            g.DrawString("Mã HĐ: " + txtMaHoaDon.Text, fontThuong, Brushes.Black, margin + 200, y);

            // Vẽ chi tiết
            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontThuong, Brushes.Black, margin, y);
            y += 30;
            g.DrawString("Mã chuyến: " + txtMaDatXe.Text, fontThuong, Brushes.Black, margin, y);
            y += 30;
            g.DrawString("Khách hàng: " + txtTenKhach.Text, fontThuong, Brushes.Black, margin, y);
            y += 30;
            g.DrawString("Từ: " + txtDiemDi.Text, fontThuong, Brushes.Black, margin, y);
            y += 30;
            g.DrawString("Đến: " + txtDiemDen.Text, fontThuong, Brushes.Black, margin, y);
            y += 30;

            // Đường kẻ
            g.DrawLine(Pens.Black, margin, y, 300, y);
            y += 20;

            // Tổng tiền
            g.DrawString("TỔNG TIỀN:", fontDam, Brushes.Black, margin, y);
            decimal tien = decimal.Parse(txtThanhTien.Text);
            g.DrawString(string.Format("{0:N0} VNĐ", tien), fontDam, Brushes.Red, margin + 120, y);

            y += 50;
            g.DrawString("Cảm ơn quý khách!", new Font("Arial", 10, FontStyle.Italic), Brushes.Gray, margin + 50, y);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadChuyenXeChuaThanhToan(); // Gọi lại hàm tải dữ liệu

            // Xóa trắng các ô nhập liệu cũ
            txtMaDatXe.Text = "";
            txtTenKhach.Text = "";
            txtDiemDi.Text = "";
            txtDiemDen.Text = "";
            txtThanhTien.Text = "";
            txtGhiChu.Text = "";
        }
    }
}
