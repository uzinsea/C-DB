<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="WebApplication1_3.Coustormer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        
        .auto-style1 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            font-weight: 700;
        }
        .auto-style2 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            width: 602px;
            text-align: right;
            margin-top: 19px;
        }
        .auto-style3 {
            font-weight: 700;
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
        }
        .auto-style4 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
        }
        .auto-style6 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            font-weight: 700;
        }
        #form1 {
            text-align: center;
        }
        .auto-style7 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            font-weight: 700;
        }
        .auto-style8 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #000000; color: #FFFFFF">
        <p class="auto-style8">&nbsp;</p>
        <p class="auto-style8">&nbsp;</p>
        <p class="auto-style8"><strong>!!Welcome Our site!!</strong></p>
        <div>
            <span class="auto-style1">User ID&nbsp;</span>&nbsp;&nbsp;
            <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
        </div>
        <p>
            <strong class="auto-style2">Password</strong>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbPwd" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p class="auto-style3">
            Name&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        </p>
        <p>
            <strong class="auto-style4">Birth</strong>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbBirth" runat="server" TextMode="Date"></asp:TextBox>
        </p>
            <asp:RadioButtonList ID="rbSex" runat="server" style="text-align: center; margin-left: 0px; margin-right: 337px; margin-top: 2px; font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; font-weight: 700;" Width="1484px">
                <asp:ListItem>male</asp:ListItem>
                <asp:ListItem>female</asp:ListItem>
            </asp:RadioButtonList>
        <p class="auto-style7">
            Phone<strong>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbPhone" runat="server" CssClass="auto-style2" Width="177px"></asp:TextBox>
            </strong>
        </p>
        <p>
            <asp:Button ID="btnSign" runat="server" Text="Sign Up" Width="238px" BackColor="#9933FF" ForeColor="White" OnClick="btnSign_Click" CssClass="auto-style6" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
