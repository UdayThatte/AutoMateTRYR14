<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DriverMasterNew.aspx.cs" Inherits="AutomateTRYOUT.Forms.DriverMasterNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel  ScrollBars="Horizontal" ID="pnlDriverMaster" runat="server">
          <h1>  Driver Master</h1>
                <asp:GridView ID="gvDriverMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvDriverMaster_PageIndexChanged" OnPageIndexChanging="gvDriverMaster_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="15" 
                  >
                    <AlternatingRowStyle BackColor="White" />
                        <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                          


                     
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Driver Code">
                            <ItemTemplate>
                                <asp:Label ID="lbldrv_code" runat="server" Text='<%#Eval("drv_code") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Driver Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Depo Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDepoName" runat="server" Text='<%#Eval("DepoName") %>'></asp:Label>
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
