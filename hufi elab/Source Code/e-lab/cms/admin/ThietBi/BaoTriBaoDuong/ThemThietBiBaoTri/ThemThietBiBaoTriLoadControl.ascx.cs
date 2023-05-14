using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.BaoTriBaoDuong.ThemThietBiBaoTri
{
    public partial class ThemThietBiBaoTriLoadControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LayDS_tb_binhthuong();
            }
        }

        private void LayDS_tb_binhthuong()
        {
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb_binhthuong();
            ddl_tb.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_tb.Items.Add(new ListItem(dt.Rows[i]["TenThietBi"].ToString(), dt.Rows[i]["MaTB"].ToString()));
            }
        }


        protected void btn_them_Click(object sender, EventArgs e)
        {
            e_lab.ThietBi.sua_trangthai_baotri(ddl_tb.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }

    }
}