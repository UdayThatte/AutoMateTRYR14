<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="AutomateTRYOUT.Administrator.UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    
    <asp:Panel  ScrollBars="Horizontal"  ID="PlnAddnewUser" runat="server" Visible="false">

            <asp:TextBox ID="txtsesstionClient" runat="server" Visible="false"></asp:TextBox>
        <table align="center">

           
        
            <tr>
                <td>
                    <asp:Label ID="lblFirstLine" Font-Size="Medium" runat="server" Text="User Name *"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtUserName" runat="server" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstLine" runat="server" ControlToValidate="txtUserName" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                        <td>
                            <asp:Label ID="lblSecondLine" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSecondLine" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>--%>
            <tr>
              
                <td>
                    <asp:Label ID="lblState" Font-Size="Medium" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtUserName" ErrorMessage="Password Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRoleName" Font-Size="Medium" runat="server" Text="Role Name"></asp:Label>
                </td>
                <td>

                    <asp:DropDownList ID="ddlRoleName" runat="server" Width="100%">
                       
                          <asp:ListItem Text="Normal User" Value="NormalUser"></asp:ListItem>
                       
                          <asp:ListItem Text="Manager" Value="Manager"></asp:ListItem>
                       
                        <asp:ListItem Text="Administrator" Value="Administrator"></asp:ListItem>

                       


                    </asp:DropDownList>
                </td>
             


            </tr>


             <tr>
                                                                         <%--   <td >
                                                                                <asp:Label ID="lblClientName" runat="server" Visible="false" Text="Client Name *"></asp:Label>
                                                                            </td>
                                                                            <td  > 
                                                                               
                                                                              <asp:DropDownList ID="ddlClientName" runat="server"  Visible="false" Width="100%">
                                                                                  <asp:ListItem Value="Automate">Automate</asp:ListItem>
                                                                                   <asp:ListItem Value="HTCGAJ01">HTCGAJ01</asp:ListItem>  
                                                                              </asp:DropDownList>
                                                                            </td>--%>
                                                                        </tr>
           
           
            <tr>
                <td>
                    <asp:TextBox ID="TxtUserId" runat="server" TabIndex="7" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="60px" ValidationGroup="Save" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"
                        Width="60px" Visible="false" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="60px" />
                </td>
                <td>&nbsp;</td>
                <td></td>


            </tr>
            <tr>
                <td>
                    <asp:Label  Font-Size="Medium" ID="lblVendorName" runat="server"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblVendorNameValue" Font-Size="Medium" runat="server" Text=""></asp:Label>
                </td>
            </tr>



        </table>
           <asp:HiddenField ID="HfCurrentLoc" runat="server" />
    </asp:Panel>





                                                                                                       <asp:Button ID="btnAddNew" Font-Size="Medium" runat="server"  Text="Add New" Width="90px" OnClick="btnAddNew_Click" />
                                                                              
                                                                     
           
          



      




    <asp:Panel  ScrollBars="Horizontal"  ID="pnlgvUserMaster" runat="server">

                    
        <asp:GridView ID="gvUserMaster" runat="server" CssClass="pagination-ys" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvUserMaster_PageIndexChanged" OnPageIndexChanging="gvUserMaster_PageIndexChanging" OnRowDeleted="gvUserMaster_RowDeleted" OnRowDeleting="gvUserMaster_RowDeleting" OnRowEditing="gvUserMaster_RowEditing"  Font-Names="Courier New" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <%--   <EditItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" ValidationGroup="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>--%></asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" >
                    <ItemTemplate>
                        <span onclick="return confirm('Are you sure to Delete the record?')">
                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete">
                                    </asp:LinkButton>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Role Name">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_routeno" runat="server" Text='<%#Eval("RoleName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblPassword" runat="server" Text='<%#Eval("Password") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client Name">
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientID") %>'></asp:Label>
                    </ItemTemplate>
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


    
      <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblErrMsg" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="ForestGreen" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNoMatch" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
         
</asp:Content>
