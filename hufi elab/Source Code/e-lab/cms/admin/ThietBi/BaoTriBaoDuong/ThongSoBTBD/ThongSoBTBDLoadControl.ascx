<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongSoBTBDLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.BaoTriBaoDuong.ThongSoBTBD.ThongSoBTBDLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThongTinThemThietBiBTBD&matb=<%=getmatb() %>" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Thông số thiết bị <%=getmatb() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi30 table_heading">Mã thông số</th>
            <th class="tb_mi70 table_heading">Thông số</th>
        </tr>
        <asp:Literal ID="ltr_ds_ts" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=ThongSoBTBD&matb=<%=getmatb() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=ThongSoBTBD&matb=<%=getmatb() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>
