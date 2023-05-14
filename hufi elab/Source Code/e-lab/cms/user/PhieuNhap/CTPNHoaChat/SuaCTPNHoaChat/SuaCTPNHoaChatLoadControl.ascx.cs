using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.CTPNHoaChat.SuaCTPNHoaChat
{
    public partial class SuaCTPNHoaChatLoadControl : System.Web.UI.UserControl
    {
        string mapx = "";
        string mahc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
            if (Request.QueryString["mahc"] != null)
                mahc = Request.QueryString["mahc"];
        }



        protected string getmapx()
        {
            return mapx;
        }

        protected string getmahc()
        {
            return mahc;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.PhieuXuat.sua_ctpx_hc(SoLuong.Text, mapx, mahc);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            SoLuong.Text = "";
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}