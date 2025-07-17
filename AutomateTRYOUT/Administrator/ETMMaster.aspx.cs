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
    public partial class ETMMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_Administrator");

                // txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MM-yy ").Replace('-', '-');
                //   txtToDateTime.Text = DateTime.Now.ToString("dd-MM-yy ").Replace('-', '-');
                bindGridView();
                ddlFillClient();
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




        private int CheckDublicUserName(String EMTName)
        {
            try
            {
                int RtnVal;
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CheckETMName"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@HID_in", EMTName);

                            da.SelectCommand = cmd;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    return RtnVal = 0;

                                }
                                else
                                {
                                    return RtnVal = 1;
                                }



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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int blnReturnDublicVal;
                blnReturnDublicVal = CheckDublicUserName(txtHID.Text);

                if (blnReturnDublicVal == 1)
                {
                    bool blnReturnVal = false;
                    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("InsertETMMaster"))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter())
                            {
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandTimeout = 600;
                                cmd.Parameters.AddWithValue("@MACHINEID_in", txtMACHINEID.Text);
                                cmd.Parameters.AddWithValue("@ClientID_in", ddlClient.SelectedValue.ToString());
                               
                                cmd.Parameters.AddWithValue("@MACHINENAME_in", txtMACHINENAME.Text);
                                cmd.Parameters.AddWithValue("@HID_in", txtHID.Text);
                                cmd.Parameters.AddWithValue("@STATUS_in",Convert.ToInt16(ddlSTATUS.SelectedValue));


                               


                                blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());

                                bindGridView();
                                PlnAddnewETm.Visible = false;
                                pnlgvETM.Visible = true;
                                gvplnETMMaster.Visible = true;
                                btnAddETM.Visible = true;
                              
                               using (DataTable dt = new DataTable())
                               {
                              



                                }
                                con.Close();
                            }
                        }
                    }
                }
                else
                {
                    lblErrMsg.Text = "";
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "Machine Already Active!";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          
            PlnAddnewETm.Visible = true;
            pnlgvETM.Visible = true;
            //  btnAddNew.Visible = true;
            //  txtPassword.Text = "";
            btnAddETM.Visible = true;
            pnlgvETM.Visible = true;
            gvplnETMMaster.Visible = true;
            PlnAddnewETm.Visible = false;
            // txtUserName.Text = "";
            lblErrMsg.Text = "";
            lblErrMsg.Visible = false;
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
           // PlnAddnewUser.GroupingText = "Add New User Master";
           // PlnAddnewUser.Visible = true;
           // pnlgvUserMaster.Visible = false;
           // btnAddNew.Visible = false;
          //  txtPassword.Text = "";
            PlnAddnewETm.Visible = true;
           // TxtUserId.Text = "";
           // txtUserName.Text = "";
            lblErrMsg.Text = "";
            lblErrMsg.Visible = false;
        //    txtUserName.Enabled = true;
            lblMsg.Text = "";
            lblMsg.Visible = false;
            pnlgvETM.Visible = false;
            gvplnETMMaster.Visible = false;
            btnAddETM.Visible = false;
            txtHID.Enabled = true;
            txtHID.Text = "";
            txtMACHINEID.Text = "";
            txtMACHINENAME.Text = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;

        }
        private void bindGridView()
        {
            lblErrMsg.Text = "";
            lblErrMsg.Visible = false;
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
            //gvplnETMMaster.EditIndex = e.NewEditIndex;


            btnAddETM.Visible = false;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnAddETM.Visible = false;
            Label ID = gvplnETMMaster.Rows[e.NewEditIndex].FindControl("lblHID") as Label;
            DataSet dsDetail = FillDetailGrid(ID.Text);

            PlnAddnewETm.Visible = true;
            pnlgvETM.Visible = false;
            gvplnETMMaster.Visible = false;

            txtHID.Text= dsDetail.Tables[0].Rows[0]["HID"].ToString();
            txtMACHINEID.Text = dsDetail.Tables[0].Rows[0]["MACHINEID"].ToString();
            txtMACHINENAME.Text = dsDetail.Tables[0].Rows[0]["MACHINENAME"].ToString();
            ddlClient.SelectedValue = dsDetail.Tables[0].Rows[0]["ClientID"].ToString();
            ddlSTATUS.SelectedValue = dsDetail.Tables[0].Rows[0]["STATUS"].ToString();
            txtHID.Enabled = false;

            //DropDownList ddl = (DropDownList)gvplnETMMaster.Rows[e.RowIndex].FindControl("ddlClientID");
            // bindGridView();
            // ddlFillClientName();


        }


        public DataSet FillDetailGrid(String CheckListID)
        {
            //DataSet ds = new DataSet();

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "GetETMDetailsMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        cmd.Parameters.AddWithValue("@HID_in", CheckListID);

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

        private void ddlFillClient()
        {
           
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                 
                    "GetClientMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        // cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

                        da.SelectCommand = cmd;

                        using (DataSet ds = new DataSet())
                        {

                            da.Fill(ds);

                            ddlClient.DataSource = ds;
                            ddlClient.DataTextField = "ClientID";
                            ddlClient.DataValueField = "ClientID";
                            ddlClient.DataBind();
                            ddlClient.SelectedValue = Session["ClientID"].ToString();
                        }



                    }
                }
            }
        }


        private void ddlFillClientName()
        {
            //DropDownList ddl = (DropDownList)gvplnETMMaster.Rows[e.RowIndex].FindControl("ddlClientID");
            DropDownList ddlClientID = gvplnETMMaster.FindControl("ddlClientID") as DropDownList;
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                  
                    "GetClientMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        // cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

                        da.SelectCommand = cmd;

                        using (DataSet ds = new DataSet())
                        {

                            da.Fill(ds);

                            ddlClientID.DataSource = ds;
                            ddlClientID.DataTextField = "ClientID";
                            ddlClientID.DataValueField = "ClientID";
                            ddlClientID.DataBind();
                        }



                    }
                }
            }
        }
        protected void gvplnETMMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {



                bool blnReturnVal = false;
                Label HID = gvplnETMMaster.Rows[e.RowIndex].FindControl("lblHID") as Label;
               TextBox MACHINEName = gvplnETMMaster.Rows[e.RowIndex].FindControl("txtMACHINENAME") as TextBox;
                TextBox MACHINEID = gvplnETMMaster.Rows[e.RowIndex].FindControl("txtMACHINEID") as TextBox;
                

                int STATUS = int.Parse(((DropDownList)(gvplnETMMaster.Rows[e.RowIndex].Cells[3].FindControl("ddlSTATUS"))).SelectedValue);

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(

                        "UpdateETMMaster"

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
                            cmd.Parameters.AddWithValue("@STATUS_in", STATUS);
                            cmd.Parameters.AddWithValue("@HID_in", HID.Text);
                            cmd.Parameters.AddWithValue("@MACHINENAME_in", MACHINEName.Text);
                            cmd.Parameters.AddWithValue("@MACHINEID_in", MACHINEID.Text);



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


        public bool DeleteMethod(String CheckListID)
        {
            bool blnReturnValDel = false;



            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "DeleteETMMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@HID_in", CheckListID);
                        blnReturnValDel = Convert.ToBoolean(cmd.ExecuteNonQuery());                      

                      
                        con.Close();
                    }
                }
            }

            //using (SqlConnection conn = DatabaseManager.GetDatabaseManager().GetConnection())
            //{
            //    SqlCommand cmd = new SqlCommand("[EFleetMasters].[spCheckListMasterDelete]", conn);
            //    conn.Open();
            //    cmd.Connection = conn;

            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@CheckListID_in", SqlDbType.Int).Value = Convert.ToInt32(CheckListID);
            //    cmd.ExecuteNonQuery();
            //    blnReturnValDel = Convert.ToBoolean(cmd.ExecuteNonQuery());
            //}

            return blnReturnValDel;

        }
        protected void gvplnETMMaster_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {


            Label lblMACHINEID = gvplnETMMaster.Rows[e.RowIndex].FindControl("lblHID") as Label;

          //  Label CheckListID = gvCheckListMaster.Rows[e.RowIndex].FindControl("lblchklistid") as Label;
                DeleteMethod(lblMACHINEID.Text);
            gvplnETMMaster.EditIndex = -1;


            bindGridView();
            lblMsg.Text = "Deleted successfully";
                lblMsg.Visible = true;
           
        }

        protected void gvplnETMMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DropDownList ddl = (DropDownList)gvplnETMMaster.Rows[e.RowIndex].FindControl("ddlClientID");
                // DropDownList ddlClientID = gvplnETMMaster.FindControl("ddlClientID") as DropDownList;

          //      DropDownList ddlClientID =
          //(DropDownList)e.Row.FindControl("ddlClientID");
          //      string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
          //      using (MySqlConnection con = new MySqlConnection(constr))
          //      {
          //          using (MySqlCommand cmd = new MySqlCommand(
          //              //                    @"SELECT td.wytd_waybill_no as 'Waybill Number', min(td.td_ticket_date) as 'Date', MAX(td.Mc_Serial) as 'Machine Serial No', max(td.td_route_no) as 'Route', 
          //              //                    (select CONCAT(rp.rp_startstg,'-',rp.rp_endstg) from newver_routeprogramming rp where rp.rp_routeno = td.td_route_no) as 'Route Name',
          //              //                     sum(td_ticket_fare) 'Collection (in Rs.)', sum(td.td_full_ticket + td.td_half_ticket) 'Total Pax' from newver_ticketdetails td
          //              //                    WHERE ClientID='HTCGAJ01' group by ClientID, td.wytd_waybill_no ORDER by 1 desc limit 1000"
          //              "GetClientMaster"

          //              ))
          //          {
          //              using (MySqlDataAdapter da = new MySqlDataAdapter())
          //              {
          //                  cmd.Connection = con;
          //                  cmd.CommandType = CommandType.StoredProcedure;
          //                  //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
          //                  // cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());

          //                  da.SelectCommand = cmd;

          //                  using (DataSet ds = new DataSet())
          //                  {

          //                      da.Fill(ds);

          //                      ddlClientID.DataSource = ds;
          //                      ddlClientID.DataTextField = "ClientID";
          //                      ddlClientID.DataValueField = "ClientID";
          //                      ddlClientID.DataBind();
          //                  }



          //              }
          //          }
                }
           // }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {


      
                try
                {
                int blnReturnDublicVal;
                blnReturnDublicVal = CheckDublicUserName(txtHID.Text);
                //this is to be checked if machine is tried to make active
                //for updating it to make it inactive no check is required
                if ((blnReturnDublicVal == 0 ) && (ddlSTATUS.SelectedValue.ToString() == "0"))

                {
                    lblErrMsg.Text = "";
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "Machine Already Active!";
                    return;
                }
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(

                            "UpdateETMMaster"

                            ))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter())
                            {
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                            cmd.Parameters.AddWithValue("@ClientID_in", ddlClient.SelectedValue);
                                cmd.Parameters.AddWithValue("@STATUS_in",ddlSTATUS.SelectedValue);
                                cmd.Parameters.AddWithValue("@HID_in", txtHID.Text);
                                cmd.Parameters.AddWithValue("@MACHINENAME_in", txtMACHINENAME.Text);
                                cmd.Parameters.AddWithValue("@MACHINEID_in", txtMACHINEID.Text);



                                cmd.ExecuteNonQuery();

                            PlnAddnewETm.Visible = false;
                            pnlgvETM.Visible = true;
                            gvplnETMMaster.Visible = true;
                            btnAddETM.Visible = true;
                           
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
    }
}