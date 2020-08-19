using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using vm.application.contracts.User;

namespace vm.domain.service.Controllers
{
    [Route("api/users")]
    public class UserController : IUser
    {
        private IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        public Task<IHttpActionResult> GetUserProfile(string userId)
        {
            return null;
        }
    }
}
