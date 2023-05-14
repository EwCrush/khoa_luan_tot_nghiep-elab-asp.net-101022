using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi
{
    public partial class ThietBiLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        int btbd = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (!IsPostBack)
            {
                layDSTB();
            }
        }

        protected string get_iptk()
        {
            return iptk.Text.Trim();
        }

        protected int dsbtbd()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb_dang_btbd();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tonghang++;
            }
            return btbd = tonghang;
            

        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb();
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
            dt = e_lab.ThietBi.ds_ThietBi_pagination(getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb.Text += @"
                <tr id='Line" + dt.Rows[i]["MaTB"] + @"' class='table_row'>
            <td class='tb_col_10_percent table_info'>" + dt.Rows[i]["MaTB"] + @"</td>
            <td class='tb_col_20_percent table_info'>" + dt.Rows[i]["TenThietBi"] + @"</td>
            <td class='tb_col_15_percent table_info'>" + dt.Rows[i]["NgayNhap"] + @"</td>
            <td class='tb_col_10_percent table_info'>" + dt.Rows[i]["SoLuongNhap"] + @"</td>
            <td class='tb_col_10_percent table_info'>" + dt.Rows[i]["SoLuongXuat"] + @"</td>
            <td class='tb_col_10_percent table_info'>" + dt.Rows[i]["SoLuongTon"] + @"</td>
            <td class='tb_col_10_percent table_info'>" + dt.Rows[i]["DVT"] + @"</td>
            <td class='tb_col_15_percent table_info'>
                <a href='/Admin.aspx?modul=ThongTinThemThietBi&matb=" + dt.Rows[i]["MaTB"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-circle-info' title='Thông tin thêm'></i>
                </a>
                <a href='/Admin.aspx?modul=LichSuSuDung&matb=" + dt.Rows[i]["MaTB"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-clock-rotate-left' title='Lịch sử sử dụng'></i>
                </a>
                <a href='/Admin.aspx?modul=SuaThietBi&matb=" + dt.Rows[i]["MaTB"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaTB(" + dt.Rows[i]["MaTB"] + @", " + dt.Rows[i]["SoLuongXuat"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}