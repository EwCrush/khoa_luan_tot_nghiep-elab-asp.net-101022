using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin
{
    public partial class adminLoadControl : System.Web.UI.UserControl
    {
        private string modul = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];

            switch (modul)
            {
                case "PhongLab":
                    phadminLoadControl.Controls.Add(LoadControl("PhongLab/PhongLabLoadControl.ascx"));
                    break;
                case "LichSuHoatDong":
                    phadminLoadControl.Controls.Add(LoadControl("LichSuHoatDong/LichSuHoatDongLoadControl.ascx"));
                    break;
                case "PhieuXuatDangChoDuyet":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuXuat/PhieuXuatDangChoDuyet/PhieuXuatDangChoDuyet.ascx"));
                    break;
                case "NhanVien":
                    phadminLoadControl.Controls.Add(LoadControl("NhanVien/NhanVienLoadControl.ascx"));
                    break;
                case "NhaSanXuat":
                    phadminLoadControl.Controls.Add(LoadControl("NhaSanXuat/NhaSanXuatLoadControl.ascx"));
                    break;
                case "NhaCungCap":
                    phadminLoadControl.Controls.Add(LoadControl("NhaCungCap/NhaCungCapLoadControl.ascx"));
                    break;
                case "PhieuNhap":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/PhieuNhapLoadControl.ascx"));
                    break;
                case "PhieuNhapDangChoXacNhan":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/PhieuNhapDangChoXacNhan/PhieuNhapDangChoXacNhanLoadControl.ascx"));
                    break;
                case "SuaPhieuNhap":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/SuaPhieuNhap/SuaPhieuNhapLoadControl.ascx"));
                    break;
                case "ChiTietPhieuNhapDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapDungCu/ChiTietPhieuNhapDungCuLoadControl.ascx"));
                    break;
                case "ChiTietPhieuNhapHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapHoaChat/ChiTietPhieuNhapHoaChatLoadControl.ascx"));
                    break;
                case "ChiTietPhieuXuatDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuXuat/ChiTietPhieuXuatDungCu/ChiTietPhieuXuatDungCu.ascx"));
                    break;
                case "ChiTietPhieuXuatHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuXuat/ChiTietPhieuXuatHoaChat/ChiTietPhieuXuatHoaChat.ascx"));
                    break;
                case "ChiTietPhieuXuatThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuXuat/ChiTietPhieuXuatThietBi/ChiTietPhieuXuatThietBi.ascx"));
                    break;
                case "CTPNDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapDungCu/CTPNDungCu/CTPNDungCuLoadControl.ascx"));
                    break;
                case "CTPNHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapHoaChat/CTPNHoaChat/CTPNHoaChatLoadControl.ascx"));
                    break;
                case "CTPNThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapThietBi/CTPNThietBi/CTPNThietBiLoadControl.ascx"));
                    break;
                case "ThemChiTietPhieuNhapHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapHoaChat/ThemChiTietPhieuNhapHoaChat/ThemChiTietPhieuNhapHoaChatLoadControl.ascx"));
                    break;
                case "SuaChiTietPhieuNhapHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapHoaChat/SuaChiTietPhieuNhapHoaChat/SuaChiTietPhieuNhapHoaChatLoadControl.ascx"));
                    break;
                case "ThemChiTietPhieuNhapThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapThietBi/ThemChiTietPhieuNhapThietBi/ThemChiTietPhieuNhapThietBiLoadControl.ascx"));
                    break;
                case "SuaChiTietPhieuNhapThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapThietBi/SuaChiTietPhieuNhapThietBi/SuaChiTietPhieuNhapThietBiLoadControl.ascx"));
                    break;
                case "ThemChiTietPhieuNhapDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapDungCu/ThemChiTietPhieuNhapDungCu/ThemChiTietPhieuNhapDungCuLoadControl.ascx"));
                    break;
                case "SuaChiTietPhieuNhapDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapDungCu/SuaChiTietPhieuNhapDungCu/SuaChiTietPhieuNhapDungCuLoadControl.ascx"));
                    break;
                case "ChiTietPhieuNhapThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapThietBi/ChiTietPhieuNhapThietBiLoadControl.ascx"));
                    break;
                case "PhieuXuat":
                    phadminLoadControl.Controls.Add(LoadControl("PhieuXuat/PhieuXuatLoadControl.ascx"));
                    break;
                case "DoiMatKhau":
                    phadminLoadControl.Controls.Add(LoadControl("DoiMatKhau/DoiMatKhauLoadControl.ascx"));
                    break;
                case "ThemPL":
                    phadminLoadControl.Controls.Add(LoadControl("PhongLab/ThemPL/ThemPLLoadControl.ascx"));
                    break;
                case "SuaPL":
                    phadminLoadControl.Controls.Add(LoadControl("PhongLab/SuaPL/SuaPLLoadControl.ascx"));
                    break;
                case "ThemNSX":
                    phadminLoadControl.Controls.Add(LoadControl("NhaSanXuat/ThemNSX/ThemNSXLoadControl.ascx"));
                    break;
                case "SuaNSX":
                    phadminLoadControl.Controls.Add(LoadControl("NhaSanXuat/SuaNSX/SuaNSXLoadControl.ascx"));
                    break;
                case "ThemNCC":
                    phadminLoadControl.Controls.Add(LoadControl("NhaCungCap/ThemNCC/ThemNCCLoadControl.ascx"));
                    break;
                case "SuaNCC":
                    phadminLoadControl.Controls.Add(LoadControl("NhaCungCap/SuaNCC/SuaNCCLoadControl.ascx"));
                    break;               
                case "ThemNV":
                    phadminLoadControl.Controls.Add(LoadControl("NhanVien/ThemNV/ThemNVLoadControl.ascx"));
                    break;
                case "SuaNV":
                    phadminLoadControl.Controls.Add(LoadControl("NhanVien/SuaNV/SuaNVLoadControl.ascx"));
                    break;
                case "TaiKhoan":
                    phadminLoadControl.Controls.Add(LoadControl("TaiKhoan/TaiKhoanLoadControl.ascx"));
                    break;
                case "ThemTaiKhoan":
                    phadminLoadControl.Controls.Add(LoadControl("TaiKhoan/ThemTaiKhoan/ThemTaiKhoanLoadControl.ascx"));
                    break;
                case "SuaTaiKhoan":
                    phadminLoadControl.Controls.Add(LoadControl("TaiKhoan/SuaTaiKhoan/SuaTaiKhoanLoadControl.ascx"));
                    break;
                case "TimKiemPhongLab":
                    phadminLoadControl.Controls.Add(LoadControl("PhongLab/TimKiemPhongLab/TimKiemPhongLabLoadControl.ascx"));
                    break;
                case "TimKiemTaiKhoan":
                    phadminLoadControl.Controls.Add(LoadControl("TaiKhoan/TimKiemTaiKhoan/TimKiemTaiKhoanLoadControl.ascx"));
                    break;
                case "TimKiemNhaCungCap":
                    phadminLoadControl.Controls.Add(LoadControl("NhaCungCap/TimKiemNhaCungCap/TimKiemNhaCungCapLoadControl.ascx"));
                    break;
                case "TimKiemNhaSanXuat":
                    phadminLoadControl.Controls.Add(LoadControl("NhaSanXuat/TimKiemNhaSanXuat/TimKiemNhaSanXuatLoadControl.ascx"));
                    break;
                case "TimKiemNhanVien":
                    phadminLoadControl.Controls.Add(LoadControl("NhanVien/TimKiemNhanVien/TimKiemNhanVienLoadControl.ascx"));
                    break;
                case "HoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/HoaChatLoadControl.ascx"));
                    break;
                case "ThemHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/ThemHoaChat/ThemHoaChatLoadControl.ascx"));
                    break;
                case "ThongTinThemHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/ThongTinThemHoaChat/ThongTinThemHoaChatLoadControl.ascx"));
                    break;
                case "HoaChatHetHan":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/HoaChatHetHan/HoaChatHetHanLoadControl.ascx"));
                    break;
                case "ThanhLy":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/HoaChatHetHan/ThanhLy/ThanhLyLoadControl.ascx"));
                    break;
                case "ThongTinThemHoaChatHetHan":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/HoaChatHetHan/ThongTinThemHoaChatHetHan/ThongTinThemHoaChatHetHanLoadControl.ascx"));
                    break;
                case "SuaHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/SuaHoaChat/SuaHoaChatLoadControl.ascx"));
                    break;
                case "TimKiemHoaChat":
                    phadminLoadControl.Controls.Add(LoadControl("HoaChat/TimKiemHoaChat/TimKiemHoaChatLoadControl.ascx"));
                    break;
                case "DungCu":
                    phadminLoadControl.Controls.Add(LoadControl("DungCu/DungCuLoadControl.ascx"));
                    break;
                case "ThemDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("DungCu/ThemDungCu/ThemDungCuLoadControl.ascx"));
                    break;
                case "SuaDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("DungCu/SuaDungCu/SuaDungCuLoadControl.ascx"));
                    break;
                case "TimKiemDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("DungCu/TimKiemDungCu/TimKiemDungCuLoadControl.ascx"));
                    break;
                case "ThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/ThietBiLoadControl.ascx"));
                    break;
                case "ThemThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/ThemThietBi/ThemThietBiLoadControl.ascx"));
                    break;
                case "ThemThietBiBaoTri":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/BaoTriBaoDuong/ThemThietBiBaoTri/ThemThietBiBaoTriLoadControl.ascx"));
                    break;
                case "BaoTriBaoDuong":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/BaoTriBaoDuong/BaoTriBaoDuongLoadControl.ascx"));
                    break;
                case "ThongTinThemDungCu":
                    phadminLoadControl.Controls.Add(LoadControl("DungCu/ThongTinThemDungCu/ThongTinThemDungCuLoadControl.ascx"));
                    break;
                case "ThongTinThemThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/ThongTinThemThietBi/ThongTinThemThietBiLoadControl.ascx"));
                    break;
                case "ThongTinThemThietBiBTBD":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/BaoTriBaoDuong/ThongTinThemThietBiBTBD/ThongTinThemThietBiBTBDLoadControl.ascx"));
                    break;
                case "SuaThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/SuaThietBi/SuaThietBiLoadControl.ascx"));
                    break;
                case "TimKiemThietBi":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/TimKiemThietBi/TimKiemThietBiLoadControl.ascx"));
                    break;
                case "ThongSo":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/ThongSo/ThongSoLoadControl.ascx"));
                    break;
                case "ThongSoBTBD":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/BaoTriBaoDuong/ThongSoBTBD/ThongSoBTBDLoadControl.ascx"));
                    break;
                case "LichSuSuDung":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/LichSuSuDung/LichSuSuDungLoadControl.ascx"));
                    break;
                case "ThemThongSo":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/ThongSo/ThemThongSo/ThemThongSoLoadControl.ascx"));
                    break;
                case "SuaThongSo":
                    phadminLoadControl.Controls.Add(LoadControl("ThietBi/ThongSo/SuaThongSo/SuaThongSoLoadControl.ascx"));
                    break;
            }
        }
    }
}