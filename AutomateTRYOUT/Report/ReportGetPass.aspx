<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportGetPass.aspx.cs" Inherits="AutomateTRYOUT.Report.ReportGetPass" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
            case "Apply":
                return ("yes");
                break;
            case "Find Way Bill":
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
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

       <asp:UpdatePanel ID="upnlKMPLReport" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
    <asp:Panel  ScrollBars="Horizontal" ID="PnlSarchPara" runat="server" Font-Names="Arial" Font-Size="Small" Style="border: 1px solid #000;"  GroupingText=" Gate Pass Report">


       
        <table align="Center" cellpadding="5">
            <tr>
                <td>
                    <asp:Label ID="lblFromDateTime" runat="server" Text="From Date" Font-Size="Medium"> </asp:Label>
                     

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
                        Format="yyyy-MM-dd" Enabled="true">
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
                        Format="yyyy-MM-dd" Enabled="true">
                    </cc1:CalendarExtender>

                </td>
            
          
               <%-- <td>
                    <asp:Label ID="Label1" runat="server" Text="Way Bill"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                    </asp:DropDownList>
                </td>--%>

                <td>
                    <asp:Label ID="lblMachineNo" runat="server" Text="Machine No" Font-Size="Medium"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachineNo" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlMachineNo_SelectedIndexChanged">
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

              <%--  <td>
                     <asp:Label ID="lblMachine" runat="server" Text="Machine" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                      <asp:DropDownList ID="ddlMachine" runat="server" Width="100%" AppendDataBoundItems="true">
                                  <asp:ListItem Text="ALL" Value="ALL">ALL</asp:ListItem>
                            </asp:DropDownList>
                </td>--%>

                  </tr>
                        <tr>
                 <td>
                    <asp:Label ID="lblWayBillsarch" runat="server" Text="Way Bill" Font-Size="Medium" ></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlWyBill" runat="server" Width="100%" AppendDataBoundItems="true" AutoPostBack="true">
                      
                    </asp:DropDownList>
                </td>
            </tr>

              
            
            <tr>
                <td></td>
             <td>
                    <asp:Button ID="Button1"   runat="server" Width="90px" ValidationGroup="Save" OnClick="Button1_Click"  />

                    <asp:Button ID="Button2"  runat="server" Text="Reset" Width="60px" OnClick="Button2_Click"   />


                </td>
              
                <td>

                       <asp:Button ID="btnApply"  runat="server" Text="Apply" Width="60px" OnClick="btnApply_Click" />

                 
                </td>
            </tr>




        </table>
         <table>
                <tr>
                 <td>
                            <asp:Label ID="lblErrorMsg" runat="server" Text=""  Visible="false" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
            </table>
    </asp:Panel>
    

           

       <asp:Panel  ScrollBars="Horizontal" ID="rptpnlGetPass" runat="server" Width="100%" Height="100%" HorizontalAlign="Center" Visible="false">
                <table>
                    <tr>
                        <td>
                           
                            <rsweb:ReportViewer ID="RptGetPass" runat="server" AsyncRendering="False" SizeToReportContent="True"
                                
                                Font-Names="Verdana" EnableExternalImages="true" Font-Size="8pt" WaitMessageFont-Size="14pt"
                                Width="1000px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"></rsweb:ReportViewer>
                          
                        </td>
                        
                     
                    </tr>
                </table>
            </asp:Panel>
       </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
