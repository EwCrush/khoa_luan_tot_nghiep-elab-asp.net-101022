<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiemNhaCungCapLoadControl.ascx.cs" Inherits="e_lab.cms.admin.NhaCungCap.TimKiemNhaCungCap.TimKiemNhaCungCapLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=NhaCungCap&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách nhà cung cấp có tên là <%=get_keyword() %></div>
    
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mancc table_heading">Mã NCC</th>
            <th class="tb_tenncc table_heading">Tên NCC</th>
            <th class="tb_sdtncc table_heading">SDT</th>
            <th class="tb_emailncc table_heading">Email</th>
            <th class="tb_diachincc table_heading">Địa chỉ</th>
            <th class="tb_thaotac table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_ncc" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=TimKiemNhaCungCap&keyword=<%=get_keyword() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=TimKiemNhaCungCap&keyword=<%=get_keyword() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaNCC(MaNCC) {
        if (confirm("Bạn có muốn xóa nhà cung cấp này chứ?")) {
            $.post("cms/admin/NhaCungCap/Ajax/NhaCungCap.aspx",
                {
                    "MaNCC": MaNCC
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaNCC).slideUp();

                    }
                });
        }
    }
</script>