<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongTinThemThietBiBTBDLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.BaoTriBaoDuong.ThongTinThemThietBiBTBD.ThongTinThemThietBiBTBDLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=BaoTriBaoDuong&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Thông tin thêm về thiết bị <%=getmatb() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi20 table_heading">Nhà sản xuất</th>
            <th class="tb_mi20 table_heading">Nhà cung cấp</th>
            <th class="tb_mi10 table_heading">Ngày nhập</th>
            <th class="tb_mi10 table_heading">Số lượng nhập</th>
            <th class="tb_mi10 table_heading">Số lượng xuất</th>
            <th class="tb_mi10 table_heading">Số lượng tồn</th>
            <th class="tb_mi10 table_heading">DVT</th>
            <th class="tb_mi10 table_heading">Thông số</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>