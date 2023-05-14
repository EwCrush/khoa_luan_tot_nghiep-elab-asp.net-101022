<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhieuNhapLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.PhieuNhapLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=PhieuNhapDangChoDuyet&trang=1" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-bell" title="Danh sách phiếu xuất đang chờ duyệt"></i>
            <span class="notify"><%=dsChoDuyet() %></span>
        </a>
    </div>

    <div class="heading-text">Danh sách phiếu nhập của <%=getmadv() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi10 table_heading">Mã phiếu nhập</th>
            <th class="tb_mi15 table_heading">Ngày lập</th>
            <th class="tb_mi15 table_heading">Nhân viên nhập</th>
            <th class="tb_mi20 table_heading">Tên đơn vị</th>
            <th class="tb_mi15 table_heading">Trạng thái</th>
            <th class="tb_mi15 table_heading">Chi tiết phiếu xuất</th>
            <th class="tb_mi10 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/User.aspx?modul=GuiPhieuNhap&trang=1" class="ThemMoi">
            <i class="to-do-heading-icon fa-sharp fa-solid fa-paper-plane" title="Gửi phiếu nhập"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/User.aspx?modul=GuiPhieuNhap&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=GuiPhieuNhap&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaPX(MaPX) {
        if (confirm("Bạn có muốn xóa phiếu nhập này chứ?")) {
            $.post("cms/user/PhieuNhap/Ajax/PhieuNhap.aspx",
                {
                    "MaPX": MaPX
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaPX).slideUp();

                    }
                });
        }
    }
</script>