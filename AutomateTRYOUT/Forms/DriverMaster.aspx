<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DriverMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.DriverMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



     <asp:Panel ID="pnlDriverMasterSearch" runat="server" SkinID="pnl" Visible="false">
                <table >
                    <tr>
                        <td>
                            <asp:Label ID="lbldrvcode" runat="server" Text="Type Of Address"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlTypeOfAddress" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblname" runat="server" Text="name*"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstLine" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                 
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblstatus" runat="server" Text="status"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPINCode" runat="server" Width="182px" CssClass="rightAlign"></asp:TextBox>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                 
                   
                    <tr>
                        <td>
                          
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="60px" ValidationGroup="Save"/>
                         
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="60px"/>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </asp:Panel>
    <asp:Panel ID="plngvDriverSearch" runat="server" Visible="false">

         <table >
                    <tr>
                        <td>
                            <asp:Label ID="lblDrvCodeSearch" runat="server" Text="Drv Code"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlVehicleNo" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td>
                            <asp:Label ID="lblnamesearch" runat="server" Text="First Line *"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtFirstLine" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstLine" runat="server" ControlToValidate="txtFirstLine" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblstatusSearch" runat="server" Text="Second Line"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSecondLine" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                   
                        
                     
                    </tr>
   <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button ID="btnApply" runat="server"  Text="Apply" Width="60px" ValidationGroup="Save"/>
                           
                            <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="60px"/>

                             <asp:Button ID="BtnAddNew" runat="server" Text="Add new Driver"  Width="60px" OnClick="BtnAddNew_Click"/>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                 
               
                </table>
    </asp:Panel>


    <asp:Panel ID="pnlDriverMaster" runat="server">
                <asp:GridView ID="gvDriverMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvDriverMaster_PageIndexChanged" OnPageIndexChanging="gvDriverMaster_PageIndexChanging"
                  >
                    <Columns>
                          


                        <asp:CommandField ShowEditButton="True" />
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="drv code">
                            <ItemTemplate>
                                <asp:Label ID="lbldrvcode" runat="server" Text='<%#Eval("drvcode") %>'></asp:Label>
                            </ItemTemplate>
                              <EditItemTemplate>
                                <asp:TextBox ID="txtdrvcode" runat="server" Text='<%#Eval("drvcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtname" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
            </asp:Panel>

    <table>
               <%-- <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add New Address" Width="130px" OnClick="btnAdd_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Back" Width="130px" 
                            onclick="btnBack_Click" />
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="ForestGreen" Visible="false"></asp:Label>
                        <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Text="" 
                            Visible="false"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            
                <tr>
                    <td>
                        <asp:HiddenField ID="hfEntityCode" runat="server" />
                    </td>
                    <td>
                       <asp:ValidationSummary ID="valAdd" runat="server" ShowMessageBox="false" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="Save" />
                    </td>
                    
                </tr>
            </table>
</asp:Content>

