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
    public partial class frmHang : Form
    {
        public frmHang()
        {
            InitializeComponent();
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            txtDongiaban.ReadOnly = true;
            txtDongianhap.ReadOnly = true;
            txtSoluong.ReadOnly = true;
            txtDongiaban.Text = "0";
            txtDongianhap.Text = "0";
            txtSoluong.Text = "0";
            txtMaHH.ReadOnly = true;
            grbThongtinhang.Enabled = false;
            Hienthi_Luoi();
        }

        private void Hienthi_Luoi()
        {
            string sql;
            DataTable tblH;
            sql = "SELECT * FROM tblHang";
            tblH = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblH;
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Tên hàng";
            dataGridView.Columns[2].HeaderText = "Đơn giá bán";
            dataGridView.Columns[3].HeaderText = "Đơn giá nhập";
            dataGridView.Columns[4].HeaderText = "Số lượng tồn kho";
            dataGridView.Columns[5].HeaderText = "Xuất xứ";
            dataGridView.Columns[6].HeaderText = "Ảnh";
            dataGridView.Columns[7].HeaderText = "Ghi chú";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 50;
            dataGridView.Columns[6].Width = 200;
            dataGridView.Columns[7].Width = 200;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblH.Dispose();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            grbThongtinhang.Enabled = true;
            ResetValues();
            txtMaHH.Text = ThucthiSQL.CreateKey("HH");
        }
        private void ResetValues()
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtXuatxu.Text = "";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtAnh.Text = "";
            txtSoluong.Text = "0";
            txtGhichu.Text = "";
            txtDongiaban.ReadOnly = true;
            txtDongianhap.ReadOnly = true;
            txtSoluong.ReadOnly = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ảnh Jpeg(*.jpg)|*.jpg|Ảnh bitmap (*.bmp)|*.bmp|All files(*.*)|*.*";
            dlg.Title = "Chọn ảnh sản phẩm";
            dlg.InitialDirectory = @"C:\";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlg.FileName);
                txtAnh.Text = dlg.FileName;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenHH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHH.Focus();
                return;
            }
            if (txtDongianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
                return;
            }
            if (txtDongiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng tồn kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblHang(Mahang, TenHang, Dongiaban, Dongianhap, Soluongtonkho, Xuatxu, Anh, Ghichu) Values (N'" + txtMaHH.Text +
                            "',N'" + txtTenHH.Text + "',N'" + txtDongiaban.Text + "',N'" + txtDongianhap.Text + "'," + txtSoluong.Text + "',N'" + txtXuatxu.Text + "',N'" + txtAnh.Text + "',N'" + txtGhichu.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            Hienthi_Luoi();
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
                grbThongtinhang.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM tblHang WHERE Mahang=N'" + txtMaHH.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                Hienthi_Luoi();
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
                grbThongtinhang.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                txtDongiaban.ReadOnly = false;
                txtDongianhap.ReadOnly = false;
                txtSoluong.ReadOnly = false;
                txtMaHH.Text = dataGridView.CurrentRow.Cells["Mahang"].Value.ToString();
                txtTenHH.Text = dataGridView.CurrentRow.Cells["Tenhang"].Value.ToString();
                txtDongiaban.Text = dataGridView.CurrentRow.Cells["Dongiaban"].Value.ToString();
                txtDongianhap.Text = dataGridView.CurrentRow.Cells["Dongianhap"].Value.ToString();
                txtAnh.Text = dataGridView.CurrentRow.Cells["Anh"].Value.ToString();
                txtGhichu.Text = dataGridView.CurrentRow.Cells["Ghichu"].Value.ToString();
                txtSoluong.Text = dataGridView.CurrentRow.Cells["Soluong"].Value.ToString();
                txtXuatxu.Text = dataGridView.CurrentRow.Cells["Xuatxu"].Value.ToString();
                picAnh.Image = Image.FromFile(txtAnh.Text);
            }
        }


    }
}
