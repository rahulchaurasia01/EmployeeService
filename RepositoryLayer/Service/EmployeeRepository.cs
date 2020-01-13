/*
 *  Purpose: This Class Interact with the Database to get the Data
 * 
 *  Author: Rahul Chaurasia
 *  Date: 9/1/2020
 */

using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace RepositoryLayer.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static string sqlConnection = "Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True";

        /// <summary>
        /// It Create the new Employee Data in Database.
        /// </summary>
        /// <param name="employee">Employee Data</param>
        public int Add([FromBody]Employee employee)
        {
            try
            {
                int count = 0;
                using (SqlConnection sqlConnect = new SqlConnection(sqlConnection))
                {
                    SqlCommand sqlCommand = new SqlCommand("spCreateEmployee", sqlConnect);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Specialization", employee.Specialization);
                    sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);

                    sqlConnect.Open();
                    count = sqlCommand.ExecuteNonQuery();

                    return count;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return -1;
            }
        }

        /// <summary>
        /// It Delete the Specific Employee from the database.
        /// </summary>
        /// <param name="id">Employee Id</param>
        public int Delete(int id)
        {
            try
            {
                int count = 0;
                using(SqlConnection sqlConnect = new SqlConnection(sqlConnection))
                {
                    SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeById", sqlConnect);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;


                    sqlCommand.Parameters.AddWithValue("@ID", id);
                    sqlConnect.Open();
                    count = sqlCommand.ExecuteNonQuery();

                    return count;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return -1;
            }
        }

        /// <summary>
        /// It Retrieve All the Employees Data From the database.
        /// </summary>
        /// <returns>List Of all the Employee</returns>
        public List<Employee> Get()
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection sqlConnect = new SqlConnection(sqlConnection))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetEmployees", sqlConnect);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnect.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(sqlDataReader[0]);
                        employee.FirstName = sqlDataReader[1].ToString();
                        employee.LastName = sqlDataReader[2].ToString();
                        employee.Gender = sqlDataReader[3].ToString();
                        employee.Specialization = sqlDataReader[4].ToString();
                        employee.Salary = Convert.ToInt32(sqlDataReader[5]);

                        employees.Add(employee);

                    }
                }

                return employees;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }

        }

        /// <summary>
        /// It Return the employee Details.
        /// </summary>
        /// <param name="id">employee Id</param>
        /// <returns>Employee Detail</returns>
        public Employee Get(int id)
        {
            try
            {
                Employee employee = null;

                using(SqlConnection sqlConnect = new SqlConnection(sqlConnection))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetEmployeeById", sqlConnect);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@ID", id);

                    sqlConnect.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        employee = new Employee();
                        employee.ID = Convert.ToInt32(sqlDataReader[0]);
                        employee.FirstName = sqlDataReader[1].ToString();
                        employee.LastName = sqlDataReader[2].ToString();
                        employee.Gender = sqlDataReader[3].ToString();
                        employee.Specialization = sqlDataReader[4].ToString();
                        employee.Salary = Convert.ToInt32(sqlDataReader[5]);
                    }
                }
                return employee;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
            
        }

        /// <summary>
        /// It is used to Update the Employee Details
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <param name="employee">Employee Data</param>
        public int Put(int id, [FromBody]Employee employee)
        {
            try
            {
                int count = 0;
                using (SqlConnection sqlConnect = new SqlConnection(sqlConnection))
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", sqlConnect);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;


                    sqlCommand.Parameters.AddWithValue("@ID", id);
                    sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Specialization", employee.Specialization);
                    sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);

                    sqlConnect.Open();
                    count = sqlCommand.ExecuteNonQuery();

                    return count;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return -1;
            }
        }
    
    }
}
