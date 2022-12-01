using Microsoft.AspNetCore.Mvc;
using WebMotors.Application.Models.User;
using WebMotors.Application.Services.User;

namespace WebMotors.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequestModel param)
        {
            var result = await _userService.Create(param);

            if (result is null)
                return BadRequest();

            Response.Headers.Add("Location", $"{Request.Path}/{result.Id}");
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetAll()
        {
            var result = await _userService.GetAll();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseModel>> GetById(int id)
        {
            var result = await _userService.GetById(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserRequestModel param)
        {
            var result = await _userService.Update(id, param);

            return result ? Ok() : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);

            return result ? Ok() : NotFound();
        }
    }
}
