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
        DataTable tblCV;
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
            string sql;
            sql = "SELECT * FROM tblChucvu";
            tblCV = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblCV;
            Hienthi_Luoi();
        }

        private void Hienthi_Luoi()
        {
            
            dataGridView.Columns[0].HeaderText = "Mã chức vụ";
            dataGridView.Columns[1].HeaderText = "Tên chức vụ";
            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 250;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
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
                MessageBox.Show("Bạn phải nhập mã chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }
            if (txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }
            sql = "select * from tblChucVu where MaCV = N'" + txtMaCV.Text + "'";
            tblCV = ThucthiSQL.DocBang(sql);
            if (tblCV.Rows.Count == 0)
            {
                sql = "INSERT INTO tblChucvu(MaCV, TenCV) Values (N'" + txtMaCV.Text +"',N'" + txtTenCV.Text + "')";
            }
            else
            {
                sql = "UPDATE tblChucvu set TenCV = N'" + txtTenCV.Text + "' where MaCV = N'" + txtMaCV.Text +"'";
            }
            ThucthiSQL.CapNhatDuLieu(sql);
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            sql = "SELECT * FROM tblChucvu";
            tblCV = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblCV;
            Hienthi_Luoi();
            grbChucvu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblChucvu WHERE MaCV=N'" + txtMaCV.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                sql = "SELECT * FROM tblChucvu";
                tblCV = ThucthiSQL.DocBang(sql);
                dataGridView.DataSource = tblCV;
                Hienthi_Luoi();
                ResetValues();
                grbChucvu.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnXoa.Enabled == false)
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
            else
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
                btnHuy.Enabled = true;
                grbChucvu.Enabled = true;
                btnLuu.Enabled = true;
                
                txtMaCV.Text = dataGridView.CurrentRow.Cells["MaCV"].Value.ToString();
                txtTenCV.Text = dataGridView.CurrentRow.Cells["TenCV"].Value.ToString();
                btnXoa.Enabled = true;
                txtMaCV.Enabled = false;
            }
        }

        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
        }
    }
}
