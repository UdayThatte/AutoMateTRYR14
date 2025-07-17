<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ETMMaster.aspx.cs" Inherits="AutomateTRYOUT.Forms.EMTMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvETM" runat="server">
         <h1> ETM  Master</h1>
                <asp:GridView ID="gvplnETMMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                     GridLines="None" Width="100%" OnPageIndexChanged="gvplnETMMaster_PageIndexChanged" OnPageIndexChanging="gvplnETMMaster_PageIndexChanging"
                     OnRowEditing="gvplnETMMaster_RowEditing" OnRowUpdating="gvplnETMMaster_RowUpdating" OnRowCancelingEdit="gvplnETMMaster_RowCancelingEdit" OnDataBound="gvplnETMMaster_DataBound"
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
                        <asp:TemplateField HeaderText="MACHINEID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMACHINEID" runat="server" Text='<%#Eval("MACHINEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ClientID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("ClientID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MACHINE NAME" >
                            <ItemTemplate>
                                <asp:Label ID="lblMACHINENAME" runat="server" Text='<%#Eval("MACHINENAME") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HID">
                            <ItemTemplate>
                                <asp:Label ID="lblHID" runat="server" Text='<%#Eval("HID") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="STATUS" >
                            
                           
                             <EditItemTemplate>
                               <asp:DropDownList ID="ddlSTATUS" runat="server"  AutoPostBack="true" Text='<%#Eval("STATUS") %>'>
                                      <asp:ListItem Text="Active" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="1"></asp:ListItem>
                                  
                                   
                                </asp:DropDownList>
                                 
                               


                            </EditItemTemplate>
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
</asp:Content>