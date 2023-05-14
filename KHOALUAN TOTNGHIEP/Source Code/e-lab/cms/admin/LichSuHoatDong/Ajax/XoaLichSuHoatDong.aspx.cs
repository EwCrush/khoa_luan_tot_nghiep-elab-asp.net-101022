using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.LichSuHoatDong.Ajax
{
    public partial class XoaLichSuHoatDong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaLSHD = "";
            if (Request.Params["MaLSHD"] != null)
                MaLSHD = Request.Params["MaLSHD"];




            e_lab.LichSuHoatDong.xoa_ls(MaLSHD);
            Response.Write("1");

        }
    }
}