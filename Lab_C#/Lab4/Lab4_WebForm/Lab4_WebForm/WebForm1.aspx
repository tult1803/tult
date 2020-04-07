<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab4_WebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 302px;
            width: 579px;
        }
    </style>
</head>
<body style="height: 289px; width: 582px">
    <form id="form1" runat="server">
        <asp:Label ID="lblF" runat="server" Text="From" Width="50px" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt1" runat="server" Height="20px" style="margin-left: 19px; margin-top: 21px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;Việt Nam&nbsp;(
        <asp:Label ID="lbl1" runat="server" Text="VNĐ"></asp:Label>
        )<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="btnSwitch" runat="server" Height="66px" ImageUrl="~/Image/switch.png" OnClick="btnSwitch_Click" Width="70px" />
        <br />
        <br />
&nbsp;<asp:Label ID="lblT" runat="server" Text="To             " Width="50px" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt2" runat="server" Height="20px" Width="200px" Enabled="False"></asp:TextBox>
        <asp:DropDownList ID="list" runat="server" Height="20px" Width="200px" AutoPostBack="True">
            <asp:ListItem Value="AUD">AUST DOLLAR ( AUD )</asp:ListItem>
            <asp:ListItem Value="EUR">EURO ( EUR )</asp:ListItem>
            <asp:ListItem Value="GBP">BRITISH POUND ( GBP )</asp:ListItem>
            <asp:ListItem Value="HKD">HONGKONG DOLLAR ( HKD )</asp:ListItem>
            <asp:ListItem Value="JPY">JAPANESE YEN ( JPY )</asp:ListItem>
            <asp:ListItem Value="SGD">SINGAPORE DOLLAR ( SGD )</asp:ListItem>
            <asp:ListItem Value="THB">THAI BAHT ( THB )</asp:ListItem>
            <asp:ListItem Value="USD">US DOLLAR ( USD )</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCon" runat="server" OnClick="btnCon_Click" Text="Convert" />
        <br />
        <br />
&nbsp;<strong>Status </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" Height="20px" Text="Ready" Width="100px"></asp:Label>
    </form>
</body>
</html>
