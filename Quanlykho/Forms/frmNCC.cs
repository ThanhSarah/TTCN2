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
    public partial class frmNCC : Form
    {
        public frmNCC()
        {
            InitializeComponent();
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNCC.ReadOnly = true;
            grbNhacungcap.Enabled = false;
            Hienthi_Luoi();
        }

        private void Hienthi_Luoi()
        {
            string sql;
            DataTable tblNCC;
            sql = "SELECT * FROM tblNCC";
            tblNCC = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblNCC;
            dataGridView.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView.Columns[2].HeaderText = "Số điện thoại";
            dataGridView.Columns[3].HeaderText = "Địa chỉ";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblNCC.Dispose();
        }

        private void ResetValues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            grbNhacungcap.Enabled = true;
            ResetValues();
            txtMaNCC.Text = ThucthiSQL.CreateKey("NCC");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            sql = "INSERT INTO tblNCC(MaNCC, TenNCC, Diachi, SDT) Values (N'" + txtMaNCC.Text +
                            "',N'" + txtTenNCC.Text + "',N'" + txtDiachi.Text + "',N'" + txtSDT.Text + ")";
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
                sql = "DELETE FROM tblNCC WHERE MaNCC=N'" + txtMaNCC.Text + "'";
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
                grbNhacungcap.Enabled = false;
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
                grbNhacungcap.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                txtMaNCC.Text = dataGridView.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dataGridView.CurrentRow.Cells["TenNCC"].Value.ToString();
                txtSDT.Text = dataGridView.CurrentRow.Cells["SDT"].Value.ToString();
                txtDiachi.Text = dataGridView.CurrentRow.Cells["Diachi"].Value.ToString();
            }
        }
    }
}
