<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimKiemNhanVienLoadControl.ascx.cs" Inherits="e_lab.cms.user.NhanVien.TimKiemNhanVien.TimKiemNhanVienLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=NhanVien&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách nhân viên có tên <%=get_keyword() %> trong <%=getmadv() %></div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_manv table_heading">Mã nhân viên</th>
            <th class="tb_tennv table_heading">Tên nhân viên</th>
            <th class="tb_gioitinh table_heading">Giới tính</th>
            <th class="tb_ngaysinh table_heading">Ngày sinh</th>
            <th class="tb_sdtnv table_heading">SDT</th>
            <th class="tb_diachinv table_heading">Địa chỉ</th>
            <th class="tb_donvinv table_heading">Đơn vị</th>
            <th class="tb_chucvunv table_heading">Chức vụ</th>
            <th class="tb_thaotacnv table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_nv" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/User.aspx?modul=TimKiemNhanVien&keyword=<%=get_keyword() %>&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=TimKiemNhanVien&keyword=<%=get_keyword() %>&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function XoaNV(MaNV) {
        if (confirm("Bạn có muốn xóa nhân viên này chứ?")) {
            $.post("cms/admin/NhanVien/Ajax/NhanVien.aspx",
                {
                    "MaNV": MaNV
                },
                function (data, status) {
                    if (status == "success") {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa xóa đi
                        $("#Line" + MaNV).slideUp();

                    }
                });
        }
    }
</script>