using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.ThongSo.Ajax
{
    public partial class ThongSo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaTS = "";
            if (Request.Params["MaTS"] != null)
                MaTS = Request.Params["MaTS"];

            e_lab.ThietBi.xoa_thongso(MaTS);
            Response.Write("1");
        }
    }
}