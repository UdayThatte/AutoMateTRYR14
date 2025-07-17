using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace AutomateTRYOUT.Report
{
    public partial class TicketView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Replace('-', '/');
                txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
                bindGridView();
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_master");
                //  ddlConductorFill();
                ddlWayBillFill();
                // ddlMachineFill();
                ddlTicketTypeFill();
                ddlRouteFill();





            }
        }



        //private void ddlConductorFill()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("GetConductorDetails"))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
        //                da.SelectCommand = cmd;
        //                using (DataSet ds = new DataSet())
        //                {
        //                    da.Fill(ds);
        //                    ddlConductor.DataSource = ds;
        //                    ddlConductor.DataTextField = "cd_condrdetails_code";
        //                    ddlConductor.DataValueField = "cd_condrdetails_code";
        //                    ddlConductor.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}


        private void ddlWayBillFill()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetWayBillFill"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlWyBill.DataSource = ds;
                            ddlWyBill.DataTextField = "wbp_waybillno";
                            ddlWyBill.DataValueField = "wbp_waybillno";
                            ddlWyBill.DataBind();
                        }
                    }
                }
            }
        }


        private void ddlRouteFill()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetRoute"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlRoute.DataSource = ds;
                            ddlRoute.DataTextField = "RouteName";
                            ddlRoute.DataValueField = "id";
                            ddlRoute.DataBind();
                        }
                    }
                }
            }
        }



        //private void ddlMachineFill()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("GetMachine"))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
        //                da.SelectCommand = cmd;
        //                using (DataSet ds = new DataSet())
        //                {
        //                    da.Fill(ds);
        //                    ddlMachine.DataSource = ds;
        //                    ddlMachine.DataTextField = "MACHINENAME";
        //                    ddlMachine.DataValueField = "MACHINENAME";
        //                    ddlMachine.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}


        private void ddlTicketTypeFill()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetTicketType"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlTicketType.DataSource = ds;
                            ddlTicketType.DataTextField = "td_ticket_code";
                            ddlTicketType.DataValueField = "td_ticket_code";
                            ddlTicketType.DataBind();
                        }
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView(); //bindgridview will get the data source and bind it again
        }

        //this is some sample data 
        private void bindGridView()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT  `id`, `ClientID`, `wytd_waybill_no`, `td_trip_no`, `td_route_no`, `td_ticket_code`, `td_ticket_num`, `td_stg_from`, `td_stg_to`, `td_full_ticket`, `td_half_ticket`, `td_luggage_ticket`, `td_pass_ticket`, `td_ticket_fare`, `td_ticket_date`, `td_ticket_time`, `td_doc_rec_no`, `td_con_case_code`, `td_state_code`, `td_half`, `td_full`, `td_bustype`, `Mc_Serial`, `Div_Name`, `Dep_Name`  FROM newver_ticketdetails order by id desc limit 1000"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }






        protected void btnApply_Click(object sender, EventArgs e)
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            string sqlQuery = "";
            string sqlWhere = "";
            // if (ddlConductor.SelectedValue == "ALL")
            // {
            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

            // sqlWhere = "And wbp.ClientID = @ClientID_in ";


            //  }
            //  else
            //  {
            //    sqlWhere = "And wbp.wbp_condrdetails = @Conductor_in ";
            // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";




            // }

            // if (ddlMachine.SelectedValue == "ALL")
            //  {
            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

            //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";


            // }
            //  else
            //  {
            //    sqlWhere = sqlWhere + " And wbp.MachineNo = @Machine_in";
            // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";




            // }



            if (ddlWyBill.SelectedValue == "ALL")
            {
                //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

                //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";


            }
            else
            {
                sqlWhere = sqlWhere + " And wytd_waybill_no = @WayBill_in";
                // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";




            }

            if (ddlRoute.SelectedValue == "ALL")
            {
                //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

                //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";


            }
            else
            {
                sqlWhere = sqlWhere + " And td_route_no = @Route_in";
                // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";




            }
            if (ddlTicketType.SelectedValue == "ALL")
            {
                //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

                //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";


            }
            else
            {
                sqlWhere = sqlWhere + " And td_ticket_code =@ddlTicketType";
                // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";




            }


            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT  `id`, `ClientID`, `wytd_waybill_no`, `td_trip_no`, `td_route_no`, `td_ticket_code`, `td_ticket_num`, `td_stg_from`, `td_stg_to`, `td_full_ticket`, `td_half_ticket`, `td_luggage_ticket`, `td_pass_ticket`, `td_ticket_fare`, `td_ticket_date`, `td_ticket_time`, `td_doc_rec_no`, `td_con_case_code`, `td_state_code`, `td_half`, `td_full`, `td_bustype`, `Mc_Serial`, `Div_Name`, `Dep_Name`  FROM newver_ticketdetails Where ClientID=@ClientID_in" + sqlWhere + " order by id desc limit 1000"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        // cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlTicketType", ddlTicketType.SelectedValue);
                        cmd.Parameters.AddWithValue("@Route_in", ddlRoute.SelectedValue);
                        cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            bindGridView();
        }
    }
}