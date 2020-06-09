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
    public partial class frmTimkiemhoadonban : Form
    {
        DataTable tblHDB;

        public frmTimkiemhoadonban()
        {
            InitializeComponent();
        }

        private void frmTimkiemhoadonban_Load(object sender, EventArgs e)
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql;
            string trangthai = "Chua thanh toan";
           
            sql = "SELECT a.MaHDB, Ngaylap, c.MaNV, b.MaKH, a.Tongtien, Trangthai FROM tblHoadonban as a, tblKhachhang as b, tblNhanvien as c WHERE 1=1 and a.MaKH = b.MaKH and a.MaNV =c.MaNV";
            if (txtMahoadon.Text != "")
                sql = sql + " AND a.MaHDB Like N'%" + txtMahoadon.Text + "%'";
            if (txtTenNV.Text != "")
                sql = sql + " AND c.TenNV Like N'%" + txtTenNV.Text + "%'";
            if (txtTenkhachhang.Text != "")
                sql = sql + " AND b.TenKH Like N'%" + txtTenkhachhang.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND a.Tongtien <=" + txtTongtien.Text;  
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
            dataGridView.Columns[0].HeaderText = "Mã HĐB";
            dataGridView.Columns[1].HeaderText = "Ngày bán";
            dataGridView.Columns[2].HeaderText = "Mã nhân viên";
            dataGridView.Columns[3].HeaderText = "Mã khách hàng";
            dataGridView.Columns[4].HeaderText = "Tổng tiền";
            dataGridView.Columns[5].HeaderText = "Trạng thái";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 80;
            dataGridView.Columns[5].Width = 100;
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
            Forms.frmHoadonban f = new frmHoadonban();
            f.StartPosition = FormStartPosition.CenterScreen;
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo");
                return;
            }
            f.txtMahoadon.Text = dataGridView.CurrentRow.Cells["MaHDB"].Value.ToString();
            f.dtpNgaynhap.Text = dataGridView.CurrentRow.Cells["Ngaylap"].Value.ToString();
            f.cboMaKH.Text = dataGridView.CurrentRow.Cells["MaKH"].Value.ToString();
            f.cboManhanvien.Text = dataGridView.CurrentRow.Cells["MaNV"].Value.ToString();
            f.txtTongtien.Text = dataGridView.CurrentRow.Cells["Tongtien"].Value.ToString();
            f.lblBangchu.Text = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(dataGridView.CurrentRow.Cells["Tongtien"].Value.ToString());
            if (dataGridView.CurrentRow.Cells["Trangthai"].Value.ToString() == "Da thanh toan")
            {
                f.chkThanhtoan.Checked = true;
            }
            string sql = "select TenNV from tblNhanvien where MaNV=N'" + dataGridView.CurrentRow.Cells["MaNV"].Value.ToString() + "'";
            DataTable table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                f.txtTennhanvien.Text = table.Rows[0][0].ToString();
            }
            table = ThucthiSQL.DocBang("select TenKH, Diachi, SDT from tblKhachhang where MaKH=N'" + f.cboMaKH.Text + "'");
            if (table.Rows.Count > 0)
            {
                f.txtTenkhachhang.Text = table.Rows[0][0].ToString();
                f.txtDiachi.Text = table.Rows[0][1].ToString();
                f.txtSDT.Text = table.Rows[0][2].ToString();
            }
            f.Hienthi_Luoi();
            f.Show();
            f.btnThem.Enabled = false;
            f.grbChitiet.Enabled = true;
        }
    }
}
