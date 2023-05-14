<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongTinThemHoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.admin.HoaChat.ThongTinThemHoaChat.ThongTinThemHoaChatLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=HoaChat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Thông tin thêm về hóa chất <%=getmahc() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi25 table_heading">Nhà sản xuất</th>
            <th class="tb_mi25 table_heading">Nhà cung cấp</th>
            <th class="tb_mi15 table_heading">Hạn sử dụng</th>
            <th class="tb_mi35 table_heading">Ghi chú</th>
        </tr>
        <asp:Literal ID="ltr_ds_hc" runat="server"></asp:Literal>
    </table>