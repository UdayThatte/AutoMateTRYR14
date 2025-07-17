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
    public partial class ReportWaybillSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_master");
                //txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy ").Replace('-', '/');
                // txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MM-yy ").Replace('-', '-');
                //  txtToDateTime.Text = DateTime.Now.ToString("dd-MM-yy ").Replace('-', '-');

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Replace('-', '/');
                txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');

                bindGridView();
                ddlConductorFill();
                // ddlWayBillFill();
                ddlMachineFill();
               
                //  ddlTicketTypeFill();
                // ddlRouteFill();



            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView(); //bindgridview will get the data source and bind it again
        }
        protected void GridView_DataBound(Object sender, EventArgs e)
        {
            //GridView grid = (GridView)sender;
            //BoundField col = (BoundField)grid.Columns[5];
            //col.DataFormatString = "₹ {0:##,##,##,###}";
        }

        protected void GV_RowDataBound(object o, GridViewRowEventArgs e)
        {
            //// apply custom formatting to data cells
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // set formatting for the category cell
            //    TableCell cell = e.Row.Cells[0];
            //    // set formatting for value cells
            //    for (int i = 1; i < e.Row.Cells.Count; i++)
            //    {
            //        if (i == 6)
            //        {
            //            cell.Text = String.Format("₹ {0:##,##,##,###}", cell.Text);

            //            cell.HorizontalAlign = HorizontalAlign.Right;
            //        }
            //    }
            //}
        }


        protected DataTable BindCommentDetails()
        {








            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;


            string sqlQuery = "";
            string sqlWhere = "";
            if (ddlConductor.SelectedValue == "ALL")
            {
            }
            else
            {
                sqlWhere = "And wbp.wbp_condrdetails = @Conductor_in ";
            }

            //if (ddlMachine.SelectedValue == "ALL")
            //{
            //}
            //else
            //{
            //    sqlWhere = sqlWhere + " And wbp.MachineNo = @Machine_in";
            //}
            //if (chkFromDateTime.Checked == true)
            //{
            //    sqlWhere = sqlWhere + " And wbp.Wbp_date Between  @FromDate_in And  @ToDate_in";
            //}
            //else
            //{
            //}

            //    sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select Max(cd.cd_condrdetails) from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails And wbp.ClientID = @ClientID_in) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE wbp.wbp_waybillno = td.wytd_waybill_no wbp.ClientID = @ClientID_in ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no wbp.ClientID = @ClientID_in ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  wbp.ClientID = @ClientID_in) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select max(dn.`name`) from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details ), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle', 0 as  'WBClosingCode',wbp.WBCloserRemar as  'ClosingRemark',(SELECT count(1) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no wbp.ClientID = @ClientID_in) as 'TicketCount'from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in " + sqlWhere + " order by wbp.id desc limit 1000";

             //   sqlQuery = "select * from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in " + sqlWhere + " order by wbp.id desc limit 1000";







            // string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                  
                   //"waybillsummary"
                   "SearchWayBillSummary"
                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        //  cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@Machine_in", ddlMachine.SelectedValue);
                        cmd.Parameters.AddWithValue("@FromDate_in", Convert.ToDateTime(txtFromDateTime.Text));
                      cmd.Parameters.AddWithValue("@ToDate_in",Convert.ToDateTime(txtToDateTime.Text));

                      cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);


                    


                        //cmd.Parameters.AddWithValue("@ddlFromDay", ddlFromDay.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlFromMonth", ddlFromMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlFromYear", ddlFromyear.SelectedValue);

                        //cmd.Parameters.AddWithValue("@ddlToDay", ddltoDay.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlToMonth", ddltoMonth.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlToYear", ddltoyear.SelectedValue);


                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            //  GridView1.DataSource = dt;
                            //GridView1.DataBind();
                            return dt;
                        }
                    }
                }
            }
           
        }
        //// UserAccessDefinition.objPermission permission = AAAManager.getUserPermission(TxtUserId.Text);
        //// String OperationCentre = permission.Dataset;
        ////// try
        ////// {
        ////     mainreport.AttendenceDatatableDataTable dt = new mainreport.AttendenceDatatableDataTable();
        ////     using (SqlConnection conn = DatabaseManager.Instance.GetSQLConnection())
        ////     {

        ////         SqlCommand cmd = new SqlCommand("Report.spEmployeeAttendence", conn);
        ////         {
        ////             SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////             conn.Open();
        ////             cmd.CommandType = CommandType.StoredProcedure;
        ////             cmd.Parameters.Add("@OperationCentre", SqlDbType.VarChar).Value = OperationCentre;
        ////             if (chkDate.Checked == true)
        ////             {
        ////                 if (!(txtFromDate.Text.Equals("")))
        ////                 {
        ////                     cmd.Parameters.Add("@FromEDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtFromDate.Text);
        ////                 }
        ////                 if (!(txtToDate.Text.Equals("")))
        ////                 {
        ////                     cmd.Parameters.Add("@ToEDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtToDate.Text);
        ////                 }
        ////             }
        ////             if (chkEmpCode.Checked == true)
        ////             {
        ////                 cmd.Parameters.Add("@EmployeeCode_in", SqlDbType.NVarChar).Value = txtEmpCode.Text;
        ////             }
        ////             if (chkEmpName.Checked == true)
        ////             {
        ////                 cmd.Parameters.Add("@EmployeeName_in", SqlDbType.NVarChar).Value = txtEmpName.Text;
        ////             }

        ////             cmd.ExecuteNonQuery();

        ////             da.Fill(dt);
        ////             conn.Close();
        ////         }
        ////     }
        ////     return dt;
        //// }

        //catch (Exception ex)
        //{
        //    return null;
        //    throw new BGTechException("1000:" + ex.Message);
        //}


        private void BindDataToReport(String reportPath)
        {
          //  try
            //{
                RptWayBillSummary.LocalReport.DataSources.Clear();
                RptWayBillSummary.Visible = true;
                RptWayBillSummary.LocalReport.DataSources.Add(new ReportDataSource("WaybillSummary", BindCommentDetails()));
                RptWayBillSummary.LocalReport.ReportPath = string.Empty;
                RptWayBillSummary.LocalReport.ReportPath = Server.MapPath(reportPath);
                String userID = Convert.ToString(Context.User.Identity.Name);
                String date = System.DateTime.Now.ToShortDateString();
                String FromDate = "";
                String ToDate = "";
                String EmployeeCode = "";
                String EmployeeName = "";
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

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("ClientID_in", Session["ClientID"].ToString(), false);
               param[1] = new ReportParameter("UserName", Session["username"].ToString(), false);
                //param[2] = new ReportParameter("FromDate", FromDate, false);
                //param[3] = new ReportParameter("ToDate", ToDate, false);
                //param[4] = new ReportParameter("EmployeeCode", EmployeeCode, false);
                //param[5] = new ReportParameter("EmployeeName", EmployeeName, false);
                RptWayBillSummary.LocalReport.SetParameters(param);
                RptWayBillSummary.LocalReport.Refresh();
                // ReportViewer1.LocalReport.Refresh();
           // }
            //catch (Exception ex)
            //{
            //    throw  ("1000:" + ex.Message);
            //}
        }

        //this is some sample data 
        private void bindGridView()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                 
                    "waybillsummary"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();


                            //Calculate Sum and display in Footer Row
                            decimal totalAmount = dt.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                            decimal totalPax = dt.AsEnumerable().Sum(row => row.Field<decimal>("PaxCount"));
                            decimal totalLuggage = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageCount"));
                            decimal totalPass = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            GridView1.FooterRow.Cells[0].Text = "Total";
                            GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[5].Text = totalAmount.ToString("N0");
                            GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[6].Text = totalPax.ToString("N0");
                            GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[7].Text = totalLuggage.ToString("N0");
                            GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[8].Text = totalPass.ToString("N0");
                            GridView1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                        }
                    }
                }
            }
        }


        private void ddlConductorFill()
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
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
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
        //                    ddlConductor.DataValueField = "id";
        //                    ddlConductor.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}
        //private void ddlWayBillFill()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("GetWayBillFill"))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                //   cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
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
        //                cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
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



        private void ddlMachineFill()
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
                        // cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlMachine.DataSource = ds;
                            ddlMachine.DataTextField = "MACHINENAME";
                            ddlMachine.DataValueField = "MACHINENAME";
                            ddlMachine.DataBind();
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
        //                cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
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

            // Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r]|[J,j][U,u][N,n]|[S,s][E,e][P,p]|[N,n][O,o][V,v]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n]|[M,m][A,a][R,r]|[M,m][A,a][Y,y]|[J,j][U,u][L,l]|[A,a][U,u][G,g]|[O,o][C,c][T,t]|[D,d][E,e][C,c])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");
            // DateTime FromDate, ToDate;
            // int min, max;
            // Match mtStartDt = Regex.Match(txtFromDateTime.Text, regexDt.ToString());
            //  Match mtEndDt = Regex.Match(txtToDateTime.Text, regexDt.ToString());

            // FromDate = Convert.ToDateTime(txtFromDateTime.Text);
            //  ToDate = Convert.ToDateTime(txtToDateTime.Text);
            DataTable dt = BindCommentDetails();
            string paths = "~/Report/rdlcWaybillSummary.rdlc";
            BindDataToReport(paths);

           
            //sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select Max(1) cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails And wbp.ClientID = @ClientID_in) as 'Conductor',(SELECT Max(1) IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'Amount',(SELECT Max(1) IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'PaxCount',(SELECT Max(1) IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in) as 'LuggageCount',(SELECT Max(1) IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  And wbp.ClientID = @ClientID_in) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select Max(1) dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details And wbp.ClientID = @ClientID_in), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark',(SELECT count(1) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'TicketCount' from newver_waybillprogramming wbp where wbp.ClientID =@ClientID_in " + sqlWhere + " order by wbp.id desc limit 1000";



            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";
            // sqlWhere = "And wbp.ClientID = @ClientID_in ";
            // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";
            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

            //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";



            // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";            // if (ddlWyBill.SelectedValue == "ALL")
            //  {
            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

            //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";


            //  }
            //  else
            //   {
            //      sqlWhere = sqlWhere + " And wbp.wbp_waybillno = @WayBill_in";
            // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";



            //
            //}




            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

            //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";




            // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";








            //if (txtToDateTime.Text == "")
            //{
            //    //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in  order by wbp.id desc limit 1000";

            //    //sqlWhere = sqlWhere + "And wbp.ClientID = @ClientID_in";


            //}
            //else
            //{
            //    sqlWhere = sqlWhere + " And wbp.CreatedDT = @ToDate_in";
            //    // sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in And wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";




            //}



            //sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails And wbp.ClientID = @ClientID_in ) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  And wbp.ClientID = @ClientID_in) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in " + sqlWhere + " order by wbp.id desc limit 1000";            //string sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no ) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark' from newver_waybillprogramming wbp where wbp.ClientID = @ClientID_in or wbp.wbp_waybillno = @WayBill_in or wbp.MachineNo = @Machine_in or wbp.wbp_condrdetails = @Conductor_in order by wbp.id desc limit 1000";    // And wbp.CreatedDT between  @FromDate_in And wbp.CreatedDT=@ToDate_in



            //  sqlQuery = "select wbp.wbp_waybillno as 'WaybillNo',wbp.CreatedDT 'WBDate',wbp.`status`,wbp.wbp_condrdetails as 'ConductorCode',(select cd.cd_condrdetails from newver_conductordetails cd where cd.cd_condrdetails_code = wbp.wbp_condrdetails And wbp.ClientID = @ClientID_in) as 'Conductor',(SELECT IFNULL(sum(td.td_full), 0) + IFNULL(sum(td.td_half), 0) + IFNULL(sum(td.td_luggage), 0) + IFNULL(sum(td.td_pass), 0) FROM newver_ticketdetails td WHERE wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'Amount',(SELECT IFNULL(sum(td.td_full_ticket), 0) + IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'PaxCount',(SELECT IFNULL(sum(td.td_luggage_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in) as 'LuggageCount',(SELECT IFNULL(sum(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  And wbp.ClientID = @ClientID_in) as 'PassCount',CONCAT(IFNULL(wbp.wbp_driver1details, ''), '-', IFNULL((select dn.`name` from newver_drivernames dn where dn.drv_code = wbp.wbp_driver1details And wbp.ClientID = @ClientID_in), '')) as 'Driver',wbp.MachineNo as 'MachineNo',wbp.wbp_vehicalno as 'Vehicle',CASE WHEN wbp.WBCloseCode = -1 THEN 0 ELSE wbp.WBCloseCode END as 'WBClosingCode',wbp.WBCloserRemar 'ClosingRemark',(SELECT count(1) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no And wbp.ClientID = @ClientID_in ) as 'TicketCount' from newver_waybillprogramming wbp where wbp.ClientID =@ClientID_in " + sqlWhere + " order by wbp.id desc limit 1000";


            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand(sqlQuery))//"SearchWayBillSummary"))
            //    {
            //        using (MySqlDataAdapter da = new MySqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            //  cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
            //            cmd.Parameters.AddWithValue("@FromDate_in", txtFromDateTime.Text);
            //            cmd.Parameters.AddWithValue("@ToDate_in", txtToDateTime.Text);

            //            cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);


            //            cmd.Parameters.AddWithValue("@Machine_in", ddlMachine.SelectedValue);
            //            // cmd.Parameters.AddWithValue("@Route_in", ddlRoute.SelectedValue);
            //            // cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);
            //            //  cmd.Parameters.AddWithValue("@TicketType_in", ddlTicketType.SelectedValue);


            //            da.SelectCommand = cmd;

            //            using (DataTable dt = new DataTable())
            //            {
            //                da.Fill(dt);
            //                GridView1.DataSource = dt;
            //                GridView1.DataBind();


            //                //Calculate Sum and display in Footer Row
            //              //  decimal totalAmount = dt.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
            //              //  decimal totalPax = dt.AsEnumerable().Sum(row => row.Field<decimal>("PaxCount"));
            //              //  decimal totalLuggage = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageCount"));
            //              //  decimal totalPass = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
            //              //  GridView1.FooterRow.Cells[0].Text = "Total";
            //              //  GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            //              //  GridView1.FooterRow.Cells[5].Text = totalAmount.ToString("N0");
            //              //  GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            //              //  GridView1.FooterRow.Cells[6].Text = totalPax.ToString("N0");
            //              //  GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            //              //  GridView1.FooterRow.Cells[7].Text = totalLuggage.ToString("N0");
            //              //  GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            //              //  GridView1.FooterRow.Cells[8].Text = totalPass.ToString("N0");
            //              //  GridView1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            //            }
            //        }
            //    }
            //}

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            bindGridView();
            ddlConductorFill();
            // ddlWayBillFill();
            ddlMachineFill();

            rptpnl.Visible = false;
            // ddlTicketTypeFill();
            // ddlRouteFill();

        }

       
    }
}