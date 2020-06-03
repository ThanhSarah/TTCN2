using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykho.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangnhap f = new frmDangnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void thôngTinHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nhà sách XƯA VÀ NAY Hà Nội" + Environment.NewLine +
                            "Địa chỉ: 676 Đống Đa, Hà Nội" + Environment.NewLine +
                            "Email: nsxuavanay@gmail.com" + Environment.NewLine +
                            "Số điện thoại: 0917431234");
        }

        private void thôngTinPhiênBảnPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Họ tên sinh viên: Nguyễn Thị Thanh" + Environment.NewLine +
                            "Mã số sinh viên: 20A4040132" + Environment.NewLine +
                            "Thực tập chuyên ngành 2");
        }

        private void hàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHang f = new frmHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmKhachhang f = new frmKhachhang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNhanvien f = new frmNhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNCC f = new frmNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChucvu f = new frmChucvu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (frmDangnhap.MaCV != "QL")
            {
                nhânViênToolStripMenuItem.Visible = false;
                chứcVụToolStripMenuItem.Visible = false;
            }
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHoadonnhap f = new frmHoadonnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHoadonban f = new frmHoadonban();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTimkiemhoadonban f = new frmTimkiemhoadonban();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTimkiemhoadonnhap f = new frmTimkiemhoadonnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        } 

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBaocaodoanhthu f = new frmBaocaodoanhthu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void báoCáoHàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBaocaohangton f = new frmBaocaohangton();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
