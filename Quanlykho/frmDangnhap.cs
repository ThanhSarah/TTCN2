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
        public static string MaCV;
        public frmDangnhap()
        {
            InitializeComponent();

            txtMatkhau.ForeColor = Color.LightGray;
            txtMatkhau.Text = "Nhập mật khẩu";
            this.txtMatkhau.Leave += new System.EventHandler(this.txtMatkhau_Leave);
            this.txtMatkhau.Enter += new System.EventHandler(this.txtMatkhau_Enter);

            cboTendangnhap.ForeColor = Color.LightGray;
            cboTendangnhap.Text = "Chọn tài khoản đăng nhập";
            this.cboTendangnhap.Leave += new System.EventHandler(this.cboTendangnhap_Leave);
            this.cboTendangnhap.Enter += new System.EventHandler(this.cboTendangnhap_Enter);
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
            chkShowpass.Checked = false;
            txtMatkhau.PasswordChar = '*';
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (cboTendangnhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                cboTendangnhap.Focus();
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo");
                txtMatkhau.Focus();
                return;
            }
            string sql = "select * from tblDangnhap where Tendangnhap=N'" + cboTendangnhap.Text + "'and Matkhau =N'" + txtMatkhau.Text + "'";
            DataTable table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                MaCV = table.Rows[0][2].ToString();
                this.Hide();
                Forms.frmMain f = new Forms.frmMain();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu. Bạn hãy nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTendangnhap.Text = "";
                txtMatkhau.Text = "";
                cboTendangnhap.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTendangnhap_DropDown(object sender, EventArgs e)
        {
            cboTendangnhap.DataSource = ThucthiSQL.DocBang("select Tendangnhap from tblDangnhap");
            cboTendangnhap.ValueMember = "Tendangnhap";
            cboTendangnhap.SelectedIndex = -1;
        }

        private void chkShowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowpass.Checked == false)
            {
                txtMatkhau.PasswordChar = '*';
            }
            else
            {
                txtMatkhau.PasswordChar = (char)0;
            }
        }

        private void txtMatkhau_Enter(object sender, EventArgs e)
        {
            if (txtMatkhau.Text == "Nhập mật khẩu")
            {
                txtMatkhau.Text = "";
                txtMatkhau.ForeColor = Color.Black;
            }
        }

        private void txtMatkhau_Leave(object sender, EventArgs e)
        {
            if (txtMatkhau.Text == "")
            {
                txtMatkhau.Text = "Nhập mật khẩu";
                txtMatkhau.ForeColor = Color.Gray;
            }
        }

        private void cboTendangnhap_Enter(object sender, EventArgs e)
        {
            if (cboTendangnhap.Text == "Chọn tài khoản đăng nhập")
            {
                cboTendangnhap.Text = "";
                cboTendangnhap.ForeColor = Color.Black;
            }
        }

        private void cboTendangnhap_Leave(object sender, EventArgs e)
        {
            if (cboTendangnhap.Text == "")
            {
                cboTendangnhap.Text = "Chọn tài khoản đăng nhập";
                cboTendangnhap.ForeColor = Color.Gray;
            }
        }
    }
}
