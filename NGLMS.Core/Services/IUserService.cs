using NGLMS.Core.Models;

namespace NGLMS.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<IEnumerable<User>> Test();
    }
}
