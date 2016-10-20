using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP229_F2016_Midterm_3007711771.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_Midterm_3007711771
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetThing();
            }
        }
        protected void GetThing()
        {
            // populate the form with existing data from db
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoContext db = new TodoContext())
            {
                // populate a student object instance with the StudentID from 
                // the URL parameter
                Todos updated = (from student in db.Todos
                                 where student.TodoID == TodoID
                                 select student).FirstOrDefault();

                // map the student properties to the form control
                if (updated != null)
                {
                    LastNameTextBox.Text = updated.TodoID.ToString();
                    FirstNameTextBox.Text = updated.TodoDescirption;
                    EnrollmentDateTextBox.Text = updated.TodoNotes;
                }
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to the students page
            Response.Redirect("~/Contoso/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (TodoContext db = new TodoContext())
            {


                Todos newStudent = new Todos();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a STUDENTID in it
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current student from EF db
                    newStudent = (from student in db.Todos
                                  where student.TodoID == TodoID
                                  select student).FirstOrDefault();
                }

                // add form data to the new student record
                newStudent.TodoID = Convert.ToInt32(LastNameTextBox.Text);
                newStudent.TodoDescirption = FirstNameTextBox.Text;
                newStudent.TodoNotes = EnrollmentDateTextBox.Text;

                // use LINQ to ADO.NET to add / insert new student into the db

                if (TodoID == 0)
                {
                    db.Todos.Add(newStudent);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Contoso/TodoList.aspx");
            }
        }
    }
}
