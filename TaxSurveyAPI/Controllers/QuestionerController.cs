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
        [HttpPost]
        public HttpResponseMessage Post([FromBody]List<Question> questions)
        {
            try
            {
                questions = questions.Where(q => q.IsAnswered == true).ToList();
                decimal totalWeightage = 0;
                decimal selectedWeightage = 0;
                foreach (var question in questions)
                {
                    totalWeightage = totalWeightage + question.TotalWeightage;
                    QuestionType type = QuestionType.text;
                    Enum.TryParse<QuestionType>(question.Type, out type);
                    switch (type)
                    {
                        case QuestionType.checkbox:
                            var questionOptions = question.Options.Where(o => o.IsSelected == true);
                            foreach (var item in questionOptions)
                            {
                                selectedWeightage = selectedWeightage + item.Weightage;
                            }
                            break;
                        case QuestionType.radio:
                            var questionOption = question.Options.First(o => o.Value == question.SelectedOption);
                            selectedWeightage = selectedWeightage + questionOption.Weightage;
                            break;
                        case QuestionType.text:
                            selectedWeightage = 10;
                            break;
                        default:
                            break;
                    }
                }
                decimal weightagePercent = Math.Round((selectedWeightage / totalWeightage) * 100, 2);
                var message = Request.CreateResponse(HttpStatusCode.OK, weightagePercent);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
