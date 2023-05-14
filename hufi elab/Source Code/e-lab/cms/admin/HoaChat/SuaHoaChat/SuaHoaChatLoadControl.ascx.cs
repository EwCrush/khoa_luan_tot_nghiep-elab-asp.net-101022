using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.HoaChat.SuaHoaChat
{
    public partial class SuaHoaChatLoadControl : System.Web.UI.UserControl
    {
        string mahc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mahc"] != null)
                mahc = Request.QueryString["mahc"];

            DataTable dt = new DataTable();
            dt = e_lab.HoaChat.ds_hc_mahc(mahc);

            TenHC.Text = dt.Rows[0]["TenHC"].ToString();
            CTHH.Text = dt.Rows[0]["CTHH"].ToString();
            SoLuongTon.Text = dt.Rows[0]["SoLuongTon"].ToString();
            HSD.Text = dt.Rows[0]["HanSuDung"].ToString();
            GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            DVT.Text = dt.Rows[0]["DVT"].ToString();

            if (!IsPostBack)
            {
                LayDS_nsx();
                LayDS_ncc();
            }
        }

        protected string getmahc() {
            return mahc;
        }

        private void LayDS_ncc()
        {
            DataTable dt = new DataTable();
            dt = e_lab.NhaCungCap.ds_ncc();
            ddl_ncc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_ncc.Items.Add(new ListItem(dt.Rows[i]["TenNCC"].ToString(), dt.Rows[i]["MaNCC"].ToString()));
            }
        }

        private void LayDS_nsx()
        {
            DataTable dt = new DataTable();
            dt = e_lab.NhaSanXuat.ds_nsx();
            ddl_nsx.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_nsx.Items.Add(new ListItem(dt.Rows[i]["TenNSX"].ToString(), dt.Rows[i]["MaNSX"].ToString()));
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            HSD.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }

        protected void btn_themnsx_Click(object sender, EventArgs e)
        {
            int soluongton;
            int.TryParse(SoLuongTon.Text, out soluongton);
            e_lab.HoaChat.sua_hc(mahc, TenHC.Text, CTHH.Text, ddl_nsx.SelectedValue, ddl_ncc.SelectedValue, soluongton, HSD.Text, GhiChu.Text, DVT.Text);
            e_lab.HoaChat.update_soluong();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        protected void btn_nhaplai_themnsx_Click(object sender, EventArgs e)
        {
            resetInput();
        }

        private void resetInput()
        {
            TenHC.Text = CTHH.Text = SoLuongTon.Text = HSD.Text = GhiChu.Text = "";
        }
    }
}