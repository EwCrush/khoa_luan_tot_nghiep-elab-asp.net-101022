using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapHoaChat.ThemChiTietPhieuNhapHoaChat
{
    public partial class ThemChiTietPhieuNhapLoadControl : System.Web.UI.UserControl
    {
        string mapn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapn"] != null)
                mapn = Request.QueryString["mapn"];
            if (!IsPostBack)
                layDSHoaChat();
        }

        private void layDSHoaChat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.HoaChat.ds_hc();
            ddl_hoachat.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_hoachat.Items.Add(new ListItem(dt.Rows[i]["TenHC"].ToString(), dt.Rows[i]["MaHC"].ToString()));
            }
        }

        protected Boolean daTonTai()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuNhap.ds_hc_check(ddl_hoachat.SelectedValue, mapn);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        protected string getmapn() {
            return mapn;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            if (daTonTai() == true)
            {
                e_lab.PhieuNhap.them_ctpn_hc(mapn, ddl_hoachat.SelectedValue, SoLuong.Text);
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