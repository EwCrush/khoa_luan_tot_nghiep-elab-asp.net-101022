using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhanVien.Ajax
{
    public partial class NhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            xoaNhanVien();
        }

        private void xoaNhanVien()
        {
            string MaNV = "";
            if (Request.Params["MaNV"] != null)
                MaNV = Request.Params["MaNV"];

            e_lab.NhanVien.xoa_nv(MaNV);
            Response.Write("1");
        }
    }
}