using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxSurveyAPI.Factory;
using TaxSurveyAPI.Models;

namespace TaxSurveyAPI.Controllers
{
    public class QuestionerController : ApiController
    {
        QuestionerFactory questionerFactory;
        public QuestionerController()
        {
            questionerFactory = new QuestionerFactory();
        }
        // GET api/Questioner
        public IEnumerable<Question> Get()
        {
            return questionerFactory.GetQuestioner();
        }
    }
}
