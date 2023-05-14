using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.SuaPhieuNhap
{
    public partial class SuaPhieuNhapLoadControl : System.Web.UI.UserControl
    {
        string mapn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapn"] != null)
                mapn = Request.QueryString["mapn"];
        }

        protected string getmapn() {
            return mapn;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ngaylap.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
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
                e_lab.PhieuNhap.update_phieunhap(mapn, ngaylap.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                ngaylap.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid time')", true);
            }
        }


        protected void NhapLai_Click(object sender, EventArgs e)
        {
            ngaylap.Text = "";
        }
    }
}