﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <br />
    <asp:TextBox ID="txtCaptchaCode" runat="server"></asp:TextBox>
    <br />
    <asp:Image ID="imgCaptchaImage" runat="server" />
    <br />
    <asp:Button ID="btnCheckCaptcha" 
            runat="server" 
            onclick="btnCheckCaptcha_Click" 
            Text="Check Captcha" />
    </form>
</body>
</html>
