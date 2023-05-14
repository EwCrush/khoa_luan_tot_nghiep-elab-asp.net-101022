<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiemHoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.user.HoaChat.TimKiemHoaChat.TimKiemHoaChatLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=HoaChat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách hóa chất có tên <%=getkeyword() %> trong <%=getmadv() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi10 table_heading">Mã hóa chất</th>
            <th class="tb_mi15 table_heading">Tên hóa chất</th>
            <th class="tb_mi15 table_heading">CTHH</th>
            <th class="tb_mi10 table_heading">Ngày nhập</th>
            <th class="tb_mi10 table_heading">Số lượng tồn</th>
            <th class="tb_mi10 table_heading">DVT</th>
            <th class="tb_mi10 table_heading">Hạn sử dụng</th>
            <th class="tb_mi10 table_heading">Ghi chú</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_hc" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=TimKiemHoaChat&keyword=<%=getkeyword() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=TimKiemHoaChat&keyword=<%=getkeyword() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>