using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quanlykho
{
    class ThucthiSQL
    {
        public static SqlConnection conn;
           
        public static string connString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
            System.IO.Directory.GetCurrentDirectory().ToString() +
            "\\Database\\Quankho.mdf;Integrated Security = True";
        public static void KetNoiCSDL()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        public static void DongKetNoiCSDL()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        public static DataTable DocBang(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Mydata = new SqlDataAdapter();
            Mydata.SelectCommand = new SqlCommand();
            KetNoiCSDL();
            Mydata.SelectCommand.Connection = conn;
            Mydata.SelectCommand.CommandText = sql;
            Mydata.Fill(dt);
            DongKetNoiCSDL();
            return dt;
        }
        public static void CapNhatDuLieu(string sql)
        {
            KetNoiCSDL();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            DongKetNoiCSDL();
        }
        public static string Thanhtien(string Soluong, string Dongia, string Giamgia)
        {
            Double SL, DG, GG, TT;
            if (Soluong == "")
            {
                SL = 0;
            }
            else SL = Convert.ToDouble(Soluong);
            if (Dongia == "")
            {
                DG = 0;
            }
            else DG = Convert.ToDouble(Dongia);
            if (Giamgia == "")
            {
                GG = 0;
            }
            else
            {
                GG = Convert.ToDouble(Giamgia);
            }
            TT = DG * SL - DG * SL * GG / 100;
            return TT.ToString();
        }
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsday = new string[5];
            partsday = DateTime.Now.ToShortDateString().Split('/');
            string d = string.Format("{0}{1}{2}", partsday[0], partsday[1], partsday[2]);
            key = key + d;
            string[] partstime = new string[5];
            partstime = DateTime.Now.ToLongTimeString().Split(':');
            if (partstime[2].Substring(3, 2) == "PM")
                partstime[0] = ConvertTimeTo24(partstime[0]);
            if (partstime[2].Substring(3, 2) == "AM")
                if (partstime[0].Length == 1)
                    partstime[0] = "0" + partstime[0];
            partstime[2] = partstime[2].Remove(2, 3);
            string t;
            t = string.Format("_{0}{1}{2}", partstime[0], partstime[1], partstime[2]);
            key = key + t;
            return key;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1;
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i)
                    break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + "Tỷ";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }
    }
}
