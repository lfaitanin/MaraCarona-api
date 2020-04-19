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
        void updateUser(User user);
        Task<IEnumerable<User>> Getusers();
        Task<ActionResult<User>> GetUser(string token);
        Task<UserType> GetTypeUser(User user);
        Task<Club> GetClub(User user);
        object GetNextGame(User user);
        bool UserExists(int id);
        User GetUserByEmail(string email);
        User GetUserByToken(string token);
    }
}
