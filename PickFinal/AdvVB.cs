using System.ComponentModel.DataAnnotations;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PickFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdvVB
    {
        public int Id { get; set; }
        public string projectname { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public string studentname { get; set; }
    }
}