using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.Ajax
{
    public partial class PhieuXuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaPXK = "";
            if (Request.Params["MaPXK"] != null)
                MaPXK = Request.Params["MaPXK"];

            e_lab.PhieuXuatKhoa.xoa_ctpxk_thietbi_frompn(MaPXK);
            e_lab.PhieuXuatKhoa.xoa_ctpxk_dungcu_frompn(MaPXK);
            e_lab.PhieuXuatKhoa.xoa_ctpxk_hoachat_frompn(MaPXK);
            e_lab.PhieuXuatKhoa.xoa_pxk(MaPXK);
            e_lab.LichSuHoatDong.xoaphieuxuatkhoa(Session["MaNhanVien"].ToString(), MaPXK);
            Response.Write("1");
        }
    }
}