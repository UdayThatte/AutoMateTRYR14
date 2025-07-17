<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WayBillMaster.aspx.cs" Inherits="AutomateTRYOUT.Administrator.WayBillMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





      <asp:Panel  ScrollBars="Horizontal" ID="pnlgvWayBillMaster" runat="server" Width="100%">
                <asp:GridView ID="gvWayBillMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="gvWayBillMaster_PageIndexChanged" OnPageIndexChanging="gvWayBillMaster_PageIndexChanging" OnRowEditing="gvWayBillMaster_RowEditing" OnRowUpdated="gvWayBillMaster_RowUpdated" OnRowUpdating="gvWayBillMaster_RowUpdating" OnRowCancelingEdit="gvWayBillMaster_RowCancelingEdit" Width="100%" OnRowDeleting="gvWayBillMaster_RowDeleting" CssClass="pagination-ys" PageSize="15"
                  >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                      
                         <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" ></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Delete" Visible="False">
                            <ItemTemplate>
                                <span onclick="return confirm('Are you sure to Delete the record?')">
                                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete">
                                    </asp:LinkButton>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label  ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Way Bill No">
                            <ItemTemplate>
                                <asp:Label ID="lblwbp_waybillno"  runat="server" Text='<%#Eval("wbp_waybillno") %>'></asp:Label>
                            </ItemTemplate>

                            
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus"  runat="server" Text='<%#Eval("status") %>'></asp:Label>
                            </ItemTemplate>


                            
                              <EditItemTemplate>
                           
                                  <asp:DropDownList ID="ddstatus" runat="server">
                                      <asp:ListItem Text="ISSUED" Value="ISSUED"></asp:ListItem>
                                       <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>

                                  </asp:DropDownList>
                                 
                            <%--   <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>'></asp:TextBox>--%>


                            </EditItemTemplate>
                           
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Closing " Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblWBCloseCode"  runat="server" Text='<%#Eval("WBCloseCode") %>'></asp:Label>
                            </ItemTemplate>                       
                              
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Modified Date" >
                            <ItemTemplate>
                                <asp:Label ID="lblModifiedTS" runat="server" Text='<%#Eval("ModifiedTS") %>'></asp:Label>
                            </ItemTemplate>
                        
                              
                        </asp:TemplateField>
                       
                         
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:Label ID="lblWBCloserRemar" runat="server" Text='<%#Eval("WBCloserRemar") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>
                           
                                 
                               <asp:TextBox ID="txtWBCloserRemar" runat="server" Text='<%#Eval("WBCloserRemar") %>'></asp:TextBox>


                            </EditItemTemplate>
                               </asp:TemplateField>
                           
                       
                         
                       
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="3" />
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
