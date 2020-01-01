using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternApplication.Models
{
    public class Candidate
    {
        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required]
        public string Phone {get; set;}


        public byte GenderId { get; set; }
        public Gender Gender { get; set; }

        public byte RaceId { get; set; }
        public Race Race { get; set; }

        public byte VeteranStatusId { get; set; }
        public VeteranStatus VerteranStatus { get; set; }

        public string CurrentCompany {get; set;}
        public string LinkedInURL { get; set; }

        public string GitHubURL {get; set;}

        public string PortfolioURL {get; set;}

    }
}