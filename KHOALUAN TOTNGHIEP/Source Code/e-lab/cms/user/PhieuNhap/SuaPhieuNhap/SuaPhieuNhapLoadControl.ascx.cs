using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.SuaPhieuNhap
{
    public partial class SuaPhieuNhapLoadControl : System.Web.UI.UserControl
    {
        string mapx = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
        }

        protected string getmapx()
        {
            return mapx;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ngaylap.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }

        protected Boolean isPreTime()
        {
            DateTime selectedTime = Convert.ToDateTime(ngaylap.Text);
            if (selectedTime > DateTime.Now)
                return false;
            else
                return true;
        }

        protected void CapNhat_Click(object sender, EventArgs e)
        {
            if (isPreTime() == true)
            {
                e_lab.PhieuXuat.update_phieuxuat_ngaylap(mapx, ngaylap.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                ngaylap.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid time')", true);
            }
        }

        protected string getmodul()
        {
            int dangchoduyet = 0;
            string modul = "";
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.isDangDuyet(mapx);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dangchoduyet++;
            }
            if (dangchoduyet > 0)
            {
                modul = "PhieuNhapDangChoDuyet";
            }
            else
            {
                modul = "GuiPhieuNhap";
            }
            return modul;
        }


        protected void NhapLai_Click(object sender, EventArgs e)
        {
            ngaylap.Text = "";
        }
    }
}