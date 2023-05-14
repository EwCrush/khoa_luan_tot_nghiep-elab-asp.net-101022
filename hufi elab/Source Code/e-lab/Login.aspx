<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="e_lab.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="cms/admin/css/cssLogin.css" rel="stylesheet" />
    <link href = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap&subset=vietnamese" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/8.0.1/normalize.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="cms/admin/js/jquery.js"></script>
</head>
<body>
    <form id="form1" class="main" runat="server">
    <div>
        <div class="login-container">
            <div class="username-password">
                <i class="up-icon fa-solid fa-user"></i>
                <asp:TextBox ID="txtusername" CssClass="login-textbox" runat="server" Placeholder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtusername" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
            </div>
            <div class="username-password">
                <i class="up-icon fa-solid fa-lock"></i>
                <asp:TextBox ID="txtpassword" CssClass="login-textbox" Placeholder="Password" Type="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpassword" display="Dynamic" setfocusonerror="true"></asp:RequiredFieldValidator>
            </div>
            <div class="submit">
                <asp:LinkButton ID="btdn" CssClass="dangnhap" runat="server" OnClick="btdn_Click">ĐĂNG NHẬP</asp:LinkButton>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
