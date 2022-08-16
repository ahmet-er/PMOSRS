using PMOSRS.Model.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Entities
{
    public class t_Files : BaseEntity
    {
        [Required, MaxLength(36),  Display(Name ="Referans Id")]
        public string RefId { get; set; }

        [Required, MaxLength(36), Display(Name = "File Type Id")]
        public string FileTypeId { get; set; }

        [Required, MaxLength(36), Display(Name = "Table Type Id")]
        public string TableTypeId { get; set; }

        [Required, MaxLength(255), Display(Name = "File Path")]
        public string FilePath { get; set; }

        [Required, MaxLength(50), Display(Name = "File Name")]
        public string FileName { get; set; }


    }
}
