using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Domain.Interfaces
{
    public interface IUserService : IBaseService<User, UserModel, UserRepository>
    {
        UserModel GetUser(string username, string password);
        Task RegisterUserAsync(UserModel model);
        UserModel GetUserByName(string username);
    }
}
