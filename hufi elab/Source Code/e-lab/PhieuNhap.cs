using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class PhieuNhap
    {
        public static DataTable ds_PhieuNhap_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPN, NgayLap, TenNV, TrangThai from PhieuNhap, NhanVien where PhieuNhap.MaNV = NhanVien.MaNV and TrangThai = N'Đã xác nhận' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuNhap_dcxn_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPN, NgayLap, TenNV, TrangThai from PhieuNhap, NhanVien where PhieuNhap.MaNV = NhanVien.MaNV and TrangThai != N'Đã xác nhận' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuNhap()
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuNhap where TrangThai = N'Đã xác nhận'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable check_trangthai(string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuNhap where MaPN = '"+mapn+"' and  TrangThai = N'Đã xác nhận'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPN_hc(string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_HoaChat where MaPN = '" + mapn + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPN_tb(string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_ThietBi where MaPN = '" + mapn + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPN_dc(string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_DungCu where MaPN = '" + mapn + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        //public static DataTable CTPN_dc(string MaPN)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_DungCu where MaPN = '" + MaPN + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        public static DataTable CTPN_hc_pagination(string mapn, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPN, TenHC, ChiTietPhieuNhap_HoaChat.MaHC, SoLuong from ChiTietPhieuNhap_HoaChat, HoaChat where ChiTietPhieuNhap_HoaChat.MaHC = HoaChat.MaHC and MaPN = '" + mapn + "' order by MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPN_tb_pagination(string mapn, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPN, TenThietBi, ChiTietPhieuNhap_ThietBi.MaTB, SoLuong from ChiTietPhieuNhap_ThietBi, ThietBi where ChiTietPhieuNhap_ThietBi.MaTB = ThietBi.MaTB and MaPN = '" + mapn + "' order by MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPN_dc_pagination(string mapn, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPN, TenDC, ChiTietPhieuNhap_DungCu.MaDC, SoLuong from ChiTietPhieuNhap_DungCu, DungCu where ChiTietPhieuNhap_DungCu.MaDC = DungCu.MaDC and MaPN = '" + mapn + "' order by MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuNhap_dangxacnhan()
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuNhap where TrangThai != N'Đã xác nhận'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }



        public static void xoa_ctpn_hoachat_frompn(string MaPN)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuNhap_HoaChat where MaPN = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpn_thietbi_frompn(string MaPN)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuNhap_ThietBi where MaPN = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpn_dungcu_frompn(string MaPN)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuNhap_DungCu where MaPN = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_pn(string MaPN)
        {
            OleDbCommand cmd = new OleDbCommand("delete from PhieuNhap where MaPN = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpn_hc(string MaPN, string MaHC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuNhap_HoaChat where MaPN = ? and MaHC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.Parameters.AddWithValue("@MaHC", MaHC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpn_dc(string MaPN, string MaDC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuNhap_DungCu where MaPN = ? and MaDC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.Parameters.AddWithValue("@MaDC", MaDC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpn_tb(string MaPN, string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuNhap_ThietBi where MaPN = ? and MaTB = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.Parameters.AddWithValue("@MaTB", MaTB);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpn_hc(string mapn, string mahc, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuNhap_HoaChat values(N'" + mapn + "','" + mahc + "', '"+soluong+"')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpn_tb(string mapn, string matb, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuNhap_ThietBi values(N'" + mapn + "','" + matb + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_pn(string manv)
        {
            OleDbCommand cmd = new OleDbCommand("insert into PhieuNhap (NgayLap, MaNV) values (getdate(), '"+manv+"')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpn_dc(string mapn, string madc, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuNhap_DungCu values(N'" + mapn + "','" + madc + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpn_hc(string soluong, string mapn, string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuNhap_HoaChat set SoLuong = '"+soluong+"' where MaPN = '"+mapn+"' and MaHC ='"+mahc+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpn_tb(string soluong, string mapn, string matb)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuNhap_ThietBi set SoLuong = '" + soluong + "' where MaPN = '" + mapn + "' and MaTB ='" + matb + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpn_dc(string soluong, string mapn, string madc)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuNhap_DungCu set SoLuong = '" + soluong + "' where MaPN = '" + mapn + "' and MaDC ='" + madc + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_daxacnhan(string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuNhap set TrangThai = N'Đã xác nhận' where MaPN = '" + mapn + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_dungcu(string mapn, string madc)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCu set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuNhap_DungCu where MaDC = '"+madc+"' and MaPN = '" + mapn + "') where MaDC = '"+madc+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        //public static DataTable CTPN_hc(string MaPN)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_HoaChat where MaPN = '" + MaPN + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        //public static DataTable CTPN_tb(string MaPN)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_ThietBi where MaPN = '" + MaPN + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        //public static DataTable CTPN_dc(string MaPN)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_DungCu where MaPN = '" + MaPN + "'");
        //    cmd.CommandType = CommandType.Text;
        //    return SQLDatabase.GetData(cmd);
        //}

        public static void update_phieunhap(string mapn, string ngaylap)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuNhap set NgayLap = '"+ngaylap+"' where MaPN = '"+mapn+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_thietbi(string mapn, string matb)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuNhap_ThietBi where MaTB = '" + matb + "' and MaPN = '" + mapn + "') where MaTB = '" + matb + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_hoachat(string mapn, string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChat set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuNhap_HoaChat where MaHC = '"+mahc+"' and MaPN = '" + mapn + "') where MaHC = '"+mahc+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_dc_check(string keyword, string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_DungCu where MaDC = '"+keyword+"' and MaPN ='"+mapn+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_check(string keyword, string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_HoaChat where MaHC = '" + keyword + "' and MaPN ='" + mapn + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tb_check(string keyword, string mapn)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuNhap_ThietBi where MaTB = '" + keyword + "' and MaPN ='" + mapn + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}