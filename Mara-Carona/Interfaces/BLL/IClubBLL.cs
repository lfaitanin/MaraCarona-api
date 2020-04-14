using Mara_Carona.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
    public interface IClubBLL
    {
        IEnumerable<Club> GetClub();
    }
}
