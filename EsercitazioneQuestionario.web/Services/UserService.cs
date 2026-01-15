using EsercitazioneQuestionario.web.Models.Database;
using EsercitazioneQuestionario.web.Models.Question;
using EsercitazioneQuestionario.web.Models.User;
using EsercitazioneQuestionario.web.Services.Constracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EsercitazioneQuestionario.web.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> CheckUserPassword(UserLoginModel user)
        {
            using (var db = new EsercitazioneDbContext())
            {
                return await db.User.AnyAsync(u => u.UserName == user.Username && u.Password == user.Password);
            }
        }

        public async Task<FormViewModel> GetFlag(int UserId)
        {
            using (var db = new EsercitazioneDbContext())
            {
                return await db.User.Where(u => u.UserId == UserId).Select(u => new FormViewModel
                {
                    FlagForm = u.Flag_Form,
                    UserId = u.UserId
                }).FirstOrDefaultAsync();
            }
        }

        public async Task SetCompile(int UserId)
        {
            using(var db = new EsercitazioneDbContext()) {
                User user = await db.User.FirstOrDefaultAsync(u => u.UserId == UserId);

                if (user != null) {
                    user.Flag_Form = true;
                    user.CompileDate = DateTime.Now;

                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<int> Pippo(string username)
        {
            using(var db = new EsercitazioneDbContext())
            {
                return await db.User.Where(u => u.UserName == username).Select(u => u.UserId).FirstAsync();
            }
        }
    }
}