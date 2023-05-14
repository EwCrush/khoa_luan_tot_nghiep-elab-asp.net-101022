using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.DungCu.ThemDungCu
{
    public partial class ThemDungCuLoadLoadControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LayDS_nsx();
                LayDS_ncc();
            }
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
            e_lab.DungCu.them_DC(TenDC.Text, ddl_nsx.SelectedValue, ddl_ncc.SelectedValue, soluongton, DVT.Text);
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