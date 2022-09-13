using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class ResultViewModel
    {
        public List<Question> questions { get; set; }
        public Result result { get; set; }
        public Dictionary<int,string[]> savedUserAnswers { get; set; }
    }
}
