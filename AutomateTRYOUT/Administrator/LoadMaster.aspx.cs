using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Threading;

namespace AutomateTRYOUT.Administrator
{
    public partial class LoadMaster : System.Web.UI.Page
    {

         enum DataDestination
        {
            RouteMaster,
            StageMaster,
            ConductorMaster,
            DriverMaster,
            InspectorMaster,
            AgentMaster
        }
        private DataDestination getDestinationFromString(string value)
        {
            switch (value)
            {
                case "Route Master":
                    return DataDestination.RouteMaster;
                case "Counductor Master":
                    return  DataDestination.ConductorMaster;
                case "Agent Master":
                    return DataDestination.AgentMaster;
                case "Driver Master":
                    return DataDestination.DriverMaster;
                //case "Vehicle Master":
                //    panel_vehicle.Visible = true;
                //    BindTo_VehicleGrid();
                //    break;
                case "Stage Master":
                    return DataDestination.StageMaster;
                case "Inspector Master":
                    return DataDestination.InspectorMaster;

            }
            throw new Exception("Invalid Enum Option");

        }
        //private DataTable tblcsv = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();
                FileUploadControl.Visible = false;
                UploadButton.Visible = false;
                PromoteButton.Visible = false;
                ResetButton.Visible = false;
                InvisibleAllGrids();
  

            }
            
            DataTable tblLogging = new DataTable();
            tblLogging.Columns.Add("Line No");
            tblLogging.Columns.Add("Row Data");
            tblLogging.Columns.Add("Status");
            tblLogging.Columns.Add("Message");
            Session["tblLogging"] = tblLogging;
        }


        protected void OnSelectedIndexChanged_DropDownList_master(object sender, EventArgs e)
        {
            string selectedItem = DropDownList_master.SelectedItem.ToString();

            if (selectedItem.Equals("--- Select ---"))
            {
                FileUploadControl.Visible = false;
                UploadButton.Visible = false;
                InvisibleAllGrids();
            }
            else
            {
                FileUploadControl.Enabled = true;
                FileUploadControl.Visible = true;
                UploadButton.Visible = true;
                Panel_MasterDescription.Visible = true;
                //PopulateDescription(getDestinationFromString(DropDownList_master.SelectedItem.ToString()));
                ResetButton.Visible = true;
            }

        }

        protected void GetButton_Click(object sender, EventArgs e)
        {
            lblerrer.Text = "00";
            lblFile.Visible = false;
            lblFile.Text = "";
            PleaseWaitPopup.Show();
            if (FileUploadControl.HasFile)
            {
               
                lblerrer.Text = "0";
                FileUploadControl.Enabled = false;
                UploadButton.Visible = false;
                PromoteButton.Visible = true;
                ResetButton.Visible = true;
                try
                {
                    FileUploadControl.Visible = false;
                    lblerrer.Text = "1";
                    string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        con.Open();
                        string filename = Path.GetFileName(FileUploadControl.FileName);

                        string[] FileName = FileUploadControl.FileName.ToString().Split('.');
                        int index = FileName.Length;
                        string FileExt = FileName[index - 1].ToString();
                        if ((FileExt.ToString().Equals("csv")) | (FileExt.ToString().Equals("CSV")))
                        {
                            lblFile.Visible = true;
                            lblFile.Text = "File Name:" + filename;

                            FileUploadControl.SaveAs(Server.MapPath("~/upload/") + filename);

                            // FileUploadControl.SaveAs(Server.MapPath(@"../upload") + filename);

                            GridView_logging.Visible = true;
                            GridView_logging.Caption = "";//uday 

                            processFile(con, Server.MapPath("~/upload/") + filename, getDestinationFromString(DropDownList_master.SelectedItem.ToString()));
                            //processFile(con, Server.MapPath(@"../upload") + filename, getDestinationFromString(DropDownList_master.SelectedItem.ToString()));
                            BindGrid(getDestinationFromString(DropDownList_master.SelectedItem.ToString()), con);
                            DropDownList_master.Enabled = false;//uday
                        }
                        else
                        {
                            PromoteButton.Visible = false;
                            ResetButton.Visible = true;
                            lblFile.Visible = true;
                            lblFile.Text = "Please Select File of Type .csv";
                           

                        }
                    }
                }
                catch (Exception ex)
                {
                    PleaseWaitPopup.Hide();
                    throw ex;
                    
                }
            }
            PleaseWaitPopup.Hide();
        }
        private void processFile(MySqlConnection con, string dataFileName,DataDestination dest){

            //  Read the file one line each
            //  Insert into destination
            //  Update Log

            //  string tokenizing
            //  validation about column count
            //  call to insert
            //  call to log 

            DataTable tblLogging = (DataTable)Session["tblLogging"];
            if (null == tblLogging)
            {
                tblLogging = new DataTable();
                Session["tblLogging"] = tblLogging;
            }

            string spName = "";
            int ParamCount = 0;
            MySqlCommand cmd1 = null;
            switch (dest)
            {
                case DataDestination.RouteMaster:
                    spName = "InsertRouteMaster";
                    ParamCount = 8;
                
                    cmd1 = new MySqlCommand("delete from newver_routeprogramming_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'");
                    cmd1.Connection = con;
                    cmd1.ExecuteScalar();
                    break;
                case DataDestination.ConductorMaster:
                    spName = "InsertConductorMaster";
                    ParamCount = 9;
                    cmd1 = new MySqlCommand("delete from newver_conductordetails_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'");
                    cmd1.Connection = con;
                    cmd1.ExecuteScalar();
                    break;
                case DataDestination.AgentMaster:
                    spName = "InsertAgentMaster";
                    ParamCount = 8;
                    cmd1 = new MySqlCommand("delete from agents_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'");
                    cmd1.Connection = con;
                    cmd1.ExecuteScalar();
                    break;
                case DataDestination.DriverMaster:
                    spName = "InsertDriverMaster";
                    ParamCount = 2;
                    cmd1 = new MySqlCommand("delete from newver_drivernames_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'");
                    cmd1.Connection = con;
                    cmd1.ExecuteScalar();
                    break;
                case DataDestination.StageMaster:
                    spName = "InsertStageMaster";
                    // ParamCount = 13;
                    ParamCount = 11;
                    cmd1 = new MySqlCommand("delete from newver_rpstagedetails_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'");
                    cmd1.Connection = con;
                    cmd1.ExecuteScalar();
                    break;
                case DataDestination.InspectorMaster:
                    spName = "InsertInspectorMaster";
                    ParamCount = 3;
                    cmd1 = new MySqlCommand("delete from inspector_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'");
                    cmd1.Connection = con;
                    cmd1.ExecuteScalar();
                    break;
                default:
                    return;
            }
            using (MySqlCommand cmd = new MySqlCommand(spName))
            {


                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;
                string ReadCSV = File.ReadAllText(dataFileName);
                int cnt=0;
                foreach (string csvRow in ReadCSV.Split('\n'))
                
                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                     
                        string[]newRow = new string[4];
                        newRow[0] = (cnt + 1).ToString();
                        newRow[1] = csvRow;
                        newRow[1] = newRow[1].Replace("\r", string.Empty);
                        newRow[2] = "";
                        newRow[3] = "";
                        string[] valueSet = csvRow.Split(',');

                        //  Validation
                        if (ParamCount != valueSet.Length)
                        {
                            newRow[2] = "ERR";
                            newRow[3] = "No. or expected parameters do not match. Row Rejected.";
                            tblLogging.Rows.Add(newRow);
                            continue;
                        }
                   
                        tblLogging.Rows.Add(newRow);
                        insertIntoTempTable(cmd, tblLogging, cnt, valueSet, dest);
                        cnt++;
                    }
                }
            }
            GridView_logging.DataSource = tblLogging;
            GridView_logging.DataBind();
        }

         


        private void insertIntoTempTable(MySqlCommand cmd , DataTable tblLogging, int rowCount, string[] parameters, DataDestination dest)
        {
            try
            {
               
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ClientID", Session["ClientID"].ToString());
               
                for (int i = 1; i <= parameters.Length; i++)
                {
                    parameters[i - 1] = parameters[i - 1].Replace("\r", string.Empty);//uday 061219
                    cmd.Parameters.AddWithValue("@param" + i.ToString(), parameters[i-1]);//uday "@param" + i
                }
                
                cmd.ExecuteNonQuery();
                tblLogging.Rows[rowCount][2] = "OK";
                tblLogging.Rows[rowCount][3] = "-";
            }
            catch (Exception ex)
            {
                tblLogging.Rows[rowCount][2] = "ERR";
                tblLogging.Rows[rowCount][3] = ex.Message;
                            
            }
        }

        private void BindGrid(DataDestination GridType, MySqlConnection con)
        {
            InvisibleAllGrids();
            switch (GridType)
            {
                case DataDestination.RouteMaster:
                    panel_route.Visible = true;
                    BindTo_RouteGrid(con);
                    break;
                case DataDestination.ConductorMaster: 
                    panel_conductor.Visible = true;
                    BindTo_CounductorGrid(con);
                    break;
                case DataDestination.AgentMaster: 
                    panel_Agent.Visible = true;                    
                    BindTo_AgentGrid(con);
                    break;
                case DataDestination.DriverMaster: 
                    panel_driver.Visible = true;
                    BindTo_DriverGrid(con);
                    break;
                //case "Vehicle Master":
                //    panel_vehicle.Visible = true;
                //    BindTo_VehicleGrid();
                //    break;
                case DataDestination.StageMaster: 
                    panel_stage.Visible = true;
                    BindTo_StageGrid(con);
                    //BindTo_StageGridTest();
                    break;
                case DataDestination.InspectorMaster: 
                    panel_inspector.Visible = true;
                    BindTo_InspectorGrid(con);
                    break;
                default: break;
            }
        }

        private void BindTo_RouteGrid(MySqlConnection con)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_routeprogramming_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            
            {

                cmd.Connection = con;
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Route.DataSource = dt;
                        GridView_Route.DataBind();
                        if (dt.Rows.Count == 0) PromoteButton.Visible = false;//uday
                    }
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_routeprogramming WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Route_owned.DataSource = dt;
                        GridView_Route_owned.DataBind();
                    }
                }
            }
        }

        private void BindTo_CounductorGrid(MySqlConnection con)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_conductordetails_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                cmd.Connection = con;
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Counductor.Caption = "";
                        GridView_Counductor.DataSource = dt;
                        GridView_Counductor.DataBind();
                        if (dt.Rows.Count == 0) PromoteButton.Visible = false;//uday
                    }
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_conductordetails WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Counductor_owned.DataSource = dt;
                        GridView_Counductor_owned.DataBind();
                    }
                }
            }
        }
        //Uday new to table view
        protected void  UpdateTableView()
        {
            GridView_logging.Caption = "";
            DataDestination dest = getDestinationFromString(DropDownList_master.SelectedItem.ToString());
            int ParamCount = 0;
            switch (dest)
            {
                case DataDestination.RouteMaster:
                    ParamCount = 8;
                    break;
                case DataDestination.ConductorMaster:
                    ParamCount = 9;
                    break;
                case DataDestination.AgentMaster:
                    ParamCount = 8;
                    break;
                case DataDestination.DriverMaster:
                    ParamCount = 2;
                    break;
                case DataDestination.StageMaster:
                    ParamCount = 11;
                    break;
                case DataDestination.InspectorMaster:
                    ParamCount = 3;
                    break;
                default:
                    return;
            }
            try
            {
                DataTable tblLogging = (DataTable)Session["tblLogging"];
                if (null == tblLogging)
                {
                    tblLogging = new DataTable();
                    Session["tblLogging"] = tblLogging;
                }

                string[] FileName = lblFile.Text.ToString().Split(':');

                string ReadCSV = File.ReadAllText(Server.MapPath("~/upload/") + FileName[1]);
                int cnt = 0;
                foreach (string csvRow in ReadCSV.Split('\n'))

                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        string[] newRow = new string[4];
                        newRow[0] = (cnt + 1).ToString();
                        newRow[1] = csvRow;
                        newRow[2] = "";
                        newRow[3] = "";
                        string[] valueSet = csvRow.Split(',');
                        //  Validation
                        if (ParamCount != valueSet.Length)
                        {
                            newRow[2] = "ERR";
                            newRow[3] = "No. or expected parameters do not match. Row Rejected.";
                            tblLogging.Rows.Add(newRow);
                            continue;
                        }
                        else
                        {
                            newRow[2] = "OK";
                            newRow[3] = "-";
                        }
                        tblLogging.Rows.Add(newRow);
                        cnt++;
                    }
                }
                GridView_logging.DataSource = tblLogging;
                GridView_logging.DataBind();
            }
            catch (Exception ex)
            {
                GridView_logging.Caption = ex.Message;
            }

        }

        //following theme is copied from recent tickets paging Uday
        //required for page changing
        protected void GridView_logging_PageIndexChanged(object sender, EventArgs e)
        {
            UpdateTableView();
        }
        protected void GridView_logging_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_logging.PageIndex = e.NewPageIndex;
            GridView_logging.EditIndex = -1;
        }



        protected void GridView_Counductor_owned_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_CounductorGrid(con);
            }


        }
        protected void GridView_Counductor_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_CounductorGrid(con);
            }


        }

        protected void GridView_Counductor_owned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Counductor_owned.PageIndex = e.NewPageIndex;

            GridView_Counductor_owned.EditIndex = -1;
        }
        protected void GridView_Counductor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Counductor.PageIndex = e.NewPageIndex;

            GridView_Counductor.EditIndex = -1;
        }

        //now for agent
        protected void GridView_Agent_owned_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_AgentGrid(con);
            }


        }
        protected void GridView_Agent_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_AgentGrid(con);
            }


        }
        protected void GridView_Agent_owned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            GridView_Agent_owned.PageIndex = e.NewPageIndex;
            GridView_Agent_owned.EditIndex = -1;
        }
        protected void GridView_Agent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView_Agent.PageIndex = e.NewPageIndex;
            GridView_Agent.EditIndex = -1;
        }

        //now for driver
        protected void GridView_Driver_owned_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_DriverGrid(con);
            }


        }
        protected void GridView_Driver_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_DriverGrid(con);
            }


        }
        protected void GridView_Driver_owned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Driver_owned.PageIndex = e.NewPageIndex;
            GridView_Driver_owned.EditIndex = -1;
        }
        protected void GridView_Driver_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Driver.PageIndex = e.NewPageIndex;
            GridView_Driver.EditIndex = -1;
        }

        //For inspecotr
        protected void GridView_inspector_owned_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_InspectorGrid(con);
            }


        }
        protected void GridView_inspector_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_InspectorGrid(con);
            }


        }
        protected void GridView_inspector_owned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_inspector_owned.PageIndex = e.NewPageIndex;
            GridView_inspector_owned.EditIndex = -1;
        }
        protected void GridView_inspector_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_inspector.PageIndex = e.NewPageIndex;
            GridView_inspector.EditIndex = -1;
        }
        // for routes
        protected void GridView_Route_owned_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_RouteGrid(con);
            }


        }
        protected void GridView_Route_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_RouteGrid(con);
            }


        }
        protected void GridView_Route_owned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Route_owned.PageIndex = e.NewPageIndex;
            GridView_Route_owned.EditIndex = -1;
        }
        protected void GridView_Route_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Route.PageIndex = e.NewPageIndex;
            GridView_Route.EditIndex = -1;
        }
        //for stage view
        protected void GridView_stage_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_StageGrid(con);
                //BindTo_StageGridTest();
            }


        }
        protected void GridView_stage_owned_PageIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                BindTo_StageGrid(con);
                //BindTo_StageGridTest();
            }


        }
        protected void GridView_stage_owned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_stage_owned.PageIndex = e.NewPageIndex;
            GridView_stage_owned.EditIndex = -1;
        }
        protected void GridView_stage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_stage.PageIndex = e.NewPageIndex;
            GridView_stage.EditIndex = -1;
        }
        //end of added code uday
        private void BindTo_AgentGrid(MySqlConnection con)
        {
          

            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM agents_Temp WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                cmd.Connection = con;
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Agent.DataSource = dt;
                        GridView_Agent.DataBind();
                        if (dt.Rows.Count == 0) PromoteButton.Visible = false;//uday
                    }
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM agents WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Agent_owned.DataSource = dt;
                        GridView_Agent_owned.DataBind();
                    }
                }
            }

        }

        private void BindTo_DriverGrid(MySqlConnection con)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_drivernames_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                cmd.Connection = con;
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Driver.DataSource = dt;
                        GridView_Driver.DataBind();
                        if (dt.Rows.Count == 0) PromoteButton.Visible = false;//uday
                    }
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_drivernames WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_Driver_owned.DataSource = dt;
                        GridView_Driver_owned.DataBind();
                    }
                }
            }
        }

        private void BindTo_StageGridTest()
        {
            //testing
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                //using (var cmd = new MySqlCommand("GetWayBillMaster"))
                using (var cmd = new MySqlCommand("LOAD DATA INFILE 'c:/wamp64/tmp/STAGEMSTR_201219.csv' INTO TABLE automate_automateds.newver_rpstagedetails_test FIELDS TERMINATED BY ','; "))
                //using (var cmd = new MySqlCommand("SELECT nwb.id,nwb.cd_condrdetails_code as 'wbp_waybillno',nwb.status as 'status',nwb.cd_date as 'ModifiedTS', nwb.cd_deponame as 'WBCloserRemar' From newver_conductordetails nwb where nwb.ClientID='AUTOMATE' LIMIT 100; "))
                // using (MySqlCommand cmd = new MySqlCommand("SearchTicketView"))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        //cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            //test ends
        }

        private void BindTo_StageGrid(MySqlConnection con)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_rpstagedetails_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                cmd.Connection = con;
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_stage.DataSource = dt;
                        GridView_stage.DataBind();
                        if (dt.Rows.Count == 0) PromoteButton.Visible = false;//uday
                    }
                }
            }
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM newver_rpstagedetails   WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_stage_owned.DataSource = dt;
                        GridView_stage_owned.DataBind();
                    }
                }
            }
        }

            private void BindTo_InspectorGrid(MySqlConnection con)
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM inspector_temp WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
                {
                    cmd.Connection = con;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView_inspector.DataSource = dt;
                            GridView_inspector.DataBind();
                            if (dt.Rows.Count == 0) PromoteButton.Visible = false;//uday
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM inspector  WHERE ClientID='" + Session["ClientID"].ToString() + "'"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView_inspector_owned.DataSource = dt;
                            GridView_inspector_owned.DataBind();
                        }
                    }
                }
            }
        //private void BindTo_VehicleGrid()
        //{ }

        private void InvisibleAllGrids()
        {
            panel_route.Visible = false;
            panel_conductor.Visible = false;
            panel_Agent.Visible = false;
            panel_driver.Visible = false;
            panel_vehicle.Visible = false;
            panel_stage.Visible = false;
            panel_inspector.Visible = false;
            //GridView_logging.Visible = false;
            Panel_MasterDescription.Visible = false;
        }


        protected void ResetButton_Click(object sender, EventArgs e)
        {

            FileUploadControl.Visible = false;
            UploadButton.Visible = false;
            PromoteButton.Visible = false;
            ResetButton.Visible = false;
            DropDownList_master.SelectedIndex = 0;
            GridView_logging.Visible = false;
            Panel_MasterDescription.Visible = false;
            InvisibleAllGrids();
            lblFile.Text = "";
            DropDownList_master.Enabled = true;//uday
        }

        protected void PromoteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    PromoteData(con,getDestinationFromString(DropDownList_master.SelectedItem.ToString()));
                    BindGrid(getDestinationFromString(DropDownList_master.SelectedItem.ToString()), con);
                    PromoteButton.Visible = false;
                  
                    lblFile.Visible = true;
                    
                }
            }
            catch (Exception ex)
            {
                GridView_Counductor.Caption = "Failed:" + ex.Message;
            }
        }

        private void PromoteData(MySqlConnection con, DataDestination GridType)
        {
            MySqlCommand cmd1 = null;
            try
            {
                switch (GridType)
                {
                    case DataDestination.RouteMaster:
                        cmd1 = new MySqlCommand("InsertRouteMasterData");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 600;
                        cmd1.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd1.Connection = con;
                        cmd1.ExecuteScalar();
                        break;
                    case DataDestination.ConductorMaster:
                        cmd1 = new MySqlCommand("InsertConductorMasterData");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 600;
                        cmd1.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        //cmd1.Parameters.AddWithValue("@count", 0);
                        cmd1.Connection = con;
                        cmd1.ExecuteScalar();
                        //if(cmd1.Parameters.)
                        //if(cmd1.LastInsertedId== 0) //not inserted bec it is duplicate
                        //if (cmd1.Parameters.)
                        // {
                        //    GridView_logging.Caption = "Duplicate Record/s";
                        //}
                        break;
                    case DataDestination.AgentMaster:
                        cmd1 = new MySqlCommand("InsertAgentMasterData");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 600;
                        cmd1.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd1.Connection = con;
                        cmd1.ExecuteScalar();
                        break;
                    case DataDestination.DriverMaster:
                        cmd1 = new MySqlCommand("InsertDriverMasterData");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 600;
                        cmd1.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd1.Connection = con;
                        cmd1.ExecuteScalar();
                        break;
                    //case "Vehicle Master":
                    //    break;
                    case DataDestination.StageMaster:
                        cmd1 = new MySqlCommand("InsertStageMasterData");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 600;
                        cmd1.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd1.Connection = con;
                        cmd1.ExecuteScalar();
                        break;
                    case DataDestination.InspectorMaster:
                         cmd1 = new MySqlCommand("InsertInspectorMasterData");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 600;
                        cmd1.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd1.Connection = con;
                        cmd1.ExecuteScalar();
                        break;
                }
            }
            catch (Exception ex)
            {
                GridView_Counductor.Caption = "Failed:" + ex.Message;
            }
        }

        private void PopulateDescription(DataDestination GridType)
        {
            switch (GridType)
            {
                case DataDestination.RouteMaster:
                    desc_NumOfVols.Text = "Total Columns Requirement : 7";
                    desc_MasterDesc.Text = "Columns Details : [ 1 : Route Number  number],[2 :Route Type  String Max 200],[3 : Bus Type String Max 50],[4 : Triangle Number number],[5 : Start Stage string],[6 : End Stage string],[7 :  Total Stops number], Exmple:-22,2,1,1,SAGAR,UDUPI,67,";
                    //desc_MasterDesc.Text = "Columns Details : [ 1 :rp_routeno  number],[2 :Route Type  String Max 200],[3 : Bus Type String Max 50],[4 : Triangle Number number],[5 : Start Stage string],[6 : End Stage string],[7 :  Total Stops number],[8 : Stage Marathi Name string],[9: Fare Charge number];

                    //,rp_routetype,rp_bustype,rp_triangleno,rp_startstg,rp_endstg,rp_noofstops,rp_stgmarathiname
                    break;
                case DataDestination.ConductorMaster:
                      desc_NumOfVols.Text = "Total Columns Requirement : 9";
                      desc_MasterDesc.Text = "Columns Details : [ 1 : Conductor Code number],[2 : Conductor Details String Max 50],[3 : Vehicle Number String Max 50],[4 :  Division Name String],[5 : Division Code String],[6 : Depo name  String],[7 : Depo Code String],[8 : Date date 'yyyy-dd-mm'],[9 :  ETM No number]";
                    break;
                case DataDestination.AgentMaster:
                    desc_NumOfVols.Text = "Total Columns Requirement : 7";
                    desc_MasterDesc.Text = "Columns Details : [ 1 : Agent Code String Max 50],[2 : Agent Name String Max 200],[3 : Password String Max 25],[4 : AtStage String Max 20],[5 : CardIssued String 50],[6 : IssuedBy String Max 20],[7 : IssuedDateString Date 'yyyy-dd-mm'] Example:- 802,H NAGARAJA SHENO,,,1,0,,";
                    break;
                case DataDestination.DriverMaster:
                       desc_NumOfVols.Text = "Total Columns Requirement :2";
                    desc_MasterDesc.Text = "Columns Details : [ 1 : Driver code String Max 200 ],[2 : name String Max 200] Example:- 00000793,CHANDRA";
                    break;
                 case DataDestination.StageMaster:
                       desc_NumOfVols.Text = "Total Columns Requirement :10";
                    desc_MasterDesc.Text = "Columns Details : [ 1 :Stage Route Number],[2 : Bus Type String Max 200],[3 : Triangle String Max 25],[4 : Stage code String Max 20],[5 : Stage namee  String Max 20],[6 : Stage name String Max 20],[7 :KM  String Max 20],[8 : rpsd stgno  String Max 20],[9 : sd sub String Max 50],[10 : rpsd intrsstg  String Max 50] Example:- 51,1,15,HAL,HALESORABHA,,0,22,0,,20";
                    break;
                case DataDestination.InspectorMaster:
                       desc_NumOfVols.Text = "Total Columns Requirement :3";
                    desc_MasterDesc.Text = "Columns Details : [ 1 : Code String Max 200 ],[2 : Name String Max 200],[3 : Password String Max 25] Example:-01,0143,1231";
                    break;

            }
        }

        protected void GridView_Counductor_owned_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
