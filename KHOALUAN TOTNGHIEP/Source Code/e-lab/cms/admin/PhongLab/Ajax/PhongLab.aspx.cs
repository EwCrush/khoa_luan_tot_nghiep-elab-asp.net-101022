using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhongLab.Ajax
{
    public partial class PhongLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XoaPhongLab();
        }

        private void XoaPhongLab()
        {
            string MaPL = "";
            if (Request.Params["MaPL"] != null)
                MaPL = Request.Params["MaPL"];

            e_lab.PhongLab.xoa_phonglab(MaPL);
            Response.Write("1");

        }
    }
}