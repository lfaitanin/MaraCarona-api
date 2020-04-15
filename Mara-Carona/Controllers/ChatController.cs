using Mara_Carona.Interfaces.BLL;
using Mara_Carona.Models.Hub;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatBLL _chatBL;

        public ChatController(IChatBLL chatBL)
        {
            _chatBL = chatBL;
        }

        // GET: api/Users
        [Route("GetMessages/{userFromId}/{userToId}")]
        [HttpGet]
        public IActionResult GetMessages(int userFromId, int userToId)
        {
            return Ok(_chatBL.GetMessages(userFromId, userToId));
        }

    }
}
