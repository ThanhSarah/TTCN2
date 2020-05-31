namespace Quanlykho.Forms
{
    partial class frmHang
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
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDongianhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtXuatxu = new System.Windows.Forms.TextBox();
            this.txtTenHH = new System.Windows.Forms.TextBox();
            this.txtMaHH = new System.Windows.Forms.TextBox();
            this.lable4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDongiaban = new System.Windows.Forms.TextBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.grbThongtinhang = new System.Windows.Forms.GroupBox();
            this.txtGhichu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtAnh = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.grbThongtinhang.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 229);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 54;
            this.label7.Text = "Đơn giá bán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Ảnh";
            // 
            // txtDongianhap
            // 
            this.txtDongianhap.Location = new System.Drawing.Point(163, 166);
            this.txtDongianhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDongianhap.Name = "txtDongianhap";
            this.txtDongianhap.Size = new System.Drawing.Size(207, 26);
            this.txtDongianhap.TabIndex = 50;
            this.txtDongianhap.TextChanged += new System.EventHandler(this.txtDongianhap_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Đơn giá nhập";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(27, 406);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(805, 301);
            this.dataGridView.TabIndex = 48;
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(873, 462);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 35);
            this.btnHuy.TabIndex = 46;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(873, 194);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(112, 35);
            this.btnLuu.TabIndex = 45;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(873, 59);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 35);
            this.btnThem.TabIndex = 44;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtXuatxu
            // 
            this.txtXuatxu.Location = new System.Drawing.Point(516, 31);
            this.txtXuatxu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXuatxu.Name = "txtXuatxu";
            this.txtXuatxu.Size = new System.Drawing.Size(249, 26);
            this.txtXuatxu.TabIndex = 43;
            this.txtXuatxu.TextChanged += new System.EventHandler(this.txtXuatxu_TextChanged);
            // 
            // txtTenHH
            // 
            this.txtTenHH.Location = new System.Drawing.Point(163, 97);
            this.txtTenHH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenHH.Name = "txtTenHH";
            this.txtTenHH.Size = new System.Drawing.Size(207, 26);
            this.txtTenHH.TabIndex = 41;
            this.txtTenHH.TextChanged += new System.EventHandler(this.txtTenHH_TextChanged);
            // 
            // txtMaHH
            // 
            this.txtMaHH.Location = new System.Drawing.Point(163, 31);
            this.txtMaHH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaHH.Name = "txtMaHH";
            this.txtMaHH.Size = new System.Drawing.Size(207, 26);
            this.txtMaHH.TabIndex = 40;
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Location = new System.Drawing.Point(400, 34);
            this.lable4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(59, 20);
            this.lable4.TabIndex = 39;
            this.lable4.Text = "xuất xứ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tên hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Mã Hàng";
            // 
            // txtDongiaban
            // 
            this.txtDongiaban.Location = new System.Drawing.Point(163, 226);
            this.txtDongiaban.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDongiaban.Name = "txtDongiaban";
            this.txtDongiaban.Size = new System.Drawing.Size(207, 26);
            this.txtDongiaban.TabIndex = 55;
            this.txtDongiaban.TextChanged += new System.EventHandler(this.txtDongiaban_TextChanged);
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(514, 74);
            this.picAnh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(251, 95);
            this.picAnh.TabIndex = 56;
            this.picAnh.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(873, 602);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(112, 35);
            this.btnDong.TabIndex = 47;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(873, 326);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 35);
            this.btnXoa.TabIndex = 57;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // grbThongtinhang
            // 
            this.grbThongtinhang.Controls.Add(this.txtGhichu);
            this.grbThongtinhang.Controls.Add(this.label6);
            this.grbThongtinhang.Controls.Add(this.txtSoluong);
            this.grbThongtinhang.Controls.Add(this.label3);
            this.grbThongtinhang.Controls.Add(this.btnOpen);
            this.grbThongtinhang.Controls.Add(this.txtAnh);
            this.grbThongtinhang.Controls.Add(this.label1);
            this.grbThongtinhang.Controls.Add(this.label2);
            this.grbThongtinhang.Controls.Add(this.picAnh);
            this.grbThongtinhang.Controls.Add(this.txtDongiaban);
            this.grbThongtinhang.Controls.Add(this.lable4);
            this.grbThongtinhang.Controls.Add(this.label7);
            this.grbThongtinhang.Controls.Add(this.txtMaHH);
            this.grbThongtinhang.Controls.Add(this.label5);
            this.grbThongtinhang.Controls.Add(this.txtTenHH);
            this.grbThongtinhang.Controls.Add(this.txtDongianhap);
            this.grbThongtinhang.Controls.Add(this.label4);
            this.grbThongtinhang.Controls.Add(this.txtXuatxu);
            this.grbThongtinhang.Location = new System.Drawing.Point(27, 32);
            this.grbThongtinhang.Name = "grbThongtinhang";
            this.grbThongtinhang.Size = new System.Drawing.Size(793, 354);
            this.grbThongtinhang.TabIndex = 58;
            this.grbThongtinhang.TabStop = false;
            this.grbThongtinhang.Text = "Thông tin hàng";
            // 
            // txtGhichu
            // 
            this.txtGhichu.Location = new System.Drawing.Point(516, 231);
            this.txtGhichu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGhichu.Multiline = true;
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(249, 78);
            this.txtGhichu.TabIndex = 62;
            this.txtGhichu.TextChanged += new System.EventHandler(this.txtGhichu_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 286);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 61;
            this.label6.Text = "Ghi chú";
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(163, 283);
            this.txtSoluong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(207, 26);
            this.txtSoluong.TabIndex = 60;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 286);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 59;
            this.label3.Text = "Số lượng";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(696, 182);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(70, 40);
            this.btnOpen.TabIndex = 58;
            this.btnOpen.Text = "open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(516, 188);
            this.txtAnh.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(180, 26);
            this.txtAnh.TabIndex = 57;
            this.txtAnh.TextChanged += new System.EventHandler(this.txtAnh_TextChanged);
            // 
            // frmHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 747);
            this.Controls.Add(this.grbThongtinhang);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmHang";
            this.Text = "Thông tin hàng hóa";
            this.Load += new System.EventHandler(this.frmHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.grbThongtinhang.ResumeLayout(false);
            this.grbThongtinhang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDongianhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtXuatxu;
        private System.Windows.Forms.TextBox txtTenHH;
        private System.Windows.Forms.TextBox txtMaHH;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDongiaban;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox grbThongtinhang;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGhichu;
        private System.Windows.Forms.Label label6;
    }
}