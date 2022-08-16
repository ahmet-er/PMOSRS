using PMOSRS.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Entities
{
    public class t_AuthorityRoleMaps : BaseEntity
    {
        [Required, MaxLength(36), Display(Name = "Authory Id")]
        public Guid AuthoryId { get; set; }
        [ForeignKey("AuthoryId")]
        public virtual t_Authorities t_Authorities { get; set; }

        [Required, MaxLength(36), Display(Name = "Role Id")]
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual t_Roles t_Roles { get; set; }
    }
}
