<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongSoLoadControl.ascx.cs" Inherits="e_lab.cms.user.ThietBi.ThongSo.ThongSoLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=ThietBi&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Thông số thiết bị <%=getmatb() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi20 table_heading">Mã thông số</th>
            <th class="tb_mi80 table_heading">Thông số</th>
        </tr>
        <asp:Literal ID="ltr_ds_ts" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=ThongSo&matb=<%=getmatb() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=ThongSo&matb=<%=getmatb() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>