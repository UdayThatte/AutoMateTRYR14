<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepoMasterNew.aspx.cs" Inherits="AutomateTRYOUT.Forms.DepoMasterNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <%--   <asp:Panel  ScrollBars="Horizontal" ID="plnDepoMaster" runat="server" >

         <table >
                      <tr>
                        <td>
                            <asp:Label ID="lblFromDateTime" runat="server" Text="From Date & Time"></asp:Label>
                        </td>
                        <td >
 <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                             <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                                Format="dd/MM/yyyy" Enabled="true">
                            </cc1:CalendarExtender>
                        </td>
                         <td>
                            <asp:Label ID="lblToDateTime" runat="server" Text="To Date & Time"></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="txtToDateTime" runat="server" ></asp:TextBox>
                             <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                                Format="dd/MM/yyyy" Enabled="true">
                            </cc1:CalendarExtender>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblWayBill" runat="server" Text="Way Bill"></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>

                         <td>
                            <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlRoute" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblConductor" runat="server" Text="Conductor"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlConductor" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                   
                        <td>
                            <asp:Label ID="lblMachine" runat="server" Text="Machine" CssClass="rightAlign"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlMachine" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                     
                    </tr>
              <tr>
                        <td>
                            <asp:Label ID="lblTicketType" runat="server" Text="Ticket Type"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlTicketType" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                   
                        <td>
                           
                        </td>
                        <td>
                           
                        </td>
                     
                    </tr>
   <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button ID="btnApply" runat="server"  Text="Apply" Width="60px" ValidationGroup="Save"/>
                           
                            <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="60px"/>

                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                 
               
                </table>
    </asp:Panel>


    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvDepoMaster" runat="server">
                <asp:GridView ID="gvplnConductorMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                  >
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddressIDGrid" runat="server" Text='<%#Eval("AddressID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Waybill No">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeOfAddressGrid" runat="server" Text='<%#Eval("TypeOfAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trip No">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Route No">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Ticket Code">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Ticket NO">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Stg From">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="stg to">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Full Ticket">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>                                                                         
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Half Ticket">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>                
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Luggage Ticket">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>                                            
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Pass Ticket">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>              
                        </asp:TemplateField>
                         
                       
                    </Columns>
                </asp:GridView>
            </asp:Panel>--%>
</asp:Content>
