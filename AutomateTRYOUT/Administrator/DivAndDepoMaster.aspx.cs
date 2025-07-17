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
    public partial class DivAndDepoMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_Administrator");
             

                bindGridView();




            }
        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {

            PlnDivAndDepoMaster.Visible = true;
            pnlgvDivAndDepoMaster.Visible = false;
            btnAddNew.Visible = false;
         

          
       
          
          

        }

        private void bindGridView()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(

                        "GetDivAndDepoMaster"


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

        private int CheckDublicUserName(String UserName)
        {
            try
            {
                int RtnVal;
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CheckUserName"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@UserName_in", UserName);

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
                blnReturnDublicVal = CheckDublicUserName(txtDepoCode.Text);

                if (blnReturnDublicVal == 1)
                {
                    bool blnReturnVal = false;
                    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("InsertdivdepotmanagementMaster"))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter())
                            {
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandTimeout = 600;
                                cmd.Parameters.AddWithValue("@ClientID_in",Session["ClientID"].ToString());
                                cmd.Parameters.AddWithValue("@DepotCode_in",txtDepoCode.Text);
                                cmd.Parameters.AddWithValue("@DepotName_in",txtDepoName.Text);
                          
                                cmd.Parameters.AddWithValue("@DivisionCode_in",txtDivisionCode.Text);
                                cmd.Parameters.AddWithValue("@DivisionName_in",txtDivisionName.Text);


                                blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                                PlnDivAndDepoMaster.Visible = false;
                                btnAddNew.Visible = true;
                                pnlgvDivAndDepoMaster.Visible = true;
                                gvplnAgentMaster.Visible = true;

                                bindGridView();

                               // PlnAddnewUser.Visible = false;
                                //pnlgvUserMaster.Visible = true;
                                btnAddNew.Visible = true;
                                using (DataTable dt = new DataTable())
                                {
                                //    da.Fill(dt);
                                //    gvUserMaster.DataSource = dt;
                                //   gvUserMaster.DataBind();



                                }
                                con.Close();
                            }
                        }
                    }
                }
                else
                {
                    //lblErrMsg.Text = "";
                   // lblErrMsg.Visible = true;
                    //lblErrMsg.Text = "User Name already added";


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            PlnDivAndDepoMaster.Visible = false;
            txtDivisionCode.Text = "";
            txtDivisionName.Text = "";
            txtDepoCode.Text = "";
            txtDepoName.Text = "";
            pnlgvDivAndDepoMaster.Visible = true;
            gvplnAgentMaster.Visible = true;
            btnAddNew.Visible = true;
        }

        protected void gvplnAgentMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvplnAgentMaster.EditIndex = e.NewEditIndex;
            bindGridView();
        }

        protected void gvplnAgentMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvplnAgentMaster.EditIndex = -1;
            bindGridView();
        }

        protected void gvplnAgentMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool blnReturnVal = false;
            Label lblID = gvplnAgentMaster.Rows[e.RowIndex].FindControl("lblID") as Label;
            TextBox txtDivisionCode = gvplnAgentMaster.Rows[e.RowIndex].FindControl("txtDivisionCode") as TextBox;
            TextBox txtDivisionName = gvplnAgentMaster.Rows[e.RowIndex].FindControl("txtDivisionName") as TextBox;
            TextBox txtDepotCode = gvplnAgentMaster.Rows[e.RowIndex].FindControl("txtDepotCode") as TextBox;
            TextBox txtDepotName = gvplnAgentMaster.Rows[e.RowIndex].FindControl("txtDepotName") as TextBox;




            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                   
                    "UpdatedivdepotmanagementMaster"

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
                        cmd.Parameters.AddWithValue("@ID_in", lblID.Text);
                      
                        cmd.Parameters.AddWithValue("@DivisionName_in", txtDivisionName.Text);
                        cmd.Parameters.AddWithValue("@DivisionCode_in", txtDivisionCode.Text);
                        cmd.Parameters.AddWithValue("@DepotCode_in", txtDepotCode.Text);
                        cmd.Parameters.AddWithValue("@DepotName_in", txtDepotName.Text);


                        cmd.ExecuteNonQuery();
                        blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                        //  da.SelectCommand = cmd;
                        //  cmd.ExecuteNonQuery();

                       using (DataTable dt = new DataTable())
                        {
                        //    da.Fill(dt);

                        //    gvplnETMMaster.DataSource = dt;
                        //    gvplnETMMaster.DataBind();



                        }
                        con.Close();
                    }
                }
            }

            
            gvplnAgentMaster.EditIndex = -1;
            bindGridView();


        }
        public bool DeleteMethod(String CheckListID)
        {
            bool blnReturnValDel = false;



            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "DeletedivdepotmanagementMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;

                        cmd.Parameters.AddWithValue("@ID_in", CheckListID);






                        blnReturnValDel = Convert.ToBoolean(cmd.ExecuteNonQuery());
                        con.Close();
                    }
                }
            }

           
            return blnReturnValDel;

        }

        protected void gvplnAgentMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblID = gvplnAgentMaster.Rows[e.RowIndex].FindControl("lblID") as Label;

            //  Label CheckListID = gvCheckListMaster.Rows[e.RowIndex].FindControl("lblchklistid") as Label;
            DeleteMethod(lblID.Text);
            gvplnAgentMaster.EditIndex = -1;


            bindGridView();
        }
    }
}