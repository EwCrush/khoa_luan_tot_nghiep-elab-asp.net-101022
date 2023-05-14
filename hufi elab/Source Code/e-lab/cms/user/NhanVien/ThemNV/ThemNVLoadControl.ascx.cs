using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.NhanVien.ThemNV
{
    public partial class ThemNVLoadControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "2")
            {
                if (!IsPostBack)
                {
                    ddl_gioitinh.Items.Add("Nam".ToString());
                    ddl_gioitinh.Items.Add("Nữ".ToString());
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }  
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ngaysinh.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }

        protected void ThemLoaiVT_Click(object sender, EventArgs e)
        {
            e_lab.NhanVien.them_nv(tennv.Text, ddl_gioitinh.Text, ngaysinh.Text, sdtnv.Text, DiaChi.Text, Session["MaDonVi"].ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        private void resetInput()
        {
            tennv.Text = ngaysinh.Text = sdtnv.Text = DiaChi.Text = "";
        }

        protected void NhapLai_LoaiVT_Click(object sender, EventArgs e)
        {
            resetInput();
        }


    }
}