using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AutomateTRYOUT
{
    public partial class RecentTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                (this.Master as Site1).SetActiveMenu("menu_OperationsView");
                bindGridView();
                ddlFillddlMachineNo();
                //ddlFillddlConductor();
                ddlWayBillFill();
            }
        }

   


        private void ddlFillddlConductor()
        {
            try
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
                            cmd.CommandTimeout = 600;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ddlWayBillFill()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetRecentTicketsWayBill"))
                    // using (MySqlCommand cmd = new MySqlCommand("GetRecentWayBillList"))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 600;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ddlFillddlMachineNo()
        {
            try
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
                            cmd.CommandTimeout = 600;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bindGridViewSingleMachine() //uday
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //uday PROCEDURE `Selected_Ticket_Export`(IN `ClientID_in` VARCHAR(50), IN `ddlWyBill_in` VARCHAR(50))
                using (MySqlCommand cmd = new MySqlCommand("Selected_Machine_Ticket_Export"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());


                        cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlWyBill_in", ddlWyBill.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlConductor_in", ddlConductor.SelectedValue);


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
                            decimal PaxCount = 0;
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
                                try { PaxCount += Convert.ToDecimal(dr["PaxCount"]); } catch (Exception) { }
                                try { AgentTicketCount += Convert.ToDecimal(dr["IsAgentTicket"]); } catch (Exception) { }
                                try { ConcessionFare += Convert.ToDecimal(dr["ConcessionAmount"]); } catch (Exception) { }
                                try { Expenses += Convert.ToDecimal(dr["Expenses"]); } catch (Exception) { }
                                try { Penulty += Convert.ToDecimal(dr["Penalty"]); } catch (Exception) { }


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
                        }
                    }
                }
            }

        }
        private void bindGridViewSingleWaybill() //uday
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //uday PROCEDURE `Selected_Ticket_Export`(IN `ClientID_in` VARCHAR(50), IN `ddlWyBill_in` VARCHAR(50))
                using (MySqlCommand cmd = new MySqlCommand("Selected_Waybill_Ticket_Export"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());


                        //cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
                        cmd.Parameters.AddWithValue("@ddlWyBill_in", ddlWyBill.SelectedValue);
                        //cmd.Parameters.AddWithValue("@ddlConductor_in", ddlConductor.SelectedValue);


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
                            decimal PaxCount = 0;
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
                                try { PaxCount += Convert.ToDecimal(dr["PaxCount"]); } catch (Exception) { }
                                try { AgentTicketCount += Convert.ToDecimal(dr["IsAgentTicket"]); } catch (Exception) { }
                                try { ConcessionFare += Convert.ToDecimal(dr["ConcessionAmount"]); } catch (Exception) { }
                                try { Expenses += Convert.ToDecimal(dr["Expenses"]); } catch (Exception) { }
                                try { Penulty += Convert.ToDecimal(dr["Penalty"]); } catch (Exception) { }


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


                            //try
                            //{
                            //    //Calculate Sum and display in Footer Row
                            //    TotalFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalFare"));
                            //    FullTicketFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("FullTicketFare"));
                            //    HalfTicketFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("HalfTicketFare"));
                            //    LuggageFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageFare"));
                            //    PaxCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PaxCount"));
                            //    LuggageCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageCount"));
                            //    PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //    AgentTicketCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("AgentTicket"));
                            //    ConcessionFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("ConcessionFare"));
                            //    Expenses = dt.AsEnumerable().Sum(row => row.Field<decimal>("Expenses"));
                            //    Penulty = dt.AsEnumerable().Sum(row => row.Field<decimal>("Penalty"));

                            //}
                            //catch(Exception ex)
                            //{

                            //}
                            ////   tblCelTotalFare.Text = TotalFare.ToString();
                            ////   tblCelFullTicketFare.Text = FullTicketFare.ToString();
                            ////   tblHalfTicketFare.Text = HalfTicketFare.ToString();
                            ////   tblCelLuggageFare.Text = LuggageCount.ToString();
                            ////   tblCelPaxCpunt.Text = PaxCount.ToString();
                            ////   tblCelConcessionFare.Text = ConcessionFare.ToString();
                            ////tblCelExpenses.Text = Expenses.ToString();
                            //// //  tblCelAgentTicketCount.Text = AgentTicketCount.ToString();
                            //// tblCelPenalty.Text = Penulty.ToString();


                            //Calculate Sum and display in Footer Row
                            //decimal TotalTickets = dt.AsEnumerable().Count();
                            //                long FullTicketFare = dt.AsEnumerable().Sum(row => row.Field<long>("FullTicketFare"));
                            //                long HalfTicketFare = dt.AsEnumerable().Sum(row => row.Field<long>("HalfTicketFare"));
                            //                long PassFare = dt.AsEnumerable().Sum(row => row.Field<long>("PassFare"));
                            //                long LuggageCount = dt.AsEnumerable().Sum(row => row.Field<long>("LuggageCount"));
                            //                //decimal PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //                long TotalTicketAmount = dt.AsEnumerable().Sum(row => row.Field<long>("TotalFare"));
                            //                long ConcessionAmount = dt.AsEnumerable().Sum(row => row.Field<long>("ConcessionAmount"));

                            //                long fullPax = dt.AsEnumerable().Sum(row => row.Field<long>("FullPaxCount"));
                            //                long halfPax  = dt.AsEnumerable().Sum(row => row.Field<long>("HalfPaxCount"));
                            //                long passPax = dt.AsEnumerable().Sum(row => row.Field<long>("PassPaxCount"));
                            //                long PaxCount = halfPax + fullPax;
                            //                long FullTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("FullTicketCount"));
                            //                long HalfTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("HalfTicketCount"));
                            //                long PassTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("PassTicketCount"));


                            //                  decimal PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //                long AgentTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("AgentTicket"));
                            //                decimal ConcessionFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("ConcessionFare"));
                            //                decimal Expenses = dt.AsEnumerable().Sum(row => row.Field<decimal>("Expenses"));
                            //                decimal Penulty = dt.AsEnumerable().Sum(row => row.Field<decimal>("Penalty"));

                            // long TotalCollectionAmount = TotalTicketAmount - PassFare;



                            //tblCelTotalTickets.Text = TotalTickets.ToString();
                            //tblCelTotalPersons.Text = PaxCount.ToString();
                            //tblCelFullPaxCount.Text = fullPax.ToString();
                            //tblCelHalfPaxCount.Text = halfPax.ToString();
                            //tblAgentTicketCount.Text = AgentTicketCount.ToString();
                            //tblCellLuggageTicketCount.Text = LuggageCount.ToString();

                            //tblCelConcessionFare.Text = ConcessionFare.ToString();
                            //tblPenalty.Text = Penulty.ToString();
                            //tblCelExpenses.Text = Expenses.ToString();
                            //  tblCelPassPaxCount.Text = PassTicketCount.ToString();
                            // tblCelCosessionAmount.Text = ConcessionAmount.ToString();
                            // tblCelTotalTicketAmount.Text = TotalTicketAmount.ToString();

                            //  tblCelTotalColAmount.Text = TotalCollectionAmount.ToString();
                            // tblCelPaymentAmount.Text = "0";
                            //tblCelNetAmount.Text = "0";

                        }
                    }
                }
            }
        }


        private void bindGridView()
        {


            //string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("RecentTicketsView"))
            //    {
            //        using (MySqlDataAdapter da = new MySqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());


            //            da.SelectCommand = cmd;

            //            using (DataTable dt = new DataTable())
            //            {
            //                da.Fill(dt);
            //                GridView1.DataSource = dt;
            //                GridView1.DataBind();


            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //uday PROCEDURE `Selected_Ticket_Export`(IN `ClientID_in` VARCHAR(50), IN `ddlWyBill_in` VARCHAR(50))
                using (MySqlCommand cmd = new MySqlCommand("RecentTicketsView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
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
                            decimal PaxCount = 0;
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
                                try { PaxCount += Convert.ToDecimal(dr["PaxCount"]); } catch (Exception) { }
                                try { AgentTicketCount += Convert.ToDecimal(dr["IsAgentTicket"]); } catch (Exception) { }
                                try { ConcessionFare += Convert.ToDecimal(dr["ConcessionAmount"]); } catch (Exception) { }
                                try { Expenses += Convert.ToDecimal(dr["Expenses"]); } catch (Exception) { }
                                try { Penulty += Convert.ToDecimal(dr["Penalty"]); } catch (Exception) { }


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


                            //try
                            //{
                            //    //Calculate Sum and display in Footer Row
                            //    TotalFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalFare"));
                            //    FullTicketFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("FullTicketFare"));
                            //    HalfTicketFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("HalfTicketFare"));
                            //    LuggageFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageFare"));
                            //    PaxCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PaxCount"));
                            //    LuggageCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("LuggageCount"));
                            //    PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //    AgentTicketCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("AgentTicket"));
                            //    ConcessionFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("ConcessionFare"));
                            //    Expenses = dt.AsEnumerable().Sum(row => row.Field<decimal>("Expenses"));
                            //    Penulty = dt.AsEnumerable().Sum(row => row.Field<decimal>("Penalty"));

                            //}
                            //catch(Exception ex)
                            //{

                            //}
                            ////   tblCelTotalFare.Text = TotalFare.ToString();
                            ////   tblCelFullTicketFare.Text = FullTicketFare.ToString();
                            ////   tblHalfTicketFare.Text = HalfTicketFare.ToString();
                            ////   tblCelLuggageFare.Text = LuggageCount.ToString();
                            ////   tblCelPaxCpunt.Text = PaxCount.ToString();
                            ////   tblCelConcessionFare.Text = ConcessionFare.ToString();
                            ////tblCelExpenses.Text = Expenses.ToString();
                            //// //  tblCelAgentTicketCount.Text = AgentTicketCount.ToString();
                            //// tblCelPenalty.Text = Penulty.ToString();


                            //Calculate Sum and display in Footer Row
                            //decimal TotalTickets = dt.AsEnumerable().Count();
                            //                long FullTicketFare = dt.AsEnumerable().Sum(row => row.Field<long>("FullTicketFare"));
                            //                long HalfTicketFare = dt.AsEnumerable().Sum(row => row.Field<long>("HalfTicketFare"));
                            //                long PassFare = dt.AsEnumerable().Sum(row => row.Field<long>("PassFare"));
                            //                long LuggageCount = dt.AsEnumerable().Sum(row => row.Field<long>("LuggageCount"));
                            //                //decimal PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //                long TotalTicketAmount = dt.AsEnumerable().Sum(row => row.Field<long>("TotalFare"));
                            //                long ConcessionAmount = dt.AsEnumerable().Sum(row => row.Field<long>("ConcessionAmount"));

                            //                long fullPax = dt.AsEnumerable().Sum(row => row.Field<long>("FullPaxCount"));
                            //                long halfPax  = dt.AsEnumerable().Sum(row => row.Field<long>("HalfPaxCount"));
                            //                long passPax = dt.AsEnumerable().Sum(row => row.Field<long>("PassPaxCount"));
                            //                long PaxCount = halfPax + fullPax;
                            //                long FullTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("FullTicketCount"));
                            //                long HalfTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("HalfTicketCount"));
                            //                long PassTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("PassTicketCount"));


                            //                  decimal PassCount = dt.AsEnumerable().Sum(row => row.Field<decimal>("PassCount"));
                            //                long AgentTicketCount = dt.AsEnumerable().Sum(row => row.Field<long>("AgentTicket"));
                            //                decimal ConcessionFare = dt.AsEnumerable().Sum(row => row.Field<decimal>("ConcessionFare"));
                            //                decimal Expenses = dt.AsEnumerable().Sum(row => row.Field<decimal>("Expenses"));
                            //                decimal Penulty = dt.AsEnumerable().Sum(row => row.Field<decimal>("Penalty"));

                            // long TotalCollectionAmount = TotalTicketAmount - PassFare;



                            //tblCelTotalTickets.Text = TotalTickets.ToString();
                            //tblCelTotalPersons.Text = PaxCount.ToString();
                            //tblCelFullPaxCount.Text = fullPax.ToString();
                            //tblCelHalfPaxCount.Text = halfPax.ToString();
                            //tblAgentTicketCount.Text = AgentTicketCount.ToString();
                            //tblCellLuggageTicketCount.Text = LuggageCount.ToString();

                            //tblCelConcessionFare.Text = ConcessionFare.ToString();
                            //tblPenalty.Text = Penulty.ToString();
                            //tblCelExpenses.Text = Expenses.ToString();
                            //  tblCelPassPaxCount.Text = PassTicketCount.ToString();
                            // tblCelCosessionAmount.Text = ConcessionAmount.ToString();
                            // tblCelTotalTicketAmount.Text = TotalTicketAmount.ToString();

                            //  tblCelTotalColAmount.Text = TotalCollectionAmount.ToString();
                            // tblCelPaymentAmount.Text = "0";
                            //tblCelNetAmount.Text = "0";

                        }
                    }
                }
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
                string Ticket_Code = e.Row.Cells[0].Text;
                string ConCase_Code = e.Row.Cells[1].Text;
               

                if (Ticket_Code.Equals("CASE")) //INSPECTOR
                {
                    if (ConCase_Code.Equals("01")) // CHECKED OK
                    {
                        e.Row.BackColor = Color.FromName("#A9DFBF");
                        e.Row.ForeColor = Color.FromName("#000000");
                    }
                    else if (ConCase_Code.Equals("02")) // ORDINARY CASE
                    {
                        e.Row.BackColor = Color.FromName("#FCF3CF");
                        e.Row.ForeColor = Color.FromName("#000000");

                    }
                    else if (ConCase_Code.Equals("03")) //RED MARK CASE
                    {
                        e.Row.BackColor = Color.FromName("#D98880");
                        e.Row.ForeColor = Color.FromName("#000000");
                    }
                    else if (ConCase_Code.Equals("04")) //OUTSTANDING CASE
                    {
                        e.Row.BackColor = Color.FromName("#cc2c1a");
                        e.Row.ForeColor = Color.FromName("#ffffff");
                    }

                    //else if (ConCase_Code.Equals("0875")) //OUTSTANDING CASE
                    //{
                    //    e.Row.BackColor = Color.FromName("#af8f0f");
                    //    e.Row.ForeColor = Color.FromName("#ffffff");
                    //}

                    
                    else
                    {
                        // e.Row.BackColor = Color.FromName("#34495E");.
                        e.Row.BackColor = Color.FromName("#5d9ad8");
                        e.Row.ForeColor = Color.FromName("#000000");

                    }
                }

                if (Ticket_Code.Equals("LUGG")) //Luggage
                {
                    e.Row.BackColor = Color.FromName("#E59866");
                    e.Row.ForeColor = Color.FromName("#17202A");

                }

                if (Ticket_Code.Equals("CONC")) //CONCESSION
                {
                    e.Row.BackColor = Color.FromName("#A3E4D7");
                    e.Row.ForeColor = Color.FromName("#000000");

                }

                if (Ticket_Code.Equals("EXPN")) //EXPENSES
                {
                    e.Row.BackColor = Color.FromName("#E74C3C");//uday "#dbb9b6");
                    e.Row.ForeColor = Color.FromName("#17202A");// "#ffffff");

                }

                if (Ticket_Code.Equals("PASS")) //PASS
                {
                    if (ConCase_Code.Equals("01")) // FREE PASS CATEGORY 1
                    {
                        e.Row.BackColor = Color.FromName("#ABEBC6");
                        e.Row.ForeColor = Color.FromName("#17202A");// "#000000");
                    }
                    else if (ConCase_Code.Equals("02")) // FREE PASS CATEGORY 2
                    {
                        e.Row.BackColor = Color.FromName("#82E0AA");// "#8291e0");
                        e.Row.ForeColor = Color.FromName("#17202A");// "#000000");
                    }
                    else if (ConCase_Code.Equals("03")) //RFID
                    {
                        e.Row.BackColor = Color.FromName("#58D68D");// "#ac58d6");
                        e.Row.ForeColor = Color.FromName("#17202A");// "#000000");
                    }
                    else
                    {
                        e.Row.BackColor = Color.FromName("#e5ebab");
                        e.Row.ForeColor = Color.FromName("#000000");

                    }
                }

                if (Ticket_Code.Equals("RCVT")) //RECHARGE
                {
                    e.Row.BackColor = Color.FromName("#BB8FCE");
                    e.Row.ForeColor = Color.FromName("#000000");

                }

                if (Ticket_Code.Equals("PNTY")) //PENALTY
                {
                    e.Row.BackColor = Color.FromName("#3498DB");
                    e.Row.ForeColor = Color.FromName("#17202A");// "#000000");

                }

                if (Ticket_Code.Equals("TCOL")) //TOLL COLLECTED
                {
                    e.Row.BackColor = Color.FromName("#E59866");
                    e.Row.ForeColor = Color.FromName("#000000");

                }

                // && ConCase_Code.Length == 4 && 
                if (ConCase_Code != null)
                {
                    if (ConCase_Code.Contains("A"))
                    {
                        e.Row.BackColor = Color.FromName("#ccff00"); //Agent Tickets
                        e.Row.ForeColor = Color.FromName("#000000");

                    }

                    //if((String.Compare(ConCase_Code.Substring(0, 1), "A") == 0))
                    //{
                    //    e.Row.BackColor = Color.FromName("#ccff00"); //Agent Tickets
                    //}
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
            //important here but not required in agentreport ??? Uday
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            string filename;
            Response.ClearContent();
            Response.Buffer = true;

            if (ddlWyBill.SelectedValue.ToString()=="ALL")
                 filename = "AllTickets_" + ddlMachineNo.SelectedValue.ToString() + ".XLS";
            else
               filename = "AllTickets_" + ddlWyBill.SelectedValue.ToString() + ".XLS";

            Response.AddHeader("content-disposition", "attachment; filename = " + filename);
            Response.ContentType = "application/excel";
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.Charset = "";
            //this.EnableViewState = false;
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            GridView1.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
            //apply btn code changed // UDAY
            //bindGridView();
            //string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("RecentTicketsView"))
            //    {
            //        using (MySqlDataAdapter da = new MySqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());


            //            cmd.Parameters.AddWithValue("@ddlMachineNo_in", ddlMachineNo.SelectedValue);
            //            cmd.Parameters.AddWithValue("@ddlWyBill_in", ddlWyBill.SelectedValue);
            //            cmd.Parameters.AddWithValue("@ddlConductor_in", ddlConductor.SelectedValue);


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

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            GridView1.AllowPaging = true;//uday
            GridView1.PageSize = 15;//uday
            BtnExport.Visible = false;
            lblMachineNo.Visible = true;
            lblConductorCode.Visible = false;
            lblWyBill.Visible = true;
            ddlConductor.Visible = false;
            ddlMachineNo.Visible = true;
            ddlWyBill.Visible = true;

            ddlMachineNo.Items.Clear();
            ddlConductor.Items.Clear();
            ddlWyBill.Items.Clear();


            ddlMachineNo.Items.Insert(0, new ListItem("ALL", "ALL")); // 
            ddlConductor.Items.Insert(0, new ListItem("ALL", "ALL")); // 
            ddlWyBill.Items.Insert(0, new ListItem("ALL", "ALL")); // 

            bindGridView();
            ddlFillddlMachineNo();
            //ddlFillddlConductor();
            ddlWayBillFill();
            ddlMachineNo.Enabled = true;
            ddlWyBill.Enabled = true;
            ddlConductor.Enabled = true;



        }

        protected void ddlMachineNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            GridView1.PageSize = 10000;//uday Only 1 page for selected waybil for export
            //bindGridView();
            bindGridViewSingleMachine();//for only current date
            BtnExport.Visible = true;

            ddlMachineNo.Enabled = false;
            ddlWyBill.Enabled = false;
            ddlConductor.Enabled = false;



            lblConductorCode.Visible = false;
            lblWyBill.Visible = false;
            ddlConductor.Visible = false;

            ddlWyBill.Visible = false;

        }

        protected void ddlConductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
            ddlMachineNo.Enabled = false;
            ddlWyBill.Enabled = false;
            ddlConductor.Enabled = false;

            lblMachineNo.Visible = false;

            lblWyBill.Visible = false;

            ddlMachineNo.Visible = false;
            ddlWyBill.Visible = false;
            bindGridView();

        }

        protected void ddlWyBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            GridView1.PageSize = 10000;//uday Only 1 page for selected waybil for export
            //bindGridView();
            bindGridViewSingleWaybill();
            BtnExport.Visible = true;
            

            ddlMachineNo.Enabled = false;
            ddlWyBill.Enabled = false;
            ddlConductor.Enabled = false;

            lblMachineNo.Visible = false;
            lblConductorCode.Visible = false;

            ddlConductor.Visible = false;
            ddlMachineNo.Visible = false;



        }
    }
}