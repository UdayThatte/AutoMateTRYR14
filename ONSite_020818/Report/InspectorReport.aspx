<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InspectorReport.aspx.cs" Inherits="AutomateTRYOUT.Report.InspectorReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <asp:Panel  ScrollBars="Horizontal" ID="PnlSarchInspectorReport" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;"  GroupingText="Inspector Report">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label Font-Size="Medium" ID="lblFromDateTime" runat="server" Text="From Date"></asp:Label>
                     

                </td>
                <td>
                   
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                   
                </td>
                <td>
                    <asp:Label Font-Size="Medium" ID="lblToDateTime" runat="server" Text="To Date "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                  

                </td>
            </tr>
             <tr>
             <td>
                    <asp:Label ID="lbldivdepotmanagement" Font-Size="Medium" runat="server" Text="Div And Depo Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddldivdepotmanagement" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="-1">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                  <td></td>
                  <td></td>

              </tr>


            <tr>
             
                <td></td>
             <td>
                    <asp:Button ID="BtnAPPly" runat="server" Text="Apply" Width="60px"  />

                    <asp:Button ID="BtnReset" runat="server" Text="Reset" Width="60px"   />


                </td>
              
                <td></td>
            </tr>




        </table>
    </asp:Panel>


    <asp:Panel  ScrollBars="Horizontal" ID="pnlgvInspectorMaster" runat="server">
         <h1> Inspector Master</h1>
                <asp:GridView ID="gvpInspectorMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvplnConductorMaster_PageIndexChanged" OnPageIndexChanging="gvplnConductorMaster_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code ">
                            <ItemTemplate>
                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="name" >
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="statuse">
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