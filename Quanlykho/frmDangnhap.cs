using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykho
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtTendangnhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                txtTendangnhap.Focus();
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo");
                txtMatkhau.Focus();
                return;
            }
            string sql = "select * from tblDangnhap where Tendangnhap=N'" + txtTendangnhap.Text + "'and Password =N'" + txtMatkhau.Text + "'";
            DataTable table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                quyen = table.Rows[0][2].ToString();
                this.Hide();
                Forms.frmMain f = new Forms.frmMain();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu. Bạn hãy nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
            Forms.frmMain f = new Forms.frmMain();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
