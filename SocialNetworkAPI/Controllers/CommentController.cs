using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// We don't use status code 500 becose we are in local/memory

namespace SocialNetworkAPI.Controllers
{
    [Route("socialNetwork/api/v1/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
    }
}