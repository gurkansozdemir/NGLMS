using NGLMS.Core.Models;

namespace NGLMS.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> Test();
    }
}
