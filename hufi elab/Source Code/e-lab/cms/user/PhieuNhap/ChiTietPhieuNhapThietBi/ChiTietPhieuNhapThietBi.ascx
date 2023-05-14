<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietPhieuNhapThietBi.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.ChiTietPhieuNhapThietBi.ChiTietPhieuNhapThietBi" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=PhieuNhap&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách thiết bị trong phiếu xuất <%=getmapx() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi40 table_heading">Tên thiết bị</th>
            <th class="tb_mi40 table_heading">Tên phòng lab</th>
            <th class="tb_mi20 table_heading">Số lượng</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=ChiTietPhieuNhapThietBi&mapx=<%=getmapx() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=ChiTietPhieuNhapThietBi&mapx=<%=getmapx() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>