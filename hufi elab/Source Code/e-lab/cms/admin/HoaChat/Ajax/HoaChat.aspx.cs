using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.HoaChat.Ajax
{
    public partial class HoaChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xoaHoaChat();
        }

        private void xoaHoaChat()
        {
            string MaHC = "";
            if (Request.Params["MaHC"] != null)
                MaHC = Request.Params["MaHC"];
            string SoLuongXuat = "";
            if (Request.Params["SoLuongXuat"] != null)
                SoLuongXuat = Request.Params["SoLuongXuat"];

            if (SoLuongXuat == "0")
            {

                e_lab.HoaChat.xoa_hc(MaHC);
                Response.Write("1");
            }
        }
    }
}