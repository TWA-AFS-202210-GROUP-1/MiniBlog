using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            User newUser = _userService.Register(user);

            return Created($"/user/{newUser.Name}", user);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(this._userService.GetAll());
        }

        [HttpPut]
        public ActionResult Update(User user)
        {
            return Ok(_userService.Update(user));
        }

        [HttpDelete]
        public ActionResult Delete(string name)
        {
            _userService.Delete(name);
            return NoContent();
        }

        [HttpGet("{name}")]
        public ActionResult GetByName(string name)
        {
            return Ok(_userService.GetByName(name));
        }
    }
}