using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaSanXuat.Ajax
{
    public partial class NhaSanXuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xoaNSX();
        }

        private void xoaNSX()
        {
            string MaNSX = "";
            if (Request.Params["MaNSX"] != null)
                MaNSX = Request.Params["MaNSX"];

            //xoa thong so
            //xoa vat tu
            //xoa nha san xuat
            e_lab.NhaSanXuat.xoa_nsx(MaNSX);

            Response.Write("1");
        }
    }
}