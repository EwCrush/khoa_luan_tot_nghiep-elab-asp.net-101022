<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTPNDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.CTPNDungCu.CTPNDungCuLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=<%=getmodul() %>&trang=1"" class="Back" >
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách dụng cụ trong phiếu xuất <%=getmapx() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi60 table_heading">Tên dụng cụ</th>
            <th class="tb_mi25 table_heading">Số lượng</th>
            <th class="tb_mi15 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/User.aspx?modul=ThemCTPNDungCu&mapx=<%=getmapx() %>" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/User.aspx?modul=CTPNDungCu&mapx=<%=getmapx() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=CTPNDungCu&mapx=<%=getmapx() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaCTPNDC(MaPX, MaDC) {
        if (confirm("Bạn có muốn xóa dụng cụ này ra khỏi phiếu nhập chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/XoaCTPXDungCu.aspx",
                {
                    "MaPX": MaPX,
                    "MaDC": MaDC
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaDC).slideUp();

                    }
                });
        }
    }
</script>