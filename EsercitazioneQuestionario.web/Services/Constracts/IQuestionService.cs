using EsercitazioneQuestionario.web.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EsercitazioneQuestionario.web.Services.Constracts
{
    public interface IQuestionService
    {
        Task<List<QuestionViewModel>> GetQuestions();
    }
}