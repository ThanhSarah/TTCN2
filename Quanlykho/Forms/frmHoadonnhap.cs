using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace Quanlykho.Forms
{
    public partial class frmHoadonnhap : Form
    {
        public frmHoadonnhap()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoadonnhap_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtTennhanvien.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtDongia.Text = "0";
            grbThongtinphieu.Enabled = false;
            grbChitiet.Enabled = false;
        }

        private void cboManhanvien_DropDown(object sender, EventArgs e)
        {
            cboManhanvien.DataSource = ThucthiSQL.DocBang("select MaNV from tblNhanvien");
            cboManhanvien.ValueMember = "MaNV";
            cboManhanvien.SelectedIndex = -1;
        }

        private void cboMaNCC_DropDown(object sender, EventArgs e)
        {
            cboMaNCC.DataSource = ThucthiSQL.DocBang("select MaNCC from tblNCC");
            cboMaNCC.ValueMember = "MaNCC";
            cboMaNCC.SelectedIndex = -1;
        }

        private void cboMahang_DropDown(object sender, EventArgs e)
        {
            cboMahang.DataSource = ThucthiSQL.DocBang("select Mahang from tblHang");
            cboMahang.ValueMember = "Mahang";
            cboMahang.SelectedIndex = -1;
        }

        private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManhanvien.Text == "")
            {
                txtTennhanvien.Text = "";
                return;
            }
            string sql = "select TenNV from tblNhanvien where MaNV=N'" + cboManhanvien.Text + "'";
            DataTable table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                txtTennhanvien.Text = table.Rows[0][0].ToString();
            }
        }

        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
                return;
            }
            string sql = "select TenNCC, Diachi, Sodienthoai from tblNCC where MaNCC=N'" + cboMaNCC.Text + "'";
            DataTable table = ThucthiSQL.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                txtTenNCC.Text = table.Rows[0][0].ToString();
                txtDiachi.Text = table.Rows[0][1].ToString();
                txtDienthoai.Text = table.Rows[0][2].ToString();
            }
        }

        private void cboMahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                return;
            }
            DataTable table = ThucthiSQL.DocBang("select Tenhang from tblHang where Mahang=N'" + cboMahang.Text + "'");
            if (table.Rows.Count > 0)
            {
                txtTenhang.Text = table.Rows[0][0].ToString();
            }
        }

        private void btnThemnhanvien_Click(object sender, EventArgs e)
        {
            Forms.frmNhanvien f = new frmNhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            Forms.frmNCC f = new frmNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void ResetValues()
        {
            txtMahoadon.Text = "";
            dtpNgaynhap.Text = DateTime.Now.ToShortDateString();
            cboMaNCC.Text = "";
            cboManhanvien.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtTenNCC.Text = "";
            txtTennhanvien.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtDongia.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            grbThongtinphieu.Enabled = true;
            grbChitiet.Enabled = false;
            dataGridView.DataSource = null;
            ResetValues();
            txtMahoadon.Text = ThucthiSQL.CreateKey("HDN");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtpNgaynhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaynhap.Focus();
                return;
            }
            if (cboManhanvien.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboManhanvien.Focus();
                return;
            }
            if (cboMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaNCC.Focus();
                return;
            }
            sql = "INSERT INTO tblHoadonnhap(MaHDN, Ngaynhap, MaNCC, MaNV, Tongtien) Values (N'" + txtMahoadon.Text +
                            "',N'" + dtpNgaynhap.Text + "',N'" + cboMaNCC.Text + "',N'" + cboManhanvien.Text + "'," + txtTongtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnLuu.Enabled = false;
            grbChitiet.Enabled = true;
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            txtThanhtien.Text = ThucthiSQL.Thanhtien(txtSoluong.Text, txtDongia.Text, txtGiamgia.Text);
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            txtThanhtien.Text = ThucthiSQL.Thanhtien(txtSoluong.Text, txtDongia.Text, txtGiamgia.Text);
        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            txtThanhtien.Text = ThucthiSQL.Thanhtien(txtSoluong.Text, txtDongia.Text, txtGiamgia.Text);
        }

        private void btnThemMahang_Click(object sender, EventArgs e)
        {
            Forms.frmHang f = new frmHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        public void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtDongia.Text = "";
            txtGiamgia.Text = "0";
        }

        public void Hienthi_Luoi()
        {
            string sql = "Select * from tblChitietHDN where MaHDN=N'" + txtMahoadon.Text + "'";
            dataGridView.DataSource = ThucthiSQL.DocBang(sql);
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Mã Hóa đơn nhập";
            dataGridView.Columns[2].HeaderText = "Số lượng";
            dataGridView.Columns[3].HeaderText = "Giá nhập";
            dataGridView.Columns[4].HeaderText = "Giảm giá";
            dataGridView.Columns[5].HeaderText = "Thành tiền";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThemhang_Click(object sender, EventArgs e)
        {
            if (cboMahang.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahang.Focus();
                return;
            }
            if (txtSoluong.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtDongia.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongia.Focus();
                return;
            }
            if (txtGiamgia.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            string sql = "SELECT * FROM tblChitietHDN WHERE Mahang=N'" + cboMahang.Text + "' AND MaHDN=N'" + txtMahoadon.Text + "'";
            if (ThucthiSQL.DocBang(sql).Rows.Count > 0)
            {
                MessageBox.Show("Mã sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMahang.Focus();
                return;
            }
            sql = "INSERT INTO tblChitietHDN(Mahang, MaHDN, Soluong, Gianhap, Giamgia, Thanhtien) VALUES(N'" + cboMahang.Text + "', N'" +
                txtMahoadon.Text + "'," + txtSoluong.Text +
                "," + txtDongia.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            Hienthi_Luoi();
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("select Tongtien from tblHoadonnhap where MaHDN=N'" +
                txtMahoadon.Text + "'").Rows[0][0].ToString());
            double tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "update tblHoadonnhap set Tongtien=" + tongmoi + "where MaHDN=N'" + txtMahoadon.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluongtonkho from tblHang where Mahang=N'" + cboMahang.Text + "'").Rows[0][0].ToString());
            double slmoi = sl + Convert.ToDouble(txtSoluong.Text);
            sql = "update tblHang set Soluongtonkho=" + slmoi + " where Mahang=N'" + cboMahang.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            double dgn = Convert.ToDouble(ThucthiSQL.DocBang("select Dongianhap from tblHang where Masach=N'" + cboMahang.Text + "'").Rows[0][0].ToString());
            double dgnmoi = (dgn * sl + Convert.ToDouble(txtSoluong.Text) * Convert.ToDouble(txtDongia.Text)) / (slmoi);
            sql = "update tblHang set Dongianhap=" + dgnmoi + "where Mahang = N'" + cboMahang.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            double dgbmoi = dgnmoi + dgnmoi * 0.2;
            sql = "update tblHang set Dongiaban=" + dgbmoi + "where Mahang = N'" + cboMahang.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            ResetValuesHang();
            btnHuy.Enabled = true;
            btnIn.Enabled = true;
        }

        private void DelUpdateHang(string mahang, double slxoa, double gianhapxoa)
        {
            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluongtonkho from tblHang where Mahang=N'" +
                mahang + "'").Rows[0][0].ToString());
            double slmoi = sl - slxoa;
            string sql = "update tblHang set Soluongtonkho=" + slmoi + "where Mahang=N'" + mahang + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            double dgn = Convert.ToDouble(ThucthiSQL.DocBang("select Dongianhap from tblHang where Mahang=N'" + mahang + "'").Rows[0][0].ToString());
            double dgnmoi = (sl * dgn - slxoa * gianhapxoa) / slmoi;
            sql = "update tblHang set Dongianhap=" + dgnmoi + "where Mahang = N'" + cboMahang.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            double dgbmoi = dgnmoi + dgnmoi * 0.2;
            sql = "update tblHang set Dongiaban=" + dgbmoi + "where Mahang = N'" + cboMahang.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
        }

        private void DelUpdateTongtien(string madonxoa, double thanhtienxoa)
        {
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("Select Tongtien from tblHoadonnhap where MaHDN=N'" + madonxoa + "'").Rows[0][0].ToString());
            double tongmoi = tong - thanhtienxoa;
            string sql = "update tblHoadonnhap SET Tongtien=" + tongmoi + "where MaHDN=N'" + madonxoa + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "select Mahang, Soluong, Gianhap from tblchitietHDN where MaHDN=N'" + txtMahoadon.Text + "'";
                DataTable tbl = ThucthiSQL.DocBang(sql);
                sql = "delete tblHoadonnhap where MaHDN=N'" + txtMahoadon.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                ResetValues();
                Hienthi_Luoi();
                for (int i = 0; i < tbl.Rows.Count; i++)
                    DelUpdateHang(tbl.Rows[0][0].ToString(), Convert.ToDouble(tbl.Rows[i][1].ToString()), Convert.ToDouble(tbl.Rows[i][2].ToString()));
                btnHuy.Enabled = false;
                btnIn.Enabled = false;
                grbThongtinphieu.Enabled = false;
                grbChitiet.Enabled = false;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1][1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "NHÀ SÁCH XƯA VÀ NAY";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "676 ĐỐNG ĐA, HÀ NỘI";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0917431234";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            sql = "select a.MaHDN, a.Tongtien, b.TenNCC, b.Diachi, b.Sodienthoai, a.Ngaynhap, c.TenNV from tblHoadonnhap as a, tblNCC as b, tblNhanvien as c where a.MaHDN=N'" + txtMahoadon.Text + "' AND a.MaNCC=b.MaNCC AND a.MaNV=c.MaNV";
            tblThongtinHD = ThucthiSQL.DocBang(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][2].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = "0" + tblThongtinHD.Rows[0][4].ToString();
            sql = "select b.Tenhang, a.Soluong, a.Gianhap, a.Giamgia, a.Thanhtien from tblChitietHDN as a, tblHang AS b where a.MaHDN=N'" + txtMahoadon.Text + "'AND a.Mahang=b.Mahang";
            tblThongtinHang = ThucthiSQL.DocBang(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền: ";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][1].ToString();
            exRange = exSheet.Cells[1][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tblThongtinHD.Rows[0][1].ToString());
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][5]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            string mahangxoa, sql;
            Double thanhtienxoa, soluongxoa, sl, slcon, tong, tongmoi;
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahangxoa = dataGridView.CurrentRow.Cells["Mahang"].Value.ToString();
                soluongxoa = Convert.ToDouble(dataGridView.CurrentRow.Cells["Soluong"].Value.ToString());
                thanhtienxoa = Convert.ToDouble(dataGridView.CurrentRow.Cells["Thanhtien"].Value.ToString());
                sql = "DELETE tblChitietHDN WHERE MaHDN=N'" + txtMahoadon.Text + "' AND Mahang = N'" + mahangxoa + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(ThucthiSQL.DocBang("SELECT Soluongtonkho FROM tblHang WHERE Masach = N'" + mahangxoa + "'").Rows[0][0].ToString());
                slcon = sl - soluongxoa;
                sql = "UPDATE tblSach SET Soluongtonkho =" + slcon + " WHERE Masach= N'" + mahangxoa + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(ThucthiSQL.DocBang("SELECT Tongtien FROM tblHoadonnhap WHERE MaHDN = N'" + txtMahoadon.Text + "'").Rows[0][0].ToString());
                tongmoi = tong - thanhtienxoa;
                sql = "UPDATE tblHoadonnhap SET Tongtien =" + tongmoi + " WHERE MaHDN = N'" + txtMahoadon.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                txtTongtien.Text = tongmoi.ToString();
                lblBangchu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
                Hienthi_Luoi();
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
