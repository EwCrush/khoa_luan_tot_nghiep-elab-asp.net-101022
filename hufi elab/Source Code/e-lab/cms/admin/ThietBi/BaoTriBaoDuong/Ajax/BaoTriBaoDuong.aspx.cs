using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.BaoTriBaoDuong.Ajax
{
    public partial class BaoTriBaoDuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaTB = "";
            if (Request.Params["MaTB"] != null)
                MaTB = Request.Params["MaTB"];

            e_lab.ThietBi.hoantat_btbd(MaTB);
            Response.Write("1");
        }
    }
}