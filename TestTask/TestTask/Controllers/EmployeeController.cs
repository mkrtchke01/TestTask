using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestTask.Repositories.Contracts;
using TestTask.Requests;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetById/{id}")]
        [SwaggerOperation(Summary = "Get employee by id")]
        [SwaggerResponse(200, "Success result")]
        [SwaggerResponse(404, "Employee is not found")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add employee")]
        [SwaggerResponse(200, "Adding is success")]
        [SwaggerResponse(400, "Adding is failed")]
        public async Task<IActionResult> Add([FromBody]AddEmployeeRequest employee)
        {
            if(employee == null)
            {
                return BadRequest();
            }
            await _repository.AddAsync(employee);
            return Ok();
        }
        [HttpPost("Update/{id}")]
        [SwaggerOperation(Summary = "Update employee")]
        [SwaggerResponse(200, "Updating is success")]
        [SwaggerResponse(400, "Updating is failed")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest employee, int id)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(employee, id);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation(Summary = "Delete employee")]
        [SwaggerResponse(200, "Delete is success")]
        [SwaggerResponse(404, "Employee is not found")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(employee);
            return Ok();
        }
    }
}
