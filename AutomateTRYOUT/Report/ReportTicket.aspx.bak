<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportTicket.aspx.cs" Inherits="AutomateTRYOUT.Report.ReportTicket" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:Panel  ScrollBars="Horizontal" ID="plnSearchTicketDetails" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;"  GroupingText="Select Parameters Ticket Report">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date"></asp:Label>
                    

                </td>
                <td>
                   
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                       Format="dd/MM/yy" Enabled="true">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                        Format="dd/MM/yy" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
          
                <td>
                    <asp:Label ID="lblWayBillsarch" runat="server" Text="Way Bill"></asp:Label>
                    
                </td>
                <td>
                    <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoute" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
          
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

                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="60px" OnClick="btnReset_Click"  />


                </td>
                <td></td>
                <td></td>
            </tr>




        </table>
    </asp:Panel>

       <asp:Panel  ScrollBars="Horizontal" ID="rptpnlTicket" runat="server" Width="100%" Height="100%" HorizontalAlign="Center" Visible="false">
                <table>
                    <tr>
                        <td>
                           
                            <rsweb:ReportViewer ID="RptTicket" runat="server" AsyncRendering="False" SizeToReportContent="True"
                                
                                Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Size="14pt"
                                Width="1000px " InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"></rsweb:ReportViewer>
                          
                        </td>
                    </tr>
                </table>
            </asp:Panel>

</asp:Content>
