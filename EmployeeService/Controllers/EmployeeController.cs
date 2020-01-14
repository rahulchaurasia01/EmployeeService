/*
 *  Purpose: Api for the Employee Service to retrieve the Data from the Database.
 * 
 *  Author: Rahul Chaurasia
 *  Date: 9/1/2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using CommonLayer.Model;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        public IEmployeeBusiness employeeBusiness;

        public EmployeeController(IEmployeeBusiness IEmployeeBusiness)
        {
            employeeBusiness = IEmployeeBusiness;
        }

        /// <summary>
        /// It Return the List of Employee Data if Present
        /// </summary>
        /// <returns>List Of Employee with Http Response</returns>
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            try
            {
                List<Employee> employees = employeeBusiness.Get();
                if (employees.Count == 0)
                {
                    return NotFound(new { Message = "No Data Present" });
                }
                return Ok(employees.ToList());
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        /// <summary>
        /// It Return the Specfic Employee Data from the Database.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Employee Data</returns>
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                Employee employee = employeeBusiness.Get(id);
                if (employee == null)
                {
                    return NotFound(new { Message = "No Employee Data Present with id: " +id });
                }
                return Ok(employee);
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        /// <summary>
        /// It Create the New Employee Data in the Database.
        /// </summary>
        /// <param name="employee">Employee Data</param>
        /// <returns>If Created then Successfull</returns>
        [HttpPost]
        public IActionResult CreateEmployee([FromBody]Employee employee)
        {
            try
            {
                int count = employeeBusiness.Add(employee);
                if (count == 0)
                {
                    return Content(NoContent().ToString(), "Unable to Create Employee Data.");
                }
                else if(count == -1)
                {
                    throw new Exception();
                }
                return Ok(new { Message = "Employee Data Created" });
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        /// <summary>
        /// It Update The Employee data
        /// </summary>
        /// <param name="id"> Employee Id</param>
        /// <param name="employee">Employee Data to Update</param>
        /// <returns>It Return 200, If Successfull.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id,[FromBody]Employee employee)
        {
            try
            {
                int count = employeeBusiness.Put(id, employee);
                if(count == 0)
                {
                    return NotFound(new { Message = "No Employee Data Present with id: " + id });
                }
                else if (count == -1)
                {
                    throw new Exception();
                }
                return Ok(new { Message = "Employee data has Been Successfully Updated" });
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        /// <summary>
        /// It Delete the Specific Employee Data
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>It Return 200, If Successfull.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                int count = employeeBusiness.Delete(id);
                if (count == 0)
                {
                    return NotFound(new { Message = "No Employee to Delete with id: " + id });
                }
                else if(count == -1)
                {
                    throw new Exception();
                }
                return Ok(new { Message = "Employee data Deleted Successfully" });
            }
            catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }


    }
}