
using AutoMapper;
using System.Application.Main.Dtos.Test;
using System.Domain.Entities.TestModule;

namespace System.Application.Service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TestEntity, TestDto>();
            //CreateMap<CategoriaEntity, CategoriaDto>();
        }
    }
}
