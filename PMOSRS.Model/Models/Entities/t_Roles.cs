using PMOSRS.Model.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Entities
{
    public class t_Roles : BaseEntity
    {
        [Required, MaxLength(50), Display(Name = "Role Name")]
        public string Name { get; set; }

        [Required, MaxLength(255), Display(Name = "Role Decription")]
        public string Description { get; set; }
    }
}
