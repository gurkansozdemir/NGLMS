using AutoMapper;
using NGLMS.Core.DTOs;
using NGLMS.Core.Models;
using NGLMS.Core.Repositories;
using NGLMS.Core.Services;
using NGLMS.Core.UnitOfWorks;

namespace NGLMS.Service.Services
{
    public class ChatService : Service<Chat>, IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        public ChatService(IGenericRepository<Chat> repository, IUnitOfWork unitOfWork, IChatRepository chatRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<ChatWithMessage>> GetChatWithMessagesById(int id)
        {
            var chats = await _chatRepository.GetChatWithMessagesById(id);
            var chatWithMessageDto = _mapper.Map<ChatWithMessage>(chats);
            return CustomResponseDto<ChatWithMessage>.Success(200, chatWithMessageDto);
        }
    }
}
