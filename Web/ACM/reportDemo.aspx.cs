using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;

namespace Web.ACM
{
    public partial class reportDemo : System.Web.UI.Page
    {
        CallEntities DB = new CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Databind();
            }
        }

        protected void Databind()
        {
            var list = DB.TBLPRODUCTs.Where(p => p.TenantID == 6 && p.UOM==20);

            ListView1.DataSource = list;
            ListView1.DataBind();

            ListView2.DataSource = list;
            ListView2.DataBind();
        }
    }
}