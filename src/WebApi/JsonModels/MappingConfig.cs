using DatabaseService;
using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public static class MappingConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<PostExtended, PostModel>();
            });
        }
    }
}
