<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.admin.HoaChat.HoaChatLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=HoaChatHetHan&trang=1" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-bell" title="Danh sách hóa chất đã hết hạn sử dụng"></i>
            <span class="notify"><%=dshethsd() %></span>
        </a>
    </div>

    <div class="heading-text">Danh sách hóa chất</div>
    <div class="search">
            <div class="tk">
                <asp:TextBox ID="iptk" CssClass ="cssiptk" runat="server"></asp:TextBox>
                <a href="/Admin.aspx?modul=TimKiemHoaChat&keyword=<%=get_iptk() %>&trang=1" class="ThemMoi">
                    <i class="tk-icon fa-solid fa-magnifying-glass" title="Tìm kiếm"></i>
                </a>
            </div> 
      </div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_col_10_percent table_heading">Mã hóa chất</th>
            <th class="tb_col_15_percent table_heading">Tên hóa chất</th>
            <th class="tb_col_10_percent table_heading">CTHH</th>
            <th class="tb_col_10_percent table_heading">Ngày nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng xuất</th>
            <th class="tb_col_10_percent table_heading">Số lượng tồn</th>
            <th class="tb_col_10_percent table_heading">DVT</th>
            <th class="tb_col_15_percent table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_hc" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemHoaChat" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=HoaChat&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=HoaChat&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>


<script type="text/javascript">
    function XoaHC(MaHC, SoLuongXuat) {
        if (confirm("Bạn có muốn xóa hóa chất này chứ?")) {
            $.post("cms/admin/HoaChat/Ajax/HoaChat.aspx",
                {
                    "MaHC": MaHC,
                    "SoLuongXuat": SoLuongXuat
                },
                function (data, status) {
                    if (data != 1) {
                        alert("Vui lòng thu hồi tất cả hóa chất cần xóa từ các khoa về trung tâm trước khi thực hiện xóa");
                    }
                if (data == 1) {
                    alert(status);
                    //    //thực hiện thành công => ẩn dòng vừa xóa đi
                    $("#Line" + MaHC).slideUp();

                }
                });
        }
    }
</script>