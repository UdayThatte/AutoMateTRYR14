<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConductorMasterNew.aspx.cs" Inherits="AutomateTRYOUT.Forms.ConductorMasterNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvConductorMaster" runat="server">
          <h1>  Conductor Master</h1>
                <asp:GridView ID="gvplnConductorMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvplnConductorMaster_PageIndexChanged" OnPageIndexChanging="gvplnConductorMaster_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCancelingEdit="gvplnConductorMaster_RowCancelingEdit" OnRowEditing="gvplnConductorMaster_RowEditing" OnRowUpdating="gvplnConductorMaster_RowUpdating" PageSize="15"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                       
                      
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddressIDGrid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conductor Code">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeOfAddressGrid" runat="server" Text='<%#Eval("cd_condrdetails_code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conductor Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstLineGrid" runat="server" Text='<%#Eval("cd_condrdetails") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehicle Number" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblcd_vehicalno" runat="server" Text='<%#Eval("cd_vehicalno") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Division Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcd_divisionname" runat="server" Text='<%#Eval("cd_divisionname") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Depo Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcd_deponame" runat="server" Text='<%#Eval("cd_deponame") %>'></asp:Label>
                            </ItemTemplate>
                                         
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Depot Code" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblcddepocode" runat="server" Text='<%#Eval("cd_depocode") %>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Division Code" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("cd_divisioncode") %>'></asp:Label>
                            </ItemTemplate>
                     
                        </asp:TemplateField>
                       
                       
                          <asp:TemplateField HeaderText="ETMNumber" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblcdetmno" runat="server" Text='<%#Eval("cd_etmno") %>'></asp:Label>
                            </ItemTemplate>
                                                                                                  
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Status">
                               <EditItemTemplate>
                               <asp:DropDownList ID="ddlstatus" runat="server"  AutoPostBack="true" Text='<%#Eval("status") %>'>
                                      <asp:ListItem Text="S" Value="Y"></asp:ListItem>
                                    <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                  
                                   
                                </asp:DropDownList>
                                 
                               


                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
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
