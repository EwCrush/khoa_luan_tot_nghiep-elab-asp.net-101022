using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhanVien.SuaNV
{
    public partial class SuaNVLoadControl : System.Web.UI.UserControl
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

                tennv.Text = dt.Rows[0]["TenNV"].ToString();
                ngaysinh.Text = dt.Rows[0]["NgaySinh"].ToString();
                sdtnv.Text = dt.Rows[0]["SDT"].ToString();
                DiaChi.Text = dt.Rows[0]["DiaChi"].ToString();

                if (!IsPostBack)
                {
                    ddl_gioitinh.Items.Add("Nam".ToString());
                    ddl_gioitinh.Items.Add("Nữ".ToString());
                    LayDS_DonVi();
                    LayDS_ChucVu();
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

        private void LayDS_DonVi()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.ds_donvi();
            ddl_donvi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_donvi.Items.Add(new ListItem(dt.Rows[i]["TenDV"].ToString(), dt.Rows[i]["MaDV"].ToString()));
            }
        }

        private void LayDS_ChucVu()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.ds_chucvu();
            ddl_chucvu.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_chucvu.Items.Add(new ListItem(dt.Rows[i]["TenCV"].ToString(), dt.Rows[i]["MaCV"].ToString()));
            }
        }

        protected Boolean isAlreadyExist()
        {
            if ((ddl_donvi.SelectedValue == "1") || (ddl_donvi.SelectedValue.ToString() != "1" && ddl_chucvu.SelectedValue.ToString() == "3"))
                return false;
            else
            {
                DataTable dt = new DataTable();
                dt = e_lab.NhanVien.ds_nv_check_madv_macv(ddl_donvi.SelectedValue);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        protected Boolean checkChucVuDonVi()
        {
            if (ddl_donvi.SelectedValue.ToString() == "1" && ddl_chucvu.SelectedValue.ToString() == "2")
                return false;
            else
                return true;
        }

        protected void CapNhat_Click(object sender, EventArgs e)
        {
            if (checkChucVuDonVi() == true && isAlreadyExist() == false)
            {
                e_lab.NhanVien.sua_nv_trungtam(manv, tennv.Text, ddl_gioitinh.Text, ngaysinh.Text, sdtnv.Text, DiaChi.Text, ddl_donvi.SelectedValue, ddl_chucvu.SelectedValue);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                resetInput();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please check the data you entered')", true);
            }
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