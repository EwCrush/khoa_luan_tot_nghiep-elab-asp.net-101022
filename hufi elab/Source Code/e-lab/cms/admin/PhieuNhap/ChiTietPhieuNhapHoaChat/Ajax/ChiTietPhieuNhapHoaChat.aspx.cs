using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapHoaChat.Ajax
{
    public partial class ChiTietPhieuNhapHoaChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPN = "";
            string MaHC = "";
            if (Request.Params["MaPN"] != null)
                MaPN = Request.Params["MaPN"];
            if (Request.Params["MaHC"] != null)
                MaHC = Request.Params["MaHC"];
            e_lab.PhieuNhap.xoa_ctpn_hc(MaPN, MaHC);
            Response.Write("1");
        }
    }
}