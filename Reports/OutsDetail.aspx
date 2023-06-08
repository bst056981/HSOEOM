<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="OutsDetail.aspx.cs" Inherits="Reports_OutsDetail" Theme="SkinFile" %>

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
    <h3 style="text-align: center;">OUTS Detail</h3>
    <table class="igoogle-summer" width="969px">
        <tr>
            <th width="50px">Type:
            </th>
            <td>
                <asp:DropDownList ID="ddlTypeOuts" runat="server" OnClick="ddlTypeOuts_Click" AutoPostBack="true">
                    <asp:ListItem Value="CLEC" Selected="True">CLEC</asp:ListItem>
                    <asp:ListItem Value="ILEC">ILEC</asp:ListItem>
                </asp:DropDownList>
            </td>
            <th>Year:
            </th>
            <td width="700px">
                <asp:DropDownList ID="ddlDate" runat="server" DataSourceID="dsDate" DataTextField="CUST_CNT_DATE" AutoPostBack="true" OnTextChanged="ddlDate_OnTextChanged"
                    DataValueField="CUST_CNT_DATE">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsDate" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT CUST_CNT_DATE FROM CUSTOMER_COUNT ORDER BY to_date(CUST_CNT_DATE, 'MM-DD-YYYY') DESC "></asp:SqlDataSource>
            </td>
            <td align="right">
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="dsOutsDetail" SkinID="igoogle-summer" DataKeyNames="ID"
        AutoGenerateColumns="False" Width="969px" AllowPaging="False" EnableTheming="True" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="DICE" HeaderText="DICE" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="NAME" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="REASON" HeaderText="Reason" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="PANEL" HeaderText="Panel" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="INACTIVE_DATE" HeaderText="Inactive Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="DEALER" HeaderText="Dealer" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="START_DATE" HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="REP" HeaderText="Rep" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="SERVICE" HeaderText="Service" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
    <asp:SqlDataSource ID="dsOutsDetail" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT CLEC_OUTS_ID AS ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE FROM CLEC_OUTS_KEEP WHERE :typeOuts = 'CLEC' AND SUBSTR(TO_CHAR(INACTIVE_DATE), 1, 2) = SUBSTR(TO_CHAR(:ENTER_DATE), 1, 2) AND SUBSTR(TO_CHAR(INACTIVE_DATE), 7, 4) = SUBSTR(TO_CHAR(:ENTER_DATE), 7, 4) UNION ALL SELECT ILEC_OUTS_ID AS ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE FROM ILEC_OUTS_KEEP WHERE :typeOuts = 'ILEC' AND SUBSTR(TO_CHAR(INACTIVE_DATE), 1, 2) = SUBSTR(TO_CHAR(:ENTER_DATE), 1, 2) AND SUBSTR(TO_CHAR(INACTIVE_DATE), 7, 4) = SUBSTR(TO_CHAR(:ENTER_DATE), 7, 4) ORDER BY DEALER, REASON">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTypeOuts" Name="typeOuts" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlDate" Name="ENTER_DATE" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsOutsDetailExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, TO_CHAR(RATE, 'fm9990D00') AS RATE FROM CLEC_OUTS_KEEP WHERE :typeOuts = 'CLEC' AND SUBSTR(TO_CHAR(INACTIVE_DATE), 1, 2) = SUBSTR(TO_CHAR(:ENTER_DATE), 1, 2) AND SUBSTR(TO_CHAR(INACTIVE_DATE), 7, 4) = SUBSTR(TO_CHAR(:ENTER_DATE), 7, 4) UNION ALL SELECT DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, TO_CHAR(RATE, 'fm9990D00') AS RATE FROM ILEC_OUTS_KEEP WHERE :typeOuts = 'ILEC' AND SUBSTR(TO_CHAR(INACTIVE_DATE), 1, 2) = SUBSTR(TO_CHAR(:ENTER_DATE), 1, 2) AND SUBSTR(TO_CHAR(INACTIVE_DATE), 7, 4) = SUBSTR(TO_CHAR(:ENTER_DATE), 7, 4) ORDER BY DEALER, REASON">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlTypeOuts" Name="typeOuts" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlDate" Name="ENTER_DATE" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
