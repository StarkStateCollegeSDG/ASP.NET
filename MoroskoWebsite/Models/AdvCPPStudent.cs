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
    
    public partial class AdvCPPStudent
    {
        public int Id { get; set; }
        public string aspnetuserId { get; set; }
        public int advcppId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AdvCPP AdvCPP { get; set; }
    }
}
