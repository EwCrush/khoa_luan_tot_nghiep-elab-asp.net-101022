using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapThietBi.SuaChiTietPhieuNhapThietBi
{
    public partial class SuaChiTietPhieuNhapThietBiLoadControl : System.Web.UI.UserControl
    {
        string mapn = "";
        string matb = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapn"] != null)
                mapn = Request.QueryString["mapn"];
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];
        }



        protected string getmapn()
        {
            return mapn;
        }

        protected string getmatb()
        {
            return matb;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.PhieuNhap.sua_ctpn_tb(SoLuong.Text, mapn, matb);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            SoLuong.Text = "";
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}