using PMOSRS.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Entities
{
    public class t_TSs : BaseEntity
    {
        [Required, MaxLength(36), Display(Name = "Project Id")]
        public Guid ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual t_Projects Projects { get; set; }

        [Required, MaxLength(50), Display(Name = "TS Name")]
        public string Name { get; set; }
    }
}
