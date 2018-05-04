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
                decimal TimeWeightage = 0;
                decimal MoneyWeightage = 0;
                decimal OtherWeightage = 0;
                decimal OperationalWeightage = 0;
                decimal BurdenWeightage = 0;
                decimal CostPFWeightage = 0;
                decimal Psychological = 0;


                foreach (var question in questions)
                {
                    //totalWeightage = totalWeightage + question.TotalWeightage;
                    QuestionType type = QuestionType.text;
                    Enum.TryParse<QuestionType>(question.Type, out type);
                    switch (type)
                    {
                        case QuestionType.checkbox:
                            var questionOptions = question.Options.Where(o => o.IsSelected == true);
                            foreach (var item in questionOptions)
                            {
                                TimeWeightage += item.FactorWeightage.Time;
                                MoneyWeightage += item.FactorWeightage.Money;
                                OtherWeightage += item.FactorWeightage.Other;
                                OperationalWeightage += item.FactorWeightage.Operational;
                                BurdenWeightage += item.FactorWeightage.Burden;
                                CostPFWeightage += item.FactorWeightage.CostOfPF;
                                Psychological += item.FactorWeightage.Pshycological;
                            }
                            break;
                        case QuestionType.radio:
                            var questionOption = question.Options.First(o => o.Value == question.SelectedOption);
                            TimeWeightage += questionOption.FactorWeightage.Time;
                            MoneyWeightage += questionOption.FactorWeightage.Money;
                            OtherWeightage += questionOption.FactorWeightage.Other;
                            OperationalWeightage += questionOption.FactorWeightage.Operational;
                            BurdenWeightage += questionOption.FactorWeightage.Burden;
                            CostPFWeightage += questionOption.FactorWeightage.CostOfPF;
                            Psychological += questionOption.FactorWeightage.Pshycological;

                            break;
                        case QuestionType.text:
                            break;
                        default:
                            break;
                    }
                }


                TimeWeightage = TimeWeightage / questions.Count;
                MoneyWeightage = MoneyWeightage / questions.Count;
                OtherWeightage = OtherWeightage / questions.Count;
                OperationalWeightage = OperationalWeightage / questions.Count;
                BurdenWeightage = BurdenWeightage / questions.Count;
                CostPFWeightage = CostPFWeightage / questions.Count;
                Psychological = Psychological / questions.Count;

                var compliance = ((TimeWeightage + MoneyWeightage + OtherWeightage) / 3);
                var efficiency = ((OperationalWeightage + BurdenWeightage + CostPFWeightage) / 3);
                var psychological = Psychological;


                totalWeightage = ((compliance + efficiency + Psychological) / 3);

                var notMatFilingDone = questions.Any(q => q.QuestionId == 4) ? (questions.FirstOrDefault(q => q.QuestionId == 4).IsAnswered &&
                                    questions.FirstOrDefault(q => q.QuestionId == 4).SelectedOption == 2) : false;
                var matFilingComment = string.Empty;
                var homeRuledComment = string.Empty;
                var rdsRuledComment = string.Empty;
                var comments = new List<string>();
                if (notMatFilingDone)
                {
                    matFilingComment = "Albama state provides consolidated MAT filing instead of filing multiple forms, Please file your returns using MAT!!!";
                    comments.Add(matFilingComment);
                }
                var homeRuled = questions.FirstOrDefault(q => q.QuestionId == 9 && q.IsAnswered).Options.Where(o => (o.Value == 1 || o.Value == 2 || o.Value == 5) && o.IsSelected);

                var rdsRuled = questions.FirstOrDefault(q => q.QuestionId == 9 && q.IsAnswered).Options.Where(o => (o.Value == 3 || o.Value == 4) && o.IsSelected);
                if (homeRuled.Any())
                {
                    homeRuledComment = string.Format("For {0} you have to submit respective home ruled forms as well as state forms for tax filing", string.Join(", ", homeRuled.Select(o => o.Text).ToList()));
                    comments.Add(homeRuledComment);
                }
                if (rdsRuled.Any())
                {
                    rdsRuledComment = string.Format("For {0} you have to submit respective RDS forms as well as state forms for tax filing", string.Join(", ", rdsRuled.Select(o => o.Text).ToList()));
                    comments.Add(rdsRuledComment);
                }
                //decimal weightagePercent = Math.Round((selectedWeightage / totalWeightage) * 100, 2);
                var message = Request.CreateResponse(HttpStatusCode.OK, new
                {
                    comments = comments,
                    totalWeightage  = Math.Round(totalWeightage, 2),
                    barChart = new
                    {
                        Compliance = Math.Round(compliance,2),
                        Efficiency = Math.Round(efficiency, 2),
                        Psychological = Math.Round(Psychological, 2)
                    },
                    pieChart = new
                    {
                        Time = Math.Round(TimeWeightage, 2),
                        Money = Math.Round(MoneyWeightage, 2),
                        Other = Math.Round(OtherWeightage, 2),
                        Operational = Math.Round(OperationalWeightage, 2),
                        Burden = Math.Round(BurdenWeightage, 2),
                        CostOfPF = Math.Round(CostPFWeightage, 2)
                    }
                });
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
