<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiemTaiKhoanLoadControl.ascx.cs" Inherits="e_lab.cms.user.TaiKhoan.TimKiemTaiKhoan.TimKiemTaiKhoanLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=TaiKhoan&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Danh sách tài khoản có tên là <%=get_keyword() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_manv_tk table_heading">Mã nhân viên</th>
            <th class="tb_tennv_tk table_heading">Tên nhân viên</th>
            <th class="tb_taikhoan table_heading">Tài khoản</th>
            <th class="tb_matkhau table_heading">Mật khẩu</th>
            <th class="tb_thaotac table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tk" runat="server"></asp:Literal>
    </table>

<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=TimKiemTaiKhoan&keyword=<%=get_keyword() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=TimKiemTaiKhoan&keyword=<%=get_keyword() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>