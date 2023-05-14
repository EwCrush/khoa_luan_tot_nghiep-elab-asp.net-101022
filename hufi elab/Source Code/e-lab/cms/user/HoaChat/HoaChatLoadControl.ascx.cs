using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.HoaChat
{
    public partial class HoaChatLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        int hethsd = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (!IsPostBack)
            {
                layDSHC();
            }
        }

        protected string get_iptk()
        {
            return iptk.Text.Trim();
        }

        protected string getmadv()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(Session["MaDonVi"].ToString());
            return dt.Rows[0]["TenDV"].ToString();
        }


        protected int dshethsd()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_hc_het_date(Session["MaDonVi"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tonghang++;
            }
            return hethsd = tonghang;


        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_hoachatkhoa(Session["MaDonVi"].ToString());
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

        protected string isOnePage()
        {
            int tonghang = 0;
            string s = "";
            if (getlast() == 1)
                s = "one-page";
            else
            {
                DataTable dt = new DataTable();
                dt = e_lab.VatTuKhoa.ds_hoachatkhoa(Session["MaDonVi"].ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tonghang++;
                }
                if (tonghang == 0)
                    s = "one-page";
            }
            return s;
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

        private void layDSHC()
        {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_hoachatkhoa_pagination(Session["MaDonVi"].ToString(), getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_hc.Text += @"
                <tr id='Line" + dt.Rows[i]["MaHC"] + @"' class='table_row'>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["MaHC"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["TenHC"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["CTHH"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["NgayNhap"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["SoLuongTon"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["DVT"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["HanSuDung"] + @"</td>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["GhiChu"] + @"</td>
            <td class='tb_mi10 table_info'>
                <a href='/User.aspx?modul=SuaHoaChat&mahc=" + dt.Rows[i]["MaHC"] + @"' class='tb_thaotac_link'>
                 <i class='tb_mi10 fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}