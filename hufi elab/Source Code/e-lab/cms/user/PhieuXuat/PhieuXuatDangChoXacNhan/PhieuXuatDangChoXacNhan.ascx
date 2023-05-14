<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuXuatDangChoXacNhan.ascx.cs" Inherits="e_lab.cms.user.PhieuXuat.PhieuXuatDangChoXacNhan.PhieuXuatDangChoXacNhan" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=PhieuXuat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu xuất đang chờ xác nhận</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi15 table_heading">Mã phiếu xuất</th>
            <th class="tb_mi15 table_heading">Ngày lập</th>
            <th class="tb_mi15 table_heading">Tên nhân viên</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi20 table_heading">Chi tiết phiếu nhập</th>
            <th class="tb_mi20 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=PhieuXuatDangChoXacNhan&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=PhieuXuatDangChoXacNhan&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaPXK(MaPXK) {
        if (confirm("Bạn có muốn xóa phiếu xuất này chứ?")) {
            $.post("cms/user/PhieuXuat/Ajax/XoaPhieuXuat.aspx",
                {
                    "MaPXK": MaPXK
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPXK).slideUp();

                    }
                });
        }
    }
</script>

<script type="text/javascript">
    function XacNhanPXK(MaPXK) {
        if (confirm("Bạn có muốn xác nhận phiếu xuất này chứ?")) {
            $.post("cms/user/PhieuXuat/Ajax/XacNhanPhieuXuat.aspx",
                {
                    "MaPXK": MaPXK
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPXK).slideUp();

                    }
                    else
                        alert("Không đủ số lượng để xuất, vui lòng kiểm tra lại!");
                });
        }
    }
</script>