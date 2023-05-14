<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichSuSuDungLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.LichSuSuDung.LichSuSuDungLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThietBi&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Lịch sử sử dụng thiết bị <%=getmatb() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi30 table_heading">Tên đơn vị</th>
            <th class="tb_mi30 table_heading">Tên phòng lab</th>
            <th class="tb_mi15 table_heading">Ngày nhận</th>
            <th class="tb_mi15 table_heading">Ngày trả</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_ls" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=LichSuSuDung&matb=<%=getmatb() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=LichSuSuDung&matb=<%=getmatb() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaLichSu(MaLS) {
        if (confirm("Bạn có muốn xóa lịch sử này chứ?")) {
            $.post("cms/admin/ThietBi/LichSuSuDung/Ajax/LichSuSuDung.aspx",
                {
                    "MaLS": MaLS,
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaLS).slideUp();

                    }
                });
        }
    }
</script>