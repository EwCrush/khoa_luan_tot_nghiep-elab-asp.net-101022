<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemNSXLoadControl.ascx.cs" Inherits="e_lab.cms.admin.NhaSanXuat.ThemNSX.ThemNSXLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=NhaSanXuat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Thêm nhà sản xuất</div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Tên nhà sản xuất</div>
        <div class="Input">
            <asp:TextBox ID="TenNSX_them" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_tennsx_them" runat="server" ControlToValidate="TenNSX_them" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">SDT</div>
        <div class="Input">
            <asp:TextBox ID="SDT_NSX_them" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="SDT_NSX_Them" ID="RegularExpressionValidator_checksdt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Email</div>
        <div class="Input">
            <asp:TextBox ID="Email_NSX_them" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Địa chỉ</div>
        <div class="Input">
            <asp:TextBox ID="DiaChiNSX_them" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btn_themnsx" Class="btnThem" runat="server" Text="Thêm" OnClick="btn_themnsx_Click"  />
    <asp:Button ID="btn_nhaplai_themnsx" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_themnsx_Click" />
</div>