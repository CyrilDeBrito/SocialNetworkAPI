using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Stores;

// We don't use status code 500 becose we are in local/memory

namespace SocialNetworkAPI.Controllers
{
    [Route("socialNetwork/api/v1/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentStore commentStore;

        public CommentController(ICommentStore commentStore)
        {
            this.commentStore = commentStore;
        }

        // Link for postman [GET]:  socialNetwork/api/v1/comment
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public Comment[] GetComments()
        {
            return commentStore.Store.ToArray();
        }

        // Link for postman [GET]:  socialNetwork/api/v1/{id_of_comment}
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = commentStore.Store.FirstOrDefault(u => u.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // Link for postman [POST]:  socialNetwork/api/v1/{name_of_comment}
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Comment> AddComment(Comment comment)
        {
            comment.Id = commentStore.AddComment(comment);
            return CreatedAtAction(nameof(GetComment), new { comment.Id }, comment);
        }

        // Link for postman [DELETE]:  socialNetwork/api/v1/{id_of_comment}
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Comment> DeleteComment(int id)
        {
            var comm = commentStore.Store.FirstOrDefault(u => u.Id == id);
            if (comm == null)
            {
                return BadRequest();
            }
            commentStore.Store.RemoveAt(comm.Id);
            return NoContent();
        }
    }
}