namespace quanlytaxi
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTapTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyXe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyTaxi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyTaiXe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiemXe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiemTaiXe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHƯƠNG TRÌNH QUẢN LÝ TAXI - XE - TÀI XẾ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTapTin,
            this.mnuDanhMuc,
            this.mnuTimKiem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTapTin
            // 
            this.mnuTapTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThoat});
            this.mnuTapTin.Name = "mnuTapTin";
            this.mnuTapTin.Size = new System.Drawing.Size(82, 29);
            this.mnuTapTin.Text = "Tập tin";
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(270, 34);
            this.mnuThoat.Text = "Thoát";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuanLyXe,
            this.mnuQuanLyTaxi,
            this.mnuQuanLyTaiXe});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(109, 29);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuQuanLyXe
            // 
            this.mnuQuanLyXe.Name = "mnuQuanLyXe";
            this.mnuQuanLyXe.Size = new System.Drawing.Size(270, 34);
            this.mnuQuanLyXe.Text = "Quản lý xe";
            // 
            // mnuQuanLyTaxi
            // 
            this.mnuQuanLyTaxi.Name = "mnuQuanLyTaxi";
            this.mnuQuanLyTaxi.Size = new System.Drawing.Size(270, 34);
            this.mnuQuanLyTaxi.Text = "Quản lý taxi";
            // 
            // mnuQuanLyTaiXe
            // 
            this.mnuQuanLyTaiXe.Name = "mnuQuanLyTaiXe";
            this.mnuQuanLyTaiXe.Size = new System.Drawing.Size(270, 34);
            this.mnuQuanLyTaiXe.Text = "Quản lý tài xế";
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimKiemXe,
            this.mnuTimKiemTaiXe});
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Size = new System.Drawing.Size(100, 29);
            this.mnuTimKiem.Text = "Tìm kiếm";
            // 
            // mnuTimKiemXe
            // 
            this.mnuTimKiemXe.Name = "mnuTimKiemXe";
            this.mnuTimKiemXe.Size = new System.Drawing.Size(270, 34);
            this.mnuTimKiemXe.Text = "Tìm kiếm xe";
            // 
            // mnuTimKiemTaiXe
            // 
            this.mnuTimKiemTaiXe.Name = "mnuTimKiemTaiXe";
            this.mnuTimKiemTaiXe.Size = new System.Drawing.Size(270, 34);
            this.mnuTimKiemTaiXe.Text = "Tìm kiếm tài xế";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "CHƯƠNG TRÌNH";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTapTin;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyXe;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyTaxi;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyTaiXe;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiemXe;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiemTaiXe;
    }
}