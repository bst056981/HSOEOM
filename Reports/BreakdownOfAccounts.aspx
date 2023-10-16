<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BreakdownOfAccounts.aspx.cs" Inherits="Reports_BreakdownOfAccounts" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="text-align: center;">
        <asp:Label runat="server" Font-Size="X-Large" ForeColor="Black">Breakdown of Accounts Report</asp:Label>
    </div>

    <table>
        <tr>            
            <td>
                <asp:Button ID="btnCreate" runat="server" Text="Create Report" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="BRANCH" DataSourceID="dsCustomerCnt" 
        AllowSorting="False" SkinID="igoogle-summer" OnRowDataBound="Gridview_RowDataBound" Width="969px">
        <Columns>
            <asp:BoundField HeaderText="BRANCH SUMMARY" DataField="BRANCH" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="AL" DataField="AL" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="AR" DataField="AR" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="BROOK" DataField="BROOK" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="BRSP1" DataField="BRSP1" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="BRSP2" DataField="BRSP2" ReadOnly="True" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="BRSPD" DataField="BRSPD" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CLINK" DataField="CLINK" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CPRT" DataField="CPRT" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CTL1" DataField="CTL1" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="CTL2" DataField="CTL2" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="DRL" DataField="DRL" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="ELEV" DataField="ELEV" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="ILEC" DataField="ILEC" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="LO" DataField="LO" ReadOnly="True" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="MO" DataField="MO" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="MOSH" DataField="MOSH" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="MS" DataField="MS" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="OB" DataField="OB" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="OBSH" DataField="OBSH" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="SM" DataField="SM" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="SO" DataField="SO" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="SOSH" DataField="SOSH" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="TOTAL" DataField="TOTAL" ReadOnly="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>

    <br />

    <asp:HiddenField ID="hfDate" runat="server" Value="" />
    <asp:SqlDataSource ID="dsCustomerCnt" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT DISTINCT 'ADDS' BRANCH,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AL') AS AL,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AR') AS AR,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BROOK') AS BROOK,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP1') AS BRSP1,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP2') AS BRSP2,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSPD') AS BRSPD,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CLINK') AS CLINK,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CPRT') AS CPRT,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL1') AS CTL1,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL2') AS CTL2,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'DRL') AS DRL,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ELEV') AS ELEV,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ILEC') AS ILEC,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'LO') AS LO,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MO') AS MO,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MOSH') AS MOSH,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MS') AS MS,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OB') AS OB,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OBSH') AS OBSH,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SM') AS SM,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SO') AS SO,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SOSH') AS SOSH,
       (SELECT SUM(ADDS) ADDS FROM BREAKDOWN_ACCOUNTS_VW) AS TOTAL       
  FROM BREAKDOWN_ACCOUNTS_VW
UNION ALL
SELECT DISTINCT 'DISCONNECTS' BRANCH,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AL') AS AL,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AR') AS AR,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BROOK') AS BROOK,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP1') AS BRSP1,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP2') AS BRSP2,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSPD') AS BRSPD,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CLINK') AS CLINK,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CPRT') AS CPRT,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL1') AS CTL1,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL2') AS CTL2,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'DRL') AS DRL,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ELEV') AS ELEV,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ILEC') AS ILEC,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'LO') AS LO,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MO') AS MO,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MOSH') AS MOSH,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MS') AS MS,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OB') AS OB,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OBSH') AS OBSH,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SM') AS SM,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SO') AS SO,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SOSH') AS SOSH,
       (SELECT SUM(DISCONNECTS) DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW) AS TOTAL       
  FROM BREAKDOWN_ACCOUNTS_VW
UNION ALL
SELECT DISTINCT 'NET' BRANCH,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AL') AS AL,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AR') AS AR,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BROOK') AS BROOK,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP1') AS BRSP1,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP2') AS BRSP2,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSPD') AS BRSPD,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CLINK') AS CLINK,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CPRT') AS CPRT,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL1') AS CTL1,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL2') AS CTL2,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'DRL') AS DRL,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ELEV') AS ELEV,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ILEC') AS ILEC,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'LO') AS LO,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MO') AS MO,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MOSH') AS MOSH,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MS') AS MS,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OB') AS OB,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OBSH') AS OBSH,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SM') AS SM,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SO') AS SO,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SOSH') AS SOSH,
       (SELECT SUM(NET) NET FROM BREAKDOWN_ACCOUNTS_VW) AS TOTAL       
  FROM BREAKDOWN_ACCOUNTS_VW">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfDate" Name="start_date" PropertyName="value" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsCountExportAll" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
        SelectCommand="SELECT BRANCH, AL  &quot;  AL  &quot;, AR  &quot;  AR  &quot;, BROOK  &quot;  BROOK  &quot;, BRSP1  &quot;  BRSP1  &quot;, BRSP2  &quot;  BRSP2  &quot;, BRSPD  &quot;  BRSPD  &quot;, CLINK  &quot;  CLINK  &quot;, CPRT  &quot;  CPRT  &quot;, CTL1  &quot;  CTL1  &quot;, CTL2  &quot;  CTL2  &quot;, DRL  &quot;  DRL  &quot;, ELEV  &quot;  ELEV  &quot;, ILEC  &quot;  ILEC  &quot;, LO  &quot;  LO  &quot;, MO  &quot;  MO  &quot;, MOSH  &quot;  MOSH  &quot;, MS  &quot;  MS  &quot;, OB  &quot;  OB  &quot;, OBSH  &quot;  OBSH  &quot;, SM  &quot;  SM  &quot;, SO  &quot;  SO  &quot;, SOSH  &quot;  SOSH  &quot;, TOTAL FROM (
       SELECT DISTINCT 'ADDS' BRANCH,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AL') AS AL,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AR') AS AR,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BROOK') AS BROOK,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP1') AS BRSP1,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP2') AS BRSP2,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSPD') AS BRSPD,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CLINK') AS CLINK,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CPRT') AS CPRT,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL1') AS CTL1,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL2') AS CTL2,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'DRL') AS DRL,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ELEV') AS ELEV,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ILEC') AS ILEC,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'LO') AS LO,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MO') AS MO,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MOSH') AS MOSH,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MS') AS MS,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OB') AS OB,       
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OBSH') AS OBSH,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SM') AS SM,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SO') AS SO,
       (SELECT ADDS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SOSH') AS SOSH,
       (SELECT SUM(ADDS) ADDS FROM BREAKDOWN_ACCOUNTS_VW) AS TOTAL       
  FROM BREAKDOWN_ACCOUNTS_VW
UNION ALL
SELECT DISTINCT 'DISCONNECTS' BRANCH,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AL') AS AL,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AR') AS AR,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BROOK') AS BROOK,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP1') AS BRSP1,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP2') AS BRSP2,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSPD') AS BRSPD,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CLINK') AS CLINK,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CPRT') AS CPRT,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL1') AS CTL1,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL2') AS CTL2,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'DRL') AS DRL,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ELEV') AS ELEV,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ILEC') AS ILEC,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'LO') AS LO,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MO') AS MO,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MOSH') AS MOSH,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MS') AS MS,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OB') AS OB,       
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OBSH') AS OBSH,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SM') AS SM,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SO') AS SO,
       (SELECT DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SOSH') AS SOSH,
       (SELECT SUM(DISCONNECTS) DISCONNECTS FROM BREAKDOWN_ACCOUNTS_VW) AS TOTAL       
  FROM BREAKDOWN_ACCOUNTS_VW
UNION ALL
SELECT DISTINCT 'NET' BRANCH,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AL') AS AL,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'AR') AS AR,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BROOK') AS BROOK,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP1') AS BRSP1,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSP2') AS BRSP2,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'BRSPD') AS BRSPD,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CLINK') AS CLINK,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CPRT') AS CPRT,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL1') AS CTL1,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'CTL2') AS CTL2,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'DRL') AS DRL,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ELEV') AS ELEV,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'ILEC') AS ILEC,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'LO') AS LO,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MO') AS MO,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MOSH') AS MOSH,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'MS') AS MS,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OB') AS OB,       
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'OBSH') AS OBSH,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SM') AS SM,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SO') AS SO,
       (SELECT NET FROM BREAKDOWN_ACCOUNTS_VW WHERE DEALER = 'SOSH') AS SOSH,
       (SELECT SUM(NET) NET FROM BREAKDOWN_ACCOUNTS_VW) AS TOTAL       
  FROM BREAKDOWN_ACCOUNTS_VW)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfDate" Name="start_date" PropertyName="value" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
