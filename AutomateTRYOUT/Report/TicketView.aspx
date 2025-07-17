<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TicketView.aspx.cs" Inherits="AutomateTRYOUT.Report.TicketView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

       <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>


    <asp:Panel  ScrollBars="Horizontal" ID="plnSearchTicketDetails" runat="server" border="1" Style="border: 1px solid #000;" GroupingText="Select Tickets">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
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
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yyyy" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblWayBillsarch" runat="server" Text="Waybill"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoute" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <%-- <asp:Label ID="lblConductor" runat="server" Text="Conductor"></asp:Label>--%>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="ddlConductor" runat="server" Width="100%" AppendDataBoundItems="true">
                                 <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem> 
                            </asp:DropDownList>--%>
                </td>

                <td>
                    <%-- <asp:Label ID="lblMachine" runat="server" Text="Machine" CssClass="rightAlign"></asp:Label>--%>
                </td>
                <td>
                    <%--  <asp:DropDownList ID="ddlMachine" runat="server" Width="100%" AppendDataBoundItems="true">
                                  <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                            </asp:DropDownList>--%>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTicketType" runat="server" Text="Ticket Type"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTicketType" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
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
    <h1>Ticket Report</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" AllowSorting="True" Caption="Ticket Information" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="20">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </p>


</asp:Content>
