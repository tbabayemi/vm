using vm.application.contracts.User;
using Microsoft.AspNetCore.Mvc;
using vm.application.contracts.Models;
using vm.domain.service.Contracts;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace vm.service.Controllers
{
    [ApiController]
    public class UserController : ControllerBase, IUser
    {
        private IUserDomain _domainService;
        readonly ILogger<UserController> _logger;

        public UserController(IUserDomain domainService, ILogger<UserController> logger)
        {
            _logger = logger;
            _domainService = domainService;
        }

        [HttpGet("/users/profiles/{id}")]
        public ProfileModelOutput GetUserProfile(Guid id)
        {
            return _domainService.GetUserProfile(id);
        }

        [HttpPost("/users/profile")]
        public IActionResult CreateUserProfile([FromBody] ProfileModel profile)
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
