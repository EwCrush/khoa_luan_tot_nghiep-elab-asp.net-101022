using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.Ajax
{
    public partial class XoaCTPXThietBi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPXK = "";
            string MaTB = "";
            string MaPL = "";
            if (Request.Params["MaPXK"] != null)
                MaPXK = Request.Params["MaPXK"];
            if (Request.Params["MaTB"] != null)
                MaTB = Request.Params["MaTB"];
            if (Request.Params["MaPL"] != null)
                MaPL = Request.Params["MaPL"];
            e_lab.PhieuXuatKhoa.xoa_ctpxk_tb(MaPXK, MaTB, MaPL);
            Response.Write("1");
        }
    }
}