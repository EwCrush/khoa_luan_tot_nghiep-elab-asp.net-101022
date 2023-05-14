using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class PhieuXuat
    {
        public static DataTable ds_PhieuXuat_dangchoduyet()
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đang chờ duyệt'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_dangchogui_khoa(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where (TrangThai = N'Chưa gửi' or TrangThai =N'Bị từ chối') and MaDV='"+madv+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_dangchoduyet_khoa(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đang chờ duyệt' and MaDV='" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable checkmodul(string mapx)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đang chờ duyệt' and MaPX = '"+mapx+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable isDangDuyet(string mapx)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đang chờ duyệt' and MaPX = '" + mapx + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable isDaDuyet(string mapx)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đã duyệt' and MaPX = '" + mapx + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat()
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đã duyệt'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_mapx(string mapx)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where MaPX = '"+mapx+"''");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_khoa(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhieuXuat where TrangThai = N'Đã duyệt' and MaDV = '" + madv + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, NgayLap, TenNV, TenDV, TrangThai from PhieuXuat, NhanVien, DonVi where PhieuXuat.NVDuyet = NhanVien.MaNV and PhieuXuat.MaDV = DonVi.MaDV and TrangThai = N'Đã duyệt' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_pagination_khoa(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, NgayLap, TenNV, TenDV, TrangThai from PhieuXuat, NhanVien, DonVi where PhieuXuat.NVLap = NhanVien.MaNV and PhieuXuat.MaDV = DonVi.MaDV and TrangThai = N'Đã duyệt' and DonVi.MaDV = '" + madv + "' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_dangchogui_pagination_khoa(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, NgayLap, TenNV, TenDV, TrangThai from PhieuXuat, NhanVien, DonVi where PhieuXuat.NVLap = NhanVien.MaNV and PhieuXuat.MaDV = DonVi.MaDV and (TrangThai = N'Chưa gửi' or TrangThai= N'Bị từ chối') and DonVi.MaDV = '" + madv + "' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_dangchoduyet_pagination_khoa(string madv, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, NgayLap, TenNV, TenDV, TrangThai from PhieuXuat, NhanVien, DonVi where PhieuXuat.NVLap = NhanVien.MaNV and PhieuXuat.MaDV = DonVi.MaDV and TrangThai = N'Đang chờ duyệt' and DonVi.MaDV = '" + madv + "' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_PhieuXuat_pagination_choduyet(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, NgayLap, TenNV, PhieuXuat.MaDV, TenDV, TrangThai from PhieuXuat, NhanVien, DonVi where PhieuXuat.NVLap = NhanVien.MaNV and PhieuXuat.MaDV = DonVi.MaDV and TrangThai = N'Đang chờ duyệt' order by NgayLap offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void xoa_ctpx_hoachat_frompx(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuat_HoaChat where MaPX = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpx_thietbi_frompx(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuat_ThietBi where MaPX = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpx_dungcu_frompx(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuat_DungCu where MaPX = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_px(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("delete from PhieuXuat where MaPX = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void gui_px(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuat set TrangThai = N'Đang chờ duyệt' where MaPX = '"+MaPX+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void thuhoi_px(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuat set TrangThai = N'Chưa gửi' where MaPX = '" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_tuchoiduyet(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuat set TrangThai = N'Bị từ chối' where MaPX = '" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable CTPX_hc(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuat_HoaChat where MaPX = '" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_tb(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuat_ThietBi where MaPX = '" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_dc(string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuat_DungCu where MaPX = '" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_hc_pagination(string MaPX, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, TenHC, ChiTietPhieuXuat_HoaChat.MaHC, SoLuong from ChiTietPhieuXuat_HoaChat, HoaChat where ChiTietPhieuXuat_HoaChat.MaHC = HoaChat.MaHC and MaPX = '" + MaPX + "' order by MaHC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_tb_pagination(string MaPX, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, TenThietBi, ChiTietPhieuXuat_ThietBi.MaPL, TenPL, ChiTietPhieuXuat_ThietBi.MaTB, SoLuong from ChiTietPhieuXuat_ThietBi, ThietBi, PhongLab where ChiTietPhieuXuat_ThietBi.MaTB = ThietBi.MaTB and ChiTietPhieuXuat_ThietBi.MaPL = PhongLab.MaPL and MaPX = '" + MaPX + "' order by MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable CTPX_dc_pagination(string MaPX, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaPX, TenDC, ChiTietPhieuXuat_DungCu.MaDC, SoLuong from ChiTietPhieuXuat_DungCu, DungCu where ChiTietPhieuXuat_DungCu.MaDC = DungCu.MaDC and MaPX = '" + MaPX + "' order by MaDC offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void update_soluong_dungcu(string MaPX, string MaDC)
        {
            OleDbCommand cmd = new OleDbCommand("update DungCu set SoLuongTon = SoLuongTon - (select SoLuong from ChiTietPhieuXuat_DungCu where ChiTietPhieuXuat_DungCu.MaDC = '" + MaDC + "' and MaPX = '" + MaPX + "') where MaDC = '" + MaDC + "'"); 
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }


        public static void update_phieuxuat(string MaPX, string manv)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuat set NVDuyet = '" + manv + "', TrangThai = N'Đã duyệt' where MaPX = '"+MaPX+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_thietbi(string MaPX, string mapl, string matb)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set SoLuongTon = SoLuongTon - (select SoLuong from ChiTietPhieuXuat_ThietBi where ChiTietPhieuXuat_ThietBi.MaTB = '"+matb+"' and MaPX = '" + MaPX + "' and MaPL = '" + mapl + "') where MaTB = '"+matb+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_soluong_hoachat(string MaPX, string MaHC)
        {
            OleDbCommand cmd = new OleDbCommand("update HoaChat set SoLuongTon = SoLuongTon - (select SoLuong from ChiTietPhieuXuat_HoaChat where ChiTietPhieuXuat_HoaChat.MaHC = '" + MaHC + "' and MaPX = '" + MaPX + "') where MaHC = '" + MaHC + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpx_dc(string MaPX, string madc, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuXuat_DungCu values(N'" + MaPX + "','" + madc + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpx_hc(string MaPX, string mahc, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuXuat_HoaChat values(N'" + MaPX + "','" + mahc + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ctpx_tb(string MaPX, string matb, string mapl, string soluong)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ChiTietPhieuXuat_ThietBi values(N'" + MaPX + "','" + matb + "', '" + mapl + "', '" + soluong + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_dc_check(string keyword, string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuat_DungCu where MaDC = '" + keyword + "' and MaPX ='" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_hc_check(string keyword, string MaPX)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuat_HoaChat where MaHC = '" + keyword + "' and MaPX ='" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tb_check(string keyword, string MaPX, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChiTietPhieuXuat_ThietBi where MaTB = '" + keyword + "' and MaPX ='" + MaPX + "' and MaPL ='"+mapl+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void sua_ctpx_hc(string soluong, string MaPX, string mahc)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuXuat_HoaChat set SoLuong = '" + soluong + "' where MaPX = '" + MaPX + "' and MaHC ='" + mahc + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpx_dc(string soluong, string MaPX, string madc)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuXuat_DungCu set SoLuong = '" + soluong + "' where MaPX = '" + MaPX + "' and MaDC ='" + madc + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ctpx_tb(string soluong, string MaPX, string matb, string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("update ChiTietPhieuXuat_ThietBi set SoLuong = '" + soluong + "' where MaPX = '" + MaPX + "' and MaTB ='" + matb + "' and MaPL = '"+mapl+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpx_hc(string MaPX, string MaHC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuat_HoaChat where MaPX = ? and MaHC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            cmd.Parameters.AddWithValue("@MaHC", MaHC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpx_dc(string MaPX, string MaDC)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuat_DungCu where MaPX = ? and MaDC = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            cmd.Parameters.AddWithValue("@MaDC", MaDC);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ctpx_tb(string MaPX, string MaTB, string MaPL)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ChiTietPhieuXuat_ThietBi where MaPX = ? and MaTB = ? and MaPL = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPX", MaPX);
            cmd.Parameters.AddWithValue("@MaTB", MaTB);
            cmd.Parameters.AddWithValue("@MaPL", MaPL);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_px(string manv, string madv)
        {
            OleDbCommand cmd = new OleDbCommand("insert into PhieuXuat (NgayLap, NVLap, MaDV, TrangThai) values (getdate(), '" + manv + "', '"+madv+"', N'Chưa gửi')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_phieuxuat_ngaylap(string MaPX, string ngaylap)
        {
            OleDbCommand cmd = new OleDbCommand("update PhieuXuat set NgayLap = '" + ngaylap + "' where MaPX = '" + MaPX + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
    }
}