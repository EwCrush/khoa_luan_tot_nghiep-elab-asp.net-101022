<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemPLLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhongLab.ThemPL.ThemPLLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhongLab&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Thêm phòng lab</div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Tên phòng lab</div>
        <div class="Input">
            <asp:TextBox ID="TenPL" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="TenPL" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
    </div>
    <div class="ThongTin">
        <div class="Label">Địa chỉ</div>
        <div class="Input">
            <asp:TextBox ID="DiaChiPhongLab" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="ThemPL" CssClass="btnThem" runat="server" Text="Thêm" OnClick="ThemPL_Click" />
    <asp:Button ID="NhapLai" CssClass="btnThem" runat="server" Text="Nhập lại" OnClick="NhapLai_Click" />
</div>