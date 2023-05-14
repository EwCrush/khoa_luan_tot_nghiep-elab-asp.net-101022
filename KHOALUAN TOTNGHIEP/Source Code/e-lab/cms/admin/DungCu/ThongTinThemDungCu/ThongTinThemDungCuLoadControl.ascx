<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongTinThemDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.admin.DungCu.ThongTinThemDungCu.ThongTinThemDungCuLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=DungCu&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Thông tin thêm về dụng cụ <%=getmadc() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi50 table_heading">Nhà sản xuất</th>
            <th class="tb_mi50 table_heading">Nhà cung cấp</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>