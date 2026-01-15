using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsercitazioneQuestionario.web.Models.Question
{
    public class FormViewModel
    {
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}