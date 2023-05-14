using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.LichSuHoatDong
{
    public partial class LichSuHoatDongLoadControl : System.Web.UI.UserControl
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
                    LoadDS_taikhoan();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.LichSuHoatDong.ds_lshd();
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
                dt = e_lab.LichSuHoatDong.ds_lshd();
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


        private void LoadDS_taikhoan()
        {
            DataTable dt = new DataTable();
            dt = e_lab.LichSuHoatDong.ds_lshd_pagination(getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ds_lichsu.Text += @"
                <tr id='Line" + dt.Rows[i]["MaLSHD"] + @"' class='table_row'>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["TenNV"] + @"</td>
            <td class='tb_mi50 table_info'>" + dt.Rows[i]["TrangThai"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["ThoiGian"] + @"</td>
            <td class='tb_mi10 table_info'>
                <a href='javascript:XoaLS(" + dt.Rows[i]["MaLSHD"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
                
            </td>
        </tr>
";
            }
        }
    }
}