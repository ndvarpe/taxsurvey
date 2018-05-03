using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxSurveyAPI.Models;

namespace TaxSurveyAPI.Factory
{
    public class QuestionerFactory
    {
        public List<Question> GetQuestioner()
        {
            List<QuestionOption> questionOptions1 = new List<QuestionOption>
            {
                GetQuestionOptions("0 to 5", 1, false,5),
                GetQuestionOptions("5 to 15", 2, false,10),
                GetQuestionOptions("15 to 30", 3, false,15),
                GetQuestionOptions("30 to 50", 4, false,20)
            };
            List<QuestionOption> questionOptions2 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,10),
                GetQuestionOptions("No", 2, false,0)
            };

            List<Question> questionslist = new List<Question>
            {
                GetQuestion(1, "How many states are you obligated to collect sales tax in?", QuestionType.checkbox.ToString(), questionOptions1, GetTotalWeightage(QuestionType.checkbox,questionOptions1)),
                GetQuestion(2, "Do you collect sales tax in Home-Ruled State like Louisiana?", QuestionType.radio.ToString(), questionOptions2, GetTotalWeightage(QuestionType.radio,questionOptions2)),
                GetQuestion(3, "Do you sell products online (via the internet)?", QuestionType.radio.ToString(), questionOptions2,GetTotalWeightage(QuestionType.radio,questionOptions2))
            };

            return questionslist;
        }

        Question GetQuestion(int questionId, string questionText, string type, List<QuestionOption> options, int totalWeightage)
        {
            Question questionObject = new Question()
            {
                QuestionId = questionId,
                QuestionText = questionText,
                Type = type,
                Options = options,
                TotalWeightage = totalWeightage
            };
            return questionObject;
        }
        QuestionOption GetQuestionOptions(string text, int value, bool IsSelected, int weightage)
        {
            QuestionOption obj = new QuestionOption()
            {
                Text = text,
                Value = value,
                IsSelected = IsSelected,
                Weightage = weightage
            };
            return obj;
        }
        int GetTotalWeightage(QuestionType questionType, List<QuestionOption> questionOptions)
        {
            int totalWeightage = 0;
            switch (questionType)
            {
                case QuestionType.checkbox:
                case QuestionType.radio:
                    foreach (var questionOption in questionOptions)
                    {
                        totalWeightage = totalWeightage + questionOption.Weightage;
                    }
                    break;
                case QuestionType.text:
                    totalWeightage = 10;
                    break;
                default:
                    break;
            }
            return totalWeightage;
        }

    }
}