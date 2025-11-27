using System;
using System.Windows.Forms;

namespace quanlytaxi
{
    public partial class frmMain : Form
    {
        private bool _isAdmin;
        private string _username;

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(bool isAdmin, string username)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
            _username = username;
            this.Text = "CHƯƠNG TRÌNH QUẢN LÝ TAXI - " + (_isAdmin ? "Quản trị viên" : "Nhân viên") + " (" + username + ")";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = false;   // KHÔNG dùng MDI nữa
            frmDMQuanLyTaiXe frmTaiXe = new frmDMQuanLyTaiXe();
            frmTaiXe.TopLevel = false;
            frmTaiXe.FormBorderStyle = FormBorderStyle.None;
            frmTaiXe.Dock = DockStyle.Fill;
            tabQuanLyTaiXe.Controls.Add(frmTaiXe);
            frmTaiXe.Show();

            frmDMQuanLyXe frmXe = new frmDMQuanLyXe();
            frmXe.TopLevel = false;
            frmXe.FormBorderStyle = FormBorderStyle.None;
            frmXe.Dock = DockStyle.Fill;
            tabQuanLyXe.Controls.Add(frmXe);
            frmXe.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===== HÀM CHUNG MỞ TAB ====
        private void OpenTab(string title, Form form)
        {
            // Kiểm tra tab đã tồn tại chưa
            foreach (TabPage page in tabMain.TabPages)
            {
                if (page.Text == title)
                {
                    tabMain.SelectedTab = page;
                    return;
                }
            }

            // Tạo tab mới
            TabPage newTab = new TabPage(title);
            tabMain.TabPages.Add(newTab);
            tabMain.SelectedTab = newTab;

            // Nhúng form vào tab
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            newTab.Controls.Add(form);
            form.Show();
        }

        // ===== MENU QUẢN LÝ TÀI XẾ =====
        private void toolDMQuanLyTaiXe_Click(object sender, EventArgs e)
        {
            OpenTab("Quản lý tài xế", new frmDMQuanLyTaiXe());
        }

        // ===== MENU QUẢN LÝ XE =====
        private void toolDMQuanLyXe_Click(object sender, EventArgs e)
        {
            OpenTab("Quản lý xe", new frmDMQuanLyXe());
        }
    }
}
