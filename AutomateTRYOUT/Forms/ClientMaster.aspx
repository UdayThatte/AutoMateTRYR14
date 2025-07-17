<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClientMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.ClientMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:Panel  align="center" ID="PlnAddClientName" runat="server" Visible="false" BorderWidth="1px">

           
        <table align="center">

           
        
            <tr>
                <td>
                    <asp:Label ID="lblClientName" runat="server" Text="Client Name *" Font-Size="Medium"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtClientName" runat="server" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstLine" runat="server" ForeColor="Red" ControlToValidate="txtClientName" ErrorMessage="Client Name is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
            </tr>
             
                <tr>
                <td>
                    <asp:Label ID="lblDescription" runat="server" Text="Description Name *" Font-Size="Medium"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description  is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
            </tr>
       
        
             <tr>
                <td>
                   
                </td>
                <td >
                     <asp:Button ID="BtnSave" runat="server" Text="Save" Font-Size="Medium" OnClick="BtnSave_Click" ValidationGroup="Save" />
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" Font-Size="Medium" OnClick="BtnCancel_Click" />
                </td>
            </tr>
           


           
          
      



        </table>
         
    </asp:Panel>

    <asp:Button ID="BtnAddNewClient" runat="server" Font-Size="Medium" Text="Client Add" OnClick="BtnAddNewClient_Click" />

    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvClientMaster" runat="server">
         <h1> Client Master</h1>
                <asp:GridView ID="gvClientMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDeleting="gvClientMaster_RowDeleting" OnPageIndexChanged="gvClientMaster_PageIndexChanged" OnPageIndexChanging="gvClientMaster_PageIndexChanging"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
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
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client ID ">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("ClientID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" >
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
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
