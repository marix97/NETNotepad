using Microsoft.EntityFrameworkCore;
using NETNotepad.Entities;
using NETNotepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Data
{
    public class NotepadContext : DbContext
    {
        public NotepadContext(DbContextOptions<NotepadContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
