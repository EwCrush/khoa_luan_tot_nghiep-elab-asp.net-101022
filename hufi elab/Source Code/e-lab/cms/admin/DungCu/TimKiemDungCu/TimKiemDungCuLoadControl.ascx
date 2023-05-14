<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiemDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.admin.DungCu.TimKiemDungCu.TimKiemDungCu" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=DungCu&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Danh sách dụng cụ có tên <%=getkeyword() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_col_10_percent table_heading">Mã dụng cụ</th>
            <th class="tb_col_20_percent table_heading">Tên dụng cụ</th>
            <th class="tb_col_15_percent table_heading">Ngày nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng xuất</th>
            <th class="tb_col_10_percent table_heading">Số lượng tồn</th>
            <th class="tb_col_10_percent table_heading">DVT</th>
            <th class="tb_col_15_percent table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_dc" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=TimKiemDungCu&keyword=<%=getkeyword() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=TimKiemDungCu&keyword=<%=getkeyword() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function XoaDC(MaDC, SoLuongXuat) {
        if (confirm("Bạn có muốn xóa dụng cụ này chứ?")) {
            $.post("cms/admin/DungCu/Ajax/DungCu.aspx",
                {
                    "MaDC": MaDC,
                    "SoLuongXuat": SoLuongXuat
                },
                function (data, status) {
                    if (data != 1) {
                        alert("Vui lòng thu hồi tất cả dụng cụ cần xóa từ các khoa về trung tâm trước khi thực hiện xóa");
                    }
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaDC).slideUp();

                    }
                });
        }
    }
</script>