using Microsoft.EntityFrameworkCore;
using NGLMS.Core.Models;
using NGLMS.Core.Repositories;

namespace NGLMS.Repository.Repositories
{
    public class UserRepository : GenericRespository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<User>> Test()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
