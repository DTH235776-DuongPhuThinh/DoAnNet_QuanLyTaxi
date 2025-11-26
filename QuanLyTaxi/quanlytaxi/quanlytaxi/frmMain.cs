using System;
using System.Windows.Forms;

namespace quanlytaxi
{
    public partial class frmMain : Form
    {
        private bool _isAdmin;
        private string _username;

        // Constructor mặc định (cần thiết cho Designer)
        public frmMain()
        {
            InitializeComponent();
        }

        // Constructor nhận thông tin đăng nhập
        public frmMain(bool isAdmin, string username)
        {
            InitializeComponent();
            this._isAdmin = isAdmin;
            this._username = username;
            this.Text = "CHƯƠNG TRÌNH - " + (_isAdmin ? "Quản trị viên" : "Nhân viên") + " (" + username + ")";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Thiết lập Form chính là MDI Container để chứa các Form con
            this.IsMdiContainer = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Đảm bảo ứng dụng thoát hoàn toàn khi form chính đóng
            Application.Exit();
        }

        // --- Xử lý sự kiện Click cho Menu Quản lý Tài Xế ---
        private void toolDMQuanLyTaiXe_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra form đã mở chưa
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.GetType() == typeof(frmDMQuanLyTaiXe))
                {
                    childForm.BringToFront();
                    return;
                }
            }

            // 2. Mở form mới nếu chưa mở
            frmDMQuanLyTaiXe frmTaiXe = new frmDMQuanLyTaiXe();
            frmTaiXe.MdiParent = this;
            frmTaiXe.Show();
        }
        // --- Xử lý sự kiện Click cho Menu Quản lý Xe ---
        private void toolDMQuanLyXe_Click(object sender, EventArgs e)
        {

            // 1. Kiểm tra form đã mở chưa
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.GetType() == typeof(frmDMQuanLyXe))
                {
                    childForm.BringToFront();
                    return;
                }
            }

            // 2. Mở form mới nếu chưa mở
            frmDMQuanLyXe frmXe = new frmDMQuanLyXe();
            frmXe.MdiParent = this;
            frmXe.Show();
        }
    }
}