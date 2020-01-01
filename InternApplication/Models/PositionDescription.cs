using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternApplication.Models
{
    public class PositionDescription
    {
        public byte Id { get; set; }
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Body { get; set; }

    }
}