using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercitazioneQuestionario.web.Models.User
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "UserName Necessario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Necessaria")]
        public string Password { get; set; }
    }
}