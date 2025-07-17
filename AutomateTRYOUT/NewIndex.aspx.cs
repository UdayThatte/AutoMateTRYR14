
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace AutomateTRYOUT
{
    public partial class NewIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_OperationsView");


                bindGridView();

                sendPing();
                pnlIndexNew.Visible = true;
                PnlMain.Visible = false;
                pnlhed.Visible = false;
            }
        }


        private void sendPing()
        {
            //return; 
            //after switching to a new server this was necessary
            //as the server was stopping the inactive service
            try
            {

                // Create a request for the URL.        
                WebRequest request = WebRequest.Create("http://automatesystemsdataservice.in/AMDS/AutomateInternalWS.asmx/HelloWorld");
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();


                // Create a request for the URL.        
                WebRequest request2 = WebRequest.Create("http://automatesystemsdataservice.in/AMDS_Demo/AutomateInternalWS.asmx/HelloWorld");
                // Get the response.
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                response2.Close();

            }
            catch (Exception ex)
            {


            }
        }

        private void Update_Waybills_Issued_Closed()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            string TodaysDt = DateTime.Now.ToString("yyyy-MM-dd");
            //TodaysDt = "2018-02-23";

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT count(id) as 'CNT' from newver_waybillprogramming WHERE DATE_FORMAT(CreatedDT,'%Y-%m-%d') = '" + TodaysDt + "' AND ClientID = @ClientID_in ;"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            lbl_issued_waybills.Text = Convert.ToString(dt.Rows[0][0]); 
                        }
                    }
                }
            }
            //now closed waybills
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT count(id) as 'CNT' from newver_waybillprogramming WHERE DATE_FORMAT(CreatedDT,'%Y-%m-%d') = '" + TodaysDt + "' AND ClientID = @ClientID_in AND status='CLOSED';"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            lbl_closed_waybills.Text = Convert.ToString(dt.Rows[0][0]);
                        }
                    }
                }
            }

            if ((lbl_closed_waybills.Text == "0") && (lbl_issued_waybills.Text == "0"))
                btnExport.Enabled = false;
            else
                btnExport.Enabled = true;

        }

        private void bindGridView()
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    //241119 uday using (MySqlCommand cmd = new MySqlCommand("IndexPageViewNew"))
                    using (MySqlCommand cmd = new MySqlCommand("IndexPageViewNewUday"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 500;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());


                            da.SelectCommand = cmd;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GVIndexNew.DataSource = dt;
                                GVIndexNew.DataBind();
                            }
                        }
                    }
                }
                //uday now update waybills issued and closed today
                Update_Waybills_Issued_Closed();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.EditIndex = -1;
        }
        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = e.Row.Cells[3].Text;
                if (status.Equals("ISSUED"))
                {
                    e.Row.BackColor = Color.FromName("#41A317");
                }
            }
        }


        protected void btnIndexNewview_Click(object sender, EventArgs e)
        {

            try
            {




                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label WaybillNo = (Label)row.FindControl("lblWaybillNo");




                DataSet dsDetail = FillDetailGrid(WaybillNo.Text);

                GridView1.DataSource = dsDetail;
                GridView1.DataBind();
                pnlIndexNew.Visible = false;
                PnlMain.Visible = true;
                pnlhed.Visible = false;







            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet FillDetailGrid(String WaybillNo)
        {


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "GetWayBillWiseDetails"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@ddlWyBill_in", WaybillNo);

                        da.SelectCommand = cmd;

                        using (DataSet ds = new DataSet())
                        {

                            da.Fill(ds);

                            return ds;
                        }



                    }
                }
            }


        }
        protected void GVIndexNew_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void GVIndexNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIndexNew.PageIndex = e.NewPageIndex;
            GVIndexNew.EditIndex = -1;
        }


        protected void BtnReset_Click(object sender, EventArgs e)
        {



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bindGridView();
            pnlIndexNew.Visible = true;
            PnlMain.Visible = false;
            pnlhed.Visible = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
            //important here but not required in agentreport ??? Uday
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            string TodaysDt = DateTime.Now.ToString("yyyy-MM-dd");
            //TodaysDt = "2018-05-15";

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT wbp.MachineNo as MachineNo,wbp.wbp_date as IssueDate,wbp.wbp_waybillno as WaybillNo,wbp.`status` as Status,(select max(cd.cd_condrdetails) from newver_conductordetails cd Where cd.cd_condrdetails_code = wbp.wbp_condrdetails And cd.ClientID = wbp.ClientID) as ConductorName,wbp.wbp_driver1details as Driver ,wbp.wbp_condrdetails as 'ConductorCode',wbp.wbp_vehicalno as VehicleNo FROM newver_waybillprogramming wbp where wbp.ClientID = '" + Session["ClientID"].ToString() + "' AND DATE_FORMAT(CreatedDT,'%Y-%m-%d') = '"+ TodaysDt +"' ORDER by wbp.wbp_waybillno ASC LIMIT 200;"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            HiddenGrid.DataSource = dt;
                            HiddenGrid.DataBind();

                        }
                    }
                }
            }
            //grid is ready
            
            if (HiddenGrid.Rows.Count == 0) return;

            HiddenGrid.Visible = true;
            string filename;
            Response.ClearContent();
            Response.Buffer = true;
            filename = "WayBillStatus_" + DateTime.Now.ToString("ddMMyyyy") + ".XLS";
            Response.AddHeader("content-disposition", "attachment; filename = " + filename);
            Response.ContentType = "application/excel";
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.Charset = "";
            //this.EnableViewState = false;
            StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            HiddenGrid.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
            HiddenGrid.Visible = false;

        }

    
    }

}


/*
 * 
 * BEGIN






















SELECT
	wbp.MachineNo as MachineNo,
	wbp.wbp_date,
	wbp.wbp_waybillno as 'WaybillNo',
	wbp.`status`,
  wbp.wbp_condrdetails as 'ConductorCode',


(SELECT IFNULL(sum(td.td_ticket_fare), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	(select cc.TicketCode from newver_clientticketconfig cc where cc.ClientID = td.ClientID  and  cc.IsActive = 1  AND cc.IsRevenue = 1 )
AND 
 wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)  as TotalFare,


(SELECT IFNULL(sum(td.td_ticket_fare), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	('CONC') AND  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)  as ConcessionFare,

(SELECT IFNULL(sum(td.td_ticket_fare), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	('EXPN') AND  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)  as Expenses,

(SELECT IFNULL(sum(td.td_pass), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	('PNTY') AND  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)  as Penalty,


(SELECT IFNULL(sum(td.td_full * td.td_full_ticket), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	(select cc.TicketCode from newver_clientticketconfig cc where cc.ClientID = td.ClientID  and  cc.IsActive = 1  AND cc.IsRevenue = 1 )
AND
 td.td_ticket_code NOT IN 
 	('CONC')
AND 
 wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID) 
 as FullTicketFare,
 
(SELECT IFNULL(sum(td.td_half * td.td_half_ticket), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	(select cc.TicketCode from newver_clientticketconfig cc where cc.ClientID = td.ClientID  and  cc.IsActive = 1  AND cc.IsRevenue = 1 )
AND
 td.td_ticket_code NOT IN 
 	('CONC')
AND 
 wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID) 
 as HalfTicketFare,

(SELECT  IFNULL(sum(td.td_ticket_fare), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID
AND td.td_ticket_code in ('LUGG')
)  as 'LuggageFare',

IFNULL((SELECT  count(1) FROM newver_ticketdetails td WHERE  td.td_con_case_code like '%A%' AND 
wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID),0)  as AgentTicket,

(SELECT IFNULL(sum(td.td_pass), 0)	FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)  as PassFare,
(SELECT IFNULL(sum(td.td_full_ticket), 0)	+ IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)   
as 'PaxCount',
(SELECT IFNULL(sum(td.td_full_ticket), 0)	FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no    
AND  td.td_ticket_code NOT IN  	('CONC') and wbp.ClientID = td.ClientID)
as 'FullPaxCount',
(SELECT IFNULL(sum(td.td_half_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no 
AND  td.td_ticket_code NOT IN  	('CONC') and wbp.ClientID = td.ClientID)
as 'HalfPaxCount',

(SELECT IFNULL(sum(td.td_full_ticket), 0)	+ IFNULL(sum(td.td_half_ticket), 0) 
	FROM newver_ticketdetails td WHERE  
 td.td_ticket_code IN 
 	('CONC') AND  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID)  as 'ConcessionPaxCount',

(SELECT  IFNULL(count(td.td_ticket_fare), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no  and wbp.ClientID = td.ClientID
AND td.td_ticket_code in ('LUGG')
)  as 'LuggageCount',

(SELECT IFNULL(count(td.td_pass_ticket), 0) FROM newver_ticketdetails td WHERE  wbp.wbp_waybillno = td.wytd_waybill_no and wbp.ClientID = td.ClientID AND 
td.td_ticket_code in ('PASS')) 
as 'PassCount'

	
FROM
	newver_waybillprogramming wbp
where
	wbp.ClientID = ClientID_in 
AND 


wbp.wbp_waybillno IN ( CASE WHEN ddlWyBill_in ='ALL' THEN wbp.wbp_waybillno ELSE ddlWyBill_in   END)  
     


order by wbp.wbp_waybillno desc 
limit 50;

END


    */

