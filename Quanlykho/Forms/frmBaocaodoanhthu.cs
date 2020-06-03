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
    public partial class frmBaocaodoanhthu : Form
    {
        public frmBaocaodoanhthu()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select a.Mahang, b.Tenhang, a.Soluong, a.Giaban, a.Thanhtien from tblChitietHDB as a, tblHang as b, tblHoadonban as c where MONTH(c.Ngaylap)='" + dtpThang.Text + "' AND YEAR(c.Ngaylap)='" + dtpNam.Text + "' AND a.Mahang=b.Mahang AND a.MaHDB=c.MaHDB";
            DataTable tblDT = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblDT;
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Tên hàng";
            dataGridView.Columns[2].HeaderText = "Số lượng";
            dataGridView.Columns[3].HeaderText = "Đơn giá bán";
            dataGridView.Columns[4].HeaderText = "Thanh tien";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblDT.Dispose();
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select a.Mahang, b.Tenhang, a.Soluong, a.Giaban, a.Thanhtien from tblChitietHDB as a, tblHang as b, tblHoadonban as c where MONTH(c.Ngaylap)='" + dtpThang.Text + "' AND YEAR(c.Ngaylap)='" + dtpNam.Text + "' AND a.Mahang=b.Mahang AND a.MaHDB=c.MaHDB";
            DataTable tblDT = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblDT;
            double dt = 0;
            for (int i = 0; i < tblDT.Rows.Count; i++)
            {
                dt = dt + Convert.ToDouble(tblDT.Rows[i][4].ToString());
            }
            string DT = Convert.ToString(dt);
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;

            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            exRange = exSheet.Cells[1, 1];
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

            exRange.Range["B6:F7"].Font.Size = 16;
            exRange.Range["B6:F7"].Font.Name = "Times new roman";
            exRange.Range["B6:F7"].Font.Bold = true;
            exRange.Range["B6:F7"].Font.ColorIndex = 3;
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["B7:F7"].MergeCells = true;
            exRange.Range["B6:F7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange.Range["C6:E6"].Value = "BÁO CÁO DOANH THU THÁNG " + dtpThang.Text;
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange.Range["A11:A11"].ColumnWidth = 8;
            exRange.Range["B11:B11"].ColumnWidth = 12;
            exRange.Range["C11:C11"].ColumnWidth = 24;
            exRange.Range["D11:E11"].ColumnWidth = 12;
            exRange.Range["F11:F11"].ColumnWidth = 26;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã hàng";
            exRange.Range["C11:C11"].Value = "Tên hàng";
            exRange.Range["D11:D11"].Value = "Số lượng còn";
            exRange.Range["E11:E11"].Value = "Đơn giá ban";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblDT.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblDT.Columns.Count; cot++)
                    exSheet.Cells[cot + 2][hang + 12] = tblDT.Rows[hang][cot].ToString();
            }

            exRange = exSheet.Cells[1, 1];
            exRange.Range["E15:F15"].Font.Size = 14;
            exRange.Range["E15:F15"].Font.Name = "Times new roman";
            exRange.Range["E15:F15"].Font.Bold = true;
            exRange.Range["E15:F15"].MergeCells = true;
            exRange.Range["E15:F15"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E15:F15"].Value = "Tổng doanh thu: " + DT;
            exSheet.Name = "Báo cáo doanh thu";
            exApp.Visible = true;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dataGridView.DataSource = null;
        }
    }
}
