using System;
using System.Windows.Forms;

namespace quanlytaxi
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            // Thiết lập ký tự ẩn cho mật khẩu
            txtMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            bool isAdmin = false;
            bool loginSuccess = false;

            // --- Logic Kiểm tra Đăng nhập Cố định ---
            if (username == "admin" && password == "123") // Tài khoản Quản trị
            {
                isAdmin = true;
                loginSuccess = true;
            }
            else if (username == "nv" && password == "1") // Tài khoản Nhân viên
            {
                isAdmin = false;
                loginSuccess = true;
            }

            if (loginSuccess)
            {
                // Đăng nhập thành công
                this.Hide();
                // Mở Form Chính và truyền thông tin phân quyền
                frmMain fMain = new frmMain(isAdmin, username);
                fMain.Show();

                // Lưu ý: Form DangNhap sẽ tự đóng khi ứng dụng kết thúc
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtDangNhap.Focus();
            }
        }
    }
}