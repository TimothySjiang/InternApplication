using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InternApplication.Models;

namespace InternApplication.Dtos
{
    public class ApplicationDto
    {
        public int Id { get; set; }

        public string CandidateEmail { get; set; }

        public CandidateDto Candidate { get; set; }

        [Required]
        public int PositionId { get; set; }

        public PositionDto Position { get; set; }

        public int Score { get; set; }

        public DateTime DateApplied { get; set; }

        public string ResumePath { get; set; }

        public string AddInfo { get; set; }
    }
}