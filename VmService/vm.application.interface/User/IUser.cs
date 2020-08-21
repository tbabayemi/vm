using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace vm.application.contracts.User
{
    public interface IUser
    {
       string GetUserProfile(string userId);
    }
}
