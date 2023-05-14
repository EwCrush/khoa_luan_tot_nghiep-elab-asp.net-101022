using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.CTPNDungCu.SuaCTPNDungCu
{
    public partial class SuaCTPNDungCuLoadControl : System.Web.UI.UserControl
    {
        string mapx = "";
        string madc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
            if (Request.QueryString["madc"] != null)
                madc = Request.QueryString["madc"];
        }


        protected string getmapx()
        {
            return mapx;
        }

        protected string getmadc() {
            return madc;
        }

        //protected Boolean daTonTai()
        //{
        //    DataTable dt = new DataTable();
        //    dt = e_lab.PhieuXuat.ds_dc_check(ddl_dungcu.SelectedValue, mapx);
        //    if (dt.Rows.Count > 0)
        //        return false;
        //    else
        //        return true;
        //}

        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.PhieuXuat.sua_ctpx_dc(SoLuong.Text, mapx, madc);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            SoLuong.Text = "";
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}