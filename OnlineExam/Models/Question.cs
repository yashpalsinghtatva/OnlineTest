using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class Question
    {
        public int questionId { get; set; }
        public string questionText { get; set; }
        public QuestionType questionType { get; set; }
        public int  languageId { get; set; }
        public List<Option> options { get; set; }
        public List<Answer> answers { get; set; }
        public string[] userAnswer { get; set; }

        public int questionIndexNo { get; set; }
    }
}
