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
                GetQuestionOptions("Yes", 1, false, 3, GetFactorWeightage(40, 20)),
                GetQuestionOptions("No", 2, false, 2, GetFactorWeightage(30))
            };
            List<QuestionOption> questionOptions2 = new List<QuestionOption>
            {
                GetQuestionOptions("Albama", 1, false, 4, GetFactorWeightage(50,30, 10, 20, 15, 25)),
                GetQuestionOptions("California", 2, false, 5, GetFactorWeightage(30,20, 10, 20, 15, 25)),
                GetQuestionOptions("Michigan", 3, false, 5, GetFactorWeightage(20,20, 15, 25))
            };
            List<QuestionOption> questionOptions2_Chk = new List<QuestionOption>
            {
                GetQuestionOptions("Albama", 1, false,5, GetFactorWeightage(50,30, 10, 20, 15, 25)),
                GetQuestionOptions("California", 2, false,5, GetFactorWeightage(30,20, 10, 20, 15, 25)),
                GetQuestionOptions("Michigan", 3, false,5, GetFactorWeightage(20,20, 15, 25))
            };
            List<QuestionOption> questionOptions3 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,6, GetFactorWeightage(0,0,0,0,0,0,0)),
                GetQuestionOptions("No", 2, false,5, GetFactorWeightage(30,20, 10, 20, 15, 25))
            };
            List<QuestionOption> questionOptions4 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,6, GetFactorWeightage(20,20,25)),
                GetQuestionOptions("No", 2, false,6, GetFactorWeightage(30,20, 10, 20, 15, 25))
            };
            List<QuestionOption> questionOptions5 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,7, GetFactorWeightage(30,20, 10, 20, 15, 25)),
                GetQuestionOptions("No", 2, false,7, GetFactorWeightage(78,65, 40, 70, 45, 35, 45))
            };
            List<QuestionOption> questionOptions6 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,8, GetFactorWeightage(48,35, 45)),
                GetQuestionOptions("No", 2, false,8, GetFactorWeightage(35, 40))
            };
            List<QuestionOption> questionOptions7 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,9, GetFactorWeightage(48,25, 45)),
                GetQuestionOptions("No", 2, false,9, GetFactorWeightage(30,20)),
                GetQuestionOptions("Both, other than home ruled also", 3, false,9, GetFactorWeightage(49,30, 10, 20, 25, 35, 25))
            };
            List<QuestionOption> questionOptions8 = new List<QuestionOption>
            {
                GetQuestionOptions("1658-ATTALIA", 1, false,10, GetFactorWeightage(30,30, 43,26,30)),
                GetQuestionOptions("1718-BIRMINGHAM", 2, false,10, GetFactorWeightage(30,30, 43,26,30)),
                GetQuestionOptions("9752-BAKERHILL", 3, false,10, GetFactorWeightage(50,70, 43,26,30)),
                GetQuestionOptions("9643-BEAR CREEK", 4, false,10, GetFactorWeightage(70,60, 43,26,30)),
                GetQuestionOptions("2089-CULLMAN", 5, false,10,GetFactorWeightage(30,30, 43,26,30))
            };
            List<QuestionOption> questionOptions9 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,11, GetFactorWeightage(55,65, 43,26,30)),
                GetQuestionOptions("No", 2, false,11, GetFactorWeightage(30,30, 43,26,30))
            };
            List<QuestionOption> questionOptions10 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,12, GetFactorWeightage(60,70, 43,26,30)),
                GetQuestionOptions("No", 2, false,12, GetFactorWeightage(0,0, 20,20,30))
            };
            List<QuestionOption> questionOptions11 = new List<QuestionOption>
            {
                GetQuestionOptions("Yes", 1, false,-1, GetFactorWeightage(20,20, 23,26,20)),
                GetQuestionOptions("No", 2, false,-1, GetFactorWeightage(50,60, 43,26,30))
            };

            List<Question> questionslist = new List<Question>
            {
                GetQuestion(1, "Are you filing for more than one State?", QuestionType.radio.ToString(), questionOptions1, GetTotalWeightage(QuestionType.checkbox,questionOptions1)),
                GetQuestion(2, "In which state are you obligated to Collect sales tax?", QuestionType.radio.ToString(), questionOptions2, GetTotalWeightage(QuestionType.radio,questionOptions2)),
                GetQuestion(3, "In which state are you obligated to Collect sales tax?", QuestionType.checkbox.ToString(), questionOptions2_Chk, GetTotalWeightage(QuestionType.radio,questionOptions2_Chk)),
                GetQuestion(4, "Are you doing MAT-filing?", QuestionType.radio.ToString(), questionOptions3,GetTotalWeightage(QuestionType.radio,questionOptions3)),
                GetQuestion(5, "Are you doing e-filing?", QuestionType.radio.ToString(), questionOptions4,GetTotalWeightage(QuestionType.radio,questionOptions4)),
                GetQuestion(6, "Are you paying for preparer or using any software?", QuestionType.radio.ToString(), questionOptions5,GetTotalWeightage(QuestionType.radio,questionOptions5)),
                GetQuestion(7, "Do you integrate filing raw data with the system using any tool?", QuestionType.radio.ToString(), questionOptions6,GetTotalWeightage(QuestionType.radio,questionOptions6)),
                GetQuestion(8, "Does it come under Home-ruled state?", QuestionType.radio.ToString(), questionOptions7,GetTotalWeightage(QuestionType.radio,questionOptions7)),
                GetQuestion(9, "In which city are you doing bussiness?", QuestionType.checkbox.ToString(), questionOptions8,GetTotalWeightage(QuestionType.radio,questionOptions8)),
                GetQuestion(10, "Are you doing sales tax nexus filing in your bussiness?", QuestionType.radio.ToString(), questionOptions9,GetTotalWeightage(QuestionType.radio,questionOptions9)),
                GetQuestion(11, "Have you done any transactions in Sales tax holidays also?", QuestionType.radio.ToString(), questionOptions10,GetTotalWeightage(QuestionType.radio,questionOptions10)),
                GetQuestion(12, "Have you been audited?", QuestionType.radio.ToString(), questionOptions11,GetTotalWeightage(QuestionType.radio,questionOptions11))
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
        QuestionOption GetQuestionOptions(string text, int value, bool IsSelected, int nextQuestionId, FactorWeightage factorWeightage)
        {
            QuestionOption obj = new QuestionOption()
            {
                Text = text,
                Value = value,
                IsSelected = IsSelected,
                NextQuestionId = nextQuestionId,
                FactorWeightage = factorWeightage
            };
            return obj;
        }

        FactorWeightage GetFactorWeightage(int time=10, int money = 10, int other = 10, int operational = 10, int burden = 10, int costOfPF = 10, int pshycological = 10)
        {
            FactorWeightage obj = new FactorWeightage()
            {
                Time = time,
                Money = money,
                Other = other,
                Operational = operational,
                Burden = burden,
                CostOfPF = costOfPF,
                Pshycological = pshycological
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
                        //totalWeightage = totalWeightage + questionOption.FactorWeightage;
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