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
        // Exemple of postman Json : Templates\JSON\post_comment
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
        public ActionResult<Comment> DeleteComment(int id)
        {
            var comment = commentStore.Store.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            // Remove from the Store
            commentStore.Store.Remove(comment);
            return new OkResult();
        }

        // Link for postman [PUT]:  socialNetwork/api/v1/{id_of_comment}
        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public ActionResult<Comment> UpdateComment(int id, Comment comment)
        {
            if (comment == null || comment.Id != id)
            {
                return BadRequest();
            }

            // Get the comment
            var existingPublication = commentStore.Store.FirstOrDefault(p => p.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            // Remove the comment
            commentStore.Store.Remove(existingPublication);
            // Re-create the comment
            commentStore.Store.Add(comment);
            return new OkResult();
        }
    }
}