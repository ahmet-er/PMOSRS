using PMOSRS.Model.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Entities
{
    public class t_Settings : BaseEntity
    {
        [Required, MaxLength(50), Display(Name = "Version")]
        public string Version { get; set; }
    }
}
