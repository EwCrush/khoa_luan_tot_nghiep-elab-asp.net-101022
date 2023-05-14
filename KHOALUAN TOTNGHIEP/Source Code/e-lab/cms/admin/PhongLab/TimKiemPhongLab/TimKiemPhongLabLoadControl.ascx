<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiemPhongLabLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhongLab.TimKiemPhongLab.TimKiemPhongLab" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhongLab&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Danh sách phòng lab tên <%=get_keyword() %></div>
</div>


<table class="table">
        <tr class="table_row">
            <th class="tb_mapl table_heading">Mã phòng lab</th>
            <th class="tb_tenpl table_heading">Tên phòng lab</th>
            <th class="tb_diachi table_heading">Địa chỉ</th>
            <th class="tb_thaotac table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_phonglab" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper ">
    <div class="pagination">
        <a href="/Admin.aspx?modul=TimKiemPhongLab&keyword=<%=get_keyword() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=TimKiemPhongLab&keyword=<%=get_keyword() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaPhongLab(MaPL) {
        if (confirm("Bạn có muốn xóa phòng lab này chứ?")) {
            $.post("cms/admin/PhongLab/Ajax/PhongLab.aspx",
                {
                    //"ThaoTac": "XoaPhongLab",
                    "MaPL": MaPL
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPL).slideUp();

                    }
                });
        }
    }
</script>