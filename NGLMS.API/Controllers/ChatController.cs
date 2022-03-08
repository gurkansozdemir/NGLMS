using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NGLMS.Core.DTOs;
using NGLMS.Core.Models;
using NGLMS.Core.Services;

namespace NGLMS.API.Controllers
{
    public class ChatController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IChatService _chatService;

        public ChatController(IMapper mapper, IChatService chatService)
        {
            _mapper = mapper;
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var chats = await _chatService.GetAllAsync();
            var chatDtos = _mapper.Map<List<ChatDto>>(chats.ToList());
            return CreateActionResult(CustomResponseDto<List<ChatDto>>.Success(200, chatDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChatDto paramChatDto)
        {
            var chat = await _chatService.AddAsync(_mapper.Map<Chat>(paramChatDto));
            var chatDto = _mapper.Map<ChatDto>(chat);
            return CreateActionResult(CustomResponseDto<ChatDto>.Success(201, chatDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ChatWithMessagesById(int id)
        {
            return CreateActionResult(await _chatService.GetChatWithMessagesById(id));
        }
    }
}
