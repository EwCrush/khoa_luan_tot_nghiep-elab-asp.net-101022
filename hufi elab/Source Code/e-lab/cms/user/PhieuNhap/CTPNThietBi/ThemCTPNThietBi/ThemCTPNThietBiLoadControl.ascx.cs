using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.CTPNThietBi.ThemCTPNThietBi
{
    public partial class ThemCTPNThietBiLoadControl : System.Web.UI.UserControl
    {
        string mapx = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
            if (!IsPostBack)
            {
                layDSTB();
                layDSPL();
            }
        }

        private void layDSTB()
        {
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb_binhthuong();
            ddl_thietbi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_thietbi.Items.Add(new ListItem(dt.Rows[i]["TenThietBi"].ToString(), dt.Rows[i]["MaTB"].ToString()));
            }
        }

        private void layDSPL()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhongLab.ds_phonglab();
            ddl_phonglab.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_phonglab.Items.Add(new ListItem(dt.Rows[i]["TenPL"].ToString(), dt.Rows[i]["MaPL"].ToString()));
            }
        }

        protected Boolean daTonTai()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.ds_tb_check(ddl_thietbi.SelectedValue, mapx, ddl_phonglab.SelectedValue);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        protected string getmapx()
        {
            return mapx;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            if (daTonTai() == true)
            {
                e_lab.PhieuXuat.them_ctpx_tb(mapx, ddl_thietbi.SelectedValue, ddl_phonglab.SelectedValue, SoLuong.Text);
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