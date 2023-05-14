<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTPNThietBiLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.CTPNThietBi.CTPNThietBi" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=<%=getmodul() %>&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách thiết bị trong phiếu nhập <%=getmapx() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi30 table_heading">Tên dụng cụ</th>
            <th class="tb_mi40 table_heading">Tên phòng lab</th>
            <th class="tb_mi20 table_heading">Số lượng</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/User.aspx?modul=ThemCTPNThietBi&mapx=<%=getmapx() %>" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/User.aspx?modul=CTPNThietBi&mapx=<%=getmapx() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=CTPNThietBi&mapx=<%=getmapx() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaCTPNTB(MaPX, MaTB, MaPL) {
        if (confirm("Bạn có muốn xóa thiết bị này ra khỏi phiếu nhập chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/XoaCTPXThietBi.aspx",
                {
                    "MaPX": MaPX,
                    "MaTB": MaTB,
                    "MaPL": MaPL,
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaTB).slideUp();

                    }
                });
        }
    }
</script>