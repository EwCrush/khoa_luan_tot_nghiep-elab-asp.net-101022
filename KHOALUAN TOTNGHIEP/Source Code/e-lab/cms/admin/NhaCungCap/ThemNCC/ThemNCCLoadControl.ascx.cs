using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaCungCap.ThemNCC
{
    public partial class ThemNCCLoadControl : System.Web.UI.UserControl
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

        protected void btn_themncc_Click(object sender, EventArgs e)
        {
            e_lab.NhaCungCap.them_ncc(TenNCC_them.Text, SDT_NCC_them.Text, Email_NCC_them.Text, DiaChiNCC_them.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        protected void btn_nhaplai_themncc_Click(object sender, EventArgs e)
        {
            resetInput();
        }


        private void resetInput()
        {
            TenNCC_them.Text = SDT_NCC_them.Text = Email_NCC_them.Text = DiaChiNCC_them.Text = "";
        }

    }
}