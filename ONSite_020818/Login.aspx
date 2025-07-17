<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AutomateTRYOUT.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

         <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 10%">
                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                    <%--<tr>
                                <td style="height:13%" >
                                  
                                </td>
                            </tr>--%>
                    <tr>
                        <td style="height: 80%">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 80%">
                <div>
                    <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="height: 13%">
                                <table>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Image ID="imgLogo" runat="server" />
                                            </div>
                                          
                                        </td>
                                        <td valign="middle" align="center" style="width: 700px;">
                                            <div style="text-align: right; width: 75%; padding-left: 100px">
                                                <%--<asp:Panel  ScrollBars="Horizontal" ID="pnlLoginHeading" runat="server" 
                                            BorderColor="#000066" BorderWidth="0px"                                             
                                            Font-Names="Sakkal Majalla" HorizontalAlign="Center">--%>
                                             <%--   <asp:Label ID="lblHeading" runat="server" ForeColor="#583A84" Font-Size="Large" Font-Names="Constantia"
                                                    Text="Sarthrakshak"></asp:Label>--%>
                                            </div>
                                            <%--</asp:Panel>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 80%">
                                            <div style="width: 381px; height: 342px;">

                                             <%--   <asp:Image ID="imgLeftSideImage" runat="server" Height="342px" Width="381px" />--%>
                                            </div>
                                        </td>
                                        <td>
                                            <%--<asp:Label ID="lblApplicationName" runat="server" Text="Sarthrakshak"></asp:Label>--%>
                                            <div style="text-align: center; vertical-align: middle;">
                                                <asp:Login ID="LogAuthenticateUser" runat="server" BorderStyle="Double" Height="188px"
                                                    Width="282px" BorderWidth="1px" OnAuthenticate="LogAuthenticateUser_Authenticate"
                                                    BorderColor="#C3D9FF" BackColor="#E8EEFA" Font-Size="0.9em" DisplayRememberMe="true"
                                                    EnableViewState="true">
                                                    <LoginButtonStyle Width="80px" />
                                                    <LayoutTemplate>
                                                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" style="height: 187px; width: 290px;">
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                Log In
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblClientName" runat="server" AssociatedControlID="UserName" SkinID="Login">Client Name:</asp:Label>
                                                                            </td>
                                                                            <td align="left"> 
                                                                                &nbsp;&nbsp;&nbsp;
                                                                              <asp:DropDownList ID="ddlClientID" runat="server">
                                                                                  <asp:ListItem Value="Automate">Automate</asp:ListItem>
                                                                                   <asp:ListItem Value="HTCGAJ01">HTCGAJ01</asp:ListItem>  
                                                                              </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" SkinID="Login">Username:</asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;&nbsp;
                                                                                <asp:TextBox ID="UserName" runat="server" Width="130px" SkinID="LoginUserDtls"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LogAuthenticateUser">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" SkinID="Login">Password:</asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;&nbsp;
                                                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="130px" SkinID="LoginUserDtls"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LogAuthenticateUser">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                           
                                                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2" style="color: Red;">
                                                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Names="Arial"
                                                                                    Font-Size="X-Small" SkinID="LoginButton" Text="Log In" ValidationGroup="LogAuthenticateUser"
                                                                                    Width="80px" OnClick="LoginButton_Click" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                <asp:LinkButton ID="lbForgotPass" runat="server" Visible="false" Font-Size="X-Small" PostBackUrl="~/ForgetPassword.aspx"
                                                                                    Font-Names="Constantia" SkinID="ForgotPassword">Forgot Password</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                </asp:Login>
                                            </div>
                                            <!--<asp:Image ID="ibtnBgtechlogo" runat="server" />-->
                                            <div style="vertical-align: middle; padding-left: 40px">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                               <%-- <asp:ImageButton ID="btnib" runat="server" ImageUrl="~/App_Themes/Images/logoBGTech.png"
                                                    OnClick="btnib_Click" />--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7%">
                                <table style="width: 100%;">
                                    <tr bgcolor="#C3D9FF">
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr bgcolor="#FDFDFD">
                                        <td colspan="2">
                                         <%--   <asp:Label ID="lblPowerdby0" runat="server" Font-Names="Arial" Font-Size="XX-Small"
                                                ForeColor="Gray" Text="Powered by " SkinID="Copywrite"></asp:Label>
                                            <a href="http:\\www.bgtechsolutions.com">
                                                <asp:Label ID="lblDeveloperCompanyName" runat="server" Font-Names="Arial" Font-Size="XX-Small"
                                                    ForeColor="Gray" Text="BGTech Solutions" SkinID="Copywrite"></asp:Label></a>&copy;
                                            <asp:Label ID="copyright" runat="server" Font-Names="Arial" Font-Size="XX-Small"
                                                ForeColor="Gray" Text="BGTech Solutions. All Rights Reserved." SkinID="Copywrite"></asp:Label>--%>
                                        </td>
                                        <%-- <td align="right">
                                            
                                        </td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td style="width: 10%">
                <div>
                    <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 10%">
                                <div>
                                    <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="height: 13%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#F9F9FB" style="height: 80%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <%--<div>

         <div style="text-align: right; vertical-align: central;">
                                                <asp:Login ID="LogAuthenticateUser" runat="server" BorderStyle="Double" Height="188px"
                                                    Width="282px" BorderWidth="1px" OnAuthenticate="LogAuthenticateUser_Authenticate"
                                                    BorderColor="#C3D9FF" BackColor="#E8EEFA" Font-Size="0.9em" DisplayRememberMe="true"
                                                    EnableViewState="true">
                                                    <LoginButtonStyle Width="80px" />
                                                    <LayoutTemplate>
                                                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" style="height: 187px; width: 290px;">
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                Log In
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblClientName" runat="server" AssociatedControlID="UserName" SkinID="Login">Client Name:</asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;&nbsp;
                                                                              <asp:DropDownList ID="DropDownList1" runat="server">
                                                                                  <asp:ListItem Value="Automate">Automate</asp:ListItem>
                                                                                   <asp:ListItem Value="HTCGAJ01">HTCGAJ01</asp:ListItem>  
                                                                              </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" SkinID="Login">Username:</asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;&nbsp;
                                                                                <asp:TextBox ID="UserName" runat="server" Width="130px" SkinID="LoginUserDtls"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LogAuthenticateUser">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" SkinID="Login">Password:</asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;&nbsp;
                                                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="130px" SkinID="LoginUserDtls"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LogAuthenticateUser">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                           
                                                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2" style="color: Red;">
                                                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Names="Arial"
                                                                                    Font-Size="X-Small" SkinID="LoginButton" Text="Log In" ValidationGroup="LogAuthenticateUser"
                                                                                    Width="80px" OnClick="LoginButton_Click" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                <asp:LinkButton ID="lbForgotPass" runat="server" Font-Size="X-Small" PostBackUrl="~/ForgetPassword.aspx"
                                                                                    Font-Names="Constantia" SkinID="ForgotPassword">Forgot Password</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </LayoutTemplate>
                                                </asp:Login>
                                            </div>
    
    </div>--%>
    </form>
</body>
</html>
