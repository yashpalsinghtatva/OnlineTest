using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Models;
using OnlineTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Controllers
{
    public class QuestionController : Controller
    {
        QuestionService questions = new QuestionService();
        List<Question> allRandomQuestions = new List<Question>();
        Dictionary<int, string[]> dtyUserAnswers = new Dictionary<int, string[]>();
        public IActionResult Index()
        {
            try
            {
                var currentCandidate = HttpContext.Session.GetObjectFromJson<Candidate>("currentCandidate");
                if (currentCandidate != null)
                {
                    allRandomQuestions = HttpContext.Session.GetObjectFromJson<List<Question>>("currentSessionQuestions");
                    if (allRandomQuestions == null)
                    {
                        allRandomQuestions = questions.getAllQuestions(currentCandidate.candidatePreferedLanguageId);
                        if (allRandomQuestions == null || allRandomQuestions.Count == 0)
                        {
                            //ViewBag.ErrorMessage = "No Question Found Please ask to add Question First";
                            return RedirectToAction("Error", "Home", new { errorMessage = "No Question Found Please ask to add Question First" });

                        }
                        Tuple<List<Option>, List<Answer>> currentQuestionsData = questions.getAllOptionsByQuestionIds(String.Join(", ", allRandomQuestions.Select(x => x.questionId)));

                        foreach (var question in allRandomQuestions)
                        {
                            question.options = currentQuestionsData.Item1.Where(x => x.questionId == question.questionId).ToList();
                            question.answers = currentQuestionsData.Item2.Where(x => x.questionId == question.questionId).ToList();
                        }
                        allRandomQuestions = allRandomQuestions.OrderBy(x => x.questionIndexNo).ToList();
                        HttpContext.Session.SetObjectAsJson("currentSessionQuestions", allRandomQuestions);

                    }
                    ViewBag.TotalQuestions = allRandomQuestions.Count;
                    ViewBag.CurrentQuestion = 1;
                    return View(allRandomQuestions.First());
                }
                else
                {
                    //ViewBag.ErrorMessage = "Something Went Wrong Please try again";
                    return RedirectToAction("Error", "Home", new { errorMessage = "Something Went Wrong Please try again" });
                }
            }
            catch (Exception ex)
            {
                //ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });

            }

        }

        public IActionResult NextPrev(IFormCollection formCollection)
        {
            try
            {
                List<Question> allRandomQuestions = HttpContext.Session.GetObjectFromJson<List<Question>>("currentSessionQuestions");

                if (allRandomQuestions == null)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Something Went Wrong Please try again" });

                }
                ViewBag.TotalQuestions = allRandomQuestions.Count;
                if (formCollection.Count == 0)
                {
                    ViewBag.CurrentQuestion = 1;
                    ViewBag.selectedQuestionNumbers = allRandomQuestions.Where(x=>x.userAnswer != null).Select(x=>x.questionIndexNo).ToList();
                    return View("Index", allRandomQuestions.First());

                }

                if (formCollection["submitButton"].ToString().ToLower().Contains("question"))
                {
                    string currentButtonName = formCollection["submitButton"].ToString();
                    int questionNumber = Convert.ToInt32(currentButtonName.Substring(currentButtonName.Length - 1, 1));
                    ViewBag.CurrentQuestion = questionNumber;
                    ViewBag.selectedQuestionNumbers = allRandomQuestions.Where(x => x.userAnswer != null).Select(x => x.questionIndexNo).ToList();

                    return View("Index", allRandomQuestions[questionNumber - 1]);
                }
                string[] candidateGivenAnswer = null;

                if (!String.IsNullOrEmpty(formCollection["userAnswer"]))
                {
                    candidateGivenAnswer = formCollection["userAnswer"].ToArray();
                    var savedUserAnswers = HttpContext.Session.GetObjectFromJson<Dictionary<int, string[]>>("savedUserAnswers");
                    if (savedUserAnswers != null)
                    {
                        dtyUserAnswers = savedUserAnswers;
                    }
                    dtyUserAnswers[Convert.ToInt32(formCollection["questionId"])] = candidateGivenAnswer;
                    allRandomQuestions.Where(x => x.questionId == Convert.ToInt32(formCollection["questionId"])).FirstOrDefault().userAnswer = candidateGivenAnswer;
                    HttpContext.Session.SetObjectAsJson("savedUserAnswers", dtyUserAnswers);
                    HttpContext.Session.SetObjectAsJson("currentSessionQuestions", allRandomQuestions);

                }
                ViewBag.selectedQuestionNumbers = allRandomQuestions.Where(x => x.userAnswer != null).Select(x => x.questionIndexNo).ToList();

                if (formCollection["submitButton"].ToString().ToLower().Equals("next"))
                {
                    ViewBag.CurrentQuestion = Convert.ToInt32(formCollection["currentRecordNo"]) + 1;
                    return View("Index", allRandomQuestions[Convert.ToInt32(formCollection["currentRecordNo"])]);

                }
                else if (formCollection["submitButton"].ToString().ToLower().Equals("prev"))
                {
                    ViewBag.CurrentQuestion = Convert.ToInt32(formCollection["currentRecordNo"]) - 1;
                    return View("Index", allRandomQuestions[Convert.ToInt32(formCollection["currentRecordNo"]) - 2]);

                }
                else if (formCollection["submitButton"].ToString().ToLower().Equals("submit"))
                {
                    int correctAnswers = 0;
                    foreach (var answer in dtyUserAnswers)
                    {
                        var correctCurrentAnswer = allRandomQuestions.Where(x => x.questionId == answer.Key).FirstOrDefault().answers.Select(x => x.AnswerText).ToList();
                        if (answer.Value.SequenceEqual(correctCurrentAnswer))
                        {
                            correctAnswers++;
                        }
                    }
                    return RedirectToAction("CalculateResult", new { obtainedScore = correctAnswers, totalScore = allRandomQuestions.Count });
                }
                else
                {
                    //ViewBag.ErrorMessage = "Something Went Wrong Please try again";
                    return RedirectToAction("Error", "Home", new { errorMessage = "Something Went Wrong Please try again" });
                }
            }
            catch (Exception ex)
            {
                //ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });

            }

        }
        [HttpGet]
        public IActionResult CalculateResult(int obtainedScore, int totalScore)
        {
            Result result = new Result();
            try
            {
                var currentCandidate = HttpContext.Session.GetObjectFromJson<Candidate>("currentCandidate");
                var allRandomQuestions = HttpContext.Session.GetObjectFromJson<List<Question>>("currentSessionQuestions");
                var savedUserAnswers = HttpContext.Session.GetObjectFromJson<Dictionary<int, string[]>>("savedUserAnswers");

                //if (currentCandidate != null && allRandomQuestions != null && savedUserAnswers != null)
                if (currentCandidate != null && allRandomQuestions != null)
                {
                    result.candidateId = currentCandidate.CandidateId;
                    result.CandidateName = currentCandidate.candidateName;
                    result.obtainedScore = obtainedScore;
                    result.IncorrectScore = totalScore - obtainedScore;
                    result.totalScore = totalScore;

                    if (questions.AddResult(result))
                    {
                        ResultViewModel resultViewModel = new ResultViewModel();
                        resultViewModel.questions = allRandomQuestions;
                        resultViewModel.result = result;
                        resultViewModel.savedUserAnswers = savedUserAnswers;
                        return View(resultViewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();

        }
    }
}
