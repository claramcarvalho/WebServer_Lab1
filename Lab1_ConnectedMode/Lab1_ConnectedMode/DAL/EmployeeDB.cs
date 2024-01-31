using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1_ConnectedMode.BLL;
using Lab1_ConnectedMode.DAL;
using System.Data.SqlClient;

namespace Lab1_ConnectedMode.DAL
{
    public static class EmployeeDB
    {
        //1. A method to save an employee record to the database

        /// <summary>
        /// This method receives an employee and saves this new record to the database
        /// </summary>
        /// Version 1: Working, but has problem: SQL injection (not good, must encapsulate)
        /// Version 2: Using Parametrized Query
        /// <param name="emp"></param>
        public static void SaveRecord(Employee emp)
        {
            //1.Connect to DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //2.Perform INSERT operation
            //a-create and customize an object of type SqlCommand
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;

            /*
             * INSERT INTO Employees
	                VALUES (3333,'Mary','Ford','Programmer');
             */

            //VERSION 1:
            //cmdInsert.CommandText = "INSERT INTO Employees " +
            //                            "VALUES (" + 
            //                                emp.EmployeeID + "," +
            //                                "'" + emp.FirstName + "'," +
            //                                "'" + emp.LastName + "'," +
            //                                "'" + emp.JobTitle + "');";

            //VERSION 2:
            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeID, FirstName, LastName, JobTitle)" +
                                        "VALUES (@EmployeeID, @FirstName, @LastName, @JobTitle);";

            cmdInsert.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);

            cmdInsert.ExecuteNonQuery();

            //3.Close DB connection
            conn.Close();
        }    
        
        public static List<Employee> GetAllRecords()
        {
            List<Employee> listToReturn = new List<Employee>();
            
            //1.Connect to DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //2.Perform SELECT statement --> create and customize an object of type SqlCommand
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees",conn);

            SqlDataReader reader = cmdSelect.ExecuteReader();  // this method execute the query and saves on the object reader
            Employee emp;

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                emp.FirstName = Convert.ToString(reader["FirstName"]);
                emp.LastName = Convert.ToString(reader["LastName"]);
                emp.JobTitle = Convert.ToString(reader["JobTitle"]);
                listToReturn.Add(emp);
            }

            //3.Close DB connection
            conn.Close();
            return listToReturn;
        }

        //Search Operation
        ////Search Employee by EmployeeID   --> IF FOUND : 1 record
        ////Search Employee by First Name   --> IF FOUND : 1 or MORE
        
        //Polymorphism : Method Overloaded
        //// If two methods have the same name but different signature (in terms of type and number of parameters)
        //// they are called OVERLOADED METHODS
        //// (run time polymorphism : overriding method ---> different than overloaded )
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>

        public static Employee SearchRecord (int ID)
        {
            Employee employee = new Employee();

            //1.Connect to DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //2.Perform SELECT statement --> create and customize an object of type SqlCommand
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees " +
                "WHERE EmployeeID = @EmployeeID", conn);
            cmdSelect.Parameters.AddWithValue("@EmployeeID", ID);

            SqlDataReader reader = cmdSelect.ExecuteReader();  // this method execute the query and saves on the object reader
            
            // SqlDataReader provides a way of reading a forward-only stream
            //of rows from a SQL Server Database

            if (reader.Read()) {
                //found
                employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                employee.FirstName = Convert.ToString(reader["FirstName"]);
                employee.LastName = Convert.ToString(reader["LastName"]);
                employee.JobTitle = Convert.ToString(reader["JobTitle"]);
            } else {
                //not found
                employee = null;
            }
            
            //3.Close DB connection
            conn.Close();
            return employee;
        }

        public static List<Employee> SearchRecord(string input)
        {
            List<Employee> listToReturn = new List<Employee>();

            //1.Connect to DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //2.Perform SELECT statement --> create and customize an object of type SqlCommand
            SqlCommand cmdSearchByName = new SqlCommand("SELECT * FROM Employees " +
                "WHERE FirstName = @FirstName OR " +
                "LastName = @LastName", conn);

            cmdSearchByName.Parameters.AddWithValue("@FirstName", input);
            cmdSearchByName.Parameters.AddWithValue("@LastName", input);

            SqlDataReader reader = cmdSearchByName.ExecuteReader();  // this method execute the query and saves on the object reader
            Employee emp;

            while (reader.Read())
            {
                emp = new Employee();

                emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                emp.FirstName = Convert.ToString(reader["FirstName"]);
                emp.LastName = Convert.ToString(reader["LastName"]);
                emp.JobTitle = Convert.ToString(reader["JobTitle"]);
                listToReturn.Add(emp);
            }

            //3.Close DB connection
            conn.Close();
            return listToReturn;
        }

        public static List<Employee> SearchRecord(string input1, string input2)
        {
            List<Employee> listToReturn = new List<Employee>();

            //1.Connect to DB
            SqlConnection conn = UtilityDB.GetDBConnection();

            //2.Perform SELECT statement --> create and customize an object of type SqlCommand
            SqlCommand cmdSearchByName = new SqlCommand("SELECT * FROM Employees " +
                "WHERE FirstName = @FirstName AND " +
                "LastName = @LastName", conn);
            cmdSearchByName.Parameters.AddWithValue("@FirstName", input1);
            cmdSearchByName.Parameters.AddWithValue("@LastName", input2);

            SqlDataReader reader = cmdSearchByName.ExecuteReader();  // this method execute the query and saves on the object reader
            Employee emp;

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                emp.FirstName = Convert.ToString(reader["FirstName"]);
                emp.LastName = Convert.ToString(reader["LastName"]);
                emp.JobTitle = Convert.ToString(reader["JobTitle"]);
                listToReturn.Add(emp);
            }

            //3.Close DB connection
            conn.Close();
            return listToReturn;
        }

        public static void UpdateRecord (Employee empToUpdate)
        {
            // UPDATE Employees SET JobTitle = 'Java Programmer' WHERE EmployeeID = 1111
            // use the code from save record

            SqlConnection conn = UtilityDB.GetDBConnection();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;

            cmdInsert.CommandText = "UPDATE    Employees " +
                                        "SET   FirstName = @FirstName, " +
                                               "LastName = @LastName, " +
                                               "JobTitle = @JobTitle " +
                                        "WHERE EmployeeID = @EmployeeID;";

            cmdInsert.Parameters.AddWithValue("@EmployeeID", empToUpdate.EmployeeID);
            cmdInsert.Parameters.AddWithValue("@FirstName", empToUpdate.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", empToUpdate.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", empToUpdate.JobTitle);

            cmdInsert.ExecuteNonQuery();

            conn.Close();
        }

        public static void DeleteRecord (Employee empToDelete)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;

            cmdInsert.CommandText = "DELETE FROM Employees " +
                                        "WHERE EmployeeID = @EmployeeID;";

            cmdInsert.Parameters.AddWithValue("@EmployeeID", empToDelete.EmployeeID);

            cmdInsert.ExecuteNonQuery();

            conn.Close();
        }
    }
}