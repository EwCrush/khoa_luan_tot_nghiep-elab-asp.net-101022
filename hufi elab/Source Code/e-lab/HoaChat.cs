using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class HoaChat
    {
        public static void xoa_hc(string MaHC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from HoaChat where MaHC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaHC", MaHC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable sosanhsoluong_hc(string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChat where MaHC = '" + mahc + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void them_hc(string TenHC, string CTHH, string MaNSX, string MaNCC, int SoLuongTon, string HSD, string GhiChu, string dvt)
        {
            OleDbCommand cmd = new OleDbCommand("insert into HoaChat values(N'" + TenHC + "', N'" + CTHH + "', N'" + MaNSX + "', N'" + MaNCC + "', getdate() , 0, 0, " + SoLuongTon + ", N'" + dvt + "', '" + HSD + "', N'" + GhiChu + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong()
        {
            OleDbCommand cmd2 = new OleDbCommand("update HoaChat set SoLuongXuat = (select sum(SoLuongTon) from HoaChatKhoa where HoaChat.MaHC = HoaChatKhoa.MaHC)");
            cmd2.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd2);
            OleDbCommand cmd3 = new OleDbCommand("update HoaChat set SoLuongXuat = 0 where SoLuongXuat IS NULL");
            cmd3.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd3);
            OleDbCommand cmd4 = new OleDbCommand("update HoaChat set SoLuongNhap = (SoLuongXuat+SoLuongTon)");
            cmd4.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd4);
        }

        public static DataTable ds_hc_het_date()
        {
            OleDbCommand cmd = new OleDbCommand("select MaHC, TenHC, CTHH, TenNSX, TenNCC, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, HanSuDung, GhiChu from HoaChat, NhaSanXuat, NhaCungCap where NhaSanXuat.MaNSX = HoaChat.MaNSX and NhaCungCap.MaNCC = HoaChat.MaNCC and HanSuDung <= getdate()");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }


        public static void sua_hc(string MaHC, string TenHC, string CTHH, string MaNSX, string MaNCC, int SoLuongTon, string HSD, string GhiChu, string dvt)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChat set TenHC = '" + TenHC + "', CTHH = '" + CTHH + "', MaNSX='" + MaNSX + "', MaNCC = '" + MaNCC + "', SoLuongTon = " + SoLuongTon + ", GhiChu = N'" + GhiChu + "', HanSuDung = '" + HSD + "', DVT = N'" + dvt + "' where MaHC = '" + MaHC + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_hc()
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChat");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_con_date()
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChat where HanSuDung >= getdate()");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_mahc(string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChat where MaHC = '"+mahc+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable moreinfo_hc(string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("select TenNSX, TenNCC, HanSuDung, GhiChu from HoaChat, NhaSanXuat, NhaCungCap where HoaChat.MaNSX = NhaSanXuat.MaNSX and HoaChat.MaNCC=NhaCungCap.MaNCC and MaHC ='"+mahc+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable moreinfo_hc_hethan(string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("select NgayNhap, TenNSX, TenNCC, GhiChu from HoaChat, NhaSanXuat, NhaCungCap where HoaChat.MaNSX = NhaSanXuat.MaNSX and HoaChat.MaNCC=NhaCungCap.MaNCC and MaHC ='" + mahc + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_HoaChat_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaHC, TenHC, CTHH, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from HoaChat order by MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_HoaChat_het_date_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaHC, TenHC, CTHH, SoLuongNhap, SoLuongXuat, SoLuongTon, HanSuDung, DVT from HoaChat where HanSuDung <= getdate() order by HanSuDung offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_search(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChat where TenHC like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_HoaChat_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaHC, TenHC, CTHH, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from HoaChat where TenHC like N'%" + keyword + "%' order by MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

    }
}