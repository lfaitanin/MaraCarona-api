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
    public class ClubController : ControllerBase
    {
        private readonly IClubBLL _clubBLL;

        public ClubController(IClubBLL clubBLL)
        {
            _clubBLL = clubBLL;
        }
        // GET: api/Club
        [HttpGet]
        public IEnumerable<Club> Get()
        {
            return _clubBLL.GetClub();
        }
    }
}
