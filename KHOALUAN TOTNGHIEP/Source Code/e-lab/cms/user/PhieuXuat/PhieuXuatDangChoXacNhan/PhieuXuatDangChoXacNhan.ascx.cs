using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.PhieuXuatDangChoXacNhan
{
    public partial class PhieuXuatDangChoXacNhan : System.Web.UI.UserControl
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


        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.ds_PhieuXuat_dangxacnhan(Session["MaDonVi"].ToString());
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
            dt = e_lab.PhieuXuatKhoa.ds_PhieuXuatKhoa_dcxn_pagination(Session["MaDonVi"].ToString(), getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_tb.Text += @"
                <tr id='Line" + dt.Rows[i]["MaPXK"] + @"' class='table_row'>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["MaPXK"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["NgayLap"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["TenNV"] + @"</td>
            <td class='tb_mi15 table_info'>" + dt.Rows[i]["TrangThai"] + @"</td>
            <td class='tb_mi20 table_info'>
                <a href='/User.aspx?modul=CTPXHoaChat&mapxk=" + dt.Rows[i]["MaPXK"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-flask' title='Chi tiết phiếu nhập hóa chất'></i>
                </a>
                <a href='/User.aspx?modul=CTPXThietBi&mapxk=" + dt.Rows[i]["MaPXK"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-microscope' title='Chi tiết phiếu nhập thiết bị'></i>
                </a>    
                <a href='/User.aspx?modul=CTPXDungCu&mapxk=" + dt.Rows[i]["MaPXK"] + @"&trang=1' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-vial' title='Chi tiết phiếu nhập dụng cụ'></i>
                </a>
            </td>
            <td class='tb_mi20 table_info'>
                <a href='javascript:XacNhanPXK(" + dt.Rows[i]["MaPXK"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-solid fa-check' title='Xác nhận'></i>
                </a>
                <a href='/User.aspx?modul=SuaPhieuXuat&mapxk=" + dt.Rows[i]["MaPXK"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaPXK(" + dt.Rows[i]["MaPXK"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}