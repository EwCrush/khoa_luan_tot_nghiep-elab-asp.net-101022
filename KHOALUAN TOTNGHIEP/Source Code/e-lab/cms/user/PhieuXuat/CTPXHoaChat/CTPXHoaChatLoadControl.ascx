<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTPXHoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuXuat.CTPXHoaChat.CTPXHoaChatLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=PhieuXuatDangChoXacNhan&trang=1"" class="Back" >
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách hóa chất trong phiếu xuất <%=getmapxk() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi60 table_heading">Tên hóa chất</th>
            <th class="tb_mi25 table_heading">Số lượng</th>
            <th class="tb_mi15 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/User.aspx?modul=ThemCTPXHoaChat&mapxk=<%=getmapxk() %>" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/User.aspx?modul=CTPXHoaChat&mapxk=<%=getmapxk() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=CTPXHoaChat&mapxk=<%=getmapxk() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaCTPXHC(MaPXK, MaHC) {
        if (confirm("Bạn có muốn xóa hóa chất này ra khỏi phiếu xuất chứ?")) {
            $.post("cms/user/PhieuXuat/Ajax/XoaCTPXHoaChat.aspx",
                {
                    "MaPXK": MaPXK,
                    "MaHC": MaHC
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaHC).slideUp();

                    }
                });
        }
    }
</script>