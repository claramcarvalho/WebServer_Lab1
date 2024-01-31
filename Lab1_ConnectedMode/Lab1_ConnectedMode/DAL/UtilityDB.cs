using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;  //required for SQL Server Database
                              // ADO.Net Object Model
using System.Configuration;
using System.Xml.Linq;

//How to write a method
//Q1: What is the purpose of your method?
//Q2: Does your method require formal parameters?
//YES => Specify it or them.
//For each parameter, type and passing method
//Pass by value, by ref, by out
//NO => ()
//Q3: Does your method return a value EXPLICITLY?
//Q4: Where do you use your method?

namespace Lab1_ConnectedMode.DAL
{
    public static class UtilityDB
    {
        /// <summary>
        /// This method returns an active database connection
        /// </summary>
        /// Version 1: WORKING, but NOT GOOD: expose the connection string
        /// Version 2: Encapsulated!
        /// <returns>Object of type SqlConnection</returns>
        
        //public static SqlConnection GetDBConnection()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    //where is database, which database, user that will use database

        //    conn.ConnectionString = "server=(local);database=EmployeeDB;user=sa;password=sysadm";
        //    conn.Open();

        //    return conn;
        //}

        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            //where is database, which database, user that will use database

            //Insert in Web.config:
                  //           ...... </ system.web >

                  //  < connectionStrings >
                  //      < add name = "DBEmployeeConnection" connectionString = "Data Source = (local); Initial Catalog = EmployeeDB; User ID = sa; Password = sysadm" />
                  //  </ connectionStrings >

                  //< system.codedom > ............

            //References -> Add References
            //ckeckbox System.Configuration  --> to be able to use the Web.config

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBEmployeeConnection"].ConnectionString;
            conn.Open();

            return conn;
        }
    }
}