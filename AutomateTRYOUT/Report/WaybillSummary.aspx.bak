<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WaybillSummary.aspx.cs" Inherits="AutomateTRYOUT.Report.WaybillSummary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    


       <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>






    <asp:Panel  ScrollBars="Horizontal" ID="plnSearchWayBillMaster" runat="server" border="1" Style="border: 1px solid #000;" GroupingText="Select Parameters Way Bill Summary">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date & Time"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                         Format="MM-DD-YYYY" Enabled="true">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date & Time"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                          Format="MM-DD-YYYY" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWayBill" runat="server" Text="Way Bill"></asp:Label>
                   <%-- <asp:CheckBox ID="ChkWayBill" runat="server" />--%>
                </td>
                <td>
                    <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:DropDownList ID="ddlMachine" runat="server" Width="100%" AppendDataBoundItems="true">
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


    <h1>Way Bill Summary</h1>
    <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging"
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
</asp:Content>

