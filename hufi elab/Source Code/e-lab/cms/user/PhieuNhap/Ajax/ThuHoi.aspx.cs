using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.Ajax
{
    public partial class ThuHoi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPX = "";
            if (Request.Params["MaPX"] != null)
                MaPX = Request.Params["MaPX"];

            e_lab.PhieuXuat.thuhoi_px(MaPX);
            Response.Write("1");
        }
    }
}