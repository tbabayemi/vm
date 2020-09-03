using System;
using System.Collections.Generic;
using System.Text;

namespace vm.application.contracts.Models
{
    public class ProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ProfileMetadata Metadata { get; set; }
    }
}
