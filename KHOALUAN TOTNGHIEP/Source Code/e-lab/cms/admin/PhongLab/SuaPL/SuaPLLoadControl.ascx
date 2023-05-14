<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaPLLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhongLab.SuaPL.SuaPLLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhongLab&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Chỉnh sửa thông tin phòng lab <%=getmapl() %></div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin">
        <div class="Label">Tên phòng lab</div>
        <div class="Input">
            <asp:TextBox ID="TenPL_Sua" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="TenPL_Sua" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Địa chỉ</div>
        <div class="Input">
            <asp:TextBox ID="DiaChiPhongLab_Sua" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="SuaPL" CssClass="btnThem" runat="server" Text="Cập nhật" OnClick="SuaPL_Click" />
    <asp:Button ID="NhapLaiPL" CssClass="btnThem" runat="server" Text="Nhập lại" OnClick="NhapLaiPL_Click" />
</div>