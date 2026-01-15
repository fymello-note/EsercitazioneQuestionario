using EsercitazioneQuestionario.web.Models.Database;
using EsercitazioneQuestionario.web.Models.Question;
using EsercitazioneQuestionario.web.Services.Constracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EsercitazioneQuestionario.web.Services
{
    public class QuestionService : IQuestionService
    {
        public async Task<List<QuestionViewModel>> GetQuestions(int userId)
        {
            using(var db = new EsercitazioneDbContext()){
                return await db.Question.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    Text = q.Text,
                    Answer = db.Answer.Where(ab => ab.UserId == userId &&  ab.QuestionId == q.QuestionId)
                                .Select(a => (bool?)a.AnswerValue).FirstOrDefault()
                }).ToListAsync();
            }
        }
    }
}