using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapHoaChat.SuaChiTietPhieuNhapHoaChat
{
    public partial class SuaChiTietPhieuNhapHoaChatLoadControl : System.Web.UI.UserControl
    {
        string mapn = "";
        string mahc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapn"] != null)
                mapn = Request.QueryString["mapn"];
            if (Request.QueryString["mahc"] != null)
                mahc = Request.QueryString["mahc"];
        }

        

        protected string getmapn()
        {
            return mapn;
        }

        protected string getmahc()
        {
            return mahc;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.PhieuNhap.sua_ctpn_hc(SoLuong.Text, mapn, mahc);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            SoLuong.Text = "";
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}