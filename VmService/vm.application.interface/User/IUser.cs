using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace vm.application.contracts.User
{
    public interface IUser
    {
        Task<IHttpActionResult> GetUserProfile(string userId);
    }
}
