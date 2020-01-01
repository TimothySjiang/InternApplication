using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using InternApplication.Dtos;
using InternApplication.Models;

namespace InternApplication.Controllers.Api
{
    public class ApplicationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ApplicationsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/positions/1
        [HttpGet]
        public IHttpActionResult GetApplicationsByPosition(int id)
        {
            var applicationDtos = _context.Applications
                .Where(m => m.PositionId == id)
                .Include(c => c.Candidate)
                .Include(c => c.Candidate.Gender)
                .Include(c => c.Candidate.Race)
                .Include(c => c.Candidate.VerteranStatus)
                .Include(c => c.Position)
                .ToList()
                .Select(Mapper.Map<Application, ApplicationDto>);
            if (applicationDtos == null)
                return NotFound();
            return Ok(applicationDtos);
        }

        // POST /api/Applications
        [HttpPost]
        public async Task<HttpResponseMessage> PostApplications()
        {
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            await Request.Content.ReadAsMultipartAsync(provider);

            var Email = provider.FormData.GetValues("email")[0];
            var Name = provider.FormData.GetValues("name")[0];
            var Phone = provider.FormData.GetValues("phone")[0];
            var GenderId = Convert.ToByte(provider.FormData.GetValues("candidate.GenderId")[0]);
            var RaceId = Convert.ToByte(provider.FormData.GetValues("candidate.RaceId")[0]);
            var VeteranStatusId = Convert.ToByte(provider.FormData.GetValues("candidate.VeteranStatusId")[0]);
            var CurrentCompany = provider.FormData.GetValues("company")[0];
            var LinkedInURL = provider.FormData.GetValues("linkedin")[0];
            var GitHubURL = provider.FormData.GetValues("github")[0];
            var PortfolioURL = provider.FormData.GetValues("portfolio")[0];
            var AdditionalInfo = provider.FormData.GetValues("addinfo")[0];
            var PositionId = Convert.ToInt32(provider.FormData.GetValues("PositionId")[0]);


            var CandidateInDb = _context.Candidates.SingleOrDefault(c => c.Email == Email);

            var candidate = new Candidate
            {
                Email = Email,
                Name = Name,
                Phone = Phone,
                CurrentCompany = CurrentCompany,
                GenderId = GenderId,
                RaceId = RaceId,
                VeteranStatusId = VeteranStatusId,
                LinkedInURL = LinkedInURL,
                GitHubURL = GitHubURL,
                PortfolioURL = PortfolioURL,
            };

            if (CandidateInDb == null)
            {
                _context.Candidates.Add(candidate);
            }
            else
            {
                CandidateInDb.Name = Name;
                CandidateInDb.Phone = Phone;
                CandidateInDb.CurrentCompany = CurrentCompany;
                CandidateInDb.GenderId = GenderId;
                CandidateInDb.RaceId = RaceId;
                CandidateInDb.VeteranStatusId = VeteranStatusId;
                CandidateInDb.LinkedInURL = LinkedInURL;
                CandidateInDb.GitHubURL = GitHubURL;
                CandidateInDb.PortfolioURL = PortfolioURL;
            }

            // Handle the file part, Store on server driver
            var Resume = provider.FileData[0];
            Trace.WriteLine(Resume.Headers.ContentDisposition.FileName);
            var Path = Resume.LocalFileName;
            Trace.WriteLine("Server file path: " + Path);

            //Calculate Score:
            var totalScore = 0;
            var Weights = provider.FormData.GetValues("Creterias")[0].Split(';'); 
            var Scores = provider.FormData.GetValues("score");


            for (var i = 0; i < Weights.Length; i++)
               {
                var weight = Weights[i].Split(',')[1];
                totalScore += Convert.ToInt32(Scores[i]) * Convert.ToInt32(weight);
               }

    var application = new Application
            {
                CandidateEmail = Email,
                PositionId = PositionId,
                DateApplied = DateTime.Now,
                ResumePath = Path,
                AddInfo = AdditionalInfo,
                Score = totalScore,
            };
            _context.Applications.Add(application);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
