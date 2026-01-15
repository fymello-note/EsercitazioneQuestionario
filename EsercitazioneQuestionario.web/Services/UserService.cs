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
    public class UserService : IUserService
    {
        public async Task<FormViewModel> GetFlag(int UserId)
        {
            using (var db = new EsercitazioneDbContext())
            {
                return await db.User.Select(u => new FormViewModel
                {
                    FlagForm = u.Flag_Form,
                    UserId = u.UserId
                }).FirstOrDefaultAsync(u => u.UserId == UserId);
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
    }
}