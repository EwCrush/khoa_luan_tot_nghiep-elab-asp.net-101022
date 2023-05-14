using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.DoiMatKhau
{
    public partial class DoiMatKhauLoadControl : System.Web.UI.UserControl
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected Boolean isCurrentPassword()
        {
            if (MatKhauHienTai.Text == Session["Password"].ToString())
                return true;
            else
                return false;
        }

        protected Boolean isSameNewPassword()
        {
            if (MatKhauMoi.Text == NhapLaiMatKhau.Text)
                return true;
            else
                return false;
        }

        protected Boolean isSameOldPassword()
        {
            if (MatKhauHienTai.Text != MatKhauMoi.Text)
                return true;
            else
                return false;
        }

        protected void btn_themnsx_Click(object sender, EventArgs e)
        {
            if (isCurrentPassword() == true)
            {
                if (isSameNewPassword() == true)
                {
                    if (isSameOldPassword() == true)
                    {
                        e_lab.NhanVien.sua_taikhoan(Session["MaNhanVien"].ToString(), Session["Username"].ToString(), MatKhauMoi.Text);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You entered the old password')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('New password and re-entered password do not match')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The current password entered is incorrect')", true);
            }
        }

        protected void btn_nhaplai_themnsx_Click(object sender, EventArgs e)
        {
            MatKhauMoi.Text = NhapLaiMatKhau.Text = MatKhauHienTai.Text = "";
        }

        
        
    }
}