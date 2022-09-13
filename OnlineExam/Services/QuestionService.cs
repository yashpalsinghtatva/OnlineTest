using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Services
{
    public class QuestionService
    {
        public List<Question> getAllQuestions(int preferedLanguageId)
        {
            List<Question> testQuestions = new List<Question>();
            SqlConnection con = DatabaseOperations.GetSqlConnection();
            SqlCommand cmd = new SqlCommand("u_QuestionsGetAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@candidatePreferedLanguageId", preferedLanguageId);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            int i = 1;
            while (dataReader.Read())
            {
                Question question = new Question();
                question.questionId = Convert.ToInt32(dataReader["questionId"].ToString());
                question.questionText = @dataReader["questionText"].ToString();
                question.languageId = Convert.ToInt32(dataReader["languageId"].ToString());
                question.questionType = new QuestionType();
                question.questionType.QuestionTypeId = Convert.ToInt32(dataReader["QuestionTypeId"].ToString());
                question.questionType.QuestionTypeName = dataReader["QuestionTypeName"].ToString();
                question.questionIndexNo = i;
                testQuestions.Add(question);
                i++;

            }
            dataReader.Close();
            return testQuestions;
        }

        public Tuple<List<Option>,List<Answer>> getAllOptionsByQuestionIds(string questionIds)
        {
            List<Option> allOptions = new List<Option>();
            List<Answer> allAnswers = new List<Answer>();

            try
            {
                SqlConnection con = DatabaseOperations.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("u_OptionsAndAnswerGetAllByQuestionId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@questionIds", questionIds);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Option option = new Option();
                    option.optionId = Convert.ToInt32(dataReader["optionId"].ToString());
                    option.optionText = dataReader["optionText"].ToString();
                    option.questionId = Convert.ToInt32(dataReader["questionId"].ToString());

                    allOptions.Add(option);
                }
                dataReader.NextResult();

                while (dataReader.Read())
                {
                    Answer answer = new Answer();
                    answer.AnswerId = Convert.ToInt32(dataReader["answerId"].ToString());
                    answer.AnswerText = dataReader["answerText"].ToString();
                    answer.questionId = Convert.ToInt32(dataReader["questionId"].ToString());

                    allAnswers.Add(answer);
                }
                dataReader.Close();
                return new Tuple<List<Option>, List<Answer>>(allOptions,allAnswers);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddResult(Result result)
        {
            try
            {
                SqlConnection con = DatabaseOperations.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("u_ResultAdd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@candidateId", result.candidateId);
                cmd.Parameters.AddWithValue("@obtainedScore", result.obtainedScore);
                cmd.Parameters.AddWithValue("@totalScore", result.totalScore);
                cmd.Parameters.Add("@OutputResultId", SqlDbType.Int);
                cmd.Parameters["@OutputResultId"].Direction = ParameterDirection.Output;
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                {
                    result.resultId = Convert.ToInt32(cmd.Parameters["@OutputResultId"].Value);
                    return true;
                }
                con.Close();
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}