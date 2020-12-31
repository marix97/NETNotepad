using NETNotepad.Domain.Interfaces;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories;
using NETNotepad.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Domain
{
    public class UserService : BaseService<User, UserModel, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository) { }

        public UserModel GetUser(string username, string password)
        {
            return _repository.GetUserByNameAndPassword(username, password);
        }

        public UserModel GetUserByName(string username)
        {
            return _repository.GetUserByName(username);
        }

        public async Task RegisterUserAsync(UserModel model)
        {
             await _repository.CreateAsync(model);
        }
    }
}
