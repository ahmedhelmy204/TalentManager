using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TalentManager.Models;

namespace TalentManager.Controllers
{
    [Authorize(Roles = "HumanResourceTeamMember")]
    public class EmployeesController : ApiController
    {
        public Employee Get(int id)
        {
            return new Employee() { Id = id, Name = "John Q Law", Department = "Enforcement" };
        }

        public IEnumerable<Employee> Get()
        {
            return new Employee[]{
                new Employee(){ Id=12345, Name="John Q Law", Department="Enforcement" },
                new Employee(){ Id=45678, Name="Jane Q Taxpayer", Department="Revenue" }
            };
        }

        public Employee Post(Employee human)
        {
            // Add employee to the system
            human.Id = 12345; // Id produced as a result of adding the employee to data store
            return human;
        }

        [Authorize(Roles = "ManagementTeamMember")]
        public void Delete(int id)
        {
            // Delete employee from the system
        }

        public void Put(Employee employee)
        {
            // Update employee in the system
        }

        public IEnumerable<Employee> Get(string department)
        {
            if (!String.Equals(department, "HR", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Bad Department");

            return new List<Employee>()
            {
                new Employee(){Id=12345,Name="John Q Human"}
            };
        }


    }
}
