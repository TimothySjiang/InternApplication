using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternApplication.Models
{
    public class Position
    {
        public int Id { get; set; }
        public static readonly byte NewCreatedPosition = 0;

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public byte DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string DetailedDescription { get; set; }

        public string Criteria { get; set; }
    }
}