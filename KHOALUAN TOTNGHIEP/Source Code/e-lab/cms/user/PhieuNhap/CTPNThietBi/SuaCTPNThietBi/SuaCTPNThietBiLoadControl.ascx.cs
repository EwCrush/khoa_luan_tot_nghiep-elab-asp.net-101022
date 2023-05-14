using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.CTPNThietBi.SuaCTPNThietBi
{
    public partial class SuaCTPNThietBiLoadControl : System.Web.UI.UserControl
    {
        string mapx = "";
        string matb = "";
        string mapl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
            if (Request.QueryString["mapl"] != null)
                mapl = Request.QueryString["mapl"];
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];
        }



        protected string getmapx()
        {
            return mapx;
        }

        protected string getmapl()
        {
            return mapl;
        }

        protected string getmatb()
        {
            return matb;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.PhieuXuat.sua_ctpx_tb(SoLuong.Text, mapx, matb, mapl);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            SoLuong.Text = "";
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}