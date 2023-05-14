using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.Ajax
{
    public partial class PhieuNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPN = "";
            if (Request.Params["MaPN"] != null)
                MaPN = Request.Params["MaPN"];

            e_lab.PhieuNhap.xoa_ctpn_thietbi_frompn(MaPN);
            e_lab.PhieuNhap.xoa_ctpn_dungcu_frompn(MaPN);
            e_lab.PhieuNhap.xoa_ctpn_hoachat_frompn(MaPN);
            e_lab.PhieuNhap.xoa_pn(MaPN);
            e_lab.LichSuHoatDong.xoaphieunhap(Session["MaNhanVien"].ToString(), MaPN);
            Response.Write("1");
        }
    }
}