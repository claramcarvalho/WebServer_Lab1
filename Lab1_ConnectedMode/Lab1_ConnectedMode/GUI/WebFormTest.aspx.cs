using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient; //just for testing
using Lab1_ConnectedMode.DAL; //just for testing
using Lab1_ConnectedMode.BLL;

namespace Lab1_ConnectedMode.GUI
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConnectDB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            MessageBox.Show("Database connection is " + conn.State.ToString());
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(6666,"Mary","Brown","Programmer Analyst");
            emp.SaveEmployee(emp);
            MessageBox.Show("Employee saved!");
        }

        protected void ButtonListAll_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            GridViewEmployees.DataSource = employee.GetAllEmployees();
            GridViewEmployees.DataBind();
        }
    }
}