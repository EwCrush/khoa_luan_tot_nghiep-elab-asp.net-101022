using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.ThongSo.ThemThongSo
{
    public partial class ThemThongSoLoadControl : System.Web.UI.UserControl
    {
        string matb = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];
        }

        protected string getmatb() {
            return matb;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.ThietBi.them_ts(matb, ThongSo.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            ThongSo.Text = "";
        }
    }
}