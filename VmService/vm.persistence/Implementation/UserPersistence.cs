using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using vm.application.contracts.Models;
using vm.persistence.Contracts;
using vm.persistence.Data;
using vm.persistence.Entities;

namespace vm.persistence.Implementation
{
    public class UserPersistence : IUserPersistence
    {
        private VmContext _vmContext;
        public UserPersistence(VmContext context)
        {
            _vmContext = context;
        }

        public Profile GetUserProfile(Guid id)
        {
            return _vmContext.Profiles.Include(p => p.Metadata).FirstOrDefault<Profile>();
            
        }
        public Guid CreateUserProfile(Profile profile)
        {
            if(profile == null)
            {
                throw new ArgumentNullException("User Profile Argument is null");
            }

            
            var curProfile = _vmContext.Add(profile);

            return curProfile.Entity.Id;
        }
    }
}
