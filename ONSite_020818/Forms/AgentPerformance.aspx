<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgentPerformance.aspx.cs" Inherits="AutomateTRYOUT.Forms.AgentPerformance" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 112px;
        }
    </style>
</asp:Content>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">

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
            case "Apply":
                return ("yes");
                break;
            case "Reset":
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

    <asp:Button ID="HiddenButton" runat="server" CssClass="hidden" Text="Hidden Button"
            ToolTip="Necessary for Modal Popup Extender" />
        <cc1:ModalPopupExtender ID="PleaseWaitPopup" BehaviorID="PleaseWaitPopup"
            runat="server" TargetControlID="HiddenButton" PopupControlID="PleaseWaitMessagePanel"
            BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
        <h2 style="text-align:center">Agent Performance</h2>
    <asp:Panel  ScrollBars="Horizontal" ID="plnSearchAgentMaster" runat="server" BorderStyle="Groove" >

        <table>
           <%-- <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Agent Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAgentName" runat="server" Width="100%">
                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" Font-Size="Medium" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    <cc1:calendarextender id="cetxtFromDateTime" runat="server" targetcontrolid="txtFromDateTime"
                        format="yyyy-MM-dd" enabled="true">
                    </cc1:calendarextender>
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" Font-Size="Medium" runat="server" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:calendarextender id="cetxtToDateTime" runat="server" targetcontrolid="txtToDateTime"
                        format="yyyy-MM-dd" enabled="true">
                    </cc1:calendarextender>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Commission Percentage"></asp:Label>
                    <asp:TextBox ID="TextBoxCommissionPercentage" runat="server" value="5" Width="44px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                  <td>
                    <asp:Button ID="btnApply" runat="server" Font-Size="Medium" Text="Apply" Width="60px" ValidationGroup="Save" OnClick="btnApply_Click"  />
                      <asp:Button ID="Button1" runat="server" Font-Size="Medium" OnClick="Button1_Click" Text="Export" />
                    <asp:Button ID="btnReset" runat="server" Font-Size="Medium" Text="Reset" Width="60px" OnClick="btnReset_Click"/>
                </td>
            </tr>

        </table>
    </asp:Panel>


    <asp:Panel  ScrollBars="Horizontal" ID="panel_GridAgentPerformance" runat="server">
        <asp:GridView ID="GridAgentPerformance" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanged="GridAgentPerformance_PageIndexChanged" OnPageIndexChanging="GridAgentPerformance_PageIndexChanging" PageSize="30">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="AgentID">
                    <ItemTemplate>
                        <asp:Label ID="lblAgentID" runat="server" Text='<%#Eval("AgentID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent Name">
                    <ItemTemplate>
                        <asp:Label ID="lblAgentName" runat="server" Text='<%#Eval("AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tickets Sold">
                    <ItemTemplate>
                        <asp:Label ID="lblTicketsSold" runat="server" Text='<%#Eval("TicketsSold") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField><asp:TemplateField HeaderText="TicketsAmount">
                    <ItemTemplate>
                        <asp:Label ID="lblTicketsAmount" runat="server" Text='<%#Eval("TicketsAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Commission(%)">
                    <ItemTemplate>
                        <asp:Label ID="lblCommissionPercentage" runat="server" Text='<%#Eval("CommissionPercentage") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Commission">
                    <ItemTemplate>
                        <asp:Label ID="lblCommission" runat="server" Text='<%#Eval("Commission") %>'></asp:Label>
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
    </asp:Panel>


</asp:Content>
