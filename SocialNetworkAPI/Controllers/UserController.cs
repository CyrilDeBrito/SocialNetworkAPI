using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Stores;

namespace SocialNetworkAPI.Controllers
{
    // Link for postman:  socialNetwork/api/v1/user
    [Route("socialNetwork/api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserStore userStore;

        public UserController(IUserStore userStore)
        {
            this.userStore = userStore;
        }

        // Link for postman [GET]:  socialNetwork/api/v1/user
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public User[] GetUsers()
        {
            return userStore.Store.ToArray();
        }

        // Link for postman [GET]:  socialNetwork/api/v1/{id_of_user}
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

        // Link for postman [POST]:  socialNetwork/api/v1/user
        // Exemple of postman Json : Templates\JSON\post_user
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<User> AddUser(User user)
        {
            user.Id = userStore.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { user.Id }, user);
        }

        // Link for postman [DELETE]:  socialNetwork/api/v1/{id_of_user}
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<User> DeleteUser(int id)
        {
            // Get the user
            var user = userStore.Store.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            // Remove from the Store
            userStore.Store.Remove(user);
            return new OkResult();
        }

        // Link for postman [PUT]:  socialNetwork/api/v1/{id_of_user}
        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<User> UpdateUser(int id, User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            // Get the user
            var existingUser = userStore.Store.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            // Remove the user
            userStore.Store.Remove(existingUser);
            // Re-create the user
            userStore.Store.Add(user);
            return new OkResult();
        }
    }
}