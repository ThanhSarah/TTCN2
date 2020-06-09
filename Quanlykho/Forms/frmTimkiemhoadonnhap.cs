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
    public partial class frmTimkiemhoadonnhap : Form
    {
        DataTable tblHDB;

        public frmTimkiemhoadonnhap()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimkiemhoadonnhap_Load(object sender, EventArgs e)
        {
            ResetValues();
            dataGridView.DataSource = null;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMahoadon.Focus();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahoadon.Text == "") &&
               (txtTenNV.Text == "") && (txtTenNCC.Text == "") &&
               (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoadonnhap as a, tblNhanvien as b, tblNCC as c WHERE 1=1 and a.MaNV =b.MaNV and a.MaNCC =c.MaNCC";
            if (txtMahoadon.Text != "")
                sql = sql + " AND a.MaHDN Like N'%" + txtMahoadon.Text + "%'";
            if (txtTenNV.Text != "")
                sql = sql + " AND b.TenNV Like N'%" + txtTenNV.Text + "%'";
            if (txtTenNCC.Text != "")
                sql = sql + " AND c.TenNCC Like N'%" + txtTenNCC.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongtien.Text;
            tblHDB = ThucthiSQL.DocBang(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView.DataSource = tblHDB;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dataGridView.Columns[0].HeaderText = "Mã HĐN";
            dataGridView.Columns[1].HeaderText = "Mã nhân viên";
            dataGridView.Columns[2].HeaderText = "Ngày nhập";
            dataGridView.Columns[3].HeaderText = "Mã nhà cung cấp";
            dataGridView.Columns[4].HeaderText = "Tổng tiền";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 80;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dataGridView.DataSource = null;
        }

        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
