using AutoMapper;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<NoteModel, Note>();
            CreateMap<Note, NoteModel>();

            CreateMap<UserLoginModel, UserModel>();
            CreateMap<UserModel, UserLoginModel>();

            CreateMap<UserRegisterModel, UserModel>();
            CreateMap<UserModel, UserRegisterModel>();

            CreateMap<NoteModel, NoteResponseModel>();

            CreateMap<EditNote, NoteModel>();
        }
    }
}
