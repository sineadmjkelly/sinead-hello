using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SineadK.Models
{
    public class ContactViewModel
    {
        private string _message;
        [Required]
        [MinLength (length: 5, ErrorMessage="Must be more than 5 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(length: 250, ErrorMessage = "Message is too long")]
        public string Message { get => _message; set => _message = value; }
    }
}
