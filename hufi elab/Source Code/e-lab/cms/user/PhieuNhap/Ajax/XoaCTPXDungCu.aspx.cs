using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.Ajax
{
    public partial class XoaCTPNDungCu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPX = "";
            string MaDC = "";
            if (Request.Params["MaPX"] != null)
                MaPX = Request.Params["MaPX"];
            if (Request.Params["MaDC"] != null)
                MaDC = Request.Params["MaDC"];
            e_lab.PhieuXuat.xoa_ctpx_dc(MaPX, MaDC);
            Response.Write("1");
        }
    }
}