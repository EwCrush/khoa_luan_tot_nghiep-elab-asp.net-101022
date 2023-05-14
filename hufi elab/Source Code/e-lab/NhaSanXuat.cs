using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class NhaSanXuat
    {
        public static void xoa_nsx(string MaNSX)
        {
            OleDbCommand cmd = new OleDbCommand("delete from NhaSanXuat where MaNSX = '" + MaNSX + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_nsx(string TenNSX, string SDT, string Email, string DiaChi)
        {
            OleDbCommand cmd = new OleDbCommand("insert into NhaSanXuat values(N'" + TenNSX + "', N'" + SDT + "', N'" + Email + "', N'"+DiaChi+"')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_nsx(string MaNSX, string TenNSX, string SDT, string Email, string DiaChi)
        {
            OleDbCommand cmd = new OleDbCommand("update NhaSanXuat set TenNSX = N'"+TenNSX+"', SDT = '"+SDT+"', Email = '"+Email+"', DiaChi = N'"+DiaChi+"' where MaNSX = '"+MaNSX+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_nsx()
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaSanXuat");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nsx_search(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaSanXuat where TenNSX like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_NhaSanXuat_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaSanXuat order by MaNSX offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_NhaSanXuat_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaSanXuat where TenNSX like N'%" + keyword + "%' order by MaNSX offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nsx_MaNSX(string MaNSX)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaSanXuat where MaNSX = '" + MaNSX + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    
    }
}