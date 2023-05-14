using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapDungCu.Ajax
{
    public partial class ChiTietPhieuNhapDungCu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPN = "";
            string MaDC = "";
            if (Request.Params["MaPN"] != null)
                MaPN = Request.Params["MaPN"];
            if (Request.Params["MaDC"] != null)
                MaDC = Request.Params["MaDC"];
            e_lab.PhieuNhap.xoa_ctpn_dc(MaPN, MaDC);
            Response.Write("1");
        }
    }
}