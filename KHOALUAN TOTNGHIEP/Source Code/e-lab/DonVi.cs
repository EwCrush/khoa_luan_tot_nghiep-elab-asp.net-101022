using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class DonVi
    {
        public static DataTable ds_donvi()
        {
            OleDbCommand cmd = new OleDbCommand("select * from DonVi");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable ds_chucvu()
        {
            OleDbCommand cmd = new OleDbCommand("select * from ChucVu where MaCV != 1");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }

        public static DataTable get_tendv(string madv)
        {
            OleDbCommand cmd = new OleDbCommand("select * from DonVi where MaDV = '"+madv+"'");
            cmd.CommandType = CommandType.Text;
            return SQLDatabase.GetData(cmd);
        }
    }
}