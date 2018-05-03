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
                GetQuestionOptions("Yes", 1, false,20,2),
                GetQuestionOptions("No", 2, false,0,2),
            };
            List<QuestionOption> questionOptions2 = new List<QuestionOption>
            {
                GetQuestionOptions("Albama", 1, false,30,3),
                GetQuestionOptions("California", 2, false,30,3),
                GetQuestionOptions("Michigan", 2, false,10,3)
            };
            List<QuestionOption> questionOptions3 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,0,4),
                GetQuestionOptions("No", 2, false,30,4)
            };
            List<QuestionOption> questionOptions4 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,0,5),
                GetQuestionOptions("No", 2, false,30,5)
            };
            List<QuestionOption> questionOptions5 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,10,6),
                GetQuestionOptions("No", 2, false,60,6)
            };
            List<QuestionOption> questionOptions6 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,10,7),
                GetQuestionOptions("No", 2, false,60,7)
            };
            List<QuestionOption> questionOptions7 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,20,8),
                GetQuestionOptions("No", 2, false,0,8),
                GetQuestionOptions("Both, other than home ruled also", 3, false,30,8)
            };
            List<QuestionOption> questionOptions8 = new List<QuestionOption>
            {
                GetQuestionOptions("1658-ATTALIA", 1, false,10,9),
                GetQuestionOptions("1718-BIRMINGHAM", 2, false,10,9),
                GetQuestionOptions("9752-BAKERHILL", 2, false,20,9),
                GetQuestionOptions("9643-BEAR CREEK", 2, false,20,9),
                GetQuestionOptions("2089-CULLMAN", 2, false,10,9)
            };
            List<QuestionOption> questionOptions9 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,20,10),
                GetQuestionOptions("No", 2, false,0,10)
            };
            List<QuestionOption> questionOptions10 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,10,11),
                GetQuestionOptions("No", 2, false,0,11)
            };
            List<QuestionOption> questionOptions11 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,0,-1),
                GetQuestionOptions("No", 2, false,20,-1)
            };

            List<Question> questionslist = new List<Question>
            {
                GetQuestion(1, "Are you filing for more than one State?", QuestionType.radio.ToString(), questionOptions1, GetTotalWeightage(QuestionType.checkbox,questionOptions1)),
                GetQuestion(2, "In which state are you obligated to Collect sales tax?", QuestionType.radio.ToString(), questionOptions2, GetTotalWeightage(QuestionType.radio,questionOptions2)),
                GetQuestion(3, "Are you doing MAT-filing?", QuestionType.radio.ToString(), questionOptions3,GetTotalWeightage(QuestionType.radio,questionOptions3)),
                GetQuestion(4, "Are you doing e-filing?", QuestionType.radio.ToString(), questionOptions4,GetTotalWeightage(QuestionType.radio,questionOptions4)),
                GetQuestion(5, "Are you paying for preparer or buyied any software?", QuestionType.radio.ToString(), questionOptions5,GetTotalWeightage(QuestionType.radio,questionOptions5)),
                GetQuestion(6, "Do you integrate filing raw data with the system using any tool?", QuestionType.radio.ToString(), questionOptions6,GetTotalWeightage(QuestionType.radio,questionOptions6)),
                GetQuestion(7, "Does it come under Home-ruled state?", QuestionType.radio.ToString(), questionOptions7,GetTotalWeightage(QuestionType.radio,questionOptions7)),
                GetQuestion(8, "In which city are you doing bussiness?", QuestionType.radio.ToString(), questionOptions8,GetTotalWeightage(QuestionType.radio,questionOptions8)),
                GetQuestion(9, "Are you doing sales tax nexus filing in your bussiness?", QuestionType.radio.ToString(), questionOptions9,GetTotalWeightage(QuestionType.radio,questionOptions9)),
                GetQuestion(10, "Have you done any transactions in Sales tax holidays also?", QuestionType.radio.ToString(), questionOptions10,GetTotalWeightage(QuestionType.radio,questionOptions10)),
                GetQuestion(11, "Have you been audited?", QuestionType.radio.ToString(), questionOptions11,GetTotalWeightage(QuestionType.radio,questionOptions11))
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
        QuestionOption GetQuestionOptions(string text, int value, bool IsSelected, int weightage, int nextQuestionId)
        {
            QuestionOption obj = new QuestionOption()
            {
                Text = text,
                Value = value,
                IsSelected = IsSelected,
                Weightage = weightage,
                NextQuestionId = nextQuestionId
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