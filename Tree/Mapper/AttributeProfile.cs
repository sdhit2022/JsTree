using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tree.Models;
using Tree.Models.Dto;

namespace Tree.Mapper
{
    public class AttributeProfile:Profile
    {
        public AttributeProfile()
        {
            CreateMap<Models.Attribute, AttributeDto>().ReverseMap();
        }
    }
}
