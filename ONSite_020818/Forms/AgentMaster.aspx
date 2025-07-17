<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgentMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.AgentMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:Panel  ScrollBars="Horizontal"  ID="pnlgvAgentMaster" runat="server"> 
         <h1> Agent Master</h1>
                <asp:GridView ID="gvplnAgentMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvplnConductorMaster_PageIndexChanged" OnPageIndexChanging="gvplnConductorMaster_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="15"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddressIDGrid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Code ">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeOfAddressGrid" runat="server" Text='<%#Eval("AgCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPswd" runat="server" Text='<%#Eval("Pswd") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location" >
                            <ItemTemplate>
                                <asp:Label ID="lblAtStg" runat="server" Text='<%#Eval("AtStg") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAgName" runat="server" Text='<%#Eval("AgName") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="IsActive" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIsActive" runat="server" Text='<%#Eval("IsActive") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                      <%--    <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblIssueDt" runat="server" Text='<%#Eval("IssueDt") %>'></asp:Label>
                            </ItemTemplate>
                     
                        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="Cards Issued">
                            <ItemTemplate>
                                <asp:Label ID="lblCardsIssued" runat="server" Text='<%#Eval("CardsIssued") %>'></asp:Label>
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

