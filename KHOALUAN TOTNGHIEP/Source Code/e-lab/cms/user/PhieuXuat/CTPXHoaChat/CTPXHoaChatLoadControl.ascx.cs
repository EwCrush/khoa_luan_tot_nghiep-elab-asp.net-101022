using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXHoaChat
{
    public partial class CTPXHoaChatLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        string mapxk = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["trang"] != null)
                trang = Request.QueryString["trang"];
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
            if (!IsPostBack)
            {
                layDS();
            }
        }



        protected string getmapxk()
        {
            return mapxk;
        }


        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_hc(mapxk);
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

        protected string getmodul()
        {
            int dangchoduyet = 0;
            string modul = "";
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.isDangDuyet(mapxk);
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

        private void layDS()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_hc_pagination(mapxk, getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb.Text += @"
                <tr id='Line" + dt.Rows[i]["MaHC"] + @"' class='table_row'>
            <td class='tb_mi60 table_info'>" + dt.Rows[i]["TenHC"] + @"</td>
            <td class='tb_mi25 table_info'>" + dt.Rows[i]["SoLuong"] + @"</td>
            <td class='tb_mi15 table_info'>
                <a href='/User.aspx?modul=SuaCTPXHoaChat&mapxk=" + dt.Rows[i]["MaPXK"] + @"&mahc=" + dt.Rows[i]["MaHC"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaCTPXHC(" + dt.Rows[i]["MaPXK"] + @", " + dt.Rows[i]["MaHC"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}