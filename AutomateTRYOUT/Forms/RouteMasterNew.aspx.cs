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
    public partial class RouteMasterNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_master");

             
                lblErrMsg.Visible = false;
                lblErrMsg.Text = "";
                bindGridView();

                this.PlnSubRouteMaster.Visible = false;
                this.gvSubRouteMaster.Visible = false;
                if (Session["RoleName"].ToString() != "Administrator")
                {
                    btnDeleteAll.Visible = false;
                    this.gvRouteMasterr.Columns[0].Visible = false;
                }
                    

            }

        }
        protected void gvRouteMasterr_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }



        protected void gvSubRouteMaster_PageIndexChanged(object sender, EventArgs e)
        {

            DataSet dsDetailnew = FillRouteDetailGrid(hifRouteno.Value);

            gvSubRouteMaster.DataSource = dsDetailnew;
            gvSubRouteMaster.DataBind();

        }

        protected void gvSubRouteMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubRouteMaster.PageIndex = e.NewPageIndex;

            gvSubRouteMaster.EditIndex = -1;
        }



        protected void gvRouteMasterr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRouteMasterr.PageIndex = e.NewPageIndex;

            gvRouteMasterr.EditIndex = -1;
        }



        private void bindGridView()
        {
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(

                        "GetRouteMaster"

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
                                gvRouteMasterr.DataSource = dt;
                                gvRouteMasterr.DataBind();
                                if (dt.Rows.Count == 0)
                                {
                                    lblErrMsg.Visible = true;
                                    lblErrMsg.Text = "No Routes Found...";

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

       


        protected DataSet FillRoute(int BatteryNumber)
        {

            lblErrMsg.Visible = false;
            lblErrMsg.Text = "";


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    "GetRouteWiseRouteDetails"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@Id", BatteryNumber);

                        da.SelectCommand = cmd;

                        using (DataSet dt = new DataSet())
                        {
                            da.Fill(dt);



                            return dt;

                        }
                    }
                }
            }


        }



        protected void btnpodelete_Click(object sender, EventArgs e)
        {
            lblErrMsg.Text = "";
            gvSubRouteMaster.Visible = false;
            PlnSubRouteMaster.Visible = false;

            Button btnapp = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnapp.NamingContainer;
            Label lblPONumberG = (Label)gvr.FindControl("lblrp_routeno");


            DataSet ds = new DataSet();
            ds = FillRoute(Convert.ToInt32(lblPONumberG.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {

                gvSubRouteMaster.Visible = true;
                gvSubRouteMaster.DataSource = ds;
                gvSubRouteMaster.DataBind();
                PlnSubRouteMaster.Visible = true;
            }
            else
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Data is Not Found ";
                gvSubRouteMaster.Visible = false;
                PlnSubRouteMaster.Visible = false;
            }




        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            bool blnReturnValDel = false;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DeletAllRouteInBothTables"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            blnReturnValDel = Convert.ToBoolean(cmd.ExecuteNonQuery());

                        }
                    }
                }
                gvRouteMasterr.EditIndex = -1;
                bindGridView();
                
                //return blnReturnValDel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {

           
            btnSave.Visible = true;
            txtrouteno.Enabled = true;
            txtstartstg.Enabled = true;
            txtendstg.Enabled = true;
            txtroutetype.Enabled = true;
            txtbustype.Enabled = true;
            txttriangleno.Enabled = true;
            txtstartstg.Enabled = true;
            txtendstg.Enabled = true;
            txtnoofstops.Enabled = true;
            txtstgmarathiname.Enabled = true;
            txtfarechanged.Enabled = true;


            PlnSubRouteMaster.Visible = false;
            gvSubRouteMaster.Visible = false;
            pnlAdd.Visible = true;
            pnlgvRouteMaster.Visible = false;
            gvRouteMasterr.Visible = false;
            lblErrMsg.Text = "";
            lblMsg.Text = "";
            btnAddNew.Visible = false;
        }


        private int CheckDublicUserName(string txtrouteno, String txtstartstg, String txtendstg, string txttriangleno)
        {
            try
            {
                int RtnVal;
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "Checknewverrouteprogramming"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@routeno_in", txtrouteno);
                            cmd.Parameters.AddWithValue("@startstg_in", txtstartstg);
                            cmd.Parameters.AddWithValue("@endstg_in", txtendstg);
                            cmd.Parameters.AddWithValue("@triangleno_in", txttriangleno);
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

            int blnReturnDublicVal;
            blnReturnDublicVal = CheckDublicUserName(txtrouteno.Text, txtstartstg.Text, txtendstg.Text, txttriangleno.Text);

            if (blnReturnDublicVal == 1)
            {

                bool blnReturnVal = false;
                lblErrMsg.Text = "";
                lblMsg.Text = "";
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "Insertnewverrouteprogramming"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@routeno_in", txtrouteno.Text);
                            cmd.Parameters.AddWithValue("@routetype_in", txtroutetype.Text);
                            cmd.Parameters.AddWithValue("@bustype_in", txtbustype.Text);
                            cmd.Parameters.AddWithValue("@triangleno_in", txttriangleno.Text);
                            cmd.Parameters.AddWithValue("@startstg_in", txtstartstg.Text);
                            cmd.Parameters.AddWithValue("@endstg_in", txtendstg.Text);
                            cmd.Parameters.AddWithValue("@noofstops_in", txtnoofstops.Text);
                          

                            if(txtstgmarathiname.Text.Equals(""))
                            {
                                cmd.Parameters.AddWithValue("@stgmarathiname_in",DBNull.Value.ToString());
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@stgmarathiname_in", txtstgmarathiname.Text);
                            }
                            if (txtfarechanged.Text.Equals(""))
                            {
                                cmd.Parameters.AddWithValue("@farechanged_in",0);
                            }
                           else
                            {
                                cmd.Parameters.AddWithValue("@farechanged_in", txtfarechanged.Text);
                            }

                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                            btnAddNew.Visible = true;
                            pnlAdd.Visible = false;
                            pnlgvRouteMaster.Visible = true;
                            pnlgvRouteMaster.Visible = true;
                            gvRouteMasterr.Visible = true;

                        }
                    }
                }
            }
            else
            {
                lblErrMsg.Text = "";
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Record already added";


            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnAddNewSubRoute.Visible = false;
            pnlAdd.Visible = false;
            pnlgvRouteMaster.Visible = true;
            pnlgvRouteMaster.Visible = true;
            txtrouteno.Text = "";
            txtroutetype.Text = "";
            txtbustype.Text = "";
            txttriangleno.Text = "";
            txtstartstg.Text = "";
            txtendstg.Text = "";
            txtnoofstops.Text = "";
            txtstgmarathiname.Text = "";
            txtfarechanged.Text = "";
            bindGridView();
            PlnSubRouteMaster.Visible = false;
            gvSubRouteMaster.Visible = false;
            PnlSubRoute.Visible = false;
            PlnSubRouteMaster.Visible = false;
            btnAddNew.Visible = true;
            gvRouteMasterr.Visible = true;

        }

        //protected void gvRouteMasterr_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "view")
        //    {

        //        GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
        //        Label ID = (Label)gvr.FindControl("lblrp_routeno");

        //        btnAddNewSubRoute.Visible = true;

        //        pnlAdd.Visible = true;
             
        //        pnlgvRouteMaster.Visible = false;
        //        gvRouteMasterr.Visible = true;
               
             
        //        DataSet dsDetail = FillDetailGrid(ID.Text);
        //        btnAddNew.Visible = false;
        //        btnSave.Visible = false;
        //        txtrouteno.Enabled = false;
        //        txtstartstg.Enabled = false;
        //        txtendstg.Enabled = false;
        //        txtroutetype.Enabled = false;
        //        txtbustype.Enabled = false;
        //        txttriangleno.Enabled = false;
        //        txtstartstg.Enabled = false;
        //        txtendstg.Enabled = false;
        //        txtnoofstops.Enabled = false;
        //        txtstgmarathiname.Enabled = false;
        //        txtfarechanged.Enabled = false;

        //        txtrouteno.Text = dsDetail.Tables[0].Rows[0]["rp_routeno"].ToString();
        //        txtroutetype.Text = dsDetail.Tables[0].Rows[0]["rp_routetype"].ToString();
        //        txtbustype.Text = dsDetail.Tables[0].Rows[0]["rp_bustype"].ToString();
        //        txttriangleno.Text = dsDetail.Tables[0].Rows[0]["rp_triangleno"].ToString();
        //        txtstartstg.Text = dsDetail.Tables[0].Rows[0]["rp_startstg"].ToString();
        //        txtendstg.Text = dsDetail.Tables[0].Rows[0]["rp_endstg"].ToString();
        //        txtnoofstops.Text = dsDetail.Tables[0].Rows[0]["rp_noofstops"].ToString();
        //        txtstgmarathiname.Text = dsDetail.Tables[0].Rows[0]["rp_stgmarathiname"].ToString();
        //        txtfarechanged.Text = dsDetail.Tables[0].Rows[0]["farechanged"].ToString();

        //        Label DetailID = (Label)gvr.FindControl("lblrp_routeno");
               
       
        //        hifRouteno.Value = DetailID.Text;
        //        DataSet dsDetailnew = FillRouteDetailGrid(DetailID.Text);
        //        gvSubRouteMaster.DataSource = dsDetailnew;
        //        gvSubRouteMaster.DataBind();
        //        PlnSubRouteMaster.Visible = true;
        //        gvSubRouteMaster.Visible = true;
        //        PnlSubRoute.Visible = false;
        //        btnReset.Visible = true;


        //    }
        //}
        public DataSet FillDetailGrid(String CheckListID)
        {


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "Getrouteprogramming"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@id_in", CheckListID);

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


        public DataSet FillRouteDetailGrid(String CheckListID)
        {


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "GetRouteWiseRouteDetails"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@Id", CheckListID);
                        cmd.Parameters.AddWithValue("@ClientID_In", Session["ClientID"].ToString());
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

        protected void gvSubRouteMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvSubRouteMaster.EditIndex = -1;
            DataSet dsDetailnew = FillRouteDetailGrid(hifRouteno.Value);
            gvSubRouteMaster.DataSource = dsDetailnew;
            gvSubRouteMaster.DataBind();
        }


        protected void gvSubRouteMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {



                bool blnReturnVal = false;
                Label lblSubId = gvSubRouteMaster.Rows[e.RowIndex].FindControl("lblSubId") as Label;
                TextBox stgcode = gvSubRouteMaster.Rows[e.RowIndex].FindControl("txtgvrpsdstgcode") as TextBox;
                TextBox stageNo = gvSubRouteMaster.Rows[e.RowIndex].FindControl("txtgvStageNo") as TextBox;
                TextBox stagename = gvSubRouteMaster.Rows[e.RowIndex].FindControl("txtgvrpsd_stgnamee") as TextBox;
                TextBox txtsubrpsdtriangleno = gvSubRouteMaster.Rows[e.RowIndex].FindControl("txtsubrpsdtriangleno") as TextBox;



                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(

                        "Updatenewverrpstagedetails"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@id_in", lblSubId.Text);
                            cmd.Parameters.AddWithValue("@stgcode_in", stgcode.Text);
                            cmd.Parameters.AddWithValue("@stgno_in", stageNo.Text);                           
                            cmd.Parameters.AddWithValue("@stgnamee_in", stagename.Text);
                            cmd.Parameters.AddWithValue("@triangleno_in", txtsubrpsdtriangleno.Text);
                            cmd.ExecuteNonQuery();
                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());

                        }
                    }
                }
                gvSubRouteMaster.EditIndex = -1;
                DataSet dsDetailnew = FillRouteDetailGrid(hifRouteno.Value);
                gvSubRouteMaster.DataSource = dsDetailnew;
                gvSubRouteMaster.DataBind();
                btnAddNewSubRoute.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvSubRouteMaster_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvSubRouteMaster.EditIndex = e.NewEditIndex;
            DataSet dsDetailnew = FillRouteDetailGrid(hifRouteno.Value);
            gvSubRouteMaster.DataSource = dsDetailnew;
            gvSubRouteMaster.DataBind();



        }


        protected void gvRouteMasterr_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvRouteMasterr.EditIndex = -1;
            bindGridView();
        }

        protected void gvRouteMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            bool blnReturnValDel = false;
            try
            {
                Label RouteNoToDelete = gvRouteMasterr.Rows[e.RowIndex].FindControl("lblrp_routeno") as Label;

                if (Session["RoleName"].ToString() != "Administrator")
                    return;

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DeletRouteInBothTables"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@Routeno_in", RouteNoToDelete.Text);
                            blnReturnValDel = Convert.ToBoolean(cmd.ExecuteNonQuery());

                        }
                    }
                }



                gvRouteMasterr.EditIndex = -1;
                bindGridView();
                //return blnReturnValDel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvRouteMasterr_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {



                bool blnReturnVal = false;
                Label HID = gvRouteMasterr.Rows[e.RowIndex].FindControl("lblid") as Label;
                TextBox triangleno = gvRouteMasterr.Rows[e.RowIndex].FindControl("txtrp_triangleno") as TextBox;
                TextBox txtrp_startstg = gvRouteMasterr.Rows[e.RowIndex].FindControl("txtrp_startstg") as TextBox;
                TextBox txtrpendstg = gvRouteMasterr.Rows[e.RowIndex].FindControl("txtrpendstg") as TextBox;
                TextBox txtrpnoofstops = gvRouteMasterr.Rows[e.RowIndex].FindControl("txtrpnoofstops") as TextBox;
               
                

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(

                        "Updatenewverrouteprogramming"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());                         
                            cmd.Parameters.AddWithValue("@id_in", HID.Text);
                            cmd.Parameters.AddWithValue("@triangleno_in", triangleno.Text);
                            cmd.Parameters.AddWithValue("@startstg_in", txtrp_startstg.Text);
                            cmd.Parameters.AddWithValue("@endstg_in", txtrpendstg.Text);
                            cmd.Parameters.AddWithValue("@noofstops_in", txtrpnoofstops.Text);
                            cmd.ExecuteNonQuery();
                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());
                          
                        }
                    }
                }
                gvRouteMasterr.EditIndex = -1;
                bindGridView();
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvRouteMasterr_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvRouteMasterr.EditIndex = e.NewEditIndex;
            bindGridView();
          


        }


        private int CheckDublicSubRouteName(string txtrouteno, String txttriangleno, String txtstgcode, string txtsubstgnamee)
        {
            try
            {
                int RtnVal;
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CheckRPStageDetails"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@rpsd_routeno_in", txtrouteno);
                            cmd.Parameters.AddWithValue("@rpsd_triangleno_in", txttriangleno);
                            cmd.Parameters.AddWithValue("@rpsd_stgcode_in", txtstgcode);
                            cmd.Parameters.AddWithValue("@rpsd_stgnamee_in", txtsubstgnamee);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool blnReturnVal = false;
            int blnReturnDublicVal;
            blnReturnDublicVal = CheckDublicSubRouteName(txtrouteno.Text, txtsubTriangleno.Text, txtstgcode.Text, txtsubstgnamee.Text);

            if (blnReturnDublicVal == 1)
            {

                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(
                        "InsertRPStageDetails"

                        ))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                            cmd.Parameters.AddWithValue("@routeno_in", txtrouteno.Text);
                            cmd.Parameters.AddWithValue("@bustype_in", txtsubbustype.Text);
                            cmd.Parameters.AddWithValue("@triangleno_in", txtsubTriangleno.Text);
                            cmd.Parameters.AddWithValue("@stgcode_in", txtstgcode.Text);
                            cmd.Parameters.AddWithValue("@stgnamee_in", txtsubstgnamee.Text);

                            if (txtsubstgnamem.Text.Equals(""))
                            {
                                cmd.Parameters.AddWithValue("@stgnamem_in", DBNull.Value.ToString());
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@stgnamem_in", txtsubstgnamem.Text);
                            }

                            
                            cmd.Parameters.AddWithValue("@km_in", txtsubkm.Text);
                            cmd.Parameters.AddWithValue("@stgno_in", txtsubstgno.Text);
                          
                            if (txtsubsub.Text.Equals(""))
                            {
                                cmd.Parameters.AddWithValue("@sub_in",0);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@sub_in", txtsubsub.Text);
                            }

                            if (txtsubintrsstg.Text.Equals(""))
                            {
                                cmd.Parameters.AddWithValue("@intrsstg_in", DBNull.Value.ToString());
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@intrsstg_in", txtsubintrsstg.Text);
                            }
                           
                           

                            if (txtsubfarenormal.Text.Equals(""))
                            {

                                cmd.Parameters.AddWithValue("@farenormal_in", DBNull.Value.ToString());
                            }
                            else
                            {
                                 cmd.Parameters.AddWithValue("@farenormal_in", txtsubfarenormal.Text);
                            }

                            if (txtsubsubstgidin.Text.Equals(""))
                            {
                          
                                cmd.Parameters.AddWithValue("@stgid_in",0);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@stgid_in", txtsubsubstgidin.Text);
                            }
                           

                            blnReturnVal = Convert.ToBoolean(cmd.ExecuteNonQuery());

                            PlnSubRouteMaster.Visible = true;
                            gvSubRouteMaster.Visible = true;
                            PnlSubRoute.Visible = false;
                            btnReset.Visible = false;
                            pnlAdd.Visible = true;                           
                            pnlgvRouteMaster.Visible = false;
                            gvRouteMasterr.Visible = true;                          
                            txtsubbustype.Text = "";
                            txtstgcode.Text = "";
                            txtsubstgnamee.Text = "";
                            txtsubTriangleno.Text = "";
                            txtsubstgnamem.Text = "";
                            txtsubkm.Text = "";
                            txtsubstgno.Text = "";
                            txtsubsub.Text = "";
                            txtsubintrsstg.Text = "";
                            txtsubfarenormal.Text = "";
                            txtsubsubstgidin.Text = "";
                            lblErrMsg.Text = "";

                            DataSet dsDetailnew = FillRouteDetailGrid(hifRouteno.Value);

                            gvSubRouteMaster.DataSource = dsDetailnew;
                            gvSubRouteMaster.DataBind();
                        }

                    }
                }
            
            
            }
            else
            {
                lblErrMsg.Text = "";
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Record already added";
            }
        }



      


               protected void btnview_Click(object sender, EventArgs e)
        {

            try
            {




                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            Label ID = (Label)row.FindControl("lblrp_routeno");

          

            btnAddNewSubRoute.Visible = true;

            pnlAdd.Visible = true;

            pnlgvRouteMaster.Visible = false;
            gvRouteMasterr.Visible = true;


            DataSet dsDetail = FillDetailGrid(ID.Text);
            btnAddNew.Visible = false;
            btnSave.Visible = false;
            txtrouteno.Enabled = false;
            txtstartstg.Enabled = false;
            txtendstg.Enabled = false;
            txtroutetype.Enabled = false;
            txtbustype.Enabled = false;
            txttriangleno.Enabled = false;
            txtstartstg.Enabled = false;
            txtendstg.Enabled = false;
            txtnoofstops.Enabled = false;
            txtstgmarathiname.Enabled = false;
            txtfarechanged.Enabled = false;

            txtrouteno.Text = dsDetail.Tables[0].Rows[0]["rp_routeno"].ToString();
            txtroutetype.Text = dsDetail.Tables[0].Rows[0]["rp_routetype"].ToString();
            txtbustype.Text = dsDetail.Tables[0].Rows[0]["rp_bustype"].ToString();
            txttriangleno.Text = dsDetail.Tables[0].Rows[0]["rp_triangleno"].ToString();
            txtstartstg.Text = dsDetail.Tables[0].Rows[0]["rp_startstg"].ToString();
            txtendstg.Text = dsDetail.Tables[0].Rows[0]["rp_endstg"].ToString();
            txtnoofstops.Text = dsDetail.Tables[0].Rows[0]["rp_noofstops"].ToString();
            txtstgmarathiname.Text = dsDetail.Tables[0].Rows[0]["rp_stgmarathiname"].ToString();
            txtfarechanged.Text = dsDetail.Tables[0].Rows[0]["farechanged"].ToString();

          


            hifRouteno.Value = ID.Text;
            DataSet dsDetailnew = FillRouteDetailGrid(ID.Text);
            gvSubRouteMaster.DataSource = dsDetailnew;
            gvSubRouteMaster.DataBind();
            PlnSubRouteMaster.Visible = true;
            gvSubRouteMaster.Visible = true;
            PnlSubRoute.Visible = false;
            btnReset.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void BtnSubRouteCancel_Click(object sender, EventArgs e)
        {
            try
            {


                PnlSubRoute.Visible = false;
            pnlgvRouteMaster.Visible = true;
            PlnSubRouteMaster.Visible = true;
            btnAddNewSubRoute.Visible = true;
            pnlgvRouteMaster.Visible = false;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvSubRouteMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblID = gvSubRouteMaster.Rows[e.RowIndex].FindControl("lblSubId") as Label;

           
            DeleteMethod(lblID.Text);
            gvSubRouteMaster.EditIndex = -1;
            btnReset.Visible = true;
            DataSet dsDetailnew = FillRouteDetailGrid(hifRouteno.Value);
            gvSubRouteMaster.DataSource = dsDetailnew;
            gvSubRouteMaster.DataBind();
            btnAddNewSubRoute.Visible = true;
        }


        public bool DeleteMethod(String CheckListID)
        {
            bool blnReturnValDel = false;



            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "DeletenewverrpstagedetailsMaster"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@Id_in", CheckListID);
                        blnReturnValDel = Convert.ToBoolean(cmd.ExecuteNonQuery());
                       
                    }
                }
            }


            return blnReturnValDel;

        }

        protected void btnAddNewSubRoute_Click(object sender, EventArgs e)
        {
            PnlSubRoute.Visible = true;
            pnlgvRouteMaster.Visible = false;
            PlnSubRouteMaster.Visible = false;
            btnAddNewSubRoute.Visible = false;

        }
    }
}

