<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WayBillMaster.aspx.cs" Inherits="AutomateTRYOUT.Administrator.WayBillMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

      <asp:Panel  ScrollBars="Horizontal" ID="pnlgvWayBillMaster" runat="server">
          <h1>  WayBill Master</h1>
                  <asp:GridView ID="gvWayBillMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="gvWayBillMaster_PageIndexChanged" OnPageIndexChanging="gvWayBillMaster_PageIndexChanging" OnRowEditing="gvWayBillMaster_RowEditing" OnRowUpdated="gvWayBillMaster_RowUpdated" OnRowUpdating="gvWayBillMaster_RowUpdating" OnRowCancelingEdit="gvWayBillMaster_RowCancelingEdit" Width="100%" 
                      CssClass="pagination-ys" PageSize="15"
                  >
                      <%-- OnRowDeleting="gvWayBillMaster_RowDeleting"  --%>

                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
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
                      
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddressIDGrid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WayBill No">
                            <ItemTemplate>
                                <asp:Label ID="lblwbp_waybillno" runat="server" Text='<%#Eval("wbp_waybillno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                         
                              <EditItemTemplate>
                           
                                  <asp:DropDownList ID="ddstatus" runat="server">
                                      <asp:ListItem Text="ISSUED" Value="ISSUED"></asp:ListItem>
                                       <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>

                                  </asp:DropDownList>
                                 
                            <%--   <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>'></asp:TextBox>--%>

                            </EditItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modify Date">
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
