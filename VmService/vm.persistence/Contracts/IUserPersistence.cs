using System;
using System.Collections.Generic;
using System.Text;
using vm.application.contracts.Models;
using vm.persistence.Entities;

namespace vm.persistence.Contracts
{
    public interface IUserPersistence
    {
        Guid CreateUserProfile(Profile profile);
        Profile GetUserProfile(Guid Id);
    }
}
