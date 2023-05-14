using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.PhieuXuat.PhieuXuatDangChoDuyet.Ajax
{
    public partial class DuyetPhieuXuat : System.Web.UI.Page
    {
        string MaPX = "";
        string MaDV = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["MaPX"] != null)
                MaPX = Request.Params["MaPX"];
            if (Request.Params["MaDV"] != null)
                MaDV = Request.Params["MaDV"];

            
            duyetPX_DC();
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
            e_lab.PhieuXuat.update_phieuxuat(MaPX, Session["MaNhanVien"].ToString());
        }

        private void themvaoLichSuHoatDong()
        {
            e_lab.LichSuHoatDong.duyetphieuxuat(Session["MaNhanVien"].ToString(), MaPX, gettendv());
        }

        private string gettendv()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(MaDV);
            return dt.Rows[0]["TenDV"].ToString();
        }

        private void themVaoThietBi()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.CTPX_tb(MaPX);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.check_thietbikhoa(dt.Rows[i]["MaTB"].ToString(), MaDV, dt.Rows[i]["MaPL"].ToString());
                if (dt2.Rows.Count > 0)
                {
                    e_lab.VatTuKhoa.update_soluong_thietbikhoa(MaPX, dt.Rows[i]["MaTB"].ToString(), MaDV, dt.Rows[i]["MaPL"].ToString());
                    e_lab.PhieuXuat.update_soluong_thietbi(MaPX, dt.Rows[i]["MaPL"].ToString(), dt.Rows[i]["MaTB"].ToString());
                    e_lab.ThietBi.update_soluong();
                    e_lab.ThietBi.them_ls(MaDV, dt.Rows[i]["MaPL"].ToString(), dt.Rows[i]["MaTB"].ToString());
                }
                else 
                {
                    e_lab.VatTuKhoa.them_tbk(dt.Rows[i]["MaTB"].ToString(), MaDV, dt.Rows[i]["MaPL"].ToString(), dt.Rows[i]["SoLuong"].ToString());
                    e_lab.PhieuXuat.update_soluong_thietbi(MaPX, dt.Rows[i]["MaPL"].ToString(), dt.Rows[i]["MaTB"].ToString());
                    e_lab.ThietBi.update_soluong();
                    e_lab.ThietBi.them_ls(MaDV, dt.Rows[i]["MaPL"].ToString(), dt.Rows[i]["MaTB"].ToString());
                }
            }
        }


        private void themVaoHoaChat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.CTPX_hc(MaPX);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.check_hoachatkhoa(dt.Rows[i]["MaHC"].ToString(), MaDV);
                if (dt2.Rows.Count > 0)
                {
                    e_lab.VatTuKhoa.update_soluong_hoachatkhoa(MaPX, dt.Rows[i]["MaHC"].ToString(), MaDV);
                    e_lab.PhieuXuat.update_soluong_hoachat(MaPX, dt.Rows[i]["MaHC"].ToString());
                    e_lab.HoaChat.update_soluong();
                }
                else
                {
                    e_lab.VatTuKhoa.them_hck(dt.Rows[i]["MaHC"].ToString(), MaDV, dt.Rows[i]["SoLuong"].ToString());
                    e_lab.PhieuXuat.update_soluong_hoachat(MaPX, dt.Rows[i]["MaHC"].ToString());
                    e_lab.HoaChat.update_soluong();
                }
            }
        }


        private void themVaoDungCu()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.CTPX_dc(MaPX);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.VatTuKhoa.check_dungcukhoa(dt.Rows[i]["MaDC"].ToString(), MaDV);
                if (dt2.Rows.Count > 0)
                {
                    e_lab.VatTuKhoa.update_soluong_dungcukhoa(MaPX, dt.Rows[i]["MaDC"].ToString(), MaDV);
                    e_lab.PhieuXuat.update_soluong_dungcu(MaPX, dt.Rows[i]["MaDC"].ToString());
                    e_lab.DungCu.update_soluong();
                }
                else 
                {
                    e_lab.VatTuKhoa.them_dck(dt.Rows[i]["MaDC"].ToString(), MaDV, dt.Rows[i]["SoLuong"].ToString());
                    e_lab.PhieuXuat.update_soluong_dungcu(MaPX, dt.Rows[i]["MaDC"].ToString());
                    e_lab.DungCu.update_soluong();
                }
            }
        }

        

        
        
        

        private Boolean duyetPX_DC()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuat.CTPX_dc(MaPX);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.DungCu.sosanhsoluong_dc(dt.Rows[i]["MaDC"].ToString());
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
            dt = e_lab.PhieuXuat.CTPX_tb(MaPX);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.ThietBi.sosanhsoluong_tb(dt.Rows[i]["MaTB"].ToString());
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
            dt = e_lab.PhieuXuat.CTPX_hc(MaPX);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = new DataTable();
                dt2 = e_lab.HoaChat.sosanhsoluong_hc(dt.Rows[i]["MaHC"].ToString());
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