using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.DungCu.ThongTinThemDungCu
{
    public partial class ThongTinThemDungCuLoadControl : System.Web.UI.UserControl
    {
        string madc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["madc"] != null)
                madc = Request.QueryString["madc"];
            if (!IsPostBack)
            {
                layThongTinDungCu();
            }
        }

        protected string getmadc()
        {
            return madc;
        }

        private void layThongTinDungCu()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DungCu.moreinfo_dc(madc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb.Text += @"
                <tr class='table_row'>
            <td class='tb_mi50 table_info'>" + dt.Rows[i]["TenNSX"] + @"</td>
            <td class='tb_mi50 table_info'>" + dt.Rows[i]["TenNCC"] + @"</td>
        </tr>
";
            }
        }
    }
}