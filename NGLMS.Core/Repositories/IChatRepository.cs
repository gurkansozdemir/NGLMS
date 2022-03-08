using NGLMS.Core.Models;

namespace NGLMS.Core.Repositories
{
    public interface IChatRepository : IGenericRepository<Chat>
    {
        Task<List<Chat>> GetChatWithMessagesById(int id);
    }
}
