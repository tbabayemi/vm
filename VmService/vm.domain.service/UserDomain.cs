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

        public ProfileModelOutput GetUserProfile(Guid userId)
        {
            var curProfile = _persistence.GetUserProfile(userId);
            if(curProfile == null)
            {
                return null;
            }

            return new ProfileModelOutput
            {
                Email = curProfile.Email,
                LastName = curProfile.LastName,
                FirstName = curProfile.FirstName,
                Metadata = new vm.application.contracts.Models.ProfileMetadata
                {

                    CreatedBy = curProfile.Metadata.CreatedBy,
                    CreatedDate = curProfile.Metadata.CreatedDate,
                    UpdatedBy = curProfile.Metadata.UpdatedBy,
                    UpdatedDate = curProfile.Metadata.UpdatedDate
                },
                Id = curProfile.Id,
                MetadataId = curProfile.Metadata.Id,
            };
        }

    }
}
