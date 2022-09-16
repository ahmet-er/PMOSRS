using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMOSRS.Model.Models.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid? Id { get; set; }

        [Required, DataType(DataType.DateTime), Display(Name = "Create Date"), BindNever]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Update Date"), BindNever]
        public DateTime? UpdateDate { get; set; }

        [MaxLength(36), Display(Name = "Create User Id"), BindNever]
        public string CreateUserId { get; set; }

        [MaxLength(36), Display(Name = "Update User Id"), BindNever]
        public string UpdateUserId { get; set; }

        [Range(0, 1), Display(Name = ("Is Deleted")), BindNever]
        public int IsDeleted { get; set; }

    }
}
