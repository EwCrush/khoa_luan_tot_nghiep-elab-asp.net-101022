using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaSanXuat.ThemNSX
{
    public partial class ThemNSXLoadControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "1")
            {
                
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btn_themnsx_Click(object sender, EventArgs e)
        {
            e_lab.NhaSanXuat.them_nsx(TenNSX_them.Text, SDT_NSX_them.Text, Email_NSX_them.Text, DiaChiNSX_them.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        private void resetInput()
        {
            TenNSX_them.Text = SDT_NSX_them.Text = Email_NSX_them.Text = DiaChiNSX_them.Text = "";
        }

        protected void btn_nhaplai_themnsx_Click(object sender, EventArgs e)
        {
            resetInput();
        }
    }
}