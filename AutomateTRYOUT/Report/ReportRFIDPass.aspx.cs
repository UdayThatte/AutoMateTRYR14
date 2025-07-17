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
    public partial class ReportRFIDPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_reports");
                rptpnlRFID.Visible = false;
                RptRFID.Visible = false;
                txtPastyp.Text = "0";

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //ddlFillddlMachineNo(); //uday removed all
                //ddlFillddlConductor();
                //ddlWayBillFill();


                //ddlnewverdivdepotmanagement();

            }


        }

        /*
                private void ddlFillddlConductor()
                {
                    try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // ReportMIS
        
        private void ddlFillddlMachineNo()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ddlWayBillFill()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetRecentTicketsWayBill"))
                    // using (MySqlCommand cmd = new MySqlCommand("GetRecentWayBillList"))
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
            catch (Exception ex)
            {
                throw ex;
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
        
        */
        protected void BtnAPPly_Click(object sender, EventArgs e)
        {
            try
            {
                RptRFID.Visible = true;
                rptpnlRFID.Visible = true;
                //uday seems repeatation done in Binddatatoreport    DataTable dt = BindCommentDetails();
                string paths = "~/Report/rdlcRFID.rdlc";
                BindDataToReport(paths);


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }




        protected DataTable BindCommentDetails()

        {
            try
            {


                int PassType = Int16.Parse(txtPastyp.Text);

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {

                    //using (MySqlCommand cmd = new MySqlCommand("ReportMIS"))
                    using (MySqlCommand cmd = new MySqlCommand("Report_RFID_Usage")) //uday
                    // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@FromDt_in", Convert.ToDateTime(txtFromDateTime.Text));
                            cmd.Parameters.AddWithValue("@ToDt_in", Convert.ToDateTime(txtToDateTime.Text));
                            cmd.Parameters.AddWithValue("@PassType_in",PassType.ToString());
                            

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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void BindDataToReport(String reportPath)
        {
            try
            {


                RptRFID.LocalReport.DataSources.Clear();
                RptRFID.Visible = true;
                //RptMIS.LocalReport.DataSources.Add(new ReportDataSource("GetMISDataset", BindCommentDetails()));
                RptRFID.LocalReport.DataSources.Add(new ReportDataSource("RFIDPassDataset", BindCommentDetails())); //uday
                RptRFID.LocalReport.ReportPath = string.Empty;
                RptRFID.LocalReport.ReportPath = Server.MapPath(reportPath);
                String date = System.DateTime.Now.ToShortDateString();
                RptRFID.LocalReport.DisplayName = "RFID" + "_" + txtFromDateTime.Text + "_" + txtToDateTime.Text;
                

                ReportParameter[] param = new ReportParameter[4];
                param[0] = new ReportParameter("ClientID_in", Session["ClientID"].ToString(), false);
                param[1] = new ReportParameter("txtFromDate", txtFromDateTime.Text, false);
                param[2] = new ReportParameter("txtToDate", txtToDateTime.Text, false);
                param[3] = new ReportParameter("PassType", txtPastyp.Text, false);

                RptRFID.LocalReport.SetParameters(param);
                RptRFID.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {

            try
            {
                /*
                ddlMachineNo.Items.Clear();
                ddlWyBill.Items.Clear();
                ddlConductor.Items.Clear();

                ddlMachineNo.Items.Insert(0, new ListItem("ALL", "ALL")); // 
                ddlConductor.Items.Insert(0, new ListItem("ALL", "ALL")); // 
                ddlWyBill.Items.Insert(0, new ListItem("ALL", "ALL")); // 
                
                ddlFillddlMachineNo();
                ddlFillddlConductor();
                ddlWayBillFill();
                */
                rptpnlRFID.Visible = false;
                RptRFID.Visible = false;
                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtPastyp.Text = "0";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}