using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Microsoft.AspNetCore.Authorization;


namespace Project.Controllers
{
    [ApiController]
    [Route("api/emp")]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        // Simulate DB with static list
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = new Department { Id = 101, Name = "HR" },
                Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } }
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Salary = 60000,
                Permanent = false,
                DateOfBirth = new DateTime(1992, 2, 2),
                Department = new Department { Id = 102, Name = "Finance" },
                Skills = new List<Skill> { new Skill { Id = 2, Name = "Excel" } }
            }
        };

        // GET all employees
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        // POST: Add a new employee
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee newEmp)
        {
            newEmp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(newEmp);
            return Ok(newEmp);
        }

        // PUT: Update an employee
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            // Update the employee details
            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Permanent = updatedEmp.Permanent;
            emp.DateOfBirth = updatedEmp.DateOfBirth;
            emp.Department = updatedEmp.Department;
            emp.Skills = updatedEmp.Skills;

            return Ok(emp);
        }

        // DELETE: Delete an employee
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            employees.Remove(emp);
            return Ok($"Employee {id} deleted");
        }
    }
}
