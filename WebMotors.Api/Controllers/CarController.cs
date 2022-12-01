using Microsoft.AspNetCore.Mvc;
using WebMotors.Application.Models.Car;
using WebMotors.Application.Services.Car;

namespace WebMotors.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarRequestModel param)
        {
            var result = await _carService.Create(param);

            if (result is null)
                return BadRequest();

            Response.Headers.Add("Location", $"{Request.Path}/{result.Id}");
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarResponseModel>>> GetAll()
        {
            var result = await _carService.GetAll();

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarResponseModel>> GetById(int id)
        {
            var result = await _carService.GetById(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarRequestModel param)
        {
            var result = await _carService.Update(id, param);

            return result ? Ok() : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carService.Delete(id);

            return result ? Ok() : NotFound();
        }
    }
}
