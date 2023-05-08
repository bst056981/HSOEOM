<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DealerTotals.aspx.cs" Inherits="Reports_DealerTotals" Theme="SkinFile" %>

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
    <h3 style="text-align: center;">Dealer Totals</h3>
    <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="dsCustomer" SkinID="igoogle-summer" DataKeyNames="DEALER"
        AutoGenerateColumns="False" Width="969px" AllowPaging="False" EnableTheming="True" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="DEALER" HeaderText="Dealer" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="ACTIVE" HeaderText="Active" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="INACTIVE" HeaderText="Inactive" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
        </Columns>
        <PagerStyle Font-Underline="True" />
        <EmptyDataTemplate>
            <table class="igoogle-summer grid datatable" width="916px">
                <tr>
                    <td colspan="4">No Customers for selected filters
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EditRowStyle Font-Underline="True" />
        <AlternatingRowStyle Font-Underline="False" />
    </asp:GridView>
    <%-- ****** Per Cassandra CPRT active count will always be 113 so that is why there is code in the below SQL for CPRT *****************--%>
    <asp:SqlDataSource ID="dsCustomer" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM (SELECT DISTINCT  '1' REC, A.DEALER, ACTIVE.CNT AS ACTIVE, INACTIVE.CNT AS INACTIVE FROM CUSTOMER A LEFT OUTER JOIN (SELECT DEALER, COUNT(DEALER) AS CNT FROM CUSTOMER WHERE END_DATE = ' ' AND DEALER != 'CPRT'  GROUP BY DEALER UNION SELECT DISTINCT DEALER, 113 AS CNT FROM CUSTOMER WHERE END_DATE = ' ' AND DEALER = 'CPRT' GROUP BY DEALER) ACTIVE ON A.DEALER = ACTIVE.DEALER LEFT OUTER JOIN (SELECT DEALER, COUNT(DEALER) AS CNT FROM CUSTOMER WHERE END_DATE != ' ' GROUP BY DEALER) INACTIVE ON A.DEALER = INACTIVE.DEALER UNION SELECT '2' AS REC, 'TOTAL' AS DEALER, (SELECT CNT + 113 FROM (SELECT COUNT(DEALER) AS CNT FROM CUSTOMER WHERE END_DATE = ' ' AND DEALER != 'CPRT')) ACTIVE, (SELECT COUNT(DEALER) FROM CUSTOMER WHERE END_DATE != ' ') INACTIVE FROM CUSTOMER GROUP BY 1 ) ORDER BY REC, DEALER"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsCustomerExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DEALER, ACTIVE, INACTIVE FROM (SELECT DISTINCT  '1' REC, A.DEALER, ACTIVE.CNT AS ACTIVE, INACTIVE.CNT AS INACTIVE FROM CUSTOMER A LEFT OUTER JOIN (SELECT DEALER, COUNT(DEALER) AS CNT FROM CUSTOMER WHERE END_DATE = ' ' AND DEALER != 'CPRT'  GROUP BY DEALER UNION SELECT DISTINCT DEALER, 113 AS CNT FROM CUSTOMER WHERE END_DATE = ' ' AND DEALER = 'CPRT' GROUP BY DEALER) ACTIVE ON A.DEALER = ACTIVE.DEALER LEFT OUTER JOIN (SELECT DEALER, COUNT(DEALER) AS CNT FROM CUSTOMER WHERE END_DATE != ' ' GROUP BY DEALER) INACTIVE ON A.DEALER = INACTIVE.DEALER UNION SELECT '2' AS REC, 'TOTAL' AS DEALER, (SELECT CNT + 113 FROM (SELECT COUNT(DEALER) AS CNT FROM CUSTOMER WHERE END_DATE = ' ' AND DEALER != 'CPRT')) ACTIVE, (SELECT COUNT(DEALER) FROM CUSTOMER WHERE END_DATE != ' ') INACTIVE FROM CUSTOMER GROUP BY 1 ) ORDER BY REC, DEALER"></asp:SqlDataSource>
</asp:Content>
