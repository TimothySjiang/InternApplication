using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InternApplication.Models;
using InternApplication.ViewModels;

namespace InternApplication.Controllers
{
    public class ApplicationController : Controller
    {
        private ApplicationDbContext _context;
        public ApplicationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [AllowAnonymous]
        public ActionResult NewApplication(int Id)
        {   
            var position = _context.Positions.Single(p => p.Id == Id);
            if (position == null)
                return HttpNotFound();
            var viewModel = new NewApplicationViewModel
            {   
                PositionId = position.Id,
                Title = position.Name,
                Location = position.Location,
                Creterias = position.Criteria,
                candidate = new Candidate(),
                Genders = _context.Genders.ToList(),
                Races = _context.Races.ToList(),
                VeteranStatuses = _context.VeteranStatuses.ToList(),
            };
            return View(viewModel);
        }

        public ActionResult Details(int Id)
        {
            var application = _context.Applications
                .Include(a => a.Candidate)
                .Include(c => c.Candidate.Gender)
                .Include(c => c.Candidate.Race)
                .Include(c => c.Candidate.VerteranStatus)
                .Include(c => c.Position)
                .SingleOrDefault(a => a.Id == Id);

            if (application == null)
                return HttpNotFound();
            var viewModel = new ApplicationDetailViewModel
            {
                Application = application,
            };
            return View(viewModel);
        }


    }
}