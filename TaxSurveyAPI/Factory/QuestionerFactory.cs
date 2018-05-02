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
                GetQuestionOptions("0 to 5", 1, false,10),
                GetQuestionOptions("5 to 15", 2, false,10),
                GetQuestionOptions("15 to 30", 3, false,10),
                GetQuestionOptions("30 to 50", 4, false,10)
            };
            List<QuestionOption> questionOptions2 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,10),
                GetQuestionOptions("No", 2, false,10)
            };

            List<Question> questionslist = new List<Question>
            {
                GetQuestion(1, "How many states are you obligated to collect sales tax in?", "radio", questionOptions1),
                GetQuestion(2, "Do you collect sales tax in Louisiana?", "radio", questionOptions2),
                GetQuestion(3, "Do you sell products online (via the internet)?", "radio", questionOptions2)
            };

            return questionslist;
        }

        Question GetQuestion(int questionId, string questionText, string type, List<QuestionOption> options)
        {
            Question questionObject = new Question()
            {
                QuestionId = questionId,
                QuestionText = questionText,
                Type = type,
                Options = options
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

    }
}