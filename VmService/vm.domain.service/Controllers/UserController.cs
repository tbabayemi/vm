using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using vm.application.contracts.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace vm.domain.service.Controllers
{
    [ApiController]
    public class UserController : ControllerBase, IUser
    {
        public UserController()
        {

        }

        [HttpGet("/users/profiles")]
        public string GetUserProfile(string userId)
        {
            return "profile";
        }
    }
}
