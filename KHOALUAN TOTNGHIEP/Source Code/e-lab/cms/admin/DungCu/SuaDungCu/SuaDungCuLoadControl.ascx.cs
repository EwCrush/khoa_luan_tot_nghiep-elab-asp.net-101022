using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.DungCu.SuaDungCu
{
    public partial class SuaDungCuLoadControl : System.Web.UI.UserControl
    {
        string madc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["madc"] != null)
                madc = Request.QueryString["madc"];

            DataTable dt = new DataTable();
            dt = e_lab.DungCu.ds_dc_madc(madc);

            TenDC.Text = dt.Rows[0]["TenDC"].ToString();
            SoLuongTon.Text = dt.Rows[0]["SoLuongTon"].ToString();
            DVT.Text = dt.Rows[0]["DVT"].ToString();

            if (!IsPostBack)
            {

                LayDS_nsx();
                LayDS_ncc();
            }
        }

        protected string getmadc() {
            return madc;
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

        protected void btn_them_Click(object sender, EventArgs e)
        {
            int soluongton;
            int.TryParse(SoLuongTon.Text, out soluongton);
            e_lab.DungCu.sua_dc(madc, TenDC.Text, ddl_nsx.SelectedValue, ddl_ncc.SelectedValue, soluongton, DVT.Text);
            e_lab.DungCu.update_soluong();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            resetInput();
        }

        private void resetInput()
        {
            TenDC.Text = SoLuongTon.Text = "";
        }
    }
}