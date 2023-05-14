using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.NhaSanXuat
{
    public partial class NhaSanXuatLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "1")
            {
                if (Request.QueryString["trang"] != null)
                    trang = Request.QueryString["trang"];
                if (!IsPostBack)
                {
                    layDSNSX();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string get_iptk()
        {
            return iptk.Text.Trim();
        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.NhaSanXuat.ds_nsx();
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
                dt = e_lab.NhaSanXuat.ds_nsx();
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



        private void layDSNSX()
        {
            DataTable dt = new DataTable();
            dt = e_lab.NhaSanXuat.ds_NhaSanXuat_pagination(getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_nsx.Text += @"
                <tr id='Line" + dt.Rows[i]["MaNSX"] + @"' class='table_row'>
            <td class='tb_mancc table_info'>" + dt.Rows[i]["MaNSX"] + @"</td>
            <td class='tb_tenncc table_info'>" + dt.Rows[i]["TenNSX"] + @"</td>
            <td class='tb_sdtncc table_info'>" + dt.Rows[i]["SDT"] + @"</td>
            <td class='tb_emailncc table_info'>" + dt.Rows[i]["Email"] + @"</td>
            <td class='tb_diachincc table_info'>" + dt.Rows[i]["DiaChi"] + @"</td>
            <td class='tb_thaotac table_info'>
                <a href='/Admin.aspx?modul=SuaNSX&mansx=" + dt.Rows[i]["MaNSX"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaNSX(" + dt.Rows[i]["MaNSX"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}