<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Secure_Login"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="mv1" runat="server">
    <asp:View ID="vNotLoggedIn" runat="server">
        <div id="div1" runat="server">
            <span style="font-family:Calibri;font-size:large;text-align:center" runat="server">HSO EOM Login</span>
        </div>
        <div ID="div2" runat="server">
            <link ID="link1" runat="server" rel="shortcut icon" href="images/BSicon.ico" type="image/vnd.microsoft.icon" />
            <link ID="link2" runat="server" href="Login.css" rel="stylesheet" />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logoBS.jpg" AlternateText="Brightspeed" Height="71" Width="230" />
        </div>
        <div ID="div3" runat="server">
            <table>
                <tr>
                    <td style="text-align:left; width:40%">
                        <asp:Label ID="Lable1" runat="server" Text="CUID"></asp:Label>
                    </td>
                    <td style="text-align:left; width:50%">
                        <asp:TextBox ID="txtUserName" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left; width:40%">
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td style="text-align:left; width=50%">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width:40%">
                <tr>
                    <td style="text-align:center; width:100%">
                        <asp:Button ID="cmdLogin"  runat="server" CssClass="btn btn-primary" Text="Login" Width="30%" OnClick="cmdLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; width:40%">
                        <asp:Label ID="lblResponse" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:View>
    </asp:MultiView>
</asp:Content>