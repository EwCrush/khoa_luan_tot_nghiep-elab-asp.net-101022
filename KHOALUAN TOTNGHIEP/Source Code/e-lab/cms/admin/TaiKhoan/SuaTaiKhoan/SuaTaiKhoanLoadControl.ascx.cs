using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.TaiKhoan.SuaTaiKhoan
{
    public partial class SuaTaiKhoanLoadControl : System.Web.UI.UserControl
    {
        string manv = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "1")
            {
                if (Request.QueryString["manv"] != null)
                    manv = Request.QueryString["manv"];

                DataTable dt = new DataTable();
                dt = e_lab.NhanVien.ds_nv_for_update(manv);

                taikhoan.Text = dt.Rows[0]["TaiKhoan"].ToString();
                matkhau.Text = dt.Rows[0]["MatKhau"].ToString();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btn_capnhat_Click(object sender, EventArgs e)
        {
            e_lab.NhanVien.sua_taikhoan(manv, taikhoan.Text, matkhau.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

        protected string getmanv() {
            return manv;
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            taikhoan.Text = matkhau.Text = "";
        }
    }
}