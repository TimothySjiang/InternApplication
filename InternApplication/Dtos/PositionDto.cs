using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InternApplication.Models;

namespace InternApplication.Dtos
{
    public class PositionDto
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

        public DepartmentDto Department { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string DetailedDescription { get; set; }

        public string Criteria { get; set; }

    }
}