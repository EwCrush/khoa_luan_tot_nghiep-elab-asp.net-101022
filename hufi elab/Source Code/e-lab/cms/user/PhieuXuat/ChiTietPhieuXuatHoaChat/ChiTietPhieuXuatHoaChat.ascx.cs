﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.ChiTietPhieuXuatHoaChat
{
    public partial class ChiTietPhieuXuatHoaChat : System.Web.UI.UserControl
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

        //protected string getmodul()
        //{
        //    int daduyet = 0;
        //    int chuaduyet = 0;
        //    string modul = "";
        //    DataTable dt = new DataTable();
        //    dt = e_lab.PhieuXuat.isDaDuyet(mapx);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        daduyet++;
        //    }
        //    if (daduyet > 0)
        //    {
        //        modul = "PhieuNhap";
        //    }
        //    else
        //    {
        //        DataTable dt2 = new DataTable();
        //        dt2 = e_lab.PhieuXuat.isDaDuyet(mapx);
        //        for (int i = 0; i < dt2.Rows.Count; i++)
        //        {
        //            chuaduyet++;
        //        }
        //        if (chuaduyet > 0)
        //            modul = "PhieuNhapDangChoDuyet";
        //        else
        //        {
        //            modul = "GuiPhieuNhap";
        //        }
        //    }
        //    return modul;
        //}


        protected string getmapx()
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
            <td class='tb_mi75 table_info'>" + dt.Rows[i]["TenHC"] + @"</td>
            <td class='tb_mi25 table_info'>" + dt.Rows[i]["SoLuong"] + @"</td>
        </tr>
";
            }
        }
    }
}