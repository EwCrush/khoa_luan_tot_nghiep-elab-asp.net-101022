using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap.CTPNThietBi
{
    public partial class CTPNThietBi : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        string mapx = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (Request.QueryString["mapx"] != null)
                mapx = Request.QueryString["mapx"];
            if (!IsPostBack)
            {
                layDS();
            }
        }

        protected string getmapx()
        {
            return mapx;
        }



        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.CTPX_tb(mapx);
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

        protected string getmodul()
        {
            int dangchoduyet = 0;
            string modul = "";
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.isDangDuyet(mapx);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dangchoduyet++;
            }
            if (dangchoduyet > 0)
            {
                modul = "PhieuNhapDangChoDuyet";
            }
            else
            {
                modul = "GuiPhieuNhap";
            }
            return modul;
        }

        private void layDS()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.CTPX_tb_pagination(mapx, getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb.Text += @"
                <tr id='Line" + dt.Rows[i]["MaTB"] + @"' class='table_row'>
            <td class='tb_mi30 table_info'>" + dt.Rows[i]["TenThietBi"] + @"</td>
            <td class='tb_mi40 table_info'>" + dt.Rows[i]["TenPL"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["SoLuong"] + @"</td>
            <td class='tb_mi10 table_info'>
                <a href='/User.aspx?modul=SuaCTPNThietBi&mapx=" + dt.Rows[i]["MaPX"] + @"&matb=" + dt.Rows[i]["MaTB"] + @"&mapl=" + dt.Rows[i]["MaPL"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaCTPNTB(" + dt.Rows[i]["MaPX"] + @", " + dt.Rows[i]["MaTB"] + @", " + dt.Rows[i]["MaPL"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}