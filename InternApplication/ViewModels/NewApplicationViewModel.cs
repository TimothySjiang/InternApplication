using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternApplication.Models;

namespace InternApplication.ViewModels
{
    public class NewApplicationViewModel
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public int PositionId { get; set; }

        public string Creterias { get; set; }

        public Candidate candidate { get; set; }
        public IEnumerable<Gender> Genders { get; set; }

        public IEnumerable<Race> Races { get; set; }

        public IEnumerable<VeteranStatus> VeteranStatuses { get; set;}
    }
}