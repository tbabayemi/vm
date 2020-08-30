using System;
using System.Collections.Generic;
using System.Text;
using vm.application.contracts.Models;

namespace vm.domain.service.Contracts
{
    public interface IUserDomain
    {
        Guid CreateUserProfile(ProfileModel profileModel);
    }
    
}
