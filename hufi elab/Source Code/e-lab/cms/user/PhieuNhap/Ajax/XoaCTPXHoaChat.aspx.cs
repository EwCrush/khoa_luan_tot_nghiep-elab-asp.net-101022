using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.Ajax
{
    public partial class XoaCTPXHoaChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPX = "";
            string MaHC = "";
            if (Request.Params["MaPX"] != null)
                MaPX = Request.Params["MaPX"];
            if (Request.Params["MaHC"] != null)
                MaHC = Request.Params["MaHC"];
            e_lab.PhieuXuat.xoa_ctpx_hc(MaPX, MaHC);
            Response.Write("1");
        }
    }
}