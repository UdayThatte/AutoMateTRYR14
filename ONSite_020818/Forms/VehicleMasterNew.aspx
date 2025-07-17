<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VehicleMasterNew.aspx.cs" Inherits="AutomateTRYOUT.Forms.VehicleMasterNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    


    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvVehicleMaster" runat="server" Width="100%">
           <h1>  Vehicle Master</h1>
                <asp:GridView ID="gvVehicleMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvVehicleMaster_PageIndexChanged" OnPageIndexChanging="gvVehicleMaster_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblbd_busid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="BusID" >
                            <ItemTemplate>
                                <asp:Label ID="lblbd_busid" runat="server" Text='<%#Eval("bd_busid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="BusID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblbd_busid" runat="server" Text='<%#Eval("bd_busid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BusType">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeOfAddressGrid" runat="server" Text='<%#Eval("bd_bustype") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Busfare">
                            <ItemTemplate>
                                <asp:Label ID="lblbd_busfare" runat="server" Text='<%#Eval("bd_busfare") %>'></asp:Label>
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
