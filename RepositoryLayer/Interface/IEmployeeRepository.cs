/*
 *  Purpose: InterFace for the Repository Layer
 * 
 *  Author: Rahul Chaurasia
 *  Date: 9/1/2020
 */

using CommonLayer.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace RepositoryLayer.Interface
{
    interface IEmployeeRepository
    {

        List<Employee> Get();

        Employee Get(int id);

        int Add([FromBody]Employee employee);

        int Put(int id, [FromBody]Employee employee);

        int Delete(int id);


    }
}
