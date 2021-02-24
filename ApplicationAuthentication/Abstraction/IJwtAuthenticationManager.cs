using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAuthentication.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        Task<Tuple<string,int>> AuthenticateAsync(UserAuthDto data);
        void SetUserRepo(IRepository<User> usersRepo);
    }
}
