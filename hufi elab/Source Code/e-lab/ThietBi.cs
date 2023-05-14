using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class ThietBi
    {
        public static void xoa_tb(string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ThietBi where MaTB = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaTB", MaTB);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable sosanhsoluong_tb(string matb)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where MaTB = '" + matb + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void xoa_ls(string MaLS)
        {
            OleDbCommand cmd = new OleDbCommand("delete from LichSuSuDungThietBi where MaLS = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaLS", MaLS);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ls(string madv, string mapl, string matb)
        {
            OleDbCommand cmd = new OleDbCommand("insert into LichSuSuDungThietBi (MaDV, MaPL, NgayNhan, MaTB) values ('" + madv + "', '" + mapl + "', getdate(), '" + matb + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void update_ls(string madv, string mapl, string matb, string ngaynhan)
        {
            OleDbCommand cmd = new OleDbCommand("update LichSuSuDungThietBi set NgayTra = getdate() where MaTB = '"+matb+"' and MaDV = '"+madv+"' and MaPL = '"+mapl+"' and NgayNhan = '"+ngaynhan+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_ts(string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ThongSoThietBi where MaTB = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaTB", MaTB);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void xoa_thongso(string MaTS)
        {
            OleDbCommand cmd = new OleDbCommand("delete from ThongSoThietBi where MaTS = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaTS", MaTS);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_TB(string TenThietBi, string MaNSX, string MaNCC, int SoLuongTon, string NgayBaoDuong, string DVT)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ThietBi values(N'" + TenThietBi + "', N'" + MaNSX + "', N'" + MaNCC + "', getdate() , 0, 0, " + SoLuongTon + ", N'" + DVT + "', '" + NgayBaoDuong + "', N'Bình thường')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);

        }

        public static void update_soluong()
        {
            OleDbCommand cmd2 = new OleDbCommand("update ThietBi set SoLuongXuat = (select sum(SoLuongTon) from ThietBiKhoa where ThietBi.MaTB = ThietBiKhoa.MaTB)");
            cmd2.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd2);
            OleDbCommand cmd3 = new OleDbCommand("update ThietBi set SoLuongXuat = 0 where SoLuongXuat IS NULL");
            cmd3.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd3);
            OleDbCommand cmd4 = new OleDbCommand("update ThietBi set SoLuongNhap = (SoLuongXuat+SoLuongTon)");
            cmd4.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd4);
        }

        public static DataTable ds_tb_dang_btbd()
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where NgayBaoDuong <= getdate() or TrangThai !=N'Bình thường'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }


        public static void sua_tb(string MaTB, string TenThietBi, string MaNSX, string MaNCC, int SoLuongTon, string NgayBaoDuong, string DVT)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set TenThietBi = '" + TenThietBi + "', MaNSX='" + MaNSX + "', MaNCC = '" + MaNCC + "', SoLuongTon = " + SoLuongTon + ", NgayBaoDuong = '" + NgayBaoDuong + "', DVT =N'" + DVT + "' where MaTB = '" + MaTB + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_ts(string mats, string ts)
        {
            OleDbCommand cmd = new OleDbCommand("update ThongSoThietBi set ThongSo = N'" + ts + "' where MaTS='" + mats + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_trangthai_baotri(string matb)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set TrangThai = N'Bảo trì' where MaTB ='" + matb + "'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_ts(string matb, string ts)
        {
            OleDbCommand cmd = new OleDbCommand("insert into ThongSoThietBi values (N'" + ts + "', '" + matb + "')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_tb()
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tb_matb(string matb)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where MaTB = '"+matb+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable check_trangthai(string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where MaTB='"+MaTB+"' and NgayBaoDuong > getdate()");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ts(string matb)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThongSoThietBi where MaTB = '"+matb+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ts_mats(string matb, string mats)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThongSoThietBi where MaTB = '" + matb + "' and MaTS = '"+mats+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tb_binhthuong()
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where TrangThai = N'Bình thường'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ts_pagination(string matb, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThongSoThietBi where MaTB = '" + matb + "' order by MaTS offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static void update_trangthai_btbd()
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set TrangThai = N'Bảo dưỡng' where NgayBaoDuong <= getdate() and TrangThai = N'Bình thường'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void hoantat_btbd(string matb)
        {
            OleDbCommand cmd = new OleDbCommand("update ThietBi set TrangThai = N'Bình thường', NgayBaoDuong = (select dateadd(month, 6, getdate())) where MaTB = '"+matb+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable moreinfo_tb(string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("select MaTB, TenNSX, TenNCC, NgayBaoDuong, TrangThai from ThietBi, NhaSanXuat, NhaCungCap where ThietBi.MaNSX = NhaSanXuat.MaNSX and ThietBi.MaNCC=NhaCungCap.MaNCC and MaTB ='"+MaTB+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable lichsusudung(string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("select * from LichSuSuDungThietBi where MaTB = '" + MaTB + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable lichsusudung_pagination(string MaTB, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaLS, TenDV, TenPL, NgayNhan, NgayTra from DonVi, PhongLab, LichSuSuDungThietBi where DonVi.MaDV = LichSuSuDungThietBi.MaDV and LichSuSuDungThietBi.MaPL = PhongLab.MaPL and MaTB = '" + MaTB + "' order by NgayNhan offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable moreinfo_tb_btbd(string MaTB)
        {
            OleDbCommand cmd = new OleDbCommand("select MaTB, NgayNhap, TenNSX, TenNCC, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from ThietBi, NhaSanXuat, NhaCungCap where ThietBi.MaNSX = NhaSanXuat.MaNSX and ThietBi.MaNCC=NhaCungCap.MaNCC and MaTB ='" + MaTB + "'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ThietBi_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaTB, TenThietBi, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from ThietBi order by MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ThietBi_dang_btbd_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaTB, TenThietBi, NgayBaoDuong, TrangThai from ThietBi  where NgayBaoDuong <= getdate() or TrangThai !=N'Bình thường' order by MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_tb_search(string keyword)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where TenThietBi like N'%" + keyword + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable tenthietbi(string matb)
        {
            OleDbCommand cmd = new OleDbCommand("select * from ThietBi where MaTB = '"+matb+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_ThietBi_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select MaTB, TenThietBi, NgayNhap, SoLuongNhap, SoLuongXuat, SoLuongTon, DVT from ThietBi where TenThietBi like N'%" + keyword + "%' order by MaTB offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}