using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Enums
{
    public enum IsDeletedEnum
    {
        [Display(Name = "Not Deleted")]
        NotDeleted=1,

        [Display(Name ="Deleted")]
        Deleted

    }
}
