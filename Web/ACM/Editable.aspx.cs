using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;

namespace Web.ACM
{
    public partial class Editable : System.Web.UI.Page
    {
        CallEntities DB = new CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Database.ACM_Editable obj_edit = new Database.ACM_Editable();
            obj_edit.UserName = "";
         
          

            DB.ACM_Editable.AddObject(obj_edit);
            DB.SaveChanges();
        }
       
       
    }
}