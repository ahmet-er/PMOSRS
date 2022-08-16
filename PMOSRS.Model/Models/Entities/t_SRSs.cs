using PMOSRS.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Entities
{
    public class t_SRSs : BaseEntity
    {
        [Required, MaxLength(36), Display(Name = "TID Id")]
        public Guid TIDId { get; set; }
        [ForeignKey("TIDId")]
        public virtual t_TIDs TID { get; set; }

        [Required, MaxLength(50), Display(Name = "SRS Work Item Code")]
        public string WorkItemCode { get; set; }

        [Required, MaxLength(50), Display(Name = "SRS Tags")]
        public string Tags { get; set; }

        [Required, MaxLength(50), Display(Name = "SRS RelScope")]
        public string RelScope { get; set; }

        [Required, MaxLength(50), Display(Name = "SRS Description")]
        public string Description { get; set; }

        [Required, Display(Name = "TID State Id")]
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual t_SRSStates SRSState { get; set; }
    }
}
