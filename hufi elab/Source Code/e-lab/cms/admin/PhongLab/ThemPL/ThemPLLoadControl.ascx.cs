using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhongLab.ThemPL
{
    public partial class ThemPLLoadControl : System.Web.UI.UserControl
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

        protected string prepage()
        {
            string strURLOld = HttpContext.Current.Request.UrlReferrer.ToString();
            return strURLOld;
        }

        protected void ThemPL_Click(object sender, EventArgs e)
        {
            //if ((e_lab.PhongLab.ds_phonglab_check(MaPL.Text)==false))
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "confirm('Mã phòng lab này đã được sử dụng, bạn muốn update chứ?')", true);
            e_lab.PhongLab.them_phonglab(TenPL.Text, DiaChiPhongLab.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        private void resetInput()
        {
            
            TenPL.Text = "";
            DiaChiPhongLab.Text = "";
        }

        protected void NhapLai_Click(object sender, EventArgs e)
        {
            resetInput();
        }
    }
}