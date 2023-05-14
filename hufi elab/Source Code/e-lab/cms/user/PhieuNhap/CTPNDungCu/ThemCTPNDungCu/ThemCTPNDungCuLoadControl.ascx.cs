using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.CTPNDungCu.ThemCTPNDungCu
{
    public partial class ThemCTPNDungCuLoadControl : System.Web.UI.UserControl
    {
        string mapx = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
            if (!IsPostBack)
                layDSHoaChat();
        }

        private void layDSHoaChat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DungCu.ds_dc();
            ddl_dungcu.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_dungcu.Items.Add(new ListItem(dt.Rows[i]["TenDC"].ToString(), dt.Rows[i]["MaDC"].ToString()));
            }
        }

        protected string getmapx()
        {
            return mapx;
        }

        protected Boolean daTonTai()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.ds_dc_check(ddl_dungcu.SelectedValue, mapx);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            if (daTonTai() == true)
            {
                e_lab.PhieuXuat.them_ctpx_dc(mapx, ddl_dungcu.SelectedValue, SoLuong.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                SoLuong.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data already exists')", true);
            }
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}