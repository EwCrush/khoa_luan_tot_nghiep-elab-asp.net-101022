<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.user.DungCu.SuaDungCu.SuaDungCuLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=DungCu&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Cập nhật số lượng tồn của dụng cụ <%=getmadc() %> trong <%=getmadv() %></div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin">
        <div class="Label">Số lượng tồn</div>
        <div class="Input">
            <asp:TextBox ID="SoLuongTon" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_soluongton" runat="server" ControlToValidate="SoLuongTon" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="SoLuongTon" ID="RegularExpressionValidator_checkslt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <asp:Button ID="btncapnhat" Class="btnThem" runat="server" Text="Cập nhật" OnClick="btncapnhat_Click"  />
    <asp:Button ID="btnreset" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btnreset_Click"  />
</div>