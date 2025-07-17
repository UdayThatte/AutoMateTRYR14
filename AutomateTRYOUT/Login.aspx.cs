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


namespace AutomateTRYOUT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // (this.Master as Site1).SetActiveMenu("menu_master");

                // txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy ").Replace('-', '/');
                //  txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd-MM-yy ").Replace('-', '-');
                //   txtToDateTime.Text = DateTime.Now.ToString("dd-MM-yy ").Replace('-', '-');
                ddlFillClientName();
                //ddlConductorFill();
                // ddlWayBillFill();
                // ddlMachineFill();
                // txtFromDateTime.Enabled = false;
                // txtToDateTime.Enabled = false;
                //  ddlTicketTypeFill();
                // ddlRouteFill();



            }
        }



        protected void LogAuthenticateUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //AAAManager am = new AAAManager();
            //if (true == Authenticate(LogAuthenticateUser.UserName, LogAuthenticateUser.Password))
            //{

            //    if (true == FirstTimeRun(LogAuthenticateUser.UserName))
            //    {
            //        Session["UserId"] = LogAuthenticateUser.UserName;

            //    }
            //    else
            //    {
            //        Session["UserId"] = LogAuthenticateUser.UserName;
            //        Session["FirstTimeLogin"] = 1;

            //    }
            //}
            //else
            //{

            //    string FailureText = (new PageResourceBinder()).getValue("Login", "AuthenticationFailureText");
            //    if (null != FailureText)
            //        LogAuthenticateUser.FailureText = FailureText;
            //}

        }


        private void ddlFillClientName()
        {
            DropDownList ddlClientID = LogAuthenticateUser.FindControl("ddlClientID") as DropDownList;
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

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            TextBox usernameTextBox = LogAuthenticateUser.FindControl("UserName") as TextBox;
            TextBox PasswordTextBox = LogAuthenticateUser.FindControl("Password") as TextBox;
            DropDownList ddlClientID = LogAuthenticateUser.FindControl("ddlClientID") as DropDownList;

            var UserName = usernameTextBox.Text;
            var Password = PasswordTextBox.Text;
            var ClientID = ddlClientID.SelectedValue;

            if (ddlClientID.SelectedValue == "Automate")
            {
                //UserName = "Admin";
                //Password = "Uday";
            }

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(

                    "AuthenticationUser"

                    ))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {

                        Response.Cookies["UserSettings"]["username"] = usernameTextBox.Text;
                        //Response.Cookies["UserSettings"]["Password"] = PasswordTextBox.Text;
                        Response.Cookies["UserSettings"]["ClientID"] = ddlClientID.SelectedValue;
                        Response.Cookies["UserSettings"]["RoleName"] = "";

                        cmd.Connection = con;
                        Session["username"] = usernameTextBox.Text;
                        Session["Password"] = PasswordTextBox.Text;
                        Session["ClientID"] = ddlClientID.SelectedValue;
                        Session["RoleName"] = "";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 600;
                        //  cmd.Parameters.AddWithValue("@ClientID_in", "HTCGAJ01");
                        cmd.Parameters.AddWithValue("@usernameTextBox_in", UserName);
                        cmd.Parameters.AddWithValue("@PasswordTextBox_in", Password);
                        cmd.Parameters.AddWithValue("@ClientID_in", ddlClientID.SelectedValue);

                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);

                            //GridView1.DataSource = dt;
                            //GridView1.DataBind();
                            if (dt.Rows.Count > 0)
                            {
                                Session["GroupID"] = dt.Rows[0]["GroupID"].ToString();
                                Session["ClientRole"] = dt.Rows[0]["ClientRole"].ToString();
                                Session["RoleName"] = dt.Rows[0]["RoleName"];
                                Response.Cookies["UserSettings"]["RoleName"] = dt.Rows[0]["RoleName"].ToString();
                                // Response.Redirect("~/index.aspx");
                                Response.Redirect("~/NewIndex.aspx");

                            }
                            else
                            {

                                Request.Cookies["UserSettings"]["username"] = null;
                                Request.Cookies["UserSettings"]["Password"] = null;
                                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                                Request.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                                Request.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
                                Session.Abandon();

                                Session["RoleName"] = "";
                                Session["username"] = "";
                                Session["Password"] = "";
                                Session["ClientID"] = "";
                                Session["GroupID"] = "";
                                Session["ClientRole"] = "";
                                Response.Redirect("~/Login.aspx");

                            }


                        }
                    }
                }



            }
        }
    }
}