using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            var registeredUser = _userService.RegisterUser(user);
            if (registeredUser == null)
            {
                return BadRequest();
            }

            return Created($"user/{registeredUser.Name}", registeredUser);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var foundUser = _userService.UpdateUser(user);
            if (foundUser ==null)
            {
                return NotFound();
            }

            return Ok(foundUser);
        }

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            if (_userService.DeleteUser(name))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var foundUser = _userService.GetUserByName(name);
            if (foundUser == null)
            {
                return NotFound();
            }

            return Ok(foundUser);
        }
    }
}