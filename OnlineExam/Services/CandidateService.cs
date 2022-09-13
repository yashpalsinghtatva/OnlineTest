using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Services
{
    public class CandidateService
    {
        public bool AddCandidate(Candidate candidate)
        {
            try
            {
                SqlConnection con = DatabaseOperations.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("u_CandidatesAdd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@candidateName", candidate.candidateName);
                cmd.Parameters.AddWithValue("@candidateEmail", candidate.candidateEmail);
                cmd.Parameters.AddWithValue("@candidiatePhoneNo", candidate.candidiatePhoneNo);
                cmd.Parameters.AddWithValue("@candidateGender", candidate.candidateGender);
                cmd.Parameters.AddWithValue("@candidateUsername", candidate.candidateUsername);
                cmd.Parameters.AddWithValue("@candidatePassword", candidate.candidatePassword);
                cmd.Parameters.AddWithValue("@candidatePreferedLanguageId", candidate.candidatePreferedLanguageId);
                cmd.Parameters.Add("@OutputCandId", SqlDbType.Int);
                cmd.Parameters["@OutputCandId"].Direction = ParameterDirection.Output;
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                {
                    candidate.CandidateId = Convert.ToInt32(cmd.Parameters["@OutputCandId"].Value);
                    return true;
                }
                con.Close();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}
