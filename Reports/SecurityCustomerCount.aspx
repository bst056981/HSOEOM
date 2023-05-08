<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SecurityCustomerCount.aspx.cs" Inherits="Reports_SecurityCustomerCount" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="text-align: center;">
        <asp:Label runat="server" Font-Size="X-Large" ForeColor="Black">Security Customer Count</asp:Label>
    </div>

    <%--    <table>
        <tr>
            <th>Year
            </th>
            <td width="700px">
                <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="dsYear" DataTextField="DESCR"
                    DataValueField="KEY" OnTextChanged="ddlYear_OnTextChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsYear" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT KEY, DESCR FROM STATIC_INFO WHERE TYPE = :YEARS ORDER BY ID DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="YEARS" Name="TYPE" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td   width="100px">
                <asp:Button Text="Update" OnClick="OnUpdate" BackColor="Orange" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>--%>

    <br />

    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="REC_ID" DataSourceID="dsCustomerCnt" Style="margin-left: -200px"
        AllowSorting="False" SkinID="igoogle-summer" OnRowDataBound="Gridview_RowDataBound" Width="1369px">
        <Columns>
            <asp:BoundField HeaderText="REC_ID" DataField="REC_ID" ReadOnly="True" Visible="False" />
            <asp:BoundField HeaderText="DEALER" DataField="HEADING1" ReadOnly="True" ItemStyle-BackColor="#F57E20" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CLEC ACCOUNTS" DataField="HEADING2" ReadOnly="true" ItemStyle-BackColor="#F57E20" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT12" DataField="CNT12" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT11" DataField="CNT11" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT10" DataField="CNT10" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT9" DataField="CNT9" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT8" DataField="CNT8" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT7" DataField="CNT7" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT6" DataField="CNT6" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT5" DataField="CNT5" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT4" DataField="CNT4" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT3" DataField="CNT3" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT2" DataField="CNT2" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT2" DataField="CNT1" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CNT0" DataField="CNT0" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>

    <br />

    <%--    <div style="text-align: center;">
        <asp:Button Text="Update" OnClick="OnUpdate" runat="server" BackColor="Orange" />
    </div>--%>

    <asp:HiddenField ID="hfYear" runat="server" Value="" />
    <asp:SqlDataSource ID="dsCustomerCnt" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT * FROM (
                        SELECT HEADING1, HEADING2, HDR.CUST_CNT_HDR_REC_ID REC_ID, A12.CUST_CNT CNT12, A11.CUST_CNT CNT11, A10.CUST_CNT CNT10, A9.CUST_CNT CNT9, A8.CUST_CNT CNT8, A7.CUST_CNT CNT7, A6.CUST_CNT CNT6, A5.CUST_CNT CNT5, A4.CUST_CNT CNT4, A3.CUST_CNT CNT3, A2.CUST_CNT CNT2, A1.CUST_CNT CNT1, A0.CUST_CNT CNT0
                        FROM CUSTOMER_COUNT_HEADINGS HDR
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-12)) A12 ON HDR.CUST_CNT_HDR_REC_ID = A12.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-11)) A11 ON HDR.CUST_CNT_HDR_REC_ID = A11.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-10)) A10 ON HDR.CUST_CNT_HDR_REC_ID = A10.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-9)) A9 ON HDR.CUST_CNT_HDR_REC_ID = A9.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-8)) A8 ON HDR.CUST_CNT_HDR_REC_ID = A8.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-7)) A7 ON HDR.CUST_CNT_HDR_REC_ID = A7.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-6)) A6 ON HDR.CUST_CNT_HDR_REC_ID = A6.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-5)) A5 ON HDR.CUST_CNT_HDR_REC_ID = A5.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-4)) A4 ON HDR.CUST_CNT_HDR_REC_ID = A4.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-3)) A3 ON HDR.CUST_CNT_HDR_REC_ID = A3.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-2)) A2 ON HDR.CUST_CNT_HDR_REC_ID = A2.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-1)) A1 ON HDR.CUST_CNT_HDR_REC_ID = A1.CUST_CNT_REC_ID 
                        LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-0)) A0 ON HDR.CUST_CNT_HDR_REC_ID = A0.CUST_CNT_REC_ID)ORDER BY REC_ID">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfYear" Name="ENTER_DATE" PropertyName="Value" DefaultValue="03/31/2023" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsCountExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT * FROM (
SELECT HEADING1, HEADING2, HDR.CUST_CNT_HDR_REC_ID REC_ID, A12.CUST_CNT CNT12, A11.CUST_CNT CNT11, A10.CUST_CNT CNT10, A9.CUST_CNT CNT9, A8.CUST_CNT CNT8, A7.CUST_CNT CNT7, A6.CUST_CNT CNT6, A5.CUST_CNT CNT5, A4.CUST_CNT CNT4, A3.CUST_CNT CNT3, A2.CUST_CNT CNT2, A1.CUST_CNT CNT1, A0.CUST_CNT CNT0
FROM CUSTOMER_COUNT_HEADINGS HDR
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-12)) A12 ON HDR.CUST_CNT_HDR_REC_ID = A12.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-11)) A11 ON HDR.CUST_CNT_HDR_REC_ID = A11.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-10)) A10 ON HDR.CUST_CNT_HDR_REC_ID = A10.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-9)) A9 ON HDR.CUST_CNT_HDR_REC_ID = A9.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-8)) A8 ON HDR.CUST_CNT_HDR_REC_ID = A8.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-7)) A7 ON HDR.CUST_CNT_HDR_REC_ID = A7.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-6)) A6 ON HDR.CUST_CNT_HDR_REC_ID = A6.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-5)) A5 ON HDR.CUST_CNT_HDR_REC_ID = A5.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-4)) A4 ON HDR.CUST_CNT_HDR_REC_ID = A4.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-3)) A3 ON HDR.CUST_CNT_HDR_REC_ID = A3.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-2)) A2 ON HDR.CUST_CNT_HDR_REC_ID = A2.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-1)) A1 ON HDR.CUST_CNT_HDR_REC_ID = A1.CUST_CNT_REC_ID 
LEFT OUTER JOIN (SELECT CUST_CNT, CUST_CNT_REC_ID FROM CUSTOMER_COUNT WHERE (to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = add_months(to_char(to_date(:ENTER_DATE, 'MM/DD/YYYY'), 'DD-MON-YYYY'),-0)) A0 ON HDR.CUST_CNT_HDR_REC_ID = A0.CUST_CNT_REC_ID)ORDER BY REC_ID">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfYear" Name="ENTER_DATE" PropertyName="Value" DefaultValue="03/31/2023" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
