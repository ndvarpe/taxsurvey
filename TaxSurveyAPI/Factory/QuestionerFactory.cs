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
                GetQuestionOptions("0 to 5", 1, false),
                GetQuestionOptions("5 to 15", 2, false),
                GetQuestionOptions("15 to 30", 3, false),
                GetQuestionOptions("30 to 50", 4, false)
            };
            List<QuestionOption> questionOptions2 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false),
                GetQuestionOptions("No", 2, false)
            };

            List<Question> questionslist = new List<Question>
            {
                GetQuestion(1, "How many states are you obligated to collect sales tax in?", "radio", 10,questionOptions1),
                GetQuestion(2, "Do you collect sales tax in Louisiana?", "radio", 10,questionOptions2),
                GetQuestion(3, "Do you sell products online (via the internet)?", "radio", 10,questionOptions2)
            };

            return questionslist;
        }

        Question GetQuestion(int questionId, string questionText, string type, int weightage, List<QuestionOption> options)
        {
            Question questionObject = new Question()
            {
                QuestionId = questionId,
                QuestionText = questionText,
                Type = type,
                Weightage = weightage,
                Options = options
            };
            return questionObject;
        }
        QuestionOption GetQuestionOptions(string text, int value, bool IsSelected)
        {
            QuestionOption obj = new QuestionOption()
            {
                Text = text,
                Value = value,
                IsSelected = IsSelected
            };
            return obj;
        }

    }
}