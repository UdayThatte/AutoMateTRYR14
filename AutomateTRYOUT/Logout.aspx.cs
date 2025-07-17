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
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            //if (!this.IsPostBack && (Request.Cookies["username"] == null || Request.Cookies["username"].Value == ""))
            {
                Request.Cookies["UserSettings"]["username"] = null;
                Request.Cookies["UserSettings"]["Password"] = null;
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Request.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Request.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);

                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                AddCookie();
                //Response.Redirect("~/Login.aspx"); 
                //Response.Write("Session.SessionID=" + Session.SessionID + "");
                //Response.Write("Cookie ASP.NET_SessionId=" + Request.Cookies["ASP.NET_SessionId"].Value + "");
            }
        }

        private void AddCookie()
        {
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "TestCookie", DateTime.Now, DateTime.Now.AddSeconds(5), false,"");
            //string encryptedText = Login.Encrypt(ticket);
            //string encryptedText = FormsAuthentication.Encrypt(ticket);
            //Response.Cookies.Add(new HttpCookie("TESTLOGIN", encryptedText));

            //Response.Cookies.Add(new HttpCookie("TESTLOGIN", "this is test"));
            Response.Cookies.Add(new HttpCookie("UserSettings", string.Empty));
        }

    }
}