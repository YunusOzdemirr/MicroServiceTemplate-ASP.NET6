using System;
namespace MicroServiceTemplate.Application.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User,Guid>
    {
    }
}

