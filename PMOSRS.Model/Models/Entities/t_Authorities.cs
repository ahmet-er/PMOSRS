using PMOSRS.Model.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Entities
{
    public class t_Authorities : BaseEntity
    {
        [MaxLength(50), Display(Name = "Area Name")]
        public string AreaName { get; set; }

        [Required, MaxLength(50), Display(Name = "Controller Name")]
        public string ControllerName { get; set; }

        [Required, MaxLength(50), Display(Name = "Action Name")]
        public string ActionName { get; set; }

        [MaxLength(255), Display(Name = "Description")]
        public string Description { get; set; }
    }
}
