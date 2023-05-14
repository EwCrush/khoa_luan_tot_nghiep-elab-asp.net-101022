using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user
{
    public partial class userLoadControl : System.Web.UI.UserControl
    {
        private string modul = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["modul"] != null)
                modul = Request.QueryString["modul"];

            switch (modul)
            {
                case "NhanVien":
                    phuserLoadControl.Controls.Add(LoadControl("NhanVien/NhanVienLoadControl.ascx"));
                    break;
                case "DoiMatKhau":
                    phuserLoadControl.Controls.Add(LoadControl("DoiMatKhau/DoiMatKhauLoadControl.ascx"));
                    break;
                case "PhieuNhap":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/PhieuNhapLoadControl.ascx"));
                    break;
                case "PhieuXuat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/PhieuXuatLoadControl.ascx"));
                    break;
                case "HoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("HoaChat/HoaChatLoadControl.ascx"));
                    break;
                case "DungCu":
                    phuserLoadControl.Controls.Add(LoadControl("DungCu/DungCuLoadControl.ascx"));
                    break;
                case "ThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("ThietBi/ThietBiLoadControl.ascx"));
                    break;
                case "TimKiemNhanVien":
                    phuserLoadControl.Controls.Add(LoadControl("NhanVien/TimKiemNhanVien/TimKiemNhanVienLoadControl.ascx"));
                    break;
                case "TimKiemHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("HoaChat/TimKiemHoaChat/TimKiemHoaChatLoadControl.ascx"));
                    break;
                case "TimKiemDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("DungCu/TimKiemDungCu/TimKiemDungCuLoadControl.ascx"));
                    break;
                case "TimKiemThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("ThietBi/TimKiemThietBi/TimKiemThietBiLoadControl.ascx"));
                    break;
                case "ThongSo":
                    phuserLoadControl.Controls.Add(LoadControl("ThietBi/ThongSo/ThongSoLoadControl.ascx"));
                    break;
                case "ThemNV":
                    phuserLoadControl.Controls.Add(LoadControl("NhanVien/ThemNV/ThemNVLoadControl.ascx"));
                    break;
                case "SuaNV":
                    phuserLoadControl.Controls.Add(LoadControl("NhanVien/SuaNV/SuaNVLoadControl.ascx"));
                    break;
                case "TaiKhoan":
                    phuserLoadControl.Controls.Add(LoadControl("TaiKhoan/TaiKhoanLoadControl.ascx"));
                    break;
                case "SuaTaiKhoan":
                    phuserLoadControl.Controls.Add(LoadControl("TaiKhoan/SuaTaiKhoan/SuaTaiKhoanLoadControl.ascx"));
                    break;
                case "TimKiemTaiKhoan":
                    phuserLoadControl.Controls.Add(LoadControl("TaiKhoan/TimKiemTaiKhoan/TimKiemTaiKhoanLoadControl.ascx"));
                    break;
                case "SuaHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("HoaChat/SuaHoaChat/SuaHoaChatLoadControl.ascx"));
                    break;
                case "SuaDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("DungCu/SuaDungCu/SuaDungCuLoadControl.ascx"));
                    break;
                case "ChiTietPhieuNhapDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapDungCu/ChiTietPhieuNhapDungCu.ascx"));
                    break;
                case "ChiTietPhieuNhapHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapHoaChat/ChiTietPhieuNhapHoaChat.ascx"));
                    break;
                case "ChiTietPhieuNhapThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/ChiTietPhieuNhapThietBi/ChiTietPhieuNhapThietBi.ascx"));
                    break;
                case "CTPNDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNDungCu/CTPNDungCuLoadControl.ascx"));
                    break;
                case "CTPNHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNHoaChat/CTPNHoaChatLoadControl.ascx"));
                    break;
                case "CTPNThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNThietBi/CTPNThietBiLoadControl.ascx"));
                    break;
                case "CTPXDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXDungCu/CTPXDungCuLoadControl.ascx"));
                    break;
                case "CTPXHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXHoaChat/CTPXHoaChatLoadControl.ascx"));
                    break;
                case "CTPXThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXThietBi/CTPXThietBiLoadControl.ascx"));
                    break;
                case "PhieuNhapDangChoDuyet":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/PhieuNhapDangChoDuyet/PhieuNhapDangChoDuyet.ascx"));
                    break;
                case "GuiPhieuNhap":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/GuiPhieuNhap/GuiPhieuNhapLoadControl.ascx"));
                    break;
                case "SuaPhieuNhap":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/SuaPhieuNhap/SuaPhieuNhapLoadControl.ascx"));
                    break;
                case "SuaPhieuXuat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/SuaPhieuXuat/SuaPhieuXuatLoadControl.ascx"));
                    break;
                case "ChiTietPhieuXuatDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/ChiTietPhieuXuatDungCu/ChiTietPhieuXuatDungCu.ascx"));
                    break;
                case "PhieuXuatDangChoXacNhan":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/PhieuXuatDangChoXacNhan/PhieuXuatDangChoXacNhan.ascx"));
                    break;
                case "ChiTietPhieuXuatHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/ChiTietPhieuXuatHoaChat/ChiTietPhieuXuatHoaChat.ascx"));
                    break;
                case "ChiTietPhieuXuatThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/ChiTietPhieuXuatThietBi/ChiTietPhieuXuatThietBi.ascx"));
                    break;
                case "SuaCTPNDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNDungCu/SuaCTPNDungCu/SuaCTPNDungCuLoadControl.ascx"));
                    break;
                case "ThemCTPNDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNDungCu/ThemCTPNDungCu/ThemCTPNDungCuLoadControl.ascx"));
                    break;
                case "SuaCTPNThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNThietBi/SuaCTPNThietBi/SuaCTPNThietBiLoadControl.ascx"));
                    break;
                case "ThemCTPNThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNThietBi/ThemCTPNThietBi/ThemCTPNThietBiLoadControl.ascx"));
                    break;
                case "SuaCTPNHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNHoaChat/SuaCTPNHoaChat/SuaCTPNHoaChatLoadControl.ascx"));
                    break;
                case "ThemCTPNHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuNhap/CTPNHoaChat/ThemCTPNHoaChat/ThemCTPNHoaChatLoadControl.ascx"));
                    break;
                case "SuaCTPXDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXDungCu/SuaCTPXDungCu/SuaCTPXDungCuLoadControl.ascx"));
                    break;
                case "ThemCTPXDungCu":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXDungCu/ThemCTPXDungCu/ThemCTPXDungCuLoadControl.ascx"));
                    break;
                case "SuaCTPXThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXThietBi/SuaCTPXThietBi/SuaCTPXThietBiLoadControl.ascx"));
                    break;
                case "ThemCTPXThietBi":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXThietBi/ThemCTPXThietBi/ThemCTPXThietBiLoadControl.ascx"));
                    break;
                case "SuaCTPXHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXHoaChat/SuaCTPXHoaChat/SuaCTPXHoaChatLoadControl.ascx"));
                    break;
                case "ThemCTPXHoaChat":
                    phuserLoadControl.Controls.Add(LoadControl("PhieuXuat/CTPXHoaChat/ThemCTPXHoaChat/ThemCTPXHoaChatLoadControl.ascx"));
                    break;
            }
        }
    }
}