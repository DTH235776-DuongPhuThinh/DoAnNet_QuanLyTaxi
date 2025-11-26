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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelHeader.Location = new System.Drawing.Point(135, 125);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(634, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "QUẢN LÝ TAXI - QUẢN LÝ XE VÀ TÀI XẾ";
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
            this.menuStrip1.Size = new System.Drawing.Size(880, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuDanhMuc
            // 
            this.menuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDMQuanLyTaiXe,
            this.toolDMQuanLyXe});
            this.menuDanhMuc.Name = "menuDanhMuc";
            this.menuDanhMuc.Size = new System.Drawing.Size(109, 29);
            this.menuDanhMuc.Text = "Danh mục";
            // 
            // toolDMQuanLyTaiXe
            // 
            this.toolDMQuanLyTaiXe.Name = "toolDMQuanLyTaiXe";
            this.toolDMQuanLyTaiXe.Size = new System.Drawing.Size(270, 34);
            this.toolDMQuanLyTaiXe.Text = "Quản lý tài xế";
            this.toolDMQuanLyTaiXe.Click += new System.EventHandler(this.toolDMQuanLyTaiXe_Click);
            // 
            // toolDMQuanLyXe
            // 
            this.toolDMQuanLyXe.Name = "toolDMQuanLyXe";
            this.toolDMQuanLyXe.Size = new System.Drawing.Size(270, 34);
            this.toolDMQuanLyXe.Text = "Quản lý xe";
            this.toolDMQuanLyXe.Click += new System.EventHandler(this.toolDMQuanLyXe_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 566);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHƯƠNG TRÌNH";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem toolDMQuanLyTaiXe;
        private System.Windows.Forms.ToolStripMenuItem toolDMQuanLyXe;
    }
}