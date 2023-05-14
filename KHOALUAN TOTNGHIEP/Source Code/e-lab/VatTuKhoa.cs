using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class VatTuKhoa
    {
        public static DataTable check_thietbikhoa(string matb, string madv, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBiKhoa where MaTB = '"+matb+"' and MaDV = '"+madv+"' and MaPL = '"+mapl+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable check_dungcukhoa(string madc, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCuKhoa where MaDC = '" + madc + "' and MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable check_hoachatkhoa(string mahc, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChatKhoa where MaHC = '" + mahc + "' and MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void them_tbk(string matb, string madv, string mapl, string soluongton)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ThietBiKhoa values('" + matb + "', '" + madv + "', '" + mapl + "', getdate(), '"+soluongton+"')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_dck(string madc, string madv, string soluongton)
        {
            OleDbCommand cmd = new OleDbCommand("insert into DungCuKhoa values('" + madc + "', '" + madv + "', getdate(), '" + soluongton + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_hck(string MaHC, string madv, string soluongton)
        {
            OleDbCommand cmd = new OleDbCommand("insert into HoaChatKhoa values('" + MaHC + "', '" + madv + "', getdate(), '" + soluongton + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_thietbikhoa(string mapx, string matb, string madv, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBiKhoa set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuXuat_ThietBi where MaTB = '" + matb + "' and MaPL = '" + mapl + "' and MaPX = '" + mapx + "') where MaTB = '" + matb + "' and MaDV = '" + madv + "' and MaPL = '" + mapl + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_thietbikhoa_xuat(string MaPXK, string matb, string madv, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBiKhoa set SoLuongTon = SoLuongTon - (select SoLuong from ChiTietPhieuXuatKhoa_ThietBi, PhieuXuatKhoa where MaTB = '" + matb + "' and MaDV = '" + madv + "' and MaPL = '" + mapl + "' and PhieuXuatKhoa.MaPXK = '" + MaPXK + "') where MaTB = '" + matb + "' and MaDV = '" + madv + "' and MaPL = '" + mapl + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_dungcukhoa_xuat(string MaPXK, string MaDC, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCuKhoa set SoLuongTon = SoLuongTon - (select SoLuong from ChiTietPhieuXuatKhoa_DungCu, PhieuXuatKhoa where MaDC ='" + MaDC + "' and MaDV = '" + madv + "' and PhieuXuatKhoa.MaPXK = '" + MaPXK + "') where MaDC ='" + MaDC + "' and MaDV = '" + madv + "'  ");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_hoachatkhoa_xuat(string MaPXK, string mahc, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChatKhoa set SoLuongTon = SoLuongTon - (select SoLuong from ChiTietPhieuXuatKhoa_HoaChat, PhieuXuatKhoa where MaHC ='" + mahc + "' and MaDV = '" + madv + "' and PhieuXuatKhoa.MaPXK = '" + MaPXK + "') where MaHC ='" + mahc + "' and MaDV = '" + madv + "'  ");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_dungcukhoa(string mapx, string MaDC, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCuKhoa set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuXuat_DungCu where MaDC ='" + MaDC + "' and MaPX = '" + mapx + "') where MaDC ='" + MaDC + "' and MaDV = '" + madv + "'  ");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_hoachatkhoa(string mapx, string mahc, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChatKhoa set SoLuongTon = SoLuongTon + (select SoLuong from ChiTietPhieuXuat_HoaChat where MaHC ='" + mahc + "' and MaPX = '" + mapx + "') where MaHC ='" + mahc + "' and MaDV = '" + madv + "'  ");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_dungcukhoa(string MaDV)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCuKhoa where MaDV = '"+MaDV+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_thietbikhoa(string MaDV)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBiKhoa where MaDV = '" + MaDV + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_thietbikhoa_matb(string MaDV, string matb, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBiKhoa where MaDV = '" + MaDV + "' and MaTB = '"+matb+"' and MaPL = '"+mapl+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hoachatkhoa(string MaDV)
        {
            OleDbCommand cmd = new OleDbCommand("select HoaChat.MaHC, TenHC, CTHH, HoaChatKhoa.NgayNhap, HoaChatKhoa.SoLuongTon, HanSuDung, GhiChu from HoaChat, HoaChatKhoa where HoaChatKhoa.MaHC = HoaChat.MaHC and MaDV = '" + MaDV + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hoachatkhoa_mahc(string MaDV, string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChatKhoa where MaHC = '"+mahc+"' and MaDV = '" + MaDV + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_dungcukhoa_madc(string MaDV, string madc)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCuKhoa where MaDC = '" + madc + "' and MaDV = '" + MaDV + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_dungcukhoa_pagination(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select DungCuKhoa.MaDC, TenDC, DungCuKhoa.NgayNhap, DungCuKhoa.SoLuongTon, DungCu.DVT from DungCuKhoa, DungCu where DungCuKhoa.MaDC = DungCu.MaDC and MaDV = '"+madv+"' order by DungCuKhoa.MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_thietbikhoa_pagination(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select ThietBiKhoa.MaTB, TenThietBi, TenPL, ThietBiKhoa.NgayNhap, ThietBiKhoa.SoLuongTon, DVT from ThietBiKhoa, ThietBi, PhongLab where PhongLab.MaPL = ThietBiKhoa.MaPL and ThietBiKhoa.MaTB = ThietBi.MaTB and MaDV = '" + madv + "' order by ThietBiKhoa.MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_thietbikhoa_search_pagination(string madv, string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select ThietBiKhoa.MaTB, TenThietBi, TenPL, ThietBiKhoa.NgayNhap, ThietBiKhoa.SoLuongTon, DVT from ThietBiKhoa, ThietBi, PhongLab where PhongLab.MaPL = ThietBiKhoa.MaPL and ThietBiKhoa.MaTB = ThietBi.MaTB and MaDV = '" + madv + "' and TenThietBi like N'%" + keyword + "%' order by ThietBiKhoa.MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_thietbikhoa_search(string madv, string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select ThietBiKhoa.MaTB, TenThietBi, TenPL, ThietBiKhoa.NgayNhap, ThietBiKhoa.SoLuongTon from ThietBiKhoa, ThietBi, PhongLab where PhongLab.MaPL = ThietBiKhoa.MaPL and ThietBiKhoa.MaTB = ThietBi.MaTB and MaDV = '" + madv + "' and TenThietBi like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hoachatkhoa_pagination(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select HoaChat.MaHC, TenHC, CTHH, HoaChatKhoa.NgayNhap, HoaChatKhoa.SoLuongTon, HanSuDung, GhiChu, DVT from HoaChat, HoaChatKhoa where HoaChatKhoa.MaHC = HoaChat.MaHC and MaDV = '" + madv + "' order by HoaChatKhoa.MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hoachatkhoa_search_pagination(string madv, string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select HoaChat.MaHC, TenHC, CTHH, HoaChatKhoa.NgayNhap, HoaChatKhoa.SoLuongTon, HanSuDung, GhiChu, DVT from HoaChat, HoaChatKhoa where HoaChatKhoa.MaHC = HoaChat.MaHC and MaDV = '" + madv + "' and TenHC like N'%" + keyword + "%' order by HoaChatKhoa.MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_dungcukhoa_search_pagination(string madv, string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select DungCuKhoa.MaDC, TenDC, DungCuKhoa.NgayNhap, DungCuKhoa.SoLuongTon, DungCu.DVT from DungCuKhoa, DungCu where TenDC like N'%" + keyword + "%' and DungCuKhoa.MaDC = DungCu.MaDC and MaDV = '" + madv + "' order by DungCuKhoa.MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_dungcukhoa_search(string madv, string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select DungCuKhoa.MaDC, TenDC, DungCuKhoa.NgayNhap, DungCuKhoa.SoLuongTon from DungCuKhoa, DungCu where TenDC like N'%" + keyword + "%' and DungCuKhoa.MaDC = DungCu.MaDC and MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hoachatkhoa_search(string madv, string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select HoaChat.MaHC, TenHC, CTHH, HoaChatKhoa.NgayNhap, HoaChatKhoa.SoLuongTon, HanSuDung, GhiChu from HoaChat, HoaChatKhoa where HoaChatKhoa.MaHC = HoaChat.MaHC and MaDV = '" + madv + "' and TenHC like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_het_date(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select HanSuDung from HoaChat , HoaChatKhoa where HoaChat.MaHC = HoaChatKhoa.MaHC and MaDV = '"+madv+"' and HanSuDung <= getdate()");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void sua_hc(string mahc, string madv, string soluongton)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChatKhoa set SoLuongTon ='"+soluongton+"' where MaDV ='"+madv+"' and MaHC ='"+mahc+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_dc(string madc, string madv, string soluongton)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCuKhoa set SoLuongTon ='" + soluongton + "' where MaDV ='" + madv + "' and MaDC ='" + madc + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable sosanhsoluong_dc(string madc, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DungCuKhoa where MaDC = '" + madc + "' and MaDV = '"+madv+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable sosanhsoluong_tb(string matb, string mapl, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBiKhoa where MaTB = '" + matb + "' and MaDV = '" + madv + "' and MaPL = '" + mapl + "' ");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable sosanhsoluong_hc(string mahc, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from HoaChatKhoa where MaHC = '" + mahc + "' and MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}