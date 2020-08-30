using vm.application.contracts.User;
using Microsoft.AspNetCore.Mvc;
using vm.application.contracts.Models;
using vm.domain.service.Contracts;
using System;
using Microsoft.AspNetCore.Http;

namespace vm.service.Controllers
{
    [ApiController]
    public class UserController : ControllerBase, IUser
    {
        private IUserDomain _domainService;
        public UserController(IUserDomain domainService)
        {
            _domainService = domainService;
        }

        [HttpGet("/users/profiles")]
        public string GetUserProfile(string userId)
        {
            return "profile";
        }

        [HttpPost("/users/profile")]
        public IActionResult CreateProfile([FromBody] ProfileModel profile)
        {
            try
            {
               var profileId =_domainService.CreateUserProfile(profile);
                if (Guid.Empty == profileId)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(profileId);
                }
            }
            catch(Exception exp)
            {
                //Log with NLOG
                var result = StatusCode(StatusCodes.Status500InternalServerError, exp);
                return result;
            }

        }
    }
}
