<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaTaiKhoanLoadControl.ascx.cs" Inherits="e_lab.cms.admin.TaiKhoan.SuaTaiKhoan.SuaTaiKhoanLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=TaiKhoan&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Chỉnh sửa thông tin đăng nhập cho tài khoản của nhân viên <%=getmanv() %></div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Tài khoản</div>
        <div class="Input">
            <asp:TextBox ID="taikhoan" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_taikhoan" runat="server" ControlToValidate="taikhoan" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Mật khẩu</div>
        <div class="Input">
            <asp:TextBox ID="matkhau" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_matkhau" runat="server" ControlToValidate="matkhau" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <asp:Button ID="btn_capnhat" Class="btnThem" runat="server" Text="Cập nhật" OnClick="btn_capnhat_Click"  />
    <asp:Button ID="btn_nhaplai" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_Click"  />
</div>