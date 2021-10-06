using AutoMapper;
using GEL.Services.PostAPI.Dtos;
using GEL.Services.PostAPI.Models;

namespace GEL.Services.PostAPI.Profiles
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Sources => Targets
                config.CreateMap<PostDto, Post>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
