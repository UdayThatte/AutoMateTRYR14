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


using Microsoft.Reporting.WebForms;

namespace AutomateTRYOUT.Report
{
    public partial class ReportTicket : System.Web.UI.Page
    {
        string sqlWhere = "";
        string Sqlstring = "";
        protected void Page_Load(object sender, EventArgs e)

        {
           

            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                rptpnlTicket.Visible = false;

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yy ").Replace('-', '-');
                txtToDateTime.Text = DateTime.Now.ToString("dd-MMM-yy ").Replace('-', '-');
                ddlWayBillFill();
                // ddlMachineFill();
                ddlTicketTypeFill();
                ddlRouteFill();
            }


        }




        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        private void ddlWayBillFill()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetWayBillFillForTicket"))
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
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
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

        protected void btnApply_Click(object sender, EventArgs e)
        {

            DataTable dt = BindCommentDetails();
            string paths = "~/Report/rdlcTicket.rdlc";
            BindDataToReport(paths);


        }

        protected DataTable BindCommentDetails()
        {


            rptpnlTicket.Visible = true;










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

                using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@WayBill_in", ddlWyBill.SelectedValue);
                     
                        cmd.Parameters.AddWithValue("@ddlTicketType_in", ddlTicketType.SelectedValue);
                        cmd.Parameters.AddWithValue("@Route_in", ddlRoute.SelectedValue);
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

        private void BindDataToReport(String reportPath)
        {
            //  try
            //{
            RptTicket.LocalReport.DataSources.Clear();
            RptTicket.Visible = true;
            RptTicket.LocalReport.DataSources.Add(new ReportDataSource("TicketDataset", BindCommentDetails()));
            RptTicket.LocalReport.ReportPath = string.Empty;
            RptTicket.LocalReport.ReportPath = Server.MapPath(reportPath);
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
            RptTicket.LocalReport.SetParameters(param);
            RptTicket.LocalReport.Refresh();
            // ReportViewer1.LocalReport.Refresh();
            // }
            //catch (Exception ex)
            //{
            //    throw  ("1000:" + ex.Message);
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlRoute.Items.Clear();
            ddlWyBill.Items.Clear();
            txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yy").Replace('/', '/');
            txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yy").Replace('/', '/');
            ddlWayBillFill();

            // ddlMachineFill();
            ddlWyBill.Items.Insert(0, new ListItem("ALL", "ALL"));
            ddlRoute.Items.Add(new ListItem("ALL", "ALL"));
           // ddlWyBill.Items.Add(new ListItem("ALL", "ALL"));
            ddlTicketTypeFill();
            ddlRouteFill();
          
            rptpnlTicket.Visible = false;
          
           



        }
    }
}

    
