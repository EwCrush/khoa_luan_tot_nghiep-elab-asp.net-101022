using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaDonVi"] != null && Session["MaDonVi"].ToString() != "1")
            {

            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string getname()
        {
            return Session["TenNhanVien"].ToString();
        }

        protected string getdonvi() {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(Session["MaDonVi"].ToString());
            return dt.Rows[0]["TenDV"].ToString();
        }

        protected string DanhDau(string tenModul)
        {
            string s = "";

            string modul = ""; //Biến lưu giá trị của querstring modul
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];
            if (tenModul == modul)
                s = "current";

            return s;
        }

        protected string isNhanVien()
        {
            string s = "";
            if (Session["MaChucVu"].ToString() == "3")
                s = "userNhanVien";
            return s;
        }
    }
}