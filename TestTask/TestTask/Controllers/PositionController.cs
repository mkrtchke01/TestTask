using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestTask.Repositories.Contracts;
using TestTask.Requests;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _repository;
        public PositionController(IPositionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetById/{id}")]
        [SwaggerOperation(Summary = "Get position by id")]
        [SwaggerResponse(200, "Success result")]
        [SwaggerResponse(404, "Position is not found")]
        public async Task<IActionResult> GetById(int id)
        {
            var position = await _repository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add position")]
        [SwaggerResponse(200, "Adding is success")]
        [SwaggerResponse(400, "Adding is failed")]
        public async Task<IActionResult> Add([FromBody]AddPositionRequest position)
        {
            if (position == null)
            {
                return BadRequest();
            }
            await _repository.AddAsync(position);
            return Ok();
        }
        [HttpPost("Update/{id}")]
        [SwaggerOperation(Summary = "Update position")]
        [SwaggerResponse(200, "Updating is success")]
        [SwaggerResponse(400, "Updating is failed")]
        public async Task<IActionResult> Update([FromBody] UpdatePositionRequest position, int id)
        {
            if (position == null)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(position, id);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation(Summary = "Delete position")]
        [SwaggerResponse(200, "Delete is success")]
        [SwaggerResponse(404, "Position is not found")]
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _repository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(position);
            return Ok();
        }
    }
}
