<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTPNHoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapHoaChat.CTPNHoaChat.CTPNHoaChatLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhieuNhap&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách hóa chất trong phiếu nhập <%=getmapn() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi75 table_heading">Tên hóa chất</th>
            <th class="tb_mi25 table_heading">Số lượng</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=CTPNHoaChat&mapn=<%=getmapn() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=CTPNHoaChat&mapn=<%=getmapn() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>