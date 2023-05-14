<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhanVienLoadControl.ascx.cs" Inherits="e_lab.cms.user.NhanVien.NhanVienLoadControl" %>

<div class="to-do-heading">

    <div class="heading-text no-icon-link">Danh sách nhân viên thuộc <%=getmadv() %></div>
    <div class="search">
            <div class="tk">
                <asp:TextBox ID="iptk" CssClass ="cssiptk" runat="server"></asp:TextBox>
                <a href="/User.aspx?modul=TimKiemNhanVien&keyword=<%=get_iptk() %>&trang=1" class="ThemMoi">
                    <i class="tk-icon fa-solid fa-magnifying-glass" title="Tìm kiếm"></i>
                </a>
            </div> 
      </div>
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
    <div class="pagination floatleft-item">
        <a href="/User.aspx?modul=ThemNV" class="ThemMoi">
            <i class="to-do-heading-icon fa-solid fa-circle-plus" title="Thêm"></i>
        </a>
    </div>
    <div class="pagination">
        <a href="/User.aspx?modul=NhanVien&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/User.aspx?modul=NhanVien&trang=<%=getnext() %>" class="ThemMoi">
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