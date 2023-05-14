<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoTriBaoDuongLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.BaoTriBaoDuong.BaoTriBaoDuongLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThietBi&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách đang bảo trì bảo dưỡng</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi15 table_heading">Mã thiết bị</th>
            <th class="tb_mi30 table_heading">Tên thiết bị</th>
            <th class="tb_mi20 table_heading">Ngày bảo dưỡng</th>
            <th class="tb_mi20 table_heading">Trạng thái</th>
            <th class="tb_mi15 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb_btbd" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemThietBiBaoTri" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=BaoTriBaoDuong&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=BaoTriBaoDuong&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function HoanTat(MaTB) {
        if (confirm("Bạn có chắc rằng thiết bị này đã hoàn tất bảo trì/bảo dưỡng chứ?")) {
            $.post("cms/admin/ThietBi/BaoTriBaoDuong/Ajax/BaoTriBaoDuong.aspx",
                {
                    "MaTB": MaTB
                },
                function (data, status) {
                    if (data != 1) {
                        alert("Thất bại");
                    }
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaTB).slideUp();

                    }
                });
        }
    }
</script>