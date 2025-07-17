<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TicketReport.aspx.cs" Inherits="AutomateTRYOUT.Forms.TicketReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


          <asp:Panel  ScrollBars="Horizontal" ID="PnlSarchMIS" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;"  GroupingText="Ticket Report">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date"></asp:Label>
                     

                </td>
                <td>
                   
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yy" Enabled="true">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yy" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
           
           
                  <td>
                    <asp:Label ID="lbldivdepotmanagement"  runat="server" Text="Div And Depo Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddldivdepotmanagement" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="-1">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblMachineNo" runat="server" Text="Machine No"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachineNo" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:Label ID="lblWayBillsarch" runat="server" Text="Way Bill"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
               <td>
                     <asp:Label ID="lblRoute" runat="server" Text="Route Name" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                      <asp:DropDownList ID="ddlRoute" runat="server" Width="100%" AppendDataBoundItems="true">
                                  <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                            </asp:DropDownList>
                </td>
            </tr>



             <tr>
              





                
           
                 <td></td>
                 <td></td>
                 <td></td>
                 <td>
                     <asp:Button ID="BtnAPPly" runat="server" OnClick="BtnAPPly_Click" Text="Apply" ValidationGroup="Save" Width="60px" />
                     <asp:Button ID="BtnReset" runat="server" Text="Reset" Width="60px" />
                 </td>
                 <td></td>
                 <td></td>
                  </tr>






        </table>
    </asp:Panel>


    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvTicketReport" runat="server" >
         <h1> Ticket Report </h1> 
                <asp:GridView ID="gvplnTicketReport" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanged="gvplnETMMaster_PageIndexChanged" OnPageIndexChanging="gvplnETMMaster_PageIndexChanging"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="MACHINEID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMACHINEID" runat="server" Text='<%#Eval("MACHINEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ClientID ">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("ClientID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MACHINE NAME" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMACHINENAME" runat="server" Text='<%#Eval("MACHINENAME") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HID">
                            <ItemTemplate>
                                <asp:Label ID="lblHID" runat="server" Text='<%#Eval("HID") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="STATUS" >
                            <ItemTemplate>
                                <asp:Label ID="lblSTATUS" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                          
                      
                          
                       
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                   
                      <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" FirstPageText="First" LastPageText="Last"></PagerSettings>
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </asp:Panel>
</asp:Content>
