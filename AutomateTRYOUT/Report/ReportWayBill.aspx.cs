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
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;


namespace AutomateTRYOUT.Report
{
    public partial class ReportWayBill : System.Web.UI.Page
    {
        DataTable dt2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_reports");

                ddlMachineNo.Items.Clear();
                ddlMachineNo.Items.Insert(0, new ListItem("ALL", "ALL"));
                Button1.Text = "Find Way Bill";

               txtFromDateTime.Visible = true;
               txtToDateTime.Visible = true;
                lblMachineNo.Visible = true;
                ddlMachineNo.Visible = true;
                lblConductor.Visible = true;
                ddlConductor.Visible = true;
                lblFromDateTime.Visible = true;
                lblToDateTime.Visible = true;
                Button2.Visible = false;
                btnApply.Visible = false;
              


                lblWayBillsarch.Visible = false;
                ddlWyBill.Visible = false;

                rptpnlGetPass.Visible = false;

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
               txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd ");
              //  ddlWayBillFill();
                // ddlMachineFill();
                //  ddlTicketTypeFill();
                //ddlRouteFill();
                ddlFillddlMachineNo();
                ddlFillConductor();
            }


        }


        private void ddlFillConductor()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetConductorDetails"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlConductor.DataSource = ds;
                            ddlConductor.DataTextField = "cd_condrdetails_code";
                            ddlConductor.DataValueField = "cd_condrdetails_code";
                            ddlConductor.DataBind();
                        }
                    }
                }
            }
        }
        //rdlcGetPass



        private void ddlFillddlMachineNo()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetMachine"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlMachineNo.DataSource = ds;
                            ddlMachineNo.DataTextField = "MACHINENAME";
                            ddlMachineNo.DataValueField = "MACHINENAME";
                            ddlMachineNo.DataBind();
                        }
                    }
                }
            }
        }


        //private void ddlWayBillFill()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("GetWayBillFillForTicket"))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
        //                da.SelectCommand = cmd;
        //                using (DataSet ds = new DataSet())
        //                {
        //                    da.Fill(ds);
        //                    ddlWyBill.DataSource = ds;
        //                    ddlWyBill.DataTextField = "wbp_waybillno";
        //                    ddlWyBill.DataValueField = "wbp_waybillno";
        //                    ddlWyBill.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}

        //private void ddlRouteFill()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("GetRoute"))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
        //                da.SelectCommand = cmd;
        //                using (DataSet ds = new DataSet())
        //                {
        //                    da.Fill(ds);
        //                    ddlRoute.DataSource = ds;
        //                    ddlRoute.DataTextField = "RouteName";
        //                    ddlRoute.DataValueField = "id";
        //                    ddlRoute.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}





        //private void ddlTicketTypeFill()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("GetTicketType"))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
        //                da.SelectCommand = cmd;
        //                using (DataSet ds = new DataSet())
        //                {
        //                    da.Fill(ds);
        //                    ddlTicketType.DataSource = ds;
        //                    ddlTicketType.DataTextField = "td_ticket_code";
        //                    ddlTicketType.DataValueField = "td_ticket_code";
        //                    ddlTicketType.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}

        protected void btnApply_Click(object sender, EventArgs e)
        {

         

           


        }

        protected DataTable BindCommentDetailsExp()
        {


            rptpnlGetPass.Visible = true; //?? Uday not in MIS



            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("Report_WayBill_Exp"))      //uday
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue.ToString());


                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            Session["dt3"] = dt;

                            return dt;
                        }
                    }
                }
            }

        }


        protected DataTable BindCommentDetails()
        {


             rptpnlGetPass.Visible = true; //?? Uday not in MIS


            
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("Report_WayBill"))      //uday
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue.ToString());

                    
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            Session["dt2"] = dt;

                            return dt;
                        }
                    }
                }
            }

        }

        private void MyBindDataToReport(String reportPath)
        {
            RptWayBill.LocalReport.DataSources.Clear();
            RptWayBill.Visible = true;
            // RptGetPass.LocalReport.DataSources.Add(new ReportDataSource("MyGetPassDataset", BindCommentDetails()));
            DataTable resultData = BindCommentDetails();
            DataTable resultDataExp = BindCommentDetailsExp();
            RptWayBill.LocalReport.DataSources.Add(new ReportDataSource("WayBill_Exp", resultDataExp));
            RptWayBill.LocalReport.ReportPath = Server.MapPath(reportPath);

            //RptGetPass.LocalReport.DisplayName = "GetPass" + "_" + DateTime.Now.ToString("yyyy-MM-dd ");
            RptWayBill.LocalReport.DisplayName = "WayBill" + "_" + ddlWyBill.SelectedValue.ToString() + "_" + DateTime.Now.ToString("yyyy-MM-dd ");

            try

            {
                if(resultData.Rows.Count >0)
                {
                    String Pvehicalno = resultData.Rows[0]["vehicalno"].ToString();
                    String PCliendID = Session["ClientID"].ToString();
                    String PConductorName = resultData.Rows[0]["ConductorCode"].ToString();
                    String PStatus = resultData.Rows[0]["status"].ToString();
                    String PMcNo = resultData.Rows[0]["MachineNo"].ToString();
                    String PIssueDt = resultData.Rows[0]["wbp_date"].ToString();
                    String PWyBillNo = resultData.Rows[0]["WaybillNo"].ToString();

                    int lastrow = resultData.Rows.Count - 1;
                    //String PFirstTick = resultData.Rows[0]["TickStart"].ToString();
                    // String PLastTick = resultData.Rows[lastrow]["TickEnd"].ToString();
                    String PTotalTickets = resultData.Rows[0]["TotalTicketIssued"].ToString();
                    String PTrips = resultData.Rows[0]["Trips"].ToString();
                    String PFullPaxCount = resultData.Rows[0]["FullPaxCount"].ToString();
                    String PFullTicketFare = resultData.Rows[0]["FullTicketFare"].ToString();
                    String PHalfPaxCount = resultData.Rows[0]["HalfPaxCount"].ToString();
                    String PHalfTicketFare = resultData.Rows[0]["HalfTicketFare"].ToString();
                    String PLuggageCount = resultData.Rows[0]["LuggageCount"].ToString();
                    String PLuggageFare = resultData.Rows[0]["LuggageFare"].ToString();
                    String PConcessionPaxCount = resultData.Rows[0]["ConcessionPaxCount"].ToString();
                    String PConcessionFare = resultData.Rows[0]["ConcessionFare"].ToString();
                    String PPassCount = resultData.Rows[0]["PassCount"].ToString();
                    String PPntyCnt = resultData.Rows[0]["PntyCnt"].ToString();
                    String PPenalty = resultData.Rows[0]["Penalty"].ToString();
                    String PExpCnt = resultData.Rows[0]["ExpCnt"].ToString();
                    String PExpenses = resultData.Rows[0]["Expenses"].ToString();
                    String PRfidPaxCnt = resultData.Rows[0]["RfidPaxCnt"].ToString();
                    String PTotalRFIDuse3 = resultData.Rows[0]["TotalRFID3"].ToString();
                    String PTotalRFIDuse4 = resultData.Rows[0]["TotalRFID4"].ToString();
                    String PRFIDRchrgCnt = resultData.Rows[0]["RFIDRchrgCnt"].ToString();
                    String PRFIDRchrgAmt = resultData.Rows[0]["RFIDRchrgAmt"].ToString();
                    String PTotalFare = resultData.Rows[0]["TotalFare"].ToString();
                    String PNetCash = resultData.Rows[0]["NetCash"].ToString();
                    String PTotalRFIDuse5 = resultData.Rows[0]["TotalRFID5"].ToString();
                    int AmtType3,AmtType4, AmtType5;
                    int.TryParse(PTotalRFIDuse3, out AmtType3);
                    int.TryParse(PTotalRFIDuse4, out AmtType4);
                    int.TryParse(PTotalRFIDuse5, out AmtType5);
                    string PTotalRFIDuse = (AmtType3 + AmtType4 + AmtType5).ToString();

                    ReportParameter[] param = new ReportParameter[31];
                    param[0] = new ReportParameter("Pvehicalno", Pvehicalno, false);
                    param[1] = new ReportParameter("PClientID", PCliendID, false);
                    param[2] = new ReportParameter("PConductorName", PConductorName, false);
                    param[3] = new ReportParameter("PStatus", PStatus, false);
                    param[4] = new ReportParameter("PMcNo", PMcNo, false);
                    param[5] = new ReportParameter("PIssueDt", PIssueDt, false);
                    param[6] = new ReportParameter("PWyBillNo", PWyBillNo, false);
                    param[7] = new ReportParameter("PTotalTickets", PTotalTickets, false);
                    param[8] = new ReportParameter("PTrips", PTrips, false);
                    param[9] = new ReportParameter("PFullPaxCount", PFullPaxCount, false);
                    param[10] = new ReportParameter("PFullTicketFare", PFullTicketFare, false);
                    param[11] = new ReportParameter("PHalfPaxCount", PHalfPaxCount, false);
                    param[12] = new ReportParameter("PHalfTicketFare", PHalfTicketFare, false);
                    param[13] = new ReportParameter("PLuggageCount", PLuggageCount, false);
                    param[14] = new ReportParameter("PLuggageFare", PLuggageFare, false);
                    param[15] = new ReportParameter("PConcessionPaxCount", PConcessionPaxCount, false);
                    param[16] = new ReportParameter("PConcessionFare", PConcessionFare, false);
                    param[17] = new ReportParameter("PPassCount", PPassCount, false);
                    param[18] = new ReportParameter("PPntyCnt", PPntyCnt, false);
                    param[19] = new ReportParameter("PPenalty", PPenalty, false);
                    param[20] = new ReportParameter("PExpCnt", PExpCnt, false);
                    param[21] = new ReportParameter("PExpenses", PExpenses, false);
                    param[22] = new ReportParameter("PRfidPaxCnt", PRfidPaxCnt, false);
                    param[23] = new ReportParameter("PTotalRFIDuse3", PTotalRFIDuse3, false);
                    param[24] = new ReportParameter("PTotalRFIDuse4", PTotalRFIDuse4, false);
                    param[25] = new ReportParameter("PTotalRFIDuse", PTotalRFIDuse, false);
                    param[26] = new ReportParameter("PRFIDRchrgCnt", PRFIDRchrgCnt, false);
                    param[27] = new ReportParameter("PRFIDRchrgAmt", PRFIDRchrgAmt, false);
                    param[28] = new ReportParameter("PTotalFare", PTotalFare, false);
                    param[29] = new ReportParameter("PNetCash", PNetCash, false);
                    param[30] = new ReportParameter("PTotalRFIDuse5", PTotalRFIDuse5, false);

                    // param[8] = new ReportParameter("PLastTick", PLastTick, false);
                    //// RptGetPass.LocalReport.EnableExternalImages = true;
                    RptWayBill.LocalReport.SetParameters(param);
                    RptWayBill.LocalReport.Refresh();


                }
            }

            catch (Exception ex)
            {
                string errormsg = ex.ToString();
                throw ex;
            }

        }

  
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            lblErrorMsg.Visible = false;

            if (Button1.Text == "Apply")

            {
                Button2.Visible = true;
                //uday repeated again in BindDataToReport   DataTable dt = BindCommentDetails();
                //string paths = "~/Report/MyrdlcGetPass.rdlc";
                string paths = "~/Report/ReportWayBill.rdlc";
                //string paths = "~/Report/Report1.rdlc";
                MyBindDataToReport(paths);
            }


            if (Button1.Text == "Find Way Bill")
            {

                //if (ddlConductor.SelectedValue.ToString().Equals("ALL"))
                //{
                //    lblErrorMsg.Visible = true;
                //    lblErrorMsg.Text = "Select a Value For Conductor code";


                //}
                //else
                //{

                    //// string Fromdate =Convert.ToString(txtFromDateTime.Text.Split('/'));
                    // int FromDayy = Convert.ToInt16(txtFromDateTime.Text.Substring(0, 2));

                    //// int fromDay=Convert.ToInt16(FromDayy.Split('/'));

                    //int fromMonth= Convert.ToInt16(txtFromDateTime.Text.Substring(4, 6)); ;
                    // int fromyear;
                    // int fromHH;
                    // int fromMM;


                    // int ToDay;
                    // int ToMonth;
                    // int Toear;
                    // int ToHH;
                    // int ToMM;


                    Button2.Visible = true;
                    txtFromDateTime.Visible = false;
                    txtToDateTime.Visible = false;
                    lblMachineNo.Visible = false;
                    ddlMachineNo.Visible = false;
                    lblConductor.Visible = false;
                    ddlConductor.Visible = false;
                    lblFromDateTime.Visible = false;
                    lblToDateTime.Visible = false;

                    Button1.Text = "Apply";

                    lblWayBillsarch.Visible = true;
                    ddlWyBill.Visible = true;


                    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {

                        using (MySqlCommand cmd = new MySqlCommand("ReportGetPassTopara"))
                        // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter())
                            {
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                                cmd.Parameters.AddWithValue("@MachineNo_in", ddlMachineNo.SelectedValue);
                                cmd.Parameters.AddWithValue("@ddlConductor_in", ddlConductor.SelectedValue);
                                cmd.Parameters.AddWithValue("@FromDate_in", Convert.ToDateTime(txtFromDateTime.Text));
                                cmd.Parameters.AddWithValue("@ToDate_in", Convert.ToDateTime(txtToDateTime.Text));


                                // cmd.Parameters.AddWithValue("@ddlFromDay", ddlFromDay.SelectedValue );
                                // cmd.Parameters.AddWithValue("@ddlFromMonth", ddlFromMonth.SelectedValue);
                                //cmd.Parameters.AddWithValue("@ddlFromYear", ddlFromyear.SelectedValue);

                                // cmd.Parameters.AddWithValue("@ddlToDay", ddltoDay.SelectedValue);
                                // cmd.Parameters.AddWithValue("@ddlToMonth", ddltoMonth.SelectedValue);
                                // cmd.Parameters.AddWithValue("@ddlToYear", ddltoyear.SelectedValue);
                                //cmd.Parameters.AddWithValue("@ddlConductor", ddlt.SelectedValue);





                                //    cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);

                                //  cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                                // cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                                // cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);

                                da.SelectCommand = cmd;
                                using (DataTable dtTop = new DataTable())
                                {

                                    da.Fill(dtTop);

                                    if (dtTop.Rows.Count > 0)
                                    {
                                        Button1.Visible = true;
                                        ddlWyBill.DataSource = dtTop;
                                        ddlWyBill.DataTextField = "wbp_waybillno";
                                        ddlWyBill.DataValueField = "wbp_waybillno";
                                        ddlWyBill.DataBind();
                                    }
                                   else
                                    {
                                        Button1.Visible = false;
                                        lblWayBillsarch.Visible = false;
                                        ddlWyBill.Visible = false;
                                        lblErrorMsg.Visible = true;
                                        lblErrorMsg.Text = "No Way bills";

                                    }




                                }
                            }
                        }
                    }
                }
           // }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            lblErrorMsg.Text = "";
            lblErrorMsg.Visible = false;

            lblErrorMsg.Text ="";

            ddlMachineNo.Items.Clear();
            ddlMachineNo.Items.Insert(0, new ListItem("ALL", "ALL"));
            Button2.Visible = false;
            Button1.Text = "Find Way Bill";
           
           txtToDateTime.Visible = true;
            lblMachineNo.Visible = true;
            ddlMachineNo.Visible = true;
            lblConductor.Visible = true;
            ddlConductor.Visible = true;
            lblFromDateTime.Visible = true;
            lblToDateTime.Visible = true;
            ddlWyBill.Items.Clear();
            ddlFillddlMachineNo();
            ddlFillConductor();
            Button1.Visible = true;
            txtFromDateTime.Visible = true;

            ddlWyBill.Visible = false;
            lblWayBillsarch.Visible = false;
            ddlConductor.Items.Clear();
            ddlWyBill.Items.Clear();
            txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd ");
            //ddlWayBillFill();

            // ddlMachineFill();
            ddlWyBill.Items.Clear();
         
            ddlConductor.Items.Add(new ListItem("ALL", "ALL"));
            // ddlWyBill.Items.Add(new ListItem("ALL", "ALL"));
            // ddlTicketTypeFill();
            // ddlRouteFill();
            //  chkFromDateTime.Checked = false;
            ddlFillConductor();
            rptpnlGetPass.Visible = false;
        }

        protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblErrorMsg.Text = "";
            lblErrorMsg.Visible = false;

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("GetMachineWiseCondrdetails"))
                // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@MachineNo_in", ddlMachineNo.SelectedValue);
                      


                        // cmd.Parameters.AddWithValue("@ddlFromDay", ddlFromDay.SelectedValue );
                        // cmd.Parameters.AddWithValue("@ddlFromMonth", ddlFromMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlFromYear", ddlFromyear.SelectedValue);

                        // cmd.Parameters.AddWithValue("@ddlToDay", ddltoDay.SelectedValue);
                        // cmd.Parameters.AddWithValue("@ddlToMonth", ddltoMonth.SelectedValue);
                        // cmd.Parameters.AddWithValue("@ddlToYear", ddltoyear.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlConductor", ddlt.SelectedValue);





                        //    cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);

                        //  cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                        // cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                        // cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);

                        da.SelectCommand = cmd;
                        using (DataTable dtTop = new DataTable())
                        {
                            ddlConductor.Items.Clear();
                            ddlConductor.Items.Add(new ListItem("ALL", "ALL"));
                            da.Fill(dtTop);
                            ddlConductor.DataSource = dtTop;
                            ddlConductor.DataTextField = "wbp_condrdetails";
                            ddlConductor.DataValueField = "wbp_condrdetails";
                            ddlConductor.DataBind();




                        }
                    }
                }
            }


        }
    }
}

