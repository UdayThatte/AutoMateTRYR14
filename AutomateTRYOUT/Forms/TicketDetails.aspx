<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TicketDetails.aspx.cs" Inherits="AutomateTRYOUT.Forms.TicketDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 


    <asp:Panel ID="plnSearchTicketDetails" runat="server">

         <table >
              <tr>
                        <td>
                            <asp:Label ID="lblFromDateTime" runat="server" Text="From Date & Time"></asp:Label>
                        </td>
                        <td >
 <asp:TextBox ID="txtFromDateTime" runat="server"  ></asp:TextBox>
                              <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                                Format="dd/MM/yyyy" Enabled="true">
                            </cc1:CalendarExtender>
                        </td>
                         <td>
                            <asp:Label ID="lblToDateTime" runat="server" Text="To Date Time"></asp:Label>
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
                            <asp:DropDownList ID="ddlWayBill" runat="server">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>

                         <td>
                            <asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlRoute" runat="server">
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
                           <asp:DropDownList ID="ddlConductor" runat="server" >
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                   
                        <td>
                            <asp:Label ID="lblMachine" runat="server" Text="Machine" CssClass="rightAlign"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlMachine" runat="server" >
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
                           <asp:DropDownList ID="ddlTicketType" runat="server" >
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
                            <asp:Button ID="btnApply" runat="server"  Text="Apply" Width="60px" ValidationGroup="Save" OnClick="btnApply_Click"/>
                           
                            <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="60px"/>

                            
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                 
               
                </table>
    </asp:Panel>


    <asp:Panel ID="pnlgvTicketDetails" runat="server">
                <asp:GridView ID="gvVehicleMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                  >
                    <Columns>
                      
                     
                        <asp:TemplateField HeaderText="AddressID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddressIDGrid" runat="server" Text='<%#Eval("AddressID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Condr Details">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeOfAddressGrid" runat="server" Text='<%#Eval("TypeOfAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Driver Details">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehical No">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Division Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Division Code">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Depo Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Depo Code">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>                                                                         
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Way Bill Schedule">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>                
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Etm No">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>                                            
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>              
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Machine No">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
                            </EditItemTemplate>              
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
            </asp:Panel>

    <table>
            
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="ForestGreen" Visible="false"></asp:Label>
                        <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Text="" 
                            Visible="false"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            
                <tr>
                    <td>
                        <asp:HiddenField ID="hfEntityCode" runat="server" />
                    </td>
                    <td>
                       <asp:ValidationSummary ID="valAdd" runat="server" ShowMessageBox="false" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="Save" />
                    </td>
                    
                </tr>
            </table>
</asp:Content>
