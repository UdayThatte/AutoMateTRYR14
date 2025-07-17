using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //uday for excel

namespace AutomateTRYOUT.Forms
{
    public partial class AgentPerformance : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                (this.Master as Site1).CheckSessionVar();

                txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtToDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                panel_GridAgentPerformance.Visible = false;
                Button1.Enabled = false;
            }
           
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            panel_GridAgentPerformance.Visible = true;
            bindGridView();
            
            if (GridAgentPerformance.PageCount>0) Button1.Enabled = true ; //uday if no data is present

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            panel_GridAgentPerformance.Visible = false;
            bindGridView();
            Button1.Enabled = false;
        }

        private void bindGridView()
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("MyAgentPerformanceReport")) //uday 
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 500;
                        cmd.Parameters.AddWithValue("@ClientID_in", Session["ClientID"].ToString());
                        cmd.Parameters.AddWithValue("@FromDT_in",Convert.ToDateTime(txtFromDateTime.Text));
                        cmd.Parameters.AddWithValue("@ToDT_in", Convert.ToDateTime(txtToDateTime.Text));
                        cmd.Parameters.AddWithValue("@CommPerc_in", TextBoxCommissionPercentage.Text.ToString());

                        da.SelectCommand = cmd;
                        con.Close();
                        using (DataTable dt = new DataTable())
                            using(dt)
                        {
                            da.Fill(dt);
                            GridAgentPerformance.DataSource = dt;
                            GridAgentPerformance.DataBind();

                        }

                    }
                }
            }
        }

        protected void GridAgentPerformance_PageIndexChanged(object sender, EventArgs e)
        {
            bindGridView();
        }

        protected void GridAgentPerformance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridAgentPerformance.PageIndex = e.NewPageIndex;

            GridAgentPerformance.EditIndex = -1;

        }

        //uday below
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            string filename = "AgentCommission_" + txtFromDateTime.Text.ToString() + "_" + txtToDateTime.Text.ToString()+".XLS";
            Response.AddHeader("content-disposition", "attachment; filename = " + filename);
            Response.ContentType = "application/excel";
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.Charset = "";
            //this.EnableViewState = false;
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            GridAgentPerformance.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }
        ////uday
    }




}