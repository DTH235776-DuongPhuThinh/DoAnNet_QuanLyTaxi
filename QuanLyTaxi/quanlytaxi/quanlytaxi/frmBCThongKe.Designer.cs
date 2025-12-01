namespace quanlytaxi
{
    partial class frmBCThongKe
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQLDTTX = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimTaiXe = new System.Windows.Forms.Button();
            this.txtTimKiemTaiXe = new System.Windows.Forms.TextBox();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.txtTenTaiXe = new System.Windows.Forms.TextBox();
            this.txtSoChuyen = new System.Windows.Forms.TextBox();
            this.txtMaTaiXe = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.dgvBaoCaoThang = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabQLDTTX.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.tabBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoThang)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabQLDTTX);
            this.tabControl1.Controls.Add(this.tabBaoCao);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1241, 654);
            this.tabControl1.TabIndex = 0;
            // 
            // tabQLDTTX
            // 
            this.tabQLDTTX.Controls.Add(this.groupBox1);
            this.tabQLDTTX.Controls.Add(this.txtDoanhThu);
            this.tabQLDTTX.Controls.Add(this.txtTenTaiXe);
            this.tabQLDTTX.Controls.Add(this.txtSoChuyen);
            this.tabQLDTTX.Controls.Add(this.txtMaTaiXe);
            this.tabQLDTTX.Controls.Add(this.btnSua);
            this.tabQLDTTX.Controls.Add(this.btnHuy);
            this.tabQLDTTX.Controls.Add(this.btnLuu);
            this.tabQLDTTX.Controls.Add(this.btnXoa);
            this.tabQLDTTX.Controls.Add(this.btnThem);
            this.tabQLDTTX.Controls.Add(this.dgvThongKe);
            this.tabQLDTTX.Controls.Add(this.label3);
            this.tabQLDTTX.Controls.Add(this.label5);
            this.tabQLDTTX.Controls.Add(this.label4);
            this.tabQLDTTX.Controls.Add(this.label2);
            this.tabQLDTTX.Controls.Add(this.label1);
            this.tabQLDTTX.Location = new System.Drawing.Point(4, 36);
            this.tabQLDTTX.Name = "tabQLDTTX";
            this.tabQLDTTX.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLDTTX.Size = new System.Drawing.Size(1233, 614);
            this.tabQLDTTX.TabIndex = 0;
            this.tabQLDTTX.Text = "Quản lý doanh thu tài xế";
            this.tabQLDTTX.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimTaiXe);
            this.groupBox1.Controls.Add(this.txtTimKiemTaiXe);
            this.groupBox1.Location = new System.Drawing.Point(618, 139);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(289, 88);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnTimTaiXe
            // 
            this.btnTimTaiXe.Location = new System.Drawing.Point(192, 34);
            this.btnTimTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimTaiXe.Name = "btnTimTaiXe";
            this.btnTimTaiXe.Size = new System.Drawing.Size(90, 36);
            this.btnTimTaiXe.TabIndex = 28;
            this.btnTimTaiXe.Text = "Tìm";
            this.btnTimTaiXe.UseVisualStyleBackColor = true;
            this.btnTimTaiXe.Click += new System.EventHandler(this.btnTimTaiXe_Click);
            // 
            // txtTimKiemTaiXe
            // 
            this.txtTimKiemTaiXe.Location = new System.Drawing.Point(18, 34);
            this.txtTimKiemTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiemTaiXe.Name = "txtTimKiemTaiXe";
            this.txtTimKiemTaiXe.Size = new System.Drawing.Size(164, 35);
            this.txtTimKiemTaiXe.TabIndex = 27;
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(470, 192);
            this.txtDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(111, 35);
            this.txtDoanhThu.TabIndex = 22;
            // 
            // txtTenTaiXe
            // 
            this.txtTenTaiXe.Location = new System.Drawing.Point(134, 192);
            this.txtTenTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTaiXe.Name = "txtTenTaiXe";
            this.txtTenTaiXe.Size = new System.Drawing.Size(208, 35);
            this.txtTenTaiXe.TabIndex = 23;
            // 
            // txtSoChuyen
            // 
            this.txtSoChuyen.Location = new System.Drawing.Point(471, 136);
            this.txtSoChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoChuyen.Name = "txtSoChuyen";
            this.txtSoChuyen.Size = new System.Drawing.Size(111, 35);
            this.txtSoChuyen.TabIndex = 24;
            // 
            // txtMaTaiXe
            // 
            this.txtMaTaiXe.Location = new System.Drawing.Point(134, 136);
            this.txtMaTaiXe.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTaiXe.Name = "txtMaTaiXe";
            this.txtMaTaiXe.Size = new System.Drawing.Size(119, 35);
            this.txtMaTaiXe.TabIndex = 25;
            this.txtMaTaiXe.TextChanged += new System.EventHandler(this.txtMaTaiXe_TextChanged);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSua.Location = new System.Drawing.Point(946, 158);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 44);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHuy.Location = new System.Drawing.Point(1000, 212);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(96, 44);
            this.btnHuy.TabIndex = 20;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(1052, 108);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(96, 42);
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoa.Location = new System.Drawing.Point(1052, 158);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 44);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThem.Location = new System.Drawing.Point(946, 108);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 42);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(15, 285);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 62;
            this.dgvThongKe.RowTemplate.Height = 28;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(1199, 290);
            this.dgvThongKe.TabIndex = 15;
            this.dgvThongKe.Click += new System.EventHandler(this.dgvThongKe_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tên tài xế";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(350, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Doanh thu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(351, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "Số chuyến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã tài xế";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(347, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 45);
            this.label1.TabIndex = 14;
            this.label1.Text = "QUẢN LÝ DOANH THU TÀI XẾ";
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.btnXemBaoCao);
            this.tabBaoCao.Controls.Add(this.cboNam);
            this.tabBaoCao.Controls.Add(this.dgvBaoCaoThang);
            this.tabBaoCao.Controls.Add(this.label7);
            this.tabBaoCao.Controls.Add(this.label6);
            this.tabBaoCao.Location = new System.Drawing.Point(4, 36);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(1233, 614);
            this.tabBaoCao.TabIndex = 1;
            this.tabBaoCao.Text = "Báo cáo tháng";
            this.tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXemBaoCao.Location = new System.Drawing.Point(655, 157);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(180, 53);
            this.btnXemBaoCao.TabIndex = 3;
            this.btnXemBaoCao.Text = "Xem thống kê";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(528, 166);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 35);
            this.cboNam.TabIndex = 2;
            // 
            // dgvBaoCaoThang
            // 
            this.dgvBaoCaoThang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoThang.Location = new System.Drawing.Point(28, 264);
            this.dgvBaoCaoThang.Name = "dgvBaoCaoThang";
            this.dgvBaoCaoThang.RowHeadersWidth = 62;
            this.dgvBaoCaoThang.RowTemplate.Height = 28;
            this.dgvBaoCaoThang.Size = new System.Drawing.Size(1164, 308);
            this.dgvBaoCaoThang.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(411, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "Chọn năm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(449, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(362, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "BÁO CÁO THÁNG";
            // 
            // frmBCThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1265, 678);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBCThongKe";
            this.Text = "frmBCThongKe";
            this.Load += new System.EventHandler(this.frmBCThongKe_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabQLDTTX.ResumeLayout(false);
            this.tabQLDTTX.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.tabBaoCao.ResumeLayout(false);
            this.tabBaoCao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoThang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQLDTTX;
        private System.Windows.Forms.TabPage tabBaoCao;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.TextBox txtTenTaiXe;
        private System.Windows.Forms.TextBox txtSoChuyen;
        private System.Windows.Forms.TextBox txtMaTaiXe;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.DataGridView dgvBaoCaoThang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTimTaiXe;
        private System.Windows.Forms.TextBox txtTimKiemTaiXe;
        private System.Windows.Forms.Button btnLuu;
    }
}