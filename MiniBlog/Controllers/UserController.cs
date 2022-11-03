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
            return Ok(_userService.UpdateUser(user));
        }

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            _userService.DeleteUser(name);
            return NoContent();
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(_userService.GetUserByName(name));
        }
    }
}