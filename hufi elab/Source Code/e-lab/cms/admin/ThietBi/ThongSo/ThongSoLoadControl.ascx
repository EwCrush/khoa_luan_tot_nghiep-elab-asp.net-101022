<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongSoLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.ThongSo.ThongSoLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThongTinThemThietBi&matb=<%=getmatb() %>" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Thông số thiết bị <%=getmatb() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi15 table_heading">Mã thông số</th>
            <th class="tb_mi70 table_heading">Thông số</th>
            <th class="tb_mi15 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_ts" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemThongSo&matb=<%=getmatb()%>" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=ThongSo&matb=<%=getmatb() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=ThongSo&matb=<%=getmatb() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function XoaTS(MaTS) {
        if (confirm("Bạn có muốn xóa thông số  này chứ?")) {
            $.post("cms/admin/ThietBi/ThongSo/Ajax/ThongSo.aspx",
                {
                    "MaTS": MaTS
                },
                function (data, status) {
                    if (data != 1) {
                        alert("failed");
                    }
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaTS).slideUp();

                    }
                });
        }
    }
</script>