using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuXuat.PhieuXuatDangChoDuyet.Ajax
{
    public partial class TuChoi : System.Web.UI.Page
    {
        string MaPX = "";
        string MaDV = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["MaPX"] != null)
                MaPX = Request.Params["MaPX"];
            if (Request.Params["MaDV"] != null)
                MaDV = Request.Params["MaDV"];
            e_lab.PhieuXuat.update_tuchoiduyet(MaPX);
            e_lab.LichSuHoatDong.tuchoi_duyetphieuxuat(Session["MaNhanVien"].ToString(), MaPX, gettendv());
            Response.Write("1");
        }

        private string gettendv()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(MaDV);
            return dt.Rows[0]["TenDV"].ToString();
        }
    }
}