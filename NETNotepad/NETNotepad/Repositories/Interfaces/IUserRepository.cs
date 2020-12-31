using NETNotepad.DomainModels;
using NETNotepad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, UserModel>
    {
        UserModel GetUserByNameAndPassword(string username, string password);
        UserModel GetUserByName(string username);
    }
}
