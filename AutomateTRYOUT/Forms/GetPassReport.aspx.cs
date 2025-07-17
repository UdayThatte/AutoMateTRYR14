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

namespace AutomateTRYOUT.Forms
{
    public partial class GetPassReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_master");


                txtFromDateTime.Visible = true;
                txtToDateTime.Visible = true;
                lblMachineNo.Visible = true;
                ddlMachineNo.Visible = true;
                lblConductor.Visible = true;
                ddlConductor.Visible = true;
                lblFromDateTime.Visible = true;
                lblToDateTime.Visible = true;
                Button2.Visible = false;




                ddlnewverdivdepotmanagement();

                rptpnlGetPass.Visible = false;

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yy ").Replace('-', '-');
                txtToDateTime.Text = DateTime.Now.ToString("dd-MMM-yy ").Replace('-', '-');
                ddlWayBillFill();
                ddlFillddlMachineNo();
                //  ddlTicketTypeFill();
                ddlRouteFill();
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
                        cmd.CommandTimeout = 600;
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
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
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
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
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


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(""))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@txtFromDateTime", txtFromDateTime.Text);
                        cmd.Parameters.AddWithValue("@txtToDateTime", txtToDateTime.Text);
                        cmd.Parameters.AddWithValue("@Route_in", ddlRoute.SelectedValue);
                        cmd.Parameters.AddWithValue("@DivDepotManagement_in", ddldivdepotmanagement.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlMachineNo", ddlMachineNo.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlWyBill", ddlWyBill.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlConductor", ddlConductor.SelectedValue);
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            gvplnTicketReport.DataSource = ds;

                            gvplnTicketReport.DataBind();
                        }
                    }
                }
            }




        }

        protected DataTable BindCommentDetails()
        {


            rptpnlGetPass.Visible = true;










            //if (CheckBox1.Checked == true)
            //{
            //    if (ddlWyBill.SelectedValue == "ALL")
            //    {

            //    }
            //    else
            //    {
            //        sqlWhere = sqlWhere + " And td.wytd_waybill_no=@WayBill_in"; //'"+ ddlWyBill.SelectedValue.ToString()+"'";
            //     }
            //}

            //if (chkFromDateTime.Checked == true)
            //{

            //    if (txtFromDateTime.Text == "")
            //    {

            //    }
            //    else
            //    {
            //        sqlWhere = sqlWhere + " And td_ticket_date between @FromDate And @ToDate";


            //    }
            //}

            //if (chkRoute.Checked == true)
            //{

            //    if (ddlRoute.SelectedValue == "ALL")
            //    {


            //    }
            //    else
            //    {
            //        sqlWhere = sqlWhere + " And td.td_route_no = @Route_in";
            //    }

            //}





            //if (String.IsNullOrEmpty(sqlWhere))
            //{
            //    Sqlstring = @"SELECT  `id` , `ClientID`, `wytd_waybill_no`, `td_trip_no`, `td_route_no`,IFNULL((select Concat(rp.rp_routeno,':',rp.rp_startstg,'-',rp.rp_endstg)  From newver_routeprogramming rp where rp_routeno=td.td_route_no),'Not Defined') as routeName ,`td_ticket_code`, `td_ticket_num`,IFNULL((select CONCAT(rps.rpsd_stgcode,' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno=1 AND rps.rpsd_routeno =td.td_route_no AND rps.rpsd_stgno = td.td_stg_from),'Not Defined') as FromStage,IFNULL((select CONCAT(rps.rpsd_stgcode,' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno=1 AND rps.rpsd_routeno =td.td_route_no AND rps.rpsd_stgno = td.td_stg_to),'Not Defined') as TOStage,`td_stg_from`, `td_stg_to`, `td_full_ticket`, `td_half_ticket`, `td_luggage_ticket`, `td_pass_ticket`, `td_ticket_fare`, `td_ticket_date`, `td_ticket_time`, `td_doc_rec_no`, `td_con_case_code`, `td_state_code`, `td_half`, `td_full`, `td_bustype`, `Mc_Serial`, `Div_Name`, `Dep_Name`  FROM newver_ticketdetails  td	order by id desc limit 1000";

            //}
            //else
            //{
            //    // Sqlstring = @"SELECT `id` , `ClientID`, `wytd_waybill_no`, `td_trip_no`, `td_route_no`,IFNULL((select Concat(rp.rp_routeno,':',rp.rp_startstg,'-',rp.rp_endstg)  From newver_routeprogramming rp where rp_routeno=td.td_route_no),'Not Defined') as routeName ,`td_ticket_code`, `td_ticket_num`,IFNULL((select CONCAT(rps.rpsd_stgcode,' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno=1 AND rps.rpsd_routeno =td.td_route_no AND rps.rpsd_stgno = td.td_stg_from),'Not Defined') as FromStage,IFNULL((select  CONCAT(rps.rpsd_stgcode,' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno=1 AND rps.rpsd_routeno =td.td_route_no AND rps.rpsd_stgno = td.td_stg_to And rps.ClientID=@ClientID_in),'Not Defined') as TOStage,`td_stg_from`, `td_stg_to`, `td_full_ticket`, `td_half_ticket`, `td_luggage_ticket`, `td_pass_ticket`, `td_ticket_fare`, `td_ticket_date`, `td_ticket_time`, `td_doc_rec_no`, `td_con_case_code`, `td_state_code`, `td_half`, `td_full`, `td_bustype`, `Mc_Serial`, `Div_Name`, `Dep_Name`  FROM newver_ticketdetails  td  Where td.ClientID=@ClientID_in And DATE_FORMAT(STR_TO_DATE(td.td_ticket_date, '%d/%m/%Y'), '%Y-%m-%d') BETWEEN DATE_FORMAT(STR_TO_DATE(@FromDate, '%d/%m/%Y'), '%Y-%m-%d') AND DATE_FORMAT(STR_TO_DATE(@ToDate, '%d/%m/%Y'), '%Y-%m-%d')" + sqlWhere + " order by id desc limit 1000";
            //    Sqlstring = @"SELECT `id` , `ClientID`, `wytd_waybill_no`, `td_trip_no`, `td_route_no`,IFNULL((select Concat(rp.rp_routeno,':',rp.rp_startstg,'-',rp.rp_endstg)  From newver_routeprogramming rp where rp_routeno=td.td_route_no),'Not Defined') as routeName ,`td_ticket_code`, `td_ticket_num`,IFNULL((select CONCAT(rps.rpsd_stgcode,' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno=1 AND rps.rpsd_routeno =td.td_route_no AND rps.rpsd_stgno = td.td_stg_from),'Not Defined') as FromStage,IFNULL((select  CONCAT(rps.rpsd_stgcode,' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno=1 AND rps.rpsd_routeno =td.td_route_no AND rps.rpsd_stgno = td.td_stg_to And rps.ClientID=@ClientID_in),'Not Defined') as TOStage,`td_stg_from`, `td_stg_to`, `td_full_ticket`, `td_half_ticket`, `td_luggage_ticket`, `td_pass_ticket`, `td_ticket_fare`, `td_ticket_date`, `td_ticket_time`, `td_doc_rec_no`, `td_con_case_code`, `td_state_code`, `td_half`, `td_full`, `td_bustype`, `Mc_Serial`, `Div_Name`, `Dep_Name`  FROM newver_ticketdetails  td  Where td.ClientID=@ClientID_in " + sqlWhere + " order by id desc limit 1000";

            //}

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("ReportGetPass"))
                // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);

                        //  cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                        // cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                        // cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                        //cmd.Parameters.AddWithValue("@FromDate", txtFromDateTime.Text);
                        //cmd.Parameters.AddWithValue("@ToDate", txtToDateTime.Text);
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);

                            return dt;
                        }
                    }
                }
            }

        }


        private void ddlnewverdivdepotmanagement()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetDivAndDepoList"))
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
                            ddldivdepotmanagement.DataSource = ds;
                            ddldivdepotmanagement.DataTextField = "DivisionName";
                            ddldivdepotmanagement.DataValueField = "ID";
                            ddldivdepotmanagement.DataBind();
                        }
                    }
                }
            }
        }

        private void BindDataToReport(String reportPath)
        {
            //  try
            //{

            ////RptGetPass.LocalReport.DataSources.Clear();
            ////RptGetPass.Visible = true;
            ////RptGetPass.LocalReport.DataSources.Add(new ReportDataSource("GetPassDataset", BindCommentDetails()));
            ////RptGetPass.LocalReport.ReportPath = string.Empty;
            ////RptGetPass.LocalReport.ReportPath = Server.MapPath(reportPath);
            //////String userID = Convert.ToString(Context.User.Identity.Name);
            //////String date = System.DateTime.Now.ToShortDateString();
            ////String condrName = "";
            ////String drivernames = "";
            ////String vehicalno = "";
            ////String FromStage = "";
            ////String ToStage = "";
            ////String date = "";

            //// if (txtFromDate.Text != "")
            // {
            //     FromDate = txtFromDate.Text;
            // }
            // else
            // {
            //     FromDate = "All";
            // }
            // if (txtToDate.Text != "")
            // {
            //     ToDate = txtToDate.Text;
            // }
            // else
            // {
            //     ToDate = "All";
            // }
            // if (txtEmpCode.Text != "")
            // {
            //     EmployeeCode = txtEmpCode.Text;
            // }
            // else
            // {
            //     EmployeeCode = "All";
            // }
            // if (txtEmpName.Text != "")
            // {
            //     EmployeeName = txtEmpName.Text;
            // }
            // else
            // {
            //     EmployeeName = "All";
            // }

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

                            //condrName = dtTop.Rows[0]["wbp_condrdetails"].ToString();
                            //drivernames = dtTop.Rows[0]["wbp_driver1details"].ToString();
                            //vehicalno = dtTop.Rows[0]["wbp_vehicalno"].ToString();



                            //FromStage = dtTop.Rows[0]["FromStage"].ToString();
                            //ToStage = dtTop.Rows[0]["ToStage"].ToString();
                            //date = dtTop.Rows[0]["wbp_date"].ToString();


                        }
                    }
                }
            }
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

            //ReportParameter[] param = new ReportParameter[9];
            //param[0] = new ReportParameter("ClientID", Session["ClientID"].ToString(), false);
            //param[1] = new ReportParameter("WayBillNo", ddlWyBill.SelectedValue.ToString(), false);
            ////  param[2] = new ReportParameter("Conductor", ddlConductor.SelectedValue.ToString(), false);
            //param[2] = new ReportParameter("username", Session["username"].ToString(), false);
            //param[3] = new ReportParameter("Cname", condrName, false);
            //param[4] = new ReportParameter("dname", drivernames, false);
            //param[5] = new ReportParameter("vehicalno", vehicalno, false);


            //param[6] = new ReportParameter("FromStage", FromStage, false);
            //param[7] = new ReportParameter("ToStage", ToStage, false);
            //param[8] = new ReportParameter("date", date, false);











            //RptGetPass.LocalReport.SetParameters(param);
            //RptGetPass.LocalReport.Refresh();


            //        }
            //    }
            //}
        }


        // ReportViewer1.LocalReport.Refresh();
        // }
        //catch (Exception ex)
        //{
        //    throw  ("1000:" + ex.Message);
        //}
        //  }



        protected void Button1_Click(object sender, EventArgs e)
        {


            if (Button1.Text == "Apply")

            {
                Button2.Visible = true;
                DataTable dt = BindCommentDetails();
                string paths = "~/Report/rdlcGetPass.rdlc";
                BindDataToReport(paths);
            }

            if (Button1.Text == "Find Way Bill")
            {
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
                // txtFromDateTime.Visible = false;
                // txtToDateTime.Visible = false;
                lblMachineNo.Visible = false;
                ddlMachineNo.Visible = false;
                lblConductor.Visible = false;
                ddlConductor.Visible = false;
                lblFromDateTime.Visible = false;
                lblToDateTime.Visible = false;

             

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
                            cmd.Parameters.AddWithValue("@ddlConductor", ddlConductor.SelectedValue);
                            cmd.Parameters.AddWithValue("@FromDate", txtFromDateTime.Text);
                            cmd.Parameters.AddWithValue("@ToDate", txtToDateTime.Text);


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
                                ddlWyBill.DataSource = dtTop;
                                ddlWyBill.DataTextField = "wbp_waybillno";
                                ddlWyBill.DataValueField = "wbp_waybillno";
                                ddlWyBill.DataBind();




                            }
                        }
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

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
            txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yy ").Replace('-', '-');
            txtToDateTime.Text = DateTime.Now.ToString("dd-MMM-yy ").Replace('-', '-');
            //ddlWayBillFill();

            // ddlMachineFill();
            ddlWyBill.Items.Clear();
            ddlWyBill.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlConductor.Items.Add(new ListItem("ALL", "ALL"));
            // ddlWyBill.Items.Add(new ListItem("ALL", "ALL"));
            // ddlTicketTypeFill();
            // ddlRouteFill();
            //  chkFromDateTime.Checked = false;

            rptpnlGetPass.Visible = false;
        }

        protected void ddlWyBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptpnlGetPass.Visible = false;
        }
    }
}



/*
 * DROP PROCEDURE `ReportGetPassToPara`;
CREATE DEFINER=`dbuser`@`%` PROCEDURE `ReportGetPassToPara`(IN `ClientID_In` VARCHAR(25), IN `MachineNo_in` VARCHAR(25), IN `ddlConductor_in` VARCHAR(25), IN `FromDate_in` DATETIME, IN `ToDate_in` DATETIME) DETERMINISTIC NO SQL SQL SECURITY DEFINER BEGIN
	#Routine body goes here...
Select  
wbp.status as status,
wbp.wbp_waybillno,
td.td_stg_from as FromStage,
td.td_stg_to as ToStage,
wbp.wbp_condrdetails,
wbp.wbp_driver1details,
wbp.wbp_vehicalno,
wbp.wbp_divisionname,
wbp.wbp_divisioncode,
wbp.wbp_depocode,
wbp.wbp_date,
wbp.wbp_waybillschedule,
wbp.wbp_etmno,
wbp.status,
wbp.CreatedDT  
from  
newver_waybillprogramming wbp left outer join newver_ticketdetails  td on td.wytd_waybill_no=wbp.wbp_waybillno

Where wbp.ClientID=ClientID_In 
-- And wbp.MachineNo IN ( CASE WHEN WayBill_in ='ALL' THEN wbp.MachineNo ELSE WayBill_in  END)
 And  wbp.MachineNo IN ( CASE WHEN MachineNo_in ='ALL' THEN  wbp.MachineNo ELSE MachineNo_in  END)
And wbp.wbp_condrdetails IN ( CASE WHEN ddlConductor_in ='ALL' THEN wbp.wbp_condrdetails ELSE ddlConductor_in  END) AND  
wbp.bi_date BETWEEN FromDate_in And ToDate_in -- And  wbp.wbp_waybillno IN ( CASE WHEN WayBill_in ='ALL' THEN  wbp.wbp_waybillno ELSE WayBill_in  END)
 
-- "HTCGAJ01","17050104","ALL" 17050104 ALL  Concat('0000000',WayBill_in)  IN `WayBill_in` varchar(25),
ORDER BY 
wbp.wbp_waybillno;
END


    */
     
