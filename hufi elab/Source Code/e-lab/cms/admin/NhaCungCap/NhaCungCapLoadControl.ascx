<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhaCungCapLoadControl.ascx.cs" Inherits="e_lab.cms.admin.NhaCungCap.NhaCungCapLoadControl" %>

<div class="to-do-heading">
    <%--<div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThemNCC" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-bell" title="Thêm"></i>
            <span class="notify">3</span>
        </a>
    </div>--%>

    <div class="heading-text no-icon-link">Danh sách nhà cung cấp</div>
    <div class="search">
            <div class="tk">
                <asp:TextBox ID="iptk" CssClass ="cssiptk" runat="server"></asp:TextBox>
                <a href="/Admin.aspx?modul=TimKiemNhaCungCap&keyword=<%=get_iptk() %>&trang=1" class="ThemMoi">
                    <i class="tk-icon fa-solid fa-magnifying-glass" title="Tìm kiếm"></i>
                </a>
            </div> 
      </div>
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
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemNCC" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=NhaCungCap&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=NhaCungCap&trang=<%=getnext() %>" class="ThemMoi">
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