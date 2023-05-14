<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuaPhieuNhapLoadControl.ascx.cs" Inherits="e_lab.cms.user.PhieuNhap.SuaPhieuNhap.SuaPhieuNhapLoadControl" %>


<div class="to-do-heading">
    <div class="to-do-heading-icon-list">
        <a href="/User.aspx?modul=<%=getmodul() %>&trang=1" class="Back" <%--style="color:#fff; text-decoration: none"--%>>
            <i class="to-do-heading-icon fa-solid fa-circle-chevron-left" title=" Quay lại"></i>
        </a>
    </div>

    <div class="heading-text">Cập nhật thông tin cho phiếu nhập <%=getmapx() %></div>
</div>

<div class="ThaoTac-PhongLab">
    <div class="ThongTin">
        <div class="Label">Ngày lập</div>
        <div class="Input">
            <asp:TextBox ID="ngaylap" CssClass ="css-input" runat="server"></asp:TextBox>
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
    <asp:Button ID="CapNhat" CssClass="btnThem" runat="server" Text="Cập nhật" OnClick="CapNhat_Click"/>
    <asp:Button ID="NhapLai" CssClass="btnThem" runat="server" Text="Nhập lại" OnClick="NhapLai_Click" />
</div>
