using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.BaoTriBaoDuong
{
    public partial class BaoTriBaoDuongLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];

            e_lab.ThietBi.update_trangthai_btbd();
            if (!IsPostBack)
            {
                layDSTB();
            }
        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb_dang_btbd();
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
            dt = e_lab.ThietBi.ds_ThietBi_dang_btbd_pagination(getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb_btbd.Text += @"
                <tr id='Line" + dt.Rows[i]["MaTB"] + @"' class='table_row'>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["MaTB"] + @"</td>
            <td class='tb_mi30 table_info'>" + dt.Rows[i]["TenThietBi"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["NgayBaoDuong"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["TrangThai"] + @"</td>
            <td class='tb_mi15 table_info'>
                <a href='/Admin.aspx?modul=ThongTinThemThietBiBTBD&matb=" + dt.Rows[i]["MaTB"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-circle-info' title='Thông tin thêm'></i>
                </a>
                <a href='javascript:HoanTat(" + dt.Rows[i]["MaTB"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-circle-check' title='Hoàn tất bảo trì bảo dưỡng'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}