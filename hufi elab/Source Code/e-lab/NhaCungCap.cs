using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class NhaCungCap
    {
        public static DataTable ds_ncc_mancc(string MaNCC)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaCungCap where MaNCC = '" + MaNCC + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void xoa_ncc(string MaNCC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from NhaCungCap where MaNCC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ncc(string TenNCC, string SDT, string Email, string DiaChi)
        {
            OleDbCommand cmd = new OleDbCommand("insert into NhaCungCap values(N'" + TenNCC + "', N'" + SDT + "', N'" + Email + "', N'" + DiaChi + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ncc(string MaNCC, string TenNCC, string SDT, string Email, string DiaChi)
        {
            OleDbCommand cmd = new OleDbCommand("update NhaCungCap set TenNCC = N'" + TenNCC + "', SDT = '" + SDT + "', Email = '" + Email + "', DiaChi = N'" + DiaChi + "' where MaNCC = '" + MaNCC + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_ncc()
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaCungCap");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_NhaCungCap_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaCungCap order by MaNCC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ncc_search(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaCungCap where TenNCC like N'%"+keyword+"%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_NhaCungCap_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhaCungCap where TenNCC like N'%" + keyword + "%' order by MaNCC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}