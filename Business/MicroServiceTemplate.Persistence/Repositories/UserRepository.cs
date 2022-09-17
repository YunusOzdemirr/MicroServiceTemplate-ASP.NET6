using System;
using MicroServiceTemplate.Domain.Entities;

namespace MicroServiceTemplate.Persistence.Repositories
{
    public class UserRepository:GenericRepository<User,Guid>,IUserRepository
    {
        public UserRepository()
        {
        }
    }
}

