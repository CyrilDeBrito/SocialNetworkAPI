using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Stores;
using System.Linq;

namespace SocialNetworkAPI.Controllers
{
    [Route("socialNetwork/api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserStore userStore;

        public UserController(IUserStore userStore)
        {
            this.userStore = userStore;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public User[] GetUsers()
        {
            return userStore.Store.ToArray();
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser(int id)
        {
            var user = userStore.Store.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> AddUser(User user)
        {
            user.Id = userStore.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { user.Id }, user);
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void DeleteUser(int id)
        {
            // SEARCH a delete method or try a linq syntax method to delete a user
        }
    }
}