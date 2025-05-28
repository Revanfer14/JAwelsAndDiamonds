<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="JAwelsAndDiamonds.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="~/CSS/RegisterPage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
            <h1>Register</h1>

            <div class="container">
                <div>
                    <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
                    <br />
                    <asp:TextBox ID="emailTb" runat="server" TextMode="Email" placeholder="revan@gmail.com"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="usernameLbl" runat="server" Text="Username"></asp:Label>
                    <br />
                    <asp:TextBox ID="usernameTb" runat="server" placeholder="Revan Ferdinand"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="passwordTb" runat="server" placeholder="••••••••" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="confirmLbl" runat="server" Text="Confirm Password"></asp:Label>
                    <br />
                    <asp:TextBox ID="confirmTb" runat="server" placeholder="••••••••" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
                    <br />
                    <asp:RadioButtonList ID="genderRBL" runat="server">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div>
                    <asp:Label ID="dobLbl" runat="server" Text="Date of Birth"></asp:Label>
                    <br />
                    <asp:Calendar ID="dobCalendar" runat="server" VisibleDate="2005-01-01"></asp:Calendar>
                </div>

                 <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Visible="false" Text="Invalid!"></asp:Label>

                <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />

                <p>
                    Already have an account?
                    <asp:HyperLink ID="loginHl" runat="server" NavigateUrl="LoginPage.aspx" Text="Login here" />
                </p>
            </div>

        </div>
    </form>
</body>
</html>
