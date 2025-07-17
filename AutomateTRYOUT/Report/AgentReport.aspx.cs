using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutomateTRYOUT.Report
{
    public partial class AgentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as Site1).CheckSessionVar();
            (this.Master as Site1).SetActiveMenu("menu_master");

        }
    }
}