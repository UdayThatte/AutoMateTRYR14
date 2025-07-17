
using MySql.Data.MySqlClient;
using System;
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

namespace AutomateTRYOUT
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_OperationsView");
                //ddlMachineNo.Items.Clear();
                //ddlConductor.Items.Clear();
                //ddlWyBill.Items.Clear();
               // bindGridView();
                ddlFillddlMachineNo();
                ddlFillddlConductor();
                ddlWayBillFill();

                ddlMachineNo.Visible = true;
                ddlConductor.Visible = true;
                ddlWyBill.Visible = true;
                lblMachineNo.Visible = true;
                lblTicketCode.Visible = true;
                lblWyBill.Visible = true;
                sendPing();
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



        private void ddlFillddlConductor()
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetConductorDetails"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {

                   
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                       // cmd.CommandTimeout = 500;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlConductor.DataSource = ds;
                            ddlConductor.DataTextField = "cd_condrdetails_code";
                            ddlConductor.DataValueField = "cd_condrdetails_code";
                            ddlConductor.DataBind();
                        }
                    }
                }
            }
        }


        private void ddlWayBillFill()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetRecentWayBillList"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                       // cmd.CommandTimeout = 500;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlWyBill.DataSource = ds;
                            ddlWyBill.DataTextField = "wbp_waybillno";
                            ddlWyBill.DataValueField = "wbp_waybillno";
                            ddlWyBill.DataBind();
                        }
                    }
                }
            }
        }

        private void ddlFillddlMachineNo()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetMachine"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                       // cmd.CommandTimeout = 500;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            ddlMachineNo.DataSource = ds;
                            ddlMachineNo.DataTextField = "MACHINENAME";
                            ddlMachineNo.DataValueField = "MACHINENAME";
                            ddlMachineNo.DataBind();
                        }
                    }
                }
            }
        }


        protected void BtnRefresh_Click(object sender, EventArgs e)
        {
            bindGridView();
        }
            


        protected void BtnApply_Click(object sender, EventArgs e)
        {
            bindGridView();

            //string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("SearchIndexPageView"))
            //    {
            //        using (MySqlDataAdapter da = new MySqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
            //            cmd.Parameters.AddWithValue("@ddlMachineNo", ddlMachineNo.SelectedValue);
            //            cmd.Parameters.AddWithValue("@ddlWyBill", ddlWyBill.SelectedValue);
            //            cmd.Parameters.AddWithValue("@ddlConductor", ddlConductor.SelectedValue);


            //            da.SelectCommand = cmd;

            //            using (DataTable dt = new DataTable())
            //            {
            //                da.Fill(dt);
            //                GridView1.DataSource = dt;
            //                GridView1.DataBind();
            //            }
            //        }
            //    }
            //}


        }
        

        private void bindGridView()
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("IndexPageView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                          
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 500;
                            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlWyBill_in", ddlWyBill.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlConductor_in", ddlConductor.SelectedValue);


                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();



                            decimal TotalFare = 0;
                            decimal FullTicketFare = 0;
                            decimal HalfTicketFare = 0;
                            decimal LuggageFare = 0;
                            decimal PassFare = 0;
                            decimal PaxCount = 0;
                            decimal LuggageCount = 0;
                            decimal PassCount = 0;
                            decimal AgentTicketCount = 0;
                            decimal ConcessionFare = 0;
                            decimal Expenses = 0;
                            decimal Penulty = 0;

                             foreach (DataRow dr in dt.Rows)
                             {
                                 try { TotalFare += Convert.ToDecimal(dr["TotalFare"]); } catch (Exception) { }
                                try { FullTicketFare += Convert.ToDecimal(dr["FullTicketFare"]); } catch (Exception) { }
                               try { HalfTicketFare += Convert.ToDecimal(dr["HalfTicketFare"]); } catch (Exception) { }
                               try { LuggageFare += Convert.ToDecimal(dr["LuggageFare"]); } catch (Exception) { }
                               try { PassFare += Convert.ToDecimal(dr["PassFare"]); } catch (Exception) { }
                                try{ PaxCount += Convert.ToDecimal(dr["PaxCount"]); } catch (Exception) { }                             
                                 try { LuggageCount += Convert.ToDecimal(dr["LuggageCount"]); } catch (Exception) { }
                               try{ PassCount += Convert.ToDecimal(dr["PassCount"]);  } catch (Exception) { }
                               try {AgentTicketCount += Convert.ToDecimal(dr["AgentTicket"]); } catch (Exception) { }
                                try{ ConcessionFare += Convert.ToDecimal(dr["ConcessionFare"]); } catch (Exception) { }
                                  try { Expenses += Convert.ToDecimal(dr["Expenses"]); } catch (Exception) { }
                                  try {  Penulty += Convert.ToDecimal(dr["Penalty"]); } catch (Exception) { }                      


                             }

                            tblCelTotalFare.Text = TotalFare.ToString();
                            tblCelFullTicketFare.Text = FullTicketFare.ToString();
                            tblHalfTicketFare.Text = HalfTicketFare.ToString();
                            tblCelLuggageFare.Text = LuggageFare.ToString();
                            tblCelPaxCpunt.Text = PaxCount.ToString();
                            tblCelConcessionFare.Text = ConcessionFare.ToString();
                            tblCelExpenses.Text = Expenses.ToString();
                            tblCelAgentTicketCount.Text = AgentTicketCount.ToString();
                            tblCelPenalty.Text = Penulty.ToString();



                            //Calculate Sum and display in Footer Row
                            //  decimal TotalFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalFare"));
                            //decimal FullTicketFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("FullTicketFare"));
                            //decimal HalfTicketFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("HalfTicketFare"));
                            //decimal LuggageFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageFare"));
                            //decimal PassFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassFare"));
                            //decimal PaxCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PaxCount"));
                            //decimal LuggageCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageCount"));
                            //decimal PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //long AgentTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("AgentTicket"));
                            //decimal ConcessionFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("ConcessionFare"));
                            //decimal Expenses = dt.AsEnumerable().Sum(row => row.Field<decimal>("Expenses"));
                            //decimal Penulty = dt.AsEnumerable().Sum(row => row.Field<decimal>("Penalty"));



                            //GridView1.FooterRow.Cells[0].Text = "Total";
                            //GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[5].Text = TotalFare.ToString("N0");
                            //GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[6].Text = FullTicketFare.ToString("N0");
                            //GridView1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[7].Text = HalfTicketFare.ToString("N0");
                            //GridView1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[8].Text = LuggageFare.ToString("N0");
                            //GridView1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[9].Text = PassFare.ToString("N0");
                            //GridView1.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[10].Text = PaxCount.ToString("N0");
                            //GridView1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[11].Text = LuggageCount.ToString("N0");
                            //GridView1.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Right;
                            //GridView1.FooterRow.Cells[12].Text = PassCount.ToString("N0");
                            //GridView1.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Right;

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

        protected void BtnReset_Click(object sender, EventArgs e)
        {

         

                 ddlMachineNo.Items.Clear();
            ddlConductor.Items.Clear();
            ddlWyBill.Items.Clear();

            ddlMachineNo.Items.Insert(0, new ListItem("ALL", "ALL")); // 
            ddlConductor.Items.Insert(0, new ListItem("ALL", "ALL")); // 
            ddlWyBill.Items.Insert(0, new ListItem("ALL", "ALL")); // 
            bindGridView();
            ddlFillddlMachineNo();
            ddlFillddlConductor();
            ddlWayBillFill();

         

            ddlMachineNo.Enabled = true;
            ddlConductor.Enabled = true;
            ddlWyBill.Enabled = true;


            ddlMachineNo.Visible = true;
            ddlConductor.Visible = true;
            ddlWyBill.Visible = true;
            lblMachineNo.Visible = true;
            lblTicketCode.Visible = true;
            lblWyBill.Visible = true;
        }

        protected void ddlConductor_SelectedIndexChanged(object sender, EventArgs e)
        {


            bindGridView();
            ddlMachineNo.Enabled = false;
            ddlConductor.Enabled = false;
            ddlWyBill.Enabled = false;
            ddlFillddlMachineNo();
            ddlWayBillFill();


            ddlMachineNo.Visible = false;
          
            ddlWyBill.Visible = false;
            lblMachineNo.Visible = false;
          
            lblWyBill.Visible = false;
        }

        protected void ddlWyBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGridView();


            ddlMachineNo.Enabled = false;
            ddlConductor.Enabled = false;
            ddlWyBill.Enabled = false;
            ddlFillddlMachineNo();
            ddlFillddlConductor();


            ddlMachineNo.Visible = false;
            ddlConductor.Visible = false;
          
            lblMachineNo.Visible = false;
            lblTicketCode.Visible = false;
        
        }

        protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            bindGridView();
            ddlMachineNo.Enabled = false;
            ddlConductor.Enabled = false;
            ddlWyBill.Enabled = false;
            ddlWayBillFill();
            ddlFillddlConductor();


          
            ddlConductor.Visible = false;
            ddlWyBill.Visible = false;
           
            lblTicketCode.Visible = false;
            lblWyBill.Visible = false;
        }
    }
}

