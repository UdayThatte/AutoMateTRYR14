using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AutomateTRYOUT.Forms
{
    public partial class IndexNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_OperationsView");
             
              
                bindGridView();
             
                sendPing();
                pnlIndexNew.Visible = true;
                PnlMain.Visible = false;
                pnlhed.Visible = false;
            }
        }


        private void sendPing()
        {
            try
            {

                // Create a request for the URL.        
                WebRequest request = WebRequest.Create("http://automatesystemsdataservice.in/AMDS/AutomateInternalWS.asmx/HelloWorld");
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();


                // Create a request for the URL.        
                WebRequest request2 = WebRequest.Create("http://automatesystemsdataservice.in/AMDS_Demo/AutomateInternalWS.asmx/HelloWorld");
                // Get the response.
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                response2.Close();

            }
            catch (Exception ex)
            {


            }
        }



    

       

      


       



        private void bindGridView()
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("IndexPageViewNew"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 500;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());             


                            da.SelectCommand = cmd;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                GVIndexNew.DataSource = dt;
                                GVIndexNew.DataBind();

                               

                              

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


        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.EditIndex = -1;
        }
        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = e.Row.Cells[3].Text;
                if (status.Equals("ISSUED"))
                {
                    e.Row.BackColor = Color.FromName("#41A317");
                }
            }
        }


        protected void btnIndexNewview_Click(object sender, EventArgs e)
        {

            try
            {




                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label WaybillNo = (Label)row.FindControl("lblWaybillNo");




                DataSet dsDetail = FillDetailGrid(WaybillNo.Text);
               
                GridView1.DataSource = dsDetail;
                GridView1.DataBind();
                pnlIndexNew.Visible = false;
                PnlMain.Visible = true;
                pnlhed.Visible = false;







            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet FillDetailGrid(String WaybillNo)
        {


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "GetWayBillWiseDetails"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@ddlWyBill_in", WaybillNo);

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
        protected void GVIndexNew_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void GVIndexNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIndexNew.PageIndex = e.NewPageIndex;

            GVIndexNew.EditIndex = -1;
        }
      

        protected void BtnReset_Click(object sender, EventArgs e)
        {



        }

       

       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bindGridView();
            pnlIndexNew.Visible = true;
            PnlMain.Visible = false;
            pnlhed.Visible = false;
        }
    }
}
