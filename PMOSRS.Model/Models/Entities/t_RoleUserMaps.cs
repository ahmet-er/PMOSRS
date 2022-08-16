using PMOSRS.Model.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Entities
{
    public class t_RoleUserMaps : BaseEntity
    {
        [Required, MaxLength(36), Display(Name = "Role Id")]
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual t_Roles Roles { get; set; }

        [Required, MaxLength(36), Display(Name ="User Id")]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual t_Users Users { get; set; }
    }
}
