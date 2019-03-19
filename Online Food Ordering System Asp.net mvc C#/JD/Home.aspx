<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Default2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;
    <asp:Button ID="Button2" runat="server" Style="left: 0px; position: relative; top: 28px; font-weight: bold; font-size: 15pt; background-image: url(Images/pF002275[1].jpg); color: #6600ff; font-style: italic; font-variant: small-caps;"
        Text="Products" Height="33px" Width="117px" />&nbsp;
    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="RedirectToLoginPage" Style="left: 80px; position: relative; top: 149px; font-weight: bold; font-size: 15pt; color: #6600ff; font-style: italic;"
        Width="71px" Height="26px" />
    <asp:Button ID="Button1" runat="server" Style="left: -29px; position: relative; top: 31px; font-weight: bold; font-size: 15pt; background-image: url(Images/pF000669[1].jpg); color: #6600ff; font-style: italic; font-variant: small-caps;"
        Text="User Name" Height="35px" Width="117px" />
    &nbsp; &nbsp; &nbsp;
    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
        BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
        ForeColor="#663399" Height="200px" ShowGridLines="True" Style="left: 634px; position: relative;
        top: -20px" Width="220px">
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        <SelectorStyle BackColor="#FFCC66" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
    </asp:Calendar>
    <asp:Button ID="Button3" runat="server" Height="32px" Style="left: 355px;
        position: relative; top: -206px; font-weight: bold; font-size: 15pt; color: #6600ff; font-style: italic; background-color: #ffffff; font-variant: small-caps;" Text="Contact Us" Width="147px" />
    &nbsp;
</asp:Content>

