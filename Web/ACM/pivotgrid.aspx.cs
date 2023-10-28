using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxPivotGrid;

namespace Web.ACM
{
    public partial class pivotgrid : System.Web.UI.Page
    {
        Database.CallEntities DB = new Database.CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
           
           ASPxPivotGrid1.BeginUpdate();
           ASPxPivotGrid1.DataSource = DB.MODULE_MST;
          
           ASPxPivotGrid1.BeginUpdate();
        
           ASPxPivotGrid1.Fields["Year"].AllowedAreas = 0;
        }
    }
}