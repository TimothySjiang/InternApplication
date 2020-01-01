using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternApplication.Models;

namespace InternApplication.ViewModels
{
    public class ApplicationDetailViewModel
    {
        public Application Application { get; set; }

        public string positionName { get; set; }
    }
}