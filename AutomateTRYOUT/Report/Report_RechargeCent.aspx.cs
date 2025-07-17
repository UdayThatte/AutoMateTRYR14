using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutomateTRYOUT.Report
{
    public partial class Report_RechargeCent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_reports");
                PnlRechargeCent.Visible = true;
                rptpnlRechargeCent.Visible = false;
                txtPastype.Text = "0";
                ddlCenter.Visible = true;
                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ddlFillCenterNames();
            }

        }

        private void ddlFillCenterNames()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetRechargeCent"))
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
                            ddlCenter.DataSource = ds;
                            ddlCenter.DataTextField = "CENTNAME";
                            ddlCenter.DataValueField = "CENTNAME";
                            ddlCenter.DataBind();
                        }
                    }
                }
            }
        }
        protected DataTable BindCommentDetails()

        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {

                    //using (MySqlCommand cmd = new MySqlCommand("ReportMIS"))
                    using (MySqlCommand cmd = new MySqlCommand("RechargeReport"))
                    // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@Centre_In", ddlCenter.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@FromDt_in", txtFromDateTime.Text);
                            cmd.Parameters.AddWithValue("@ToDt_in", txtToDateTime.Text);
                            cmd.Parameters.AddWithValue("@Pastyp_In", txtPastype.Text);
                            
                            da.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                
                                da.Fill(dt);
                                int n = dt.Rows.Count;
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

                RptRechargeCent.LocalReport.DataSources.Clear();
                rptpnlRechargeCent.Visible = true;
                //RptMIS.LocalReport.DataSources.Add(new ReportDataSource("GetMISDataset", BindCommentDetails()));
                RptRechargeCent.LocalReport.DataSources.Add(new ReportDataSource("RechargeData", BindCommentDetails())); //uday
                RptRechargeCent.LocalReport.ReportPath = string.Empty;
                RptRechargeCent.LocalReport.ReportPath = Server.MapPath(reportPath);
                String date = System.DateTime.Now.ToShortDateString();
                RptRechargeCent.LocalReport.DisplayName = "RECHARGE" + "_" + ddlCenter.SelectedValue.ToString() + "_" + txtFromDateTime.Text + "_" + txtToDateTime.Text;


                ReportParameter[] param = new ReportParameter[6];
                param[0] = new ReportParameter("ClientID", Session["username"].ToString(), false);
                param[1] = new ReportParameter("txtFromDate", txtFromDateTime.Text, false);
                param[2] = new ReportParameter("txtToDate", txtToDateTime.Text, false);
                param[3] = new ReportParameter("CentreSlctd", ddlCenter.SelectedValue.ToString(), false);
                param[4] = new ReportParameter("username", Session["username"].ToString(), false);
                param[5] = new ReportParameter("PassType", txtPastype.Text, false);

                RptRechargeCent.LocalReport.SetParameters(param);
                RptRechargeCent.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        protected void BtnAPPly_Click(object sender, EventArgs e)
        {
            try
            {
                rptpnlRechargeCent.Visible = true;
                PnlRechargeCent.Visible = true;
                BtnAPPly.Enabled = false;
                txtFromDateTime.Enabled = false;
                txtToDateTime.Enabled = false;
                ddlCenter.Enabled = false;

                //uday seems repeatation done in Binddatatoreport    DataTable dt = BindCommentDetails();
                string paths = "~/Report/rdlcRecharge.rdlc";
                BindDataToReport(paths);

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
                //ddlFillCenterNames();
                PnlRechargeCent.Visible = true;
                rptpnlRechargeCent.Visible = false;
                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BtnAPPly.Enabled = true;
                txtFromDateTime.Enabled = true;
                txtToDateTime.Enabled = true;
                ddlCenter.Enabled = true;
                txtPastype.Text = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }


}