using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPhyndLogin.Models
{
    public class LoginCred
    {
        [Required(ErrorMessage = "this field is required to continue")]

        public string Email { get; set; }
        [Required(ErrorMessage = "this field is required to continue")]

        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
