<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CustomerDetail.aspx.cs" Inherits="Reports_CustomerDetail" Theme="SkinFile" %>

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
    <h3 style="text-align: center;">Customer Detail</h3>
    <table class="igoogle-summer" width="969px">
        <tr>
            <th>Status:
            </th>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" OnClick="ddlStatus_Click" AutoPostBack="true">
                    <asp:ListItem Value="Active" Selected="True">Active</asp:ListItem>
                    <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                </asp:DropDownList>
            </td>
            <th>Dealer:
            </th>
            <td>
                <asp:DropDownList ID="ddlDealer" runat="server" DataSourceID="dsDealer" DataTextField="DEALER" AutoPostBack="true" OnTextChanged="ddlDealer_Click"
                    DataValueField="DEALER" OnDataBound="ddlAddAll">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsDealer" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT DEALER FROM CUSTOMER WHERE (:STATUS = 'Active' AND END_DATE = ' ') OR (:STATUS = 'Inactive' AND END_DATE != ' ') ORDER BY DEALER">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlStatus" Name="STATUS" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <th>Start Date:
            </th>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server" Width="8em"></asp:TextBox>
                <obout:Calendar ID="CalendarStartDt" runat="server" DatePickerMode="True" MonthWidth="160"
                    MonthHeight="160" StyleFolder="../Resource/Calendar_data/styles/default"
                    DatePickerImagePath="../Resource/Calendar_data/styles/date_picker1.gif" Columns="1"
                    DateFormat="MM/dd/yyyy" DatePickerSynchronize="true"
                    TextBoxId="txtStartDate">
                </obout:Calendar>
            </td>
            <td>
               <asp:TextBox ID="txtEndDate" runat="server" Width="8em"></asp:TextBox>
                <obout:Calendar ID="CalendarEndDt" runat="server" DatePickerMode="True" MonthWidth="160"
                    MonthHeight="160" StyleFolder="../Resource/Calendar_data/styles/default"
                    DatePickerImagePath="../Resource/Calendar_data/styles/date_picker1.gif" Columns="1"
                    DateFormat="MM/dd/yyyy" DatePickerSynchronize="true"
                    TextBoxId="txtEndDate">
                </obout:Calendar>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Filter" OnClick="btnSearch_Click" />
            </td>
            <td align="right">
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="dsCustomer" SkinID="igoogle-summer" DataKeyNames="CUST_ID"
        AutoGenerateColumns="False" Width="969px" AllowPaging="False" EnableTheming="True" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="DICE" HeaderText="DICE" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="NAME" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="DEALER" HeaderText="Dealer" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="START_DATE" HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="END_DATE" HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
    <asp:SqlDataSource ID="dsCustomer" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT CUST_ID, DICE, NAME, DEALER,  START_DATE, END_DATE FROM CUSTOMER WHERE (( TO_DATE(START_DATE, 'MM/DD/YYYY') >= TO_DATE(:startDate, 'MM/DD/YYYY')) AND TO_DATE(START_DATE, 'MM/DD/YYYY') <= TO_DATE(:endDate, 'MM/DD/YYYY')) AND (LOWER(DEALER) LIKE LOWER( :dealer )  || '%') AND ((:status = 'Active' AND END_DATE = ' ') OR (:status = 'Inactive' AND END_DATE != ' ')) ORDER BY DEALER, DICE">
         <SelectParameters>
            <asp:ControlParameter ControlID="txtStartDate" PropertyName="Text" Name="startDate" DefaultValue="01/01/0001" />
            <asp:ControlParameter ControlID="txtEndDate" PropertyName="Text" Name="endDate" DefaultValue="12/31/9999" />
            <asp:ControlParameter ControlID="ddlDealer" Name="dealer" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlStatus" Name="status" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsCustomerExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DICE, NAME, DEALER,  START_DATE, END_DATE FROM CUSTOMER WHERE (( TO_DATE(START_DATE, 'MM/DD/YYYY') >= TO_DATE(:startDate, 'MM/DD/YYYY')) AND TO_DATE(START_DATE, 'MM/DD/YYYY') <= TO_DATE(:endDate, 'MM/DD/YYYY')) AND (LOWER(DEALER) LIKE LOWER( :dealer )  || '%') AND ((:status = 'Active' AND END_DATE = ' ') OR (:status = 'Inactive' AND END_DATE != ' ')) ORDER BY DEALER, DICE">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtStartDate" PropertyName="Text" Name="startDate" DefaultValue="01/01/0001" />
            <asp:ControlParameter ControlID="txtEndDate" PropertyName="Text" Name="endDate" DefaultValue="12/31/9999" />
            <asp:ControlParameter ControlID="ddlDealer" Name="DEALER" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlStatus" Name="STATUS" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
