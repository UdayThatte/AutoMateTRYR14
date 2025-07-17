<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RouteMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.RouteMaster" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

       
    <asp:Panel ID="plnRouteMastersearch" runat="server" Visible="false" >

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


    <asp:Panel ID="pnlgvRouteMaster" runat="server">
                <asp:GridView ID="gvRouteMasterr" runat="server" CssClass="pagination-ys" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvRouteMasterr_PageIndexChanged" OnPageIndexChanging="gvRouteMasterr_PageIndexChanging"     >
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="rp_routeno">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_routeno" runat="server" Text='<%#Eval("rp_routeno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="rp_routetype">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstLineGrid" runat="server" Text='<%#Eval("rp_routetype") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="rp_bustype">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_bustype" runat="server" Text='<%#Eval("rp_bustype") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="rp_triangleno">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_triangleno" runat="server" Text='<%#Eval("rp_triangleno") %>'></asp:Label>
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="rp_startstg">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_startstg" runat="server" Text='<%#Eval("rp_startstg") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="rp_endstg">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_endstg" runat="server" Text='<%#Eval("rp_endstg") %>'></asp:Label>
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="rp_noofstops">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_noofstops" runat="server" Text='<%#Eval("rp_noofstops") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="rp_stgmarathiname">
                            <ItemTemplate>
                                <asp:Label ID="lblrp_stgmarathiname" runat="server" Text='<%#Eval("rp_stgmarathiname") %>'></asp:Label>
                            </ItemTemplate>
                                                                                                 
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="farechanged">
                            <ItemTemplate>
                                <asp:Label ID="lblfarechanged" runat="server" Text='<%#Eval("farechanged") %>'></asp:Label>
                            </ItemTemplate>
                                        
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
