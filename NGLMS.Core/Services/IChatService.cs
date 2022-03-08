using NGLMS.Core.DTOs;
using NGLMS.Core.Models;

namespace NGLMS.Core.Services
{
    public interface IChatService : IService<Chat>
    {
        Task<CustomResponseDto<ChatWithMessage>> GetChatWithMessagesById(int id);
    }
}
