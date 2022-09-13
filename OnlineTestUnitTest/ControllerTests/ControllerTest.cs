using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineTest.Controllers;
using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static OnlineTest.Models.Globals;

namespace OnlineTestUnitTest.ControllerTests
{
    [TestClass]
    public class ControllerTest
    {
        string defaultViewName = string.Empty;

        [TestMethod]
        public void Candidate_Index_Test_Success()
        {
            string defaultViewName = string.Empty;
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            //Arrange
            CandidateController candidateController = new CandidateController();
            candidateController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var result = candidateController.Index() as ViewResult;
            var datamodel = (Candidate)result.Model;
            if (string.IsNullOrEmpty(result.ViewName))
            {
                defaultViewName = "Index";
            }
            else
            {
                defaultViewName = result.ViewName;
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(datamodel.lstPreferedLanguages, typeof(List<SelectListItem>));
            Assert.AreEqual("Index", defaultViewName);
        }

        [TestMethod]
        public void Candidate_Index_Test_Exception()
        {
            //Arrange
            CandidateController candidateController = new CandidateController();
      
            //Act
            var result = candidateController.Index() as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
            Assert.IsNotNull(result.RouteValues);
        }

        [TestMethod]
        public void Candidate_Create_Test_Success()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            //Arrange
            CandidateController candidateController = new CandidateController();
            candidateController.ControllerContext.HttpContext = mockHttpContext.Object;
            Candidate candidate = getTestCandidate();

            //Act
            var result = (RedirectToActionResult)candidateController.Create(candidate);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Question", result.ControllerName);

        }

        [TestMethod]
        public void Candidate_Create_Test_Exception()
        {
            //Arrange
            CandidateController candidateController = new CandidateController();
            Candidate candidate = getTestCandidate();

            //Act
            var result = (RedirectToActionResult)candidateController.Create(candidate);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
            Assert.IsNotNull(result.RouteValues);

        }

        [TestMethod]
        public void Question_Index_Test_Success()
        {

            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", getTestQuestions());
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;

            var result = questionController.Index() as ViewResult;
            var datamodel = (Question)result.Model;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(datamodel, typeof(Question));

            //Assert.AreEqual(datamodel, type);
            if (string.IsNullOrEmpty(result.ViewName))
            {
                defaultViewName = "Index";
            }
            else
            {
                defaultViewName = result.ViewName;
            }
            Assert.AreEqual("Index", defaultViewName);

        }

        [TestMethod]
        public void Question_Index_Test_NoCandidate()
        {

            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", null);
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;

            //Act
            var result = questionController.Index() as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
            Assert.IsNotNull(result.RouteValues);

        }

        [TestMethod]
        public void Question_Index_Test_NoQuestionsInSession()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", null);
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);


            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;
            var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

            //Act
            var result = questionController.Index() as ViewResult;
            var datamodel = (Question)result.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(datamodel, typeof(Question));

            //Assert.AreEqual(datamodel, type);
            if (string.IsNullOrEmpty(result.ViewName))
            {
                defaultViewName = "Index";
            }
            else
            {
                defaultViewName = result.ViewName;
            }
            Assert.AreEqual("Index", defaultViewName);

        }

        [TestMethod]
        public void Question_NextPrev_Test_Next()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", getTestQuestions());
            mockSession.SetObjectAsJson("savedUserAnswers", getTestAnswer());
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;
            var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "submitButton", "next" },
                { "userAnswer", "object-oriented ,modern" },
                { "questionId", "2" },
                {"currentRecordNo","1"}
            });
            //Act
            var result = questionController.NextPrev(formCol) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Question_NextPrev_Test_Prev()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", getTestQuestions());
            mockSession.SetObjectAsJson("savedUserAnswers", getTestAnswer());
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;
            var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "submitButton", "prev" },
                { "userAnswer", "4" },
                { "questionId", "4" },
                {"currentRecordNo","2"}
            });

            //Act
            var result = questionController.NextPrev(formCol) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Question_NextPrev_Test_Question()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", getTestQuestions());
            mockSession.SetObjectAsJson("savedUserAnswers", getTestAnswer());
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;
            var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "submitButton", "question1" },
                { "questionId", "4" },
                {"currentRecordNo","2"}
            });

            //Act
            var result = questionController.NextPrev(formCol) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Question_NextPrev_Test_Refresh()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", getTestQuestions());
            mockSession.SetObjectAsJson("savedUserAnswers", getTestAnswer());
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;
            var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

            //Act
            var result = questionController.NextPrev(formCol) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Question_NextPrev_Test_NoQuestion()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentSessionQuestions", null);
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;
            var formCol = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());

            //Act
            var result = questionController.NextPrev(formCol) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
            Assert.IsNotNull(result.RouteValues);

        }

        [TestMethod]
        public void Question_CalculateResult_Test()
        {
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockHttpSession mockSession = new MockHttpSession();
            mockSession.SetObjectAsJson("currentCandidate", getTestCandidate());
            mockSession.SetObjectAsJson("currentSessionQuestions", getTestQuestions());
            mockSession.SetObjectAsJson("savedUserAnswers", getTestAnswer());
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);

            QuestionController questionController = new QuestionController();
            questionController.ControllerContext.HttpContext = mockHttpContext.Object;

            var result = questionController.CalculateResult(1, 1) as ViewResult;
            var datamodel = (ResultViewModel)result.Model;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(datamodel, typeof(ResultViewModel));

            if (string.IsNullOrEmpty(result.ViewName))
            {
                defaultViewName = "CalculateResult";
            }
            else
            {
                defaultViewName = result.ViewName;
            }
            Assert.AreEqual("CalculateResult", defaultViewName);

        }
        public Candidate getTestCandidate()
        {
            Candidate candidate = new Candidate();
            candidate.candidateGender = 'M';
            candidate.candidateEmail = "yashpalsingh@gmail.com";
            candidate.candidateName = "yash";
            candidate.candidatePreferedLanguageId = 1;
            candidate.candidiatePhoneNo = "8767787667";
            candidate.lstPreferedLanguages = getTestLanguages();

            return candidate;
        }
        public List<SelectListItem> getTestLanguages()
        {
            List<SelectListItem> testLanguages = new List<SelectListItem>();
            testLanguages.Add(new SelectListItem() { Text = "English", Value = "1" });
            testLanguages.Add(new SelectListItem() { Text = "Hindi", Value = "2" });
            return testLanguages;
        }
        public List<Question> getTestQuestions()
        {
            List<Question> testQuestions = new List<Question>();
            Question question = testQuestion();
            testQuestions.Add(question);

            question = new Question();
            question.questionId = 4;
            question.questionType = new OnlineTest.Models.QuestionType();
            question.questionType.QuestionTypeId = 3;
            question.questionText = "int occupies ____ number of bytes";
            question.questionIndexNo = 2;
            question.languageId = 1;
            question.answers = new List<Answer>() { new Answer() { AnswerId = 6, AnswerText = "4", questionId = 4 } };

            question.options = new List<Option>();
            testQuestions.Add(question);

            return testQuestions;
        }
        public Question testQuestion()
        {
            Question question = new Question();
            question.questionId = 2;
            question.questionType = new OnlineTest.Models.QuestionType();
            question.questionType.QuestionTypeId = 5;
            question.questionText = "What type of language is c#?";
            question.languageId = 1;
            question.questionIndexNo = 1;
            question.answers = new List<Answer>() { new Answer() {AnswerId = 2,AnswerText="object-oriented",questionId=2 },
                                                    new Answer() {AnswerId = 3,AnswerText="modern",questionId=2 },
                                                    new Answer() {AnswerId = 4,AnswerText="general-purpose",questionId=2 }};

            question.options = new List<Option>() { new Option() {optionId = 6,optionText="object-oriented",questionId=2 },
                                                    new Option() {optionId = 7,optionText="modern",questionId=2 },
                                                    new Option() {optionId = 8,optionText="general-purpose",questionId=2 },
                                                    new Option() {optionId = 9,optionText="losely typed",questionId=2 },
                                                    new Option() {optionId = 10,optionText="none of the above",questionId=2 }};

            return question;
        }
        public Dictionary<int, string[]> getTestAnswer()
        {
            Dictionary<int, string[]> dtyUserAnswers = new Dictionary<int, string[]>();
            dtyUserAnswers.Add(2, new string[] { "object-oriented", "modern" });
            return dtyUserAnswers;
        }
    }
}
