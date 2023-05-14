using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btdn_Click(object sender, EventArgs e)
        {
            DataTable dt = e_lab.NhanVien.check_login(txtusername.Text.Trim(), txtpassword.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                string donvi = dt.Rows[0]["MaDV"].ToString();
                string tennv = dt.Rows[0]["TenNV"].ToString();
                string manv = dt.Rows[0]["MaNV"].ToString();
                string chucvu = dt.Rows[0]["MaCV"].ToString();
                Session["TenNhanVien"] = tennv;
                Session["MaNhanVien"] = manv;
                Session["MaDonVi"] = donvi;
                Session["MaChucVu"] = chucvu;
                Session["Username"] = txtusername.Text;
                Session["Password"] = txtpassword.Text;
                if (donvi == "1")
                {
                    Response.Redirect("/Admin.aspx");
                }
                else
                    Response.Redirect("/User.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thông tin đăng nhập sai hoặc không tồn tại!')", true);
            }
        }
    }
}