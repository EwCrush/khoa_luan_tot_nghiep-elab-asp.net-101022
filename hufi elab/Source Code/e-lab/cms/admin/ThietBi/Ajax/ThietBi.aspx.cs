using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.Ajax
{
    public partial class ThietBi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaTB = "";
            string SoLuongXuat="";
            if (Request.Params["MaTB"] != null)
                MaTB = Request.Params["MaTB"];
            if (Request.Params["SoLuongXuat"] != null)
                SoLuongXuat = Request.Params["SoLuongXuat"];

            if (SoLuongXuat == "0")
            {
                e_lab.ThietBi.xoa_ts(MaTB);
                e_lab.ThietBi.xoa_tb(MaTB);
                Response.Write("1");
            }
        }
    }
}