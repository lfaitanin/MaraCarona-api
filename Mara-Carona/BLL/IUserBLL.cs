using Mara_Carona.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mara_Carona.BLL
{
     public interface IUserBLL 
     {
        void createUser(User user);
        Task<ActionResult<IEnumerable<User>>> Getusers();
        Task<ActionResult<User>> GetUser(int id);
        Task<ActionResult<UserType>> GetTypeUser(User id);
        Task<ActionResult<Club>> GetClub(User id);
        Fixture GetNextGame(User user);
        bool UserExists(int id);
     }
}
