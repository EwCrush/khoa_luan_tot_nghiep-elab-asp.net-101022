using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.Ajax
{
    public partial class XoaCTPXHoaChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPXK = "";
            string MaHC = "";
            if (Request.Params["MaPXK"] != null)
                MaPXK = Request.Params["MaPXK"];
            if (Request.Params["MaHC"] != null)
                MaHC = Request.Params["MaHC"];
            e_lab.PhieuXuatKhoa.xoa_ctpxk_hc(MaPXK, MaHC);
            Response.Write("1");
        }
    }
}