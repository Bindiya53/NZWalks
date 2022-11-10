using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZWalks.NZWalks.Infrastructure.Data;

namespace NZWalks.NZWalks.Service.Contracts
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string UserName , string Password);
    }
}