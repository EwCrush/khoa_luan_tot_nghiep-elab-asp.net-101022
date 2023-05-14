<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuNhapDangChoXacNhanLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhieuNhap.PhieuNhapDangChoXacNhan.PhieuNhapDangChoXacNhanLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhieuNhap&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu nhập đang chờ xác nhận</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi15 table_heading">Mã phiếu nhập</th>
            <th class="tb_mi15 table_heading">Ngày lập</th>
            <th class="tb_mi15 table_heading">Tên nhân viên</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi20 table_heading">Chi tiết phiếu nhập</th>
            <th class="tb_mi20 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <%--<div class="pagination floatleft-item">
        <a href="" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-truck-ramp-box" title="Phiếu nhập từ khoa"></i>
        </a>
    </div>--%>
    <div class="pagination">
        <a href="/Admin.aspx?modul=PhieuNhapDangChoXacNhan&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=PhieuNhapDangChoXacNhan&trang=<%=getnext() %>" class="ThemMoi">
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
    function XacNhanPN(MaPN) {
        if (confirm("Bạn có muốn xác nhận phiếu nhập này chứ?")) {
            $.post("cms/admin/PhieuNhap/Ajax/XacNhanPhieuNhap.aspx",
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