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
    public partial class TicketReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_reports");
                // rptpnlGetPass.Visible = false;

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yy ").Replace('-', '-');
                txtToDateTime.Text = DateTime.Now.ToString("dd-MMM-yy ").Replace('-', '-');
                 ddlWayBillFill();
                ddlFillddlMachineNo();
                ddlRouteFill();
                ddlRouteFill();
                ddlnewverdivdepotmanagement();
                ddlFillConductor();
                ddlWayBillFill();

            }

        }


        private void ddlFillConductor()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetConductorMaster"))
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


        protected void BtnAPPly_Click(object sender, EventArgs e)
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
            // DataSet dt = BindCommentDetails();
            //string paths = "~/Report/rdlcMIS.rdlc";
            // BindDataToReport(paths);
            //gvMIS.DataSource = dt;
            //gvMIS.DataBind();
            // gvplnTicketReport.DataSource = dt;
            // gvplnTicketReport.DataBind();
        }


        //private void BindDataToReport(String reportPath)
        //{


        //    RptMIS.LocalReport.DataSources.Clear();
        //    RptMIS.Visible = true;
        //    RptMIS.LocalReport.DataSources.Add(new ReportDataSource("MIS", BindCommentDetails()));
        //    RptMIS.LocalReport.ReportPath = string.Empty;
        //    RptMIS.LocalReport.ReportPath = Server.MapPath(reportPath);
        //    String date = System.DateTime.Now.ToShortDateString();



        //    ReportParameter[] param = new ReportParameter[4];
        //    param[0] = new ReportParameter("ClientID_in", Session["ClientID"].ToString(), false);
        //    param[1] = new ReportParameter("txtFromDate", txtFromDateTime.Text, false);
        //    param[2] = new ReportParameter("txtToDate", txtToDateTime.Text, false);
        //    param[3] = new ReportParameter("divdepotmanagement", ddldivdepotmanagement.SelectedItem.ToString(), false);

        //    RptMIS.LocalReport.SetParameters(param);
        //    RptMIS.LocalReport.Refresh();


        //}

        protected DataSet BindCommentDetails()

        {




            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (var cmd = new MySqlCommand("ReportMIS"))
                // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        //cmd.Parameters.AddWithValue("@ClientID_in", "AUTOMATE");
                        //cmd.Parameters.AddWithValue("@FromDate_in", "ABCD");
                        //cmd.Parameters.AddWithValue("@ToDate_in", "EFG");
                        //cmd.Parameters.AddWithValue("@Id", 4);

                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

                        cmd.Parameters.AddWithValue("@FromDate_in", txtFromDateTime.Text);
                        cmd.Parameters.AddWithValue("@ToDate_in", txtToDateTime.Text);
                        cmd.Parameters.AddWithValue("@Id", ddldivdepotmanagement.SelectedValue);


                        ////  cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                        //// cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                        //// cmd.Parameters.AddWithValue("@Conductor_in", ddlConductor.SelectedValue);
                        ////cmd.Parameters.AddWithValue("@FromDate", txtFromDateTime.Text);
                        ////cmd.Parameters.AddWithValue("@ToDate", txtToDateTime.Text);
                        da.SelectCommand = cmd;
                        using (DataSet dt = new DataSet())
                        {
                            da.Fill(dt);

                            return dt;
                        }
                    }
                }
            }
        }

    

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            //pnlgvMIS.Visible = false;

           

           
        }

        protected void gvplnETMMaster_PageIndexChanged(object sender, EventArgs e)
        {

            BindCommentDetails();

        }

        protected void gvplnETMMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvplnTicketReport.PageIndex = e.NewPageIndex;

            gvplnTicketReport.EditIndex = -1;
        }
    }
}