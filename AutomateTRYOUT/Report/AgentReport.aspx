<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgentReport.aspx.cs" Inherits="AutomateTRYOUT.Report.AgentReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <asp:UpdatePanel ID="upnlSearchWayBillMaster" runat="server" RenderMode="Inline" UpdateMode="Conditional">
          <ContentTemplate>
               <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

     <asp:Panel  ScrollBars="Horizontal" ID="rptPnlReport" runat="server" Width="100%" Height="100%" HorizontalAlign="Center">
                <table>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="RptAgent" runat="server" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Size="14pt"
                                Width="1000px " ShowBackButton="true"></rsweb:ReportViewer>
                          
                        </td>
                    </tr>
                </table>
            </asp:Panel>
  </ContentTemplate>
                     </asp:UpdatePanel>
</asp:Content>

