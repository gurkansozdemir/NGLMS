using Microsoft.EntityFrameworkCore;
using NGLMS.Core.Models;
using NGLMS.Core.Repositories;

namespace NGLMS.Repository.Repositories
{
    public class ChatRepository : GenericRespository<Chat>, IChatRepository
    {
        public ChatRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Chat>> GetChatWithMessagesById(int id)
        {
            return await _context.Chats.Where(x => x.Id == id).Include(x => x.Messages).ToListAsync();
        }
    }
}
