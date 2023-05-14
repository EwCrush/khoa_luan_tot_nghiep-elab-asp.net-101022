<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuNhapLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhieuNhap.PhieuNhapLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhieuNhapDangChoXacNhan&trang=1" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-bell" title="Danh sách phiếu nhập đang chờ xác nhận"></i>
            <span class="notify"><%=dsDangXacNhan() %></span>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu nhập</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi15 table_heading">Mã phiếu nhập</th>
            <th class="tb_mi20 table_heading">Ngày lập</th>
            <th class="tb_mi20 table_heading">Tên nhân viên</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi20 table_heading">Chi tiết phiếu nhập</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="javascript:ThemPN()" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Lập phiếu nhập"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=PhieuNhap&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=PhieuNhap&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function XoaPN(MaPN) {
        if (confirm("Bạn có muốn xóa phiếu nhập này chứ?")) {
            $.post("cms/admin/PhieuNhap/Ajax/PhieuNhap.aspx",
                {
                    "MaPN": MaPN
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPN).slideUp();

                    }
                });
        }
    }
</script>

<script type="text/javascript">
    function ThemPN() {
        if (confirm("Bạn có thêm một phiếu nhập mới?")) {
            $.post("cms/admin/PhieuNhap/Ajax/ThemPhieuNhap.aspx",
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                    }
                });
        }
    }
</script>