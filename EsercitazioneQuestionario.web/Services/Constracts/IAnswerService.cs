using EsercitazioneQuestionario.web.Models.Question;
using System.Threading.Tasks;

namespace EsercitazioneQuestionario.web.Services
{
    public interface IAnswerService
    {
        Task AddAnswer(int UserId, FormViewModel form);
    }
}