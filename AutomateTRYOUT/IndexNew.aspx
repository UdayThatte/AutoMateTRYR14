<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IndexNew.aspx.cs"
     Inherits="AutomateTRYOUT.Forms.IndexNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <script type="text/javascript" language="javascript">

    function pageLoad(sender, args) {
        var sm = Sys.WebForms.PageRequestManager.getInstance();
        if (!sm.get_isInAsyncPostBack()) {
            sm.add_beginRequest(onBeginRequest);
            sm.add_endRequest(onRequestDone);
        }
    }

    function onBeginRequest(sender, args) {
        var send = args.get_postBackElement().value;
        if (displayWait(send) == "yes") {
            $find('PleaseWaitPopup').show();
        }
    }

    function onRequestDone() {
        $find('PleaseWaitPopup').hide();
    }

    function displayWait(send) {
        switch (send) {
            case "BtnRefresh":
                return ("yes");
                break;
            case "BtnReset":
                return ("yes");
                break;
                        
            default:
                return ("no");
                break;

                
        }
    }
    </script>
     <asp:Panel  ScrollBars="Horizontal" ID="PleaseWaitMessagePanel" runat="server" CssClass="modalPopup"
            >
            <br />
            <img src="../img/Loading/Loading.gif"  alt="Please wait" /></asp:Panel>



     <%-- <asp:UpdatePanel ID="upnlKMPLReport" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>--%>
    <asp:Button ID="HiddenButton" runat="server" CssClass="hidden" Text="Hidden Button"
            ToolTip="Necessary for Modal Popup Extender" />
        <cc1:ModalPopupExtender ID="PleaseWaitPopup" BehaviorID="PleaseWaitPopup"
            runat="server" TargetControlID="HiddenButton" PopupControlID="PleaseWaitMessagePanel"
            BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

      <div class="row">

        <div class="col-lg-12">
             <div class="text-center m-t-lg">
     <h1>Recent Operations
                </h1>

    
</div>
        </div>
    </div>
    <div class="row">

        <div class="col-lg-12">
            <div class="text-center m-t-lg">

                 
                <asp:Panel  ScrollBars="Horizontal"  ID="pnlIndexNew" runat="server" >
                  
             

                 

                <asp:GridView ID="GVIndexNew" runat="server" CssClass="pagination-ys"  AutoGenerateColumns="False"
                     AllowPaging="True" 
                     CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"  
                    
              OnPageIndexChanged="GVIndexNew_PageIndexChanged"
             OnPageIndexChanging="GVIndexNew_PageIndexChanging">
                     <AlternatingRowStyle BackColor="White" />
            <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                           <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                     
                        <asp:Button ID="btnIndexNewview" runat="server" Text="View" OnClick="btnIndexNewview_Click"/>
                    </ItemTemplate>

                </asp:TemplateField>
                          <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Way Bill No" >
                            <ItemTemplate>
                                <asp:Label ID="lblWaybillNo" runat="server" Text='<%#Eval("WaybillNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Machine No">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineNo" runat="server" Text='<%#Eval("MachineNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                              <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblwbp_date" runat="server" Text='<%#Eval("wbp_date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Conductor Name">
                            <ItemTemplate>
                                <asp:Label ID="lblConductorName" runat="server" Text='<%#Eval("condrName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="vehical No">
                            <ItemTemplate>
                                <asp:Label ID="lblvehicalno" runat="server" Text='<%#Eval("vehicalno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Driver Details" >
                            <ItemTemplate>
                                <asp:Label ID="lbldriverdetails" HorizontalAlign="Left" runat="server" Text='<%#Eval("driverdetails") %>'></asp:Label>
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





                  <asp:Panel  ScrollBars="Horizontal"   ID="PnlMain" runat="server" style="overflow-x:scroll;" >
                <asp:Panel  ScrollBars="Horizontal"  ID="pnlhed" runat="server" Visible="false" >
                    <asp:Table ID="tblSummary" runat="server" CellPadding="2" CellSpacing="2" Font-Bold="True" Font-Size="Medium" GridLines="Both"
                         HorizontalAlign="Left" Width="100%">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server" HorizontalAlign="Left">Total Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelTotalFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Full Ticket Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelFullTicketFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Half Ticket Fare</asp:TableCell>
                            <asp:TableCell ID="tblHalfTicketFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Luggage Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelLuggageFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                             <asp:TableCell runat="server" HorizontalAlign="Left">Agent Ticket Count</asp:TableCell>
                            <asp:TableCell ID="tblCelAgentTicketCount" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server"> 
                           
                            <asp:TableCell runat="server" HorizontalAlign="Left">Concession Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelConcessionFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Expenses</asp:TableCell>
                            <asp:TableCell ID="tblCelExpenses" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                             <asp:TableCell runat="server" HorizontalAlign="Left">Penalty</asp:TableCell>
                            <asp:TableCell ID="tblCelPenalty" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Passenger Count</asp:TableCell>
                            <asp:TableCell ID="tblCelPaxCpunt" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:Panel>
                <br />
                <hr />

                 

                <asp:GridView ID="GridView1" runat="server" EmptyDataText="Data not present"
                    AllowPaging="True" Caption="" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                    OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowDataBound="GridView1_OnRowDataBound"
                    ShowFooter="True" PagerSettings-PageButtonCount="15" AutoGenerateColumns="False" Font-Names="Courier New" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%">
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:BoundField DataField="MachineNo" HeaderText="Machine No" />
                        <asp:BoundField HeaderText="Waybill No" DataField="WaybillNo" />
                        <asp:BoundField HeaderText="Date" DataField="wbp_date" DataFormatString="{0:dd-MMM-yy}" />
                        <asp:BoundField HeaderText="Status" DataField="status" />
                        <asp:BoundField DataField="TotalFare" DataFormatString="{0:0}" HeaderText="Total Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullPaxCount" DataFormatString="{0:0}" HeaderText="Full Pax Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullTicketFare" DataFormatString="{0:0}" HeaderText="Full Ticket Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>

                        <asp:BoundField DataField="HalfPaxCount" DataFormatString="{0:0}" HeaderText="Half Pax Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HalfTicketFare" DataFormatString="{0:0}" HeaderText="Half Ticket Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LuggageCount" DataFormatString="{0:0}" HeaderText="Luggage Ticket Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LuggageFare" DataFormatString="{0:0}" HeaderText="Luggage Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ConcessionPaxCount" DataFormatString="{0:0}" HeaderText="Concession Pax Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ConcessionFare" DataFormatString="{0:0}" HeaderText="Concession Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Expenses" DataFormatString="{0:0}" HeaderText="Expenses">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Penalty" DataFormatString="{0:0}" HeaderText="Penalty">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                       </asp:BoundField>
                        <asp:BoundField DataField="PassCount" DataFormatString="{0:0}" HeaderText="Pass Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Conductor" DataField="ConductorCode" />

                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />

                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" FirstPageText="First" LastPageText="Last"></PagerSettings>

                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />

                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
                      <table>
                          <tr>
                          <td>
                              <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                       </td>

              
            </tr>






        </table>
                      
  </asp:Panel>
  
            </div>
        </div>
    </div>

    <style>
        table {
            border-spacing: 4px; /*use to work like cellspacing */
        }

        th, td {
            padding: 3px;
        }

        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>
          <%--     </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>



     

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="row">

        <div class="col-lg-12">
             <div class="text-center m-t-lg">
     <h1>Recent Operations
                </h1>

     <asp:Panel  ScrollBars="Horizontal"  ScrollBars="Horizontal" ID="PnlSarchPara" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;" >


       
        <table align="Center" cellpadding="5">
            
            <tr>
             

                <td>
                    <asp:Label ID="lblMachineNo" runat="server" Text="Machine No"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachineNo" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlMachineNo_SelectedIndexChanged">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>
           
                <td>
                     <asp:Label ID="lblWyBill" runat="server" Text="Way Bill"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true"  AutoPostBack="true" OnSelectedIndexChanged="ddlWyBill_SelectedIndexChanged">
                                 <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem> 
                            </asp:DropDownList>
                </td>

                
          
                <td>
                     <asp:Label ID="lblTicketCode" runat="server" Text="Conductor Code"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="ddlConductor" runat="server" Width="100%" AppendDataBoundItems="true"  AutoPostBack="true" OnSelectedIndexChanged="ddlConductor_SelectedIndexChanged">
                                 <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem> 
                            </asp:DropDownList>
                </td>

         

             <td>
                    <asp:Button ID="BtnApply" Visible="false" runat="server" Width="70px"  Text="Filter" OnClick="BtnApply_Click"  />

                    <asp:Button ID="BtnReset" runat="server" Text="Reset" Width="70px" OnClick="BtnReset_Click"     />


                </td>
              
            </tr>






        </table>
    </asp:Panel>
</div>
        </div>
    </div>
    <div class="row">

        <div class="col-lg-12">
            <div class="text-center m-t-lg">

                
                <asp:Panel  ScrollBars="Horizontal"  ScrollBars="Horizontal" ID="pnlHeader" runat="server" Visible="true" >
                    <asp:Table ID="tblSummary" runat="server" CellPadding="2" CellSpacing="2" Font-Bold="True" Font-Size="Medium" GridLines="Both" HorizontalAlign="Left" Width="100%">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server" HorizontalAlign="Left">Total Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelTotalFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Full Ticket Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelFullTicketFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Half Ticket Fare</asp:TableCell>
                            <asp:TableCell ID="tblHalfTicketFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Luggage Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelLuggageFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                             <asp:TableCell runat="server" HorizontalAlign="Left">Agent Ticket Count</asp:TableCell>
                            <asp:TableCell ID="tblCelAgentTicketCount" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server"> 
                           
                            <asp:TableCell runat="server" HorizontalAlign="Left">Concession Fare</asp:TableCell>
                            <asp:TableCell ID="tblCelConcessionFare" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Expenses</asp:TableCell>
                            <asp:TableCell ID="tblCelExpenses" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                             <asp:TableCell runat="server" HorizontalAlign="Left">Penalty</asp:TableCell>
                            <asp:TableCell ID="tblCelPenalty" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                            <asp:TableCell runat="server" HorizontalAlign="Left">Passenger Count</asp:TableCell>
                            <asp:TableCell ID="tblCelPaxCpunt" runat="server" HorizontalAlign="Right" BackColor="#FFFFCC"></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:Panel>
                <br />
                <hr />

                 

                <asp:GridView ID="GridView1" runat="server" EmptyDataText="Data not present"
                    AllowPaging="True" Caption="" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                    OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowDataBound="GridView1_OnRowDataBound"
                    ShowFooter="True" PagerSettings-PageButtonCount="15" AutoGenerateColumns="False" Font-Names="Courier New" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%">
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:BoundField DataField="MachineNo" HeaderText="Machine No" />
                        <asp:BoundField HeaderText="Waybill No" DataField="WaybillNo" />
                        <asp:BoundField HeaderText="Date" DataField="wbp_date" DataFormatString="{0:dd-MMM-yy}" />
                        <asp:BoundField HeaderText="Status" DataField="status" />
                        <asp:BoundField DataField="TotalFare" DataFormatString="{0:0}" HeaderText="Total Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullPaxCount" DataFormatString="{0:0}" HeaderText="Full Pax Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullTicketFare" DataFormatString="{0:0}" HeaderText="Full Ticket Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>

                        <asp:BoundField DataField="HalfPaxCount" DataFormatString="{0:0}" HeaderText="Half Pax Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HalfTicketFare" DataFormatString="{0:0}" HeaderText="Half Ticket Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LuggageCount" DataFormatString="{0:0}" HeaderText="Luggage Ticket Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LuggageFare" DataFormatString="{0:0}" HeaderText="Luggage Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ConcessionPaxCount" DataFormatString="{0:0}" HeaderText="Concession Pax Count">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ConcessionFare" DataFormatString="{0:0}" HeaderText="Concession Fare">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Expenses" DataFormatString="{0:0}" HeaderText="Expenses">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Penalty" DataFormatString="{0:0}" HeaderText="Penalty">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Conductor" DataField="ConductorCode" />

                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />

                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" FirstPageText="First" LastPageText="Last"></PagerSettings>

                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />

                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>

            </div>
        </div>
    </div>
    <style>
        table {
            border-spacing: 4px; /*use to work like cellspacing */
        }

        th, td {
            padding: 3px;
        }

        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>
</asp:Content>


--%>