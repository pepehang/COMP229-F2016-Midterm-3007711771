using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229_F2016_Midterm_3007711771
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
            if (!IsPostBack)
            {
                // check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // show the contoso content area
                    ContosoPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                }
                else
                {
                    // only show login and register
                    ContosoPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }
            }
        }

        /**
        * This method adds a css class of "active" to list items
        * relating to the current page
        * 
        * @private
        * @method SetActivePage
        * @return {void}
        */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Todo List":
                    todo.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}