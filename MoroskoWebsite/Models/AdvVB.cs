//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoroskoWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AdvVB
    {
        public int Id { get; set; }
        [Display(Name = "Project")]
        public string projectname { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Student")]
        public string studentname { get; set; }
        public string AspNetUser_Id { get; set; }
        [Display(Name = "Grade")]
        public string grade { get; set; }
    }
}
