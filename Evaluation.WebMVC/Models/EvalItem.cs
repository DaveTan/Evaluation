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
    using System.Collections.Generic;
    
    public partial class EvalItem
    {
        public int Id { get; set; }
        public Nullable<int> CoreCompetencyId { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> EvalHeaderId { get; set; }
    
        public virtual EvalHeader EvalHeader { get; set; }
        public virtual EvalHeader EvalHeader1 { get; set; }
    }
}
