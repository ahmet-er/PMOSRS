using PMOSRS.Model.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Entities
{
    public class t_Users : BaseEntity
    {
        [Required, MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$", ErrorMessage = "Incorrect Email Format!")]
        [Required, MaxLength(350), Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, MaxLength(256), Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
