using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.SuaPhieuXuat
{
    public partial class SuaPhieuXuatLoadControl : System.Web.UI.UserControl
    {
        string mapxk = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
        }

        protected string getmapxk()
        {
            return mapxk;
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
                e_lab.PhieuXuatKhoa.update_phieuxuatkhoa(mapxk, ngaylap.Text);
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