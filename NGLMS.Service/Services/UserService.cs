using AutoMapper;
using NGLMS.Core.Models;
using NGLMS.Core.Repositories;
using NGLMS.Core.Services;
using NGLMS.Core.UnitOfWorks;

namespace NGLMS.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> Test()
        {
            var users = await _userRepository.Test();
            var userDtos = _mapper.Map<List<User>>(users);
            return userDtos;
        }
    }
}
