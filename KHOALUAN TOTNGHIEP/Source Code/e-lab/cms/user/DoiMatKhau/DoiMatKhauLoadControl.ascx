<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoiMatKhauLoadControl.ascx.cs" Inherits="e_lab.cms.user.DoiMatKhau.DoiMatKhauLoadControl" %>

<div class="to-do-heading">
    <div class="heading-text no-icon-link">Đổi mật khẩu</div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin">
        <div class="Label">Mật khẩu hiện tại</div>
        <div class="Input">
            <asp:TextBox ID="MatKhauHienTai" Type="Password" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_mkht" runat="server" ControlToValidate="MatKhauHienTai" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Mật khẩu mới</div>
        <div class="Input">
            <asp:TextBox ID="MatKhauMoi" Type="Password" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_mkm" runat="server" ControlToValidate="MatKhauMoi" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Nhập lại mật khẩu mới</div>
        <div class="Input">
            <asp:TextBox ID="NhapLaiMatKhau" Type="Password" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_nlmkm" runat="server" ControlToValidate="NhapLaiMatKhau" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <asp:Button ID="btn_themnsx" Class="btnThem" runat="server" Text="Lưu" OnClick="btn_themnsx_Click"/>
    <asp:Button ID="btn_nhaplai_themnsx" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_themnsx_Click"/>
</div>