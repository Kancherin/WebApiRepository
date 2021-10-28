using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRepository.Api.Models;
using WebApiRepository.Api.Paging;
using WebApiRepository.Api.Repository;

namespace WebApiRepository.Api.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees([FromQuery] PagingParameters pagingParameters)
        {
            return await _employeeRepository.GetEmployees(pagingParameters);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
                return NotFound();
            else
                return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Empleado no existe.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo no válido.");
            }
            _employeeRepository.CreateEmployee(employee);
            return Ok(CreatedAtRoute("Id", new { id = employee.Id }, employee));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Empleado no existe.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo no válido.");
            }
            var emp = _employeeRepository.GetEmployee(id);
            if (!emp.Id.Equals(id)) 
            {
                return NotFound();
            }
            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);
            if (!emp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRepository.Delete(emp);
            return NoContent();
        }
    }
}
