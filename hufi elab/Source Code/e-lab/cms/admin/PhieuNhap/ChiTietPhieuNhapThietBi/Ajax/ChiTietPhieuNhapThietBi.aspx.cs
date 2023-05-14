using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapThietBi.Ajax
{
    public partial class ChiTietPhieuNhapThietBi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPN = "";
            string MaTB = "";
            if (Request.Params["MaPN"] != null)
                MaPN = Request.Params["MaPN"];
            if (Request.Params["MaTB"] != null)
                MaTB = Request.Params["MaTB"];
            e_lab.PhieuNhap.xoa_ctpn_tb(MaPN, MaTB);
            Response.Write("1");
        }
    }
}