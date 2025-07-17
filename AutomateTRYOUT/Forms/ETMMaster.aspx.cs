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
    public partial class EMTMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                //UDAY (this.Master as Site1).SetActiveMenu("menu_Administrator");
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

        protected void gvplnETMMaster_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();

        }

        protected void gvplnETMMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvplnETMMaster.PageIndex = e.NewPageIndex;

            gvplnETMMaster.EditIndex = -1;
        }




        private void bindGridView()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    "GetETMMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);

                            gvplnETMMaster.DataSource = dt;
                            gvplnETMMaster.DataBind();



                        }
                    }
                }
            }
        }

        protected void gvplnETMMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvplnETMMaster.EditIndex = e.NewEditIndex;
            bindGridView();

        }

        protected void gvplnETMMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {



                bool blnReturnVal = false;
                Label lblMACHINEID = gvplnETMMaster.Rows[e.RowIndex].FindControl("lblHID") as Label;


                int DESIGID = int.Parse(((DropDownList)(gvplnETMMaster.Rows[e.RowIndex].Cells[3].FindControl("ddlSTATUS"))).SelectedValue);

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        
                        "UpdateMasterETM"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@STATUS_in", DESIGID);
                            cmd.Parameters.AddWithValue("@HID_in", lblMACHINEID.Text);


                            cmd.ExecuteNonQuery();

                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                            con.Close();
                        }
                    }
                }
                gvplnETMMaster.EditIndex = -1;
                bindGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvplnETMMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvplnETMMaster.EditIndex = -1;
            bindGridView();
        }

        protected void gvplnETMMaster_DataBound(object sender, EventArgs e)
        {

        }
    }
}