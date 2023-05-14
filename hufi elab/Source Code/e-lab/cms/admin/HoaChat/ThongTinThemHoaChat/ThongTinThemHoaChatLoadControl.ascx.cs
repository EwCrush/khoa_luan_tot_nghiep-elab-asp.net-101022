using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.HoaChat.ThongTinThemHoaChat
{
    public partial class ThongTinThemHoaChatLoadControl : System.Web.UI.UserControl
    {
        string mahc = "";
        string trang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (Request.QueryString["mahc"] != null)
                mahc = Request.QueryString["mahc"];
            if (!IsPostBack)
            {
                laythongtinhoachat();
            }
        }

        protected string getmahc()
        {
            return mahc;
        }

        private void laythongtinhoachat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.HoaChat.moreinfo_hc(mahc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_hc.Text += @"
                <tr class='table_row'>
            <td class='tb_mi25 table_info'>" + dt.Rows[i]["TenNSX"] + @"</td>
            <td class='tb_mi25 table_info'>" + dt.Rows[i]["TenNCC"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["HanSuDung"] + @"</td>
            <td class='tb_mi35 table_info'>" + dt.Rows[i]["GhiChu"] + @"</td>
        </tr>
";
            }
        }
    }
}