using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.NhanVien
{
    public partial class NhanVienLoadControl : System.Web.UI.UserControl
    {
        string trang = "";
        int trangcuoi = 0;
        int trangtruoc = 0;
        int trangtiep = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaChucVu"] != null && Session["MaChucVu"].ToString() == "2")
            {
                if (Request.QueryString["trang"] != null)
                    trang = Request.QueryString["trang"];
                if (!IsPostBack)
                {
                    LoadDS_nhanvien();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string getmadv() {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(Session["MaDonVi"].ToString());
            return dt.Rows[0]["TenDV"].ToString();
        }

        protected int getlast()
        {
            int tonghang = 0;
            DataTable dt = new DataTable();
            dt = e_lab.NhanVien.ds_nv_khoa(Session["MaDonVi"].ToString());
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
                dt = e_lab.NhanVien.ds_nv_khoa(Session["MaDonVi"].ToString());
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

        protected string get_iptk()
        {
            return iptk.Text.Trim();
        }

        private void LoadDS_nhanvien()
        {
            DataTable dt = new DataTable();
            dt = e_lab.NhanVien.ds_nv_pagination_khoa(Session["MaDonVi"].ToString(), getoffset());
            //grid_phonglab.DataSource = dt;
            //grid_phonglab.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_nv.Text += @"
                <tr id='Line" + dt.Rows[i]["MaNV"] + @"' class='table_row'>
            <td class='tb_manv table_info'>" + dt.Rows[i]["MaNV"] + @"</td>
            <td class='tb_tennv table_info'>" + dt.Rows[i]["TenNV"] + @"</td>
            <td class='tb_gioitinh table_info'>" + dt.Rows[i]["GioiTinh"] + @"</td>
            <td class='tb_ngaysinh table_info'>" + dt.Rows[i]["NgaySinh"] + @"</td>
            <td class='tb_sdtnv table_info'>" + dt.Rows[i]["SDT"] + @"</td>
            <td class='tb_diachinv table_info'>" + dt.Rows[i]["DiaChi"] + @"</td>
            <td class='tb_donvinv table_info'>" + dt.Rows[i]["TenDV"] + @"</td>
            <td class='tb_chucvunv table_info'>" + dt.Rows[i]["TenCV"] + @"</td>
            <td class='tb_thaotacnv table_info'>
                <a href='/Admin.aspx?modul=SuaNV&manv=" + dt.Rows[i]["MaNV"] + @"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaNV(" + dt.Rows[i]["MaNV"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }
    }
}