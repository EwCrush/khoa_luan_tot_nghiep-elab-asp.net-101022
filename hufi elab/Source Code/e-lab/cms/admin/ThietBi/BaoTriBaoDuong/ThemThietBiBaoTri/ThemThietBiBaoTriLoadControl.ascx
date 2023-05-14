<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemThietBiBaoTriLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.BaoTriBaoDuong.ThemThietBiBaoTri.ThemThietBiBaoTriLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=BaoTriBaoDuong&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Thêm thiết bị vào danh sách bảo trì</div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin">
        <div class="Label">Thiết bị</div>
        <div class="Input">
            <asp:DropDownList ID="ddl_tb" CssClass ="css-input" runat="server"></asp:DropDownList>
        </div>
    </div>
    <asp:Button ID="btthem" Class="btnThem" runat="server" Text="Thêm" OnClick="btn_them_Click" />
</div>