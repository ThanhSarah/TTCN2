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
    public partial class frmBaocaohangton : Form
    {
        public frmBaocaohangton()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaocaohangton_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mahang, Tenhang, Soluongtonkho, Dongianhap, Dongiaban FROM tblHang";
            DataTable tblHang;
            tblHang = ThucthiSQL.DocBang(sql);
            dataGridView.DataSource = tblHang;
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Tên hàng";
            dataGridView.Columns[2].HeaderText = "Số lượng tồn kho";
            dataGridView.Columns[3].HeaderText = "Đơn giá nhập";
            dataGridView.Columns[4].HeaderText = "Đơn giá bán";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblHang.Dispose();
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mahang, Tenhang , Soluongtonkho, Dongianhap, Dongiaban FROM tblHang ";
            DataTable tblHang;
            tblHang = ThucthiSQL.DocBang(sql);
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

            exRange.Range["A1:A1"].ColumnWidth = 70;
            exRange.Range["B1:B1"].ColumnWidth = 70;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange.Range["A1:B1"].Value = "Showroom phân phối nội thất Furniland";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "92 Mễ Trì Hạ, Mễ Trì, Từ Liêm, Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 024.7309.0066";

            exRange.Range["B6:F7"].Font.Size = 16;
            exRange.Range["B6:F7"].Font.Name = "Times new roman";
            exRange.Range["B6:F7"].Font.Bold = true;
            exRange.Range["B6:F7"].Font.ColorIndex = 3;
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["B7:F7"].MergeCells = true;
            exRange.Range["B6:F7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange.Range["C6:E6"].Value = "HÀNG TỒN KHO";
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
            exRange.Range["E11:E11"].Value = "Đơn giá nhập";
            exRange.Range["F11:F11"].Value = "Đơn giá bán";

            exRange = exSheet.Cells[1][hang + 11];
            exRange.Range["A1:F" + (tblHang.Rows.Count + 1) + ""].Borders.Color = Color.Black;
            exRange.Range["A2:F" + (tblHang.Rows.Count + 1) + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange = exSheet.Cells[1, 1];
            for (hang = 0; hang < tblHang.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblHang.Columns.Count; cot++)
                    exSheet.Cells[cot + 2][hang + 12] = tblHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[4][hang + 15];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exSheet.Name = "Báo cáo hàng tồn";
            exApp.Visible = true;
        }
    }
}
