using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsercitazioneQuestionario.web.Models.Question
{
    public class FormViewModel
    {
        public int UserId { get; set; }
        public bool FlagForm { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}