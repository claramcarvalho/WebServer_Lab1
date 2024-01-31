using Lab1_ConnectedMode.BLL;
using Lab1_ConnectedMode.VALIDATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

//State Management in ASP.Net
// HTTP : Stateless
    // Client Side State Management
        // ViewState

    // Server Side State Management
        // 1) Using database
        // Session State
        // Application State

namespace Lab1_ConnectedMode.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //every time you click on a button, the page loads :  multiple lists
            //--> ONE SOLUTION
            //DropDownSearchMethods.Items.Clear();
            //--> OTHER SOLUTION
            if (!Page.IsPostBack)
            {
                DropDownSearchMethods.Items.Add("Employee ID");
                DropDownSearchMethods.Items.Add("First Name");
                DropDownSearchMethods.Items.Add("Last Name");
                DropDownSearchMethods.Items.Add("First & Last Name");
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            LabelSearch.Text = DropDownSearchMethods.Text + ": ";
            LabelLastName.Visible = false;
            TextBoxLastName.Visible = false;
            GridViewEmployees.HeaderStyle.BackColor = System.Drawing.Color.LightGray;

        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            GridViewEmployees.DataSource = employee.GetAllEmployees();
            GridViewEmployees.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string input = "";
            Employee emp = new Employee();

            switch (DropDownSearchMethods.SelectedIndex)
            { //Auto postback = true
                case 0:
                    input = TextBoxSearch.Text.Trim();
                    int size = 4;
                    if (!Validator.IsValidID(input,size))
                    {
                        MessageBox.Show("Employee ID must be a "+ size +"-digit number","Invalid Employee ID",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        TextBoxSearch.Text = "";
                        TextBoxSearch.Focus();
                        return;
                    }

                    emp = emp.SearchEmployee(Convert.ToInt32(input));
                    if (emp != null)
                    {
                        GridViewEmployees.DataSource = new List<Employee> { emp };
                    } else
                    {
                        GridViewEmployees.DataSource = new List<String> { "Employee NOT FOUND" };
                    }
                    GridViewEmployees.DataBind();
                    break;
                case 1:
                case 2:
                    input = TextBoxSearch.Text.Trim();
                    if (!Validator.IsValidName(input))
                    {
                        MessageBox.Show("Name is invalid", "Invalid Employee Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxSearch.Text = "";
                        TextBoxSearch.Focus();
                        return;
                    }

                    List<Employee> list = emp.SearchEmployee(input);
                    if (list.Count != 0)
                    {
                        GridViewEmployees.DataSource = list;
                    }
                    else
                    {
                        GridViewEmployees.DataSource = new List<String> { "No employee was found" };
                    }
                    GridViewEmployees.DataBind();
                    break;
                case 3:
                    input = TextBoxSearch.Text.Trim();
                    string inputL = TextBoxLastName.Text.Trim();
                    if (!Validator.IsValidName(input) || !Validator.IsValidName(inputL))
                    {
                        MessageBox.Show("Name is invalid", "Invalid Employee Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxSearch.Text = "";
                        TextBoxLastName.Text = "";
                        TextBoxSearch.Focus();
                        return;
                    }

                    List<Employee> list2 = emp.SearchEmployee(input,inputL);
                    if (list2.Count != 0)
                    {
                        GridViewEmployees.DataSource = list2;
                    }
                    else
                    {
                        GridViewEmployees.DataSource = new List<String> { "No employee was found" };
                    }
                    GridViewEmployees.DataBind();
                    break;
                default:
                    break;
            }
        }

        protected void DropDownSearchMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownSearchMethods.SelectedIndex)
            { //Auto postback = true
                case 0:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Employee ID ";
                    }
                    LabelLastName.Visible = false;
                    TextBoxLastName.Visible = false;
                    LabelSearch.Text = Session["message"].ToString();
                    TextBoxSearch.Focus();
                    break;
                case 1:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "First Name ";
                    }
                    LabelLastName.Visible = false;
                    TextBoxLastName.Visible = false;
                    LabelSearch.Text = Session["message"].ToString();
                    TextBoxSearch.Focus();
                    break;
                case 2:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Last Name ";
                    }
                    LabelLastName.Visible = false;
                    TextBoxLastName.Visible = false;
                    LabelSearch.Text = Session["message"].ToString();
                    TextBoxSearch.Focus();
                    //LabelSearch.Text = "LAST NAME: ";
                    //TextBoxSearch.Focus();
                    break;
                case 3:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "First and Last Name ";
                    }
                    //LabelSearch.Text = Session["message"].ToString();
                    LabelLastName.Visible = true;
                    TextBoxLastName.Visible = true;
                    LabelSearch.Text = "First Name: ";
                    LabelLastName.Text = "Last Name: ";
                    TextBoxSearch.Focus();
                    break;
                default:
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validator.IsValidID(TextBoxEmpID.Text.Trim(),4))
            {
                MessageBox.Show("The ID must be a "+4+"-digit number");
            } else
            {
                if ( !(Validator.IsValidName(TextBoxFName.Text.Trim())) || 
                     !(Validator.IsValidName(TextBoxLName.Text.Trim())) || 
                     !(Validator.IsValidName(TextBoxJobTitle.Text.Trim())))
                {
                    MessageBox.Show("You must enter valid strings for First Name, Last Name and Job Title");
                } else
                {
                    Employee newEmpToSave = new Employee();
                    newEmpToSave.EmployeeID = Convert.ToInt32(TextBoxEmpID.Text.Trim());
                    newEmpToSave.FirstName = TextBoxFName.Text.Trim();
                    newEmpToSave.LastName = TextBoxLName.Text.Trim();
                    newEmpToSave.JobTitle = TextBoxJobTitle.Text.Trim();

                    newEmpToSave.SaveEmployee(newEmpToSave);
                    MessageBox.Show("The employee was successfully saved!");
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(Validator.IsValidName(TextBoxFName.Text.Trim())) ||
                     !(Validator.IsValidName(TextBoxLName.Text.Trim())) ||
                     !(Validator.IsValidName(TextBoxJobTitle.Text.Trim())))
            {
                MessageBox.Show("You must enter valid strings for First Name, Last Name and Job Title");
            }
            else
            {
                Employee empToUpdate = new Employee();
                empToUpdate.EmployeeID = Convert.ToInt32(TextBoxEmpID.Text.Trim());
                empToUpdate.FirstName = TextBoxFName.Text.Trim();
                empToUpdate.LastName = TextBoxLName.Text.Trim();
                empToUpdate.JobTitle = TextBoxJobTitle.Text.Trim();

                empToUpdate.UpdateEmployee(empToUpdate);
                MessageBox.Show("The employee was successfully updated!");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Employee empToDelete = new Employee();
            empToDelete.EmployeeID = Convert.ToInt32(TextBoxEmpID.Text.Trim());
            empToDelete.FirstName = TextBoxFName.Text.Trim();

            switch (MessageBox.Show("You will delete the following employee:" +
                        "\nID: " + empToDelete.EmployeeID +
                        "\nFirst Name: " + empToDelete.FirstName, "Confirm DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    empToDelete.DeleteEmployee(empToDelete);
                    MessageBox.Show("The employee was successfully deleted!");
                    ClearAllTextFields();
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
            }
        }

        protected void TextBoxEmpID_TextChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Employee emp = new Employee();

                string input = TextBoxEmpID.Text.Trim();
                int size = 4;
                if (!Validator.IsValidID(input, size))
                {
                    MessageBox.Show("Employee ID must be a " + size + "-digit number", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearAllTextFields();
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                    TextBoxEmpID.Focus();
                    return;
                }

                emp = emp.SearchEmployee(Convert.ToInt32(input));
                if (emp != null)
                {
                    TextBoxFName.Text = emp.FirstName;
                    TextBoxLName.Text = emp.LastName;
                    TextBoxJobTitle.Text = emp.JobTitle;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    TextBoxFName.Text = "";
                    TextBoxFName.Focus();
                    TextBoxLName.Text = "";
                    TextBoxJobTitle.Text = "";
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false; 
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                TextBoxFName.Text = "";
                TextBoxLName.Text = "";
                TextBoxJobTitle.Text = "";
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        public void ClearAllTextFields ()
        {
            TextBoxEmpID.Text = "";
            TextBoxFName.Text = "";
            TextBoxLName.Text = "";
            TextBoxJobTitle.Text = "";
        }
    }
}