using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using vm.application.contracts.Models;

namespace vm.application.contracts.User
{
    public interface IUser
    {
       ProfileModelOutput GetUserProfile(Guid userId);
        IActionResult CreateUserProfile(ProfileModel profile);
    }
}
