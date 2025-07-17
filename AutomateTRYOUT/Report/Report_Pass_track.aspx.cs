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
    public partial class Report_Pass_track : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_reports");
                PnlSarchMIS.Visible = true;
                rptpnlpasstrack.Visible = false;


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


                    //using (MySqlCommand cmd = new MySqlCommand("Report_PassTrack"))
                    using (MySqlCommand cmd = new MySqlCommand("Select "
                    + "A.id 'id',"
                    + "A.Clientid as 'Operator',"
                    + "A.bi_waybill as 'WaybillNo',"
                    + "A.td_ticket_num as 'TicketNo',"
                    + "A.bi_ticket_datetime as 'DateTime',"
                    + "A.td_route_no as 'RouteN',"
                    + "IFNULL(IFNULL((select CONCAT(rp.rp_routeno, '-', rp.rp_startstg, '-', rp.rp_endstg) from newver_routeprogramming rp "
                    + "where rp.ClientID = A.ClientID And  rp.rp_routeno = A.td_route_no), A.td_route_no), 'Not Specified') as 'Route',"
                    + "A.td_stg_from as 'FStg',"
                    + "A.td_stg_to as 'TStg',"
                    + "IFNULL((select CONCAT(rps.rpsd_stgcode, ' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno = 1 "
                    + "AND rps.rpsd_routeno = A.td_route_no AND rps.rpsd_stgno = A.td_stg_from And rps.ClientID = A.ClientID),'Not Defined') as 'FromStg', "
                    + "IFNULL((select CONCAT(rps.rpsd_stgcode, ' (', rps.rpsd_stgnamee, ')') From newver_rpstagedetails rps where rps.rpsd_triangleno = 1 "
                    + "AND rps.rpsd_routeno = A.td_route_no AND rps.rpsd_stgno = A.td_stg_to And rps.ClientID = A.ClientID),'Not Defined') as 'ToStg',"
                    + "A.td_ticket_fare as 'Amount', "
                    + "A.td_con_case_code as 'PassNo', "
                    + "SUBSTRING(B.td_con_case_code, 1, 4) as 'Balance',"
                    + "SUBSTRING(B.td_con_case_code, 6, 6) as 'Expiry',"
                    + "A.td_doc_rec_no as 'Type' "
                    + "From newver_ticketdetails A "
                    + "LEFT JOIN newver_ticketdetails B "
                    + "ON A.bi_waybill = B.bi_waybill and A.td_ticket_num = B.td_ticket_num and A.Clientid = B.Clientid "
                    + "WHERE B.td_ticket_code = 'DTLS' "
                    + "AND A.td_ticket_code = 'PASS' "
                    + "AND(A.td_doc_rec_no = '03' OR A.td_doc_rec_no = '04' OR A.td_doc_rec_no = '05') "
                    + "AND A.td_con_case_code = '" + txtPasNo.Text.PadRight(12) + "' "
                    + "AND A.bi_ticket_datetime BETWEEN concat('" + txtFromDateTime.Text + "', ' 00:00:00') AND concat('" + txtToDateTime.Text + "',' 23:59:59') "
                    + "AND A.Clientid IN(SELECT ClientID from newver_clientmaster where GroupID = '" + Session["GroupID"].ToString() + "') "
                    + "UNION "
                    + "Select "
                    + "C.id as 'id',"
                    + "C.centID as 'Operator',"
                    + "'0' as 'WaybillNo',"
                    + "'0' as 'TicketNo',"
                    + "CONCAT(C.cct_issuedt, ' ', C.cct_issuetm) as 'DateTime',"
                    + "'0' as 'RouteN',"
                    + "' ' as 'Route',"
                    + "'0' as 'FStg',"
                    + "'0' as 'TStg',"
                    + "' ' as 'FromStg',"
                    + "' ' as 'ToStg',"
                    + "'0' as 'Amount', "
                    + "C.cct_passno as 'PassNo', "
                    + "C.cct_total_amt as 'Balance',"
                    + "'Recharge' as 'Expiry',"
                    + "C.typecode as 'Type' "
                    + "FROM cct_multi_card_details C "
                    + "WHERE C.cct_passno = TRIM('" + txtPasNo.Text.PadRight(12) + "') "
                    + "AND c.cct_issuedt BETWEEN '" + txtFromDateTime.Text + "' AND '" + txtToDateTime.Text + "' "
                    + " ORDER by DateTime ASC; "))

                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            //cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 0;
                            //cmd.Parameters.AddWithValue("@PassNo_in", txtPasNo.Text.PadRight(12));
                            //cmd.Parameters.AddWithValue("@FromDt_in", txtFromDateTime.Text);
                            //cmd.Parameters.AddWithValue("@ToDt_in", txtToDateTime.Text);
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


                RptPassTrack.LocalReport.DataSources.Clear();
                rptpnlpasstrack.Visible = true;
                //RptMIS.LocalReport.DataSources.Add(new ReportDataSource("GetMISDataset", BindCommentDetails()));
                RptPassTrack.LocalReport.DataSources.Add(new ReportDataSource("PassTrack", BindCommentDetails())); //uday
                RptPassTrack.LocalReport.ReportPath = string.Empty;
                RptPassTrack.LocalReport.ReportPath = Server.MapPath(reportPath);
                String date = System.DateTime.Now.ToShortDateString();
                RptPassTrack.LocalReport.DisplayName = "PASS"+"_"+ txtPasNo.Text + "_" + txtFromDateTime.Text + "_" + txtToDateTime.Text;


                ReportParameter[] param = new ReportParameter[4];
                param[0] = new ReportParameter("PassNo_in", txtPasNo.Text, false);
                param[1] = new ReportParameter("FromDt_in", txtFromDateTime.Text, false);
                param[2] = new ReportParameter("ToDt_in", txtToDateTime.Text, false);
                param[3] = new ReportParameter("username", Session["username"].ToString(), false);

                RptPassTrack.LocalReport.SetParameters(param);
                RptPassTrack.LocalReport.Refresh();
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
                txtPasNo.Text = txtPasNo.Text.PadLeft(8,'0');
                RptPassTrack.Visible = true;
                rptpnlpasstrack.Visible = true;
                BtnAPPly.Enabled = false;
                txtPasNo.Enabled = false;
                txtToDateTime.Enabled = false;
                txtFromDateTime.Enabled = false;
                //uday seems repeatation done in Binddatatoreport    DataTable dt = BindCommentDetails();
                string paths = "~/Report/rdlcPassTrack.rdlc";
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
                BtnAPPly.Enabled = true;
                txtPasNo.Text = "";
                PnlSarchMIS.Visible = true;
                rptpnlpasstrack.Visible = false;
                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtPasNo.Enabled = true;
                txtToDateTime.Enabled = true;
                txtFromDateTime.Enabled = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}