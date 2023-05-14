<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThietBiLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.ThietBiLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=BaoTriBaoDuong&trang=1" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-bell" title="Danh sách thiết bị đang bảo trì bảo dưỡng"></i>
            <span class="notify"><%=dsbtbd() %></span>
        </a>
    </div>

    <div class="heading-text">Danh sách thiết bị</div>
    <div class="search">
            <div class="tk">
                <asp:TextBox ID="iptk" CssClass ="cssiptk" runat="server"></asp:TextBox>
                <a href="/Admin.aspx?modul=TimKiemThietBi&keyword=<%=get_iptk() %>&trang=1" class="ThemMoi">
                    <i class="tk-icon fa-solid fa-magnifying-glass" title="Tìm kiếm"></i>
                </a>
            </div> 
      </div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_col_10_percent table_heading">Mã thiết bị</th>
            <th class="tb_col_20_percent table_heading">Tên thiết bị</th>
            <th class="tb_col_15_percent table_heading">Ngày nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng xuất</th>
            <th class="tb_col_10_percent table_heading">Số lượng tồn</th>
            <th class="tb_col_10_percent table_heading">DVT</th>
            <th class="tb_col_15_percent table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemThietBi" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=ThietBi&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=ThietBi&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function XoaTB(MaTB, SoLuongXuat) {
        if (confirm("Bạn có muốn xóa thiết bị  này chứ?")) {
            $.post("cms/admin/ThietBi/Ajax/ThietBi.aspx",
                {
                    "MaTB": MaTB,
                    "SoLuongXuat": SoLuongXuat
                },
                function (data, status) {
                    if (data != 1) {
                        alert("Vui lòng thu hồi tất cả thiết bị cần xóa từ các khoa về trung tâm trước khi thực hiện xóa");
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