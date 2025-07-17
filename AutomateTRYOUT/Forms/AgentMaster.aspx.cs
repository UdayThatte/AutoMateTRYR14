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
    public partial class AgentMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).SetActiveMenu("menu_master");
                (this.Master as Site1).CheckSessionVar();
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
        protected void gvplnConductorMaster_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void gvplnConductorMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvplnAgentMaster.PageIndex = e.NewPageIndex;

            gvplnAgentMaster.EditIndex = -1;
        }
        private void bindGridView()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                     
                        "GetAgentMaster"
                        //"GetETMMaster"

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

                                gvplnAgentMaster.DataSource = dt;
                                gvplnAgentMaster.DataBind();



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
    }
}