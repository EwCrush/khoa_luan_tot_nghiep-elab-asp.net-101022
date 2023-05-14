using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.ThongSo.SuaThongSo
{
    public partial class SuaThongSoLoadControl : System.Web.UI.UserControl
    {
        string matb = "";
        string mats = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];
            if (Request.QueryString["mats"] != null)
                mats = Request.QueryString["mats"];
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_ts_mats(matb, mats);

            ThongSo.Text = dt.Rows[0]["ThongSo"].ToString();

        }

        protected string getmats() {
            return mats;
        }

        protected string getmatb()
        {
            return matb;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.ThietBi.sua_ts(mats, ThongSo.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            ThongSo.Text = "";
        }
    }
}