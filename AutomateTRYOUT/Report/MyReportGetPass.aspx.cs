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
    public partial class ReportGetPass : System.Web.UI.Page
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
               // ddlFillConductor();
            }


        }


        //private void ddlFillConductor()
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
        //                cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
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

        protected DataTable BindCommentDetails()
        {


             rptpnlGetPass.Visible = true; //?? Uday not in MIS


            
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("MyReportGetPass"))      //uday
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);

                    
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
            RptGetPass.LocalReport.DataSources.Clear();
            RptGetPass.Visible = true;
           // RptGetPass.LocalReport.DataSources.Add(new ReportDataSource("MyGetPassDataset", BindCommentDetails()));
            RptGetPass.LocalReport.DataSources.Add(new ReportDataSource("GetPass", BindCommentDetails()));
            RptGetPass.LocalReport.ReportPath = Server.MapPath(reportPath);

            //RptGetPass.LocalReport.DisplayName = "GetPass" + "_" + DateTime.Now.ToString("yyyy-MM-dd ");
            RptGetPass.LocalReport.DisplayName = "GatePass" + "_" + ddlWyBill.SelectedValue.ToString() + "_" + DateTime.Now.ToString("yyyy-MM-dd ");
            
            String condrName = "";
            String drivernames = "";
            String vehicalno = "";
            String FromStage = "";
            String ToStage = "";
            String waybillno = "";
            String MachineNo = "";
            String Collection = "";
            String Expenses = "";
            String RFIDUsage = "";
            String statusnew = "";
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {

                    using (MySqlCommand cmd = new MySqlCommand("ReportHeadWayBill"))
                    //// using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);

                            da.SelectCommand = cmd;
                            using (DataTable dtTop = new DataTable())
                            {
                                da.Fill(dtTop);

                                if (dtTop.Rows.Count > 0)
                                {

                                    condrName = dtTop.Rows[0]["conductor"].ToString();
                                    drivernames = dtTop.Rows[0]["Driver"].ToString();
                                    vehicalno = dtTop.Rows[0]["wbp_vehicalno"].ToString();
                                    waybillno = dtTop.Rows[0]["wbp_waybillno"].ToString();
                                    MachineNo = dtTop.Rows[0]["MachineNo"].ToString();

                                    DataTable td1 = new DataTable();
                                    td1 = (DataTable)Session["dt2"];
                                    int count = td1.Rows.Count;
                                    if (td1.Rows.Count > 0)  //>=
                                    
                                    {
                                        FromStage = td1.Rows[0]["td_ticket_num"].ToString();
                                        ToStage = td1.Rows[count - 1]["td_ticket_num"].ToString();
                                    }
                                    else
                                    {

                                        FromStage = "Not Data";
                                        ToStage = "Not Data";
                                    }
                                    // date = dtTop.Rows[0]["wbp_date"].ToString();
                                    Collection = dtTop.Rows[0]["Collection"].ToString();
                                    Expenses = dtTop.Rows[0]["Expenses"].ToString();
                                    RFIDUsage = dtTop.Rows[0]["RFIDUsage"].ToString();
                                    statusnew = dtTop.Rows[0]["status"].ToString();
                                }//if row count
                                else
                                {

                                    condrName = "Not Data";
                                    drivernames = "Not Data";
                                    vehicalno = "Not Data";
                                    waybillno = "Not Data";
                                    MachineNo = "Not Data";

                                    FromStage = "Not Data";
                                    ToStage = "Not Data";
                                    // date = dtTop.Rows[0]["wbp_date"].ToString();
                                    Collection = "Not Data";
                                    Expenses = "Not Data";
                                    RFIDUsage = "Not Data";

                                }


                            }//using datatbl
                        }//using dataadapter
                    }//using mysql cmd
                }//using mysqlcon


                ReportParameter[] param = new ReportParameter[11];
                
                param[0] = new ReportParameter("WayBillNo", ddlWyBill.SelectedValue.ToString(), false);
                param[1] = new ReportParameter("username", Session["username"].ToString(), false);
                param[1] = new ReportParameter("MachineNo", MachineNo, false);
                param[2] = new ReportParameter("vehicalno", vehicalno, false);
                param[3] = new ReportParameter("Cname", condrName, false);
                param[4] = new ReportParameter("dname", drivernames, false);
                param[5] = new ReportParameter("status", statusnew, false);
                param[6] = new ReportParameter("StageFrom", FromStage, false);
                param[7] = new ReportParameter("StageTo", ToStage, false);
                param[8] = new ReportParameter("Collection", Collection, false);
                param[9] = new ReportParameter("Expenses", Expenses, false);
                param[10] = new ReportParameter("username", Session["username"].ToString(), false);
               // param[11] = new ReportParameter("ClientID", Session["ClientID"].ToString(), false);
               // RptGetPass.LocalReport.EnableExternalImages = true;
                RptGetPass.LocalReport.SetParameters(param);
                RptGetPass.LocalReport.Refresh();

            }

            catch (Exception ex)
            {
                string errormsg = ex.ToString();
                throw ex;
            }

        }

        private void BindDataToReport(String reportPath)
        {
              try
            {
           
            RptGetPass.LocalReport.DataSources.Clear();
            RptGetPass.Visible = true;
            RptGetPass.LocalReport.DataSources.Add(new ReportDataSource("MyGetPassDataset", BindCommentDetails()));
            RptGetPass.LocalReport.ReportPath = string.Empty;
            RptGetPass.LocalReport.ReportPath = Server.MapPath(reportPath);
                //uday not in MIS this.RptGetPass.LocalReport.DisplayName = "GetPass" + "_" + DateTime.Now.ToString("yyyy-MM-dd ");

                //String condrName = "";
                //String drivernames = "";
                //String vehicalno = "";
                //String FromStage = "";
                //String ToStage = "";
                //String date = DateTime.Now.ToString("yyyy-MM-dd ");
                //String waybillno = "";
                //String MachineNo = "";
                //String Collection = "";
                //String Expenses = "";
                //String RFIDUsage = "";
                //String statusnew = "";



                //string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                //using (MySqlConnection con = new MySqlConnection(constr))
                //{

                //    using (MySqlCommand cmd = new MySqlCommand("ReportHeadWayBill"))
                //    //// using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                //    {
                //        using (MySqlDataAdapter da = new MySqlDataAdapter())
                //        {
                //            cmd.Connection = con;
                //            cmd.CommandType = CommandType.StoredProcedure;
                //            cmd.CommandTimeout = 600;
                //            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                //            cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);

                //            da.SelectCommand = cmd;
                //            using (DataTable dtTop = new DataTable())
                //            {
                //                da.Fill(dtTop);

                //                if (dtTop.Rows.Count > 0)
                //                {

                //                    condrName = dtTop.Rows[0]["conductor"].ToString();
                //                    drivernames = dtTop.Rows[0]["Driver"].ToString();
                //                    vehicalno = dtTop.Rows[0]["wbp_vehicalno"].ToString();
                //                    waybillno = dtTop.Rows[0]["wbp_waybillno"].ToString();
                //                    MachineNo = dtTop.Rows[0]["MachineNo"].ToString();

                //                    DataTable td1 = new DataTable();
                //                    td1 = (DataTable)Session["dt2"];
                //                    int count = td1.Rows.Count;
                //                    if (td1.Rows.Count >= 0)
                //                    {
                //                        FromStage = td1.Rows[0]["td_ticket_num"].ToString();
                //                        ToStage = td1.Rows[count - 1]["td_ticket_num"].ToString();
                //                    }
                //                    else
                //                    {

                //                        FromStage = "Not Data";
                //                        ToStage = "Not Data";
                //                    }
                //                    // date = dtTop.Rows[0]["wbp_date"].ToString();
                //                    Collection = dtTop.Rows[0]["Collection"].ToString();
                //                    Expenses = dtTop.Rows[0]["Expenses"].ToString();
                //                    RFIDUsage = dtTop.Rows[0]["RFIDUsage"].ToString();
                //                    statusnew = dtTop.Rows[0]["status"].ToString();
                //                }
                //                else
                //                {

                //                    condrName = "Not Data";
                //                    drivernames = "Not Data";
                //                    vehicalno = "Not Data";
                //                    waybillno = "Not Data";
                //                    MachineNo = "Not Data";

                //                    FromStage = "Not Data";
                //                    ToStage = "Not Data";
                //                    // date = dtTop.Rows[0]["wbp_date"].ToString();
                //                    Collection = "Not Data";
                //                    Expenses = "Not Data";
                //                    RFIDUsage = "Not Data";

                //                }


                //            }
                //        }
                //    }
                //}


                //  cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                // cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                // cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                //cmd.Parameters.AddWithValue("@FromDate", txtFromDateTime.Text);
                //cmd.Parameters.AddWithValue("@ToDate", txtToDateTime.Text);




                //    ReportParameter[] param = new ReportParameter[3];
                //    param[0] = new ReportParameter("ClientID", Session["ClientID"].ToString(), false);
                //    param[1] = new ReportParameter("WayBillNo", ddlWyBill.SelectedValue.ToString(), false);
                //  //  param[2] = new ReportParameter("Conductor", ddlConductor.SelectedValue.ToString(), false);
                // param[2] = new ReportParameter("username", Session["username"].ToString(), false);


                //if (dtTop.Rows.Count > 0)
                //{
                //    if (dtTop.Rows[0]["wbp_condrdetails"].ToString().Equals(""))
                //    {
                //        param[4] = new ReportParameter("condrdetails", "Not", false);
                //    }
                //    else
                //    {
                //        param[4] = new ReportParameter("condrdetails", dtTop.Rows[0]["wbp_condrdetails"].ToString(), false);
                //    }


                //    param[5] = new ReportParameter("FromStage", dtTop.Rows[0]["FromStage"].ToString(), false);
                //    param[6] = new ReportParameter("ToStage", dtTop.Rows[0]["ToStage"].ToString(), false);

                //}

                //ReportParameter[] param = new ReportParameter[17];
                //                param[0] = new ReportParameter("ClientID", Session["ClientID"].ToString(), false);
                //                param[1] = new ReportParameter("WayBillNo", ddlWyBill.SelectedValue.ToString(), false);

                //                param[2] = new ReportParameter("username", Session["username"].ToString(), false);
                //                param[3] = new ReportParameter("Cname", condrName, false);
                //                param[4] = new ReportParameter("dname", drivernames, false);
                //                param[5] = new ReportParameter("vehicalno", vehicalno, false);   
                //               param[6] = new ReportParameter("FromStage", txtFromDateTime.Text, false);
                //               param[7] = new ReportParameter("ToStage", txtToDateTime.Text, false);
                //               param[8] = new ReportParameter("waybillno", waybillno, false);


                //param[9] = new ReportParameter("MachineNo", MachineNo, false);

                //param[10] = new ReportParameter("StageFrom", FromStage, false);
                //param[11] = new ReportParameter("StageTo", ToStage, false);
                //param[12] = new ReportParameter("date", date, false);

                //param[13] = new ReportParameter("Collection", Collection, false);

                //param[14] = new ReportParameter("Expenses", Expenses, false);
                //param[15] = new ReportParameter("RFIDUsage", RFIDUsage, false);
                //param[16] = new ReportParameter("status", statusnew, false);

                  ReportParameter[] param = new ReportParameter[1];
                 param[0] = new ReportParameter("WayBillNo","9820", false);

                //RptGetPass.LocalReport.EnableExternalImages = true;
                RptGetPass.LocalReport.SetParameters(param);
                RptGetPass.LocalReport.Refresh();


                //        }
                //    }
                //}
            }


            // ReportViewer1.LocalReport.Refresh();
            // }
            catch (Exception ex)
            {
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
                string paths = "~/Report/Report2.rdlc";
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
                                        lblErrorMsg.Text = "Not Way bill";

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
       //     ddlFillConductor();
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
            //ddlFillConductor();
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

