using System;
namespace MicroServiceTemplate.Domain.Common
{
    public interface IRepository<T>
	{
        IUnitOfWork UnitOfWork { get; }
    }
}

