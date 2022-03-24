using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = BE.DAL.DO.Objects;

namespace BE.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Customers, DataModels.Customers>().ReverseMap();
            CreateMap<data.CustomerDemographics, DataModels.CustomerDemographics>().ReverseMap();
            CreateMap<data.CustomerCustomerDemo, DataModels.CustomerCustomerDemo>().ReverseMap();
        }
    }
}
