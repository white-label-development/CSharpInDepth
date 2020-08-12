using AutoMapper;
using automapper_fun.Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automapper_fun.Maps
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Developer, DeveloperDto>() // all the like for like mappings
                .ForMember(dest => dest.Compensation, source => source.MapFrom(source => source.Salary)) // Specific Mapping

                //ignore 1: if destination has no partner to source, source is ognored. It's all about dest.
                //ignore 2: ignore mapping to dest via
                .ForMember(dest => dest.Id, source => source.Ignore()) // will not map Id on dest.

                .ForMember(dest => dest.IsEmployed, source => source.MapFrom(source => source.Salary > 0 ? true : false)) // Conditional Mapping
                .ForMember(dest => dest.FirstName, source => source.MapFrom(src => (src.FirstName.StartsWith("A") ? "AName" : src.FirstName))) // Conditional Mapping

                .ForMember(dest => dest.Experience, source => source.Condition(src => src.Experience > 3)) // use of Condition for conditional mapping

                .ForMember(dest => dest.FooPrimitiveTypeFromComplexType, source => source.MapFrom(src => src.ComplexType.Foo)) // Complex type to Primitive Type

                .ForMember(dest => dest.ComplexType, source => source.MapFrom(src => new ComplexTypeDto
                {
                    Prop1 = src.Prop1,
                    Prop2 = src.Prop2
                }))

                .ReverseMap() //bi-directional. Needs mapping for Complext to Primitive
                    .ForMember(dest => dest.Prop1, source => source.MapFrom(src => src.ComplexType.Prop1))
                    .ForMember(dest => dest.Prop2, source => source.MapFrom(src => src.ComplexType.Prop2));

            CreateMap<Address, AddressDto>()
                .ReverseMap();

        }
    }
}
