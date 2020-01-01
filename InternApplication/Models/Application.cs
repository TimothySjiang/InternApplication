using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternApplication.Models
{
    public class Application
    {
        public int Id { get; set; }

        public string CandidateEmail { get; set; }

        public Candidate Candidate { get; set; }

        [Required]
        public int PositionId { get; set; }

        public Position Position { get; set; }
        
        public int Score { get; set; }

        public DateTime DateApplied { get; set; }

        public string ResumePath { get; set; }
        
        public string AddInfo { get; set; }
        
    }
}