using System;
using System.ComponentModel.DataAnnotations;

namespace PMOSRS.Model.Models.Base
{
    public abstract class BaseEntity
    {
        [Key, MaxLength(36)]
        public Guid Id { get; set; }

        [Required, DataType(DataType.DateTime), Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }

        [Required, MaxLength(36), Display(Name = "Create User Id")]
        public string CreateUserId { get; set; }

        [MaxLength(36), Display(Name = "Update User Id")]
        public string UpdateUserId { get; set; }

        [Range(0, 1), Display(Name = ("Is Deleted"))]
        public int IsDeleted { get; set; }

    }
}
