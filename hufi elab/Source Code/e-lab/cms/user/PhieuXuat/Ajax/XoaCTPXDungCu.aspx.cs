using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.Ajax
{
    public partial class XoaCTPXDungCu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPXK = "";
            string MaDC = "";
            if (Request.Params["MaPXK"] != null)
                MaPXK = Request.Params["MaPXK"];
            if (Request.Params["MaDC"] != null)
                MaDC = Request.Params["MaDC"];
            e_lab.PhieuXuatKhoa.xoa_ctpxk_dc(MaPXK, MaDC);
            Response.Write("1");
        }
    }
}