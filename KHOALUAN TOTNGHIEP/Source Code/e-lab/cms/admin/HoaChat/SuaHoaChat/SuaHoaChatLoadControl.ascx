<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaHoaChatLoadControl.ascx.cs" Inherits="e_lab.cms.admin.HoaChat.SuaHoaChat.SuaHoaChatLoadControl" %>

<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/Admin.aspx?modul=HoaChat&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>
    <div class="heading-text">Chỉnh sửa thông tin hóa chất <%=getmahc() %></div>
</div>

<div class="ThaoTac-PhongLab">
    
    <div class="ThongTin">
        <div class="Label">Tên hóa chất</div>
        <div class="Input">
            <asp:TextBox ID="TenHC" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_tenhc" runat="server" ControlToValidate="TenHC" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">CTHH</div>
        <div class="Input">
            <asp:TextBox ID="CTHH" CssClass ="css-input" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_cthh" runat="server" ControlToValidate="CTHH" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
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
    <div class="ThongTin <%--middle-child--%>">
        <div class="Label">Đơn vị tính</div>
        <div class="Input">
            <asp:TextBox ID="DVT" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="ThongTin">
        <div class="Label">Hạn sử dụng</div>
        <div class="Input">
            <asp:TextBox ID="HSD" CssClass ="css-input" runat="server"></asp:TextBox>
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
        <div class="Label">Ghi chú</div>
        <div class="Input">
            <asp:TextBox ID="GhiChu" CssClass ="css-input" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btncapnhat" Class="btnThem" runat="server" Text="Cập nhật" OnClick="btn_themnsx_Click"  />
    <asp:Button ID="btnreset" Class="btnThem" runat="server" Text="Nhập lại" OnClick="btn_nhaplai_themnsx_Click" />
</div>