using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserRepository repo;

        public UsersController(LibraryContext context)
        {
            repo = new UserRepository(context);
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (user.Username == null || user.Password == null)
            {
                return BadRequest();
            }

            repo.Add(user);
            user.Password = "";
            return Accepted(user);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {
            if (user.Username == null || user.Password == null)
                return BadRequest();

            if (CheckUser(user.Username, user.Password))
            {
                var userFull = repo.GetById(user.Username);
                userFull.Password = "";
                return Ok(userFull);
            }

            return Unauthorized();
        }

        private bool CheckUser(string username, string password)
        {
            var user = repo.GetUserByCredentials(username, password);
            return user != null ? true : false;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = repo.GetAll();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = repo.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, [FromBody] User user)
        {
            if (id != user.Username)
            {
                return BadRequest();
            }

            repo.Update(user);

            if (repo.GetById(id) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var user = repo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return NoContent();
        }
    }
}
