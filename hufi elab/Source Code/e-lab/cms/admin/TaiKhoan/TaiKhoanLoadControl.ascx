<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaiKhoanLoadControl.ascx.cs" Inherits="e_lab.cms.admin.TaiKhoan.TaiKhoanLoadControl" %>

<div class="to-do-heading">

    <div class="heading-text no-icon-link">Danh sách tài khoản</div>
    <div class="search">
            <div class="tk">
                <asp:TextBox ID="iptk" CssClass ="cssiptk" runat="server"></asp:TextBox>
                <a href="/Admin.aspx?modul=TimKiemTaiKhoan&keyword=<%=get_iptk() %>&trang=1" class="ThemMoi">
                    <i class="tk-icon fa-solid fa-magnifying-glass" title="Tìm kiếm"></i>
                </a>
            </div> 
      </div>
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
        <a href="/Admin.aspx?modul=TaiKhoan&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=TaiKhoan&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>