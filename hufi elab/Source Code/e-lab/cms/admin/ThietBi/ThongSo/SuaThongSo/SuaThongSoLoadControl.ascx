<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaThongSoLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.ThongSo.SuaThongSo.SuaThongSoLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThongSo&matb=<%=getmatb() %>&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Chỉnh sửa thông số <%=getmats() %> cho thiết bị <%=getmatb() %></div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin">
        <div class="Label">Thông số</div>
        <div class="Input">
            <asp:TextBox ID="ThongSo" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_ThongSo" runat="server" ControlToValidate="ThongSo" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <asp:Button ID="btthem" Class="btnThem" runat="server" Text="Cập nhật" OnClick="btn_them_Click" />
    <asp:Button ID="btnsua" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_Click" />
</div>