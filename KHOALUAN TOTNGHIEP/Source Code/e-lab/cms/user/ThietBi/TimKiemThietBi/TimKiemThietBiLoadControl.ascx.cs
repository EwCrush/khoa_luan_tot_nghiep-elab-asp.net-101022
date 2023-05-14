using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.ThietBi.TimKiemThietBi
{
    public partial class TimKiemThietBiLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        string keyword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (Request.QueryString["keyword"] != null)
                keyword = Request.QueryString["keyword"];
            if (!IsPostBack)
            {
                layDSTB();
            }
        }

        protected string getkeyword()
        {
            return keyword;
        }

        protected string getmadv()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(Session["MaDonVi"].ToString());
            return dt.Rows[0]["TenDV"].ToString();
        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_thietbikhoa_search(Session["MaDonVi"].ToString(), keyword);
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
            dt = e_lab.VatTuKhoa.ds_thietbikhoa_search_pagination(Session["MaDonVi"].ToString(), keyword, getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_dc.Text += @"
                <tr id='Line" + dt.Rows[i]["MaTB"] + @"' class='table_row'>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["MaTB"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["TenThietBi"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["TenPL"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["NgayNhap"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["SoLuongTon"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["DVT"] + @"</td>
            <td class='tb_mi10 table_info'>
                <a href='/User.aspx?modul=ThongSo&matb=" + dt.Rows[i]["MaTB"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-eye' title='Thông số thiết bị'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}