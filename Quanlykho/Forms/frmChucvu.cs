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
    public partial class frmChucvu : Form
    {
        public frmChucvu()
        {
            InitializeComponent();
        }

        private void frmChucvu_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            grbChucvu.Enabled = false;
            Hienthi_Luoi();
        }

        private void Hienthi_Luoi()
        {
            string sql;
            DataTable tblCV;
            sql = "SELECT * FROM tblChucvu";
            tblCV = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblCV;
            dataGridView.Columns[0].HeaderText = "Mã chức vụ";
            dataGridView.Columns[1].HeaderText = "Tên chức vụ";
            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 250;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblCV.Dispose();
        }

        private void ResetValues()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            grbChucvu.Enabled = true;
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }
            if (txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }
            sql = "INSERT INTO tblChucvu(MaCV, TenCV) Values (N'" + txtMaCV.Text +
                            "',N'" + txtTenCV.Text + ")";
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
                sql = "DELETE FROM tblChucvu WHERE MaCV=N'" + txtMaCV.Text + "'";
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
                grbChucvu.Enabled = false;
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
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                txtMaCV.Text = dataGridView.CurrentRow.Cells["Machucvu"].Value.ToString();
                txtTenCV.Text = dataGridView.CurrentRow.Cells["Tenchucvu"].Value.ToString();
            }
        }

        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
        }

        private void txtTenCV_TextChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
        }
    }
}
