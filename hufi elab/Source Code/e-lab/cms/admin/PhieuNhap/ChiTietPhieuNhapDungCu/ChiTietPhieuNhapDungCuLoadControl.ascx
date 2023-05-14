<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietPhieuNhapDungCuLoadControl.ascx.cs" Inherits="e_lab.cms.admin.PhieuNhap.ChiTietPhieuNhapDungCu.ChiTietPhieuNhapDungCuLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=PhieuNhapDangChoXacNhan&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách dụng cụ trong phiếu nhập <%=getmapn() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_mi60 table_heading">Tên dụng cụ</th>
            <th class="tb_mi25 table_heading">Số lượng</th>
            <th class="tb_mi15 table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_tb" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination floatleft-item">
        <a href="/Admin.aspx?modul=ThemChiTietPhieuNhapDungCu&mapn=<%=getmapn() %>" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/Admin.aspx?modul=ChiTietPhieuNhapDungCu&mapn=<%=getmapn() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=ChiTietPhieuNhapDungCu&mapn=<%=getmapn() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaCTPNDC(MaPN, MaDC) {
        if (confirm("Bạn có muốn xóa dụng cụ này ra khỏi phiếu nhập chứ?")) {
            $.post("cms/admin/PhieuNhap/ChiTietPhieuNhapDungCu/Ajax/ChiTietPhieuNhapDungCu.aspx",
                {
                    "MaPN": MaPN,
                    "MaDC": MaDC
                },
                function (data, status) {
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaDC).slideUp();

                    }
                });
        }
    }
</script>