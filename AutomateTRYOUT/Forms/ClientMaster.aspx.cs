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
    public partial class ClientMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                (this.Master as Site1).SetActiveMenu("menu_master");
                (this.Master as Site1).CheckSessionVar();
               
                bindGridView();
            



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
                      
                        "GetClientMaster"
                    

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

                                gvClientMaster.DataSource = dt;
                                gvClientMaster.DataBind();



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

        protected void BtnAddNewClient_Click(object sender, EventArgs e)
        {

            PlnAddClientName.Visible = true;
            BtnAddNewClient.Visible = false;
            pnlgvClientMaster.Visible = false;
            gvClientMaster.Visible = false;
            txtClientName.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
               // int blnReturnDublicVal;
               // blnReturnDublicVal = CheckDublicUserName(txtUserName.Text);

               // if (blnReturnDublicVal == 1)
              //  {
                    bool blnReturnVal = false;
                    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("InsertClientMaster"))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter())
                            {
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", txtClientName.Text);
                            cmd.Parameters.AddWithValue("@Description_in", txtDescription.Text);



                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                            con.Close();
                            bindGridView();

                            PlnAddClientName.Visible = false;
                            pnlgvClientMaster.Visible = true;
                            BtnAddNewClient.Visible = true;
                            gvClientMaster.Visible = true;
                            txtClientName.Text = "";
                            
                        }
                        }
                    }
               // }
               // else
               // {
                   // lblErrMsg.Text = "";
                   // lblErrMsg.Visible = true;
                   // lblErrMsg.Text = "User Name already added";


               // }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            BtnAddNewClient.Visible = true;
            PlnAddClientName.Visible = false;
            pnlgvClientMaster.Visible = true;
            gvClientMaster.Visible = true;
            txtClientName.Text = "";
            txtDescription.Text = "";


        }

        protected void gvClientMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            bool blnReturnVal = true;
    //        int returnval;

            //        lblMsg.Visible = false;
            Label lbldataset = gvClientMaster.Rows[e.RowIndex].FindControl("lblID") as Label;

    //        // candelete = vmw.CheckAssestCount(lbldataset.Text);
    //        //  if (candelete == true)
    //        //  {
          


            


          string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("DeleteClientMaster"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@id_in",Convert.ToInt16(lbldataset.Text));

                        blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                        con.Close();
                        gvClientMaster.EditIndex = -1;
                        bindGridView();

                        txtClientName.Text = "";
                        txtDescription.Text = "";

                    }
                }
            }
    //                    if (blnReturnVal == false)
    //                    {
    //                        return RtnVal = 0;
    //                    }
    //                    else
    //                    {
    //                        return RtnVal = 1;

    //                    }



    //                    //using (DataTable dt = new DataTable())
    //                    //{
    //                    //    da.Fill(dt);
    //                    //    gvUserMaster.DataSource = dt;
    //                    //    gvUserMaster.DataBind();



    //                    //}
    //                }
    //            }
    //        }
    //        gvUserMaster.EditIndex = -1;


    //        if (returnval == 1)
    //        {


    //            PlnAddnewUser.Visible = false;
    //            pnlgvUserMaster.Visible = true;
    //            btnAddNew.Visible = true;

    //            lblErrMsg.Visible = false;
    //            lblMsg.Text = "Record Deleted Successfully";
    //            lblMsg.Visible = true;
    //            bindGridView();
    //        }
    //        //}
    //        else
    //        {
    //            lblErrMsg.Visible = false;
    //            lblErrMsg.Text = "Can not delete User Name";
    //            lblErrMsg.Visible = true;

    //        }

    //        //  }
        
    }

        protected void gvClientMaster_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void gvClientMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientMaster.PageIndex = e.NewPageIndex;

            gvClientMaster.EditIndex = -1;
        }
    }
}