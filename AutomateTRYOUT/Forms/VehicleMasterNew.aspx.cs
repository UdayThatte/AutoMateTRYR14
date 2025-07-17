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
    public partial class VehicleMasterNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_master");
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

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                     
                        "GetBusMaster"

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
                                gvVehicleMaster.DataSource = dt;
                                gvVehicleMaster.DataBind();



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


        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            //  pnlAddVehicleMaster.Visible = true;
            //  plnSearch.Visible = false;
            //  pnlVehicleMaster.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //  pnlAddVehicleMaster.Visible = false;
            //   plnSearch.Visible = true;
            //  pnlVehicleMaster.Visible = true;
        }

        protected void gvVehicleMaster_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void gvVehicleMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVehicleMaster.PageIndex = e.NewPageIndex;

            gvVehicleMaster.EditIndex = -1;

        }
    }
}