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
    public partial class frmHoadonban : Form
    {
        public frmHoadonban()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoadonban_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtTennhanvien.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtTenkhachhang.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtDongia.Text = "0";
            txtDongia.ReadOnly = true;
            grbThongtinphieu.Enabled = false;
            grbChitiet.Enabled = false;
        }

        private void cboManhanvien_DropDown(object sender, EventArgs e)
        {
            cboManhanvien.DataSource = ThucthiSQL.DocBang("select MaNV from tblNhanvien");
            cboManhanvien.ValueMember = "MaNV";
            cboManhanvien.SelectedIndex = -1;
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

        private void cboMahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                return;
            }
            DataTable table = ThucthiSQL.DocBang("select Tenhang, Dongiaban from tblHang where Mahang=N'" + cboMahang.Text + "'");
            if (table.Rows.Count > 0)
            {
                txtTenhang.Text = table.Rows[0][0].ToString();
                txtDongia.Text = table.Rows[0][1].ToString();
            }
        }

        private void btnThemnhanvien_Click(object sender, EventArgs e)
        {
            Forms.frmNhanvien f = new frmNhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btnThemMahang_Click(object sender, EventArgs e)
        {
            Forms.frmHang f = new frmHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void ResetValues()
        {
            txtMahoadon.Text = "";
            dtpNgaynhap.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            txtTongtien.Text = "0";
            txtTenkhachhang.Text = "";
            txtDiachi.Text = "";
            lblBangchu.Text = "Bằng chữ: ";
            cboMahang.Text = "";
            txtTenkhachhang.Text = "";
            txtTennhanvien.Text = "";
            txtDiachi.Text = "";
            txtSoluong.Text = "";
            txtDongia.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            txtTenkhachhang.Enabled = true;
            txtDiachi.Enabled = true;
            grbThongtinphieu.Enabled = true;
            grbChitiet.Enabled = false;
            dataGridView.DataSource = null;
            ResetValues();
            txtMahoadon.Text = ThucthiSQL.CreateKey("HDB");
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
            if (cboMaKH.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaKH.Focus();
                return;
            }
            sql = "INSERT INTO tblHoadonban(MaHDB, MaNV, Ngaylap, MaKH, Tongtien) Values (N'" + txtMahoadon.Text +
                            "',N'" + cboManhanvien.Text + "',N'" + dtpNgaynhap.Text + "',N'" + cboMaKH.Text + "'," + txtTongtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnLuu.Enabled = false;
            grbChitiet.Enabled = true;
        }

        private void cboMaKH_DropDown(object sender, EventArgs e)
        {
            cboMaKH.DataSource = ThucthiSQL.DocBang("select MaKH from tblKhachhang");
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.SelectedIndex = -1;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            Forms.frmKhachhang f = new frmKhachhang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKH.Text == "")
            {
                txtTenkhachhang.Text = "";
                txtSDT.Text = "";
                txtDiachi.Text = "";
                return;
            }
            DataTable table = ThucthiSQL.DocBang("select TenKH, Diachi, SDT from tblKhachhang where MaKH=N'" + cboMaKH.Text + "'");
            if (table.Rows.Count > 0)
            {
                txtTenkhachhang.Text = table.Rows[0][0].ToString();
                txtDiachi.Text = table.Rows[0][1].ToString();
                txtSDT.Text = table.Rows[0][2].ToString();
            }
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

        public void Hienthi_Luoi()
        {
            string sql = "Select * from tblChitietHDB where MaHDB=N'" + txtMahoadon.Text + "'";
            dataGridView.DataSource = ThucthiSQL.DocBang(sql);
            dataGridView.Columns[0].HeaderText = "Mã Hóa đơn bán";
            dataGridView.Columns[1].HeaderText = "Mã hàng";
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

        public void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtDongia.Text = "";
            txtGiamgia.Text = "0";
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
            if (txtGiamgia.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            string sql = "SELECT * FROM tblChitietHDB WHERE Mahang=N'" + cboMahang.Text + "' AND MaHDB=N'" + txtMahoadon.Text + "'";
            if (ThucthiSQL.DocBang(sql).Rows.Count > 0)
            {
                MessageBox.Show("Mã sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMahang.Focus();
                return;
            }
            sql = "INSERT INTO tblChitietHDB(MaHDB, Mahang, Soluong, Giaban, Giamgia, Thanhtien) VALUES(N'" +
                txtMahoadon.Text + "',N'" + cboMahang.Text + "', " + txtSoluong.Text +
                "," + txtDongia.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            Hienthi_Luoi();
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("select Tongtien from tblHoadonban where MaHDB=N'" +
                txtMahoadon.Text + "'").Rows[0][0].ToString());
            double tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "update tblHoadonban set Tongtien=" + tongmoi + "where MaHDB=N'" + txtMahoadon.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluongtonkho from tblSach where Mahang=N'" + cboMahang.Text + "'").Rows[0][0].ToString());
            double slmoi = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "update tblSach set Soluongtonkho=" + slmoi + " where Mahang=N'" + cboMahang.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            ResetValuesHang();
            btnHuy.Enabled = true;
            btnIn.Enabled = true;
        }

        private void DelUpdateHang(string masach, double slxoa, double Giabanxoa)
        {
            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluongtonkho from tblSach where Masach=N'" +
                masach + "'").Rows[0][0].ToString());
            double slmoi = sl + slxoa;
            string sql = "update tblSach set Soluongtonkho=" + slmoi + "where Masach=N'" + masach + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
        }
        private void DelUpdateTongtien(string madonxoa, double thanhtienxoa)
        {
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("Select Tongtien from tblHoadonban where MaHDB=N'" + madonxoa + "'").Rows[0][0].ToString());
            double tongmoi = tong - thanhtienxoa;
            string sql = "update tblHoadonban SET Tongtien=" + tongmoi + "where MaHDB=N'" + madonxoa + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "select Mahang, Soluong, Giaban from tblchitietHDB where MaHDB=N'" + txtMahoadon.Text + "'";
                DataTable tbl = ThucthiSQL.DocBang(sql);
                sql = "delete tblHoadonban where MaHDB=N'" + txtMahoadon.Text + "'";
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            sql = "select a.MaHDB, a.Ngaylap, a.Tongtien, b.TenKH, b.Diachi, c.TenNV from tblHoadonban AS a, tblKhachhang AS b, tblNhanvien as c where a.MaHDB=N'" + txtMahoadon.Text + "'AND  a.MaNV=c.MaNV AND a.MaKH = b.MaKH";
            tblThongtinHD = ThucthiSQL.DocBang(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            sql = "select b.Tenhang, a.Soluong, a.Giaban, a.Giamgia, a.Thanhtien from tblChitietHDB as a, tblHang as b where a.MaHDB=N'" + txtMahoadon.Text + "'AND a.MaHang=b.MaHang";
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
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][5];
            exSheet.Name = "Hóa đơn bán";
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
                mahangxoa = dataGridView.CurrentRow.Cells["Mahach"].Value.ToString();
                soluongxoa = Convert.ToDouble(dataGridView.CurrentRow.Cells["Soluong"].Value.ToString());
                thanhtienxoa = Convert.ToDouble(dataGridView.CurrentRow.Cells["Thanhtien"].Value.ToString());
                sql = "DELETE tblChitietHDB WHERE MaHDB=N'" + txtMahoadon.Text + "' AND Mahang = N'" + mahangxoa + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(ThucthiSQL.DocBang("SELECT Soluongtonkho FROM tblSach WHERE Mahang = N'" + mahangxoa + "'").Rows[0][0].ToString());
                slcon = sl + soluongxoa;
                sql = "UPDATE tblHang SET Soluongtonkho =" + slcon + " WHERE Mahang= N'" + mahangxoa + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(ThucthiSQL.DocBang("SELECT Tongtien FROM tblHoadonban WHERE MaHDB = N'" + txtMahoadon.Text + "'").Rows[0][0].ToString());
                tongmoi = tong - thanhtienxoa;
                sql = "UPDATE tblHoadonban SET Tongtien =" + tongmoi + " WHERE MaHDB = N'" + txtMahoadon.Text + "'";
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

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
