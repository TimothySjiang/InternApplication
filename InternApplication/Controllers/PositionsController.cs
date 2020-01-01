using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternApplication.Models;
using InternApplication.ViewModels;

namespace InternApplication.Controllers
{
    public class PositionsController : Controller
    {
        private ApplicationDbContext _context;
        public PositionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Authorize(Roles = RoleName.CanManagePositions)]
        public ActionResult New()
        {
            var viewModel = new OpeningFormViewModel
            {
                position = new Position(),
                Departments = _context.Departments.ToList(),

            };
            return View("OpeningFormView",viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManagePositions)]
        public ActionResult Post(Position position)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new OpeningFormViewModel
                {   

                    position = position,
                    Departments = _context.Departments.ToList()

                };

                return View("New", viewModel);
            }


            if (position.Id == Position.NewCreatedPosition)
            {
                position.DateAdded = DateTime.Now;
                _context.Positions.Add(position);
            }
            else
            {
                var PositionInDb = _context.Positions.Single(m => m.Id == position.Id);
                PositionInDb.Name = position.Name;
                PositionInDb.Location = position.Location;
                PositionInDb.DepartmentId = position.DepartmentId;
                PositionInDb.ShortDescription = position.ShortDescription;
                PositionInDb.DetailedDescription = position.DetailedDescription;
                PositionInDb.Criteria = position.Criteria;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Positions");
        }

        [Authorize(Roles = RoleName.CanManagePositions)]
        public ActionResult Edit(int id) 
        {
            var position = _context.Positions.SingleOrDefault(c => c.Id == id);

            if (position == null)
                return HttpNotFound();

 
            var viewModel = new OpeningFormViewModel
            {
                position = position,
                Departments = _context.Departments.ToList(),

            };

            return View("OpeningFormView", viewModel);


        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManagePositions))
                return View("List");
            else
                return View("ReadOnlyList");
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var Position = _context.Positions.SingleOrDefault(p => p.Id == id);

            if (Position == null)
                return HttpNotFound();

            return View(Position);
        }


        [Authorize(Roles = RoleName.CanManagePositions)]
        public ActionResult ListApplications(int Id, string Name)
        {

            var viewModel = new ApplicantListViewModel
            {
                positionId = Id,
                positionName = Name,

            };

            return View("ListApplications",viewModel);
        }
    }
}