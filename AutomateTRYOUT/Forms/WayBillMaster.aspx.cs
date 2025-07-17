using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;


namespace AMDS.Forms
{
    public partial class WayBillMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // pnlWayBillMaster.Visible = false;
            //plnSearchWayBillMaster.Visible = true;

          //  txtFromDateTime.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy").Replace('-', '/');
           // txtToDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');

            bindGridView();

        }

        private void bindGridView()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectToMySQLDB"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(
                   " select * FROM newver_ticketdetails "))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);

                        //    gvWayBillMaster.DataSource = dt;
                        //    gvWayBillMaster.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           
        //    plnSearchWayBillMaster.Visible = true;
           // pnlWayBillMaster.Visible = true;

        }

        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
          
         //   plnSearchWayBillMaster.Visible = false;
           // pnlWayBillMaster.Visible = false;

        }
    }
}