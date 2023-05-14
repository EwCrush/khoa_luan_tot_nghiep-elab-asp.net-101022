using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.ThietBi.ThongSo
{
    public partial class ThongSoLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        string matb = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];
            if (!IsPostBack)
            {
                layDSTB();
            }
        }

        protected string getmatb()
        {
            return matb;
        }


        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_ts(matb);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tonghang++;
            }
            if (tonghang % 5 != 0)
            {
                return trangcuoi = tonghang / 5 + 1;
            }
            else
                return trangcuoi = tonghang / 5;
        }


        protected int getpre()
        {
            int sotrang;
            int.TryParse(trang, out sotrang);
            if (sotrang == 1)
                return trangtruoc = getlast();
            else
                return trangtruoc = sotrang - 1;
        }

        protected int getnext()
        {
            int sotrang;
            int.TryParse(trang, out sotrang);
            if (sotrang == getlast())
                return trangtiep = 1;
            else
                return trangtiep = sotrang + 1;
        }



        protected string getcurrent()
        {
            //int sotrang = int.Parse(trang);
            return trang;
        }

        protected int getoffset()
        {
            string tranghientai = "";
            int offset = 0;
            if (Request.QueryString["trang"] != null)
                tranghientai = Request.QueryString["trang"];
            int.TryParse(tranghientai, out offset);

            return (offset - 1) * 5;
        }

        private void layDSTB()
        {
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_ts_pagination(matb, getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_ts.Text += @"
                <tr id='Line" + dt.Rows[i]["MaTS"] + @"' class='table_row'>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["MaTS"] + @"</td>
            <td class='tb_mi80 table_info'>" + dt.Rows[i]["ThongSo"] + @"</td>
        </tr>
";
            }
        }
    }
}