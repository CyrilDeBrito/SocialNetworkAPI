using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Stores;

namespace SocialNetworkAPI.Controllers
{
    // Link for postman:  socialNetwork/api/v1/Publicaion
    [Route("socialNetwork/api/v1/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private IPublicationStore publicationStore;

        public PublicationController(IPublicationStore publicationStore)
        {
            this.publicationStore = publicationStore;
        }

        // Link for postman [GET]:  socialNetwork/api/v1/publication
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public Publication[] GetPublications()
        {
            return publicationStore.Store.ToArray();
        }
        // Link for postman [GET]:  socialNetwork/api/v1/{id_of_publication}
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public ActionResult<Publication> GetPublication(int id)
        {
            var publication = publicationStore.Store.FirstOrDefault(p => p.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return publication;
        }

        // Link for postman [POST]:  socialNetwork/api/v1/{name_of_publication}
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Publication> AddPublication(Publication publication)
        {
            publication.Id = publicationStore.AddPublication(publication);
            return CreatedAtAction(nameof(GetPublication), new { publication.Id }, publication);
        }

        // Link for postman [DELETE]:  socialNetwork/api/v1/{id_of_publication}
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Publication> DeletePublication(Publication publication)
        {
        }
    }
}