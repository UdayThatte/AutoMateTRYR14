<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DivAndDepoMaster.aspx.cs" Inherits="AutomateTRYOUT.Administrator.DivAndDepoMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


     <asp:Panel  ScrollBars="Horizontal" ID="PlnDivAndDepoMaster" runat="server" Visible="false" HorizontalAlign="Left">


        <table align="center">

           
           
            <tr>
                <td>
                    <asp:Label ID="lblDivisionCode" runat="server" Text="Division Code *" Font-Size="Medium"></asp:Label>
                </td>
                <td >

                    <asp:TextBox ID="txtDivisionCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstLine" runat="server" ControlToValidate="txtDivisionCode" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator id="RegularExpressionValidator1"
                   ControlToValidate="txtDivisionCode"
                   ValidationExpression="\d+"
                   Display="Static"
                   EnableClientScript="true"
                   ErrorMessage="Please enter numbers only"
                   runat="server" ValidationGroup="Save"/>
                </td>
          
                <td>
                    <asp:Label ID="lblDivisionName" runat="server" Text="Division Name" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDivisionName" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDivisionName" runat="server" ControlToValidate="txtDivisionName" ErrorMessage="Password Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDepoCode" runat="server" Text="Depo Code" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtDepoCode" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDepoCode" runat="server" ControlToValidate="txtDepoCode" ErrorMessage="DepoCode Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>                    
                    <asp:RegularExpressionValidator id="revDepoCode"
                   ControlToValidate="txtDepoCode"
                   ValidationExpression="\d+"
                   Display="Static"
                   EnableClientScript="true"
                   ErrorMessage="Please enter numbers only"
                   runat="server" ValidationGroup="Save"/>

                  
                </td>
             


           
                <td>
                    <asp:Label ID="lblDepoName"  runat="server" Text="Depo Name" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtDepoName" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDepoName" runat="server" ControlToValidate="txtDepoName" ErrorMessage="Depo Name Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>

                  
                </td>
             


            </tr>


            <tr>
                <td>
                   
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" Font-Size="Medium"  ValidationGroup="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Font-Size="Medium"
                        Width="60px" Visible="false"  />
                    <asp:Button ID="btnCancel" runat="server" Font-Size="Medium" Text="Cancel"  Width="60px" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
                <td></td>


            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVendorName" runat="server"
                        Style="font-weight: 700" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblVendorNameValue" runat="server" Text=""></asp:Label>
                </td>
            </tr>



        </table>
          
    </asp:Panel>
      <asp:Button ID="btnAddNew" runat="server"  Text="Add New" Width="90px" OnClick="btnAddNew_Click" Font-Size="Medium" />
      <asp:Panel  ScrollBars="Horizontal" ID="pnlgvDivAndDepoMaster" runat="server">
         <h1> Div And Depo Master</h1>
                <asp:GridView ID="gvplnAgentMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCancelingEdit="gvplnAgentMaster_RowCancelingEdit" OnRowEditing="gvplnAgentMaster_RowEditing" OnRowUpdating="gvplnAgentMaster_RowUpdating" OnRowDeleting="gvplnAgentMaster_RowDeleting"
                  >
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
                         <asp:TemplateField HeaderText="Delete" >
                            <ItemTemplate>
                                <span onclick="return confirm('Are you sure to Delete the record?')">
                                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete">
                                    </asp:LinkButton>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Division Code ">
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionCode" runat="server" Text='<%#Eval("DivisionCode") %>'></asp:Label>
                            </ItemTemplate>
                              <EditItemTemplate>
                                                               <asp:TextBox ID="txtDivisionCode" runat="server" Text='<%#Eval("DivisionCode") %>'></asp:TextBox>



                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Division Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionName" runat="server" Text='<%#Eval("DivisionName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDivisionName" runat="server" Text='<%#Eval("DivisionName") %>'></asp:TextBox>


                            </EditItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Depo Code" >
                            <ItemTemplate>
                                <asp:Label ID="lblDepotCode" runat="server" Text='<%#Eval("DepotCode") %>'></asp:Label>
                            </ItemTemplate>
                             <EditItemTemplate>
                                                              <asp:TextBox ID="txtDepotCode" runat="server" Text='<%#Eval("DepotCode") %>'></asp:TextBox>

                                 
                               


                            </EditItemTemplate>
                        
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Depo  Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDepotName" runat="server" Text='<%#Eval("DepotName") %>'></asp:Label>
                            </ItemTemplate>


                        
                                 <EditItemTemplate>
                                                              <asp:TextBox ID="txtDepotName" runat="server" Text='<%#Eval("DepotName") %>'></asp:TextBox>

                                 
                               


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
