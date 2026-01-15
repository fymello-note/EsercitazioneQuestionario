using EsercitazioneQuestionario.web.Models.Question;
using EsercitazioneQuestionario.web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EsercitazioneQuestionario.web.Services.Constracts
{
    internal interface IUserService
    {
        Task SetCompile(int UserId);

        Task<FormViewModel> GetFlag(int UserId);

        Task<bool> CheckUserPassword(UserLoginModel user);

        Task<int> Pippo(string username);
    }
}