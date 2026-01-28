using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercitazioneQuestionario.web.Models.User
{
    public class UserCreationModel
    {
        [Required(ErrorMessage = "Il Nome è obbligatorio.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Il Cognome è obbligatorio.")]
        [RegularExpression("^([A-Za-z\\- ]+)$", ErrorMessage = "Il nome può contenere lettere, spazi e trattini.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lo username è obbligatorio.")]
        [RegularExpression("^([A-Za-z\\- ]+)$", ErrorMessage = "Il cognome può contenere lettere, spazi e trattini.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Il Password è obbligatorio.")]
        public string Password { get; set; }
    }
}