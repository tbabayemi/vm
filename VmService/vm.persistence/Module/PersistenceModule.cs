using Autofac;
using Microsoft.Extensions.Logging;
using vm.persistence.Contracts;
using vm.persistence.Data;
using vm.persistence.Implementation;

namespace vm.persistence.Module
{ 
    public class PersistenceModule: Autofac.Module
    {
        private VmContext _vmContext;
        public PersistenceModule(VmContext context)
        {
            _vmContext = context;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new UserPersistence(_vmContext)).As<IUserPersistence>();
        }
    }
}
