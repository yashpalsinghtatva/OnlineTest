using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
       
        [Required(ErrorMessage = "Candidate Name is Required")]
        [DisplayName("Candidate Name")]
        public string candidateName { get; set; }
       
        [Required(ErrorMessage = "Candidate Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Candidate Email")]
        public string candidateEmail { get; set; }

        [DisplayName("Candidate PhoneNo.")]
        [Required(ErrorMessage ="Phone Number is Required")]
        public string candidiatePhoneNo { get; set; }
        public char candidateGender { get; set; }
        public string candidateUsername { get; set; }
        public string candidatePassword { get; set; }
        public int candidatePreferedLanguageId { get; set; }

        public List<SelectListItem> lstPreferedLanguages { get; set; }

    }

}
