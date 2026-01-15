using EsercitazioneQuestionario.web.Models.Question;
using EsercitazioneQuestionario.web.Services;
using EsercitazioneQuestionario.web.Services.Constracts;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EsercitazioneQuestionario.web.Controllers
{
    public class FormController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IUserService _userService;

        public FormController()
        {
            _questionService = new QuestionService();
            _answerService = new AnswerService();
            _userService = new UserService();
        }

        // GET: Form
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            FormViewModel form = await _userService.GetFlag(1);
            form.Questions = await _questionService.GetQuestions(1);

            return View(form);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                await _answerService.AddAnswer(1, form);
                return RedirectToAction("Index", "Home");
            }
            return View(form);
        }
    }
}