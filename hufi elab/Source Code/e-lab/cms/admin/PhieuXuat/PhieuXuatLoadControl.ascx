<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuXuatLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhieuXuat.PhieuXuatLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhieuXuatDangChoDuyet&trang=1" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-bell" title="Danh sách phiếu xuất đang chờ duyệt"></i>
            <span class="notify"><%=dsChoDuyet() %></span>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu xuất</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi10 table_heading">Mã phiếu xuất</th>
            <th class="tb_mi15 table_heading">Ngày lập</th>
            <th class="tb_mi15 table_heading">Nhân viên duyệt</th>
            <th class="tb_mi20 table_heading">Tên đơn vị</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi15 table_heading">Chi tiết phiếu xuất</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=PhieuXuat&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=PhieuXuat&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaPX(MaPX) {
        if (confirm("Bạn có muốn xóa phiếu xuất này chứ?")) {
            $.post("cms/admin/PhieuXuat/Ajax/PhieuXuat.aspx",
                {
                    "MaPX": MaPX
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPX).slideUp();

                    }
                });
        }
    }
</script>