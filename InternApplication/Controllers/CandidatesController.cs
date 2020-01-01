using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternApplication.Models;

namespace InternApplication.Controllers
{
    public class CandidatesController : Controller
    {
        private ApplicationDbContext _context;
        public CandidatesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var candidates = _context.Candidates
                .Include(c => c.Gender)
                .Include(c => c.Race)
                .Include(c => c.VerteranStatus)
                .ToList();

            return View(candidates);
        }

        public ActionResult Details(string Email)
        {
            var Candidate = _context.Candidates.SingleOrDefault(c => c.Email == Email);

            if (Candidate == null)
                return HttpNotFound();

            return View(Candidate);

        }


    }
}