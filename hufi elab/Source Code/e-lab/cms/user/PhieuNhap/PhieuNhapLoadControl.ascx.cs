using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuNhap
{
    public partial class PhieuNhapLoadControl : System.Web.UI.UserControl
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
                layDS();
            }
        }


        protected int dsChoDuyet()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.ds_PhieuXuat_dangchoduyet_khoa(Session["MaDonVi"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tonghang++;
            }
            return btbd = tonghang;


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
            dt = e_lab.PhieuXuat.ds_PhieuXuat_khoa(Session["MaDonVi"].ToString());
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

        private void layDS()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.ds_PhieuXuat_pagination_khoa(Session["MaDonVi"].ToString(), getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb.Text += @"
                <tr id='Line" + dt.Rows[i]["MaPX"] + @"' class='table_row'>
            <td class='tb_mi10 table_info'>" + dt.Rows[i]["MaPX"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["NgayLap"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["TenNV"] + @"</td>
            <td class='tb_mi20 table_info'>" + dt.Rows[i]["TenDV"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["TrangThai"] + @"</td>
            <td class='tb_mi15 table_info'>
                <a href='/User.aspx?modul=ChiTietPhieuNhapHoaChat&mapx=" + dt.Rows[i]["MaPX"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-flask' title='Chi tiết phiếu nhập hóa chất'></i>
                </a>
                <a href='/User.aspx?modul=ChiTietPhieuNhapThietBi&mapx=" + dt.Rows[i]["MaPX"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-microscope' title='Chi tiết phiếu nhập thiết bị'></i>
                </a>    
                <a href='/User.aspx?modul=ChiTietPhieuNhapDungCu&mapx=" + dt.Rows[i]["MaPX"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-vial' title='Chi tiết phiếu nhập dụng cụ'></i>
                </a>
            </td>
            <td class='tb_mi10 table_info'>
                <a href='javascript:XoaPX(" + dt.Rows[i]["MaPX"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}