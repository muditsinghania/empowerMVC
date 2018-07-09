using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Empower.Mvc.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter you name")]
        [MaxLength(200,ErrorMessage = "Name cannot Exceed 200 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter you Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email")]
        [MaxLength(500, ErrorMessage = "Name cannot Exceed 500 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter you Message")]
        [MaxLength(1000, ErrorMessage = "Name cannot Exceed 1000 characters")]
        public string Message { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool HasErrored =>  !string.IsNullOrEmpty(ErrorMessage);
        public string ErrorMessage { get; set; }
    }
}
