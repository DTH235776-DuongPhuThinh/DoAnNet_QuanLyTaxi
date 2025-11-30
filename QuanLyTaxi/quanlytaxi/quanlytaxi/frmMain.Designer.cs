namespace quanlytaxi
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDMQuanLyTaiXe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDMQuanLyXe = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabQuanLyTaiXe = new System.Windows.Forms.TabPage();
            this.tabQuanLyXe = new System.Windows.Forms.TabPage();
            this.tabDatXe = new System.Windows.Forms.TabPage();
            this.tabKH = new System.Windows.Forms.TabPage();
            this.tabBCThongKe = new System.Windows.Forms.TabPage();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.đặtXeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelHeader.Location = new System.Drawing.Point(516, 38);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(253, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "QUẢN LÝ TAXI ";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDanhMuc});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuDanhMuc
            // 
            this.menuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDMQuanLyTaiXe,
            this.toolDMQuanLyXe,
            this.đặtXeToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.báoCáoThốngKêToolStripMenuItem});
            this.menuDanhMuc.Name = "menuDanhMuc";
            this.menuDanhMuc.Size = new System.Drawing.Size(109, 29);
            this.menuDanhMuc.Text = "Danh mục";
            // 
            // toolDMQuanLyTaiXe
            // 
            this.toolDMQuanLyTaiXe.Name = "toolDMQuanLyTaiXe";
            this.toolDMQuanLyTaiXe.Size = new System.Drawing.Size(271, 34);
            this.toolDMQuanLyTaiXe.Text = "Quản lý tài xế";
            this.toolDMQuanLyTaiXe.Click += new System.EventHandler(this.toolDMQuanLyTaiXe_Click);
            // 
            // toolDMQuanLyXe
            // 
            this.toolDMQuanLyXe.Name = "toolDMQuanLyXe";
            this.toolDMQuanLyXe.Size = new System.Drawing.Size(271, 34);
            this.toolDMQuanLyXe.Text = "Quản lý xe";
            this.toolDMQuanLyXe.Click += new System.EventHandler(this.toolDMQuanLyXe_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabQuanLyTaiXe);
            this.tabMain.Controls.Add(this.tabQuanLyXe);
            this.tabMain.Controls.Add(this.tabDatXe);
            this.tabMain.Controls.Add(this.tabKH);
            this.tabMain.Controls.Add(this.tabHoaDon);
            this.tabMain.Controls.Add(this.tabBCThongKe);
            this.tabMain.Location = new System.Drawing.Point(14, 82);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1281, 760);
            this.tabMain.TabIndex = 2;
            // 
            // tabQuanLyTaiXe
            // 
            this.tabQuanLyTaiXe.Location = new System.Drawing.Point(4, 29);
            this.tabQuanLyTaiXe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabQuanLyTaiXe.Name = "tabQuanLyTaiXe";
            this.tabQuanLyTaiXe.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabQuanLyTaiXe.Size = new System.Drawing.Size(1273, 727);
            this.tabQuanLyTaiXe.TabIndex = 0;
            this.tabQuanLyTaiXe.Text = "Quản lý tài xế";
            this.tabQuanLyTaiXe.UseVisualStyleBackColor = true;
            // 
            // tabQuanLyXe
            // 
            this.tabQuanLyXe.Location = new System.Drawing.Point(4, 29);
            this.tabQuanLyXe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabQuanLyXe.Name = "tabQuanLyXe";
            this.tabQuanLyXe.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabQuanLyXe.Size = new System.Drawing.Size(1273, 727);
            this.tabQuanLyXe.TabIndex = 1;
            this.tabQuanLyXe.Text = "Quản lý xe";
            this.tabQuanLyXe.UseVisualStyleBackColor = true;
            // 
            // tabDatXe
            // 
            this.tabDatXe.Location = new System.Drawing.Point(4, 29);
            this.tabDatXe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDatXe.Name = "tabDatXe";
            this.tabDatXe.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDatXe.Size = new System.Drawing.Size(1273, 727);
            this.tabDatXe.TabIndex = 2;
            this.tabDatXe.Text = "Đặt xe";
            this.tabDatXe.UseVisualStyleBackColor = true;
            // 
            // tabKH
            // 
            this.tabKH.Location = new System.Drawing.Point(4, 29);
            this.tabKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabKH.Name = "tabKH";
            this.tabKH.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabKH.Size = new System.Drawing.Size(1273, 727);
            this.tabKH.TabIndex = 3;
            this.tabKH.Text = "Quản lý khách hàng";
            this.tabKH.UseVisualStyleBackColor = true;
            // 
            // tabBCThongKe
            // 
            this.tabBCThongKe.Location = new System.Drawing.Point(4, 29);
            this.tabBCThongKe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBCThongKe.Name = "tabBCThongKe";
            this.tabBCThongKe.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabBCThongKe.Size = new System.Drawing.Size(1273, 727);
            this.tabBCThongKe.TabIndex = 5;
            this.tabBCThongKe.Text = "Báo cáo - Thống Kê";
            this.tabBCThongKe.UseVisualStyleBackColor = true;
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Location = new System.Drawing.Point(4, 29);
            this.tabHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabHoaDon.Size = new System.Drawing.Size(1273, 727);
            this.tabHoaDon.TabIndex = 6;
            this.tabHoaDon.Text = "Hóa Đơn";
            this.tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // đặtXeToolStripMenuItem
            // 
            this.đặtXeToolStripMenuItem.Name = "đặtXeToolStripMenuItem";
            this.đặtXeToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.đặtXeToolStripMenuItem.Text = "Đặt xe";
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa đơn";
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            this.báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            this.báoCáoThốngKêToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.báoCáoThốngKêToolStripMenuItem.Text = "Báo cáo thống kê";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 858);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHƯƠNG TRÌNH";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem toolDMQuanLyTaiXe;
        private System.Windows.Forms.ToolStripMenuItem toolDMQuanLyXe;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabQuanLyTaiXe;
        private System.Windows.Forms.TabPage tabQuanLyXe;
        private System.Windows.Forms.TabPage tabDatXe;
        private System.Windows.Forms.TabPage tabKH;
        private System.Windows.Forms.TabPage tabBCThongKe;
        private System.Windows.Forms.TabPage tabHoaDon;
        private System.Windows.Forms.ToolStripMenuItem đặtXeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
    }
}