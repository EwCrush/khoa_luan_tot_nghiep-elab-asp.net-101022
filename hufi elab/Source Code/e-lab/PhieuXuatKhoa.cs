using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class PhieuXuatKhoa
    {
        public static DataTable ds_PhieuXuat_dangxacnhan(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, NgayLap, TenNV, TrangThai, PhieuXuatKhoa.MaDV from PhieuXuatKhoa, NhanVien where PhieuXuatKhoa.MaNV = NhanVien.MaNV and TrangThai != N'Đã xuất' and PhieuXuatKhoa.MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, NgayLap, TenNV, TrangThai, PhieuXuatKhoa.MaDV from PhieuXuatKhoa, NhanVien where PhieuXuatKhoa.MaNV = NhanVien.MaNV and TrangThai = N'Đã xuất' and PhieuXuatKhoa.MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_pagination(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, NgayLap, TenNV, TrangThai from PhieuXuatKhoa, NhanVien where PhieuXuatKhoa.MaNV = NhanVien.MaNV and TrangThai = N'Đã xuất' and PhieuXuatKhoa.MaDV = '" + madv + "' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_hc_pagination(string MaPXK, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, TenHC, ChiTietPhieuXuatKhoa_HoaChat.MaHC, SoLuong from ChiTietPhieuXuatKhoa_HoaChat, HoaChat where ChiTietPhieuXuatKhoa_HoaChat.MaHC = HoaChat.MaHC and MaPXK = '" + MaPXK + "' order by MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_tb_pagination(string MaPXK, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, TenThietBi, ChiTietPhieuXuatKhoa_ThietBi.MaPL, TenPL, ChiTietPhieuXuatKhoa_ThietBi.MaTB, SoLuong from ChiTietPhieuXuatKhoa_ThietBi, ThietBi, PhongLab where ChiTietPhieuXuatKhoa_ThietBi.MaTB = ThietBi.MaTB and ChiTietPhieuXuatKhoa_ThietBi.MaPL = PhongLab.MaPL and MaPXK = '" + MaPXK + "' order by MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_dc_pagination(string MaPXK, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, TenDC, ChiTietPhieuXuatKhoa_DungCu.MaDC, SoLuong from ChiTietPhieuXuatKhoa_DungCu, DungCu where ChiTietPhieuXuatKhoa_DungCu.MaDC = DungCu.MaDC and MaPXK = '" + MaPXK + "' order by MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_hc(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_HoaChat where MaPXK = '" + MaPXK + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_tb(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_ThietBi where MaPXK = '" + MaPXK + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_dc(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_DungCu where MaPXK = '" + MaPXK + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void xoa_ctpxk_hoachat_frompn(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuatKhoa_HoaChat where MaPXK = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpxk_thietbi_frompn(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuatKhoa_ThietBi where MaPXK = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpxk_dungcu_frompn(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuatKhoa_DungCu where MaPXK = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_pxk(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("delete from PhieuXuatKhoa where MaPXK = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_PhieuXuatKhoa_dcxn_pagination(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPXK, NgayLap, TenNV, TrangThai from PhieuXuatKhoa, NhanVien where PhieuXuatKhoa.MaNV = NhanVien.MaNV and TrangThai != N'Đã xuất' and PhieuXuatKhoa.MaDV = '"+madv+"' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void them_pxk(string manv, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("insert into PhieuXuatKhoa (NgayLap, MaNV, MaDV) values (getdate(), '" + manv + "', '" + madv + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpx_hc(string soluong, string MaPXK, string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuXuatKhoa_HoaChat set SoLuong = '" + soluong + "' where MaPXK = '" + MaPXK + "' and MaHC ='" + mahc + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpx_dc(string soluong, string MaPXK, string madc)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuXuatKhoa_DungCu set SoLuong = '" + soluong + "' where MaPXK = '" + MaPXK + "' and MaDC ='" + madc + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpx_tb(string soluong, string MaPXK, string matb, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuXuatKhoa_ThietBi set SoLuong = '" + soluong + "' where MaPXK = '" + MaPXK + "' and MaTB ='" + matb + "' and MaPL = '" + mapl + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpx_dc(string MaPXK, string madc, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuXuatKhoa_DungCu values(N'" + MaPXK + "','" + madc + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpx_hc(string MaPXK, string mahc, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuXuatKhoa_HoaChat values(N'" + MaPXK + "','" + mahc + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpx_tb(string MaPXK, string matb, string mapl, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuXuatKhoa_ThietBi values(N'" + MaPXK + "','" + matb + "', '" + mapl + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_dc_check(string keyword, string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_DungCu where MaDC = '" + keyword + "' and MaPXK ='" + MaPXK + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_check(string keyword, string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_HoaChat where MaHC = '" + keyword + "' and MaPXK ='" + MaPXK + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tb_check(string keyword, string MaPXK, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_ThietBi where MaTB = '" + keyword + "' and MaPXK ='" + MaPXK + "' and MaPL ='" + mapl + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void xoa_ctpxk_hc(string MaPXK, string MaHC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChitietPhieuXuatKhoa_HoaChat where MaPXK = ? and MaHC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            cmd.Parameters.AddWithValue("@MaHC", MaHC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpxk_dc(string MaPXK, string MaDC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChitietPhieuXuatKhoa_DungCu where MaPXK = ? and MaDC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            cmd.Parameters.AddWithValue("@MaDC", MaDC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpxk_tb(string MaPXK, string MaTB, string MaPL)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChitietPhieuXuatKhoa_ThietBi where MaPXK = ? and MaTB = ? and MaPL = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPXK", MaPXK);
            cmd.Parameters.AddWithValue("@MaTB", MaTB);
            cmd.Parameters.AddWithValue("@MaPL", MaPL);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_phieuxuatkhoa(string mapxk, string ngaylap)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuatKhoa set NgayLap = '" + ngaylap + "' where MaPXK = '" + mapxk + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        //public static DataTable CTPX_hc(string MaPXK)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_HoaChat where MaPXK = '" + MaPXK + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        //public static DataTable CTPX_tb(string MaPXK)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_ThietBi where MaPXK = '" + MaPXK + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        //public static DataTable CTPX_dc(string MaPXK)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuatKhoa_DungCu where MaPXK = '" + MaPXK + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        public static void update_soluong_dungcu(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCu set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuXuatKhoa_DungCu where ChiTietPhieuXuatKhoa_DungCu.MaDC = DungCu.MaDC and MaPXK = '" + MaPXK + "') where MaDC = (select MaDC from ChiTietPhieuXuatKhoa_DungCu where MaPXK ='" + MaPXK + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }


        public static void update_PhieuXuatKhoa(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuatKhoa set TrangThai = N'Đã xuất' where MaPXK = '" + MaPXK + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_thietbi(string MaPXK, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuXuatKhoa_ThietBi where ChiTietPhieuXuatKhoa_ThietBi.MaTB = ThietBi.MaTB and MaPXK = '" + MaPXK + "' and MaPL = '" + mapl + "') where MaTB = (select MaTB from ChiTietPhieuXuatKhoa_ThietBi where MaPXK ='" + MaPXK + "' and MaPL = '" + mapl + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_hoachat(string MaPXK)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChat set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuXuatKhoa_HoaChat where ChiTietPhieuXuatKhoa_HoaChat.MaHC = HoaChat.MaHC and MaPXK = '" + MaPXK + "') where MaHC = (select MaHC from ChiTietPhieuXuatKhoa_HoaChat where MaPXK ='" + MaPXK + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
    }
}