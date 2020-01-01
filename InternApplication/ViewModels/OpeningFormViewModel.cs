using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternApplication.Models;

namespace InternApplication.ViewModels
{
    public class OpeningFormViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Position position { get; set; }
        
        public string[] Criteria {
            get 
            {
                return position.Criteria != null ? position.Criteria.Split(';') : new string[0];
            } 
         }
        
        public string Title
        {
            get
            {
                return position.Id != Position.NewCreatedPosition ? "Edit Position" : "New Position";
            }
        }
    }
}