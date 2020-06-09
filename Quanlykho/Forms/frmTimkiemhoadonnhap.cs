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
            string trangthai = "Chua thanh toan";
            sql = "SELECT a.MaHDN, Ngaynhap, b.MaNV, c.MaNCC, a.Tongtien, a.Trangthai FROM tblHoadonnhap as a, tblNhanvien as b, tblNCC as c WHERE 1=1 and a.MaNV =b.MaNV and a.MaNCC =c.MaNCC";
            if (txtMahoadon.Text != "")
                sql = sql + " AND a.MaHDN Like N'%" + txtMahoadon.Text + "%'";
            if (txtTenNV.Text != "")
                sql = sql + " AND b.TenNV Like N'%" + txtTenNV.Text + "%'";
            if (txtTenNCC.Text != "")
                sql = sql + " AND c.TenNCC Like N'%" + txtTenNCC.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongtien.Text;
            if (chkThanhtoan.Checked == true)
            {
                trangthai = "Da thanh toan";
            }
            sql = sql + " AND a.Trangthai = N'" + trangthai + "'";
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
            dataGridView.Columns[1].HeaderText = "Ngày nhập";
            dataGridView.Columns[2].HeaderText = "Mã viên";
            dataGridView.Columns[3].HeaderText = "Mã cung cấp";
            dataGridView.Columns[4].HeaderText = "Tổng tiền";
            dataGridView.Columns[5].HeaderText = "Trạng thái";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 150;
            dataGridView.Columns[4].Width = 80;
            dataGridView.Columns[4].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            chkThanhtoan.Checked = false;
            dataGridView.DataSource = null;
        }

        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            Forms.frmHoadonnhap f = new frmHoadonnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo");
                return;
            }
            f.txtMahoadon.Text = dataGridView.CurrentRow.Cells["MaHDN"].Value.ToString();
            f.dtpNgaynhap.Text = dataGridView.CurrentRow.Cells["Ngaynhap"].Value.ToString();
            f.cboMaNCC.Text = dataGridView.CurrentRow.Cells["MaNCC"].Value.ToString();
            f.cboManhanvien.Text = dataGridView.CurrentRow.Cells["MaNV"].Value.ToString();
            f.txtTongtien.Text = dataGridView.CurrentRow.Cells["Tongtien"].Value.ToString();
            f.lblBangchu.Text = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(dataGridView.CurrentRow.Cells["Tongtien"].Value.ToString());
            if (dataGridView.CurrentRow.Cells["Trangthai"].Value.ToString() == "Da thanh toan")
            {
                f.chkThanhtoan.Checked = true;
            }
            string sql = "select TenNCC, Diachi, SDT from tblNCC where MaNCC=N'" + f.cboMaNCC.Text + "'";
            DataTable table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                f.txtTenNCC.Text = table.Rows[0][0].ToString();
                f.txtDiachi.Text = table.Rows[0][1].ToString();
                f.txtDienthoai.Text = table.Rows[0][2].ToString();
            }
            sql = "select TenNV from tblNhanvien where MaNV=N'" + f.cboManhanvien.Text + "'";
            table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                f.txtTennhanvien.Text = table.Rows[0][0].ToString();
            }
            f.Hienthi_Luoi();
            f.Show();
            f.btnThem.Enabled = false;
            f.grbChitiet.Enabled = true;
        }
    }
}
