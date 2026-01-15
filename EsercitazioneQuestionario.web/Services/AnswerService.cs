using EsercitazioneQuestionario.web.Models.Database;
using EsercitazioneQuestionario.web.Models.Question;
using EsercitazioneQuestionario.web.Services.Constracts;
using System.Threading.Tasks;

namespace EsercitazioneQuestionario.web.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUserService user;

        public AnswerService()
        {
            user = new UserService();
        }

        public async Task AddAnswer(int UserId, FormViewModel form)
        {
            using (var db = new EsercitazioneDbContext())
            {
                foreach (QuestionViewModel question in form.Questions)
                {
                    db.Answer.Add(new Answer
                    {
                        UserId = UserId,
                        QuestionId = question.QuestionId,
                        AnswerValue = question.Answer.Value
                    });

                    await db.SaveChangesAsync();
                }
            }

            await user.SetCompile(UserId);
        }
    }
}