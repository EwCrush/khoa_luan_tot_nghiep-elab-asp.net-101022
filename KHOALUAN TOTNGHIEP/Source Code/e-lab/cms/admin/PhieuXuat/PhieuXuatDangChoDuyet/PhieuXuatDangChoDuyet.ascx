<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuXuatDangChoDuyet.ascx.cs" Inherits="e_lab.cms.admin.PhieuXuat.PhieuXuatDangChoDuyet.PhieuXuatDangChoDuyet" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhieuXuat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu xuất đang chờ duyệt</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi10 table_heading">Mã phiếu xuất</th>
            <th class="tb_mi15 table_heading">Ngày lập</th>
            <th class="tb_mi15 table_heading">Nhân viên lập</th>
            <th class="tb_mi20 table_heading">Tên đơn vị</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi15 table_heading">Chi tiết phiếu xuất</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=PhieuXuatDangChoDuyet&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=PhieuXuatDangChoDuyet&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function TuChoiDuyetPX(MaPX, MaDV) {
        if (confirm("Bạn có muốn từ chối duyệt phiếu xuất này chứ?")) {
            $.post("cms/admin/PhieuXuat/PhieuXuatDangChoDuyet/Ajax/TuChoi.aspx",
                {
                    "MaPX": MaPX,
                    "MaDV": MaDV
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
    function DuyetPX(MaPX, MaDV) {
        if (confirm("Bạn có muốn duyệt phiếu xuất này chứ?")) {
            $.post("cms/admin/PhieuXuat/PhieuXuatDangChoDuyet/Ajax/DuyetPhieuXuat.aspx",
                {
                    "MaPX": MaPX,
                    "MaDV": MaDV
                },
                function (data, status) {
                    //alert(data);
                    if (data == 1) {
                        alert(status);
                            //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPX).slideUp();

                    }
                    else
                        alert("Không đủ số lượng để xuất, vui lòng kiểm tra lại!");
                });
        }
    }
</script>