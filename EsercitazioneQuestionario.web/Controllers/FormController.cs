using EsercitazioneQuestionario.web.Models.Question;
using EsercitazioneQuestionario.web.Services;
using EsercitazioneQuestionario.web.Services.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EsercitazioneQuestionario.web.Controllers
{
    public class FormController : Controller
    {
        private readonly IQuestionService questionService;

        public FormController()
        {
            questionService = new QuestionService();
        }

        // GET: Form
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            FormViewModel form = new FormViewModel()
            {
                Questions = await questionService.GetQuestions()
            };

            return View(form);
        }

        [HttpPost]
        public async Task<ActionResult> Index(FormViewModel form)
        {
           return View(form);
        }
    }
}