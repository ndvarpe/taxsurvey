using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxSurveyAPI.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
        public int TotalWeightage { get; set; }
        public int SelectedOption { get; set; }
        public List<QuestionOption> Options { get; set; }
        public bool IsAnswered { get; set; }
        public int PrevQuestionId { get; set; }
    }
    public class QuestionOption
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public bool IsSelected { get; set; }
        //public int Weightage { get; set; }
        public int NextQuestionId { get; set; }
        public FactorWeightage FactorWeightage { get; set; }
    }
    public class FactorWeightage
    {
        public int Time { get; set; }
        public int Money { get; set; }
        public int Other { get; set; }
        public int Operational { get; set; }
        public int Burden { get; set; }
        public int CostOfPF { get; set; }
        public int Pshycological { get; set; }
    }

    public class FactorDetails
    {
        public decimal Compliance { get; set; }
        public decimal Efficiency { get; set; }

        public decimal Psychological { get; set; }
        public decimal TotalRisk { get; set; }
        public string Comment { get; set; }

    }

    public class Category
    {
        public string CategoryName { get; set; }
        public decimal Value { get; set; }
        
    }
}