using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace e_lab
{
    public class SQLDatabase
    {
        //lấy chuỗi kết nối
        private static string _connectionString = string.Empty;
        public static string ConnectionString
        {
            get
            {
                if (_connectionString.Equals(""))
                {
                    _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        // mở chuỗi kết nối
        public static OleDbConnection GetConnection()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = ConnectionString;
            conn.Open();
            return conn;
        }

        //thực hiện truy vấn ko cần trả về kết quả (delete,update,inser)
        public static void ExecuteNoneQuery(OleDbCommand cmd)
        {
            if (cmd.Connection != null)
            {
                cmd.ExecuteNonQuery();
            }
            else
            {
                OleDbConnection conn = GetConnection();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
        }

        //phương thức lấy dữ liệu trả về dataTable
        public static DataTable GetData(OleDbCommand cmd)
        {
            if (cmd.Connection != null)
            {
                using (DataSet ds = new DataSet())
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            else
            {
                using (OleDbConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    using (DataSet ds = new DataSet())
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }

        //phương thức lấy dữ liệu trả về tất cả các dataTable
        public static DataSet GetData_OverDataset(OleDbCommand cmd)
        {
            if (cmd.Connection != null)
            {
                using (DataSet ds = new DataSet())
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            else
            {
                using (OleDbConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    using (DataSet ds = new DataSet())
                    {
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }
    }
}