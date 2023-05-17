<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Breakdown.aspx.cs" Inherits="Reports_Breakdown" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="text-align: center;">
        <asp:Label runat="server" Font-Size="X-Large" ForeColor="Black">Breakdown vs Dealer Report</asp:Label>
    </div>

    <table>
        <tr>            
            <td>
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="DEALER" DataSourceID="dsCustomerCnt" 
        AllowSorting="False" SkinID="igoogle-summer" OnRowDataBound="Gridview_RowDataBound" Width="969px">
        <Columns>
            <asp:BoundField HeaderText="DEALER" DataField="DEALER" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="ADDS" DataField="CNT_ADDS" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="DISC" DataField="CNT_OUTS" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="NET" DataField="DIFF" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="VS" DataField="VS" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="DEALER" DataField="DEALER2" ReadOnly="True" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CURRENT" DataField="CURR" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="LAST" DataField="LAST" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="DIFF" DataField="DIFF2" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="MATCH" DataField="MATCH" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>

    <br />

    <asp:HiddenField ID="hfDate" runat="server" Value="" />
    <asp:SqlDataSource ID="dsCustomerCnt" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT DEALER, CNT_ADDS, CNT_OUTS, DIFF, VS, DEALER2, CURR, LAST, DIFF2, CASE WHEN (DIFF - DIFF2) = 0 THEN 'TRUE' ELSE 'FALSE' END AS MATCH  FROM (SELECT VW.DEALER, VW.CNT_ADDS, VW.CNT_OUTS, VW.DIFF, '' VS,  A.DEALER DEALER2, COALESCE(A.CNT0, 0) CURR, COALESCE(A.CNT1, 0) LAST, COALESCE(A.DIFF, 0) DIFF2 FROM BREAKDOWN_VW VW
                        LEFT OUTER JOIN (SELECT DEALER, CNT0, CNT1, (CNT0 - CNT1) DIFF FROM (SELECT HEADING1 DEALER, HDR.CUST_CNT_HDR_REC_ID REC_ID, A0.CUST_CNT CNT0, A1.CUST_CNT CNT1 FROM CUSTOMER_COUNT_HEADINGS HDR
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:start_date, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-0)) A0 ON HDR.CUST_CNT_HDR_REC_ID = A0.CUST_CNT_REC_ID                       
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:start_date, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-1)) A1 ON HDR.CUST_CNT_HDR_REC_ID = A1.CUST_CNT_REC_ID) WHERE REC_ID <= 32) A ON VW.DEALER = A.DEALER) ORDER BY DEALER">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfDate" Name="start_date" PropertyName="value" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsCountExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT DEALER, CNT_ADDS ADDS, CNT_OUTS DISC, DIFF NET, VS, DEALER2 &quot;DEALER &quot;, CURR &quot;CURRENT&quot;, LAST, DIFF2 &quot;DIFF&quot;,  CASE WHEN (DIFF - DIFF2) = 0 THEN 'TRUE' ELSE 'FALSE' END AS MATCH FROM (SELECT VW.DEALER, VW.CNT_ADDS, VW.CNT_OUTS, VW.DIFF, '' VS,  A.DEALER DEALER2, COALESCE(A.CNT0, 0) CURR, COALESCE(A.CNT1, 0) LAST, COALESCE(A.DIFF, 0) DIFF2 FROM BREAKDOWN_VW VW
                        LEFT OUTER JOIN (SELECT DEALER, CNT0, CNT1, (CNT0 - CNT1) DIFF FROM (SELECT HEADING1 DEALER, HDR.CUST_CNT_HDR_REC_ID REC_ID, A0.CUST_CNT CNT0, A1.CUST_CNT CNT1 FROM CUSTOMER_COUNT_HEADINGS HDR
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:start_date, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-0)) A0 ON HDR.CUST_CNT_HDR_REC_ID = A0.CUST_CNT_REC_ID                       
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:start_date, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-1)) A1 ON HDR.CUST_CNT_HDR_REC_ID = A1.CUST_CNT_REC_ID) WHERE REC_ID <= 32) A ON VW.DEALER = A.DEALER) ORDER BY DEALER">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfDate" Name="start_date" PropertyName="value" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
