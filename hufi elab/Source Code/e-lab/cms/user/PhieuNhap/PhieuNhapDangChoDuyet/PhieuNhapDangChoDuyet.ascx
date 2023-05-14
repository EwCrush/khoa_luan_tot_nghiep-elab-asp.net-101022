<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuNhapDangChoDuyet.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.PhieuNhapDangChoDuyet.PhieuNhapDangChoDuyet" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=PhieuNhap&trang=1" class="Back">
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu nhập đang chờ duyệt của <%=getmadv() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi10 table_heading">Mã phiếu nhập</th>
            <th class="tb_mi15 table_heading">Ngày lập</th>
            <th class="tb_mi15 table_heading">Nhân viên nhập</th>
            <th class="tb_mi15 table_heading">Tên đơn vị</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi15 table_heading">Chi tiết phiếu xuất</th>
            <th class="tb_mi15 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=PhieuNhapDangChoDuyet&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=PhieuNhapDangChoDuyet&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaPX(MaPX) {
        if (confirm("Bạn có muốn xóa phiếu nhập này chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/XoaPhieuNhap.aspx",
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

<script type="text/javascript">
    function GuiPhieuNhap(MaPX) {
        if (confirm("Bạn có muốn gửi phiếu nhập này chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/GuiPhieuNhap.aspx",
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

<script type="text/javascript">
    function ThuHoiPX(MaPX) {
        if (confirm("Bạn có muốn thu hồi phiếu nhập này chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/ThuHoi.aspx",
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


<script type="text/javascript">
    function ThemPhieuNhap() {
        if (confirm("Bạn có thêm một phiếu nhập mới?")) {
            $.post("cms/user/PhieuNhap/Ajax/ThemPhieuNhap.aspx",
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                    }
                });
        }
    }
</script>