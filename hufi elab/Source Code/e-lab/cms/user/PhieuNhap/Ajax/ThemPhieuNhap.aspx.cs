using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.Ajax
{
    public partial class ThemPhieuNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            e_lab.PhieuXuat.them_px(Session["MaNhanVien"].ToString(), Session["MaDonVi"].ToString());
            Response.Write("1");
        }
    }
}