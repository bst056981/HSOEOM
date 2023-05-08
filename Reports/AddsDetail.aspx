<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddsDetail.aspx.cs" Inherits="Reports_AddsDetail" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary" runat="Server" ShowSummary="true" DisplayMode="BulletList"
        ValidationGroup="errorGroup" HeaderText="Following error occured." Style="margin-right: 0px" />
    <style type="text/css">
        #main {
            width: 969px;
            position: relative;
            margin: auto;
        }
    </style>
    <h3 style="text-align: center;">ADDS Detail</h3>
    <table class="igoogle-summer" width="969px">
        <tr>
            <th>Type:
            </th>
            <td>
                <asp:DropDownList ID="ddlTypeAdds" runat="server" OnClick="ddlTypeAdds_Click" AutoPostBack="true">
                    <asp:ListItem Value="CLEC" Selected="True">CLEC</asp:ListItem>
                    <asp:ListItem Value="ILEC">ILEC</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="dsAddsDetail" SkinID="igoogle-summer" DataKeyNames="ID"
        AutoGenerateColumns="False" Width="969px" AllowPaging="False" EnableTheming="True" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="DICE" HeaderText="DICE" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="NAME" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="TYPE" HeaderText="Type" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="PANEL" HeaderText="Panel" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="DEALER" HeaderText="Dealer" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="START_DATE" HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="MAP" HeaderText="Map" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="BRANCH" HeaderText="Branch" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="REP" HeaderText="Rep" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="SERVICE" HeaderText="Service" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="TECH" HeaderText="Tech" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="BAN" HeaderText="BAN" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="RATE" HeaderText="Rate" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:n2}" />
        </Columns>
        <PagerStyle Font-Underline="True" />
        <EmptyDataTemplate>
            <table class="igoogle-summer grid datatable" width="916px">
                <tr>
                    <td colspan="4">No ADDS for selected filters
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EditRowStyle Font-Underline="True" />
        <AlternatingRowStyle Font-Underline="False" />
    </asp:GridView>
    <asp:SqlDataSource ID="dsAddsDetail" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT CLEC_ADDS_ID AS ID, DICE, NAME, TYPE, PANEL, DEALER, START_DATE, MAP, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE FROM CLEC_ADDS WHERE :typeAdds = 'CLEC' UNION ALL SELECT ILEC_ADDS_ID AS ID, DICE, NAME, TYPE, PANEL, DEALER, START_DATE, MAP, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE FROM ILEC_ADDS WHERE :typeAdds = 'ILEC'">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTypeAdds" Name="typeAdds" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsAddsDetailExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DICE, NAME, TYPE, PANEL, DEALER, START_DATE, MAP, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE FROM CLEC_ADDS WHERE :typeAdds = 'CLEC' UNION ALL SELECT DICE, NAME, TYPE, PANEL, DEALER, START_DATE, MAP, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE FROM ILEC_ADDS WHERE :typeAdds = 'ILEC'">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTypeAdds" Name="typeAdds" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
