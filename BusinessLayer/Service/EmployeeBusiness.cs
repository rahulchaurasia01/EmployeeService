/*
 *  Purpose: Business Layer for the Interaction between the Main Program
 *  and Repository Layer
 * 
 *  Author: Rahul Chaurasia
 *  Date: 9/1/2020
 */

using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using CommonLayer.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace BusinessLayer.Service
{
    public class EmployeeBusiness : IEmployeeBusiness
    {

        public IEmployeeRepository employeeRepository;

        public EmployeeBusiness(IEmployeeRepository IEmployeeRepository)
        {
            employeeRepository = IEmployeeRepository;
        }

        /// <summary>
        /// It Convert the FirstName, LastName and gender to PascalCase
        /// and send the data to the Repository Layer.
        /// </summary>
        /// <param name="employee">It Contains the Newly created employee Data</param>
        public int Add([FromBody]Employee employee)
        {
            char temp;
            temp = employee.FirstName[0];
            employee.FirstName = temp.ToString().ToUpper() + employee.FirstName.Substring(1);
            temp = employee.LastName[0];
            employee.LastName = temp.ToString().ToUpper() + employee.LastName.Substring(1);
            temp = employee.Gender[0];
            employee.Gender = temp.ToString().ToUpper() + employee.Gender.Substring(1);
            return employeeRepository.Add(employee);
        }

        public int Delete(int id)
        {
            return employeeRepository.Delete(id);
        }

        public List<Employee> Get()
        {
            return employeeRepository.Get();
        }

        public Employee Get(int id)
        {
            return employeeRepository.Get(id);
        }

        /// <summary>
        /// It Convert the FirstName, LastName and gender to PascalCase
        /// and send the data to the Repository Layer.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <param name="employee">Employee Data to Update</param>
        /// <returns>If the Updation is Successfull, it Return non-zero value</returns>
        public int Put(int id, [FromBody]Employee employee)
        {
            char temp;
            temp = employee.FirstName[0];
            employee.FirstName = temp.ToString().ToUpper() + employee.FirstName.Substring(1);
            temp = employee.LastName[0];
            employee.LastName = temp.ToString().ToUpper() + employee.LastName.Substring(1);
            temp = employee.Gender[0];
            employee.Gender = temp.ToString().ToUpper() + employee.Gender.Substring(1);
            return employeeRepository.Put(id, employee);
        }
    }
}
