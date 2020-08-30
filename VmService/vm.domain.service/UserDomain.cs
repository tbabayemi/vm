using AutoMapper;
using System;
using vm.application.contracts.Models;
using vm.domain.service.Contracts;
using vm.persistence.Contracts;

namespace vm.domain.service
{
    public class UserDomain: IUserDomain
    {
        private IUserPersistence _persistence;
        private IMapper _mapper;

        public UserDomain(IUserPersistence persistence, IMapper mapper)
        {
            _persistence = persistence;
            _mapper = mapper;
        }
        public Guid CreateUserProfile(ProfileModel userProfile)
        {
            var entityProfile = _mapper.Map<vm.persistence.Entities.Profile>(userProfile);
            return _persistence.CreateUserProfile(entityProfile);
        }

    }
}
