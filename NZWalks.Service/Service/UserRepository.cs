using NZWalks.Infrastructure.Contracts;
using NZWalks.NZWalks.Infrastructure.Data;
using NZWalks.NZWalks.Service.Contracts;

namespace NZWalks.NZWalks.Service.Service
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users= new List<User>
        {
            new User()
            {
                FirstName = "Bindiya", LastName = "Tandel", EmailAddress = "bindi@gmail.com",
                Id = Guid.NewGuid(), UserName = "Bindiya.Tandel", Password = "Bindiya",
                Roles = new List<string>{"reader"}
            }
        };
        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            var user =  Users.Find(x => x.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password ==  password);

            return user;
            
        }
    }
}