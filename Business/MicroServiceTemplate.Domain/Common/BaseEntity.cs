using System;
namespace MicroServiceTemplate.Domain.Common
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; } 
        public TId CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public TId ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

