using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class Result
    {
        public int resultId { get; set; }
        public int candidateId { get; set; }
        public int obtainedScore { get; set; }
        public int IncorrectScore { get; set; }
        public int totalScore { get; set; }

        public string CandidateName { get; set; }
    }
}
