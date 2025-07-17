<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ETMMaster.aspx.cs" Inherits="AutomateTRYOUT.Administrator.ETMMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Panel ScrollBars="Horizontal" ID="PlnAddnewETm" runat="server" Visible="false" BorderWidth="1px">


        <table align="center">



            <tr>
                <td>
                    <asp:Label ID="lblMACHINEID" runat="server" Font-Size="Medium" Text="Machine ID *"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtMACHINEID" runat="server" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstLine" runat="server" ControlToValidate="txtMACHINEID" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>

                <td>
                    <asp:Label ID="lblClientID" runat="server" Font-Size="Medium" Text="Client ID"></asp:Label>
                </td>
                <td>

                    <asp:DropDownList ID="ddlClient" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMACHINENAME" runat="server" Font-Size="Medium" Text="MACHINE NAME"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMACHINENAME" runat="server" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtMACHINENAME" runat="server" ControlToValidate="txtMACHINENAME" ErrorMessage="STATUS Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>

                </td>



            </tr>


            <tr>

                <td>
                    <asp:Label ID="lblHID" runat="server" Font-Size="Medium" Text="HID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHID" runat="server" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvHID" runat="server" ControlToValidate="txtHID" ErrorMessage="HID Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>

                <td>
                    <asp:Label ID="lblSTATUS" runat="server" Font-Size="Medium" Text="STATUS"></asp:Label>
                </td>
                <td>


                    <asp:DropDownList ID="ddlSTATUS" runat="server" Width="100%">

                        <asp:ListItem Text="Active" Value="0"></asp:ListItem>

                        <asp:ListItem Text="Inactive" Value="1"></asp:ListItem>





                    </asp:DropDownList>
                </td>
            </tr>


            <tr align="center">

                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="60px" ValidationGroup="Save" />
                   
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"  Visible="false" OnClick="btnUpdate_Click" />
                     <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click" Width="60px" />
                </td>



            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblVendorName" runat="server" Font-Size="Medium"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label Font-Size="Medium" ID="lblVendorNameValue"  runat="server" Text=""></asp:Label>
                </td>
            </tr>



        </table>
        <asp:HiddenField ID="HfCurrentLoc" runat="server" />
    </asp:Panel>
    <asp:Button ID="btnAddETM" runat="server" Text="Add New" Width="90px" Font-Size="Medium" OnClick="btnAddNew_Click" />

    <asp:Panel ScrollBars="Horizontal" ID="pnlgvETM" runat="server">
        <h1>ETM  Master</h1>
        <asp:GridView ID="gvplnETMMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" OnPageIndexChanged="gvplnETMMaster_PageIndexChanged" OnPageIndexChanging="gvplnETMMaster_PageIndexChanging"
            OnRowEditing="gvplnETMMaster_RowEditing" OnRowUpdating="gvplnETMMaster_RowUpdating" OnRowCancelingEdit="gvplnETMMaster_RowCancelingEdit" OnRowDataBound="gvplnETMMaster_RowDataBound" OnRowDeleting="gvplnETMMaster_RowDeleting1" PageSize="15">

            <AlternatingRowStyle BackColor="White" />
            <PagerStyle CssClass="pagination-ys" />
            <Columns>

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <%--  <EditItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" ></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" Visible="false">
                    <ItemTemplate>
                        <span onclick="return confirm('Are you sure to Delete the record?')">
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Delete">
                            </asp:LinkButton>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MACHINEID">
                    <ItemTemplate>
                        <asp:Label ID="lblMACHINEID" runat="server" Text='<%#Eval("MACHINEID") %>'></asp:Label>
                    </ItemTemplate>
                    <%-- <EditItemTemplate>
                            
                                  <asp:TextBox ID="txtMACHINEID" runat="server" Text='<%#Eval("MACHINEID") %>'></asp:TextBox>
                               


                            </EditItemTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ClientID">
                    <ItemTemplate>
                        <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("ClientID") %>'></asp:Label>
                    </ItemTemplate>
                    <%--    <EditItemTemplate>
                            
                               
                                 <asp:DropDownList ID="ddlClientID" runat="server"  AutoPostBack="true" Text='<%#Eval("ClientID") %>'>
                                   
                                  
                                   
                                </asp:DropDownList>


                            </EditItemTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MACHINE NAME">
                    <ItemTemplate>
                        <asp:Label ID="lblMACHINENAME" runat="server" Text='<%#Eval("MACHINENAME") %>'></asp:Label>
                    </ItemTemplate>

                    <%--   <EditItemTemplate>
                            
                                  <asp:TextBox ID="txtMACHINENAME" runat="server" Text='<%#Eval("MACHINENAME") %>'></asp:TextBox>
                               


                            </EditItemTemplate>--%>
                         
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HID">
                    <ItemTemplate>
                        <asp:Label ID="lblHID" runat="server" Text='<%#Eval("HID") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="STATUS">


                    <%--  <EditItemTemplate>
                               <asp:DropDownList ID="ddlSTATUS" runat="server"  AutoPostBack="true" Text='<%#Eval("STATUS") %>'>
                                      <asp:ListItem Text="Active" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="IN Active" Value="1"></asp:ListItem>
                                  
                                   
                                </asp:DropDownList>
                                 
                               


                            </EditItemTemplate>--%>
                    <ItemTemplate>
                        <asp:Label ID="lblSTATUS" runat="server" Text='<%#Eval("STATUSDetails") %>'></asp:Label>
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
