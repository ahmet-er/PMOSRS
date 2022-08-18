using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Entities
{
    public class t_IsDeletedEnums
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, MaxLength(50), Display(Name = "Display Name")]
        public string DisplayName { get; set; }
    }
}
