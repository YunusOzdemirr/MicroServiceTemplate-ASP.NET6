using System;
using MicroServiceTemplate.Domain.Common;

namespace MicroServiceTemplate.Domain.Entities
{
    public class User:BaseEntity<Guid>, IEntity
    {
        public string FirstName { get; set; }
    }
}

