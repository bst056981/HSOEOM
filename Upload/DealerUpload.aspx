<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DealerUpload.aspx.cs" Inherits="Upload_DealerUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .pageheader {
            color: black;
            font-size: 18px;
            font-weight: bold;
        }

        .button {
            background-color: #f59638;
            border-color: orange;
            border-width: 1px;
            border-style: solid;
            font-weight: bold;
            height: 26px;
            font-size: 12px;
        }

        .labeltdleft {
            border-right: solid;
            border-color: orange;
            border-right-width: 1px;
            border-right-style: solid;
            border-top: solid;
            border-top-width: 1px;
            border-top-style: solid;
            text-align: left;
            margin-bottom: 0px;
            margin-top: 0px;
            margin-right: 0px;
            padding-left: 10px;
            width: 10%;
            background-color: #f59638;
        }
    </style>
    <p style="margin: 0 auto; max-width: 963px; width: 90%;">
        <label id="lblTitle" class="pageheader" >Dealer Upload</label>
        <label id="lblComment" class="body" style="color: red;" >**********  Warning: All users should be logged out of EOM before uploading file.**********  </label>
        <br />
        <br />
    </p>
    <div style="margin: 0 auto; max-width: 962px; width: 90%; border-color: orange; border-style: solid; border-width: 1px;">
        <table cellspacing="0" cellpadding="0">
            <tr>
                <td style="width: 150px; height: 35px; background-color: #f59638; padding-left: 10px; border-right-color: orange; border-right-style: solid; border-right-width: 1px;">Upload File</td>
                <td>&nbsp;
                     <asp:FileUpload Width="450px" ID="uploadFile" Style="background-color: white;" Height="28" runat="server" />
                    &nbsp;</td>
                <td>
                    <asp:Button Text="Validate & Submit" runat="server" ID="btnSubmit" CssClass="button" OnClick="btnSubmit_Click" /><br />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="margin: 0 auto; max-width: 963px; width: 90%; text-align: center;">
        <br />
        <asp:Label ID="lblSuccess" ForeColor="orange" Text="text" runat="server" Font-Size="14px" /><br />
    </div>
    <br />
    <div runat="server" id="divError" visible="false" style="margin: 0 auto; max-width: 963px; width: 90%; padding: 10px; height: 200px;">
        <span runat="server" id="spanError" style="color: red;"></span>
    </div>
</asp:Content>

