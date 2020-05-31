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
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            txtManhanvien.ReadOnly = true;
            grbNhanvien.Enabled = false;
            Hienthi_Luoi();
        }

        private void Hienthi_Luoi()
        {
            string sql;
            DataTable tblNV;
            sql = "SELECT * FROM tblNhanvien";
            tblNV = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblNV;
            dataGridView.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView.Columns[2].HeaderText = "Giới tính";
            dataGridView.Columns[3].HeaderText = "Ngày sinh";
            dataGridView.Columns[4].HeaderText = "Chứng minh thư";
            dataGridView.Columns[5].HeaderText = "Mã chức vụ";
            dataGridView.Columns[6].HeaderText = "Địa chỉ";
            dataGridView.Columns[7].HeaderText = "Số điện thoại";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 50;
            dataGridView.Columns[6].Width = 200;
            dataGridView.Columns[7].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblNV.Dispose();
        }

        private void ResetValues()
        {
            cboMaCV.Text = "";
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            txtCMT.Text = "";
            dtpNgaysinh.Text = DateTime.Now.ToShortDateString();
            rdoNam.Checked = false;
            rdoNu.Checked = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            grbNhanvien.Enabled = true;
            ResetValues();
            txtManhanvien.Text = ThucthiSQL.CreateKey("NV");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string gt = "Nam";
            if (cboMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaCV.Focus();
                return;
            }
            if (txtTennhanvien.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdoNu.Checked == true)
            {
                gt = "Nu";
            }
            sql = "INSERT INTO tblHang(MaNV, TenNV, Gioitinh, Ngaysinh, CMT, MaCV, Diachi, SDT) Values (N'" + txtManhanvien.Text +
                            "',N'" + txtTennhanvien.Text + "',N'" + gt + "',N'" + dtpNgaysinh.Text + "'," + txtCMT.Text + "',N'" + cboMaCV.Text + "',N'" + txtDiachi.Text + "',N'" + txtSDT.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            Hienthi_Luoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblHang WHERE MaNV=N'" + txtManhanvien.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                Hienthi_Luoi();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy mà chưa lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetValues();
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnXoa.Enabled = false;
                grbNhanvien.Enabled = false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn đóng mà chưa lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                grbNhanvien.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                txtManhanvien.Text = dataGridView.CurrentRow.Cells["MaNV"].Value.ToString();
                txtTennhanvien.Text = dataGridView.CurrentRow.Cells["TenNV"].Value.ToString();
                if (dataGridView.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                dtpNgaysinh.Text = dataGridView.CurrentRow.Cells["Ngaysinh"].Value.ToString();
                txtCMT.Text = dataGridView.CurrentRow.Cells["CMT"].Value.ToString();
                cboMaCV.Text = dataGridView.CurrentRow.Cells["MaCV"].Value.ToString();
                txtDiachi.Text = dataGridView.CurrentRow.Cells["Diachi"].Value.ToString();
                txtSDT.Text = dataGridView.CurrentRow.Cells["SDT"].Value.ToString();
            }
        }
    }
}
