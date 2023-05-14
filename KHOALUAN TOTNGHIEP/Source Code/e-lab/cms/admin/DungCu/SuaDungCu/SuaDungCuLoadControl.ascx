<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.admin.DungCu.SuaDungCu.SuaDungCuLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=DungCu&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Chỉnh sửa thông tin dụng cụ <%=getmadc() %></div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin">
        <div class="Label">Tên dụng cụ</div>
        <div class="Input">
            <asp:TextBox ID="TenDC" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_TenDC" runat="server" ControlToValidate="TenDC" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Nhà sản xuất</div>
        <div class="Input">
            <asp:DropDownList ID="ddl_nsx" CssClass ="css-input" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Nhà cung cấp</div>
        <div class="Input">
            <asp:DropDownList ID="ddl_ncc" CssClass ="css-input" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Số lượng tồn</div>
        <div class="Input">
            <asp:TextBox ID="SoLuongTon" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_soluongton" runat="server" ControlToValidate="SoLuongTon" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="SoLuongTon" ID="RegularExpressionValidator_checkslt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Đơn vị tính</div>
        <div class="Input">
            <asp:TextBox ID="DVT" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btthem" Class="btnThem" runat="server" Text="Cập nhật" OnClick="btn_them_Click" />
    <asp:Button ID="btnsua" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_Click" />
</div>