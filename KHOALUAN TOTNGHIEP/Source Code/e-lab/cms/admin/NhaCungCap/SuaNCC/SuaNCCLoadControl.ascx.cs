using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaCungCap.SuaNCC
{
    public partial class SuaNCCLoadControl : System.Web.UI.UserControl
    {

        string mancc="";
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "1")
            {
                if (Request.QueryString["mancc"] != null)
                    mancc = Request.QueryString["mancc"];

                DataTable dt = new DataTable();
                dt = e_lab.NhaCungCap.ds_ncc_mancc(mancc);

                TenNCC_sua.Text = dt.Rows[0]["TenNCC"].ToString();
                SDT_NCC_sua.Text = dt.Rows[0]["SDT"].ToString();
                Email_NCC_sua.Text = dt.Rows[0]["Email"].ToString();
                DiaChiNCC_sua.Text = dt.Rows[0]["DiaChi"].ToString();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string getmancc()
        {
            return mancc;
        }

        protected void btn_suancc_Click(object sender, EventArgs e)
        {
            e_lab.NhaCungCap.sua_ncc(mancc, TenNCC_sua.Text, SDT_NCC_sua.Text, Email_NCC_sua.Text, DiaChiNCC_sua.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

        private void resetInput()
        {
            TenNCC_sua.Text = SDT_NCC_sua.Text = Email_NCC_sua.Text = DiaChiNCC_sua.Text = "";
        }

        protected void btn_nhaplai_suancc_Click(object sender, EventArgs e)
        {
            resetInput();
        }
    }
}