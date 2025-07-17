<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GetPassReport.aspx.cs" Inherits="AutomateTRYOUT.Forms.GetPassReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>


    <asp:UpdatePanel ID="upnlDieselfilig" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
    <asp:Panel  ScrollBars="Horizontal"  ID="PnlSarchPara" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;"  GroupingText="Gate Pass Report">


       
        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date" Font-Size="Medium"></asp:Label>
                     

                </td>
                <td>
                   

<%--                    <asp:DropDownList ID="ddlFromDay" runat="server"  >
                          <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>

                       <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>

                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                         <asp:ListItem Text="31" Value="31"></asp:ListItem>
                    </asp:DropDownList>

                     <asp:DropDownList ID="ddlFromMonth" runat="server"  >
                           <asp:ListItem Text="MM" Value="MM"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="11" Value="11"></asp:ListItem>
                           <asp:ListItem Text="12" Value="12"></asp:ListItem>
                           <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    </asp:DropDownList>
                     <asp:DropDownList ID="ddlFromyear" runat="server"   >
                            <asp:ListItem Text="Year" Value="Year"></asp:ListItem>
                      <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        
                    </asp:DropDownList>--%>
                   <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yy" Enabled="true">
                    </cc1:CalendarExtender>              </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date " Font-Size="Medium"></asp:Label>
                </td>
                <td>
                   
                    <%-- <asp:DropDownList ID="ddltoDay" runat="server" >
                          <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>

                       <asp:ListItem Text="11" Value="11"></asp:ListItem>
                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>

                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                         <asp:ListItem Text="31" Value="31"></asp:ListItem>
                    </asp:DropDownList>

                     <asp:DropDownList ID="ddltoMonth" runat="server"  >
                           <asp:ListItem Text="MM" Value="MM"></asp:ListItem>
                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="11" Value="11"></asp:ListItem>
                           <asp:ListItem Text="12" Value="12"></asp:ListItem>
                           <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    </asp:DropDownList>
                     <asp:DropDownList ID="ddltoyear" runat="server"  >
                            <asp:ListItem Text="Year" Value="Year"></asp:ListItem>
                      <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        
                    </asp:DropDownList>--%>
                                     <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                         CssClass="MyCalendar"
                        Format="dd/MM/yy" Enabled="true">
                    </cc1:CalendarExtender>

                </td>

                  <td>
                     <asp:Label ID="lblRoute" runat="server" Text="Route Name" CssClass="rightAlign" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                      <asp:DropDownList ID="ddlRoute" runat="server" Width="100%" AppendDataBoundItems="true">
                                  <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                            </asp:DropDownList>
                </td>
                 <td>
                    <asp:Label ID="lbldivdepotmanagement"  runat="server" Text="Div And Depo Name" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddldivdepotmanagement" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="-1">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>


            <tr>
             
            
                <td>
                    <asp:Label ID="lblMachineNo" runat="server" Text="Machine No" Font-Size="Medium"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachineNo" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>
                     <asp:Label ID="lblConductor" runat="server" Text="Conductor" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="ddlConductor" runat="server" Width="100%" AppendDataBoundItems="true">
                                 <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem> 
                            </asp:DropDownList>
                </td>

                  <td>
                    <asp:Label ID="lblWayBillsarch" runat="server" Text="Way Bill" Font-Size="Medium"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlWyBill_SelectedIndexChanged">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>

         



              
            
            <tr>
                <td>
       
                </td>
             <td>
                    <asp:Button ID="Button1" runat="server" Width="90px" Text="Apply" OnClick="Button1_Click"  />

                    <asp:Button ID="Button2" runat="server" Text="Reset" Width="60px" OnClick="Button2_Click"   />


                </td>
              
              
            </tr>




        </table>
    </asp:Panel>
    

       <asp:Panel  ScrollBars="Horizontal"  ID="rptpnlGetPass" runat="server" Width="100%" Height="100%" HorizontalAlign="Center" Visible="false">
                
    <asp:Panel  ScrollBars="Horizontal"  ID="pnlgvTicketReport" runat="server">
         <h1> Get Pass Report </h1>
                <asp:GridView ID="gvplnTicketReport" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
                  >
                    <AlternatingRowStyle BackColor="White" />
                      <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                      
                      
                        <asp:TemplateField HeaderText="MACHINEID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMACHINEID" runat="server" Text='<%#Eval("MACHINEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ClientID ">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("ClientID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MACHINE NAME" Visible="false">
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
                            <ItemTemplate>
                                <asp:Label ID="lblSTATUS" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>
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
            </asp:Panel>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
