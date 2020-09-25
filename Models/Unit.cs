using System;
using System.ComponentModel.DataAnnotations;

namespace FarmFresh.Models
{
    public class Unit
    {
        public int Id{get;set;}

        [StringLength(100)]
        public string Name {get;set;}
        public string Description {get;set;}
        public bool IsDelete {get;set;}
        public int CreatedBy {get;set;}
        public DateTime CreatedDate{get;set;}
        public int? UpdatedBy {get;set;}
        public DateTime? UpdatedDate {get;set;}
    }
}