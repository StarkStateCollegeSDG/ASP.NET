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
    
    public partial class AdvVB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdvVB()
        {
            this.AdvVBStudents = new HashSet<AdvVBStudent>();
        }
    
        public int Id { get; set; }
        public string projectname { get; set; }
        public string description { get; set; }
        public string studentname { get; set; }
        public string AspNetUser_Id { get; set; }

        //Foreign Keys.
        public virtual AspNetUser AspNetUser { get; set; }

        //Tables that have a foreign key constraint linked to this table.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvVBStudent> AdvVBStudents { get; set; }
    }
}
