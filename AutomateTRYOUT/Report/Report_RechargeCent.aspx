<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report_RechargeCent.aspx.cs" Inherits="AutomateTRYOUT.Report.Report_RechargeCent" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style2 {
            width: 274px;
        }
        
    </style>

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
     <asp:ScriptManager ID="ScriptManager2" runat="server" AsyncPostBackTimeout="56000"></asp:ScriptManager>

    <ContentTemplate>
         <asp:Panel  ScrollBars="Horizontal" ID="PnlRechargeCent" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000; margin-left: 0px;"  GroupingText="Recharge Center Report">

        <table align="Center" cellpadding="5"  >
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date" Font-Size="Medium"></asp:Label>
                     

                </td>
                <%-- <td class="auto-style2"> --%>
                   <td>
                    <asp:TextBox ID="txtFromDateTime" runat="server"></asp:TextBox>
                    
                    <cc1:CalendarExtender ID="cetxtFromDateTime" runat="server" TargetControlID="txtFromDateTime" 
                        CssClass="MyCalendar"
                        Format="yyyy-MM-dd" Enabled="true">
                    </cc1:CalendarExtender> 
                    
                </td>
                <td>
                    <asp:Label ID="lblToDateTime" runat="server" Text="To Date " Font-Size="Medium"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDateTime" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="cetxtToDateTime" runat="server" TargetControlID="txtToDateTime"
                        CssClass ="MyCalendar"
                        Format="yyyy-MM-dd" Enabled="true" PopupPosition="BottomRight">
                    </cc1:CalendarExtender>
                </td>
            </tr>
             <tr>
                <td>
                     <asp:Label ID="lblCent" runat="server" Text="Center" Font-Size="Medium" Visible="true"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="ddlCenter" runat="server" Width="50%" AppendDataBoundItems="true" Visible="False">
                               <%--  <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem> --%>
                         <asp:ListItem>ALL</asp:ListItem>
                            </asp:DropDownList>
                    <td>
                        <asp:Label ID="LabelPasTyp" runat="server" Text="Pass Type" Font-Size="Medium" Visible="true"></asp:Label>
                    </td>
                      <td>
                     <asp:TextBox ID="txtPastype" runat="server" MaxLength="2"></asp:TextBox>
                    </td>
                </td>
      
              </tr>


            <tr>
             
                <td></td>
             <td class="auto-style2">
                    <asp:Button ID="BtnAPPly" runat="server" Text="Apply" Width="60px" ValidationGroup="Save" OnClick="BtnAPPly_Click"   />

                    <asp:Button ID="BtnReset" runat="server" Text="Reset" Width="60px" OnClick="BtnReset_Click"   />

                  
                </td>
              
                <td></td>
            </tr>




        </table>
    </asp:Panel>

        <asp:Panel  ScrollBars="Horizontal" ID="rptpnlRechargeCent" runat="server" Width="100%" Height="100%" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px">
                <table >
                    <tr>
                       <td> 
                       <%--   <td class="auto-style1"> found followinf solution from web for drop down misplace --%>
                           <div style="margin-left: 10px; position: relative; ">
                            <rsweb:ReportViewer ID="RptRechargeCent" runat="server" AsyncRendering="False" SizeToReportContent="True"
                                Font-Names="Verdana" EnableExternalImages="true" Font-Size="8pt" WaitMessageFont-Size="14pt"
                                Left="0px"  InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" BorderStyle="Solid" Height="93px"
                                KeepSessionAlive="False" ShowFindControls="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False" ShowBackButton="False"  BorderWidth="1px">
                            </rsweb:ReportViewer>
                          </div>
                        </td> 
                    </tr>
                </table>
            </asp:Panel>

    </ContentTemplate>
</asp:Content>
