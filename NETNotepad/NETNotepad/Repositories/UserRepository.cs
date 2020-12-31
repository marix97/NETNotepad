using AutoMapper;
using NETNotepad.Data;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Repositories
{
    public class UserRepository : BaseRepository<User, UserModel>, IUserRepository
    {
        public UserRepository(NotepadContext context, IMapper mapper) : base(context, mapper) { }

        public UserModel GetUserByNameAndPassword(string username, string password)
        {
            var user =  _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            return _mapper.Map<UserModel>(user);
        }

        public UserModel GetUserByName(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            return _mapper.Map<UserModel>(user);
        }
    }
}
