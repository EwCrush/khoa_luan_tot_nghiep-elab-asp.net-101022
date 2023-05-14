using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhongLab.SuaPL
{
    public partial class SuaPLLoadControl : System.Web.UI.UserControl
    {
        string mapl = "";

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "1")
            {
                if (Request.QueryString["mapl"] != null)
                    mapl = Request.QueryString["mapl"];
                DataTable dt = new DataTable();
                dt = e_lab.PhongLab.ds_phonglab_mapl(mapl);

                TenPL_Sua.Text = dt.Rows[0]["TenPL"].ToString();
                DiaChiPhongLab_Sua.Text = dt.Rows[0]["DiaChi"].ToString();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string getten()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhongLab.ds_phonglab_mapl(mapl);
            return dt.Rows[0]["TenPL"].ToString();
        }

        protected string getmapl()
        {
            return mapl;
        }

        protected string DanhDau(string tenModul)
        {
            string s = "";

            string modul = ""; //Biến lưu giá trị của querstring modul
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];
            if (tenModul == modul)
                s = "current";

            return s;
        }
 

        protected void SuaPL_Click(object sender, EventArgs e)
        {
            e_lab.PhongLab.sua_phonglab(mapl, TenPL_Sua.Text, DiaChiPhongLab_Sua.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

        protected void NhapLaiPL_Click(object sender, EventArgs e)
        {
            resetInput();
        }

        private void resetInput()
        {
            //MaPL_Sua.Text = "";
            TenPL_Sua.Text = "";
            DiaChiPhongLab_Sua.Text = "";
        }
    }
}