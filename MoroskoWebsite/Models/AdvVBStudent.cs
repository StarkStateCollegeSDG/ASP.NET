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
    
    public partial class AdvVBStudent
    {
        public int Id { get; set; }
        public int aspnetuserId { get; set; }
        public int advvbId { get; set; }

        //Foreign Keys
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AdvVB AdvVB { get; set; }
    }
}
