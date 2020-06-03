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
    public partial class frmKhachhang : Form
    {
        DataTable tblKH;
        public frmKhachhang()
        {
            InitializeComponent();

            txtTimkiem.ForeColor = Color.LightGray;
            txtTimkiem.Text = "Nhập mã khách hàng, tên khách hàng, số điện thoại hoặc địa chỉ để tìm kiếm";
            this.txtTimkiem.Leave += new System.EventHandler(this.txtTimkiem_Leave);
            this.txtTimkiem.Enter += new System.EventHandler(this.txtTimkiem_Enter);
        }

        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKH.ReadOnly = true;
            grbKhachhang.Enabled = false;
            string sql = "SELECT * FROM tblKhachhang";
            tblKH = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblKH;
            Hienthi_Luoi();
        }
        private void Hienthi_Luoi()
        {
            dataGridView.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Số điện thoại";
            dataGridView.Columns[3].HeaderText = "Địa chỉ";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            grbKhachhang.Enabled = true;
            ResetValues();
            txtMaKH.Text = ThucthiSQL.CreateKey("KH");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
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

            sql = "INSERT INTO tblKhachhang(MaKH, TenKH, Diachi, SDT) Values (N'" + txtMaKH.Text +
                            "',N'" + txtTenKH.Text + "',N'" + txtDiachi.Text + "',N'" + txtSDT.Text + "')";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            sql = "SELECT * FROM tblKhachhang";
            tblKH = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblKH;
            Hienthi_Luoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblKhachhang WHERE MaNCC=N'" + txtMaKH.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                sql = "SELECT * FROM tblKhachhang";
                tblKH = ThucthiSQL.DocBang(sql);
                dataGridView.DataSource = tblKH;
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
                grbKhachhang.Enabled = false;
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
                grbKhachhang.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                txtMaKH.Text = dataGridView.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtTenKH.Text = dataGridView.CurrentRow.Cells["TenNCC"].Value.ToString();
                txtSDT.Text = dataGridView.CurrentRow.Cells["SDT"].Value.ToString();
                txtDiachi.Text = dataGridView.CurrentRow.Cells["Diachi"].Value.ToString();
            }
        }

        private void txtTimkiem_Leave(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
            {
                txtTimkiem.Text = "Nhập mã khách hàng, tên khách hàng, số điện thoại hoặc địa chỉ để tìm kiếm";
                txtTimkiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimkiem_Enter(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "Nhập mã khách hàng, tên khách hàng, số điện thoại hoặc địa chỉ để tìm kiếm")
            {
                txtTimkiem.Text = "";
                txtTimkiem.ForeColor = Color.Black;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * from tblKhachhang where TenKH Like N'%" +txtTimkiem.Text+ "%' or Diachi Like N'%" + txtTimkiem.Text + "%' or SDT Like N'%" + txtTimkiem.Text + "%'or MaKH Like N'%" + txtTimkiem.Text + "%'";
            tblKH = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblKH;
            Hienthi_Luoi();
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có " + tblKH.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
