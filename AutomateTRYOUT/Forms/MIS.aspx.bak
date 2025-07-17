<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MIS.aspx.cs" Inherits="AutomateTRYOUT.Forms.MIS" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
      <asp:Panel  ScrollBars="Horizontal" ID="PnlSarchMIS" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;"  GroupingText="MIS Report">

        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date"></asp:Label>
                     

                </td>
                <td>
                   
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime"
                       Format="yyyy-MM-dd" Enabled="true">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                       Format="yyyy-MM-dd" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
           
             <td>
                    <asp:Label ID="lbldivdepotmanagement" Visible="false" runat="server" Text="Div And Depo Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddldivdepotmanagement" Visible="false" runat="server" Width="100%" AppendDataBoundItems="true">
                        <asp:ListItem Text="ALL" Value="-1">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                 

             
              </tr>
             <tr>
                <td></td>
                  <td></td>
                  <td></td>
             <td>
                    <asp:Button ID="BtnAPPly" runat="server" Text="Apply" Width="60px" ValidationGroup="Save"  OnClick="BtnAPPly_Click"   />

                    <asp:Button ID="BtnReset" runat="server" Text="Reset" Width="60px"   />


                </td>
              
                <td></td>
                  <td></td>
            </tr>




        </table>
    </asp:Panel>

      <asp:Panel  ScrollBars="Horizontal" ID="pnlgvMIS" runat="server">
       
        <asp:GridView ID="gvMIS" runat="server" CssClass="pagination-ys" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvRouteMasterr_PageIndexChanged" OnPageIndexChanging="gvRouteMasterr_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" >
            <AlternatingRowStyle BackColor="White" />
              <PagerStyle CssClass="pagination-ys" />
            <Columns>


             
                <asp:TemplateField HeaderText="Date" >
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Machine No" >
                    <ItemTemplate>
                        <asp:Label ID="lblMachineNo" runat="server" Text='<%#Eval("MachineNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Way bill No" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblWaybillNo" runat="server" Text='<%#Eval("WaybillNo") %>'></asp:Label>
                    </ItemTemplate>
              
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vehical No" >
                    <ItemTemplate>
                        <asp:Label ID="lblvehicalno" runat="server" Text='<%#Eval("vehicalno") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Route" >
                    <ItemTemplate>
                        <asp:Label ID="lblRoute" runat="server" Text='<%#Eval("Route") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Sale">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_startstg" runat="server" Text='<%#Eval("TotalSaleA") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total RFID Use">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_endstg" runat="server" Text='<%#Eval("TotalRFIDuseB") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Express">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_noofstops" runat="server" Text='<%#Eval("totalexpressC") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total KM">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalKM" runat="server" Text='<%#Eval("TotalKM") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="EP KM">
                    <ItemTemplate>
                        <asp:Label ID="lblEPKM" runat="server" Text='<%#Eval("EPKM") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="No Of Trips">
                    <ItemTemplate>
                        <asp:Label ID="lblEPKM" runat="server" Text='<%#Eval("EPKM") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Pax Trvals">
                    <ItemTemplate>
                        <asp:Label ID="lblPaxtrvals" runat="server" Text='<%#Eval("Paxtrvals") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>


                   <asp:TemplateField HeaderText="Avg Earning">
                    <ItemTemplate>
                        <asp:Label ID="lblAvgearning" runat="server" Text='<%#Eval("Avgearning") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>


                   <asp:TemplateField HeaderText="Total Ticket Issues">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTicketIssues" runat="server" Text='<%#Eval("TotalTicketIssues") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Conductor Name">
                    <ItemTemplate>
                        <asp:Label ID="lblconductorName" runat="server" Text='<%#Eval("conductorName") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                  <asp:TemplateField HeaderText="DriverName">
                    <ItemTemplate>
                        <asp:Label ID="lblDriverName" runat="server" Text='<%#Eval("DriverName") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>



            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:HiddenField ID="HfCurrentLoc" runat="server" />
    </asp:Panel>
  
</asp:Content>
