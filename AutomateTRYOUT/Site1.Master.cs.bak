using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AutomateTRYOUT
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSessionVar();
          if  (!string.IsNullOrEmpty(Session["username"].ToString()))
          
            { lblUserName.Text = Session["username"].ToString();
            }

            if (!string.IsNullOrEmpty(Session["ClientID"].ToString()))

            {
                lblClientID.Text = Session["ClientID"].ToString();
            }

            hL_Master_RouteMaster.NavigateUrl = "Forms/RouteMasterNew.aspx";
            hL_Master_ConductorMasterNew.NavigateUrl = "Administrator/ConductorMasterAdminstrator.aspx"; //uday "Forms/ConductorMasterNew.aspx";
            hL_Master_AgentsMaster.NavigateUrl = "Forms/AgentMaster.aspx";
            hL_Master_DriverMaster.NavigateUrl = "Forms/DriverMasterNew.aspx";
            hL_Master_VehicleMaster.NavigateUrl = "Forms/VehicleMasterNew.aspx";
            hL_Master_InspectorMaster.NavigateUrl = "Forms/InspectorMaster.aspx";

            hl_OprationsView_RecentTicketsNew.NavigateUrl= "NewIndex.aspx";
            hl_Administrator_UserMaster.NavigateUrl = "Administrator/UserMaster.aspx";
            //hL_reports_GetPass.NavigateUrl = "Report/ReportGetPass.aspx";
            hL_reports_GetPass.NavigateUrl = "Report/MyReportGetPass.aspx";//uday
            //hl_report_wayBill.NavigateUrl = "";
            hl_OprationsView_RecentTickets.NavigateUrl = "RecentTickets.aspx";
            hl_OprationsView_TodaySSummary.NavigateUrl = "index.aspx";
            //  hl_OprationsView_TodaySSummary.Text = "Todays Summary";
            //  hl_OperationsView_WayBills.NavigateUrl = "Report/ReportWaybillSummary.aspx";
              hl_OperationsView_TripSheet.NavigateUrl = "Report/ReportTripSheet.aspx";
            // hl_OperationsView_WayBills.Text = "Way Bills";
            //hl_OperationalView_tickets.NavigateUrl = "Report/ReportTicket.aspx";
            hl_OperationalView_Waybill.NavigateUrl = "Report/ReportWayBill.aspx";
            //  hl_OperationalView_tickets.Text = "Tickets";
            hl_superadmin_ETMMachines.NavigateUrl = "Forms/ETMMaster.aspx";
            hl_SuperAdmin_ClientMaster.NavigateUrl = "";
            hl_reports_Summary.NavigateUrl = "Report/WaybillSummary.aspx";
          //  hl_reports_Summary.Text = "WaybillSummary";
            hl_Administrator_LoadMaster.NavigateUrl = "Administrator/LoadMaster.aspx";

            hL_reports_MIS.NavigateUrl = "Report/ReportRFIDPass.aspx";
            hL_reports_NewMIS.NavigateUrl = "Report/MISReport.aspx";
            hL_reports_InspectorReport.NavigateUrl = "Report/Report_Insp.aspx";
            hL_reports_Agent.NavigateUrl = "Forms/AgentPerformance.aspx";


            //hL_GirdView_Gatepass.NavigateUrl = "Forms/GetPassReport.aspx";
            hL_GirdView_StgWiseReport.NavigateUrl = "Report/ReportStgWise.aspx";
            hL_GirdView_TicketReport.NavigateUrl = "Forms/TicketReport.aspx";
            hl_superadmin_WayBillMaster.NavigateUrl = "Administrator/WayBillMaster.aspx";

            //added mar22 NON Standard but hardcoded
            //if((Session["ClientID"].ToString() == "CCTHOFF1") || (Session["ClientID"].ToString() == "AUTOMATE"))
            if (Session["ClientRole"].ToString() == "1") //if client is group head
            {
                hL_GirdView_PassTrackReport.NavigateUrl = "Report/Report_Pass_Track.aspx";
                hL_GirdView_InspPerformance.NavigateUrl = "Report/Report_Insp_Perform.aspx";
                hL_GirdView_Recharging.NavigateUrl = "Report/Report_RechargeCent.aspx";
            }
            else
            {
                hL_GirdView_InspPerformance.Visible = false;
                hL_GirdView_PassTrackReport.Visible = false;
                hL_GirdView_Recharging.Visible = false;
            }

            hL_Master_ETMMaster.NavigateUrl = "Administrator/ETMMaster.aspx";

            hL_Master_DivAndDepoMaster.NavigateUrl = "Forms/DivAndDepoMaster.aspx";

            hl_superadmin_DivAndDepoMaster.NavigateUrl = "Administrator/DivAndDepoMaster.aspx";

            hl_superadmin_ConductorMasterAdminstrator.NavigateUrl = "Administrator/ConductorMasterAdminstrator.aspx";

            hl_SuperAdmin_ClientMaster.NavigateUrl = "Forms/ClientMaster.aspx";
            
            menu_master.Visible = false;
            menu_Administrator.Visible = false;
            menu_superadmin.Visible = false;
            menu_reports.Visible = false;
            menu_OperationsView.Visible = false;

            if (!string.IsNullOrEmpty(Session["RoleName"].ToString()))          
            {
                handlingMenuRights(Session["RoleName"].ToString());
            }
            

        }
        public void CheckSessionVar()
        {
            try
            {
                if (null == Session["RoleName"] ||
                    null == Session["ClientID"] ||
                    null == Session["username"]
                    )
                {
                    Response.Redirect("~/Login.aspx");
                    //if (Request.Cookies["UserSettings"]["username"] != null)
                    //    Session["username"] = Request.Cookies["UserSettings"]["username"];

                    //if (Request.Cookies["UserSettings"]["ClientID"] != null)
                    //    Session["ClientID"] = Request.Cookies["UserSettings"]["ClientID"];

                    //if (Request.Cookies["UserSettings"]["ClientID"] != null)
                    //    Session["RoleName"] = Request.Cookies["UserSettings"]["RoleName"];
                }

                //if (string.IsNullOrEmpty(Session["RoleName"].ToString()) ||
                //    string.IsNullOrEmpty(Session["ClientID"].ToString()) ||
                //    string.IsNullOrEmpty(Session["username"].ToString())
                //    )
                //{
                //    if (Request.Cookies["UserSettings"]["username"] != null)
                //        Session["username"] = Request.Cookies["UserSettings"]["username"];

                //    if (Request.Cookies["UserSettings"]["ClientID"] != null)
                //        Session["ClientID"] = Request.Cookies["UserSettings"]["ClientID"];

                //    if (Request.Cookies["UserSettings"]["ClientID"] != null)
                //        Session["RoleName"] = Request.Cookies["UserSettings"]["RoleName"];

                //    //Response.Redirect("~/Login.aspx");
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SetActiveMenu(string menuName)
        {

            menu_Administrator.Attributes["class"] = "";
            menu_master.Attributes["class"] = "";
            menu_OperationsView.Attributes["class"] = "";
            menu_reports.Attributes["class"] = "";
            menu_superadmin.Attributes["class"] = "";

            //menu_Administrator_ul.Attributes["class"] = "nav nav-second-level collapse";
            //menu_master_ul.Attributes["class"] = "nav nav-second-level collapse";
            //menu_OperationsView_ul.Attributes["class"] = "nav nav-second-level collapse";
            //menu_reports_ul.Attributes["class"] = "nav nav-second-level collapse";
            //menu_superadmin_ul.Attributes["class"] = "nav nav-second-level collapse";

            switch (menuName)
            {
                case "menu_Administrator":
                    menu_Administrator.Attributes["class"] = "active";
                   //menu_Administrator_ul.Attributes["class"] = "nav nav-second-level";
                    break;
                case "menu_master":
                    menu_master.Attributes["class"] = "active";
                    //menu_master_ul.Attributes["class"] = "nav nav-second-level";
                    break;
                case "menu_OperationsView":
                    menu_OperationsView.Attributes["class"] = "active";
                    //menu_OperationsView_ul.Attributes["class"] = "nav nav-second-level";
                    break;
                case "menu_reports":
                    menu_reports.Attributes["class"] = "active";
                    //menu_reports_ul.Attributes["class"] = "nav nav-second-level";
                    break;
                case "menu_superadmin":
                    menu_superadmin.Attributes["class"] = "active";
                    //menu_superadmin_ul.Attributes["class"] = "nav nav-second-level";
                    break;
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            try {
                //Response.CacheControl = "no-cache";
                //Session.Abandon();
                //Response.Redirect("~/Login.aspx");
                Response.Redirect("~/LogOut.aspx");
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Login.aspx");
                throw ex;

            }
        }


        private void handlingMenuRights(String role)
        {
            switch (role)
            {
                case "Administrator":
                    menu_master.Visible = true;
                    menu_Administrator.Visible = true;
                    menu_superadmin.Visible = false;
                    menu_reports.Visible = true;
                    menu_OperationsView.Visible = true;
                    break;
                case "SuperAdministrator":
                    menu_master.Visible = true;
                    menu_Administrator.Visible = true;
                    menu_superadmin.Visible = true;
                    menu_reports.Visible = true;
                    menu_OperationsView.Visible = true;
                    break;
                case "NormalUser":
                    menu_master.Visible = true;
                    menu_Administrator.Visible = false;
                    menu_superadmin.Visible = false;
                    menu_reports.Visible = true;
                    menu_OperationsView.Visible = true;
                    break;
                case "Manager":
                    menu_master.Visible = true;
                    menu_Administrator.Visible = false;
                    menu_superadmin.Visible = false;
                    menu_reports.Visible = true;
                    menu_OperationsView.Visible = true;
                    break;
                default: break;
            }

        }



    }
}