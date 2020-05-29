namespace Quanlykho.Forms
{
    partial class frmTimkiemhanghoa
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtLoaihang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenhang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMahang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(420, 340);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(59, 38);
            this.btnDong.TabIndex = 51;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnTimlai
            // 
            this.btnTimlai.Location = new System.Drawing.Point(224, 340);
            this.btnTimlai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(59, 38);
            this.btnTimlai.TabIndex = 50;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(26, 340);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(59, 38);
            this.btnTim.TabIndex = 49;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(25, 126);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 27;
            this.dataGridView.Size = new System.Drawing.Size(454, 175);
            this.dataGridView.TabIndex = 48;
            // 
            // txtLoaihang
            // 
            this.txtLoaihang.Location = new System.Drawing.Point(92, 71);
            this.txtLoaihang.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoaihang.Name = "txtLoaihang";
            this.txtLoaihang.Size = new System.Drawing.Size(131, 20);
            this.txtLoaihang.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Loại hàng";
            // 
            // txtTenhang
            // 
            this.txtTenhang.Location = new System.Drawing.Point(350, 25);
            this.txtTenhang.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenhang.Name = "txtTenhang";
            this.txtTenhang.Size = new System.Drawing.Size(131, 20);
            this.txtTenhang.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tên hàng";
            // 
            // txtMahang
            // 
            this.txtMahang.Location = new System.Drawing.Point(92, 25);
            this.txtMahang.Margin = new System.Windows.Forms.Padding(2);
            this.txtMahang.Name = "txtMahang";
            this.txtMahang.Size = new System.Drawing.Size(131, 20);
            this.txtMahang.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Mã hàng";
            // 
            // frmTimkiemhanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 407);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtLoaihang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenhang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMahang);
            this.Controls.Add(this.label1);
            this.Name = "frmTimkiemhanghoa";
            this.Text = "frmTimkiemhanghoa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtLoaihang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenhang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMahang;
        private System.Windows.Forms.Label label1;
    }
}