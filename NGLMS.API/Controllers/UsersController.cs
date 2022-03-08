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
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IService<User> service, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> Test()
        //{
        //    return await _userService.GetAllAsync();
        //}

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, userDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto paramUserDto)
        {
            var user = await _userService.AddAsync(_mapper.Map<User>(paramUserDto));
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto paramUserDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(paramUserDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
