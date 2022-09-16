using PMOSRS.Model.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Entities
{
    public class t_Projects : BaseEntity
    {
        [Required(ErrorMessage ="Lütfen Proje Adını Giriniz."), MaxLength(50, ErrorMessage ="Lütfen Proje Adını En Fazla 50 Karakter Giriniz."), Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required, MaxLength(255), Display(Name = "Project Description")]
        public string Description { get; set; }
    }
}
