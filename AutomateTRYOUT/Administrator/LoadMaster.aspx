<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoadMaster.aspx.cs" Inherits="AutomateTRYOUT.Administrator.LoadMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalPopup {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:UpdatePanel ID="upnlSearchWayBillMaster" runat="server" RenderMode="Inline" UpdateMode="Conditional">--%>
    <%--<Triggers>
          <asp:PostBackTrigger ControlID="UploadButton" />
        </Triggers>
                <ContentTemplate>--%>

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
            case "PromoteButton":
                return ("yes");
                break;
            case "ResetButton":
                return ("yes");
                break;
            case "UploadButton":
                return ("yes");
                break;
                
            default:
                return ("no");
                break;

                
        }
    }
    </script>

     <asp:Panel   ID="PleaseWaitMessagePanel" runat="server" CssClass="modalPopup" Height="40px" Width="484px"
            >
            <img src="../img/Loading/Loading.gif"  alt="Please wait" />
            <br />
    </asp:Panel>

    <asp:Button ID="HiddenButton" runat="server" CssClass="hidden" Text="Hidden Button"
            ToolTip="Necessary for Modal Popup Extender" />
        <cc1:ModalPopupExtender ID="PleaseWaitPopup" BehaviorID="PleaseWaitPopup"
            runat="server" TargetControlID="HiddenButton" PopupControlID="PleaseWaitMessagePanel"
            BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
 

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
       
    <asp:Panel  ScrollBars="Horizontal"   ID="panel_head" runat="server">


         <table align="center">

           
           
            <tr>

                <td>
                   <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Select Master"></asp:Label>
                </td>
                <td >
                    <asp:DropDownList ID="DropDownList_master" runat="server" Width="100%" OnSelectedIndexChanged="OnSelectedIndexChanged_DropDownList_master" AutoPostBack="true">
                    <asp:ListItem>--- Select ---</asp:ListItem>
                    <asp:ListItem>Agent Master</asp:ListItem>
                    <asp:ListItem>Counductor Master</asp:ListItem>
                    <asp:ListItem>Driver Master</asp:ListItem>
                    <asp:ListItem>Inspector Master</asp:ListItem>
                    <asp:ListItem>Route Master</asp:ListItem>
                    <asp:ListItem>Stage Master</asp:ListItem>
                 
                </asp:DropDownList>
                </td>
                                <td>
                <asp:FileUpload ID="FileUploadControl" runat="server" />
               
                </td>
                <td >
                    <asp:Label ID="lblFile" runat="server" Visible="false" ForeColor="ForestGreen" Font-Size="Medium"></asp:Label>
                </td>

                 <td>
                      <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="GetButton_Click" />
                 </td>
                </tr>
            
             <tr>
                 <td></td>
                 <td></td>
                 <td>
                      <asp:Button runat="server" ID="PromoteButton" Text="Promote" OnClick="PromoteButton_Click" />
                      <asp:Button runat="server" ID="ResetButton" Text="Reset" OnClick="ResetButton_Click" />
                 </td>
                 <td>
                     

                 </td>
                 <td></td>
             </tr>
              
               
               
             </table>
      
        
    </asp:Panel>
                           
   <hr />
    <asp:Panel  ScrollBars="Horizontal"   ID="Panel_MasterDescription" runat="server">

         <asp:Table ID="Table1" runat="server" Width="100%">

             <asp:TableRow>
                 <asp:TableCell CssClass="alert alert-success"><asp:Label runat="server" ID="desc_NumOfVols" Text=""></asp:Label></asp:TableCell>
             </asp:TableRow>

              <asp:TableRow>
                  <asp:TableCell CssClass="alert alert-success"><asp:Label runat="server" ID="desc_MasterDesc" Text=""></asp:Label></asp:TableCell>
             </asp:TableRow>

         </asp:Table>

    </asp:Panel>
    <asp:Label ID="lblerrer" runat="server" Text=""></asp:Label>

    <%--<h1>Rows from File</h1>--%>
    <asp:GridView ID="GridView_logging" runat="server"  CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" AllowPaging="True" OnPageIndexChanged="GridView_logging_PageIndexChanged" OnPageIndexChanging="GridView_logging_PageIndexChanging">
        <PagerStyle CssClass="pagination-ys" />

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

    <hr style="color: black;" />

    <asp:Panel  ScrollBars="Horizontal"   ID="panel_route" runat="server">
        <asp:Panel  ScrollBars="Horizontal"   ID="panel_route_1" runat="server">
            <div class="row">
                <div class="col-lg-12">
                     <h1>Data to Upload</h1>
                    <asp:GridView ID="GridView_Route" runat="server" 
                        AllowPaging="True"  CellPadding="4" PageSize="10" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_Route_PageIndexChanged" OnPageIndexChanging="GridView_Route_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />
                         
                        <Columns>
                            <asp:BoundField DataField="rp_routeno" HeaderText="Route Number" />
                            <asp:BoundField DataField="rp_routetype" HeaderText="Route Type" />
                            <asp:BoundField DataField="rp_bustype" HeaderText="Bus Type" />
                            <asp:BoundField DataField="rp_triangleno" HeaderText="Triangle Number" />
                            <asp:BoundField DataField="rp_startstg" HeaderText="Start Stage" />
                            <asp:BoundField DataField="rp_endstg" HeaderText="End Stage" />
                            <asp:BoundField DataField="rp_noofstops" HeaderText="Total Stops" />
                            <asp:BoundField DataField="rp_stgmarathiname" HeaderText="Stage Marathi Name" />
                            <asp:BoundField DataField="farechanged" HeaderText="Fare Charge" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" Visible="false" />
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
        </asp:Panel>
        <br />
        <asp:Panel  ScrollBars="Horizontal"  ID="panel_route_2" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView_Route_owned" runat="server" 
                        AllowPaging="True" Caption="Existing Data from Database" CellPadding="4" PageSize="10" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_Route_owned_PageIndexChanged" OnPageIndexChanging="GridView_Route_owned_PageIndexChanging">
                         <PagerStyle CssClass="pagination-ys" />
                         <Columns>
                            <asp:BoundField DataField="rp_routeno" HeaderText="Route Number" />
                            <asp:BoundField DataField="rp_routetype" HeaderText="Route Type" />
                            <asp:BoundField DataField="rp_bustype" HeaderText="Bus Type" />
                            <asp:BoundField DataField="rp_triangleno" HeaderText="Triangle Number" />
                            <asp:BoundField DataField="rp_startstg" HeaderText="Start Stage" />
                            <asp:BoundField DataField="rp_endstg" HeaderText="End Stage" />
                            <asp:BoundField DataField="rp_noofstops" HeaderText="Total Stops" />
                            <asp:BoundField DataField="rp_stgmarathiname" HeaderText="Stage Marathi Name" />
                            <asp:BoundField DataField="farechanged" HeaderText="Fare Charge" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" Visible="false" />
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
        </asp:Panel>
    </asp:Panel>



    <asp:Panel  ScrollBars="Horizontal"  ID="panel_conductor" runat="server">
        <asp:Panel  ScrollBars="Horizontal"   ID="panel_conductor_1" runat="server"> 
            <div class="row">
                <div class="col-lg-12">
                     <h1>Data to Upload</h1>
                    <asp:GridView ID="GridView_Counductor" runat="server"
                         AllowPaging="True"  CellPadding="4" PageSize="10" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present to Insert." OnPageIndexChanged="GridView_Counductor_PageIndexChanged" OnPageIndexChanging="GridView_Counductor_PageIndexChanging">
                         <PagerStyle CssClass="pagination-ys" />

                        

                         <Columns>
                            <asp:BoundField DataField="cd_condrdetails_code" HeaderText="Conductor Code" />
                            <asp:BoundField DataField="cd_condrdetails" HeaderText="Conductor Details" />
                            <asp:BoundField DataField="cd_vehicalno" HeaderText="Vehicle Number" />
                            <asp:BoundField DataField="cd_divisionname" HeaderText="Division Name" />
                            <asp:BoundField DataField="cd_divisioncode" HeaderText="Division Code" />
                            <asp:BoundField DataField="cd_deponame" HeaderText="Depo Name" />
                            <asp:BoundField DataField="cd_depocode" HeaderText="Depo Code" />
                            <asp:BoundField DataField="cd_date" HeaderText="Date" />
                            <asp:BoundField DataField="cd_etmno" HeaderText="ETM No" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="ClientID" HeaderText="ClientID" />
                            
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" Visible="false" />
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
        </asp:Panel>

        <asp:Panel  ScrollBars="Horizontal"  ID="panel_conductor_2" runat="server">
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView_Counductor_owned" runat="server"
                          AllowPaging="True" Caption="Existing Data from Database" CellPadding="4" PageSize="10" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_Counductor_owned_PageIndexChanged" OnPageIndexChanging="GridView_Counductor_owned_PageIndexChanging">
                         <PagerStyle CssClass="pagination-ys" />
                         <Columns>
                            <asp:BoundField DataField="cd_condrdetails_code" HeaderText="Conductor Code" />
                            <asp:BoundField DataField="cd_condrdetails" HeaderText="Conductor Details" />
                            <asp:BoundField DataField="cd_vehicalno" HeaderText="Vehicle Number" />
                            <asp:BoundField DataField="cd_divisionname" HeaderText="Division Name" />
                            <asp:BoundField DataField="cd_divisioncode" HeaderText="Division Code" />
                            <asp:BoundField DataField="cd_deponame" HeaderText="Depo Name" />
                            <asp:BoundField DataField="cd_depocode" HeaderText="Depo Code" />
                            <asp:BoundField DataField="cd_date" HeaderText="Date" />
                            <asp:BoundField DataField="cd_etmno" HeaderText="ETM No" />
                            <asp:BoundField DataField="status" HeaderText="status" />
                            
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" Visible="false" />
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
        </asp:Panel>
    </asp:Panel>



    <asp:Panel  ScrollBars="Horizontal"  ID="panel_Agent" runat="server">
        <asp:Panel     ID="panel_Agent_1" runat="server" ScrollBars="Auto">

            <div class="row">
                <div class="col-lg-12">
                     <h1>Data to Upload</h1>
                    <asp:GridView ID="GridView_Agent" runat="server"
                        AllowPaging="True"  CellPadding="4" PageSize="10" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present to Insert." OnPageIndexChanged="GridView_Agent_PageIndexChanged" OnPageIndexChanging="GridView_Agent_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />

                        <Columns>
                            <asp:BoundField DataField="AgCode" HeaderText="Agent Code" />
                            <asp:BoundField DataField="AgName" HeaderText="Agent Name" />
                            <asp:BoundField DataField="Pswd" HeaderText="Password" Visible="false" />
                            <asp:BoundField DataField="AtStg" HeaderText="At Stage" />
                            <asp:BoundField DataField="IsActive" HeaderText="IS Active" />
                            <asp:BoundField DataField="CardsIssued" HeaderText="Card Issued" />
                            <asp:BoundField DataField="IssuedBy" HeaderText="Issued By" />
                            <asp:BoundField DataField="IssuedDt" HeaderText="Issued Date" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" />

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

        </asp:Panel>
            <br />
        <asp:Panel   ID="panel_Agent_2" runat="server" ScrollBars="Auto">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView_Agent_owned" runat="server"
                        AllowPaging="True" Caption="Existing Data from Database" CellPadding="4" PageSize="10" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_Agent_owned_PageIndexChanged" OnPageIndexChanging="GridView_Agent_owned_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />

                        <Columns>
                            <asp:BoundField DataField="AgCode" HeaderText="Agent Code" />
                            <asp:BoundField DataField="AgName" HeaderText="Agent Name" />
                            <asp:BoundField DataField="Pswd" HeaderText="Password" Visible="false" />
                            <asp:BoundField DataField="AtStg" HeaderText="At Stage" />
                            <asp:BoundField DataField="IsActive" HeaderText="IS Active" />
                            <asp:BoundField DataField="CardsIssued" HeaderText="Card Issued" />
                            <asp:BoundField DataField="IssuedBy" HeaderText="Issued By" />
                            <asp:BoundField DataField="IssuedDt" HeaderText="Issued Date" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" />

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
        </asp:Panel>

    </asp:Panel>


    <asp:Panel  ScrollBars="Horizontal"  ID="panel_driver" runat="server">
        <asp:Panel   ScrollBars="Horizontal" ID="panel_driver_1" runat="server">

            <div class="row">
                <div class="col-lg-12">
                     <h1>Data to Upload</h1>
                    <asp:GridView ID="GridView_Driver" runat="server"
                        AllowPaging="True"  CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present to Insert." OnPageIndexChanged="GridView_Driver_PageIndexChanged" OnPageIndexChanging="GridView_Driver_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>                           
                            <asp:BoundField DataField="drv_code" HeaderText="Driver Code" />
                            <asp:BoundField DataField="name" HeaderText="Driver Name" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" />

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
            <br />

        </asp:Panel>
        <asp:Panel  ScrollBars="Horizontal"   ID="panel_driver_2" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView_Driver_owned" runat="server"
                        AllowPaging="True" Caption="Current Data from Database" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_Driver_owned_PageIndexChanged" OnPageIndexChanging="GridView_Driver_owned_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                           
                            <asp:BoundField DataField="drv_code" HeaderText="Driver Code" />
                            <asp:BoundField DataField="name" HeaderText="Driver Name" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" />

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
        </asp:Panel>
    </asp:Panel>

    <asp:Panel  ScrollBars="Horizontal"   ID="panel_vehicle" runat="server">

        <div class="row">
            <div class="col-lg-12">
                 <h1>Data to Upload</h1>
                <asp:GridView ID="GridView_Vehicle" runat="server"
                    AllowPaging="True" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                    ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%">
                    <PagerStyle CssClass="pagination-ys" />

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
        <br />
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridView_Vehicle_owned" runat="server"
                    AllowPaging="True" Caption="Existing Data from Database" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                    ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White"
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%">
                    <PagerStyle CssClass="pagination-ys" />

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
    </asp:Panel>

    <asp:Panel  ScrollBars="Horizontal"  ID="panel_stage" runat="server">
        <asp:Panel  ScrollBars="Horizontal"   ID="panel_stage_1" runat="server">

          
            <div class="row">
                <div class="col-lg-12">
                      <h1>Data to Upload</h1>
                    <asp:GridView ID="GridView_stage" runat="server"
                        AllowPaging="True"  CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_stage_PageIndexChanged" OnPageIndexChanging="GridView_stage_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:BoundField DataField="rpsd_routeno" HeaderText="Route Number" />
                            <asp:BoundField DataField="rp_bustype" HeaderText="Bus Type" />
                            <asp:BoundField DataField="rpsd_triangleno" HeaderText="Triangle Number" />
                            <asp:BoundField DataField="rpsd_stgnamee" HeaderText="Stage Name" />
                            <asp:BoundField DataField="rpsd_stgnamem" HeaderText="Stage Name2" />
                            <asp:BoundField DataField="rpsd_km" HeaderText="km" />
                            <asp:BoundField DataField="rpsd_stgno" HeaderText="Stage Number" />
                            <asp:BoundField DataField="rpsd_sub" HeaderText="sub" />
                            <asp:BoundField DataField="rpsd_intrsstg" HeaderText="Inter Stage" />
                            <asp:BoundField DataField="rpsd_farenormal" HeaderText="Normal Fare" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="rpsd_stgid" HeaderText="Stage ID" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" />

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
        </asp:Panel>
        <br />
        <asp:Panel  ScrollBars="Horizontal"   ID="panel_stage_2" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView_stage_owned" runat="server"
                        AllowPaging="True" Caption="Existing Data from Database" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                        ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="No records Present." OnPageIndexChanged="GridView_stage_owned_PageIndexChanged" OnPageIndexChanging="GridView_stage_owned_PageIndexChanging">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:BoundField DataField="rpsd_routeno" HeaderText="Route Number" />
                            <asp:BoundField DataField="rp_bustype" HeaderText="Bus Type" />
                            <asp:BoundField DataField="rpsd_triangleno" HeaderText="Triangle Number" />
                            <asp:BoundField DataField="rpsd_stgnamee" HeaderText="Stage Name" />
                            <asp:BoundField DataField="rpsd_stgnamem" HeaderText="Stage Name2" />
                            <asp:BoundField DataField="rpsd_km" HeaderText="km" />
                            <asp:BoundField DataField="rpsd_stgno" HeaderText="Stage Number" />
                            <asp:BoundField DataField="rpsd_sub" HeaderText="sub" />
                            <asp:BoundField DataField="rpsd_intrsstg" HeaderText="Inter Stage" />
                            <asp:BoundField DataField="rpsd_farenormal" HeaderText="Normal Fare" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="rpsd_stgid" HeaderText="Stage ID" />
                            <asp:BoundField DataField="ClientID" HeaderText="Client ID" />
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
        </asp:Panel>
    </asp:Panel>

    <asp:Panel  ScrollBars="Horizontal"   ID="panel_inspector" runat="server">

        <div class="row">
            <div class="col-lg-12">
                  <h1>Data to Upload</h1>
                <asp:GridView ID="GridView_inspector" runat="server"
                    AllowPaging="True" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                    ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" EmptyDataText="No records Present to Insert."
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" OnPageIndexChanged="GridView_inspector_PageIndexChanged" OnPageIndexChanging="GridView_inspector_owned_PageIndexChanging">
                    <PagerStyle CssClass="pagination-ys" />

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
        <br />
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridView_inspector_owned" runat="server"
                    AllowPaging="True" Caption="Existing Data from Database" CellPadding="4" PageSize="15" PagerSettings-Mode="NextPreviousFirstLast"
                    ShowFooter="True" PagerSettings-PageButtonCount="3" Font-Names="Courier New" BackColor="White" EmptyDataText="No records Present."
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" OnPageIndexChanged="GridView_inspector_owned_PageIndexChanged" OnPageIndexChanging="GridView_inspector_owned_PageIndexChanging">
                    <PagerStyle CssClass="pagination-ys" />

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

    </asp:Panel>

                                

    <%-- </asp:UpdatePanel>--%>
</asp:Content>


<%--Route Number	Route Type	Bus Type	Triangle Number	Start Stage	End Stage	Number Of Stops	Local Name	Fare Changed

ConductorCode	ConductorName	VehicleNumber	DivisionName	DivisionCode	DepotCode	Date	ETMNumber	Status


Code	Name	Status

BusID	BusType	Busfare--%>