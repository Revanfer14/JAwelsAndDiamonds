<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../CSS/LoginPage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
            <h1>Login</h1>

            <div class="container">
                <div>
                    <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
                    <br />
                    <asp:TextBox ID="emailTb" runat="server" TextMode="Email" placeholder="revan@gmail.com"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="passwordTb" runat="server" placeholder="••••••••" TextMode="Password"></asp:TextBox>
                </div>

                <div class="checkbox-container">
                    <asp:CheckBox ID="rememberMe" Text="Remember me" runat="server" CssClass="custom-checkbox" />
                </div>


                <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Visible="false" Text="Invalid credentials!"></asp:Label>

                <asp:Button ID="loginBtn" OnClick="loginBtn_Click" runat="server" Text="Login" />

                <p>
                    Don't have an account?
                    <asp:HyperLink ID="registerHl" runat="server" NavigateUrl="RegisterPage.aspx" Text="Register here" />
                </p>
            </div>
        </div>
    </form>
</body>
</html>
