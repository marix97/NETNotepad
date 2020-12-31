using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.DomainModels
{
    public class UserModel : BaseModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<NoteModel> Notes { get; set; }
    }
}
