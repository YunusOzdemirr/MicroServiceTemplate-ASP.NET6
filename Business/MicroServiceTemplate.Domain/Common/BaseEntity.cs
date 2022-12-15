using System;
using System.Security.Cryptography;
using MediatR;

namespace MicroServiceTemplate.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

        int? _requestedHashCode;

        private List<INotification> domainEvents;

        public IReadOnlyCollection<INotification> DomainEvents => domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            domainEvents = domainEvents ?? new List<INotification>();
            domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            if (Id.GetType() == typeof(Guid))
                return true;
            if (Id == null)
                return false;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            BaseEntity item = (BaseEntity)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
    }
}

