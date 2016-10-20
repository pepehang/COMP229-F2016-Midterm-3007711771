using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;//keep it anyway

namespace COMP229_F2016_Midterm_3007711771
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            // perferorm sign out
            authenticationManager.SignOut();

            // Redirect the user to the Login Page
            Response.Redirect("~/Login.aspx");
        }
    }
}