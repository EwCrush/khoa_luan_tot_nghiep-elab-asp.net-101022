<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTPNHoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.CTPNHoaChat.CTPNHoaChatLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=<%=getmodul() %>&trang=1"" class="Back" >
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách hóa chất trong phiếu xuất <%=getmapx() %></div>
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
        <a href="/User.aspx?modul=ThemCTPNHoaChat&mapx=<%=getmapx() %>" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/User.aspx?modul=CTPNHoaChat&mapx=<%=getmapx() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=CTPNHoaChat&mapx=<%=getmapx() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaCTPNHC(MaPX, MaHC) {
        if (confirm("Bạn có muốn xóa hóa chất này ra khỏi phiếu nhập chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/XoaCTPXHoaChat.aspx",
                {
                    "MaPX": MaPX,
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