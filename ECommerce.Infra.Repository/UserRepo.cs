using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;


namespace ECommerce.Infra.Repository
{
    public class UserRepo : IUser
    {
        private readonly ECommerceContext _eCommerceContext;

        public UserRepo(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public async Task<User> AddUser(User u1)
        {
            _eCommerceContext.Users.Add(u1);
            await _eCommerceContext.SaveChangesAsync();
            return u1;

        }

        public async Task<User> UserLogin(int id)
        {
            var user = _eCommerceContext.Users.FirstOrDefault(x => x.Id == id);
            await _eCommerceContext.SaveChangesAsync();
            return user;
        }
    }
}
