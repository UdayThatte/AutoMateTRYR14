<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DivAndDepoMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.DivAndDepoMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:Panel  ScrollBars="Horizontal" ID="pnlgvDivAndDepoMaster" runat="server">
         <h1> Div And Depo Master</h1>
                <asp:GridView ID="gvplnAgentMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                      
                      <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Division Code ">
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionCode" runat="server" Text='<%#Eval("DivisionCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Division Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionName" runat="server" Text='<%#Eval("DivisionName") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Depo Code" >
                            <ItemTemplate>
                                <asp:Label ID="lblDepotCode" runat="server" Text='<%#Eval("DepotCode") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Depo  Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAgName" runat="server" Text='<%#Eval("DepotName") %>'></asp:Label>
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
