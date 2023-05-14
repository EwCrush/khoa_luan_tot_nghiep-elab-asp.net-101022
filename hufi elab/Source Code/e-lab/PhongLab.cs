using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class PhongLab
    {
        public static void xoa_phonglab(string MaPL)
        {
            OleDbCommand cmd = new OleDbCommand("delete from PhongLab where MaPL = ?");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MaPL", MaPL);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void them_phonglab(string TenPL, string DiaChi)
        {
            OleDbCommand cmd = new OleDbCommand("insert into PhongLab values(N'" + TenPL + "', N'"+DiaChi+"')");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static void sua_phonglab(string MaPL, string TenPL, string DiaChi)
        {
            OleDbCommand cmd = new OleDbCommand("update PhongLab set TenPL = N'"+TenPL+"', DiaChi = N'"+DiaChi+"' where MaPL = '"+MaPL+"'");
            cmd.CommandType = CommandType.Text;
            SQLDatabase.ExecuteNoneQuery(cmd);
        }

        public static DataTable ds_phonglab()
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhongLab");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_phonglab_mapl(string mapl)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhongLab where MaPL = '"+mapl+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_phonglab_pagination(int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhongLab order by MaPL offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_phonglab_search_pagination(string keyword, int offset)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhongLab where TenPL like N'%" + keyword + "%' order by MaPL offset " + offset + " rows fetch next 5 rows only");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_phonglab_search(string tenpl)
        {
            OleDbCommand cmd = new OleDbCommand("select * from PhongLab where TenPL like N'%" + tenpl + "%'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        //public static bool ds_phonglab_check(string mapl)
        //{
        //    OleDbCommand cmd = new OleDbCommand("select count(*) from PhongLab where MaPL = N'" + mapl + "'");
        //    cmd.CommandType = CommandType.Text;
            
        //    if (kq > 0)
        //        return false;
        //    else return true;
        //}
    
    }
}