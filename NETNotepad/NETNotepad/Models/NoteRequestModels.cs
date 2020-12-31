using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace NETNotepad.Models
{
    public class CreateNote
    {
        [Required]
        [Display(Name = "Title")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Text")]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        public string Text { get; set; }
    }

    public class EditNote
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Text")]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        public string Text { get; set; }
    }
}
