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



namespace AMDS.Forms
{
    public partial class RouteMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (null == Session["LoginUser"])
            //{
            //    Response.Redirect("~/Account/Login");
            //}

            if (!this.IsPostBack)
            {
                // txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy ").Replace('-', '/');
              //  txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MM-yy ").Replace('-', '-');
             //   txtToDateTime.Text = DateTime.Now.ToString("dd-MM-yy ").Replace('-', '-');
                bindGridView();
                //ddlConductorFill();
                // ddlWayBillFill();
               // ddlMachineFill();
               // txtFromDateTime.Enabled = false;
               // txtToDateTime.Enabled = false;
                //  ddlTicketTypeFill();
                // ddlRouteFill();



            }



        }

        private void bindGridView()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    //                    @"SELECT td.wytd_waybill_no as 'Waybill Number', min(td.td_ticket_date) as 'Date', MAX(td.Mc_Serial) as 'Machine Serial No', max(td.td_route_no) as 'Route', 
                    //                    (select CONCAT(rp.rp_startstg,'-',rp.rp_endstg) from newver_routeprogramming rp where rp.rp_routeno = td.td_route_no) as 'Route Name',
                    //                     sum(td_ticket_fare) 'Collection (in Rs.)', sum(td.td_full_ticket + td.td_half_ticket) 'Total Pax' from newver_ticketdetails td
                    //                    WHERE ClientID='HTCGAJ01' group by ClientID, td.wytd_waybill_no ORDER by 1 desc limit 1000"
                    "GetRouteMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            gvRouteMasterr.DataSource = dt;
                            gvRouteMasterr.DataBind();


                            
                        }
                    }
                }
            }
        }

        protected void gvRouteMasterr_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void gvRouteMasterr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRouteMasterr.PageIndex = e.NewPageIndex;

            gvRouteMasterr.EditIndex = -1;
        }
    }
}