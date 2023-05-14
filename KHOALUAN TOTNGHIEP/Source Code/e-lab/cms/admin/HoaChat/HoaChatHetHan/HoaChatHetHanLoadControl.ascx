<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoaChatHetHanLoadControl.ascx.cs" Inherits="e_lab.cms.admin.HoaChat.HoaChatHetHan.HoaChatHetHanLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=HoaChat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Danh sách hóa chất hết hạn</div>
</div>

<table class="table">
        <tr class="table_row">
            <th class="tb_col_10_percent table_heading">Mã hóa chất</th>
            <th class="tb_col_15_percent table_heading">Tên hóa chất</th>
            <th class="tb_col_10_percent table_heading">CTHH</th>
            <th class="tb_col_10_percent table_heading">Số lượng nhập</th>
            <th class="tb_col_10_percent table_heading">Số lượng xuất</th>
            <th class="tb_col_10_percent table_heading">Số lượng tồn</th>
            <th class="tb_col_10_percent table_heading">DVT</th>
            <th class="tb_col_10_percent table_heading">Hạn sử dụng</th>
            <th class="tb_col_15_percent table_heading">Thao tác</th>
        </tr>
        <asp:Literal ID="ltr_ds_hc" runat="server"></asp:Literal>
    </table>
<div class="pagination-wrapper">
    <div class="pagination">
        <a href="/Admin.aspx?modul=HoaChatHetHan&trang=<%=getpre() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-left" title="Trang trước"></i>
        </a>
        <div class="pagination-item no-hover">Trang <%=getcurrent() %>/<%=getlast() %></div>
        <a href="/Admin.aspx?modul=HoaChatHetHan&trang=<%=getnext() %>" class="ThemMoi">
            <i class="pagination-item fa-solid fa-chevron-right" title="Trang tiếp"></i>
        </a>
    </div>
</div>

<script type="text/javascript">
    function ThanhLy(MaHC, SoLuongXuat) {
        if (confirm("Bạn có muốn thanh lý hóa chất này chứ?")) {
            $.post("cms/admin/HoaChat/Ajax/HoaChat.aspx",
                {
                    "MaHC": MaHC,
                    "SoLuongXuat": SoLuongXuat
                },
                function (data, status) {
                    if (data != 1) {
                        alert("Vui lòng thu hồi tất cả hóa chất cần thanh lý từ các khoa về trung tâm trước khi thực hiện thanh lý");
                    }
                    if (data == 1) {
                        alert(status);
                        //    //thực hiện thành công => ẩn dòng vừa thanh lý đi
                        $("#Line" + MaHC).slideUp();

                    }
                });
        }
    }
</script>