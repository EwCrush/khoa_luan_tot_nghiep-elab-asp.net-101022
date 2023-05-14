using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapDungCu.SuaChiTietPhieuNhapDungCu
{
    public partial class SuaChiTietPhieuNhapDungCuLoadControl : System.Web.UI.UserControl
    {
        string mapn = "";
        string madc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapn"] != null)
                mapn = Request.QueryString["mapn"];
            if (Request.QueryString["madc"] != null)
                madc = Request.QueryString["madc"];
        }



        protected string getmadc()
        {
            return madc;
        }

        protected string getmapn() {
            return mapn;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.PhieuNhap.sua_ctpn_dc(SoLuong.Text, mapn, madc);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            SoLuong.Text = "";
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}