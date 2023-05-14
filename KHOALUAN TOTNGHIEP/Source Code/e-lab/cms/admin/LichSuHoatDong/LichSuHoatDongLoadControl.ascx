<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichSuHoatDongLoadControl.ascx.cs" Inherits="e_lab.cms.admin.LichSuHoatDong.LichSuHoatDongLoadControl" %>


<div class="to-do-heading">

    <div class="heading-text no-icon-link">Lịch sử hoạt động</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi20 table_heading">Nhân viên</th>
            <th class="tb_mi50 table_heading">Hành động</th>
            <th class="tb_mi20 table_heading">Thời gian</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ds_lichsu" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
<%--    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemNCC" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>--%>
    <div class="pagination">
        <a href="/Admin.aspx?modul=LichSuHoatDong&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=LichSuHoatDong&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function XoaLS(MaLSHD) {
        if (confirm("Bạn có muốn xóa lịch sử hoạt động này chứ?")) {
            $.post("cms/admin/LichSuHoatDong/Ajax/XoaLichSuHoatDong.aspx",
                {
                    "MaLSHD": MaLSHD
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaLSHD).slideUp();

                    }
                });
        }
    }
</script>