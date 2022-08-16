using PMOSRS.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Entities
{
    public class t_TIDs : BaseEntity
    {
        [Required, MaxLength(36), Display(Name = "TS Id")]
        public Guid TSId { get; set; }
        [ForeignKey("TSId")]
        public virtual t_TSs TS { get; set; }

        [Required, MaxLength(50), Display(Name = "TID Work Item Code")]
        public string WorkItemCode { get; set; }

        [Required, MaxLength(50), Display(Name = "TID Tags")]
        public string Tags { get; set; }

        [Required, MaxLength(50), Display(Name = "TID RelScope")]
        public string RelScope { get; set; }

        [Required, MaxLength(50), Display(Name = "TID Title")]
        public string Title { get; set; }

        [Required, MaxLength(255), Display(Name = "TID Description")]
        public string Description { get; set; }

        [Required, Display(Name = "TID State Id")]
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual t_TIDStates TIDState { get; set; }
    }
}
