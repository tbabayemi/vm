using Autofac;
using AutoMapper;
using vm.domain.service.Contracts;
using vm.persistence.Contracts;

namespace vm.domain.service.Modules
{
    public class DomainModule : Module
    {
        private IUserPersistence _peristence;
        private IMapper _mapper;

        public DomainModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
            {

                IUserPersistence persistence = ctx.Resolve<IUserPersistence>();
                IMapper mapper = ctx.Resolve<IMapper>();
                return new UserDomain(persistence, mapper);

            }).As<IUserDomain>().InstancePerLifetimeScope();
        }
    }
}
