//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evaluation.WebMVC.Models
{
    using System;
    
    public partial class sp_SearchQuarters_Result
    {
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public int isEvaluated { get; set; }
        public int isConfirmed { get; set; }
        public Nullable<double> TotalScore { get; set; }
    }
}
