<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhongLabLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhongLab.PhongLabLoadControl" %>

<div class="to-do-heading">
    <div class="heading-text no-icon-link">Danh sách phòng lab</div>
    <div class="search">
            <div class="tk">
                <asp:TextBox ID="iptk" CssClass ="cssiptk" runat="server"></asp:TextBox>
                <a href="/Admin.aspx?modul=TimKiemPhongLab&keyword=<%=get_iptk() %>&trang=1" class="ThemMoi">
                    <i class="tk-icon fa-solid fa-magnifying-glass" title="Tìm kiếm"></i>
                </a>
            </div> 
      </div>
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

<div class="pagination-wrapper <%=isOnePage() %>">
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemPL" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=PhongLab&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=PhongLab&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<%--<script type="text/javascript">
    function XoaPhongLab(MaPL) {
        confirm(MaPL);
    }
</script>--%>


<script type="text/javascript">
    function XoaPhongLab (MaPL) {
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
