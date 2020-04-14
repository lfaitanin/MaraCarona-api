using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mara_Carona.Context;
using Mara_Carona.Models;
using Microsoft.AspNetCore.Cors;
using Mara_Carona.Data;
using Mara_Carona.BLL;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IHubContext _hubContext;

        public HubController(IHubContext hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody]Message msg)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.All.Send(msg.nick, msg.message);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}
