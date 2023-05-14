using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.DungCu.Ajax
{
    public partial class DungCu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaDC = "";
            string SoLuongXuat = "";
            if (Request.Params["MaDC"] != null)
                MaDC = Request.Params["MaDC"];
            if (Request.Params["SoLuongXuat"] != null)
                SoLuongXuat = Request.Params["SoLuongXuat"];

            if (SoLuongXuat == "0")
            {
                e_lab.DungCu.xoa_dc(MaDC);
                Response.Write("1");
            }
        }
    }
}