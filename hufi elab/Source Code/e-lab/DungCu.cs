using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class DungCu
    {
        public static DataTable ds_dc()
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCu");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_dc_madc(string madc)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCu where MaDC = '"+madc+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable sosanhsoluong_dc(string madc)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCu where MaDC = '"+madc+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_DungCu_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDC, TenDC, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from DungCu order by MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_DungCu_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDC, TenDC, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from DungCu where TenDC like N'%" + keyword + "%' order by MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void update_soluong()
        {
            OleDbCommand cmd2 = new OleDbCommand("update DungCu set SoLuongXuat = (select sum(SoLuongTon) from DungCuKhoa where DungCu.MaDC = DungCuKhoa.MaDC)");
            cmd2.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd2);
            OleDbCommand cmd3 = new OleDbCommand("update DungCu set SoLuongXuat = 0 where SoLuongXuat IS NULL");
            cmd3.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd3);
            OleDbCommand cmd4 = new OleDbCommand("update DungCu set SoLuongNhap = (SoLuongXuat+SoLuongTon)");
            cmd4.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd4);
        }

        public static void them_DC(string TenDC, string MaNSX, string MaNCC, int SoLuongTon, string DVT)
        {
            OleDbCommand cmd = new OleDbCommand("insert into DungCu values(N'" + TenDC + "', N'" + MaNSX + "', N'" + MaNCC + "', getdate() , 0, 0, " + SoLuongTon + ", N'"+DVT+"')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);

        }

        public static void sua_dc(string MaDC, string TenDC, string MaNSX, string MaNCC, int SoLuongTon, string DVT)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCu set TenDC = '" + TenDC + "', MaNSX='" + MaNSX + "', MaNCC = '" + MaNCC + "', SoLuongTon = " + SoLuongTon + ", DVT = N'"+DVT+"' where MaDC = '" + MaDC + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_dc(string MaDC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from DungCu where MaDC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaDC", MaDC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable moreinfo_dc(string MaDC)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDC, TenNSX, TenNCC from DungCu, NhaSanXuat, NhaCungCap where DungCu.MaNSX = NhaSanXuat.MaNSX and DungCu.MaNCC=NhaCungCap.MaNCC and MaDC ='" + MaDC + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_dc_search(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCu where TenDC like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}