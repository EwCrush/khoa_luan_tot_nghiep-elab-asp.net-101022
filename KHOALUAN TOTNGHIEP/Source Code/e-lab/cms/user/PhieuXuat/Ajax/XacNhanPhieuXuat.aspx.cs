using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.Ajax
{
    public partial class XacNhanPhieuXuat : System.Web.UI.Page
    {
        string MaPXK = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["MaPXK"] != null)
                MaPXK = Request.Params["MaPXK"];

            duyetPX_DC();
            //if (duyetPX_DC() == true)
            //{
            //    Response.Write("1");
            //}
            //else
            //    Response.Write("2");



            duyetPX_HC();
            duyetPX_TB();
            if (duyetPX_DC() == true && duyetPX_HC() == true && duyetPX_TB() == true)
            {

                themVaoDungCu();
                themVaoThietBi();
                themVaoHoaChat();
                updatePhieuXuat();
                themvaoLichSuHoatDong();
                Response.Write("1");
            }
            else
                Response.Write("2");
        }

        private void updatePhieuXuat()
        {
            e_lab.PhieuXuatKhoa.update_PhieuXuatKhoa(MaPXK);
        }

        private void themvaoLichSuHoatDong()
        {
            e_lab.LichSuHoatDong.duyetphieuxuatkhoa(Session["MaNhanVien"].ToString(), MaPXK, gettendv());
        }

        private string gettendv()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(Session["MaDonVi"].ToString());
            return dt.Rows[0]["TenDV"].ToString();
        }

        private void themVaoThietBi()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_tb(MaPXK);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.ds_thietbikhoa_matb(Session["MaDonVi"].ToString(), dt.Rows[i]["MaTB"].ToString(), dt.Rows[i]["MaPL"].ToString());
                string ngaynhan = dt2.Rows[0]["NgayNhap"].ToString();
                e_lab.VatTuKhoa.update_soluong_thietbikhoa_xuat(MaPXK, dt.Rows[i]["MaTB"].ToString(), Session["MaDonVi"].ToString(), dt.Rows[i]["MaPL"].ToString());
                e_lab.PhieuXuatKhoa.update_soluong_thietbi(MaPXK, dt.Rows[i]["MaPL"].ToString());
                e_lab.ThietBi.update_soluong();
                e_lab.ThietBi.update_ls(Session["MaDonVi"].ToString(), dt.Rows[i]["MaPL"].ToString(), dt.Rows[i]["MaTB"].ToString(), ngaynhan);
            }
        }


        private void themVaoHoaChat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_hc(MaPXK);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                    e_lab.VatTuKhoa.update_soluong_hoachatkhoa_xuat(MaPXK, dt.Rows[i]["MaHC"].ToString(), Session["MaDonVi"].ToString());
                    e_lab.PhieuXuatKhoa.update_soluong_hoachat(MaPXK);
                    e_lab.HoaChat.update_soluong();
            }
        }


        private void themVaoDungCu()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_dc(MaPXK);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                e_lab.VatTuKhoa.update_soluong_dungcukhoa_xuat(MaPXK, dt.Rows[i]["MaDC"].ToString(), Session["MaDonVi"].ToString());
                e_lab.PhieuXuatKhoa.update_soluong_dungcu(MaPXK);
                e_lab.DungCu.update_soluong();
            }
        }

        private Boolean duyetPX_DC()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_dc(MaPXK);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.sosanhsoluong_dc(dt.Rows[i]["MaDC"].ToString(), Session["MaDonVi"].ToString());
                int soluongcan;
                int.TryParse(dt.Rows[i]["SoLuong"].ToString(), out soluongcan);
                int soluongco;
                int.TryParse(dt2.Rows[0]["SoLuongTon"].ToString(), out soluongco);
                if (soluongcan > soluongco)
                    return false;

            }
            return true;
        }

        private Boolean duyetPX_TB()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_tb(MaPXK);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.sosanhsoluong_tb(dt.Rows[i]["MaTB"].ToString(), dt.Rows[i]["MaPL"].ToString(), Session["MaDonVi"].ToString());
                int soluongcan;
                int.TryParse(dt.Rows[i]["SoLuong"].ToString(), out soluongcan);
                int soluongco;
                int.TryParse(dt2.Rows[0]["SoLuongTon"].ToString(), out soluongco);
                if (soluongcan > soluongco)
                    return false;
            }
            return true;
        }

        private Boolean duyetPX_HC()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.CTPX_hc(MaPXK);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.sosanhsoluong_hc(dt.Rows[i]["MaHC"].ToString(), Session["MaDonVi"].ToString());
                int soluongcan;
                int.TryParse(dt.Rows[i]["SoLuong"].ToString(), out soluongcan);
                int soluongco;
                int.TryParse(dt2.Rows[0]["SoLuongTon"].ToString(), out soluongco);
                if (soluongcan > soluongco)
                    return false;
            }
            return true;
        }
    }
}