<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DealerAmounts.aspx.cs" Inherits="Reports_DealerAmounts" Theme="SkinFile" %>

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
    <h3 style="text-align: center;">Dealer Outs/Adds Amounts</h3>
    <table class="igoogle-summer" width="969px">
        <tr>
            <th width="50px" >Type:
            </th>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="dsType" DataTextField="DEALER_REPORT" AutoPostBack="true" OnTextChanged="ddlType_Click"
                    DataValueField="DEALER_REPORT" OnDataBound="ddlAddAll">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsType" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT DEALER_REPORT FROM DEALER_INFO ORDER BY DEALER_REPORT"></asp:SqlDataSource>
            </td>
            <td align="right">
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="dsOutsDetail" SkinID="igoogle-summer" DataKeyNames="DEALER"
        AutoGenerateColumns="False" Width="969px" AllowPaging="False" EnableTheming="True" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="DEALER" HeaderText="Dealer" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="CNT" HeaderText="#" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="RATE_OUTS" HeaderText="OUTS #" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:c2}" NullDisplayText="$0.00" />
            <asp:BoundField DataField="RATE_ADDS" HeaderText="ADDS #" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:c2}" NullDisplayText="$0.00" />
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
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT VW.DEALER, COALESCE(CNT, 0) CNT, RATE_OUTS, RATE_ADDS FROM DEALER_CNT_RATES_VW VW, DEALER_INFO D WHERE DEALER_REPORT = :type AND VW.DEALER = D.DEALER UNION ALL SELECT 'TOTAL' AS DEALER, COALESCE(SUM(CNT), 0) CNT, SUM(RATE_OUTS) AS RATE_OUTS, SUM(RATE_ADDS) AS RATE_ADDS FROM DEALER_CNT_RATES_VW VW, DEALER_INFO D WHERE DEALER_REPORT = :type AND VW.DEALER = D.DEALER ">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlType" Name="type" PropertyName="SelectedValue" DefaultValue="CLEC SEC" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsOutsDetailExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DEALER, CNT, TO_CHAR(RATE_OUTS, 'fm99990D00') AS RATE_OUTS, TO_CHAR(RATE_ADDS, 'fm99990D00') AS RATE_ADDS FROM (SELECT VW.DEALER, COALESCE(CNT, 0) CNT, COALESCE(RATE_OUTS, 0.00) RATE_OUTS, COALESCE(RATE_ADDS, 0.00) RATE_ADDS FROM DEALER_CNT_RATES_VW VW, DEALER_INFO D WHERE DEALER_REPORT = :type AND VW.DEALER = D.DEALER UNION ALL SELECT 'TOTAL' AS DEALER,  COALESCE( SUM(CNT), 0) CNT, COALESCE(SUM(RATE_OUTS), 0.00) AS RATE_OUTS, COALESCE(SUM(RATE_ADDS), 0.00) AS RATE_ADDS FROM DEALER_CNT_RATES_VW VW, DEALER_INFO D WHERE DEALER_REPORT = :type AND VW.DEALER = D.DEALER) ORDER BY DEALER">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlType" Name="type" PropertyName="SelectedValue" DefaultValue="CLEC SEC" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
