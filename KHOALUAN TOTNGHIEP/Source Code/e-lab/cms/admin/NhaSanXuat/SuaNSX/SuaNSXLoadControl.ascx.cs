using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaSanXuat.SuaNSX
{
    public partial class SuaNSXLoadControl : System.Web.UI.UserControl
    {
        string mansx = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "1")
            {
                if (Request.QueryString["mansx"] != null)
                    mansx = Request.QueryString["mansx"];
                DataTable dt = new DataTable();
                dt = e_lab.NhaSanXuat.ds_nsx_MaNSX(mansx);

                TenNSX_sua.Text = dt.Rows[0]["TenNSX"].ToString();
                SDT_NSX_sua.Text = dt.Rows[0]["SDT"].ToString();
                Email_NSX_sua.Text = dt.Rows[0]["Email"].ToString();
                DiaChiNSX_sua.Text = dt.Rows[0]["DiaChi"].ToString();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string getmansx()
        {
            return mansx;
        }

        protected void btn_suansx_Click(object sender, EventArgs e)
        {
            e_lab.NhaSanXuat.sua_nsx(mansx, TenNSX_sua.Text, SDT_NSX_sua.Text, Email_NSX_sua.Text, DiaChiNSX_sua.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

        private void resetInput()
        {
            TenNSX_sua.Text = SDT_NSX_sua.Text = Email_NSX_sua.Text = DiaChiNSX_sua.Text = "";
        }

        protected void btn_nhaplai_suansx_Click(object sender, EventArgs e)
        {
            resetInput();
        }
    }
}