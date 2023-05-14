using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class LichSuHoatDong
    {
        public static void duyetphieuxuat(string MaNV, string MaPX, string TenDV)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Duyệt phiếu xuất "+MaPX+" cho "+TenDV+"', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void duyetphieuxuatkhoa(string MaNV, string MaPX, string TenDV)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Xác nhận duyệt phiếu xuất khoa " + MaPX + " từ khoa " + TenDV + " về trung tâm', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void tuchoi_duyetphieuxuat(string MaNV, string MaPX, string TenDV)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Từ chối duyệt phiếu xuất " + MaPX + " cho " + TenDV + "', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoaphieuxuat(string MaNV, string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Xóa phiếu xuất " + MaPX + "', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoaphieunhap(string MaNV, string MaPN)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Xóa phiếu nhập " + MaPN + "', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoaphieuxuatkhoa(string MaNV, string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Xóa phiếu xuất khoa " + MaPXK + "', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void duyetphieunhap(string MaNV, string MaPN)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuHoatDong values(N'" + MaNV + "', N'Xác nhận phiếu nhập " + MaPN + "', getdate())");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_lshd_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaLSHD, TenNV, TrangThai, ThoiGian from LichSuHoatDong, NhanVien where NhanVien.MaNV = LichSuHoatDong.MaNV  order by ThoiGian offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_lshd()
        {
            OleDbCommand cmd = new OleDbCommand("select * from LichSuHoatDong");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void xoa_ls(string MaLSHD)
        {
            OleDbCommand cmd = new OleDbCommand("delete from LichSuHoatDong where MaLSHD = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaLSHD", MaLSHD);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

    }
}