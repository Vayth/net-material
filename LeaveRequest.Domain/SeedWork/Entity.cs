using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaveRequest.Domain.SeedWork
{
    public class Entity<TKey>
    {
        [Key]
        public TKey Id { get; protected set; }
        [Required]
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        [MaxLength(256)]
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
