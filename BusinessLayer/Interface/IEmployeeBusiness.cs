/*
 *  Purpose: Interface for the Business Layer
 * 
 *  Author: Rahul Chaurasia
 *  Date: 9/1/2020
 */

using CommonLayer.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBusiness
    {

        List<Employee> Get();

        Employee Get(int id);

        int Add([FromBody]Employee employee);

        int Put(int id, [FromBody]Employee employee);

        int Delete(int id);

    }
}
