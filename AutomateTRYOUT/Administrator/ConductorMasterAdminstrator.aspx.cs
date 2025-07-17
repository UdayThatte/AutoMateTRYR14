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


namespace AutomateTRYOUT.Administrator
{
    public partial class ConductorMasterAdminstrator : System.Web.UI.Page
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
                //  txtToDateTime.Text = DateTime.Now.ToString("dd-MM-yy ").Replace('-', '-');
                bindGridView();
                //ddlConductorFill();
                // ddlWayBillFill();
                // ddlMachineFill();
                //  txtFromDateTime.Enabled = false;
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
                      
                        "GetConductorMaster"

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
                                gvplnConductorMaster.DataSource = dt;
                                gvplnConductorMaster.DataBind();



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

        protected void gvplnConductorMaster_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void gvplnConductorMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvplnConductorMaster.PageIndex = e.NewPageIndex;

            gvplnConductorMaster.EditIndex = -1;

        }

        protected void gvplnConductorMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            bool blnReturnVal = false;
            Label lblMACHINEID = gvplnConductorMaster.Rows[e.RowIndex].FindControl("lblAddressIDGrid") as Label;


            string DESIGID = ((DropDownList)(gvplnConductorMaster.Rows[e.RowIndex].Cells[3].FindControl("ddlSTATUS"))).SelectedValue;

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                  
                    "UpdateConductorMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@STATUS_in", DESIGID);
                        cmd.Parameters.AddWithValue("@id_in", lblMACHINEID.Text);
                      
                        //  da.SelectCommand = cmd;
                        //  cmd.ExecuteNonQuery();

                        using (DataTable dt = new DataTable())
                       {
                          // da.Fill(dt);

                            cmd.ExecuteNonQuery();
                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());

                            //    gvplnETMMaster.DataSource = dt;
                            //    gvplnETMMaster.DataBind();



                        }
                    }
                }
            }
            gvplnConductorMaster.EditIndex = -1;
            bindGridView();

        }

        protected void gvplnConductorMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvplnConductorMaster.EditIndex = e.NewEditIndex;
            bindGridView();
        }

        protected void gvplnConductorMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvplnConductorMaster.EditIndex = -1;
            bindGridView();
        }
    }



}