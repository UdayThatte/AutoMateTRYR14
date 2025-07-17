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
    public partial class DriverMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // pnlAddDriverMaster.Visible = false;
            // plnDriverSearch.Visible = true;
            // pnlDriverMaster.Visible = true;
            if (!this.IsPostBack)
            {
                // txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy ").Replace('-', '/');
             //   txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MM-yy ").Replace('-', '-');
              //  txtToDateTime.Text = DateTime.Now.ToString("dd-MM-yy ").Replace('-', '-');
                bindGridView();
                //ddlConductorFill();
                // ddlWayBillFill();
                // ddlMachineFill();
             //   txtFromDateTime.Enabled = false;
              //  txtToDateTime.Enabled = false;
                //  ddlTicketTypeFill();
                // ddlRouteFill();



            }

        }

        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
           // pnlAddDriverMaster.Visible = true;
            //plnDriverSearch.Visible = false;
          //  pnlDriverMaster.Visible = false;

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
                    "GetDriverMaster"

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
                            gvDriverMaster.DataSource = dt;
                            gvDriverMaster.DataBind();



                        }
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           // pnlAddDriverMaster.Visible = false;
           // plnDriverSearch.Visible = true;
           // pnlDriverMaster.Visible = true;
        }

        protected void gvDriverMaster_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void gvDriverMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDriverMaster.PageIndex = e.NewPageIndex;

            gvDriverMaster.EditIndex = -1;

        }
    }
}