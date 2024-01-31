using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ConnectedMode.BLL;
using Lab1_ConnectedMode.DAL;


//encapsulation:
//////// encapsulation is needed to protect data stored in the object
//////// prevent the data to be manipulated
//////// (capsule of medication)

namespace Lab1_ConnectedMode.BLL
{
    //instance class
    public class Employee
    {
        //class variables
        private int employeeID;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        
        //default constructor
        public Employee()
        {
            employeeID = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            jobTitle = string.Empty;
        }

        //parametrized constructor
        public Employee(int employeeID, string firstName, string lastName, string jobTitle)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
        }

        //custom methods
        //GetEmployeeID
        //SetEmployee
        public void SaveEmployee (Employee emp)
        {
            EmployeeDB.SaveRecord(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return EmployeeDB.GetAllRecords();
        }

        public Employee SearchEmployee(int employeeID)
        {
            return EmployeeDB.SearchRecord(employeeID);
        }

        public List<Employee> SearchEmployee(string employeeName) //first name or last name
        {
            return EmployeeDB.SearchRecord(employeeName);
        }

        public List<Employee> SearchEmployee(string firstName, string lastName) => EmployeeDB.SearchRecord(firstName,lastName);
        //first name AND last name

        public void UpdateEmployee(Employee emp) => EmployeeDB.UpdateRecord(emp);

        public void DeleteEmployee(Employee emp) => EmployeeDB.DeleteRecord(emp);
    }
}