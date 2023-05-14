using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace e_lab.cms.admin.PhongLab
{
    public partial class PhongLabLoadControl : System.Web.UI.UserControl
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
                    layDSPhongLab();
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
            dt = e_lab.PhongLab.ds_phonglab();
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
                dt = e_lab.PhongLab.ds_phonglab();
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

        private void layDSPhongLab()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhongLab.ds_phonglab_pagination(getoffset());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltr_ds_phonglab.Text += @"
                <tr id='Line" + dt.Rows[i]["MaPL"] + @"' class='table_row'>
            <td class='tb_mapl table_info'>"+dt.Rows[i]["MaPL"]+@"</td>
            <td class='tb_tenpl table_info'>"+dt.Rows[i]["TenPL"]+@"</td>
            <td class='tb_diachi table_info'>"+dt.Rows[i]["DiaChi"]+@"</td>
            <td class='tb_thaotac table_info'>
                <a href='/Admin.aspx?modul=SuaPL&mapl="+dt.Rows[i]["MaPL"]+@"' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
                </a>
                <a href='javascript:XoaPhongLab(" + dt.Rows[i]["MaPL"] + @")' class='tb_thaotac_link'>
                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
                </a>
            </td>
        </tr>
";
            }
        }

        protected void tk_phonglab(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
        }


//        private void layDSPhongLab_search()
//        {
//            DataTable dt = new DataTable();
//            dt = e_lab.PhongLab.ds_phonglab_search(iptk.Text);
//            //grid_phonglab.DataSource = dt;
//            //grid_phonglab.DataBind();
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                ltr_ds_phonglab.Text += @"
//                <tr class='table_phonglab_row'>
//            <td class='tb_stt table_phonglab_info'>"+(i+1)+@"</td>
//            <td class='tb_mapl table_phonglab_info'>"+dt.Rows[i]["MaPL"]+@"</td>
//            <td class='tb_tenpl table_phonglab_info'>"+dt.Rows[i]["TenPL"]+@"</td>
//            <td class='tb_diachi table_phonglab_info'>"+dt.Rows[i]["DiaChi"]+@"</td>
//            <td class='tb_thaotac table_phonglab_info'>
//                <a href='/Admin.aspx?modul=SuaPL&mapl="+dt.Rows[i]["MaPL"]+@"' class='tb_thaotac_link'>
//                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-pen' title='Sửa'></i>
//                </a>
//                <a href='javascript:XoaPhongLab(" + dt.Rows[i]["MaPL"] + @")' class='tb_thaotac_link'>
//                 <i class='tb_thaotac_link_icon fa-sharp fa-solid fa-trash' title='Xóa'></i>
//                </a>
//            </td>
//        </tr>
//";
//            }
//        }

        //protected string AnList(string tenModul)
        //{
        //    string s = "";

        //    string modul = ""; //Biến lưu giá trị của querstring modul
        //    if (Request.QueryString["modul"] != null)
        //        modul = Request.QueryString["modul"];
        //    if (tenModul == modul)
        //        s = "anlist";

        //    return s;
        //}
    }
}