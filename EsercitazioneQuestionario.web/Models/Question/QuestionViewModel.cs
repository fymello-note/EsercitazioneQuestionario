using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsercitazioneQuestionario.web.Models.Question
{
    public class QuestionViewModel
    {
        public short QuestionId { get; set; }
        public string Text { get; set; }

        [Required(ErrorMessage = "La risposta è obbligatoria")]
        public bool? Answer { get; set; } = null;
    }
}