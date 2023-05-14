<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemNCCLoadControl.ascx.cs" Inherits="e_lab.cms.admin.NhaCungCap.ThemNCC.ThemNCCLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=NhaCungCap&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Thêm nhà cung cấp</div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Tên nhà cung cấp</div>
        <div class="Input">
            <asp:TextBox ID="TenNCC_them" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_tenncc_them" runat="server" ControlToValidate="TenNCC_them" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">SDT</div>
        <div class="Input">
            <asp:TextBox ID="SDT_NCC_them" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="SDT_NCC_Them" ID="RegularExpressionValidator_checksdt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Email</div>
        <div class="Input">
            <asp:TextBox ID="Email_NCC_them" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Địa chỉ</div>
        <div class="Input">
            <asp:TextBox ID="DiaChiNCC_them" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btn_themncc" Class="btnThem" runat="server" Text="Thêm" OnClick="btn_themncc_Click"  />
    <asp:Button ID="btn_nhaplai_themncc" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_themncc_Click"  />
</div>