using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuNhap.Ajax
{
    public partial class XacNhanPhieuNhap : System.Web.UI.Page
    {
        string MaPN = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["MaPN"] != null)
                MaPN = Request.Params["MaPN"];
            updateSoLuong();

            
        }

        private void updateSoLuong()
        {
            e_lab.PhieuNhap.update_daxacnhan(MaPN);
            //e_lab.PhieuNhap.update_soluong_dungcu(MaPN);
            //e_lab.PhieuNhap.update_soluong_hoachat(MaPN);
            //e_lab.PhieuNhap.update_soluong_thietbi(MaPN);
            duyetDungCu();
            duyetHoaChat();
            duyetThietBi();
            //e_lab.DungCu.update_soluong();
            //e_lab.HoaChat.update_soluong();
            //e_lab.ThietBi.update_soluong();
            e_lab.LichSuHoatDong.duyetphieunhap(Session["MaNhanVien"].ToString(), MaPN);
            Response.Write("1");
        }

        private void duyetDungCu()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuNhap.CTPN_dc(MaPN);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                e_lab.PhieuNhap.update_soluong_dungcu(MaPN, dt.Rows[i]["MaDC"].ToString());
                e_lab.DungCu.update_soluong();
            }
        }

        private void duyetThietBi()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuNhap.CTPN_tb(MaPN);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                e_lab.PhieuNhap.update_soluong_thietbi(MaPN, dt.Rows[i]["MaTB"].ToString());
                e_lab.DungCu.update_soluong();
            }
        }

        private void duyetHoaChat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuNhap.CTPN_hc(MaPN);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                e_lab.PhieuNhap.update_soluong_hoachat(MaPN, dt.Rows[i]["MaHC"].ToString());
                e_lab.DungCu.update_soluong();
            }
        }
    }
}