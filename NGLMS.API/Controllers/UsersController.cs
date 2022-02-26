using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGLMS.Core.DTOs;
using NGLMS.Core.Models;
using NGLMS.Core.Services;

namespace NGLMS.API.Controllers
{
    public class UsersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;

        public UsersController(IMapper mapper, IService<User> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _service.GetAllAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, userDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto paramUserDto)
        {
            var user = await _service.AddAsync(_mapper.Map<User>(paramUserDto));
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto paramUserDto)
        {
            await _service.UpdateAsync(_mapper.Map<User>(paramUserDto));
            return CreateActionResult(CustomResponseDto<UserDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(204));
        }
    }
}
