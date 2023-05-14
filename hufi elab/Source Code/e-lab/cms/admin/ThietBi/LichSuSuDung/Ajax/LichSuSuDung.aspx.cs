using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.LichSuSuDung.Ajax
{
    public partial class LichSuSuDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaLS = "";
            if (Request.Params["MaLS"] != null)
                MaLS = Request.Params["MaLS"];

            //xoa thong so
            //xoa vat tu
            //xoa nha san xuat
            e_lab.ThietBi.xoa_ls(MaLS);

            Response.Write("1");
        }
    }
}