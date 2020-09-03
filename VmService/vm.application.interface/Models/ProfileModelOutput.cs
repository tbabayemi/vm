using System;
namespace vm.application.contracts.Models
{
    public class ProfileModelOutput : ProfileModel
    {
        public Guid Id { get; set; }
        public Guid MetadataId { get; set; }
    }
}
