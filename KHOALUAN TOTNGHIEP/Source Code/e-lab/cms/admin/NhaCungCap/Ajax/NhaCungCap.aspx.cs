using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaCungCap.Ajax
{
    public partial class NhaCungCap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaNCC = "";
            if (Request.Params["MaNCC"] != null)
                MaNCC = Request.Params["MaNCC"];

            //xoa thong so
            
            //xoa vat tu
            
            //xoa nha cung cap
            e_lab.NhaCungCap.xoa_ncc(MaNCC);
            Response.Write("1");
        }
    }
}