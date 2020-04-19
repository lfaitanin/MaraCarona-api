using Mara_Carona.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.Interfaces.BLL
{
    public interface IMatchBLL
    {
        Task<ActionResult<Match>> getMatchRiders(int matchId, int typeId);
        void createMatchRider(Match match);
    }
}
