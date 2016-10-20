using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP229_F2016_Midterm_3007711771.Models;
using System.Web.ModelBinding;
using System.Diagnostics;
using System.Linq.Dynamic;

namespace COMP229_F2016_Midterm_3007711771
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time
            // populate the  grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "TodoID"; // default sort column
                Session["SortDirection"] = "ASC";

                // Get the  data
                this.GetThing();
            }
        }
        private void GetThing()
        {
            //connect to db
            using (TodoContext db = new TodoContext())
            {
                string SortString = Session["SortColumn"].ToString() + " " +
                    Session["SortDirection"].ToString();

                var Thing = (from allThing in db.Todos
                             select allThing);

                ThingGridView.DataSource = Thing.AsQueryable().OrderBy(SortString).ToList();
                ThingGridView.DataBind();
            }
        }
        protected void ThingGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected TodoID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(ThingGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected  in the DB and remove it
            using (TodoContext db = new TodoContext())
            {
                // create object ot the  clas and store the query inside of it
                Todos deleted = (from Records in db.Todos
                                 where Records.TodoID == TodoID
                                 select Records).FirstOrDefault();

                // remove the selected  from the db
                db.Todos.Remove(deleted);

                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.GetThing();
            }


        }
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set the new Page size
            ThingGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the GridView
            this.GetThing();
        }
        protected void ThingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            // refresh the GridView
            this.GetThing();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        protected void ThingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < ThingGridView.Columns.Count - 1; index++)
                    {
                        if (ThingGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }
        protected void ThingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            ThingGridView.PageIndex = e.NewPageIndex;

            // refresh the Gridview
            this.GetThing();
        }
    }
}