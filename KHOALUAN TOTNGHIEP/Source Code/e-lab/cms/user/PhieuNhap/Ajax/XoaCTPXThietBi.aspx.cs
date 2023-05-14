using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.Ajax
{
    public partial class XoaCTPXThietBi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPX = "";
            string MaTB = "";
            string MaPL = "";
            if (Request.Params["MaPX"] != null)
                MaPX = Request.Params["MaPX"];
            if (Request.Params["MaPL"] != null)
                MaPL = Request.Params["MaPL"];
            if (Request.Params["MaTB"] != null)
                MaTB = Request.Params["MaTB"];
            e_lab.PhieuXuat.xoa_ctpx_tb(MaPX, MaTB, MaPL);
            Response.Write("1");
        }
    }
}