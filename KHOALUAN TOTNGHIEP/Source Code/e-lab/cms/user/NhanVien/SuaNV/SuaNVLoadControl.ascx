<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaNVLoadControl.ascx.cs" Inherits="e_lab.cms.user.NhanVien.SuaNV.SuaNVLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=NhanVien&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Chỉnh sửa thông tin nhân viên <%=getmanv() %></div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Tên nhân viên</div>
        <div class="Input">
            <asp:TextBox ID="tennv" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_tennv" runat="server" ControlToValidate="tennv" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Giới tính</div>
        <div class="Input">
            <asp:DropDownList CssClass ="css-input" ID="ddl_gioitinh" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Ngày sinh</div>
        <div class="Input">
            <asp:TextBox ID="ngaysinh" CssClass ="css-input" runat="server"></asp:TextBox>
             <asp:Calendar ID="Calendar1" runat="server" DayNameFormat="FirstLetter" Font-Names="Tahoma" Font-Size="11px" NextMonthText="." PrevMonthText="." SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar" OnSelectionChanged="Calendar1_SelectionChanged"  CellPadding="0">
                <OtherMonthDayStyle ForeColor="#b0b0b0" />
                <DayStyle CssClass="myCalendarDay" ForeColor="#2d3338" />
                <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2d3338" />
                <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
                <TodayDayStyle CssClass="myCalendarToday" />
                <SelectorStyle CssClass="myCalendarSelector" />
                <NextPrevStyle CssClass="myCalendarNextPrev" />
            <TitleStyle CssClass="myCalendarTitle" />
        </asp:Calendar>
        </div>
    </div>
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">SDT</div>
        <div class="Input">
            <asp:TextBox ID="sdtnv" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="sdtnv" ID="RegularExpressionValidator_checksdt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Địa chỉ</div>
        <div class="Input">
            <asp:TextBox ID="DiaChi" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="CapNhat" CssClass="btnThem" runat="server" Text="Cập nhật" OnClick="CapNhat_Click"/>
    <asp:Button ID="NhapLai" CssClass="btnThem" runat="server" Text="Nhập lại" OnClick="NhapLai_Click" />
</div>