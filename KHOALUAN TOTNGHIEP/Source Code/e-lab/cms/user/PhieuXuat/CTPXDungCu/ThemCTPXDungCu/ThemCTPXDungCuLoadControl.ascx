<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemCTPXDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuXuat.CTPXDungCu.ThemCTPXDungCu.ThemCTPXDungCuLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=CTPXDungCu&mapxk=<%=getmapxk() %>&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Thêm dụng cụ cho phiếu xuất <%=getmapxk() %></div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin">
        <div class="Label">Dụng cụ</div>
        <div class="Input">
            <asp:DropDownList ID="ddl_dungcu" CssClass ="css-input" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Số lượng</div>
        <div class="Input">
            <asp:TextBox ID="SoLuong" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_soluongton" runat="server" ControlToValidate="SoLuong" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="SoLuong" ID="RegularExpressionValidator_checkslt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <asp:Button ID="btthem" Class="btnThem" runat="server" Text="Thêm" OnClick="btn_them_Click" />
    <asp:Button ID="btnsua" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_Click" />
</div>