using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using vm.application.contracts.Models;

namespace vm.domain.service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProfileModel, vm.persistence.Entities.Profile>().ForPath(pf => pf.ProfileMetadata.CreatedDate, opt => opt.MapFrom(pfe => pfe.CreatedDate == default(DateTime) ? DateTime.Now : pfe.CreatedDate));
        }
    }
}
