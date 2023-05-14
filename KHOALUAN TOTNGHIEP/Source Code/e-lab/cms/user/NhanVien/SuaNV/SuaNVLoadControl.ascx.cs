using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.NhanVien.SuaNV
{
    public partial class SuaNVLoadControl : System.Web.UI.UserControl
    {
        string manv = "";
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "2")
            {
                if (Request.QueryString["manv"] != null)
                    manv = Request.QueryString["manv"];

                DataTable dt = new DataTable();
                dt = e_lab.NhanVien.ds_nv_for_update(manv);

                tennv.Text = dt.Rows[0]["TenNV"].ToString();
                ngaysinh.Text = dt.Rows[0]["NgaySinh"].ToString();
                sdtnv.Text = dt.Rows[0]["SDT"].ToString();
                DiaChi.Text = dt.Rows[0]["DiaChi"].ToString();

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

        protected string getmanv()
        {
            return manv;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ngaysinh.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }

        protected void CapNhat_Click(object sender, EventArgs e)
        {
            e_lab.NhanVien.sua_nv(manv, tennv.Text, ddl_gioitinh.Text, ngaysinh.Text, sdtnv.Text, DiaChi.Text, Session["MaDonVi"].ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        private void resetInput()
        {
            tennv.Text = ngaysinh.Text = sdtnv.Text = DiaChi.Text = "";
        }

        protected void NhapLai_Click(object sender, EventArgs e)
        {
            resetInput();
        }
    }
}