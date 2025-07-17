<%@  Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"CodeBehind="VehicleMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.VehicleMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>





     <asp:Panel ID="pnlVehicleMasterSearch" runat="server" SkinID="pnl" >
                <table >
                    <tr>
                        <td>
                            <asp:Label ID="lblTypeOfAddress" runat="server" Text="Type Of Address"></asp:Label>
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
                            <asp:Label ID="Label1" runat="server" Text="First Line *"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstLine" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                 
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblPINCode" runat="server" Text="PIN Code"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPINCode" runat="server" Width="182px" CssClass="rightAlign"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Contact Number" CssClass="rightAlign"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Width="182px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblEntityType" runat="server" Text="Entity Type"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEntityType" runat="server" Width="126px">
                                <asp:ListItem Text="Customer" Value="CUST"></asp:ListItem>
                                <asp:ListItem Text="Vendor" Value="VEND"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOperationCenter" runat="server" Text="Operation Center"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOperationCenter" runat="server" DataSourceID="odsdataSet"
                                DataTextField="DataSetName" DataValueField="DataSetName" Width="177px">
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TxtUserId" runat="server" TabIndex="7" Visible="false"></asp:TextBox>
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
    <asp:Panel ID="plnSearch" runat="server" Visible="false">

         <table >
                    <tr>
                        <td>
                            <asp:Label ID="lblVehicleNo" runat="server" Text="Vehicle No"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlVehicleNo" runat="server" Width="100%">
                                <asp:ListItem Text="Registered Office" Value="REGIS"></asp:ListItem>
                                <asp:ListItem Text="Shipping Address" Value="SHIPP"></asp:ListItem>
                                <asp:ListItem Text="Other address" Value="OTHER"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td>
                            <asp:Label ID="lblFirstLine" runat="server" Text="First Line *"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtFirstLine" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstLine" runat="server" ControlToValidate="txtFirstLine" ErrorMessage="First Line is a mandatory field" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  
                    <tr>
                        <td>
                            <asp:Label ID="lblSecondLine" runat="server" Text="Second Line"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSecondLine" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                   
                        <td>
                            <asp:Label ID="lblContactTelephoneNo" runat="server" Text="Contact Number" CssClass="rightAlign"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactTelephoneNo" runat="server" Width="182px"></asp:TextBox>
                        </td>
                     
                    </tr>
   <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button ID="btnApply" runat="server"  Text="Apply" Width="60px" ValidationGroup="Save"/>
                           
                            <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="60px"/>

                             <asp:Button ID="BtnAddNew" runat="server" Text="Add new vehicle"  Width="60px" OnClick="BtnAddNew_Click"/>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                 
               
                </table>
    </asp:Panel>


    <asp:Panel ID="pnlgvVehicleMaster" runat="server">
                <asp:GridView ID="gvVehicleMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                  >
                    <Columns>
                      
                        <asp:CommandField ShowEditButton="True" />
                        <asp:TemplateField HeaderText="AddressID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAddressIDGrid" runat="server" Text='<%#Eval("AddressID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VehicleNo">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeOfAddressGrid" runat="server" Text='<%#Eval("TypeOfAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Depo Name Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFirstLineGrid" runat="server" Text='<%#Eval("FirstLine") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Route Id">
                            <ItemTemplate>
                                <asp:Label ID="lblSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSecondLineGrid" runat="server" Text='<%#Eval("SecondLine") %>'></asp:TextBox>
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

