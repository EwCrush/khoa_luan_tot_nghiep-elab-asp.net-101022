<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemThietBiLoadControl.ascx.cs" Inherits="e_lab.cms.admin.ThietBi.ThemThietBi.ThemThietBiLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=ThietBi&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Thêm thiết bị</div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin">
        <div class="Label">Tên thiết bị</div>
        <div class="Input">
            <asp:TextBox ID="TenTB" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_TenTB" runat="server" ControlToValidate="TenTB" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Nhà sản xuất</div>
        <div class="Input">
            <asp:DropDownList ID="ddl_nsx" CssClass ="css-input" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Nhà cung cấp</div>
        <div class="Input">
            <asp:DropDownList ID="ddl_ncc" CssClass ="css-input" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Số lượng tồn</div>
        <div class="Input">
            <asp:TextBox ID="SoLuongTon" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_soluongton" runat="server" ControlToValidate="SoLuongTon" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="validator-text" ControlToValidate="SoLuongTon" ID="RegularExpressionValidator_checkslt" SetFocusOnError="true" Display="Dynamic" ValidationExpression="(\d)*" runat="server" ErrorMessage="Giá trị nhập vào phải là kiểu số"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Đơn vị tính</div>
        <div class="Input">
            <asp:TextBox ID="DVT" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Ngày bảo dưỡng</div>
        <div class="Input">
            <asp:TextBox ID="NgayBaoDuong" CssClass ="css-input" runat="server"></asp:TextBox>
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
    <asp:Button ID="btthem" Class="btnThem" runat="server" Text="Thêm" OnClick="btn_them_Click" />
    <asp:Button ID="btnsua" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_Click" />
</div>