using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class NhanVien
    {

        public static void xoa_nv(string MaNV)
        {
            OleDbCommand cmd = new OleDbCommand("delete from NhanVien where MaNV = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_nv_DonVi(string MaDV)
        {
            OleDbCommand cmd = new OleDbCommand("delete from NhanVien where MaDV = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaDV", MaDV);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_nv_trungtam(string TenNV, string GioiTinh, string NgaySinh, string SDT, string DiaChi, string MaDV, string MaCV, string Username)
        {
            OleDbCommand cmd = new OleDbCommand("insert into NhanVien(TenNV, GioiTinh, NgaySinh, SDT, DiaChi, MaDV, MaCV, TaiKhoan, MatKhau) values(N'" + TenNV + "', N'" + GioiTinh + "', '" + NgaySinh + "', N'" + SDT + "', N'" + DiaChi + "', '" + MaDV + "', '" + MaCV + "', '"+Username+"', '123')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_nv(string TenNV, string GioiTinh, string NgaySinh, string SDT, string DiaChi, string MaDV)
        {
            OleDbCommand cmd = new OleDbCommand("insert into NhanVien(TenNV, GioiTinh, NgaySinh, SDT, DiaChi, MaDV, MaCV) values(N'" + TenNV + "', N'" + GioiTinh + "', '" + NgaySinh + "', N'" + SDT + "', N'" + DiaChi + "', '" + MaDV + "', 3)");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_nv(string MaNV, string TenNV, string GioiTinh, string NgaySinh, string SDT, string DiaChi, string MaDV)
        {
            OleDbCommand cmd = new OleDbCommand("update NhanVien set TenNV = N'" + TenNV + "', GioiTinh = N'" + GioiTinh + "', NgaySinh ='" + NgaySinh + "', SDT = '" + SDT + "', DiaChi = N'" + DiaChi + "', MaDV ='" + MaDV + "' where MaNV = '" + MaNV + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_nv_trungtam(string MaNV, string TenNV, string GioiTinh, string NgaySinh, string SDT, string DiaChi, string MaDV, string MaCV)
        {
            OleDbCommand cmd = new OleDbCommand("update NhanVien set TenNV = N'" + TenNV + "', GioiTinh = N'" + GioiTinh + "', NgaySinh ='" + NgaySinh + "', SDT = '" + SDT + "', DiaChi = N'" + DiaChi + "', MaDV ='" + MaDV + "', MaCV ='" + MaCV + "' where MaNV = '" + MaNV + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_taikhoan(string MaNV, string taikhoan, string matkhau)
        {
            OleDbCommand cmd = new OleDbCommand("update NhanVien set TaiKhoan = '"+taikhoan+"', MatKhau = '"+matkhau+"' where MaNV = '" + MaNV + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_nv()
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi where NhanVien.MaDV = DonVi.MaDV");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_check_madv_macv(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhanVien where MaDV = '"+madv+"' and MaDV != 1 and MaCV != 3");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_check_tendn(string taikhoan)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhanVien where TaiKhoan = '" + taikhoan + "' ");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_for_update(string manv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhanVien where MaNV='" + manv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_khoa(string khoa)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi where NhanVien.MaDV = DonVi.MaDV and NhanVien.MaDV = '"+khoa+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_DonVi(string maDV)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi where NhanVien.MaDV = DonVi.MaDV and DonVi.MaDV = '" + maDV + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV, TenCV from NhanVien, DonVi, ChucVu where ChucVu.MaCV = NhanVien.MaCV and NhanVien.MaDV = DonVi.MaDV order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_pagination_khoa(string khoa, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV, TenCV from NhanVien, DonVi, ChucVu where NhanVien.MaCV = ChucVu.MaCV and NhanVien.MaDV = DonVi.MaDV and NhanVien.MaDV = '" + khoa + "' order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_DonVi_pagination(string maDV, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi, ChucVu where NhanVien.MaDV = DonVi.MaDV and DonVi.MaDV = '" + maDV + "' order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        //public static DataTable ds_nv_search_keyword(string keyword)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi where NhanVien.MaDV = DonVi.MaDV and TenNV like N'%" + keyword + "%'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        public static DataTable ds_nv_search_keyword(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi where NhanVien.MaDV = DonVi.MaDV and TenNV like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_search_keyword_khoa(string keyword, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV from NhanVien, DonVi where NhanVien.MaDV = '"+madv+"' and NhanVien.MaDV = DonVi.MaDV and TenNV like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk()
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, TaiKhoan, MatKhau from NhanVien");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_khoa(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDV, MaNV, TenNV, TaiKhoan, MatKhau from NhanVien where MaDV = '"+madv+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_pagination_khoa(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDV, MaNV, TenNV, TaiKhoan, MatKhau from NhanVien where MaDV = '"+madv+"' order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, TaiKhoan, MatKhau from NhanVien order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_search(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, TaiKhoan, MatKhau from NhanVien where TenNV like N'%" + keyword + "%' or TaiKhoan like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_search_khoa(string madv, string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDV, MaNV, TenNV, TaiKhoan, MatKhau from NhanVien where MaDV = '"+madv+"' and (TenNV like N'%" + keyword + "%' or TaiKhoan like N'%" + keyword + "%')");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, TaiKhoan, MatKhau from NhanVien where TenNV like N'%" + keyword + "%' or TaiKhoan like N'%" + keyword + "%' order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tk_search_pagination_khoa(string madv, string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaDV, MaNV, TenNV, TaiKhoan, MatKhau from NhanVien where MaDV = '" + madv + "' and (TenNV like N'%" + keyword + "%' or TaiKhoan like N'%" + keyword + "%') order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_search_keyword_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV, TenCV from NhanVien, DonVi, ChucVu where NhanVien.MaCV = ChucVu.MaCV and NhanVien.MaDV = DonVi.MaDV and TenNV like N'%" + keyword + "%' order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_nv_search_keyword_pagination_khoa(string keyword, string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDV, TenCV from NhanVien, DonVi, ChucVu where NhanVien.MaDV = DonVi.MaDV and NhanVien.MaCV = ChucVu.MaCV and NhanVien.MaDV = '" + madv + "' and TenNV like N'%" + keyword + "%' order by MaNV offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable check_login(string taikhoan, string matkhau)
        {
            OleDbCommand cmd = new OleDbCommand("select * from NhanVien where TaiKhoan ='"+taikhoan+"' and MatKhau='"+matkhau+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}