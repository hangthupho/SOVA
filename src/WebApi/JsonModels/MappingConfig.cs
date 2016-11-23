using AutoMapper;
using DatabaseService;
using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public static class MappingConfig<src,dest>
    {
        public static dest Convert(src model)
        {
            Mapper.Initialize(config => config.CreateMap<src, dest>().ReverseMap());

            return Mapper.Map<dest>(model);
        }
    }
}
