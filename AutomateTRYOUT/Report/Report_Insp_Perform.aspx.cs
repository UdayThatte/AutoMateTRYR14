using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace AutomateTRYOUT.Report
{
    public partial class Report_Insp_Perform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_reports");
                PnlSarchMIS.Visible = true;
                rptpnlInspPerform.Visible = false;

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                    //using (MySqlCommand cmd = new MySqlCommand("Report_InspPerform"))
                    using (MySqlCommand cmd = new MySqlCommand("SELECT td.ClientId as 'CID'," +
                        "DATE(bi_ticket_datetime)  as 'Date',td.ClientId as 'Operator'," +
                        "Mc_Serial as 'MachineNo',bi_waybill as 'WaybillNo'," +
                        "wp.wbp_vehicalno as 'VehicleNo',td_ticket_time as 'Time'," +
                        "IFNULL((select CONCAT(rp.rp_routeno,'-',rp.rp_startstg,'-',rp.rp_endstg) " +
                        "from newver_routeprogramming rp where rp.ClientID=td.ClientID " +
                        "And  rp.rp_routeno= td.td_route_no),td.td_route_no) as 'Route'," +
                        "IFNULL((select Max(CONCAT(rps1.rpsd_stgcode,' (',rps1.rpsd_stgnamee, ')')) " +
                        "From newver_rpstagedetails rps1 where  rps1.rpsd_routeno =td.td_route_no " +
                        "AND rps1.rpsd_stgno = td.td_stg_from And rps1.ClientID=td.ClientID),td.td_stg_from) as 'FromStg'," +
                        "td_trip_no as 'Trip',td_con_case_code as 'Insp',td_doc_rec_no as 'Type' " +
                        "FROM `newver_ticketdetails` as td " +
                        "LEFT JOIN `newver_waybillprogramming` wp " +
                        "ON td.bi_waybill = wp.wbp_waybillno AND td.ClientId = wp.ClientID " +
                        "where td_ticket_code = 'CASE' " +
                        "AND DATE(bi_ticket_datetime) BETWEEN '"+ txtFromDateTime.Text + "' AND '"+ txtToDateTime.Text + "' " +
                        "AND td_con_case_code like '"+ txtInspCode.Text.PadRight(12) + "'" +
                        "AND td.ClientId IN(SELECT ClientID from newver_clientmaster where GroupID = '"+ Session["GroupID"].ToString() + "') " +
                        "ORDER BY Date,Time,WaybillNo,Trip ASC;"
                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            //cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 0;
                            //cmd.Parameters.AddWithValue("@InspCode_in", txtInspCode.Text.PadRight(12));
                            //cmd.Parameters.AddWithValue("@FromDt_in", txtFromDateTime.Text);
                            //cmd.Parameters.AddWithValue("@ToDt_in", txtToDateTime.Text);
                            //cmd.Parameters.AddWithValue("@GroupID_in", Session["GroupID"].ToString());
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

                RptInspPerform.LocalReport.DataSources.Clear();
                rptpnlInspPerform.Visible = true;
                //RptMIS.LocalReport.DataSources.Add(new ReportDataSource("GetMISDataset", BindCommentDetails()));
                RptInspPerform.LocalReport.DataSources.Add(new ReportDataSource("InspPerform", BindCommentDetails())); //uday
                RptInspPerform.LocalReport.ReportPath = string.Empty;
                RptInspPerform.LocalReport.ReportPath = Server.MapPath(reportPath);
                String date = System.DateTime.Now.ToShortDateString();
                RptInspPerform.LocalReport.DisplayName = "INSP" + "_" + txtInspCode.Text + "_" + txtFromDateTime.Text + "_" + txtToDateTime.Text;


                ReportParameter[] param = new ReportParameter[4];
                param[0] = new ReportParameter("InspCode", txtInspCode.Text, false);
                param[1] = new ReportParameter("txtFromDate", txtFromDateTime.Text, false);
                param[2] = new ReportParameter("txtToDate", txtToDateTime.Text, false);
                param[3] = new ReportParameter("username", Session["username"].ToString(), false);

                RptInspPerform.LocalReport.SetParameters(param);
                RptInspPerform.LocalReport.Refresh();
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
                RptInspPerform.Visible = true;
                rptpnlInspPerform.Visible = true;
                BtnAPPly.Enabled = false;
                txtFromDateTime.Enabled = false;
                txtToDateTime.Enabled = false;
                txtInspCode.Enabled = false;

                //uday seems repeatation done in Binddatatoreport    DataTable dt = BindCommentDetails();
                string paths = "~/Report/rdlcInspPerform.rdlc";
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
                RptInspPerform.Visible = false;
                PnlSarchMIS.Visible = true;
                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BtnAPPly.Enabled = true;
                txtFromDateTime.Enabled = true;
                txtToDateTime.Enabled = true;
                txtInspCode.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}