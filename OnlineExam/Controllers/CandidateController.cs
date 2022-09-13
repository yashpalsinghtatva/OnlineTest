using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTest.Models;
using OnlineTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineTest.Models.Globals;

namespace OnlineTest.Controllers
{
    public class CandidateController : Controller
    {
        Candidate candidateModel = new Candidate();
        CandidateService candidateService = new CandidateService();

        public ActionResult Index()
        {
            try
            {
                HttpContext.Session.Clear();
                candidateModel.lstPreferedLanguages = (List<SelectListItem>)GetEnumSelectList<PreferedLanguages>();
                return View(candidateModel);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Create(Candidate candidate)
        {
            try
            {

                bool IscandidateAddSuccess = candidateService.AddCandidate(candidate);
                if (IscandidateAddSuccess)
                {
                    HttpContext.Session.SetObjectAsJson("currentCandidate", candidate);
                    return RedirectToAction("Index", "Question");
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Something Went Wrong Please try again" });
                }
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });

            }
        }
        public static List<SelectListItem> GetEnumSelectList<T>()
        {
            try
            {
                return (Enum.GetValues(typeof(T)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(T), e), Value = e.ToString() })).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
