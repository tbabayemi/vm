using System;
using Autofac;
using vm.application.contracts.User;
using vm.domain.service.Controllers;

namespace vm.domain.service.Modules
{
    public class ProfileModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(controller => new UserController()).As<IUser>();
        }
    }
}
