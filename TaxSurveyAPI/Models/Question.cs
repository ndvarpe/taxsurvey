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
        public int Weightage { get; set; }
        public int NextQuestionId { get; set; }
    }
}