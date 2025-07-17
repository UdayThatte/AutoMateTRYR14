<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportWaybillSummary.aspx.cs" Inherits="AutomateTRYOUT.Report.ReportWaybillSummary" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
               <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="upnlSearchWayBillMaster" runat="server" RenderMode="Inline" UpdateMode="Conditional">
          <ContentTemplate>
    <asp:Panel  ScrollBars="Horizontal" ID="plnSearchWayBillMaster" runat="server"   Style="border: 1px solid #000;" GroupingText="Select Parameters Way Bill Summary">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date"></asp:Label>.

                    

                </td>
                <td>
                    <%--  <asp:DropDownList ID="ddlFromDay" runat="server"  >
                          <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>

                       <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>

                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                         <asp:ListItem Text="31" Value="31"></asp:ListItem>
                    </asp:DropDownList>

                     <asp:DropDownList ID="ddlFromMonth" runat="server"  >
                           <asp:ListItem Text="MM" Value="MM"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="11" Value="11"></asp:ListItem>
                           <asp:ListItem Text="12" Value="12"></asp:ListItem>
                           <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    </asp:DropDownList>
                     <asp:DropDownList ID="ddlFromyear" runat="server"  >
                            <asp:ListItem Text="Year" Value="Year"></asp:ListItem>
                      <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        
                    </asp:DropDownList>--%>
                  <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yyyy" Enabled="true">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date"></asp:Label>
                </td>
                <td>

                     <%-- <asp:DropDownList ID="ddltoDay" runat="server"  >
                          <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>

                       <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>

                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                         <asp:ListItem Text="31" Value="31"></asp:ListItem>
                    </asp:DropDownList>

                     <asp:DropDownList ID="ddltoMonth" runat="server" >
                           <asp:ListItem Text="MM" Value="MM"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="11" Value="11"></asp:ListItem>
                           <asp:ListItem Text="12" Value="12"></asp:ListItem>
                           <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    </asp:DropDownList>
                     <asp:DropDownList ID="ddltoyear" runat="server"  >
                            <asp:ListItem Text="Year" Value="Year"></asp:ListItem>
                      <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        
                    </asp:DropDownList>--%>
                  <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yyyy" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
            </tr>
            <tr>
                <td>
                   <%-- <asp:Label ID="lblWayBill" runat="server" Text="Way Bill"></asp:Label>--%>
                </td>
                <td>
                   <%-- <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>--%>
                </td>

                <td>
                    <%-- <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>--%>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="ddlRoute" runat="server" Width="100%" AppendDataBoundItems="true">
                                 <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                            </asp:DropDownList>--%>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblConductor" runat="server" Text="Conductor"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlConductor" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="lblMachine" runat="server" Text="Machine" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachine" runat="server" Width="100%" AppendDataBoundItems="true" ValidationGroup="Save">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td>
                    <%-- <asp:Label ID="lblTicketType" runat="server" Text="Ticket Type"></asp:Label>--%>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="ddlTicketType" runat="server" Width="100%" AppendDataBoundItems="true">
                                <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                            </asp:DropDownList>--%>
                </td>

                <td></td>
                <td></td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnApply" runat="server" Text="Apply" Width="60px" ValidationGroup="Save" OnClick="btnApply_Click" />

                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="60px" OnClick="btnReset_Click" />

                </td>
                <td></td>
                <td></td>
            </tr>


        </table>
    </asp:Panel>


                 <asp:Panel  ScrollBars="Horizontal" ID="rptpnl" runat="server" Width="100%" Height="100%" HorizontalAlign="Center">
                <table>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="RptWayBillSummary" runat="server" AsyncRendering="False" SizeToReportContent="True"  Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Size="14pt"
                                Width="1000px " ShowBackButton="true"></rsweb:ReportViewer>
                          
                        </td>
                    </tr>
                </table>
            </asp:Panel>


  
    <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" Visible="false"
        OnRowDataBound="GV_RowDataBound" OnDataBound="GridView_DataBound"
        AllowPaging="True" Caption="" CellPadding="4" PageSize="20" PagerSettings-Mode="NextPreviousFirstLast"
        ShowFooter="True" PagerSettings-PageButtonCount="25" AutoGenerateColumns="False" Font-Names="Courier New" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
        <PagerStyle CssClass="pagination-ys" />
        <Columns>
            <asp:BoundField HeaderText="Waybill No." DataField="WaybillNo" />
            <asp:BoundField HeaderText="Date" DataField="WBDate" DataFormatString="{0:dd-MMM-yy HH:MM}" />
            <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:BoundField DataField="ConductorCode" HeaderText="Conductor Code" />
            <asp:BoundField DataField="Conductor" HeaderText="Conductor" />
             <asp:BoundField DataField="TicketCount" HeaderText="Ticket Count" />
            
            <asp:BoundField DataField="Amount" DataFormatString="{0:0}" HeaderText="Amount">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
            </asp:BoundField>

            <asp:BoundField DataField="PaxCount" DataFormatString="{0:0}" HeaderText="Passengers">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="LuggageCount" DataFormatString="{0:0}" HeaderText="Luggage Tickets">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="PassCount" DataFormatString="{0:0}" HeaderText="Pass Travellers">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Driver" HeaderText="Driver" />
            <asp:BoundField DataField="MachineNo" HeaderText="Machine No" />
            <asp:BoundField DataField="Vehicle" HeaderText="Vehicle" />
            <asp:BoundField DataField="ClosingRemark" HeaderText="Closing Remark" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />

        <PagerSettings Mode="NumericFirstLast" PageButtonCount="25" FirstPageText="First" LastPageText="Last"></PagerSettings>

        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />

        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>

                 </ContentTemplate>
                     </asp:UpdatePanel>
</asp:Content>
