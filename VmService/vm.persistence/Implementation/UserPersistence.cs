using System;
using System.Collections.Generic;
using System.Text;
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
        public Guid CreateUserProfile(Profile profile)
        {
            if(profile == null)
            {
                throw new ArgumentNullException("User Profile Argument is null");
            }

            try
            {
               var curProfile = _vmContext.Add(profile);
                return curProfile.Entity.Id;
            }
            catch(Exception exp)
            {

            }

            return Guid.Empty;
        }
    }
}
